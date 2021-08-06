using MorseCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseXClient
{
    enum SendMode {
        OneByOneMode,
        RepeatMode,
        AllMode,
    }
    public partial class Main : Form
    {
        private Thread SERVER_STATIS;
        private Socket clientSocket = null;
        private static bool isListen = true;
        private Thread thDataFromServer;
        private IPAddress ipadr;
        private Modem modem;
        private MessageUtil check;
        private SendMode sendMode;
        public static List<LogWindow> MorseValueList;
        public static List<LogWindow> LogValueList;

        public Main()
        {
            InitializeComponent();
            SoundUtil.SetVolume(5);
            SoundVolume.Value = 5;
            sendMode = SendMode.OneByOneMode;
            BtnSendOneByOneMode.Checked = true;
            check = new MessageUtil();
            MorseValueList = new List<LogWindow>();
            LogValueList = new List<LogWindow>();
            modem = new Modem(this);
            ipadr = IPAddress.Loopback;
            CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
            //多线程判断是否断开连接
            SERVER_STATIS = new Thread(new ThreadStart(UpdateServerStatus));
            SERVER_STATIS.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(SendText.Text, keyText.Text);
        }

        /// <summary>
        /// 向服务端发送数据
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="key">加密Key</param>
        private void SendMessage(string message, string key)
        {
            if (string.IsNullOrWhiteSpace(message.Trim())) return;
            if (clientSocket != null && clientSocket.Connected && IsConnected(clientSocket))
            {
                if (!check.CheckMessage(message)) return;
                switch (sendMode)
                {
                    case SendMode.OneByOneMode:
                        Thread OneByOneModeThread = new Thread(delegate () { SendMorseMessage(message, key); });
                        OneByOneModeThread.Start();
                        break;
                    case SendMode.RepeatMode:
                        Thread RepeatModeThread = new Thread(delegate () { SendMorseMessageRepeat(message, key); });
                        RepeatModeThread.Start();
                        break;
                    case SendMode.AllMode:
                        string EncryptAllModeMessage = Cryptography.Encrypt(modem.ConvertToMorseCode(message), key);
                        SendMorse(EncryptAllModeMessage);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please connect server");
                return;
            }
        }

        private void SendMorseMessageRepeat(string message, string key) {
            int _RepeatCountText = RepeatCountText.Text != "" ? Convert.ToInt32(RepeatCountText.Text) < 1 ? 1 : Convert.ToInt32(RepeatCountText.Text) : 1;
            int _IntervalText = IntervalText.Text != "" ? Convert.ToInt32(IntervalText.Text) < 1 ? 1 : Convert.ToInt32(IntervalText.Text) : 1;
            for (int i = 0; i < _RepeatCountText; i++)
            {
                SendMorseMessage(message, key);
                Thread.Sleep(_IntervalText);
            }
        }

        private void SendMorseMessage(string message, string key) {
            string _message = message;
            int _interval = DelayText.Text != "" ? Convert.ToInt32(DelayText.Text) < 1 ? 1 : Convert.ToInt32(DelayText.Text) : 1;
            SendText.Text = "";
            foreach (var morse in _message.ToCharArray())
            {
                string MORSE = modem.ConvertToMorseCode(morse.ToString());
                foreach (var symbol in MORSE.ToCharArray())
                {
                    string Encrypt_MORSE = Cryptography.Encrypt(symbol.ToString(), key);
                    SendMorse(Encrypt_MORSE);
                    Thread.Sleep(_interval);
                }
                string SPLIT = Cryptography.Encrypt(("[SPLIT]"), key);
                SendMorse(SPLIT);
            }
            Thread.Sleep(_interval);
            string NEWLINE = Cryptography.Encrypt(("[NEWLINE]"), key);
            SendMorse(NEWLINE);
        }

        /// <summary>
        /// 多线程判断是否连接服务器
        /// </summary>
        private void UpdateServerStatus() {
            while (true)
            {
                if (clientSocket != null && IsConnected(clientSocket) &&/*!TestConnection(ipadr.ToString(), port, 5) && clientSocket.Available == 0 &&*/ !clientSocket.Poll(1000, SelectMode.SelectRead) && clientSocket.Connected)
                {
                    isRotaryConnectOK = true;
                    Status.Invalidate();
                }
                else if(clientSocket != null)
                {
                    Disconnect();
                }
                Thread.Sleep(1000); 
            }
        }

        /// <summary>
        /// 检查一个Socket是否可连接
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        private bool IsConnected(Socket socket)
        {
            if (socket == null || socket.Connected == false)
            {
                return false;
            }

            bool blockingState = socket.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                socket.Blocking = false;
                socket.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException e)
            {
                // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的
                if (e.NativeErrorCode.Equals(10035))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                socket.Blocking = blockingState;    // 恢复状态
            }
        }

        //每一个连接的客户端必须设置一个唯一的用户名，在服务器端是把用户名和套接字保存在Dictionary<userName,ClientSocket>中
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (clientSocket == null || !clientSocket.Connected) {
                ConnectServre();
            }
        }

        private void ConnectServre() {
            if (clientSocket == null || !clientSocket.Connected)
            {
                try
                {
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //参考网址： https://msdn.microsoft.com/zh-cn/library/6aeby4wt.aspx
                    // Socket.BeginConnect 方法 (String, Int32, AsyncCallback, Object)
                    //开始一个对远程主机连接的异步请求
                    /* string host,     远程主机名
                     * int port,        远程主机的端口
                     * AsyncCallback requestCallback,   一个 AsyncCallback 委托，它引用连接操作完成时要调用的方法，也是一个异步的操作
                     * object state     一个用户定义对象，其中包含连接操作的相关信息。 当操作完成时，此对象会被传递给 requestCallback 委托
                     */
                    //如果txtIP里面有值，就选择填入的IP作为服务器IP，不填的话就默认是本机的
                    if (!string.IsNullOrWhiteSpace(IpText.Text.ToString().Trim()))
                    {
                        try
                        {
                            ipadr = IPAddress.Parse(IpText.Text.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please enter the correct IP and try again");
                            return;
                        }
                    }
                    else
                    {
                        ipadr = IPAddress.Loopback;
                    }
                    int port = PortText.Text != "" ? Convert.ToInt32(PortText.Text) : 45454;
                    clientSocket.BeginConnect(ipadr.ToString(), port, (args) =>
                    {
                        if (args.IsCompleted)   //判断该异步操作是否执行完毕
                        {
                            Byte[] bytesSend = new Byte[4096];
                            keyText.BeginInvoke(new Action(() =>
                            {
                                RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
                                byte[] byteCsp = new byte[10];
                                csp.GetBytes(byteCsp);
                                bytesSend = Encoding.UTF8.GetBytes(BitConverter.ToString(byteCsp)/*txtName.Text.Trim()*/ + "$");  //用户名，这里是刚刚连接上时需要传过去
                                if (clientSocket != null && clientSocket.Connected)
                                {
                                    clientSocket.Send(bytesSend);
                                    keyText.Enabled = false;    //设置为不能再改名字了
                                    BtnConnect.Enabled = false;
                                    BtnPasteKey.Enabled = false;
                                    BtnSend.Enabled = true;
                                    BtnDisconnect.Enabled = true;
                                    PortText.Enabled = false;
                                    SendText.Focus();         //将焦点放在
                                    thDataFromServer = new Thread(DataFromServer);
                                    thDataFromServer.IsBackground = true;
                                    thDataFromServer.Start();
                                }
                                else
                                {
                                    MessageBox.Show("Connection failure");
                                }

                            }));
                            IpText.BeginInvoke(new Action(() =>
                            {
                                if (clientSocket != null && clientSocket.Connected)
                                {
                                    IpText.Enabled = false;
                                }
                            }));
                        }
                    }, null);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Successfully connected to the server");
            }
        }

        private void ShowMsg(String msg, bool selfMessage = false)
        {
            LogText.BeginInvoke(new Action(() =>
            {
                if (msg.Split(':')[0] == "Warning")
                {
                    LogText.Text += Environment.NewLine + msg;
                    return;
                }
                foreach (var item in msg.Split('$'))
                {
                    string DecryptMessage = Cryptography.Decrypt(item, keyText.Text);
                    modem.PlayMorseTone(DecryptMessage);
                    //MorseValue.Text += DecryptMessage;
                    //Thread morse = new Thread(delegate () { modem.PlayMorseTone(DecryptMessage); });
                    //morse.Start();
                }
                //modem.PlayMorseTone(msg, key.Text);
                //MorseValue.Text += Cryptography.Decrypt(msg, key.Text);
                LogText.Text += Environment.NewLine + msg;    // 在 Windows 环境中，C# 语言 Environment.NewLine == "\r\n" 结果为 true
            }));
        }

        //获取服务器端的消息
        private void DataFromServer()
        {
            LogText.Text += "Connection succeeded!";
            isListen = true;
            try
            {
                while (isListen)
                {
                    Byte[] bytesFrom = new Byte[4096];
                    Int32 len = clientSocket.Receive(bytesFrom);

                    String dataFromClient = Encoding.UTF8.GetString(bytesFrom, 0, len);
                    if (!String.IsNullOrWhiteSpace(dataFromClient))
                    {
                        //如果收到服务器已经关闭的消息，那么就把客户端接口关了，免得出错，并在客户端界面上显示出来
                        if (dataFromClient.ToString().Length >=17 && dataFromClient.ToString().Substring(0, 17).Equals("Connection failure"))
                        {
                            clientSocket.Close();
                            clientSocket = null;

                            LogText.BeginInvoke(new Action(() =>
                            {
                                LogText.Text += Environment.NewLine + "Connection failure";
                            }));

                            keyText.BeginInvoke(new Action(() =>
                            {
                                keyText.Enabled = true;
                            }));    //重连当然可以换用户名啦

                            IpText.BeginInvoke(new Action(() =>
                            {
                                IpText.Enabled = true;
                            }));

                            thDataFromServer.Abort();   //这一句必须放在最后，不然这个进程都关了后面的就不会执行了
                          
                            return;
                        }
                        
                        if (dataFromClient.StartsWith("#") && dataFromClient.EndsWith("#"))
                        {
                            String userName = dataFromClient.Substring(1, dataFromClient.Length - 2);
                            this.BeginInvoke(new Action(() =>
                            {
                                MessageBox.Show("Flag：[" + userName + "] already exists, please try another flag and try again");
                            }));
                            isListen = false;

                            keyText.BeginInvoke(new Action(() =>
                            {
                                keyText.Enabled = true;
                                clientSocket.Send(Encoding.UTF8.GetBytes("$"));
                                clientSocket.Close();
                                clientSocket = null;
                            }));
                            IpText.BeginInvoke(new Action(() =>
                            {
                                IpText.Enabled = true;
                            }));
                        }
                        else
                        {
                            ShowMsg(Cryptography.Decrypt(dataFromClient, Cryptography.SENDSERVERKEY));
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                isListen = false;
                if (clientSocket != null && clientSocket.Connected)
                {
                    //没有在客户端关闭连接，而是给服务器发送一个消息，在服务器端关闭连接
                    //这样可以将异常的处理放到服务器。客户端关闭会让客户端和服务器都抛异常
                    clientSocket.Send(Encoding.UTF8.GetBytes("$"));
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            SendText.Focus();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Send(Encoding.UTF8.GetBytes("$"));
            }
            Disconnect();
            Process.GetCurrentProcess().Kill();
        }

        private void Disconnect() {
            if (clientSocket != null && clientSocket.Connected)
            {
                thDataFromServer.Abort();
                //System.Net.Sockets.SocketException
                clientSocket.Send(Encoding.UTF8.GetBytes("$"));

                clientSocket.Close();
                clientSocket = null;

                LogText.BeginInvoke(new Action(() =>
                {
                    LogText.Text += Environment.NewLine + "Disconnected from the server";
                }));

                keyText.BeginInvoke(new Action(() =>
                {
                    keyText.Enabled = true;
                }));

                //重连当然可以换用户名啦
                IpText.BeginInvoke(new Action(() =>
                {
                    IpText.Enabled = true;
                }));
                PortText.Enabled = true;
                BtnConnect.Enabled = true;
                BtnPasteKey.Enabled = true;
                BtnDisconnect.Enabled = false;
                BtnSend.Enabled = false;
                isRotaryConnectOK = false;
                Status.Invalidate();
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        /// <summary>
        /// 发报文给服务器
        /// </summary>
        /// <param name="message"></param>
        private void SendMorse(string message) {
            if (clientSocket != null && clientSocket.Connected)
            {
                Byte[] bytesSend = Encoding.UTF8.GetBytes(message + "$");
                clientSocket.Send(bytesSend);
            }
        }

        /* 手动发报 */
        private bool keyStatus = false;
        private void txtSendMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyStatus) return;
            string unMessage = "";
            switch (e.KeyCode)
            {
                case Keys.Left:
                    unMessage = Cryptography.Encrypt(("[DOT]"), keyText.Text);
                    SendMorse(unMessage);
                    break;
                case Keys.Right:
                    unMessage = Cryptography.Encrypt(("[DASH]"), keyText.Text);
                    SendMorse(unMessage);
                    break;
                case Keys.Up:
                    unMessage = Cryptography.Encrypt(("[SPLIT]"), keyText.Text);
                    SendMorse(unMessage);
                    break;
                case Keys.Down:
                    unMessage = Cryptography.Encrypt(("[NEWLINE]"), keyText.Text);
                    SendMorse(unMessage);
                    break;
            }
            keyStatus = true;
        }
        private void txtSendMsg_KeyUp(object sender, KeyEventArgs e)
        {
            keyStatus = false;
        }

        private void MorseValue_TextChanged(object sender, EventArgs e)
        {
            //文本框选中的起始点在最后
            MorseText.SelectionStart = MorseText.TextLength;
            //将控件内容滚动到当前插入符号位置
            MorseText.ScrollToCaret();
            foreach (var item in MorseValueList)
            {
                item.LogWindowText.Text = MorseText.Text;
            }
        }

        private void txtReceiveMsg_TextChanged(object sender, EventArgs e)
        {
            //文本框选中的起始点在最后
            LogText.SelectionStart = LogText.TextLength;
            //将控件内容滚动到当前插入符号位置
            LogText.ScrollToCaret();
            foreach (var item in MorseValueList)
            {
                item.LogWindowText.Text = LogText.Text;
            }
        }

        private void CopyKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(keyText.Text.Trim());
        }

        private bool isRotaryConnectOK = false;

        private void Status_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics; gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color c = isRotaryConnectOK ? Color.Lime : Color.Red;
            Status.Text = isRotaryConnectOK ? "   Online" : "   Offline";
            SolidBrush s = new SolidBrush(c);
            gp.FillEllipse(s, 5, 1, Status.Width / 7, Status.Width / 7);
        }

        private void pasteKey_Click(object sender, EventArgs e)
        {
            keyText.Text = Clipboard.GetText();
        }

        private void PortText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void IntervalText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void IpText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MorseText.Text = "";
        }

        private void clearMessageLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogText.Text = "";
        }

        private void openNewMessageLogWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogWindow logValue = new LogWindow();
            LogValueList.Add(logValue);
            logValue.Show();
            logValue.Text = $"#{LogValueList.Count} Log Window";
            logValue.LogWindowText.Text = LogText.Text;
        }

        private void openNewMorseLogWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogWindow morseValue = new LogWindow();
            MorseValueList.Add(morseValue);
            morseValue.Show();
            morseValue.Text = $"#{MorseValueList.Count} Morse Window";
            morseValue.LogWindowText.Text = MorseText.Text;
        }

        private void SendText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
        }

        private void translatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MorseTranslator morseTranslator = new MorseTranslator();
            morseTranslator.Show();
        }

        private void clearParseLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParseText.Text = "";
        }

        private void BtnSendOneByOneMode_CheckedChanged(object sender, EventArgs e)
        {
            sendMode = SendMode.OneByOneMode;
        }

        private void BtnSendRepeatMode_CheckedChanged(object sender, EventArgs e)
        {
            sendMode = SendMode.RepeatMode;
        }

        private void BtnSendAllMode_CheckedChanged(object sender, EventArgs e)
        {
            sendMode = SendMode.AllMode;
        }

        private void BtnRepeatCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void SoundVolume_Scroll(object sender, EventArgs e)
        {
            SoundUtil.SetVolume(SoundVolume.Value);
        }
    }
}
