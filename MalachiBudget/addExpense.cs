using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace MalachiBudget
{
    public partial class addExpense : Form
    {      
        //mainForm F = new mainForm();
        MySqlConnection conn;
        public string currentUser;

        public addExpense(MySqlConnection connection, string _currentUser)
        {
            InitializeComponent();
            conn = connection;
            currentUser = _currentUser;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void addExpense_Load(object sender, EventArgs e)
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
                loadCategoryComboBox();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCategoryComboBox()
        {
            List<string> categories = getCategories();
            foreach(string category in categories)
            {
                cmbCategory.Items.Add(category);
            }
        
        }

        public List<string> getCategories()
        {                  

            string sql = $"SELECT DISTINCT Category FROM Transactions WHERE Username = '{currentUser}';";
            List<string> results = new List<string>();

            try
            {
                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);
                MyDa.SelectCommand.CommandTimeout = 200;
                using (MySqlDataReader mySqlDataReader = MyDa.SelectCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        if (mySqlDataReader.IsDBNull("Category"))
                        {
                            //results.Add
                            //for now dont do anything
                        }
                        else
                        {
                            results.Add((string)mySqlDataReader["Category"]);
                        }


                    }
                }
                return results;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text == "  /  /")
                {
                    MessageBox.Show("Date field cannot be empty.", "Please enter a date for this submission", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn.Close();
                conn.Open();

                //load fields into an array
                string[] cellContents = new string[5];
                cellContents[0] = txtDesc.Text;
                cellContents[1] = txtAmt.Text;
                cellContents[2] = txtDate.Text;
                cellContents[3] = txtNotes.Text;
                cellContents[4] = cmbCategory.Text;
                //cellContents[5] = $"{DateTime.Now}";                

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

                double dblAmount = Convert.ToDouble(cellContents[1]);
                //INSERT INTO Transactions (`Username`,`TableName`,`Description`,`Amount`,`Due`, `Date`, `Notes`, `Category`, `Status`, `TransID`)
                // 0 = description
                // dblAmouunt = 1/amount
                // 2 = Date
                // 3 = notes
                // 4 = category                    
                string fixedDate = convertExpenseDate(txtDate.Text);
                string transID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string sql = $"INSERT INTO Transactions (`Username`,`TableName`,`Description`,`Amount`,`Due`, `Date`, `Notes`, `Category`, `Status`, `TransID`) " +
                    $"Values ('{currentUser}', 'expenses', {cellContents[0]}, {dblAmount}, NULL, '{fixedDate}', {cellContents[3]}, {cellContents[4]}, NULL, '{transID}');";

                MySqlCommand update = new MySqlCommand(@sql, conn);
                update.CommandTimeout = 200;
                update.ExecuteNonQuery();
                                                  

                DialogResult response = MessageBox.Show("Success! Add Another?", "Add another entry?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    txtAmt.Text = "";
                    //txtDate.Text = "";//DateTime.Now.ToString("MM/dd");
                    txtDesc.Text = "";
                    txtNotes.Text = "";
                    cmbCategory.Text = "";

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
    }

}
