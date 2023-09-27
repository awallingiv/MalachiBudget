using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MalachiBudget
{
    public partial class addBill : Form
    {
        MySqlConnection conn;
        public string currentUser;

        public addBill(MySqlConnection connection, string _currentUser)
        {
            InitializeComponent();
            this.conn = connection;
            this.currentUser = _currentUser;
        }

        private void addBill_Load(object sender, EventArgs e)
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
                conn.Close();
                conn.Open();


                txtDate.Text = DateTime.Now.ToString("MM/dd/yy");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();

                string[] cellContents = new string[5];
                cellContents[0] = txtDesc.Text;
                cellContents[1] = txtAmt.Text;
                cellContents[2] = txtDate.Text;
                cellContents[3] = txtNotes.Text;
                cellContents[4] = cmbBillStatus.Text;

                if (cellContents[1] == "")
                {
                    cellContents[1] = "0.0";
                }
                for (int i = 0; i < 5; i++)
                {

                    if (cellContents[i] == "")
                    {
                        cellContents[i] = "Null";
                    }
                    else if (i == 1)
                    {
                        //do nothing we want the double left a double
                    }
                    else
                    {
                        cellContents[i] = $"'{cellContents[i]}'";
                    }
                }

                try
                {
                    double dblAmount = Convert.ToDouble(cellContents[1]);

                    //string sql = $"INSERT INTO utilities VALUES ({cellContents[0]}, {dblAmount}, {cellContents[2]}, {cellContents[3]}, {cellContents[4]})";

                    string fixedDate = convertExpenseDate(txtDate.Text);
                    string transID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string sql = $"INSERT INTO Transactions (`Username`,`TableName`,`Description`,`Amount`,`Due`, `Date`, `Notes`, `Category`, `Status`, `TransID`) " +
                    $"Values ('{currentUser}', 'bills', {cellContents[0]}, {dblAmount}, '{fixedDate}', NULL, {cellContents[3]}, NULL, {cellContents[4]}, '{transID}');";

                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DialogResult response = MessageBox.Show("Success! Add Another?", "Add another entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //clear fields
                if (response == DialogResult.Yes)
                {
                    txtDesc.Text = "Description";
                    txtAmt.Text = "0.0";
                    txtDate.Text = DateTime.Now.ToString("MM/dd/yy");
                    txtNotes.Text = "enter notes";
                    cmbBillStatus.Text = "PAID";

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string convertExpenseDate(string date)
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

        private void cmbBillStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
