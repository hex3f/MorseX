using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseXClient
{
    enum WindowType {
        Log,
        Morse,
        Parse,
    }
    public partial class LogWindow : Form
    {
        WindowType type;

        public LogWindow()
        {
            InitializeComponent();
        }

        private void LogWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (type)
            {
                case WindowType.Log:
                    Main.LogValueList.Remove(this);
                    break;
                case WindowType.Morse:
                    Main.MorseValueList.Remove(this);
                    break;
                case WindowType.Parse:
                    Main.ParseValueList.Remove(this);
                    break;
                default:
                    break;
            }
        }

        private void LogWindowText_TextChanged(object sender, EventArgs e)
        {
            //文本框选中的起始点在最后
            LogWindowText.SelectionStart = LogWindowText.TextLength;
            //将控件内容滚动到当前插入符号位置
            LogWindowText.ScrollToCaret();
        }
    }
}
