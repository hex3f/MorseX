using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseXClient
{
    /// <summary>
    /// 摩斯电码翻译 - 翻译表在这里
    /// </summary>
    public static class MorseCodeTranslator
    {

        //摩斯电码翻译表
        private static Dictionary<char, string> translator = new Dictionary<char, string>
        {
            // Characters
            { 'A',".-" },
            { 'B',"-..." },
            { 'C',"-.-." },
            { 'D',"-.." },
            { 'E',"." },
            { 'F',"..-." },
            { 'G',"--." },
            { 'H',"...." },
            { 'I',".." },
            { 'J',".---" },
            { 'K',"-.-" },
            { 'L',".-.." },
            { 'M',"--" },
            { 'N',"-." },
            { 'O',"---" },
            { 'P',".--." },
            { 'Q',"--.-" },
            { 'R',".-." },
            { 'S',"..." },
            { 'T',"-" },
            { 'U',"..-" },
            { 'V',"...-" },
            { 'W',".--" },
            { 'X',"-..-" },
            { 'Y',"-.--" },
            { 'Z',"--.." },

            { 'a',".-" },
            { 'b',"-..." },
            { 'c',"-.-." },
            { 'd',"-.." },
            { 'e',"." },
            { 'f',"..-." },
            { 'g',"--." },
            { 'h',"...." },
            { 'i',".." },
            { 'j',".---" },
            { 'k',"-.-" },
            { 'l',".-.." },
            { 'm',"--" },
            { 'n',"-." },
            { 'o',"---" },
            { 'p',".--." },
            { 'q',"--.-" },
            { 'r',".-." },
            { 's',"..." },
            { 't',"-" },
            { 'u',"..-" },
            { 'v',"...-" },
            { 'w',".--" },
            { 'x',"-..-" },
            { 'y',"-.--" },
            { 'z',"--.." },

            // Numbers
            { '0',"-----" },
            { '1',".----" },
            { '2',"..---" },
            { '3',"...--" },
            { '4',"....-" },
            { '5',"....." },
            { '6',"-...." },
            { '7',"--..." },
            { '8',"---.." },
            { '9',"----." },
           
            // Special Characters
            { '.',".-.-.-" }, // Fullstop
            { ':',"---..." }, // Colon
            { ',',"--..--" }, // Comma
            { ';',"-.-.-."},
            { '?',"..--.." }, // Question Mark
            { '=',"-...-" }, // Equal sign
            { '/',"-..-." }, // Slash. division
            { '!',"-.-.--"},
            { '-',"-....-" }, // Hyphen, dash, minus
            { '_',"..--.-"},
            { '"',".-..-." }, // Quotaion mark
            { '$',"...-..-" }, // Plus
            //{ '&',"...." }, // multiplication
            { '@',".--.-." }, // At the rate of

            // Brackets
            { '(',"-.--." }, // Left bracket
            { ')',"-.--.-" }, // right bracket         
        };

        public static string translate(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char character in input)
            {
                if (translator.ContainsKey(character))
                {
                    sb.Append(translator[character] + "/");
                }
                else if (character == ' ')
                {
                    sb.Append("/ ");
                }
                else
                {
                    sb.Append(character + " ");
                }
            }
            return sb.ToString();
        }



        private static Dictionary<string, string> MorseList = new Dictionary<string, string>()
        {
            // Characters
            { ".-", "A" },
            { "-...", "B" },
            { "-.-.", "C" },
            { "-..", "D" },
            { ".", "E" },
            { "..-.", "F" },
            { "--.", "G" },
            { "....", "H" },
            { "..", "I" },
            { ".---", "J" },
            { "-.-", "K" },
            { ".-..", "L" },
            { "--", "M" },
            { "-.", "N" },
            { "---", "O" },
            { ".--.", "P" },
            { "--.-", "Q" },
            { ".-.", "R" },
            { "...", "S" },
            { "-", "T" },
            { "..-", "U" },
            { "...-", "V" },
            { ".--", "W" },
            { "-..-", "X" },
            { "-.--", "Y" },
            { "--..", "Z" },

            // Numbers
            { "-----","0" },
            { ".----","1" },
            { "..---","2" },
            { "...--","3" },
            { "....-","4" },
            { ".....","5" },
            { "-....","6" },
            { "--...","7" },
            { "---..","8" },
            { "----.","9" },

            // Special Characters
            { ".-.-.-","." }, // Fullstop
            { "---...",":" }, // Colon
            { "--..--","," }, // Comma
            { "-.-.-.",";"},
            { "..--..","?" }, // Question Mark
            { "-...-","=" }, // Equal sign
            { "-..-.","/" }, // Slash. division
            { "-.-.--","!"},
            { "-....-","-" }, // Hyphen, dash, minus
            { "..--.-","_"},
            { ".-..-.","\"" }, // Quotaion mark
            { "...-..-","$" }, // Plus
            { ".--.-.","@" }, // At the rate of

            // Brackets
            { "-.--.","(" }, // Left bracket
            { "-.--.-",")" }, // right bracket 
        };

        /// <summary>
        /// 摩斯电码格式化
        /// </summary>
        /// <param name="morse">摩斯电码</param>
        /// <returns></returns>
        private static string[] MorseRuleUpdate(string morse)
        {
            if (string.IsNullOrEmpty(morse)) return null;
            return morse.Trim().Replace(Environment.NewLine,"").Split('/');
        }

        /// <summary>
        /// 解码摩斯电码
        /// </summary>
        /// <param name="morse">摩斯电码</param>
        /// <returns></returns>
        public static string DecodeMorse(string morse) {
            string[] morseArray = MorseRuleUpdate(morse);
            if (morseArray == null) return null;
            string Result = "";
            foreach (var morseItem in morseArray)
            {
                if (MorseList.ContainsKey(morseItem))
                {
                    foreach (var item in MorseList)
                    {
                        if (item.Key == morseItem)
                        {
                            Result += item.Value + " ";
                        }
                    }
                }
                continue;
            }
            return Result;
        }

    }
}
