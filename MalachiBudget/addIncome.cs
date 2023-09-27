using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MalachiBudget
{
    public partial class addIncome : Form
    {          
            //mainForm F = new mainForm();
            MySqlConnection conn;
            string tithePercent;
            string currentUser;
            public addIncome(MySqlConnection connection, string t, string _currentUser)
            {
                InitializeComponent();
                this.conn = connection;
                this.tithePercent = $".{t}";
                this.currentUser = _currentUser;
            }

            private void cmdSubmit_Click(object sender, EventArgs e)
            {
                try
                {
                    
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                    

                string[] cellContents = new string[7];
                    cellContents[0] = txtDesc.Text;
                    cellContents[1] = txtNet.Text;
                    cellContents[2] = txtGross.Text;
                    cellContents[3] = txtTithe.Text;
                    cellContents[4] = cmbTitheStatus.Text;
                    cellContents[5] = txtDate.Text;
                    cellContents[6] = cmbCheckStatus.Text;

                    for (int i = 0; i < cellContents.Length; i++)
                    {
                        if (cellContents[i] == "")
                        {
                            if (i == 0 || i == 4)
                            {
                                cellContents[i] = "NULL";
                            }
                            else
                            {
                                cellContents[i] = "0.0";
                            }
                        }
                        else
                        {
                            if (i == 0 || i == 4 || i == 6)
                            {
                                cellContents[i] = $"'{cellContents[i]}'";
                            }
                            else
                            {
                                //do nothing, leave the dbl a dbl
                            }
                        }
                    }


                //old
                //string sql = $"INSERT INTO income (Description, Net, Gross, Tithe, Status) VALUES ({values[0]}, {Convert.ToDouble(values[1])}, {Convert.ToDouble(values[2])}, {Convert.ToDouble(values[3])}, {values[4]})";
                double dblNet = Convert.ToDouble(cellContents[1]);
                double dblGross = Convert.ToDouble(cellContents[2]);
                double dblTithe = Convert.ToDouble(cellContents[3]);

                string fixedDate = convertExpenseDate(txtDate.Text);
                string transID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //Username, Description, Net, Gross, Tithe, TitheStatus, Date, PaycheckStatus, TransID                            

                string sql = $"INSERT INTO Income (`Username`,`Description`,`Net`,`Gross`, `Tithe`, `TitheStatus`, `Date`, `PaycheckStatus`, `TransID`) " +
                $"Values ('{currentUser}', {cellContents[0]}, {dblNet}, {dblGross}, {dblTithe}, {cellContents[4]}, '{fixedDate}', {cellContents[6]}, '{transID}');";

                MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();

                    DialogResult response = MessageBox.Show("Success! Add Another?", "Add another entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //clear fields
                    if (response == DialogResult.Yes)
                    {
                        txtDesc.Text = "Description";
                        txtNet.Text = "0.0";
                        txtGross.Text = "0.0";
                        txtTithe.Text = "0.0";
                        cmbTitheStatus.Text = "SUBMITTED";

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

            private void addIncome_Load(object sender, EventArgs e)
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
                
                
                txtDate.Text = DateTime.Now.ToString("MM/dd/yy");                

                    loadStatusComboBox();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void loadStatusComboBox()
            {
                cmbTitheStatus.Items.Clear();
                cmbTitheStatus.Items.Add("SUBMITTED");
                cmbTitheStatus.Items.Add("POSTED");

                cmbCheckStatus.Items.Add("POSTED");

            }

            private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void txtGross_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    if (txtGross.Text == "")
                    {
                        txtTithe.Text = "0.0";
                    }
                    double gross = Convert.ToDouble(txtGross.Text);
                    double convertedTithe = Convert.ToDouble(tithePercent);
                    double tithe = gross * convertedTithe;
                    txtTithe.Text = Convert.ToString(tithe);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }

            }

    }
}

