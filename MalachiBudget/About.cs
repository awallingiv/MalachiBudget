using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MalachiBudget
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            try
            {
                float width_ratio = (Screen.PrimaryScreen.Bounds.Width / 1920);
                float heigh_ratio = (Screen.PrimaryScreen.Bounds.Height / 1080f);

                SizeF scale = new SizeF(width_ratio, heigh_ratio);

                this.Scale(scale);

                ////And for font size
                //foreach (Control control in this.Controls)
                //{
                //    control.Font = new Font("Microsoft Sans Serif", c.Font.SizeInPoints * heigh_ratio * width_ratio);
                //}
            }
            catch (Exception ex)
            {

            }
            lblAbout.Text = "Malachi Budget and MalachiBudget.com were created soley by me (Austin Walling) for the purpose of making financial software free and available to everyone." +
                "\r\n\r\nI created Malachi Budget software for myself in order to track my bills and expenses and also calculate tithe automatically.  I don't believe that people " +
                "should have to pay money in order to manage their finances, so I wanted this to be a free product.\r\n\r\n I also wanted to " +
                "further develop my skills as a software developer on a private project that interested me, and so MalachiBudget was born. \r\n\r\n Thank you for using this software and joining" +
                " me on this journey.";

            lblAbout.MaximumSize = new Size(400, 0);
            lblAbout.AutoSize = true;

            //create copyright symbol
            byte[] newBytes = new Byte[] { 194, 169 };
            string cRight = System.Text.Encoding.UTF8.GetString(newBytes, 0, newBytes.Length);

            lblCopyright.Text = $"Copyright {cRight} 2022 Austin Walling";

        }

        private void cmdDonate_Click(object sender, EventArgs e)
        {
            string url = "https://www.paypal.com/donate/?business=J24DBMDTTMF62&no_recurring=0&currency_code=USD";
            
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true,
            };
            Process.Start(psi);
        }
    }
}
