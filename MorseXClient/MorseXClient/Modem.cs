namespace MorseCode
{
    using MorseXClient;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class Modem
    {
        SoundPlayer dotSound = new SoundPlayer(FileUtil.DotSoundPath);
        SoundPlayer dashSound = new SoundPlayer(FileUtil.DashSoundPath);
        
        private int TimeUnitInMilliSeconds { get; set; } = 100;
        private string ParseMorseStr = "";

        Codes codeStore;
        TextBox morseValue;
        TextBox parseText;

        public Modem(Main _main)
        {
            codeStore = new Codes();
            morseValue = _main.MorseText;
            parseText = _main.ParseText;
            dotSound.Load();
            dashSound.Load();
        }
        
        public Modem()
        {
            codeStore = new Codes();
        }

        /// <returns></returns>
        public string ConvertToMorseCode(string sentence, bool addStartAndEndSignal = false)
        {
            var generatedCodeList = new List<string>();
            var wordsInSentence = sentence.Split(' ');

            if (addStartAndEndSignal)
            {
                generatedCodeList.Add(codeStore.GetSignalCode(SignalCodes.StartingSignal));
            }

            foreach (var word in wordsInSentence)
            {
                foreach (var letter in word.ToUpperInvariant().ToCharArray())
                {
                    generatedCodeList.Add(codeStore[letter]);
                }
                generatedCodeList.Add("_");
            }

            if (addStartAndEndSignal)
            {
                generatedCodeList.Add(codeStore.GetSignalCode(SignalCodes.EndOfWork));
            }
            else
            {
                generatedCodeList.RemoveAt(generatedCodeList.Count - 1);
            }

            return string.Join(" ", generatedCodeList).Replace(" _ ", "  ");
        }

        public async Task ShowDot()
        {
            await Task.Delay(100);
            morseValue.Text += ".";
            ParseMorseStr += ".";
        }

        public async Task ShowDash()
        {
            await Task.Delay(200);
            morseValue.Text += "-";
            ParseMorseStr += "-";
        }

        public void PlayDash()
        {
            if (File.Exists(FileUtil.DashSoundPath))
            {
                dashSound.Play();
            }
            else
            {
                FileUtil.ExtractResFile("MorseXClient.Sound.dash.wav", FileUtil.DashSoundPath);
                dashSound.Play();
            }
        }

        public void PlayDot()
        {
            if (File.Exists(FileUtil.DotSoundPath))
            {
                dashSound.Play();
            }
            else
            {
                FileUtil.ExtractResFile("MorseXClient.Sound.dot.wav", FileUtil.DotSoundPath);
                dotSound.Play();
            }
        }

        /// <summary>
        /// 播放摩斯电码
        /// </summary>
        /// <param name="morseStringOrSentence"></param>
        public void PlayMorseTone(string morseStringOrSentence)
        {
            if (morseStringOrSentence == "ERROR DATA") {
                return;
            }
            MessageUtil check = new MessageUtil();
            if (!check.CheckMessage(morseStringOrSentence)) {
                return;
            }
            if (morseStringOrSentence == "[DOT]")
            {
                //dotSound.Play();
                Thread dot = new Thread(new ThreadStart(PlayDot));
                dot.Start();
                morseValue.Text += ".";
                ParseMorseStr += ".";
                return;
            }
            if (morseStringOrSentence == "[DASH]")
            {
                //dashSound.Play();
                Thread dash = new Thread(new ThreadStart(PlayDash));
                dash.Start();
                morseValue.Text += "-";
                ParseMorseStr += "-";
                return;
            }
            if (morseStringOrSentence == "[SPLIT]")
            {
                morseValue.Text += "/";
                string morse = MorseCodeTranslator.DecodeMorse(ParseMorseStr);
                if (string.IsNullOrEmpty(morse)) { ParseMorseStr = "";  return; }
                parseText.Text += morse + " ";
                ParseMorseStr = "";
                return;
            }
            if (morseStringOrSentence == "[NEWLINE]")
            {
                ParseMorseStr = "";
                morseValue.Text += Environment.NewLine;
                return;
            }
            if (IsValidMorse(morseStringOrSentence))
            {
                var pauseBetweenLetters = "_"; // One Time Unit
                var pauseBetweenWords = "_______"; // Seven Time Unit

                morseStringOrSentence = morseStringOrSentence.Replace("  ", pauseBetweenWords);
                morseStringOrSentence = morseStringOrSentence.Replace(" ", pauseBetweenLetters);

                foreach (var character in morseStringOrSentence.ToCharArray())
                {
                    switch (character)
                    {
                        case '.':
                            //dotSound.Play();
                            Thread dot = new Thread(new ThreadStart(PlayDot));
                            dot.Start();
                            Task dotTask = Task.Run(ShowDot);
                            dotTask.Wait();
                            break;
                        case '-':
                            //dashSound.Play();
                            Thread dash = new Thread(new ThreadStart(PlayDash));
                            dash.Start();
                            Task dashTask = Task.Run(ShowDash);
                            dashTask.Wait();
                            break;
                        case '_':
                            morseValue.Text += "/";
                            Thread.Sleep(TimeUnitInMilliSeconds);
                            string morse = MorseCodeTranslator.DecodeMorse(ParseMorseStr);
                            if (string.IsNullOrEmpty(morse)) { ParseMorseStr = ""; return; }
                            parseText.Text += morse + " ";
                            ParseMorseStr = "";
                            break;
                    }
                }
            }
            else
            {
                PlayMorseTone(ConvertToMorseCode(morseStringOrSentence));
            }
        }

        /// <summary>
        /// 判断是否是摩斯电码
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private bool IsValidMorse(string sentence)
        {
            var countDot = sentence.Count(x => x == '.');
            var countDash = sentence.Count(x => x == '-');
            var countSpace = sentence.Count(x => x == ' ');

            return
                sentence.Length > (countDot + countDash + countSpace)
                ? false : true;
        }
    }
}