namespace ClientSimulator
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
            this.plbl = new System.Windows.Forms.Label();
            this.clbl = new System.Windows.Forms.Label();
            this.ilbl = new System.Windows.Forms.Label();
            this.pTxt = new System.Windows.Forms.TextBox();
            this.cTxt = new System.Windows.Forms.TextBox();
            this.iTxt = new System.Windows.Forms.TextBox();
            this.sBtn = new System.Windows.Forms.Button();
            this.pBtn = new System.Windows.Forms.Button();
            this.rTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // plbl
            // 
            this.plbl.AutoSize = true;
            this.plbl.Location = new System.Drawing.Point(67, 61);
            this.plbl.Name = "plbl";
            this.plbl.Size = new System.Drawing.Size(93, 25);
            this.plbl.TabIndex = 0;
            this.plbl.Text = "Publisher";
            // 
            // clbl
            // 
            this.clbl.AutoSize = true;
            this.clbl.Location = new System.Drawing.Point(67, 130);
            this.clbl.Name = "clbl";
            this.clbl.Size = new System.Drawing.Size(81, 25);
            this.clbl.TabIndex = 0;
            this.clbl.Text = "Content";
            // 
            // ilbl
            // 
            this.ilbl.AutoSize = true;
            this.ilbl.Location = new System.Drawing.Point(67, 198);
            this.ilbl.Name = "ilbl";
            this.ilbl.Size = new System.Drawing.Size(76, 25);
            this.ilbl.TabIndex = 0;
            this.ilbl.Text = "Images";
            // 
            // pTxt
            // 
            this.pTxt.Location = new System.Drawing.Point(186, 58);
            this.pTxt.Name = "pTxt";
            this.pTxt.Size = new System.Drawing.Size(702, 29);
            this.pTxt.TabIndex = 1;
            // 
            // cTxt
            // 
            this.cTxt.Location = new System.Drawing.Point(186, 127);
            this.cTxt.Name = "cTxt";
            this.cTxt.Size = new System.Drawing.Size(702, 29);
            this.cTxt.TabIndex = 1;
            // 
            // iTxt
            // 
            this.iTxt.Location = new System.Drawing.Point(72, 247);
            this.iTxt.Multiline = true;
            this.iTxt.Name = "iTxt";
            this.iTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.iTxt.Size = new System.Drawing.Size(620, 188);
            this.iTxt.TabIndex = 1;
            // 
            // sBtn
            // 
            this.sBtn.Location = new System.Drawing.Point(740, 284);
            this.sBtn.Name = "sBtn";
            this.sBtn.Size = new System.Drawing.Size(148, 120);
            this.sBtn.TabIndex = 2;
            this.sBtn.Text = "Select...";
            this.sBtn.UseVisualStyleBackColor = true;
            this.sBtn.Click += new System.EventHandler(this.sBtn_Click);
            // 
            // pBtn
            // 
            this.pBtn.Location = new System.Drawing.Point(72, 483);
            this.pBtn.Name = "pBtn";
            this.pBtn.Size = new System.Drawing.Size(816, 53);
            this.pBtn.TabIndex = 3;
            this.pBtn.Text = "Publish";
            this.pBtn.UseVisualStyleBackColor = true;
            this.pBtn.Click += new System.EventHandler(this.pBtn_Click);
            // 
            // rTxt
            // 
            this.rTxt.Location = new System.Drawing.Point(72, 586);
            this.rTxt.Multiline = true;
            this.rTxt.Name = "rTxt";
            this.rTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rTxt.Size = new System.Drawing.Size(816, 236);
            this.rTxt.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 859);
            this.Controls.Add(this.pBtn);
            this.Controls.Add(this.sBtn);
            this.Controls.Add(this.rTxt);
            this.Controls.Add(this.iTxt);
            this.Controls.Add(this.cTxt);
            this.Controls.Add(this.pTxt);
            this.Controls.Add(this.ilbl);
            this.Controls.Add(this.clbl);
            this.Controls.Add(this.plbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label plbl;
        private System.Windows.Forms.Label clbl;
        private System.Windows.Forms.Label ilbl;
        private System.Windows.Forms.TextBox pTxt;
        private System.Windows.Forms.TextBox cTxt;
        private System.Windows.Forms.TextBox iTxt;
        private System.Windows.Forms.Button sBtn;
        private System.Windows.Forms.Button pBtn;
        private System.Windows.Forms.TextBox rTxt;
    }
}

