using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Bcpg;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Windows.Forms;
using MalachiBudget.Properties;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Transactions;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace MalachiBudget
{
    public partial class mainForm : Form
    {

        // example connection string thats ssl supposedly:
        // var connection =new MySqlConnection("Data Source=127.0.0.1;Database=MyDb1;User Id=root;Password=pwd;SSL Mode=Required");
        //
        //use wireshark to test:

        //      Prepare capture setup using this tutorial
        //      Start sniffing network with wireshark and perform some queries to your database
        //      Filter traffic by database IP-address and/or port using display filter, so irrelevant packets aren't shown
        //      Examine displayed packets.Compare them to sample of MySQL over TCP and to sample of MySQL over SSL.Hint: you can see queries as a plain text in unprotected connection, while SSL makes packet payload look like bunch of random garbage.

        //    //https://wiki.wireshark.org/CaptureSetup

        public MySqlConnection conn;
        public List<string> globalCategories = new List<string>();
        //public string currentDBString = "abc";

        List<Label> labels = new List<Label>();

        public string currentUser;
        public string tableBills = "bills";
        public string tableUtils = "utilities";
        public string tableIncome = "income";
        public string tableExpenses = "expenses";

        List<string> topTenCat = new List<string>();
        List<double> topTenVals = new List<double>();
               


        //Properties.Settings.Default["SomeProperty"] = "Some Value";
        //Properties.Settings.Default.Save(); // Saves settings in application configuration file
        public int theme; //0 = gray, 1 = black, 2 = white

        //pass username as constructor from login
        public mainForm(string _currentUser)
        {
            InitializeComponent();
            this.currentUser = _currentUser;
        }
        public void Main()
        {

            setConnection();

            checkSettings();

            loadDataGridViewProperties();

            fillComboboxes();  //fills years, which will trigger months                       
               
            //refreshEverything();       
                        

        }
        /// <summary>
        /// use this for populating combobox based on available data, but this fails if there is no data
        /// </summary>
        private void dynamicFillComboboxes()
        {
            string sql = "";

            try
            {
                //    if (conn.State != ConnectionState.Open)
                //    {
                //        conn.Close();
                //        conn.Open();
                //    }
                //    sql = $"SELECT Distinct Year(Date) as yr From Transactions WHERE Username = '{currentUser}' ORDER BY yr DESC;";

                //    MySqlDataAdapter MyDa = new MySqlDataAdapter();
                //    MyDa.SelectCommand = new MySqlCommand(sql, conn);

                //    using (MySqlDataReader mySqlDataReader = MyDa.SelectCommand.ExecuteReader())
                //    {
                //        while (mySqlDataReader.Read())
                //        {
                //            if (mySqlDataReader.IsDBNull("yr"))
                //            {
                //                //results.Add
                //                //for now dont do anything
                //            }
                //            else
                //            {
                //                cmbYear.Items.Add(Convert.ToString(mySqlDataReader["yr"]));
                //            }
                //        }
                //    }

                //sort combobox
                cmbYear.Sorted = true;

                ////set combobox item to most recently added
                //if (cmbYear.Items.Count > 0)
                //{
                //    //set to first item
                //    cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
                //}

                //If Year combobox is empty
                if (cmbYear.Items.Count == 0)
                {
                    //set it to current year
                    string year = DateTime.Now.ToString("yyyy");
                    cmbYear.Text = year;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillComboboxes()
        {
            string sql = "";
            string year = DateTime.Now.ToString("yyyy");
            try
            {
                cmbMonth.Items.Add("January");
                cmbMonth.Items.Add("February");
                cmbMonth.Items.Add("March");
                cmbMonth.Items.Add("April");
                cmbMonth.Items.Add("May");
                cmbMonth.Items.Add("June");
                cmbMonth.Items.Add("July");
                cmbMonth.Items.Add("August");
                cmbMonth.Items.Add("September");
                cmbMonth.Items.Add("October");
                cmbMonth.Items.Add("November");
                cmbMonth.Items.Add("December");

                cmbYear.Sorted = true;

                string savedYear = Settings.Default.cmbYearVal;
                //set year if it has been saved
                if (savedYear != "")
                {
                    if (cmbYear.Items.Contains(savedYear))
                    {

                        cmbYear.SelectedItem = savedYear;
                    }
                    else
                    {
                        cmbYear.Items.Add(savedYear);
                        cmbYear.SelectedItem = savedYear;
                    }
                    
                }
                else
                {
                    //If Year combobox is empty
                    if (cmbYear.Items.Count == 0)
                    {
                        //set it to current year
                        
                        cmbYear.Items.Add(year);
                        cmbYear.SelectedIndex = 0;
                    }
                    else
                    {
                        if (cmbYear.Items.Count > 0)
                        {
                            cmbYear.SelectedIndex = 0;
                        }
                    }
                }
                //if the combobox does not contain the current year
                if (!cmbYear.Items.Contains(year))
                {
                    cmbYear.Items.Add(year);
                    cmbYear.SelectedItem = year;
                }

                string savedMonth = Settings.Default.cmbMonthVal;
                //set month if it has been saved
                if (Settings.Default.cmbMonthVal != "")
                {
                    if (cmbMonth.Items.Contains(savedMonth))
                    {
                        cmbMonth.SelectedItem = savedMonth;
                    }
                    else
                    {                        
                        cmbMonth.SelectedItem = savedMonth;
                    }
                }

                //if no selection has been made 
                if (cmbMonth.Text == "Month")
                {
                    //set it to current year
                    string month = DateTime.Now.ToString("MM");
                    int mo = Convert.ToInt32(month);
                    //month = convertMonthIntToString(mo);
                    cmbMonth.SelectedIndex = mo - 1;
                }
                

                

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkSettings()
        {
            //theme settings
            theme = Settings.Default.Theme;
            switch(theme)
            {
                case 0: 
                    defaultMode();
                    break;
                case 1:
                    darkMode();
                    break;
                case 2:
                    lightMode();
                    break;
            }

            //month/year or DTP settings
            bool customMode = false;
            customMode = Settings.Default.CustomRange;
            if (customMode)
            {
                rbCustom.Checked = true;
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;

                cmbYear.Enabled = false;
                cmbMonth.Enabled = false;
                
            }
            else
            {
                rbMonthYear.Checked = true;
                cmbYear.Enabled = true;
                cmbMonth.Enabled = true;

                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
            //select actual date for DTP
            dtpFrom.Value = Settings.Default.dtpFromDef;
            dtpTo.Value = Settings.Default.dtpToDef;

            //tithe settings
            int tithe = Settings.Default.TithePercent;
            txtTithePercent.Text = $"{tithe}";

            

        }
                       

        public void setConnection()
        {

            string dummyIP = "wLXoGks0fnJ13lOJkoi6dK/9t0Jwtgup4Juso0kwqmURgF2Gt2bjP2vuuvp9V40IzH5jVNnCTpkvuMk22APy/mTMcUaMtZEZjTlDWFqNGLY4ma0u9jsWhzl6xM4D7H8g7he4jQ9SFGQ45Y3kmMLvMN3o9cKmiGfC0/+5T9IiL58=";                       //test ip
            string dummyUser = "Pr7YOaL0CvkNac0M/RRbBQ==";                                                                      //new user
            string dummyPass = "O6QletsAUBxItkkwyxhSR6NGMl/XxqYGoXt8Fy/2Z/F93LtwEWwsXDQ2tScEhlQGMc0LhPVyNHsLHfS+1GBJDQ==";      //new pass
            string dummyDB = "7sHyZY3Cb2oF5Q2OQhA+r6VO378tNwvgVZnbsTUKwoM=";                                                    //test db
            string dummyport = "x7HfjBiQi2H+KNqL/wVBiA==";

            //string dummyIP = "AfhcFBfTqRBMYUz8JmloPcu7pZl1INuRdBnp0POA7xo=";                                                    //prod ip
            //string dummyUser = "UkxjnjhyPG4yxA+iXul2gnf0/KQUfp16R7BZ2SrQO/uVlyJZpsTTfJLcVhXIkPkd";                              //prod user
            //string dummyPass = "AWpnZxmLTTtSaECOOhot/96jw9M0OLitxUIhVKzzR8E=";                                                  //prod pass
            //string dummyDB = "UkxjnjhyPG4yxA+iXul2glvh0dSzrYpQaRRgCl3rhzvo8/zgUBN14r+c7Jy7lFcAnzCqkkdeAxbfKiqs3R0kMg==";        //prod db

            //string dummyIP = "hQQFMngxXZmdl+l9WyaUL6CivWp59BmLj1+agBb52IU="                       //test ip
            //string dummyUser = "OGV0Cc+OgLf4ByaEB0x73A==";                                        //test user
            //string dummyPass = "AWpnZxmLTTtSaECOOhot/+M1PwAMZ03GYciLPJ7L0w4=";                    //test pass
            //string dummyDB = "wxoOY45U5SRS12V99EuYptDvoYd02LIo8m37bEuNODzgJV2J8++gqBeP0EAb5ehF";  //test db

            try
            {
                dummyUser = StringCypher.Decrypt(dummyUser);
                dummyPass = StringCypher.Decrypt(dummyPass);
                dummyIP = StringCypher.Decrypt(dummyIP);
                dummyDB = StringCypher.Decrypt(dummyDB);
                dummyport = StringCypher.Decrypt(dummyport);

                conn = new MySqlConnection($"server={dummyIP};user={dummyUser};database={dummyDB};port={dummyport};password={dummyPass};SSL Mode=Required");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        void loadDataGridViewProperties()
        {
            try
            {
                dgvIncome.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUtilities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvIncome.ReadOnly = true;
                //dgvBills.ReadOnly = true;
                dgvExpenses.ReadOnly = true;
                dgvUtilities.ReadOnly = true;
                dgvBills.AllowUserToAddRows = false;
                dgvIncome.AllowUserToAddRows = false;
                dgvExpenses.AllowUserToAddRows = false;
                dgvUtilities.AllowUserToAddRows = false;
                dgvIncome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvUtilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        public void refreshEverything()
        {
            //new columns for trans table:
            //Username, TableName, Description, Amount, Due, Date, Notes, Category, Status, TransID
            string dateFrom = "";
            string dateTo = "";
            DateTime dtFrom;
            DateTime dtTo;
            string sql = "";
            int yr = 0;
            int mo = 0; 


            try
            {
                //dont know why it would be blank rn, but lets error handle
                if (cmbYear.Text != "")
                {
                    yr = Convert.ToInt32(cmbYear.Text);

                }
                else
                {
                    string savedYear = Settings.Default.cmbYearVal;
                    //set year if it has been saved
                    if (savedYear != "")
                    {
                        if (cmbYear.Items.Contains(savedYear))
                        {
                            cmbYear.SelectedItem = savedYear;
                            yr = Convert.ToInt32(cmbYear.Text);
                        }
                        else
                        {
                            cmbYear.Items.Add(savedYear);
                            cmbYear.SelectedItem = savedYear;
                            yr = Convert.ToInt32(cmbYear.Text);
                        }

                    }                    
                }
                
                if (cmbMonth.Text != "")
                {
                    mo = convertMonthStringToInt(cmbMonth.Text);
                }
                else
                {
                    string savedMonth = Settings.Default.cmbMonthVal;
                    //set month if it has been saved
                    if (Settings.Default.cmbMonthVal != "")
                    {
                        if (cmbMonth.Items.Contains(savedMonth))
                        {
                            cmbMonth.SelectedItem = savedMonth;
                            mo = convertMonthStringToInt(cmbMonth.Text);
                        }
                        else
                        {
                            cmbMonth.Text = savedMonth;
                            mo = convertMonthStringToInt(cmbMonth.Text);
                        }
                    }
                }
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (rbMonthYear.Checked)
                {
                    //example format '2022-10-07 12:00:00'
                    //for month selection set from date to first day of selected month
                    dtFrom = new DateTime(yr, mo, 1, 00, 00, 00);   
                    //and set to date as last day of the selected month (and 23:59, respectively)
                    dtTo = new DateTime(dtFrom.Year, dtFrom.Month, DateTime.DaysInMonth(dtFrom.Year,dtFrom.Month), 23, 59, 59);
                    //convert to string and they are ready for the sql query
                    dateFrom = dtFrom.ToString("yyyy-MM-dd HH:mm:ss");
                    dateTo = dtTo.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    //get from date, create new object with time set to 0000 (12am midnight)
                    dtFrom = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 00, 00, 00);
                    //get to date, create new object with time set to 23:59:59
                    dtTo = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 23, 59, 59);
                    //convert to string and now they are ready for sql query
                    dateFrom = dtFrom.ToString("yyyy-MM-dd HH:mm:ss");                    
                    dateTo = dtTo.ToString("yyyy-MM-dd HH:mm:ss");
                }


                //load data into tables

                //load income
                string dateFormat = "'%m/%d/%y'";
                sql = $"SELECT Description, Net, Gross, Tithe, DATE_FORMAT(Date, {dateFormat}) AS Date, TitheStatus, PaycheckStatus, transID FROM Income WHERE Username = '{currentUser}' AND Date BETWEEN '{dateFrom}' AND '{dateTo}';";
                loadTable(dgvIncome, sql);
                dgvIncome.Columns["TransID"].Visible = false;
                //dgvIncome.Columns["PaycheckStatus"].Visible = false;
                //dgvIncome.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
                

                //load bills
                sql = $"SELECT Description, Amount, DATE_FORMAT(Due, {dateFormat}) AS Due, Notes, Status, TransID FROM Transactions WHERE Username = '{currentUser}' and TableName = '{tableBills}' AND Due BETWEEN '{dateFrom}' AND '{dateTo}';";
                loadTable(dgvBills, sql);
                dgvBills.Columns["TransID"].Visible = false;

                //load expenses
                sql = $"SELECT Description, Amount, DATE_FORMAT(Date, {dateFormat}) AS Date, Notes, Category, TransID FROM Transactions WHERE Username = '{currentUser}' AND TableName = '{tableExpenses}' AND Date BETWEEN '{dateFrom}' AND '{dateTo}' ORDER BY Date;";
                loadTable(dgvExpenses, sql);
                dgvExpenses.Columns["TransID"].Visible = false;                             //set transID column invisible

                //load utilities
                sql = $"SELECT Description, Amount, DATE_FORMAT(Due, {dateFormat}) AS Due, Notes, Status, TransID FROM Transactions WHERE Username = '{currentUser}' and TableName = '{tableUtils}' AND Due BETWEEN '{dateFrom}' AND '{dateTo}';";
                loadTable(dgvUtilities, sql);
                dgvUtilities.Columns["TransID"].Visible = false;
                
                
                //handles getting categories, loading into category tables
                refreshAndLoadCategories(dateFrom, dateTo);                             
                         
                //sets totals values on form for each table
                setTotals(dateFrom, dateTo);

                loadOverview(dateFrom, dateTo);

                //if (conn.State != ConnectionState.Closed)
                //{
                //    conn.Close();
                //}
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }

        private void setTotals(string dateFrom, string dateTo)
        {
            string sql;
            double result;

            try
            {


                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // SELECT SUM(Tithe) FROM Income WHERE Username = 'Austin234'AND TitheStatus = 'PAID' AND Date BETWEEN '2022-10-01 00:00:00' AND '2022-10-31 23:59:59'
                //OR Username = 'Austin234' AND TitheStatus = 'POSTED' AND Date BETWEEN '2022-10-01 00:00:00' AND '2022-10-31 23:59:59';

                //tithe                
                sql = $"SELECT SUM(Tithe) FROM Income WHERE Username = '{currentUser}' and TitheStatus = 'PAID' AND Date BETWEEN '{dateFrom}' AND '{dateTo}'" +
                    $"OR Username = '{currentUser}' and TitheStatus = 'POSTED' AND Date BETWEEN '{dateFrom}' AND '{dateTo}';";
                result = getDoubleFromTbl(sql);
                result = Math.Round(result, 2);
                lblTotalTitheVal.Text = Convert.ToString(result);

                //utilities
                sql = $"SELECT SUM(Amount) FROM Transactions WHERE Username = '{currentUser}' and TableName = '{tableUtils}' AND Due BETWEEN '{dateFrom}' AND '{dateTo}';";
                result = getDoubleFromTbl(sql);
                result = Math.Round(result, 2);
                lblTotalUtilVal.Text = Convert.ToString(result);

                //bills
                sql = $"SELECT SUM(Amount) FROM Transactions WHERE Username = '{currentUser}' and TableName = '{tableBills}' AND Due BETWEEN '{dateFrom}' AND '{dateTo}';";
                result = getDoubleFromTbl(sql);
                result = Math.Round(result, 2);
                lblTotalBillsVal.Text = Convert.ToString(result);

                //expenses
                sql = $"SELECT SUM(Amount) FROM Transactions WHERE Username = '{currentUser}' and TableName = '{tableExpenses}' AND Date BETWEEN '{dateFrom}' AND '{dateTo}';";
                result = getDoubleFromTbl(sql);
                result = Math.Round(result, 2);
                lblTotalExpensesVal.Text = Convert.ToString(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        } 

        private void refreshAndLoadCategories(string dateFrom, string dateTo)
        {   
            try
            {
                globalCategories = getCategories();
                
                //topTenCatNames = getTopTenCategories(dateFrom, dateTo);
                getTopTenCategories(dateFrom, dateTo);

                //create list to iterate through, so we can try/catch and resume next or even hide the label
                List<Label> labelCats = new List<Label>();
                List<Label> labelVals = new List<Label>();

                labelCats.Add(lblCat1);
                labelCats.Add(lblCat2);
                labelCats.Add(lblCat3);
                labelCats.Add(lblCat4);
                labelCats.Add(lblCat5);
                labelCats.Add(lblCat6);
                labelCats.Add(lblCat7);
                labelCats.Add(lblCat8);
                labelCats.Add(lblCat9);
                labelCats.Add(lblCat10);
                labelVals.Add(lblCat1Val);
                labelVals.Add(lblCat2Val);
                labelVals.Add(lblCat3Val);
                labelVals.Add(lblCat4Val);
                labelVals.Add(lblCat5Val);
                labelVals.Add(lblCat6Val);
                labelVals.Add(lblCat7Val);
                labelVals.Add(lblCat8Val);
                labelVals.Add(lblCat9Val);
                labelVals.Add(lblCat10Val);

                //basically for each label we will try to add the value to it, if it errors lets go to the next label
                //this should handle the case where < 10 categories exist
                int x = 0;
                    foreach (Label lbl in labelCats)
                    {
                        try
                        {
                            lbl.Text = topTenCat[x].ToString();                        
                        }
                        catch (Exception ex)
                        {
                            //Adding this catch instead of a blank catch resets category text
                            //(previously, it would still show the category name from whatever date range was successful (had category values) )
                            lbl.Text = $"Category #{x+1}";
                        }
                        x++;
                    }
                    //reset counter
                    x = 0;
                    foreach (Label lbl in labelVals)
                    {
                        try
                        {
                            lbl.Text = topTenVals[x].ToString();
                        }
                        catch (Exception ex)
                        {
                            //Adding this catch instead of a blank catch resets category value
                            //(previously, it would still show the category value from whatever date range was successful (had category values) )
                            lbl.Text = "$0";
                        }
                        x++;
                    }                                      
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
                

        private void getTopTenCategories(string dateFrom, string dateTo)
        {
            //using globals topTenCats and topTenVals
            topTenCat.Clear();
            topTenVals.Clear();
            double result;
            string sql = $"SELECT Category, sum(Amount) as Total FROM Transactions WHERE username = '{currentUser}' AND TableName = '{tableExpenses}' AND Date BETWEEN '{dateFrom}' AND '{dateTo}' GROUP BY Category ORDER BY Total DESC LIMIT 10;";
            try
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);
                MyDa.SelectCommand.CommandTimeout = 200;

                using (MySqlDataReader mySqlDataReader = MyDa.SelectCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        if (mySqlDataReader.IsDBNull("Category") || mySqlDataReader.IsDBNull("Total"))
                        {
                            //results.Add
                            //for now dont do anything
                        }
                        else
                        {
                            topTenCat.Add((string)mySqlDataReader["Category"]);
                            //need to round to two decimal places first
                            result = Math.Round((double)mySqlDataReader["Total"], 2);
                            topTenVals.Add(result);                            
                        }


                    }
                }

                //conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);                
            }
        }             

        double getDoubleFromTbl(string sql)
        {
            double result = 0;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);
                result = (double)MyDa.SelectCommand.ExecuteScalar();
                result = Math.Round(result);

                //conn.Close();
            }
            catch (Exception ex)
            {
                //return 0;
                //MessageBox.Show(ex.Message);
            }
            return result;
        }

        Int64 getInt64FromTbl(string sql)
        {
            Int64 result = 0;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);
                result = (Int64)MyDa.SelectCommand.ExecuteScalar();
                
                //conn.Open();
            }
            catch (Exception ex)
            {
                //return 0;
                //MessageBox.Show(ex.Message);
            }
            return result;
        }

        public List<string> getCategories()
        {
            globalCategories.Clear();
            string sql = $"SELECT DISTINCT Category FROM Transactions WHERE Username = '{currentUser}';";
            List<string> results = new List<string>();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

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

                //conn.Close();
            }

            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);                
                return null;
            }
        }

        public List<string> getStatuses()
        {
            string sql = "SELECT DISTINCT status FROM income";

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);

                MyDa.SelectCommand.CommandTimeout = 200;
                List<string> results = new List<string>();
                using (MySqlDataReader mySqlDataReader = MyDa.SelectCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        if (mySqlDataReader.IsDBNull("Status"))
                        {
                            //results.Add
                            //for now dont do anything
                        }
                        else
                        {
                            results.Add((string)mySqlDataReader["Status"]);
                        }


                    }
                }
                return results;
                //conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            
            this.Text += $" - Logged in as {currentUser}";

            //my attempt to help with scaling different resolutions
            float width_ratio = (Screen.PrimaryScreen.Bounds.Width / 1920);
            float heigh_ratio = (Screen.PrimaryScreen.Bounds.Height / 1080f);

            SizeF scale = new SizeF(width_ratio, heigh_ratio);

            this.Scale(scale);

            ////And for font size
            //foreach (Control control in this.Controls)
            //{
            //    control.Font = new Font("Microsoft Sans Serif", c.Font.SizeInPoints * heigh_ratio * width_ratio);
            //}
            Main();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void loadTable(DataGridView dgv, string sql)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandTimeout = 200;
                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                MyDA.SelectCommand = new MySqlCommand(sql, conn);

                DataTable table = new DataTable();
                MyDA.Fill(table);

                BindingSource bsource = new BindingSource();
                bsource.DataSource = table;

                dgv.DataSource = bsource;

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }

        private void loadOverview(string dateFrom, string dateTo)
        {            

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                double totalExpenses = Convert.ToDouble(lblTotalExpensesVal.Text);
                double totalBills = Convert.ToDouble(lblTotalBillsVal.Text);
                double totalUtilities = Convert.ToDouble(lblTotalUtilVal.Text);
                double totalTithe = Convert.ToDouble(lblTotalTitheVal.Text);
                string sql = $"SELECT SUM(Net) as Total FROM Income WHERE Username = '{currentUser}' AND Date BETWEEN '{dateFrom}' AND '{dateTo}'";
                double totalIncome = getDoubleFromTbl(sql);
                totalIncome = Math.Round(totalIncome, 2);

                double totalOut = totalExpenses + totalBills + totalUtilities + totalTithe;
                double totalLeft = totalIncome - totalOut;

                lblInValue.Text = Convert.ToString(totalIncome);
                lblOutValue.Text = Convert.ToString(totalOut);
                lblLeftValue.Text = Convert.ToString(totalLeft);

                //conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void cmdAddExpense_Click(object sender, EventArgs e)
        {
            try
            {
                addExpense expenseForm = new addExpense(conn, currentUser);
                expenseForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        void darkMode()
        {
            try
            {
                this.BackColor = Color.Black;

                dgvIncome.BackgroundColor = Color.Black;
                dgvIncome.ForeColor = Color.Black;
                dgvIncome.GridColor = Color.White;
                dgvIncome.DefaultCellStyle.BackColor = Color.Black;
                dgvIncome.DefaultCellStyle.ForeColor = Color.White;
                dgvIncome.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvIncome.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvIncome.RowHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvIncome.RowHeadersDefaultCellStyle.ForeColor = Color.White;

                dgvUtilities.BackgroundColor = Color.Black;
                dgvUtilities.ForeColor = Color.Black;
                dgvUtilities.GridColor = Color.White;
                dgvUtilities.DefaultCellStyle.BackColor = Color.Black;
                dgvUtilities.DefaultCellStyle.ForeColor = Color.White;
                dgvUtilities.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvUtilities.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvUtilities.RowHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvUtilities.RowHeadersDefaultCellStyle.ForeColor = Color.White;

                dgvBills.BackgroundColor = Color.Black;
                dgvBills.ForeColor = Color.Black;
                dgvBills.GridColor = Color.White;
                dgvBills.DefaultCellStyle.BackColor = Color.Black;
                dgvBills.DefaultCellStyle.ForeColor = Color.White;
                dgvBills.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvBills.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBills.RowHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvBills.RowHeadersDefaultCellStyle.ForeColor = Color.White;

                dgvExpenses.BackgroundColor = Color.Black;
                dgvExpenses.ForeColor = Color.Black;
                dgvExpenses.GridColor = Color.White;
                dgvExpenses.DefaultCellStyle.BackColor = Color.Black;
                dgvExpenses.DefaultCellStyle.ForeColor = Color.White;
                dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvExpenses.RowHeadersDefaultCellStyle.BackColor = Color.Black;
                dgvExpenses.RowHeadersDefaultCellStyle.ForeColor = Color.White;

                lblTotalExpenses.ForeColor = Color.White;
                lblTotalBills.ForeColor = Color.White;
                lblTotalTithe.ForeColor = Color.White;
                lblTotalUtil.ForeColor = Color.White;

                lblTopTen.ForeColor = Color.White;
                lblCat1.ForeColor = Color.White;
                lblCat2.ForeColor = Color.White;
                lblCat3.ForeColor = Color.White;
                lblCat4.ForeColor = Color.White;
                lblCat5.ForeColor = Color.White;
                lblCat6.ForeColor = Color.White;
                lblCat7.ForeColor = Color.White;
                lblCat8.ForeColor = Color.White;
                lblCat9.ForeColor = Color.White;
                lblCat10.ForeColor = Color.White;

                foreach (Label item in labels)
                {
                    item.ForeColor = Color.White;
                }

                lblTotalIn.ForeColor = Color.White;
                lblTotalOut.ForeColor = Color.White;
                lblLeftover.ForeColor = Color.White;

                lblBills.ForeColor = Color.White;
                lblExpenses.ForeColor = Color.White;
                lblIncome.ForeColor = Color.White;
                lblUtilities.ForeColor = Color.White;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        void lightMode()
        {
            try
            {
                this.BackColor = SystemColors.Control;

                dgvIncome.BackgroundColor = SystemColors.Control;
                dgvIncome.ForeColor = SystemColors.Control;
                dgvIncome.GridColor = Color.Black;
                dgvIncome.DefaultCellStyle.BackColor = SystemColors.Control;
                dgvIncome.DefaultCellStyle.ForeColor = Color.Black;
                dgvIncome.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvIncome.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvIncome.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvIncome.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgvUtilities.BackgroundColor = SystemColors.Control;
                dgvUtilities.ForeColor = SystemColors.Control;
                dgvUtilities.GridColor = Color.Black;
                dgvUtilities.DefaultCellStyle.BackColor = SystemColors.Control;
                dgvUtilities.DefaultCellStyle.ForeColor = Color.Black;
                dgvUtilities.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvUtilities.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvUtilities.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvUtilities.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgvBills.BackgroundColor = SystemColors.Control;
                dgvBills.ForeColor = SystemColors.Control;
                dgvBills.GridColor = Color.Black;
                dgvBills.DefaultCellStyle.BackColor = SystemColors.Control;
                dgvBills.DefaultCellStyle.ForeColor = Color.Black;
                dgvBills.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvBills.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvBills.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvBills.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgvExpenses.BackgroundColor = SystemColors.Control;
                dgvExpenses.ForeColor = SystemColors.Control;
                dgvExpenses.GridColor = Color.Black;
                dgvExpenses.DefaultCellStyle.BackColor = SystemColors.Control;
                dgvExpenses.DefaultCellStyle.ForeColor = Color.Black;
                dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvExpenses.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                dgvExpenses.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                lblTotalExpenses.ForeColor = Color.Black;
                lblTotalBills.ForeColor = Color.Black;
                lblTotalTithe.ForeColor = Color.Black;
                lblTotalUtil.ForeColor = Color.Black;

                lblTopTen.ForeColor = Color.Black;
                lblCat1.ForeColor = Color.Black;
                lblCat2.ForeColor = Color.Black;
                lblCat3.ForeColor = Color.Black;
                lblCat4.ForeColor = Color.Black;
                lblCat5.ForeColor = Color.Black;
                lblCat6.ForeColor = Color.Black;
                lblCat7.ForeColor = Color.Black;
                lblCat8.ForeColor = Color.Black;
                lblCat9.ForeColor = Color.Black;
                lblCat10.ForeColor = Color.Black;

                foreach (Label item in labels)
                {
                    item.ForeColor = Color.Black;
                }
                lblTotalIn.ForeColor = Color.Black;
                lblTotalOut.ForeColor = Color.Black;
                lblLeftover.ForeColor = Color.Black;

                lblBills.ForeColor = Color.Black;
                lblExpenses.ForeColor = Color.Black;
                lblIncome.ForeColor = Color.Black;
                lblUtilities.ForeColor = Color.Black;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        void defaultMode()
        {
            try
            {
                this.BackColor = SystemColors.ControlDarkDark;

                dgvIncome.BackgroundColor = SystemColors.ControlDarkDark;
                dgvIncome.ForeColor = SystemColors.ControlDarkDark;
                dgvIncome.GridColor = Color.Black;
                dgvIncome.DefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvIncome.DefaultCellStyle.ForeColor = Color.Black;
                dgvIncome.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvIncome.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvIncome.RowHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvIncome.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgvUtilities.BackgroundColor = SystemColors.ControlDarkDark;
                dgvUtilities.ForeColor = SystemColors.ControlDarkDark;
                dgvUtilities.GridColor = Color.Black;
                dgvUtilities.DefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvUtilities.DefaultCellStyle.ForeColor = Color.Black;
                dgvUtilities.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvUtilities.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvUtilities.RowHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvUtilities.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgvBills.BackgroundColor = SystemColors.ControlDarkDark;
                dgvBills.ForeColor = SystemColors.ControlDarkDark;
                dgvBills.GridColor = Color.Black;
                dgvBills.DefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvBills.DefaultCellStyle.ForeColor = Color.Black;
                dgvBills.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvBills.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvBills.RowHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvBills.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                dgvExpenses.BackgroundColor = SystemColors.ControlDarkDark;
                dgvExpenses.ForeColor = SystemColors.ControlDarkDark;
                dgvExpenses.GridColor = Color.Black;
                dgvExpenses.DefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvExpenses.DefaultCellStyle.ForeColor = Color.Black;
                dgvExpenses.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvExpenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvExpenses.RowHeadersDefaultCellStyle.BackColor = SystemColors.ControlDarkDark;
                dgvExpenses.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

                lblTotalExpenses.ForeColor = Color.Black;
                lblTotalBills.ForeColor = Color.Black;
                lblTotalTithe.ForeColor = Color.Black;
                lblTotalUtil.ForeColor = Color.Black;

                lblTopTen.ForeColor = Color.Black;
                lblCat1.ForeColor = Color.Black;
                lblCat2.ForeColor = Color.Black;
                lblCat3.ForeColor = Color.Black;
                lblCat4.ForeColor = Color.Black;
                lblCat5.ForeColor = Color.Black;
                lblCat6.ForeColor = Color.Black;
                lblCat7.ForeColor = Color.Black;
                lblCat8.ForeColor = Color.Black;
                lblCat9.ForeColor = Color.Black;
                lblCat10.ForeColor = Color.Black;

                foreach (Label item in labels)
                {
                    item.ForeColor = Color.Black;
                }
                lblTotalIn.ForeColor = Color.Black;
                lblTotalOut.ForeColor = Color.Black;
                lblLeftover.ForeColor = Color.Black;

                lblBills.ForeColor = Color.Black;
                lblExpenses.ForeColor = Color.Black;
                lblIncome.ForeColor = Color.Black;
                lblUtilities.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDeleteExpense_Click(object sender, EventArgs e)
        {
            try
            {

                int index = 0;
                try
                {
                    index = dgvExpenses.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                DataGridViewRow row = dgvExpenses.Rows[index];
                string[] cellContents = new string[row.Cells.Count];
                string sql;

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //fill string array with contents of chosen row's cells
                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }

                //for each ele of the array if blank, and not the 2nd element (double Amount) then change value to NULL
                for (int x = 0; x < cellContents.Length - 1; x++)
                {
                    if (cellContents[x] == "")
                    {
                        if (x == 1)
                        {
                            cellContents[x] = "0.0";
                        }
                        else
                        {
                            cellContents[x] = "NULL";
                        }
                    }
                }
                
                DateTime fixedTransDT = DateTime.Parse(cellContents[5]);
                string fixedTransID = fixedTransDT.ToString("yyyy-MM-dd HH:mm:ss");
                sql = $"DELETE FROM Transactions WHERE Username = '{currentUser}' AND TableName = 'expenses' AND TransID = '{fixedTransID}'";
                DialogResult result = MessageBox.Show($"Are you sure you want to delete this row:\r\nDescription = '{cellContents[0]}'\r\nAmount = {cellContents[1]}\r\nDate = '{cellContents[2]}'\r\nNotes = '{cellContents[3]}'\r\nCategory = '{cellContents[4]}'", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();
                    refreshEverything();
                }
                else
                {
                    MessageBox.Show("Operation Cancelled");
                    conn.Close();
                }
                //conn.Close();
                //dgvMonthlySpending.Rows.RemoveAt(index); shouoldnt actually need this because were going to delete from the DB and then refresh the DB
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void fixDates()
        {

            try
            {
                //string[] wrongDates = new string[10];
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }


                for (int x = 1; x < 9; x++)
                {

                    string wrongDate = $"7/{x}";
                    string fixedDate = $"07/0{x}";
                    string sql = $"UPDATE expenses SET DATE = '{fixedDate}' where DATE = '{wrongDate}'";
                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();

                }
                for (int x = 10; x < 31; x++)
                {

                    string wrongDate = $"7/{x}";
                    string fixedDate = $"07/0{x}";
                    string sql = $"UPDATE expenses SET DATE = '{fixedDate}' where DATE = '{wrongDate}'";
                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();

                }
                //conn.Close();
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }


        private void cmdDeleteIncome_Click(object sender, EventArgs e)
        {

            try
            {
                int index = 0;
                try
                {
                    index = dgvIncome.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                DataGridViewRow row = dgvIncome.Rows[index];
                string[] cellContents = new string[row.Cells.Count];
                string sql;
                string tempDate;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }

                ////preserve date
                tempDate = cellContents[7];

                for (int x = 0; x < cellContents.Length - 1; x++)
                {
                    if (cellContents[x] == "")
                    {
                        if (x == 1 || x == 2 || x == 3)
                        {
                            cellContents[x] = "0.0";
                        }
                        else
                        {
                            cellContents[x] = "NULL";
                        }
                    }
                }

                DateTime fixedTransDT = DateTime.Parse(tempDate);
                string fixedTransID = fixedTransDT.ToString("yyyy-MM-dd HH:mm:ss");


                //if it is null, change value to is NULL
                //if (cellContents[4] == "= ''")
                //{
                //    cellContents[4] = "is NULL";
                //}
                //for (int x = 0; x < 5; x++)
                //{
                //    if (x == 1 || x == 2 || x == 3)
                //    {
                //        if (cellContents[x] == "")
                //        {
                //            cellContents[x] = "0.00";
                //        }
                //    }
                //    else
                //    {
                //        if (cellContents[x] == "")
                //        {
                //            cellContents[x] = "is Null";
                //        }
                //        else
                //        {
                //            cellContents[x] = $"= '{cellContents[x]}'";
                //        }
                //    }
                //}



                //   sql = $"DELETE FROM income where Description {cellContents[0]}";
                sql = $"DELETE FROM Income WHERE Username = '{currentUser}' AND TransID = '{fixedTransID}'";
                DialogResult result = MessageBox.Show($"Are you sure you want to delete this row:\r\nDescription = '{cellContents[0]}'\r\nNet = {cellContents[1]}\r\nGross = {cellContents[2]}\r\nTithe = {cellContents[3]}\r\nDate = '{cellContents[4]}'\r\nTitheStatus = '{cellContents[5]}'\r\n'CheckStatus = '{cellContents[6]}'", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();
                    refreshEverything();
                }
                else
                {
                    MessageBox.Show("Operation Cancelled");
                    conn.Close();
                }
                //conn.Close();
                //dgvMonthlySpending.Rows.RemoveAt(index); shouoldnt actually need this because were going to delete from the DB and then refresh the DB
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdAddIncome_Click(object sender, EventArgs e)
        {
            string amt = txtTithePercent.Text;
            try
            {
                addIncome incomeForm = new addIncome(conn, amt, currentUser);
                incomeForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                addBill billForm = new addBill(conn, currentUser);
                billForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdDeleteBill_Click_1(object sender, EventArgs e)
        {

            try
            {
                int index = 0;
                try
                {
                    index = dgvBills.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                DataGridViewRow row = dgvBills.Rows[index];
                string[] cellContents = new string[row.Cells.Count];
                string sql;
                string tempDate;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }
                
                //preserve date
                tempDate = cellContents[5];

                for (int x = 0; x < 5; x++)
                {
                    if (cellContents[x] == "")
                    {
                        if (x == 1)
                        {
                            cellContents[x] = "0.0";
                        }
                        else
                        {
                            cellContents[x] = "NULL";
                        }
                    }
                }

                DateTime fixedTransDT = DateTime.Parse(tempDate);
                string fixedTransID = fixedTransDT.ToString("yyyy-MM-dd HH:mm:ss");


                sql = $"DELETE FROM Transactions WHERE Username = '{currentUser}' AND TableName = 'bills' AND TransID = '{fixedTransID}'";
                DialogResult result = MessageBox.Show($"Are you sure you want to delete this row:\r\n Description = '{cellContents[0]}'\r\n Amount = {cellContents[1]}\r\n Due Date = '{cellContents[2]}'\r\n Notes = '{cellContents[3]}'\r\n Status = '{cellContents[4]}'", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();
                    refreshEverything();
                }
                else
                {
                    MessageBox.Show("Operation Cancelled");
                    conn.Close();
                }
                //conn.Close();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        public static int convertMonthStringToInt(string month)
        {
            int result = 0;

            switch (month)
            {
                case "January":
                    result = 1;
                    break;

                case "February":
                    result = 2;
                    break;

                case "March":
                    result = 3;
                    break;

                case "April":
                    result = 4;
                    break;

                case "May":
                    result = 5;
                    break;

                case "June":
                    result = 6;
                    break;

                case "July":
                    result = 7;
                    break;

                case "August":
                    result = 8;
                    break;

                case "September":
                    result = 9;
                    break;

                case "October":
                    result = 10;
                    break;

                case "November":
                    result = 11;
                    break;

                case "December":
                    result = 12;
                    break;

            }

            return result;
        }

        public static string convertMonthIntToString(int month)
        {
            string result = "";

            switch (month)
            {
                case 1:
                    result = "January";
                    break;

                case 2:
                    result = "February";
                    break;

                case 3:
                    result = "March";
                    break;

                case 4:
                    result = "April";
                    break;

                case 5:
                    result = "May";
                    break;

                case 6:
                    result = "June";
                    break;

                case 7:
                    result = "July";
                    break;

                case 8:
                    result = "August";
                    break;

                case 9:
                    result = "September";
                    break;

                case 10:
                    result = "October";
                    break;

                case 11:
                    result = "November";
                    break;

                case 12:
                    result = "December";
                    break;

            }

            return result;
        }

        private void exportToFile(string filename)
        {

            string file = filename;

            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            try
            {
                using (conn)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            //conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }
        private void addTransID()
        {

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                //string sql = $"UPDATE monthlyspending SET transID = '{DateTime.Now}' where transID is NULL";
                List<List<string>> rows = getTransIDs();

                for (int i = 0; i < rows.Count; i++)
                {
                    List<string> row = rows[i];
                    row[5] = Convert.ToString(DateTime.Now);
                    Thread.Sleep(1000);
                    //string sql = $"UPDATE monthlyspending SET transID = ";
                }

                //MySqlCommand update = new MySqlCommand(@sql, conn);
                //update.ExecuteNonQuery();


                //conn.Close();
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }

        public List<List<string>> getTransIDs()
        {


            string sql = "SELECT *  FROM expenses where transID is NULL";

            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);

                List<List<string>> rows = new List<List<string>>();
                MyDa.SelectCommand.CommandTimeout = 200;

                using (MySqlDataReader mySqlDataReader = MyDa.SelectCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        //rowzData newRow = new rowzData();
                        //rowzData.Description = (string)mySqlDataReader["Description"];
                        List<string> element = new List<string>();
                        element.Add(Convert.ToString(mySqlDataReader["Description"]));
                        element.Add(Convert.ToString(mySqlDataReader["Amount"]));
                        element.Add(Convert.ToString(mySqlDataReader["Date"]));
                        element.Add(Convert.ToString(mySqlDataReader["Notes"]));
                        element.Add(Convert.ToString(mySqlDataReader["Category"]));
                        element.Add(Convert.ToString(mySqlDataReader["transID"]));
                        rows.Add(element);

                    }
                }
                return rows;

                //conn.Close();
            }

            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        private void resetCategoryLabels()
        {
            lblCat1Val.Text = "0";
            lblCat2Val.Text = "0";
            lblCat3Val.Text = "0";
            lblCat4Val.Text = "0";
            lblCat5Val.Text = "0";
            lblCat6Val.Text = "0";
            lblCat7Val.Text = "0";
            lblCat8Val.Text = "0";
            lblCat9Val.Text = "0";
            lblCat10Val.Text = "0";
            lblCat1.Text = "1. Category";
            lblCat2.Text = "2. Category";
            lblCat3.Text = "3. Category";
            lblCat4.Text = "4. Category";
            lblCat5.Text = "5. Category";
            lblCat6.Text = "6. Category";
            lblCat7.Text = "7. Category";
            lblCat8.Text = "8. Category";
            lblCat9.Text = "9. Category";
            lblCat10.Text = "10. Category";
        }
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //used to set the database but now were just going to do that in main after we set year
            Settings.Default.cmbMonthVal = cmbMonth.Text;
            Settings.Default.Save();
            refreshEverything();
        }
        
        private void cmdEditExpense_Click(object sender, EventArgs e)
        {

            try
            {
                int index = 0;
                try
                {
                    index = dgvExpenses.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                
                DataGridViewRow row = dgvExpenses.Rows[index];
                string[] cellContents = new string[row.Cells.Count];
                string sql;

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }

                editExpense editExpenseForm = new editExpense(conn, currentUser);
                editExpenseForm.rowContents = cellContents;
                editExpenseForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbEditBill_Click(object sender, EventArgs e)
        {

            try
            {
                int index = 0;
                try
                {
                    index = dgvBills.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                
                DataGridViewRow row = dgvBills.Rows[index];
                string[] cellContents = new string[row.Cells.Count];


                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }

                editBill editBillForm = new editBill(conn, currentUser);
                editBillForm.rowContents = cellContents;
                editBillForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }        

        private void addToVDData(string month, string year)
        {
            try
            {
                //set connection:
                //setConnection("validdata", true);
                // 20221006 commenting out to make it work for now testing something else
                setConnection();

                //test connection
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //create string
                string sql = $"INSERT INTO vd{year} Values('{month}');";

                //add month to year table
                MySqlCommand update = new MySqlCommand(@sql, conn);
                update.CommandTimeout = 200;
                update.ExecuteNonQuery();

                //set connection back to what it was
                string monthAndYear = $"{cmbMonth.Text}{cmbYear.Text}";
                //setConnection(monthAndYear);
                // 20221006 commenting out to make it work for now testing something else
                setConnection();

                //conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        
        private void cmdEditIncome_Click(object sender, EventArgs e)
        {

            try
            {
                int index = 0;
                try
                {
                    index = dgvIncome.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                
                DataGridViewRow row = dgvIncome.Rows[index];
                string[] cellContents = new string[row.Cells.Count];

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }

                editIncome editIncomeForm = new editIncome(conn, currentUser);
                editIncomeForm.rowContents = cellContents;
                editIncomeForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdAddUtility_Click(object sender, EventArgs e)
        {
            try
            {
                addUtility utilityForm = new addUtility(conn, currentUser);
                utilityForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDeleteUtility_Click(object sender, EventArgs e)
        {

            try
            {
                int index = 0;
                try
                {
                    index = dgvUtilities.CurrentCell.RowIndex;
                }
                catch (Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                DataGridViewRow row = dgvUtilities.Rows[index];
                string[] cellContents = new string[row.Cells.Count];
                string sql;
                string tempDate;

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }


                //set cell contents[4] to have its own quotes in case it is null
                //cellContents[4] = $"= '{cellContents[4]}'";
                ////if it is null, change value to is NULL
                //if (cellContents[4] == "= ''")
                //{
                //    cellContents[4] = "is NULL";
                //}
                //for (int x = 0; x < cellContents.Length; x++)
                //{
                //    if (x == 1)
                //    {
                //        cellContents[x] = $"= {cellContents[x]}";
                //    }
                //    else
                //    {
                //        cellContents[x] = $"= '{cellContents[x]}'";
                //    }

                //    //for text
                //    //if it is null, change value to is NULL
                //    if (cellContents[x] == "= ''")
                //    {
                //        cellContents[x] = "is NULL";
                //    }


                //}
                //preserve date
                tempDate = cellContents[5];

                for (int x = 0; x < 5; x++)
                {
                    if (cellContents[x] == "")
                    {
                        if (x == 1)
                        {
                            cellContents[x] = "0.0";
                        }
                        else
                        {
                            cellContents[x] = "NULL";
                        }
                    }
                }

                DateTime fixedTransDT = DateTime.Parse(tempDate);
                string fixedTransID = fixedTransDT.ToString("yyyy-MM-dd HH:mm:ss");

                
                sql = $"DELETE FROM Transactions WHERE Username = '{currentUser}' AND TableName = 'utilities' AND TransID = '{fixedTransID}'";
                DialogResult result = MessageBox.Show($"Are you sure you want to delete this row:\r\n Description = '{cellContents[0]}'\r\nAmount = {cellContents[1]}\r\nDue Date = '{cellContents[2]}'\r\nNotes = '{cellContents[3]}'\r\nStatus = '{cellContents[4]}'", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand update = new MySqlCommand(@sql, conn);
                    update.CommandTimeout = 200;
                    update.ExecuteNonQuery();
                    refreshEverything();
                }
                else
                {
                    MessageBox.Show("Operation Cancelled");
                    conn.Close();
                }
                //conn.Close();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdEditUtility_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                try
                {
                    index = dgvUtilities.CurrentCell.RowIndex;
                }
                catch(Exception nullEx)
                {
                    MessageBox.Show("Must select a valid line to edit");
                    return;
                }
                DataGridViewRow row = dgvUtilities.Rows[index];
                string[] cellContents = new string[row.Cells.Count];


                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int x = 0; x < row.Cells.Count; x++)
                {
                    DataGridViewCell cell = row.Cells[x];
                    cellContents[x] = cell.Value.ToString();
                }

                editUtility editUtilityForm = new editUtility(conn, currentUser);
                editUtilityForm.rowContents = cellContents;
                editUtilityForm.ShowDialog();
                refreshEverything();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSetTithe_Click_1(object sender, EventArgs e)
        {

            DialogResult dResult;
            string temp = txtTithePercent.Text.Replace("%", "");
            temp = temp.Insert(0, ".");
            double tithePercent = Convert.ToDouble(temp);
            double result;
            string sql;


            try
            {
                dResult = MessageBox.Show("This is used to update all tithe fields. This is irreversible. Continue?", "Adjust all tithe?", MessageBoxButtons.YesNo);
                if (dResult == DialogResult.Yes)
                {
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Open();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //(hopefully) load all the contents of the dgv into a temporary array and then use that to
                    //make updates to sql table
                    foreach (DataGridViewRow row in dgvIncome.Rows)
                    {
                        string[] cellContents = new string[row.Cells.Count];

                        for (int x = 0; x < row.Cells.Count; x++)
                        {
                            DataGridViewCell cell = row.Cells[x];
                            cellContents[x] = cell.Value.ToString();
                        }
                        //now cellContents should be full, lets do some operations
                        //sql = $"SELECT Gross from income where Description = '{cellContents[0]}'";
                        //result = getDoubleFromTbl(sql);
                        //were just using the cellContents but comment this out and uncomment above ^ to use sql data (result should be the same but this way we do one less query)
                        result = Convert.ToDouble(cellContents[2]);
                        result = result * tithePercent;
                        result = Math.Round(result, 2);
                        //we got the juice, now lets set it in the Tithe Column
                        sql = $"UPDATE income SET Tithe = {result} WHERE Description = '{cellContents[0]}'";
                        MySqlCommand update = new MySqlCommand(@sql, conn);
                        update.CommandTimeout = 200;
                        update.ExecuteNonQuery();

                    }
                    //conn.Close();
                    refreshEverything();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                conn.Close();                
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        private void exportAllDBs()
        {
            string filename;
            string tempPath = Path.GetTempPath();

            //string filename = $"{tempPath}July2022.sql";
            ////setConnection("July2022");
            //// 20221006 commenting out to make it work for now testing something else
            //setConnection();
            //exportToFile(filename);

            //filename = $"{tempPath}August2022.sql";
            ////setConnection("August2022");
            //// 20221006 commenting out to make it work for now testing something else
            //setConnection();
            //exportToFile(filename);

            //filename = $"{tempPath}September2022.sql";
            ////setConnection("September2022");
            //// 20221006 commenting out to make it work for now testing something else
            //setConnection();
            //exportToFile(filename);

            //filename = $"{tempPath}October2022.sql";
            ////setConnection("September2022");
            //// 20221006 commenting out to make it work for now testing something else
            //setConnection();
            //exportToFile(filename);

            //filename = $"{tempPath}validdata.sql";
            ////setConnection("validdata");
            //// 20221006 commenting out to make it work for now testing something else
            //setConnection();
            //exportToFile(filename);

            filename = $"{tempPath}MalachiBudgetCom.sql";
            exportToFile(filename);
        }
      
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();

        }
        private void grayModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings.Default.Theme = 0;
            Settings.Default.Save();
            defaultMode();
        }
        private void darkModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {            

            Settings.Default.Theme = 1;
            Settings.Default.Save();
            darkMode();
        }
        
        private void lightModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings.Default.Theme = 2;
            Settings.Default.Save();
            lightMode();
        }        

        private void exportAllDBsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            exportAllDBs();
        }

        private void fixDatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fixDates();
        }

        private void fixTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTransID();
        }

        private void cmdRefresh_Click_1(object sender, EventArgs e)
        {
            refreshEverything();
        }


        private void rbMonthYear_CheckedChanged(object sender, EventArgs e)
        {
            //if checked, set customrange to true, else set it to false
            //if (rbCustom.Checked) Settings.Default.CustomRange = true; else Settings.Default.CustomRange = false;   //one line if else was nice but need other stuff done

            if (rbCustom.Checked)
            {
                Settings.Default.CustomRange = true;
                Settings.Default.Save();
                cmbYear.Enabled = false;
                cmbMonth.Enabled = false;

                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                Settings.Default.CustomRange = false;
                Settings.Default.Save();

                cmbYear.Enabled = true;
                cmbMonth.Enabled = true;

                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustom.Checked)
            {
                Settings.Default.CustomRange = true;
                Settings.Default.Save();
                cmbYear.Enabled = false;
                cmbMonth.Enabled = false;

                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                Settings.Default.CustomRange = false;
                Settings.Default.Save();
                cmbYear.Enabled = true;
                cmbMonth.Enabled = true;

                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void txtTithePercent_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.TithePercent = Convert.ToInt32(txtTithePercent.Text);
            Settings.Default.Save();
        }

        private void cmbYear_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (cmbYear.Text != "")
            {
                Settings.Default.cmbYearVal = cmbYear.Text;
                Settings.Default.Save();
            }
            
            //string sql = "";
            //string strTemp;
            //int intTemp;
            //string strMonth;
            //int intMonth;

            //try
            //{
            //    if (conn.State != ConnectionState.Open)
            //    {
            //        conn.Close();
            //        conn.Open();
            //    }
            //    sql = $"SELECT Distinct Month(Date) as mo From Transactions WHERE Username = '{currentUser}' ORDER BY mo ASC;";

            //    MySqlDataAdapter MyDa = new MySqlDataAdapter();
            //    MyDa.SelectCommand = new MySqlCommand(sql, conn);

            //    using (MySqlDataReader mySqlDataReader = MyDa.SelectCommand.ExecuteReader())
            //    {
            //        while (mySqlDataReader.Read())
            //        {
            //            if (mySqlDataReader.IsDBNull("mo"))
            //            {
            //                //results.Add
            //                //for now dont do anything
            //            }
            //            else
            //            {
            //                intTemp = Convert.ToInt32(mySqlDataReader["mo"]);
            //                strMonth = convertMonthIntToString(intTemp);
            //                cmbMonth.Items.Add(strMonth);
            //            }
            //        }
            //    }

            //    //set combobox item to most recently added
            //    if (cmbMonth.Items.Count > 0)
            //    {
            //        //set to first item
            //        cmbMonth.SelectedIndex = cmbMonth.Items.Count - 1;
            //    }

            //    ////If month combobox is empty
            //    //if (cmbMonth.Items.Count == 0)
            //    //{
            //    //    //set it to current year
            //    //    strMonth = DateTime.Now.ToString("M");
            //    //    convertMonthStringToInt(strMonth);
            //    //    cmbMonth.Text = strMonth;
            //    //}

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void themeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.dtpFromDef = dtpFrom.Value;
            Settings.Default.Save();
            //refreshEverything();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.dtpToDef = dtpTo.Value;
            Settings.Default.Save();
            //refreshEverything();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About formAbout = new About();
            formAbout.Show();
        }

        private void lblUtilities_DoubleClick(object sender, EventArgs e)
        {
            string result = "Utilities";

            
            result = Microsoft.VisualBasic.Interaction.InputBox("Would you like to change the table name?", "Change Table Name", lblUtilities.Text);
            
            if (result.Length > 15)
            {
                MessageBox.Show("Invalid input. Too Long");                
                result = "Utilities";
            }
            if (result.Length == 0)
            {
                result = "Utilities";
            }
            lblUtilities.Text = result;

        }

        private void lblExpenses_DoubleClick(object sender, EventArgs e)
        {
            string result = "Expenses";


            result = Microsoft.VisualBasic.Interaction.InputBox("Would you like to change the table name?", "Change Table Name", lblExpenses.Text);
            if (result.Length > 15)
            {
                MessageBox.Show("Invalid input. Too Long");
                result = "Expenses";
            }
            if (result.Length == 0)
            {
                result = "Expenses";
            }
            lblExpenses.Text = result;
        }

        private void lblBills_DoubleClick(object sender, EventArgs e)
        {
            string result = "Bills";


            result = Microsoft.VisualBasic.Interaction.InputBox("Would you like to change the table name?", "Change Table Name", lblBills.Text);
            if (result.Length > 15)
            {
                MessageBox.Show("Invalid input. Too Long");
                result = "Bills";
            }
            if (result.Length == 0)
            {
                result = "Bills";
            }
            lblBills.Text = result;
        }

        private void lblIncome_DoubleClick(object sender, EventArgs e)
        {
            string result = "Income";


            result = Microsoft.VisualBasic.Interaction.InputBox("Would you like to change the table name?", "Change Table Name", lblIncome.Text);
            if (result.Length > 15)
            {
                MessageBox.Show("Invalid input. Too Long");
                result = "Income";
            }
            if (result.Length == 0)
            {
                result = "Income";
            }
            lblIncome.Text = result;
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void devToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}