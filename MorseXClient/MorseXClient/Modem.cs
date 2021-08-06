namespace MorseCode
{
    using MorseXClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Media;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class Modem
    {
        [DllImport("winmm.dll")]
        private static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

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
            SetVolume(5);
        }

        /// <summary>
        /// Sets volume from 0 to 10
        /// </summary>
        /// <param name="volume">Volume from 0 to 10</param>
        public static void SetVolume(int volume)
        {
            int NewVolume = ((ushort.MaxValue / 10) * volume);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        /// <summary>
        /// Returns volume from 0 to 10
        /// </summary>
        /// <returns>Volume from 0 to 10</returns>
        public static int GetVolume()
        {
            uint CurrVol = 0;
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            int volume = CalcVol / (ushort.MaxValue / 10);
            return volume;
        }

        public Modem()
        {
            codeStore = new Codes();
        }

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
                dotSound.Play();
                morseValue.Text += ".";
                ParseMorseStr += ".";
                return;
            }
            if (morseStringOrSentence == "[DASH]")
            {
                dashSound.Play();
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
                            dotSound.Play();
                            Task dotTask = Task.Run(ShowDot);
                            dotTask.Wait();
                            break;
                        case '-':
                            dashSound.Play();
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
                //Thread.Sleep(100);
            }
            else
            {
                PlayMorseTone(ConvertToMorseCode(morseStringOrSentence));
            }
        }

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