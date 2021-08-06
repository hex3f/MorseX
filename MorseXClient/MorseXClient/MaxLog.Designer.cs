
namespace MorseXClient
{
    partial class LogWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogWindowText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LogWindowText
            // 
            this.LogWindowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogWindowText.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogWindowText.Location = new System.Drawing.Point(11, 11);
            this.LogWindowText.Margin = new System.Windows.Forms.Padding(2);
            this.LogWindowText.Multiline = true;
            this.LogWindowText.Name = "LogWindowText";
            this.LogWindowText.ReadOnly = true;
            this.LogWindowText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogWindowText.Size = new System.Drawing.Size(778, 428);
            this.LogWindowText.TabIndex = 11;
            this.LogWindowText.TextChanged += new System.EventHandler(this.LogWindowText_TextChanged);
            // 
            // LogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogWindowText);
            this.Name = "LogWindow";
            this.Text = "LOG WINDOW";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox LogWindowText;
    }
}