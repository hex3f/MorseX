namespace MorseXClient
{
    partial class MorseTranslator
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
            this.TranslateText = new System.Windows.Forms.TextBox();
            this.InputText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TranslateText
            // 
            this.TranslateText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TranslateText.Location = new System.Drawing.Point(11, 111);
            this.TranslateText.Margin = new System.Windows.Forms.Padding(2);
            this.TranslateText.Multiline = true;
            this.TranslateText.Name = "TranslateText";
            this.TranslateText.ReadOnly = true;
            this.TranslateText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TranslateText.Size = new System.Drawing.Size(487, 204);
            this.TranslateText.TabIndex = 11;
            // 
            // InputText
            // 
            this.InputText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputText.Location = new System.Drawing.Point(11, 11);
            this.InputText.Margin = new System.Windows.Forms.Padding(2);
            this.InputText.Multiline = true;
            this.InputText.Name = "InputText";
            this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputText.Size = new System.Drawing.Size(405, 96);
            this.InputText.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 13;
            this.button1.Text = "Translate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(421, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 41);
            this.button2.TabIndex = 14;
            this.button2.Text = "To Morse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MorseTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 326);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.TranslateText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MorseTranslator";
            this.Text = "Morse Translator";
            this.Load += new System.EventHandler(this.MorseTranslator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TranslateText;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}