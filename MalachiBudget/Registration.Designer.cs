namespace MalachiBudget
{
    partial class Registration
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.cmdCheckAvailability = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.cmdValidate = new System.Windows.Forms.Button();
            this.lblValidate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdVerify = new System.Windows.Forms.Button();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.txtVerifyCode = new System.Windows.Forms.TextBox();
            this.lblVerifyEmail = new System.Windows.Forms.Label();
            this.lblPassChk = new System.Windows.Forms.Label();
            this.lblPassChk2 = new System.Windows.Forms.Label();
            this.lblEmailChk2 = new System.Windows.Forms.Label();
            this.lblEmailChk = new System.Windows.Forms.Label();
            this.lblNameChk = new System.Windows.Forms.Label();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.cmdResend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(110, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Full Name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(192, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUser.Location = new System.Drawing.Point(193, 161);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(90, 22);
            this.txtUser.TabIndex = 4;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // cmdCheckAvailability
            // 
            this.cmdCheckAvailability.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdCheckAvailability.Location = new System.Drawing.Point(303, 159);
            this.cmdCheckAvailability.Name = "cmdCheckAvailability";
            this.cmdCheckAvailability.Size = new System.Drawing.Size(53, 24);
            this.cmdCheckAvailability.TabIndex = 5;
            this.cmdCheckAvailability.Text = "Check Availability";
            this.cmdCheckAvailability.UseVisualStyleBackColor = true;
            this.cmdCheckAvailability.Click += new System.EventHandler(this.cmdCheckAvailability_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.Location = new System.Drawing.Point(111, 165);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 16);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(140, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(98, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Verify Email:";
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvailability.Location = new System.Drawing.Point(193, 183);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(46, 16);
            this.lblAvailability.TabIndex = 9;
            this.lblAvailability.Text = ".............";
            this.lblAvailability.Visible = false;
            // 
            // cmdValidate
            // 
            this.cmdValidate.Location = new System.Drawing.Point(192, 303);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(130, 25);
            this.cmdValidate.TabIndex = 8;
            this.cmdValidate.Text = "Send Email Code";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // lblValidate
            // 
            this.lblValidate.AutoSize = true;
            this.lblValidate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValidate.Location = new System.Drawing.Point(22, 375);
            this.lblValidate.Name = "lblValidate";
            this.lblValidate.Size = new System.Drawing.Size(165, 16);
            this.lblValidate.TabIndex = 12;
            this.lblValidate.Text = "Email Verification Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(74, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Verify Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(115, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // cmdVerify
            // 
            this.cmdVerify.Location = new System.Drawing.Point(192, 417);
            this.cmdVerify.Name = "cmdVerify";
            this.cmdVerify.Size = new System.Drawing.Size(86, 24);
            this.cmdVerify.TabIndex = 10;
            this.cmdVerify.Text = "Submit";
            this.cmdVerify.UseVisualStyleBackColor = true;
            this.cmdVerify.Click += new System.EventHandler(this.cmdVerify_Click);
            // 
            // txtEmail2
            // 
            this.txtEmail2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail2.Location = new System.Drawing.Point(194, 118);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(163, 22);
            this.txtEmail2.TabIndex = 3;
            this.txtEmail2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEmail2.TextChanged += new System.EventHandler(this.txtEmail2_TextChanged);
            // 
            // txtVerifyCode
            // 
            this.txtVerifyCode.Location = new System.Drawing.Point(193, 368);
            this.txtVerifyCode.Name = "txtVerifyCode";
            this.txtVerifyCode.Size = new System.Drawing.Size(71, 23);
            this.txtVerifyCode.TabIndex = 9;
            this.txtVerifyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVerifyEmail
            // 
            this.lblVerifyEmail.AutoSize = true;
            this.lblVerifyEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVerifyEmail.Location = new System.Drawing.Point(59, 340);
            this.lblVerifyEmail.Name = "lblVerifyEmail";
            this.lblVerifyEmail.Size = new System.Drawing.Size(317, 16);
            this.lblVerifyEmail.TabIndex = 21;
            this.lblVerifyEmail.Text = "A Verification code has been sent to your email";
            this.lblVerifyEmail.Visible = false;
            // 
            // lblPassChk
            // 
            this.lblPassChk.AutoSize = true;
            this.lblPassChk.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassChk.Location = new System.Drawing.Point(192, 227);
            this.lblPassChk.Name = "lblPassChk";
            this.lblPassChk.Size = new System.Drawing.Size(46, 16);
            this.lblPassChk.TabIndex = 22;
            this.lblPassChk.Text = ".............";
            this.lblPassChk.Visible = false;
            // 
            // lblPassChk2
            // 
            this.lblPassChk2.AutoSize = true;
            this.lblPassChk2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassChk2.Location = new System.Drawing.Point(193, 271);
            this.lblPassChk2.Name = "lblPassChk2";
            this.lblPassChk2.Size = new System.Drawing.Size(46, 16);
            this.lblPassChk2.TabIndex = 23;
            this.lblPassChk2.Text = ".............";
            this.lblPassChk2.Visible = false;
            // 
            // lblEmailChk2
            // 
            this.lblEmailChk2.AutoSize = true;
            this.lblEmailChk2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmailChk2.Location = new System.Drawing.Point(193, 142);
            this.lblEmailChk2.Name = "lblEmailChk2";
            this.lblEmailChk2.Size = new System.Drawing.Size(46, 16);
            this.lblEmailChk2.TabIndex = 24;
            this.lblEmailChk2.Text = ".............";
            this.lblEmailChk2.Visible = false;
            // 
            // lblEmailChk
            // 
            this.lblEmailChk.AutoSize = true;
            this.lblEmailChk.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmailChk.Location = new System.Drawing.Point(193, 100);
            this.lblEmailChk.Name = "lblEmailChk";
            this.lblEmailChk.Size = new System.Drawing.Size(46, 16);
            this.lblEmailChk.TabIndex = 25;
            this.lblEmailChk.Text = ".............";
            this.lblEmailChk.Visible = false;
            // 
            // lblNameChk
            // 
            this.lblNameChk.AutoSize = true;
            this.lblNameChk.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNameChk.Location = new System.Drawing.Point(194, 56);
            this.lblNameChk.Name = "lblNameChk";
            this.lblNameChk.Size = new System.Drawing.Size(46, 16);
            this.lblNameChk.TabIndex = 26;
            this.lblNameChk.Text = ".............";
            this.lblNameChk.Visible = false;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail1.Location = new System.Drawing.Point(192, 81);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(164, 22);
            this.txtEmail1.TabIndex = 2;
            this.txtEmail1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEmail1.TextChanged += new System.EventHandler(this.txtEmail1_TextChanged);
            // 
            // txtPwd2
            // 
            this.txtPwd2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPwd2.Location = new System.Drawing.Point(192, 252);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.Size = new System.Drawing.Size(110, 22);
            this.txtPwd2.TabIndex = 7;
            this.txtPwd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPwd2.UseSystemPasswordChar = true;
            this.txtPwd2.TextChanged += new System.EventHandler(this.txtPwd2_TextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPwd.Location = new System.Drawing.Point(194, 208);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(110, 22);
            this.txtPwd.TabIndex = 6;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPwd.UseSystemPasswordChar = true;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            // 
            // cmdResend
            // 
            this.cmdResend.Location = new System.Drawing.Point(352, 417);
            this.cmdResend.Name = "cmdResend";
            this.cmdResend.Size = new System.Drawing.Size(110, 23);
            this.cmdResend.TabIndex = 27;
            this.cmdResend.Text = "Re-Send Code";
            this.cmdResend.UseVisualStyleBackColor = true;
            this.cmdResend.Click += new System.EventHandler(this.cmdResend_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(474, 453);
            this.Controls.Add(this.cmdResend);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtPwd2);
            this.Controls.Add(this.txtEmail1);
            this.Controls.Add(this.lblNameChk);
            this.Controls.Add(this.lblEmailChk);
            this.Controls.Add(this.lblEmailChk2);
            this.Controls.Add(this.lblPassChk2);
            this.Controls.Add(this.lblPassChk);
            this.Controls.Add(this.lblVerifyEmail);
            this.Controls.Add(this.txtVerifyCode);
            this.Controls.Add(this.txtEmail2);
            this.Controls.Add(this.cmdVerify);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblValidate);
            this.Controls.Add(this.cmdValidate);
            this.Controls.Add(this.lblAvailability);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmdCheckAvailability);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private TextBox txtUser;
        private Button cmdCheckAvailability;
        private Label lblUsername;
        private Label label1;
        private Label label2;
        private Label lblAvailability;
        private Button cmdValidate;
        private Label lblValidate;
        private Label label3;
        private Label label4;
        private Button cmdVerify;
        private TextBox txtEmail2;
        private TextBox txtVerifyCode;
        private Label lblVerifyEmail;
        private Label lblPassChk;
        private Label lblPassChk2;
        private Label lblEmailChk2;
        private Label lblEmailChk;
        private Label lblNameChk;
        private TextBox txtEmail1;
        private TextBox txtPwd2;
        private TextBox txtPwd;
        private Button cmdResend;
    }
}