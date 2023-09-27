namespace MalachiBudget
{
    partial class addUtility
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUtilityStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(620, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "Status";
            // 
            // cmbSubmit
            // 
            this.cmbSubmit.ForeColor = System.Drawing.Color.Black;
            this.cmbSubmit.Location = new System.Drawing.Point(309, 104);
            this.cmbSubmit.Name = "cmbSubmit";
            this.cmbSubmit.Size = new System.Drawing.Size(75, 23);
            this.cmbSubmit.TabIndex = 42;
            this.cmbSubmit.Text = "Submit";
            this.cmbSubmit.UseVisualStyleBackColor = true;
            this.cmbSubmit.Click += new System.EventHandler(this.cmbSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(420, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Notes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(262, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Due Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(191, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(52, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Description";
            // 
            // cmbUtilityStatus
            // 
            this.cmbUtilityStatus.FormattingEnabled = true;
            this.cmbUtilityStatus.Location = new System.Drawing.Point(562, 69);
            this.cmbUtilityStatus.Name = "cmbUtilityStatus";
            this.cmbUtilityStatus.Size = new System.Drawing.Size(160, 23);
            this.cmbUtilityStatus.TabIndex = 37;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(339, 69);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(217, 23);
            this.txtNotes.TabIndex = 36;
            // 
            // txtAmt
            // 
            this.txtAmt.Location = new System.Drawing.Point(192, 69);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(64, 23);
            this.txtAmt.TabIndex = 34;
            this.txtAmt.Text = "0.00";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(12, 69);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(174, 23);
            this.txtDesc.TabIndex = 33;
            this.txtDesc.Text = "Description";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(262, 69);
            this.txtDate.Mask = "00/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(71, 23);
            this.txtDate.TabIndex = 44;
            // 
            // addUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 161);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSubmit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUtilityStatus);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.txtDesc);
            this.Name = "addUtility";
            this.Text = "addUtility";
            this.Load += new System.EventHandler(this.addUtility_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label5;
        private Button cmbSubmit;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbUtilityStatus;
        private TextBox txtNotes;
        private TextBox txtAmt;
        private TextBox txtDesc;
        private MaskedTextBox txtDate;
    }
}