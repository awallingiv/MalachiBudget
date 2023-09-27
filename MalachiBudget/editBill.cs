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
    public partial class editBill : Form
    {        
            public string[] rowContents;
            MySqlConnection conn;
            string currentUser;

            public editBill(MySqlConnection connection, string _currentUser)
            {
                InitializeComponent();
                this.conn = connection;
                this.currentUser = _currentUser;
            }

            private void editBill_Load(object sender, EventArgs e)
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
                    txtAmt.Text = rowContents[1];
                    txtDate.Text = rowContents[2];
                    txtNotes.Text = rowContents[3];
                    cmbStatus.Text = rowContents[4];
                    
                    loadStatusComboBox();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void loadStatusComboBox()
            {
                cmbStatus.Items.Add("PAID");
                cmbStatus.Items.Add("POSTED");
            }

            private void cmbSubmit_Click(object sender, EventArgs e)
            {

                try
                {
                    string tempDate = rowContents[5];


                    conn.Close();
                    conn.Open();

                    string[] cellContents = new string[5];
                    cellContents[0] = txtDesc.Text;
                    cellContents[1] = txtAmt.Text;
                    cellContents[2] = txtDate.Text;
                    cellContents[3] = txtNotes.Text;
                    cellContents[4] = cmbStatus.Text;

                    for (int i = 0; i < cellContents.Length - 1; i++)
                    {
                        if (i == 1)
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

                    double dblAmount = Convert.ToDouble(cellContents[1]);

                    // 0 = description
                    // dblAmouunt = 1/amount
                    // 2 = Date
                    // 3 = notes
                    // 4 = category                    

                    //fix date field for update
                    string fixedDate = editExpense.convertExpenseDate(txtDate.Text);

                    DateTime dtOld = editExpense.ParseDate(tempDate);    //for previous transaction date              
                    string oldTransID = dtOld.ToString("yyyy-MM-dd HH:mm:ss");          //for old transaction date

                    string newTransID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");   //for new transaction date

                    string sql = $"UPDATE Transactions SET Description {cellContents[0]}, Amount = {dblAmount}, Date = '{fixedDate}', Notes {cellContents[3]}, Status = '{cellContents[4]}', TransID = '{newTransID}' WHERE Username = '{currentUser}' AND Tablename = 'bills' AND transID = '{oldTransID}';";


                    //string sql = $"UPDATE bills set Description {cellContents[0]}, Amount = {Convert.ToDouble(cellContents[1])}, Due {cellContents[2]}, Notes {cellContents[3]}, Status {cellContents[4]} WHERE Description = '{rowContents[0]}';";


                    //old one: string sql = $"UPDATE bills set Description ='{txtDesc.Text}', Amount = {Convert.ToDouble(txtAmt.Text)}, Due = '{txtDate.Text}', Notes = '{txtNotes.Text}', Status = '{cmbStatus.Text}' WHERE Description = '{rowContents[0]}';";
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




