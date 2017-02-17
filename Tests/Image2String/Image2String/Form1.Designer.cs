namespace Image2String
{
    partial class Form1
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
            this.imgStrTxt = new System.Windows.Forms.TextBox();
            this.imgLbl = new System.Windows.Forms.Label();
            this.imgPathTxt = new System.Windows.Forms.TextBox();
            this.browserBtn = new System.Windows.Forms.Button();
            this.rstLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imgStrTxt
            // 
            this.imgStrTxt.Location = new System.Drawing.Point(41, 129);
            this.imgStrTxt.Multiline = true;
            this.imgStrTxt.Name = "imgStrTxt";
            this.imgStrTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.imgStrTxt.Size = new System.Drawing.Size(354, 190);
            this.imgStrTxt.TabIndex = 0;
            // 
            // imgLbl
            // 
            this.imgLbl.AutoSize = true;
            this.imgLbl.Location = new System.Drawing.Point(38, 25);
            this.imgLbl.Name = "imgLbl";
            this.imgLbl.Size = new System.Drawing.Size(39, 13);
            this.imgLbl.TabIndex = 1;
            this.imgLbl.Text = "Image:";
            // 
            // imgPathTxt
            // 
            this.imgPathTxt.Location = new System.Drawing.Point(41, 51);
            this.imgPathTxt.Name = "imgPathTxt";
            this.imgPathTxt.Size = new System.Drawing.Size(253, 20);
            this.imgPathTxt.TabIndex = 2;
            // 
            // browserBtn
            // 
            this.browserBtn.Location = new System.Drawing.Point(320, 48);
            this.browserBtn.Name = "browserBtn";
            this.browserBtn.Size = new System.Drawing.Size(75, 23);
            this.browserBtn.TabIndex = 3;
            this.browserBtn.Text = "Browser";
            this.browserBtn.UseVisualStyleBackColor = true;
            this.browserBtn.Click += new System.EventHandler(this.browserBtn_Click);
            // 
            // rstLbl
            // 
            this.rstLbl.AutoSize = true;
            this.rstLbl.Location = new System.Drawing.Point(38, 103);
            this.rstLbl.Name = "rstLbl";
            this.rstLbl.Size = new System.Drawing.Size(76, 13);
            this.rstLbl.TabIndex = 1;
            this.rstLbl.Text = "Base64 String:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 342);
            this.Controls.Add(this.browserBtn);
            this.Controls.Add(this.imgPathTxt);
            this.Controls.Add(this.rstLbl);
            this.Controls.Add(this.imgLbl);
            this.Controls.Add(this.imgStrTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imgStrTxt;
        private System.Windows.Forms.Label imgLbl;
        private System.Windows.Forms.TextBox imgPathTxt;
        private System.Windows.Forms.Button browserBtn;
        private System.Windows.Forms.Label rstLbl;
    }
}

