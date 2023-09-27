namespace MalachiBudget
{
    partial class ForgotPass
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblVerifyEmail = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.txtVerifyCode = new System.Windows.Forms.TextBox();
            this.cmdVerify = new System.Windows.Forms.Button();
            this.lblValidate = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.lblPassChk2 = new System.Windows.Forms.Label();
            this.lblPassChk = new System.Windows.Forms.Label();
            this.lblPwd2 = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.cmdSubmit2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.Location = new System.Drawing.Point(214, 74);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 22);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(155, 74);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 16);
            this.lblEmail.TabIndex = 17;
            this.lblEmail.Text = "Email:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUser.Location = new System.Drawing.Point(127, 37);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(75, 16);
            this.lblUser.TabIndex = 19;
            this.lblUser.Text = "Username:";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUser.Location = new System.Drawing.Point(214, 31);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(90, 22);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVerifyEmail
            // 
            this.lblVerifyEmail.AutoSize = true;
            this.lblVerifyEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVerifyEmail.Location = new System.Drawing.Point(102, 153);
            this.lblVerifyEmail.Name = "lblVerifyEmail";
            this.lblVerifyEmail.Size = new System.Drawing.Size(317, 16);
            this.lblVerifyEmail.TabIndex = 23;
            this.lblVerifyEmail.Text = "A Verification code has been sent to your email";
            this.lblVerifyEmail.Visible = false;
            // 
            // cmdValidate
            // 
            this.cmdValidate.Location = new System.Drawing.Point(214, 115);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(130, 25);
            this.cmdValidate.TabIndex = 3;
            this.cmdValidate.Text = "Send Email Code";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // txtVerifyCode
            // 
            this.txtVerifyCode.Location = new System.Drawing.Point(214, 197);
            this.txtVerifyCode.Name = "txtVerifyCode";
            this.txtVerifyCode.Size = new System.Drawing.Size(71, 23);
            this.txtVerifyCode.TabIndex = 4;
            this.txtVerifyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdVerify
            // 
            this.cmdVerify.Location = new System.Drawing.Point(214, 241);
            this.cmdVerify.Name = "cmdVerify";
            this.cmdVerify.Size = new System.Drawing.Size(86, 24);
            this.cmdVerify.TabIndex = 5;
            this.cmdVerify.Text = "Submit";
            this.cmdVerify.UseVisualStyleBackColor = true;
            this.cmdVerify.Click += new System.EventHandler(this.cmdVerify_Click);
            // 
            // lblValidate
            // 
            this.lblValidate.AutoSize = true;
            this.lblValidate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValidate.Location = new System.Drawing.Point(37, 199);
            this.lblValidate.Name = "lblValidate";
            this.lblValidate.Size = new System.Drawing.Size(165, 16);
            this.lblValidate.TabIndex = 26;
            this.lblValidate.Text = "Email Verification Code:";
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPwd.Location = new System.Drawing.Point(214, 284);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(110, 22);
            this.txtPwd.TabIndex = 6;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPwd.UseSystemPasswordChar = true;
            this.txtPwd.Visible = false;
            // 
            // txtPwd2
            // 
            this.txtPwd2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPwd2.Location = new System.Drawing.Point(212, 328);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.Size = new System.Drawing.Size(110, 22);
            this.txtPwd2.TabIndex = 7;
            this.txtPwd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPwd2.UseSystemPasswordChar = true;
            this.txtPwd2.Visible = false;
            // 
            // lblPassChk2
            // 
            this.lblPassChk2.AutoSize = true;
            this.lblPassChk2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassChk2.Location = new System.Drawing.Point(213, 347);
            this.lblPassChk2.Name = "lblPassChk2";
            this.lblPassChk2.Size = new System.Drawing.Size(46, 16);
            this.lblPassChk2.TabIndex = 32;
            this.lblPassChk2.Text = ".............";
            this.lblPassChk2.Visible = false;
            // 
            // lblPassChk
            // 
            this.lblPassChk.AutoSize = true;
            this.lblPassChk.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassChk.Location = new System.Drawing.Point(212, 303);
            this.lblPassChk.Name = "lblPassChk";
            this.lblPassChk.Size = new System.Drawing.Size(46, 16);
            this.lblPassChk.TabIndex = 31;
            this.lblPassChk.Text = ".............";
            this.lblPassChk.Visible = false;
            // 
            // lblPwd2
            // 
            this.lblPwd2.AutoSize = true;
            this.lblPwd2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPwd2.Location = new System.Drawing.Point(94, 328);
            this.lblPwd2.Name = "lblPwd2";
            this.lblPwd2.Size = new System.Drawing.Size(113, 16);
            this.lblPwd2.TabIndex = 30;
            this.lblPwd2.Text = "Verify Password:";
            this.lblPwd2.Visible = false;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPwd.Location = new System.Drawing.Point(135, 284);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(71, 16);
            this.lblPwd.TabIndex = 29;
            this.lblPwd.Text = "Password:";
            this.lblPwd.Visible = false;
            // 
            // cmdSubmit2
            // 
            this.cmdSubmit2.Location = new System.Drawing.Point(354, 328);
            this.cmdSubmit2.Name = "cmdSubmit2";
            this.cmdSubmit2.Size = new System.Drawing.Size(86, 24);
            this.cmdSubmit2.TabIndex = 8;
            this.cmdSubmit2.Text = "Submit";
            this.cmdSubmit2.UseVisualStyleBackColor = true;
            this.cmdSubmit2.Visible = false;
            this.cmdSubmit2.Click += new System.EventHandler(this.cmdSubmit2_Click);
            // 
            // ForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 386);
            this.Controls.Add(this.cmdSubmit2);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtPwd2);
            this.Controls.Add(this.lblPassChk2);
            this.Controls.Add(this.lblPassChk);
            this.Controls.Add(this.lblPwd2);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.txtVerifyCode);
            this.Controls.Add(this.cmdVerify);
            this.Controls.Add(this.lblValidate);
            this.Controls.Add(this.lblVerifyEmail);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Name = "ForgotPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPass";
            this.Load += new System.EventHandler(this.ForgotPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblUser;
        private TextBox txtUser;
        private Label lblVerifyEmail;
        private Button cmdValidate;
        private TextBox txtVerifyCode;
        private Button cmdVerify;
        private Label lblValidate;
        private TextBox txtPwd;
        private TextBox txtPwd2;
        private Label lblPassChk2;
        private Label lblPassChk;
        private Label lblPwd2;
        private Label lblPwd;
        private Button cmdSubmit2;
    }
}