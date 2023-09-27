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
using MalachiBudget;

namespace MalachiBudget
{
    public partial class InsertData : Form
    {
        public MySqlConnection conn;

        public InsertData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            string dummyDate = DateTime.Now.ToString("dd:MM:YY");
            setConnection();

            conn.Close();
            conn.Open();

            //Username, TableName, Description, Amount, Due, Date, Notes, Category, Status, TransID
            for (int x = 0; x < 13; x++)
            {
                sql = $"INSERT INTO Transactions values ('tater', 'bills', 'abc{x}', {x*100}, 'dummyDate', '{DateTime.Now}', 'Notes{x}', 'fakeCat', 'Status', '{DateTime.Now}' )";
                MySqlCommand update = new MySqlCommand(@sql, conn);
                update.CommandTimeout = 200;
                update.ExecuteNonQuery();
            }
            

        }

        public void setConnection()
        {
            string dummyUser = "OGV0Cc+OgLf4ByaEB0x73A==";
            string dummyPass = "AWpnZxmLTTtSaECOOhot/+M1PwAMZ03GYciLPJ7L0w4=";


            try
            {
                dummyUser = StringCypher.Decrypt(dummyUser);
                dummyPass = StringCypher.Decrypt(dummyPass);
                conn = new MySqlConnection($"server=192.168.1.72;user={dummyUser};database=zMalachiBudgetCom;port=3306;password={dummyPass};SSL Mode=Required");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
