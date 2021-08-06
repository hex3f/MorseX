namespace MorseXServer
{
    partial class Server
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
            this.MessageText = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IpText = new System.Windows.Forms.TextBox();
            this.BtnResetIp = new System.Windows.Forms.Button();
            this.BtnRcv = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labIPnow = new System.Windows.Forms.Label();
            this.LogText = new System.Windows.Forms.TextBox();
            this.LocalIpList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PortText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MessageText
            // 
            this.MessageText.AcceptsReturn = true;
            this.MessageText.Location = new System.Drawing.Point(11, 11);
            this.MessageText.Margin = new System.Windows.Forms.Padding(2);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.ReadOnly = true;
            this.MessageText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageText.Size = new System.Drawing.Size(319, 192);
            this.MessageText.TabIndex = 0;
            this.MessageText.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(361, 129);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(76, 22);
            this.BtnStart.TabIndex = 1;
            this.BtnStart.Text = "START";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(361, 155);
            this.BtnStop.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(76, 22);
            this.BtnStop.TabIndex = 2;
            this.BtnStop.Text = "STOP";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // IpText
            // 
            this.IpText.Location = new System.Drawing.Point(334, 28);
            this.IpText.Margin = new System.Windows.Forms.Padding(2);
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(135, 21);
            this.IpText.TabIndex = 4;
            // 
            // BtnResetIp
            // 
            this.BtnResetIp.Location = new System.Drawing.Point(361, 77);
            this.BtnResetIp.Margin = new System.Windows.Forms.Padding(2);
            this.BtnResetIp.Name = "BtnResetIp";
            this.BtnResetIp.Size = new System.Drawing.Size(76, 22);
            this.BtnResetIp.TabIndex = 5;
            this.BtnResetIp.Text = "RESET IP";
            this.BtnResetIp.UseVisualStyleBackColor = true;
            this.BtnResetIp.Click += new System.EventHandler(this.btnResetIp_Click);
            // 
            // BtnRcv
            // 
            this.BtnRcv.Location = new System.Drawing.Point(361, 103);
            this.BtnRcv.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRcv.Name = "BtnRcv";
            this.BtnRcv.Size = new System.Drawing.Size(76, 22);
            this.BtnRcv.TabIndex = 6;
            this.BtnRcv.Text = "DEFAULT";
            this.BtnRcv.UseVisualStyleBackColor = true;
            this.BtnRcv.Click += new System.EventHandler(this.btnRcv_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(361, 181);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(76, 22);
            this.BtnClear.TabIndex = 7;
            this.BtnClear.Text = "CLEAR";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "CURRENT IP：";
            // 
            // labIPnow
            // 
            this.labIPnow.AutoSize = true;
            this.labIPnow.Location = new System.Drawing.Point(352, 223);
            this.labIPnow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labIPnow.Name = "labIPnow";
            this.labIPnow.Size = new System.Drawing.Size(35, 12);
            this.labIPnow.TabIndex = 9;
            this.labIPnow.Text = "IPnow";
            // 
            // LogText
            // 
            this.LogText.AcceptsReturn = true;
            this.LogText.AccessibleName = "";
            this.LogText.Location = new System.Drawing.Point(11, 207);
            this.LogText.Margin = new System.Windows.Forms.Padding(2);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogText.Size = new System.Drawing.Size(319, 192);
            this.LogText.TabIndex = 10;
            this.LogText.TextChanged += new System.EventHandler(this.LogText_TextChanged);
            // 
            // LocalIpList
            // 
            this.LocalIpList.AcceptsReturn = true;
            this.LocalIpList.AccessibleName = "";
            this.LocalIpList.Location = new System.Drawing.Point(336, 252);
            this.LocalIpList.Margin = new System.Windows.Forms.Padding(2);
            this.LocalIpList.Multiline = true;
            this.LocalIpList.Name = "LocalIpList";
            this.LocalIpList.ReadOnly = true;
            this.LocalIpList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LocalIpList.Size = new System.Drawing.Size(136, 147);
            this.LocalIpList.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "LOCAL IP LIST：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "PORT:";
            // 
            // PortText
            // 
            this.PortText.Location = new System.Drawing.Point(373, 52);
            this.PortText.Margin = new System.Windows.Forms.Padding(2);
            this.PortText.MaxLength = 5;
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(96, 21);
            this.PortText.TabIndex = 14;
            this.PortText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortText_KeyPress);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 410);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LocalIpList);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.labIPnow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnRcv);
            this.Controls.Add(this.BtnResetIp);
            this.Controls.Add(this.IpText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.MessageText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Server";
            this.Text = "MorseX Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IpText;
        private System.Windows.Forms.Button BtnResetIp;
        private System.Windows.Forms.Button BtnRcv;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labIPnow;
        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.TextBox LocalIpList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortText;
    }
}

