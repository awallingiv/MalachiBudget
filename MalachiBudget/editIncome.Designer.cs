namespace MalachiBudget
{
    partial class editIncome
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCheckStatus = new System.Windows.Forms.ComboBox();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTithe = new System.Windows.Forms.Label();
            this.txtTithe = new System.Windows.Forms.TextBox();
            this.lblGross = new System.Windows.Forms.Label();
            this.txtGross = new System.Windows.Forms.TextBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTitheStatus = new System.Windows.Forms.ComboBox();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(603, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Status (Check)";
            // 
            // cmbCheckStatus
            // 
            this.cmbCheckStatus.FormattingEnabled = true;
            this.cmbCheckStatus.Location = new System.Drawing.Point(604, 63);
            this.cmbCheckStatus.Name = "cmbCheckStatus";
            this.cmbCheckStatus.Size = new System.Drawing.Size(95, 23);
            this.cmbCheckStatus.TabIndex = 63;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(512, 63);
            this.txtDate.Mask = "00/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(85, 23);
            this.txtDate.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(512, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 61;
            this.label3.Text = "MM/DD/YY";
            // 
            // lblTithe
            // 
            this.lblTithe.AutoSize = true;
            this.lblTithe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTithe.Location = new System.Drawing.Point(347, 40);
            this.lblTithe.Name = "lblTithe";
            this.lblTithe.Size = new System.Drawing.Size(42, 20);
            this.lblTithe.TabIndex = 60;
            this.lblTithe.Text = "Tithe";
            // 
            // txtTithe
            // 
            this.txtTithe.Location = new System.Drawing.Point(337, 63);
            this.txtTithe.Name = "txtTithe";
            this.txtTithe.Size = new System.Drawing.Size(64, 23);
            this.txtTithe.TabIndex = 59;
            this.txtTithe.Text = "0.00";
            // 
            // lblGross
            // 
            this.lblGross.AutoSize = true;
            this.lblGross.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGross.Location = new System.Drawing.Point(276, 40);
            this.lblGross.Name = "lblGross";
            this.lblGross.Size = new System.Drawing.Size(45, 20);
            this.lblGross.TabIndex = 58;
            this.lblGross.Text = "Gross";
            // 
            // txtGross
            // 
            this.txtGross.Location = new System.Drawing.Point(267, 63);
            this.txtGross.Name = "txtGross";
            this.txtGross.Size = new System.Drawing.Size(64, 23);
            this.txtGross.TabIndex = 57;
            this.txtGross.Text = "0.00";
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Location = new System.Drawing.Point(317, 116);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(84, 23);
            this.cmdSubmit.TabIndex = 56;
            this.cmdSubmit.Text = "Submit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(411, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 55;
            this.label5.Text = "Status(Tithe)";
            // 
            // lblNet
            // 
            this.lblNet.AutoSize = true;
            this.lblNet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNet.Location = new System.Drawing.Point(213, 40);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(33, 20);
            this.lblNet.TabIndex = 54;
            this.lblNet.Text = "Net";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(63, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Description";
            // 
            // cmbTitheStatus
            // 
            this.cmbTitheStatus.FormattingEnabled = true;
            this.cmbTitheStatus.Location = new System.Drawing.Point(408, 63);
            this.cmbTitheStatus.Name = "cmbTitheStatus";
            this.cmbTitheStatus.Size = new System.Drawing.Size(95, 23);
            this.cmbTitheStatus.TabIndex = 52;
            // 
            // txtNet
            // 
            this.txtNet.Location = new System.Drawing.Point(197, 63);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(64, 23);
            this.txtNet.TabIndex = 51;
            this.txtNet.Text = "0.00";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(17, 63);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(174, 23);
            this.txtDesc.TabIndex = 50;
            this.txtDesc.Text = "Description";
            // 
            // editIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCheckStatus);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTithe);
            this.Controls.Add(this.txtTithe);
            this.Controls.Add(this.lblGross);
            this.Controls.Add(this.txtGross);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTitheStatus);
            this.Controls.Add(this.txtNet);
            this.Controls.Add(this.txtDesc);
            this.Name = "editIncome";
            this.Text = "editIncome";
            this.Load += new System.EventHandler(this.editIncome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private ComboBox cmbCheckStatus;
        private MaskedTextBox txtDate;
        private Label label3;
        private Label lblTithe;
        private TextBox txtTithe;
        private Label lblGross;
        private TextBox txtGross;
        private Button cmdSubmit;
        private Label label5;
        private Label lblNet;
        private Label label1;
        private ComboBox cmbTitheStatus;
        private TextBox txtNet;
        private TextBox txtDesc;
    }
}