using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MalachiBudget
{
    public partial class editExpense : Form
    {        
            //mainForm F = new mainForm();
            public string[] rowContents;
            MySqlConnection conn;
            string currentUser;

            public editExpense(MySqlConnection connection, string _currentUser)
            {
                InitializeComponent();
                this.conn = connection;
                this.currentUser = _currentUser;
            }

            private void editExpense_Load(object sender, EventArgs e)
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
            try
                {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                txtDesc.Text = rowContents[0];
                    txtAmt.Text = rowContents[1];
                    txtDate.Text = rowContents[2];
                    txtNotes.Text = rowContents[3];
                    cmbCategory.Text = rowContents[4];

                    //loadStatusComboBox();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void cmdSubmit_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                string[] cellContents = new string[6];
                cellContents[0] = txtDesc.Text;
                cellContents[1] = txtAmt.Text;
                cellContents[2] = txtDate.Text;
                cellContents[3] = txtNotes.Text;
                cellContents[4] = cmbCategory.Text;
                cellContents[5] = rowContents[5];

                
                if (cellContents[1] == "")
                {
                    cellContents[1] = "0.0";
                }
                for (int i = 0; i < cellContents.Length; i++)
                {

                    if (cellContents[i] == "")
                    {
                        cellContents[i] = "= Null";
                    }
                    else if (i == 1)
                    {
                        //do nothing we want the double left a double
                    }
                    else
                    {
                        cellContents[i] = $"= '{cellContents[i]}'";
                    }
                }

                
                double dblAmount = Convert.ToDouble(cellContents[1]);
                    
                // 0 = description
                // dblAmouunt = 1/amount
                // 2 = Date
                // 3 = notes
                // 4 = category                    

                //fix date field for update
                string fixedDate = convertExpenseDate(txtDate.Text);

                DateTime dtOld = ParseDate(rowContents[5]);    //for previous transaction date              
                string oldTransID = dtOld.ToString("yyyy-MM-dd HH:mm:ss");          //for old transaction date

                string newTransID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");   //for new transaction date

                string sql = $"UPDATE Transactions SET Description {cellContents[0]}, Amount = {dblAmount}, Date = '{fixedDate}', Notes {cellContents[3]}, Category {cellContents[4]}, TransID = '{newTransID}' WHERE Username = '{currentUser}' AND Tablename = 'expenses' AND transID = '{oldTransID}';";


                MySqlCommand update = new MySqlCommand(@sql, conn);
                update.CommandTimeout = 200;
                update.ExecuteNonQuery();
                
                MessageBox.Show("Done!");


                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DateTime ParseDate(string s)
        {
            DateTime result;
            if (!DateTime.TryParse(s, out result))
            {
                result = DateTime.ParseExact(s, "yyyy-MM-ddT24:mm:ssK", System.Globalization.CultureInfo.InvariantCulture);
                result = result.AddDays(1);
            }
            return result;
        }

        public static string convertExpenseDate(string date)
        {
            //    example format '2022-10-07 12:00:00'
            string[] temp;
            int mo = 0;
            int day = 0;
            int yr = 0;

            temp = date.Split("/");

            //convert day and month to int
            mo = Convert.ToInt32(temp[0]);
            day = Convert.ToInt32(temp[1]);
            yr = Convert.ToInt32(temp[2]) + 2000;

            //create datetime object
            DateTime dt = new DateTime(yr, mo, day, 12, 00, 00);

            //format DateTime and put in string
            string result = dt.ToString("yyyy-MM-dd HH:mm:ss");

            //return string
            return result;

        }
    }
}




