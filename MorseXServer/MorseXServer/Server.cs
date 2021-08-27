using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace MorseXServer
{

    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            ipadr = IPAddress.Loopback;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipAddr in ipHostInfo.AddressList)
            {
                LocalIpList.Text += ipAddr.ToString() + Environment.NewLine;
            }
        }

        //保存多个客户端的通信套接字
        public static Dictionary<String, Socket> clientList = null;
        //申明一个监听套接字 
        Socket serverSocket = null;
        //设置一个监听标记
        bool isListen = true;
        //开启监听的线程
        Thread thStartListen;
        //默认一个主机监听的IP
        IPAddress ipadr;
        //将endpoint设置为成员字段
        IPEndPoint endPoint;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (serverSocket == null)
            {
                try
                {
                    isListen = true;
                    clientList = new Dictionary<string, Socket>();

                    //实例监听套接字

                    //参考网址：http://blog.csdn.net/sight_/article/details/8138802
                    //int socket(int domain, int type, int protocol);
                    //  domain:   协议域，又名协议族。常用的协议族有，AF_INET、AF_INET6、AF_LOCAL（或称AF_UNIX，Unix域socket）、AF_ROUTE等等。
                    //协议族决定了socket的地址类型，在通信中必须采用对应的地址，如AF_INET决定了要用ipv4地址（32位的）与端口号（16位的）的组合、AF_UNIX决定了要用一个绝对路径名作为地址。
                    //  type:     指定socket类型，。常用的socket类型有，SOCK_STREAM、SOCK_DGRAM、SOCK_RAW、SOCK_PACKET、SOCK_SEQPACKET等等
                    //  protocol:   指定协议。常用的协议有，IPPROTO_TCP、IPPTOTO_UDP、IPPROTO_SCTP、IPPROTO_TIPC等
                    //并不是上面的type和protocol可以随意组合的，如SOCK_STREAM不可以跟IPPROTO_UDP组合。当protocol为0时，会自动选择type类型对应的默认协议
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);     //AddressFamily.InterNetwork代表IPV4地址，不包含IPV6   参考网址：http://bbs.csdn.net/topics/390283656?page=1

                    //端点
                    /*  在IPEndPoint类中有两个很有用的构造函数：
                        public IPEndPoint(long, int); 
                        public IPEndPoint(IPAddress, int);
                        它们的作用就是用指定的地址和端口号初始化IPEndPoint类的新实例。
                     * 参考网址：http://www.cnblogs.com/Medeor/p/3546359.html
                     */
                    //IPAddress ipadr = IPAddress.Parse("192.168.1.100");
                    //如果txtIP里面有值，就选择填入的IP作为服务器IP，不填的话就默认是本机的
                    int port = PortText.Text != "" ? Convert.ToInt32(PortText.Text) : 45454;
                    endPoint = new IPEndPoint(ipadr, port);     //IPAddress.loopback是本地环回接口，其实是虚拟接口，物理不存在的  参考网址：http://baike.sogou.com/v7893363.htm?fromTitle=loopback

                    //绑定
                    //把一个地址族的特定地址给socket
                    //int bind(int sockfd, const struct sockaddr *addr, socklen_t addrlen);
                    //sockfd:   即socket描述字，它是通过socket()函数创建了，唯一标识一个socket。bind()函数就是将给这个描述字绑定一个名字。
                    //*addr:    一个const struct sockaddr *指针，指向要绑定给sockfd的协议地址。这个地址结构根据地址创建socket时的地址协议族的不同而不同
                    //addrlen:  对应的是地址的长度
                    //通常服务器在启动的时候都会绑定一个众所周知的地址（如ip地址+端口号），用于提供服务，客户就可以通过它来接连服务器；
                    //而客户端就不用指定，有系统自动分配一个端口号和自身的ip地址组合。
                    //这就是为什么通常服务器端在listen之前会调用bind()，而客户端就不会调用，而是在connect()时由系统随机生成一个。
                    //参考网址：http://blog.csdn.net/sight_/article/details/8138802

                    //但是这里的bind不是上面的bind，是.NET里面的一个bind，使 Socket 与一个本地终结点相关联。 命名空间:System.Net.Sockets  程序集:System（在 system.dll 中）
                    //给套接字绑定一个端点，其实差不多用上面的那种bind也能实现
                    //参考网站： https://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.bind(VS.80).aspx
                    try
                    {
                        serverSocket.Bind(endPoint);

                        //设置最大连接数
                        //如果作为一个服务器，在调用socket()、bind()之后就会调用listen()来监听这个socket，如果客户端这时调用connect()发出连接请求，服务器端就会接收到这个请求。
                        //int listen(int sockfd, int backlog);
                        //listen函数的第一个参数即为要监听的socket描述字，第二个参数为相应socket可以排队的最大连接个数。
                        //socket()函数创建的socket默认是一个主动类型的，listen函数将socket变为被动类型的，等待客户的连接请求。
                        serverSocket.Listen(100);

                        thStartListen = new Thread(StartListen);
                        thStartListen.IsBackground = true;
                        thStartListen.Start();

                        //这里有点不一样，原文用的是  txtMsg.Dispatcher.BeginInvoke

                        /*Invoke在线程中等待Dispatcher调用指定方法，完成后继续下面的操作。
                         * BeginInvoke不必等待Dispatcher调用制定方法，直接继续下面的操作。
                         * 参考网址： https://zhidao.baidu.com/question/1175146013330422099.html?qbl=relate_question_1&word=Dispatcher.BeginInvoke%B5%C4%CF%E0%CD%AC%BA%AF%CA%FD
                         * 更好的参考网址：http://www.cnblogs.com/lsgsanxiao/p/5523282.html
                        **/
                        MessageText.BeginInvoke(new Action(() =>
                        {
                            MessageText.Text += "Service started successfully... - " + DateTime.Now + Environment.NewLine;
                        }));
                    }
                    catch (Exception eg)
                    {
                        MessageBox.Show("Invalid IP address entered" + eg.ToString());
                        MessageText.BeginInvoke(new Action(() =>
                        {
                            MessageText.Text += "Service failed to start..." + Environment.NewLine;
                        }));

                        if (serverSocket != null)
                        {
                            serverSocket.Close();
                            thStartListen.Abort();  //将监听进程关掉

                            BroadCast.PushMessage("Warning:Server has closed", "", false, clientList);
                            foreach (var socket in clientList.Values)
                            {
                                socket.Close();
                            }
                            clientList.Clear();

                            serverSocket = null;
                            isListen = false;
                        }
                    }
                }
                catch(SocketException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        //线程函数，封装一个建立连接的通信套接字
        private  void StartListen()
        {
            isListen = true;
            //default()只是设置为一个初始值，这里应该为null  参考网址：https://stackoverflow.com/questions/28720717/why-default-in-c-sharp-tcpclient-clientsocket-defaulttcpclient
            Socket clientSocket = default(Socket);      

            while (isListen)
            {
                try
                {
                    //参考网址： http://bbs.csdn.net/topics/30100253
                    //  int accept(int sockfd, void *addr, int *addrlen); 
                    //注意这个serverSocket，它是用来监听的套接字，当有用户连接上端口后会返回一个新的套接字也就是这里的clientSocket，sercerSocket还是在那儿继续监听的
                    //详细参考网址：http://www.360doc.com/content/13/0908/17/13253385_313070996.shtml
                    //返回值是一个新的套接字描述符，它代表的是和客户端的新的连接，这个socket相当于一个客户端的socket，包含的是客户端的ip和port
                    //但是它也继承字本地的监听套接字，因此它也有服务器的ip和port信息
                    if (serverSocket == null)   //如果服务停止，即serverSocket为空了，那就直接返回
                    {
                        return;
                    }
                    clientSocket = serverSocket.Accept();   //这个方法返回一个通信套接字，并用这个套接字进行通信，错误时返回-1并设置全局错误变量
                }
                catch (SocketException e)
                {
                    File.AppendAllText(Environment.CurrentDirectory + "\\Exception.txt", e.ToString() + Environment.NewLine + "StartListen" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine);
                }

                //TCP是面向字节流的
                byte[] bytesFrom = new byte[4096];
                string dataFromClient = null;

                if (clientSocket != null && clientSocket.Connected)
                {
                    try
                    {
                        //Socket.Receive() 参考网址：http://blog.csdn.net/cpcpc/article/details/7245420
                        //public int Receive(  byte[] buffer,  int offset,   int size,  SocketFlags socketFlags )  
                        //buffer  是byte类型的数组，存储收到的数据的位置
                        //offset  是buffer中存储所接收数据的位置
                        //size    要接收的字节数
                        //socketFlags  socketFlages值的按位组合

                        int len = clientSocket.Receive(bytesFrom);    //获取客户端发来的信息,返回的就是收到的字节数,并且把收到的信息都放在bytesForm里面

                        if (len > -1)
                        {
                            string tmp = Encoding.UTF8.GetString(bytesFrom, 0, len);  //将字节流转换成字符串
                            dataFromClient = tmp;
                            int sublen = dataFromClient.LastIndexOf("$");
                            if (sublen > -1)
                            {
                                dataFromClient = dataFromClient.Substring(0, sublen);   //获取用户名

                                if (!clientList.ContainsKey(dataFromClient))
                                {
                                    clientList.Add(dataFromClient, clientSocket);   //如果用户名不存在，则添加用户名进去

                                    //用户加入聊天
                                    //BroadCast是下面自己定义的一个类，是用来将消息对所有用户进行推送的
                                    BroadCast.PushMessage("Warning:" + dataFromClient + " Joined", dataFromClient, false, clientList);
                                    //HandleClient也是一个自己定义的类，用来负责接收客户端发来的消息并转发给所有的客户端
                                    HandleClient client = new HandleClient(MessageText, LogText);
                                    client.StartClient(clientSocket, dataFromClient, clientList);
                                    MessageText.BeginInvoke(new Action(() =>
                                    {
                                        MessageText.Text += dataFromClient + " Connected to the server - " + DateTime.Now + Environment.NewLine;
                                    }));
                                }
                                else
                                {
                                    //用户名已经存在
                                    clientSocket.Send(Encoding.UTF8.GetBytes("#" + dataFromClient + "#"));
                                }
                            }
                        }
                    }
                    catch (Exception ep)
                    {
                        File.AppendAllText(Environment.CurrentDirectory + "\\Exception.txt", ep.ToString() + Environment.NewLine + "\t\t" + DateTime.Now.ToString() + Environment.NewLine);
                    }
                }
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (serverSocket != null)
            {
                serverSocket.Close();
                thStartListen.Abort();//将监听进程关掉
                
                BroadCast.PushMessage("Warning:Server has closed", "", false, clientList);
                foreach (var socket in clientList.Values)
                {
                    socket.Close();
                }
                clientList.Clear();
                
                serverSocket = null;
                isListen = false;
                MessageText.Text += "Server shutdown. Close all client connect \t" + DateTime.Now.ToString() + Environment.NewLine;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labIPnow.BeginInvoke(new Action(() =>
            {
                labIPnow.Text = ipadr.ToString();
                IpText.Text = ipadr.ToString();
                PortText.Text = "45454";
            }));
            //try
            //{
            //    clientList = new Dictionary<string, Socket>();
            //    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//实例，监听套接字
            //    IPAddress ipadr = IPAddress.Parse("127.0.0.1");

            //    endPoint = new IPEndPoint(ipadr, 8080);//端点
            //    serverSocket.Bind(endPoint);//绑定
            //    serverSocket.Listen(100);   //设置最大连接数
            //    thStartListen = new Thread(StartListen);
            //    thStartListen.IsBackground = true;
            //    thStartListen.Start();
            //    txtMsg.BeginInvoke(new Action(() =>
            //    {
            //        txtMsg.Text += "服务启动成功..." + Environment.NewLine;
            //    }
            //    ));
            //    labIPnow.BeginInvoke(new Action(() =>
            //    {
            //        labIPnow.Text = endPoint.Address.ToString();
            //    }));
            //}
            //catch (SocketException ep)
            //{
            //    MessageBox.Show(ep.ToString());
            //}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverSocket != null)
            {
                BroadCast.PushMessage("Warning:Server has closed", "", false, clientList);
                foreach (var socket in clientList.Values)
                {
                    socket.Close();
                }
                clientList.Clear();
                serverSocket.Close();
                serverSocket = null;
                isListen = false;
                MessageText.Text += "Server stop" + Environment.NewLine;
            }

        }

        //重置监听的IP地址
        private void btnResetIp_Click(object sender, EventArgs e)
        {
            
                //如果txtIP里面有值，就选择填入的IP作为服务器IP，不填的话就默认是本机的
                if (!string.IsNullOrWhiteSpace(IpText.Text.ToString().Trim()))
                {
                    try
                    {
                        ipadr = IPAddress.Parse(IpText.Text.ToString().Trim());
                        btnStop_Click(sender, e);
                        MessageText.BeginInvoke(new Action(() =>
                        {
                            MessageText.Text += "Server is restarting, please wait..." + Environment.NewLine;
                        }));

                        btnStart_Click(sender, e);


                        labIPnow.BeginInvoke(new Action(() =>
                        {
                            labIPnow.Text = endPoint.Address.ToString();
                        }));
                    }
                    catch (Exception ep)
                    {
                        MessageBox.Show("Please enter the correct IP");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the IP address after reset");
                }
            
            
        }

        private void btnRcv_Click(object sender, EventArgs e)
        {
            if (ipadr == IPAddress.Loopback)
            {
                MessageBox.Show("Currently in the default state");
            }
            else
            {
                ipadr = IPAddress.Loopback;
                btnStop_Click(sender, e);
                MessageText.BeginInvoke(new Action(() =>
                {
                    MessageText.Text += "Server is restarting, please wait..." + Environment.NewLine;
                }));
                btnStart_Click(sender, e);
                labIPnow.BeginInvoke(new Action(() =>
                {
                    labIPnow.Text = endPoint.Address.ToString();
                }));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MessageText.BeginInvoke(new Action(() =>
            {
                MessageText.Text = "";
            }));
            LogText.BeginInvoke(new Action(() =>
            {
                LogText.Text = "";
            }));
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            //文本框选中的起始点在最后
            MessageText.SelectionStart = MessageText.TextLength;
            //将控件内容滚动到当前插入符号位置
            MessageText.ScrollToCaret();
        }

        private void LogText_TextChanged(object sender, EventArgs e)
        {
            //文本框选中的起始点在最后
            LogText.SelectionStart = LogText.TextLength;
            //将控件内容滚动到当前插入符号位置
            LogText.ScrollToCaret();
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
    }

    //该类专门负责接收客户端发来的消息，并转发给所有的客户端
    public class HandleClient
    {
        Socket clientSocket;
        string clNo;
        Dictionary<string, Socket> clientList = new Dictionary<string, Socket>();
        TextBox txtMsg;
        TextBox logMsg;
        public HandleClient() { }
        public HandleClient(TextBox msg, TextBox log) 
        {
            txtMsg = msg;
            logMsg = log;
        }

        
        public void StartClient(Socket inClientSocket, string clientNo, Dictionary<string, Socket> cList)
        {
            clientSocket = inClientSocket;
            clNo = clientNo;
            clientList = cList;

            Thread th = new Thread(Chat);
            th.IsBackground = true;
            th.Start();
        }

        private void Chat()
        {
            byte[] bytesFromClient = new byte[4096];
            string dataFromClient;
            string msgTemp = null;
            byte[] bytesSend = new byte[4096];
            bool isListen = true;

            while (isListen)
            {
                try
                {
                    if (clientSocket == null || !clientSocket.Connected)
                    {
                        return;
                    }
                    if (clientSocket.Available > 0)
                    {
                        int len = clientSocket.Receive(bytesFromClient);
                        if (len > -1)
                        {
                            dataFromClient = Encoding.UTF8.GetString(bytesFromClient, 0, len);
                            if (!string.IsNullOrWhiteSpace(dataFromClient))
                            {
                                dataFromClient = dataFromClient.Substring(0, dataFromClient.LastIndexOf("$"));   //这里的dataFromClient是消息内容，上面的是用户名
                                logMsg.BeginInvoke(new Action(() =>
                                {
                                    if (string.IsNullOrEmpty(dataFromClient)) return;
                                    logMsg.Text += dataFromClient + DateTime.Now + Environment.NewLine;
                                }));
                                if (!string.IsNullOrWhiteSpace(dataFromClient))
                                {
                                    BroadCast.PushMessage(dataFromClient, clNo, true, clientList);
                                    msgTemp = clNo + ":" + dataFromClient + "\t\t" + DateTime.Now.ToString();
                                    string newMsg = msgTemp;
                                    File.AppendAllText(Environment.CurrentDirectory + "\\MessageRecords.txt", newMsg + Environment.NewLine, Encoding.UTF8);
                                }
                                else
                                {
                                    isListen = false;
                                    clientList.Remove(clNo);
                                    txtMsg.BeginInvoke(new Action(() =>
                                    {
                                        txtMsg.Text += clNo+ "Disconnected from the server\r" + DateTime.Now + Environment.NewLine;
                                    }));
                                    BroadCast.PushMessage("Warning:" + clNo + "Offline\r", "",false,clientList);
                                    clientSocket.Close();
                                    clientSocket = null;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    isListen = false;
                    clientList.Remove(clNo);

                    
                    clientSocket.Close();
                    clientSocket = null;
                    File.AppendAllText(Environment.CurrentDirectory + "\\Exception.txt", e.ToString()+ Environment.NewLine + "Chat" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine);
                }
            }
        }
    }

    //向所有客户端发送信息
    public class BroadCast
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

        //flag是用来判断传进来的msg前面是否需要加上uName:，也就是判断是不是系统信息，是系统信息的话就设置flag为false
        public static void PushMessage(string msg, string uName, bool flag, Dictionary<string, Socket> clientList)
        {
            if (!IsNumAndEnCh(msg))
            {
                if (msg != "[DOT]" || msg != "[DASH]" || msg != "[SPLIT]" || msg != "[NEWLINE]")
                {
                    return;
                }
            }
            foreach (var item in clientList)
            {
                Socket brdcastSocket = item.Value;
                if (brdcastSocket != null && !brdcastSocket.Connected)
                {
                    continue;
                }
                string msgTemp = null;
                Byte[] castBytes = new Byte[4096];
                if (flag == true)
                {
                    msgTemp = /*uName + ":" + */msg/* + "\t\t" + DateTime.Now.ToString()*/;
                    castBytes = Encoding.UTF8.GetBytes(Cryptography.Encrypt(msgTemp, Cryptography.SENDSERVERKEY));
                }
                else
                {
                    msgTemp = msg + " - " + DateTime.Now.ToString();
                    castBytes = Encoding.UTF8.GetBytes(Cryptography.Encrypt(msgTemp, Cryptography.SENDSERVERKEY));
                }
                try
                {
                    brdcastSocket.Send(castBytes);
                }
                catch (Exception e)
                {
                    brdcastSocket.Close();
                    brdcastSocket = null;
                    File.AppendAllText(Environment.CurrentDirectory + "\\Exception.txt", e.ToString() + Environment.NewLine + "PushMessage" + Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine);
                    continue;
                }
            }
        }
    }

}
