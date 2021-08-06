using MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MorseXClient
{
    public class MessageUtil
    {
        Modem modem = new Modem();
        public bool CheckMessage(string message) {
            if (!Util.IsNumAndEnCh(message) || !Util.IsNumAndEnCh(modem.ConvertToMorseCode(message)))
            {
                if (message != "[DOT]" || message != "[DASH]" || message != "[SPLIT]" || message != "[NEWLINE]") return false;
            }
            return true;
        }
    }

    public static class Util
    {
        /// <summary>
        /// 判断输入的字符串是否只包含数字和英文字母
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumAndEnCh(string input)
        {
            string pattern = @"^[a-zA-Z0-9 .:,;?='/!-_""$&@]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
