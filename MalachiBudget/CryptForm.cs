using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MalachiBudget
{
    public partial class CryptForm : Form
    {
        public CryptForm()
        {
            InitializeComponent();
        }

        private void CryptForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUser2.Text = StringCypher.Encrypt(txtUser1.Text);
            txtPass2.Text = StringCypher.Encrypt(txtPass1.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUser1.Text = StringCypher.Decrypt(txtUser2.Text);
            txtPass1.Text = StringCypher.Decrypt(txtPass2.Text);
        }
    }
}
