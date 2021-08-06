using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseXClient
{
    public static class MorseCodeTranslator
    {
        static Dictionary<char, string> translator;

        public static void InitialiseDictionary()
        {
            char dot = '.';
            char dash = '−';

            translator = new Dictionary<char, string>()
            {
                {'a', string.Concat(dot, dash)},
                {'b', string.Concat(dash, dot, dot, dot)},
                {'c', string.Concat(dash, dot, dash, dot)},
                {'d', string.Concat(dash, dot, dot)},
                {'e', dot.ToString()},
                {'f', string.Concat(dot, dot, dash, dot)},
                {'g', string.Concat(dash, dash, dot)},
                {'h', string.Concat(dot, dot, dot, dot)},
                {'i', string.Concat(dot, dot)},
                {'j', string.Concat(dot, dash, dash, dash)},
                {'k', string.Concat(dash, dot, dash)},
                {'l', string.Concat(dot, dash, dot, dot)},
                {'m', string.Concat(dash, dash)},
                {'n', string.Concat(dash, dot)},
                {'o', string.Concat(dash, dash, dash)},
                {'p', string.Concat(dot, dash, dash, dot)},
                {'q', string.Concat(dash, dash, dot, dash)},
                {'r', string.Concat(dot, dash, dot)},
                {'s', string.Concat(dot, dot, dot)},
                {'t', string.Concat(dash)},
                {'u', string.Concat(dot, dot, dash)},
                {'v', string.Concat(dot, dot, dot, dash)},
                {'w', string.Concat(dot, dash, dash)},
                {'x', string.Concat(dash, dot, dot, dash)},
                {'y', string.Concat(dash, dot, dash, dash)},
                {'z', string.Concat(dash, dash, dot, dot)},
                {'0', string.Concat(dash, dash, dash, dash, dash)},
                {'1', string.Concat(dot, dash, dash, dash, dash)},
                {'2', string.Concat(dot, dot, dash, dash, dash)},
                {'3', string.Concat(dot, dot, dot, dash, dash)},
                {'4', string.Concat(dot, dot, dot, dot, dash)},
                {'5', string.Concat(dot, dot, dot, dot, dot)},
                {'6', string.Concat(dash, dot, dot, dot, dot)},
                {'7', string.Concat(dash, dash, dot, dot, dot)},
                {'8', string.Concat(dash, dash, dash, dot, dot)},
                {'9', string.Concat(dash, dash, dash, dash, dot)}
            };
        }

        public static void getUserInput()
        {
            string input;
            Console.WriteLine("What did you want to say?");
            input = Console.ReadLine();
            input = input.ToLower();
            Console.WriteLine("Your output is: " + translate(input));
            Console.WriteLine("Press enter to end.");
            Console.ReadLine();
        }

        public static string translate(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char character in input)
            {
                if (translator.ContainsKey(character))
                {
                    sb.Append(translator[character] + " ");
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
            //{ "....","&" }, // multiplication
            { ".--.-.","@" }, // At the rate of

            // Brackets
            { "-.--.","(" }, // Left bracket
            { "-.--.-",")" }, // right bracket 
        };

        private static string[] MorseRuleUpdate(string morse)
        {
            if (string.IsNullOrEmpty(morse)) return null;
            return morse.Trim().Replace(Environment.NewLine,"").Split('/');
        }

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
