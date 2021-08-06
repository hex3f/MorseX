using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseXClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileUtil.ExtractResFile("MorseXClient.Sound.dash.wav", FileUtil.DashSoundPath);
            FileUtil.ExtractResFile("MorseXClient.Sound.dot.wav", FileUtil.DotSoundPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
