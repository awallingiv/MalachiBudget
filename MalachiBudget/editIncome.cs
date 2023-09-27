using MySql.Data.MySqlClient;
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
    public partial class editIncome : Form
    {        
            public string[] rowContents;
            MySqlConnection conn;
            string currentUser;

            public editIncome(MySqlConnection connection, string _currentUser)
            {
                InitializeComponent();
                this.conn = connection;
                this.currentUser = _currentUser;
            }

            private void editIncome_Load(object sender, EventArgs e)
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

                    txtDesc.Text = rowContents[0];
                    txtNet.Text = rowContents[1];
                    txtGross.Text = rowContents[2];
                    txtTithe.Text = rowContents[3];
                    cmbTitheStatus.Text = rowContents[5];
                    txtDate.Text = rowContents[4];
                    cmbCheckStatus.Text = rowContents[6];

                    loadStatusComboBox();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            private void loadStatusComboBox()
            {
                cmbTitheStatus.Items.Add("PAID");
                cmbTitheStatus.Items.Add("POSTED");
            }

            private void cmdSubmit_Click(object sender, EventArgs e)
            {
                try
                {
                    conn.Close();
                    conn.Open();

                    string[] cellContents = new string[7];
                    cellContents[0] = txtDesc.Text;
                    cellContents[1] = txtNet.Text;
                    cellContents[2] = txtGross.Text;
                    cellContents[3] = txtTithe.Text;
                    cellContents[4] = cmbTitheStatus.Text;
                    cellContents[5] = txtDate.Text;
                    cellContents[6] = cmbCheckStatus.Text;

                    for (int i = 0; i < cellContents.Length - 1; i++)
                    {
                        if (i == 1 || i == 2 || i == 3)
                        {
                            if (cellContents[i] == "")
                            {
                                cellContents[i] = "0.0";
                            }

                        }
                        else
                        {
                            if (cellContents[i] == "")
                            {
                                cellContents[i] = "= Null";
                            }
                            else
                            {
                                cellContents[i] = $"= '{cellContents[i]}'";
                            }
                        }
                    }                 

                    //fix date field for update
                    double dblNet = Convert.ToDouble(cellContents[1]);
                    double dblGross = Convert.ToDouble(cellContents[2]);
                    double dblTithe = Convert.ToDouble(cellContents[3]);

                    string fixedDate = editExpense.convertExpenseDate(txtDate.Text);

                    DateTime dtOld = editExpense.ParseDate(rowContents[7]);    //for previous transaction date              
                    string oldTransID = dtOld.ToString("yyyy-MM-dd HH:mm:ss");          //for old transaction date

                    string newTransID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");   //for new transaction date

                    // (`Username`,`Description`,`Net`,`Gross`, `Tithe`, `TitheStatus`, `Date`, `PaycheckStatus`, `TransID`) " +
                    //$"Values ('{currentUser}', {cellContents[0]}, {dblNet}, {dblGross}, {dblTithe}, {cellContents[4]}, '{fixedDate}', {cellContents[6]}, '{transID}');"
                    string sql = $"UPDATE Income SET Description {cellContents[0]}, Net = {dblNet}, Gross = {dblGross}, Tithe = {dblTithe}, TitheStatus {cellContents[4]}, Date = '{fixedDate}', PaycheckStatus = '{cellContents[6]}', TransID = '{newTransID}' WHERE Username = '{currentUser}' AND transID = '{oldTransID}';";


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

    }

}




