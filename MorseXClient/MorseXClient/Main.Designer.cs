namespace MorseXClient
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMsg = new System.Windows.Forms.Label();
            this.keyText = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.LogText = new System.Windows.Forms.TextBox();
            this.SendText = new System.Windows.Forms.TextBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.IpText = new System.Windows.Forms.TextBox();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.MorseText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCopyKey = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.BtnPasteKey = new System.Windows.Forms.Button();
            this.PortText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DelayText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearParseLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMessageLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewMorseLogWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewMessageLogWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.ParseText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IntervalText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SoundVolume = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.RepeatCountText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnSendAllMode = new System.Windows.Forms.RadioButton();
            this.BtnSendRepeatMode = new System.Windows.Forms.RadioButton();
            this.BtnSendOneByOneMode = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("宋体", 10F);
            this.lbMsg.Location = new System.Drawing.Point(8, 9);
            this.lbMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(35, 14);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "Key:";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyText
            // 
            this.keyText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.keyText.Location = new System.Drawing.Point(8, 25);
            this.keyText.Margin = new System.Windows.Forms.Padding(2);
            this.keyText.MaxLength = 100;
            this.keyText.Multiline = true;
            this.keyText.Name = "keyText";
            this.keyText.ShortcutsEnabled = false;
            this.keyText.Size = new System.Drawing.Size(134, 51);
            this.keyText.TabIndex = 1;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(360, 23);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(74, 24);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "CONNECT";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // LogText
            // 
            this.LogText.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogText.Location = new System.Drawing.Point(5, 320);
            this.LogText.Margin = new System.Windows.Forms.Padding(2);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogText.Size = new System.Drawing.Size(432, 53);
            this.LogText.TabIndex = 3;
            this.LogText.TextChanged += new System.EventHandler(this.txtReceiveMsg_TextChanged);
            // 
            // SendText
            // 
            this.SendText.AcceptsReturn = true;
            this.SendText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendText.Location = new System.Drawing.Point(5, 169);
            this.SendText.Margin = new System.Windows.Forms.Padding(2);
            this.SendText.Name = "SendText";
            this.SendText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SendText.Size = new System.Drawing.Size(432, 26);
            this.SendText.TabIndex = 4;
            this.SendText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendMsg_KeyDown);
            this.SendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendText_KeyPress);
            this.SendText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendMsg_KeyUp);
            // 
            // BtnSend
            // 
            this.BtnSend.Enabled = false;
            this.BtnSend.Location = new System.Drawing.Point(358, 210);
            this.BtnSend.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(79, 28);
            this.BtnSend.TabIndex = 5;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("宋体", 10F);
            this.labelIP.Location = new System.Drawing.Point(205, 9);
            this.labelIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(28, 14);
            this.labelIP.TabIndex = 6;
            this.labelIP.Text = "IP:";
            this.labelIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IpText
            // 
            this.IpText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IpText.Location = new System.Drawing.Point(205, 25);
            this.IpText.Margin = new System.Windows.Forms.Padding(2);
            this.IpText.MaxLength = 50;
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(151, 23);
            this.IpText.TabIndex = 7;
            this.IpText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IpText_KeyPress);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Enabled = false;
            this.BtnDisconnect.Location = new System.Drawing.Point(360, 51);
            this.BtnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(74, 25);
            this.BtnDisconnect.TabIndex = 8;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // MorseText
            // 
            this.MorseText.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MorseText.Location = new System.Drawing.Point(5, 21);
            this.MorseText.Margin = new System.Windows.Forms.Padding(2);
            this.MorseText.Multiline = true;
            this.MorseText.Name = "MorseText";
            this.MorseText.ReadOnly = true;
            this.MorseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MorseText.Size = new System.Drawing.Size(432, 144);
            this.MorseText.TabIndex = 10;
            this.MorseText.TextChanged += new System.EventHandler(this.MorseValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "by hex3f.com";
            // 
            // BtnCopyKey
            // 
            this.BtnCopyKey.Location = new System.Drawing.Point(146, 24);
            this.BtnCopyKey.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCopyKey.Name = "BtnCopyKey";
            this.BtnCopyKey.Size = new System.Drawing.Size(52, 24);
            this.BtnCopyKey.TabIndex = 14;
            this.BtnCopyKey.Text = "COPY";
            this.BtnCopyKey.UseVisualStyleBackColor = true;
            this.BtnCopyKey.Click += new System.EventHandler(this.CopyKey_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Status.Location = new System.Drawing.Point(8, 435);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(77, 14);
            this.Status.TabIndex = 15;
            this.Status.Text = "   Offline";
            this.Status.Paint += new System.Windows.Forms.PaintEventHandler(this.Status_Paint);
            // 
            // BtnPasteKey
            // 
            this.BtnPasteKey.Location = new System.Drawing.Point(146, 52);
            this.BtnPasteKey.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPasteKey.Name = "BtnPasteKey";
            this.BtnPasteKey.Size = new System.Drawing.Size(52, 24);
            this.BtnPasteKey.TabIndex = 16;
            this.BtnPasteKey.Text = "PASTE";
            this.BtnPasteKey.UseVisualStyleBackColor = true;
            this.BtnPasteKey.Click += new System.EventHandler(this.pasteKey_Click);
            // 
            // PortText
            // 
            this.PortText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PortText.Location = new System.Drawing.Point(251, 51);
            this.PortText.Margin = new System.Windows.Forms.Padding(2);
            this.PortText.MaxLength = 5;
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(105, 23);
            this.PortText.TabIndex = 19;
            this.PortText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortText_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(205, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "PORT:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DelayText
            // 
            this.DelayText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DelayText.Location = new System.Drawing.Point(11, 155);
            this.DelayText.Margin = new System.Windows.Forms.Padding(2);
            this.DelayText.MaxLength = 10;
            this.DelayText.Name = "DelayText";
            this.DelayText.Size = new System.Drawing.Size(68, 23);
            this.DelayText.TabIndex = 21;
            this.DelayText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntervalText_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(10, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Send Interval:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(83, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "MS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(473, 25);
            this.Menu.TabIndex = 24;
            this.Menu.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearParseLogToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.clearMessageLogToolStripMenuItem,
            this.openNewMorseLogWindowToolStripMenuItem,
            this.openNewMessageLogWindowToolStripMenuItem,
            this.translatorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // clearParseLogToolStripMenuItem
            // 
            this.clearParseLogToolStripMenuItem.Name = "clearParseLogToolStripMenuItem";
            this.clearParseLogToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.clearParseLogToolStripMenuItem.Text = "Clear Parse Log";
            this.clearParseLogToolStripMenuItem.Click += new System.EventHandler(this.clearParseLogToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.clearToolStripMenuItem.Text = "Clear Morse Log";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // clearMessageLogToolStripMenuItem
            // 
            this.clearMessageLogToolStripMenuItem.Name = "clearMessageLogToolStripMenuItem";
            this.clearMessageLogToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.clearMessageLogToolStripMenuItem.Text = "Clear Message Log";
            this.clearMessageLogToolStripMenuItem.Click += new System.EventHandler(this.clearMessageLogToolStripMenuItem_Click);
            // 
            // openNewMorseLogWindowToolStripMenuItem
            // 
            this.openNewMorseLogWindowToolStripMenuItem.Name = "openNewMorseLogWindowToolStripMenuItem";
            this.openNewMorseLogWindowToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.openNewMorseLogWindowToolStripMenuItem.Text = "Open New Morse Log Window";
            this.openNewMorseLogWindowToolStripMenuItem.Click += new System.EventHandler(this.openNewMorseLogWindowToolStripMenuItem_Click);
            // 
            // openNewMessageLogWindowToolStripMenuItem
            // 
            this.openNewMessageLogWindowToolStripMenuItem.Name = "openNewMessageLogWindowToolStripMenuItem";
            this.openNewMessageLogWindowToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.openNewMessageLogWindowToolStripMenuItem.Text = "Open New Message Log Window";
            this.openNewMessageLogWindowToolStripMenuItem.Click += new System.EventHandler(this.openNewMessageLogWindowToolStripMenuItem_Click);
            // 
            // translatorToolStripMenuItem
            // 
            this.translatorToolStripMenuItem.Name = "translatorToolStripMenuItem";
            this.translatorToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.translatorToolStripMenuItem.Text = "Translator";
            this.translatorToolStripMenuItem.Click += new System.EventHandler(this.translatorToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Parse:";
            // 
            // ParseText
            // 
            this.ParseText.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ParseText.Location = new System.Drawing.Point(5, 253);
            this.ParseText.Margin = new System.Windows.Forms.Padding(2);
            this.ParseText.Multiline = true;
            this.ParseText.Name = "ParseText";
            this.ParseText.ReadOnly = true;
            this.ParseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ParseText.Size = new System.Drawing.Size(432, 47);
            this.ParseText.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(8, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 27;
            this.label7.Text = "Send Delay:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IntervalText
            // 
            this.IntervalText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IntervalText.Location = new System.Drawing.Point(13, 114);
            this.IntervalText.Margin = new System.Windows.Forms.Padding(2);
            this.IntervalText.MaxLength = 10;
            this.IntervalText.Name = "IntervalText";
            this.IntervalText.Size = new System.Drawing.Size(68, 23);
            this.IntervalText.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(85, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 29;
            this.label8.Text = "MS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 404);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.LogText);
            this.tabPage1.Controls.Add(this.SendText);
            this.tabPage1.Controls.Add(this.BtnSend);
            this.tabPage1.Controls.Add(this.MorseText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ParseText);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(442, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "Morse:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.SoundVolume);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.RepeatCountText);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.BtnSendAllMode);
            this.tabPage2.Controls.Add(this.BtnSendRepeatMode);
            this.tabPage2.Controls.Add(this.BtnSendOneByOneMode);
            this.tabPage2.Controls.Add(this.BtnConnect);
            this.tabPage2.Controls.Add(this.lbMsg);
            this.tabPage2.Controls.Add(this.keyText);
            this.tabPage2.Controls.Add(this.labelIP);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.IpText);
            this.tabPage2.Controls.Add(this.DelayText);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.BtnDisconnect);
            this.tabPage2.Controls.Add(this.IntervalText);
            this.tabPage2.Controls.Add(this.BtnCopyKey);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.BtnPasteKey);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.PortText);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SoundVolume
            // 
            this.SoundVolume.Location = new System.Drawing.Point(254, 121);
            this.SoundVolume.Name = "SoundVolume";
            this.SoundVolume.Size = new System.Drawing.Size(171, 45);
            this.SoundVolume.TabIndex = 37;
            this.SoundVolume.Scroll += new System.EventHandler(this.SoundVolume_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F);
            this.label10.Location = new System.Drawing.Point(141, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 36;
            this.label10.Text = "Send Mode:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RepeatCountText
            // 
            this.RepeatCountText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RepeatCountText.Location = new System.Drawing.Point(11, 196);
            this.RepeatCountText.Margin = new System.Windows.Forms.Padding(2);
            this.RepeatCountText.MaxLength = 10;
            this.RepeatCountText.Name = "RepeatCountText";
            this.RepeatCountText.Size = new System.Drawing.Size(68, 23);
            this.RepeatCountText.TabIndex = 33;
            this.RepeatCountText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BtnRepeatCount_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F);
            this.label11.Location = new System.Drawing.Point(8, 180);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 35;
            this.label11.Text = "Repeat Count:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSendAllMode
            // 
            this.BtnSendAllMode.AutoSize = true;
            this.BtnSendAllMode.Location = new System.Drawing.Point(147, 165);
            this.BtnSendAllMode.Name = "BtnSendAllMode";
            this.BtnSendAllMode.Size = new System.Drawing.Size(71, 16);
            this.BtnSendAllMode.TabIndex = 32;
            this.BtnSendAllMode.Text = "All Mode";
            this.BtnSendAllMode.UseVisualStyleBackColor = true;
            this.BtnSendAllMode.CheckedChanged += new System.EventHandler(this.BtnSendAllMode_CheckedChanged);
            // 
            // BtnSendRepeatMode
            // 
            this.BtnSendRepeatMode.AutoSize = true;
            this.BtnSendRepeatMode.Location = new System.Drawing.Point(147, 143);
            this.BtnSendRepeatMode.Name = "BtnSendRepeatMode";
            this.BtnSendRepeatMode.Size = new System.Drawing.Size(89, 16);
            this.BtnSendRepeatMode.TabIndex = 31;
            this.BtnSendRepeatMode.Text = "Repeat Mode";
            this.BtnSendRepeatMode.UseVisualStyleBackColor = true;
            this.BtnSendRepeatMode.CheckedChanged += new System.EventHandler(this.BtnSendRepeatMode_CheckedChanged);
            // 
            // BtnSendOneByOneMode
            // 
            this.BtnSendOneByOneMode.AutoSize = true;
            this.BtnSendOneByOneMode.Location = new System.Drawing.Point(147, 121);
            this.BtnSendOneByOneMode.Name = "BtnSendOneByOneMode";
            this.BtnSendOneByOneMode.Size = new System.Drawing.Size(101, 16);
            this.BtnSendOneByOneMode.TabIndex = 30;
            this.BtnSendOneByOneMode.Text = "OneByOne Mode";
            this.BtnSendOneByOneMode.UseVisualStyleBackColor = true;
            this.BtnSendOneByOneMode.CheckedChanged += new System.EventHandler(this.BtnSendOneByOneMode_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F);
            this.label12.Location = new System.Drawing.Point(251, 98);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 14);
            this.label12.TabIndex = 38;
            this.label12.Text = "Sound Volume:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 460);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MorseX";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.TextBox SendText;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox IpText;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCopyKey;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button BtnPasteKey;
        public System.Windows.Forms.TextBox MorseText;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DelayText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMessageLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNewMorseLogWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNewMessageLogWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translatorToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox ParseText;
        private System.Windows.Forms.ToolStripMenuItem clearParseLogToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IntervalText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton BtnSendAllMode;
        private System.Windows.Forms.RadioButton BtnSendRepeatMode;
        private System.Windows.Forms.RadioButton BtnSendOneByOneMode;
        private System.Windows.Forms.TextBox RepeatCountText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar SoundVolume;
        private System.Windows.Forms.Label label12;
    }
}

