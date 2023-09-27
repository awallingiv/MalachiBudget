namespace MalachiBudget
{
    partial class addIncome
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
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCheckStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTithe
            // 
            this.lblTithe.AutoSize = true;
            this.lblTithe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTithe.Location = new System.Drawing.Point(353, 43);
            this.lblTithe.Name = "lblTithe";
            this.lblTithe.Size = new System.Drawing.Size(42, 20);
            this.lblTithe.TabIndex = 36;
            this.lblTithe.Text = "Tithe";
            // 
            // txtTithe
            // 
            this.txtTithe.Location = new System.Drawing.Point(343, 66);
            this.txtTithe.Name = "txtTithe";
            this.txtTithe.Size = new System.Drawing.Size(64, 23);
            this.txtTithe.TabIndex = 4;
            this.txtTithe.Text = "0.00";
            // 
            // lblGross
            // 
            this.lblGross.AutoSize = true;
            this.lblGross.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGross.Location = new System.Drawing.Point(282, 43);
            this.lblGross.Name = "lblGross";
            this.lblGross.Size = new System.Drawing.Size(45, 20);
            this.lblGross.TabIndex = 34;
            this.lblGross.Text = "Gross";
            // 
            // txtGross
            // 
            this.txtGross.Location = new System.Drawing.Point(273, 66);
            this.txtGross.Name = "txtGross";
            this.txtGross.Size = new System.Drawing.Size(64, 23);
            this.txtGross.TabIndex = 3;
            this.txtGross.Text = "0.00";
            this.txtGross.TextChanged += new System.EventHandler(this.txtGross_TextChanged);
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Location = new System.Drawing.Point(323, 119);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(84, 23);
            this.cmdSubmit.TabIndex = 8;
            this.cmdSubmit.Text = "Submit";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(417, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Status(Tithe)";
            // 
            // lblNet
            // 
            this.lblNet.AutoSize = true;
            this.lblNet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNet.Location = new System.Drawing.Point(219, 43);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(33, 20);
            this.lblNet.TabIndex = 30;
            this.lblNet.Text = "Net";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(69, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Description";
            // 
            // cmbTitheStatus
            // 
            this.cmbTitheStatus.FormattingEnabled = true;
            this.cmbTitheStatus.Location = new System.Drawing.Point(414, 66);
            this.cmbTitheStatus.Name = "cmbTitheStatus";
            this.cmbTitheStatus.Size = new System.Drawing.Size(95, 23);
            this.cmbTitheStatus.TabIndex = 5;
            // 
            // txtNet
            // 
            this.txtNet.Location = new System.Drawing.Point(203, 66);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(64, 23);
            this.txtNet.TabIndex = 2;
            this.txtNet.Text = "0.00";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(23, 66);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(174, 23);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.Text = "Description";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(518, 66);
            this.txtDate.Mask = "00/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(85, 23);
            this.txtDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(518, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "MM/DD/YY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(609, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Status (Check)";
            // 
            // cmbCheckStatus
            // 
            this.cmbCheckStatus.FormattingEnabled = true;
            this.cmbCheckStatus.Location = new System.Drawing.Point(610, 66);
            this.cmbCheckStatus.Name = "cmbCheckStatus";
            this.cmbCheckStatus.Size = new System.Drawing.Size(95, 23);
            this.cmbCheckStatus.TabIndex = 7;
            // 
            // addIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(727, 164);
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
            this.Name = "addIncome";
            this.Text = "addIncome";
            this.Load += new System.EventHandler(this.addIncome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private MaskedTextBox txtDate;
        private Label label3;
        private Label label2;
        private ComboBox cmbCheckStatus;
    }
}