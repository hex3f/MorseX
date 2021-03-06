namespace MorseCode
{
    using System.Collections.Generic;

    public class Codes
    {
        public string this[char character]
        {
            get
            {
                string code = string.Empty;
                SymbolCodes.TryGetValue(character, out code);
                return code;
            }
        }

        public string GetSignalCode(SignalCodes code)
        {
            switch (code)
            {
                case SignalCodes.StartingSignal:
                    return SignalMorseCodes[0];
                case SignalCodes.InvitationToTransmit:
                    return SignalMorseCodes[1];
                case SignalCodes.Understood:
                    return SignalMorseCodes[2];
                case SignalCodes.Error:
                    return SignalMorseCodes[3];
                case SignalCodes.Wait:
                    return SignalMorseCodes[4];
                case SignalCodes.EndOfWork:
                    return SignalMorseCodes[5];
                default:
                    return string.Empty;
            }
        }

        private static Dictionary<char, string> SymbolCodes = new Dictionary<char, string>
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

        private static Dictionary<int, string> SignalMorseCodes = new Dictionary<int, string> {
            { 0,"-.-.-" },
            { 1,"-.-" },
            { 2,"...-." },
            { 3,"........" },
            { 4,".-..." },
            { 5,"...-.-" },
        };

    }
}