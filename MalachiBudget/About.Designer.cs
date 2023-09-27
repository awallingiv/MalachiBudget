namespace MalachiBudget
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.cmdDonate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(30, 35);
            this.lblAbout.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(93, 15);
            this.lblAbout.TabIndex = 2;
            this.lblAbout.Text = "Malachi Budget ";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(12, 277);
            this.lblCopyright.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(167, 15);
            this.lblCopyright.TabIndex = 3;
            this.lblCopyright.Text = "Copyright 2022 Austin Walling";
            // 
            // cmdDonate
            // 
            this.cmdDonate.Image = ((System.Drawing.Image)(resources.GetObject("cmdDonate.Image")));
            this.cmdDonate.Location = new System.Drawing.Point(342, 265);
            this.cmdDonate.Name = "cmdDonate";
            this.cmdDonate.Size = new System.Drawing.Size(107, 38);
            this.cmdDonate.TabIndex = 5;
            this.cmdDonate.UseVisualStyleBackColor = true;
            this.cmdDonate.Click += new System.EventHandler(this.cmdDonate_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 301);
            this.Controls.Add(this.cmdDonate);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblAbout);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblAbout;
        private Label lblCopyright;
        private Button cmdDonate;
    }
}