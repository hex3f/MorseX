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
            this.IntervalText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMessageLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewMorseLogWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewMessageLogWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.ParseText = new System.Windows.Forms.TextBox();
            this.clearParseLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Font = new System.Drawing.Font("宋体", 10F);
            this.lbMsg.Location = new System.Drawing.Point(11, 28);
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
            this.keyText.Location = new System.Drawing.Point(11, 44);
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
            this.BtnConnect.Location = new System.Drawing.Point(363, 42);
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
            this.LogText.Location = new System.Drawing.Point(11, 373);
            this.LogText.Margin = new System.Windows.Forms.Padding(2);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogText.Size = new System.Drawing.Size(429, 53);
            this.LogText.TabIndex = 3;
            this.LogText.TextChanged += new System.EventHandler(this.txtReceiveMsg_TextChanged);
            // 
            // SendText
            // 
            this.SendText.AcceptsReturn = true;
            this.SendText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendText.Location = new System.Drawing.Point(11, 247);
            this.SendText.Margin = new System.Windows.Forms.Padding(2);
            this.SendText.Name = "SendText";
            this.SendText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SendText.Size = new System.Drawing.Size(429, 26);
            this.SendText.TabIndex = 4;
            this.SendText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendMsg_KeyDown);
            this.SendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendText_KeyPress);
            this.SendText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendMsg_KeyUp);
            // 
            // BtnSend
            // 
            this.BtnSend.Enabled = false;
            this.BtnSend.Location = new System.Drawing.Point(361, 277);
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
            this.labelIP.Location = new System.Drawing.Point(208, 28);
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
            this.IpText.Location = new System.Drawing.Point(208, 44);
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
            this.BtnDisconnect.Location = new System.Drawing.Point(363, 70);
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
            this.MorseText.Location = new System.Drawing.Point(11, 99);
            this.MorseText.Margin = new System.Windows.Forms.Padding(2);
            this.MorseText.Multiline = true;
            this.MorseText.Name = "MorseText";
            this.MorseText.ReadOnly = true;
            this.MorseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MorseText.Size = new System.Drawing.Size(429, 144);
            this.MorseText.TabIndex = 10;
            this.MorseText.TextChanged += new System.EventHandler(this.MorseValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 355);
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
            this.BtnCopyKey.Location = new System.Drawing.Point(149, 43);
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
            this.BtnPasteKey.Location = new System.Drawing.Point(149, 71);
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
            this.PortText.Location = new System.Drawing.Point(254, 70);
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
            this.label3.Location = new System.Drawing.Point(208, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "PORT:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IntervalText
            // 
            this.IntervalText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IntervalText.Location = new System.Drawing.Point(289, 280);
            this.IntervalText.Margin = new System.Windows.Forms.Padding(2);
            this.IntervalText.MaxLength = 10;
            this.IntervalText.Name = "IntervalText";
            this.IntervalText.Size = new System.Drawing.Size(68, 23);
            this.IntervalText.TabIndex = 21;
            this.IntervalText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntervalText_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(215, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Interval:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(336, 305);
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
            this.Menu.Size = new System.Drawing.Size(453, 25);
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
            this.label6.Location = new System.Drawing.Point(8, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Parse:";
            // 
            // ParseText
            // 
            this.ParseText.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ParseText.Location = new System.Drawing.Point(11, 323);
            this.ParseText.Margin = new System.Windows.Forms.Padding(2);
            this.ParseText.Multiline = true;
            this.ParseText.Name = "ParseText";
            this.ParseText.ReadOnly = true;
            this.ParseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ParseText.Size = new System.Drawing.Size(429, 29);
            this.ParseText.TabIndex = 26;
            // 
            // clearParseLogToolStripMenuItem
            // 
            this.clearParseLogToolStripMenuItem.Name = "clearParseLogToolStripMenuItem";
            this.clearParseLogToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.clearParseLogToolStripMenuItem.Text = "Clear Parse Log";
            this.clearParseLogToolStripMenuItem.Click += new System.EventHandler(this.clearParseLogToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 460);
            this.Controls.Add(this.ParseText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IntervalText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.BtnPasteKey);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.BtnCopyKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MorseText);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.IpText);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.SendText);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.lbMsg);
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
        private System.Windows.Forms.TextBox IntervalText;
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
    }
}

