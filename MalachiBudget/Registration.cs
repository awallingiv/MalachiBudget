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
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using MySqlX.XDevAPI.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Utilities.Collections;

namespace MalachiBudget
{
    

    public partial class Registration : Form
    {
        public MySqlConnection conn;
        public string ReturnValue {get;set;}

        public Registration()
        {
            InitializeComponent();            
        }


        

        private void Registration_Load(object sender, EventArgs e)
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

            string dummyIP = "wLXoGks0fnJ13lOJkoi6dHXyZH8hbje+pWvQHGDyF+MFluFuFqtPAhCP3lCpOwSWLmdIAwhp1wZskkAnEJZcM/NQUiXjhZ9VutCYoFcEDpsMddM/rLbb34CptuSnUEYCQGErOaOy5K7CqgCIB31sGOcbQ471kd6qIJhfIPjLw0AENRDxqJNFqovQG7l+ZHpizUPjVOy4pCXfbMiMVzjEjg==";                       //test ip
            string dummyUser = "Pr7YOaL0CvkNac0M/RRbBQ==";                                                                      //new user
            string dummyPass = "EZm31WhvQXubdTTH7ZvWzbfyJC9wY4pqLm4eyW22iyubd+FAQzT6p2uEk6lgqEG26AUpuv201M5XHclAs6aWSw==";      //new pass
            string dummyDB = "S2fr8s1hNb+pQrk1fmO9RyVR6BVW1lZyrFiImiOlDHqPTfOg726nmgOxn1yhhImt";                                //test db
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
                conn = new MySqlConnection($"server={dummyIP};user={dummyUser};database={dummyDB};port={dummyport};password={dummyPass};SSL Mode=Required");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdCheckAvailability_Click(object sender, EventArgs e)
        {
            string sql;
            string result;

            //connect to login
            conn.Close();
            conn.Open();

            sql = $"SELECT * FROM Users WHERE Username = '{txtUser.Text}'";
            result = getStringFromTbl(sql);
            if(result == "" || result == null)
            {
                
                lblAvailability.Text = "Username Available!";
                lblAvailability.ForeColor = Color.Green;
                lblAvailability.Visible = true;
                Refresh();
            }
            else
            {
                lblAvailability.Text = "Username Unavailable!";
                lblAvailability.ForeColor = Color.Red;
                lblAvailability.Visible = true;
                //Refresh();
            }

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            lblEmailChk2.Visible = false;

            if (txtUser.Text.Length < 5)
            {
                lblAvailability.Visible = true;
                lblAvailability.ForeColor = Color.Red;
                lblAvailability.Text = "Must be at least 5 characters.";
                cmdCheckAvailability.Enabled = false;
            }         
            else if (txtUser.Text.Contains(' '))
            {
                lblAvailability.Visible = true;
                lblAvailability.ForeColor = Color.Red;
                lblAvailability.Text = "No Spaces are allowed in username";
                cmdCheckAvailability.Enabled = false;
            }
            else
            {
                lblAvailability.Visible = false;
                cmdCheckAvailability.Enabled = true;
            }

        }

        public string getStringFromTbl(string sql)
        {
            string result = "";

            try
            {
                conn.Close();
                conn.Open();

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);
                result = (string)MyDa.SelectCommand.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                //return 0;
                //MessageBox.Show(ex.Message);
            }
            return result;
        }

        public DateTime getDateFromTbl(string sql)
        {
            DateTime result;
            DateTime dt = new DateTime(1950, 01, 01, 12, 00, 00);
            try
            {
                conn.Close();
                conn.Open();

                MySqlDataAdapter MyDa = new MySqlDataAdapter();
                MyDa.SelectCommand = new MySqlCommand(sql, conn);
                result = (DateTime)MyDa.SelectCommand.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                //return 0;
                //MessageBox.Show(ex.Message);
            }
            return dt;
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string ValidationCode = RandomString(7);
            string sql = "";
            string result = "";
            string transID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Cursor = Cursors.WaitCursor;

            txtName.Enabled = false;
            txtEmail1.Enabled = false;
            txtEmail2.Enabled = false;
            txtUser.Enabled = false;
            cmdCheckAvailability.Enabled = false;
            txtPwd.Enabled = false;
            txtPwd2.Enabled = false;

            conn.Close();
            conn.Open();


            sql = $"SELECT * FROM Users WHERE Username = '{txtUser.Text}'";
            result = getStringFromTbl(sql);
            if (result == "" || result == null)
            {
                // Username, Pass, Email, Name, Validated, ValidationCode, TransID
                sql = $"INSERT INTO Users (`Username`,`Pass`,`Email`,`Name`,`Validated`, `ValidationCode`, `TransID`)" +
                    $"VALUES('{txtUser.Text}', '{txtPwd2.Text}', '{txtEmail2.Text}', '{txtName.Text}', 0, '{ValidationCode}', '{transID}')";
                MySqlCommand insert = new MySqlCommand(@sql, conn);
                insert.CommandTimeout = 200;
                insert.ExecuteNonQuery();

                sendEmail(ValidationCode);
                lblVerifyEmail.Visible = true;
                lblVerifyEmail.Text = "Verification Code has been sent to your Email.";
                lblValidate.Enabled = true;
                txtVerifyCode.Enabled = true;
                cmdVerify.Enabled = true;                 
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Error. Please try again.");
                Cursor = Cursors.Default;
                return;
            }


        }

        public string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void sendEmail(string ValidationCode)
        {
            string result = "";

            //EMLsupp12#$
            MailAddress to = new MailAddress(txtEmail1.Text);
            MailAddress from = new MailAddress("support@malachibudget.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Malachi Budget E-Mail validation code";
            email.Body = $"Hello {txtName.Text}, \r\n \r\n Your validation code is {ValidationCode}";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.titan.email";
            //website says use port 465, but it doesnt work and 587 does
            smtp.Port = 587;
            //smtp.Timeout = 10000;
            //smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("support@malachibudget.com", "EMLsupp12#$");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {
                /* Send method called below is what will send off our email 
                 * unless an exception is thrown.
                 */
                smtp.Send(email);
                lblVerifyEmail.Text = ("Validation E-Mai Sent! Please Check your E-Mail.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }


        }

        //private static bool IsValid(string email)
        //{
        //    var valid = true;

        //    try
        //    {
        //        var emailAddress = new MailAddress(email);
        //    }
        //    catch
        //    {
        //        valid = false;
        //    }

        //    return valid;
        //}
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {   
            if (txtName.Text.Length < 5)
            {
                lblNameChk.Visible = true;
                lblNameChk.ForeColor = Color.Red;
                lblNameChk.Text = "Must be at least 5 characters.";
            }
            else if (txtEmail1.Text.Length > 25)
            {
                lblNameChk.Visible = true;
                lblNameChk.ForeColor = Color.Red;
                lblNameChk.Text = "Must be no more than 25 characters.";
            }
            else
            {
                lblNameChk.Visible = false;
                //lblNameChk.Visible = true;
                //lblNameChk.ForeColor = Color.Green;
                //lblNameChk.Text = "Name Requirements met";
            }
        }

        private void txtEmail1_TextChanged(object sender, EventArgs e)
        {
            lblNameChk.Visible = false;
            



            //if (IsValid(txtEmail1.Text))
            if (Validator.EmailIsValid(txtEmail1.Text))
            {
                lblEmailChk.Visible = false;
                //lblEmailChk.Visible = true;
                //lblEmailChk.ForeColor = Color.Green;
                //lblEmailChk.Text = "Success! Email requirements met";
            }
            else
            {                
                lblEmailChk.Visible = true;
                lblEmailChk.ForeColor = Color.Red;
                lblEmailChk.Text = "Not a valid email address";
            }
        }

        private void txtEmail2_TextChanged(object sender, EventArgs e)
        {
            lblEmailChk.Visible = false;

            if (txtEmail2.Text != txtEmail1.Text)
            {
                lblEmailChk2.Visible = true;
                lblEmailChk2.ForeColor = Color.Red;
                lblEmailChk2.Text = "Email Addresses do not match!";
            }
            else
            {
                lblEmailChk2.Visible = false;
                //lblEmailChk2.Visible = true;
                //lblEmailChk2.ForeColor = Color.Green;
                //lblEmailChk2.Text = "Success!";
            }
        }

        private void txtPwd2_TextChanged(object sender, EventArgs e)
        {
            if (txtPwd2.Text != txtPwd.Text)
            {
                lblPassChk2.Visible = true;
                lblPassChk2.ForeColor = Color.Red;
                lblPassChk2.Text = "Passwords don't match!";
            }
            else
            {
                lblPassChk2.Visible = false;
            }
        }

        private void cmdVerify_Click(object sender, EventArgs e)
        {
            string sql;
            string code = "";
            DateTime transID;
            DateTime currentDT = DateTime.Now;
            
            System.TimeSpan timeSpan;

            conn.Close();
            conn.Open();

            sql = $"SELECT ValidationCode FROM Users WHERE Username = '{txtUser.Text}'";
            code = getStringFromTbl(sql);
            if (code == "" || code == null)
            {
                MessageBox.Show("Error retrieving validation code from server.\r\n Try clicking 'Submit' Again.");
            }
            else
            {
                if (txtVerifyCode.Text == code)
                {
                    sql = $"SELECT TransID FROM Users WHERE Username = '{txtUser.Text}'";
                    transID = getDateFromTbl(sql);   
                    timeSpan = currentDT.Subtract(transID);
                    if (timeSpan.TotalMinutes < 10)
                    {
                        
                        sql = $"UPDATE Users set Validated = 1 WHERE Username = '{txtUser.Text}'";
                        MySqlCommand update = new MySqlCommand(@sql, conn);
                        update.CommandTimeout = 200;
                        update.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful. \r\nPlease Login with your new username!");

                        //return username as text
                        this.ReturnValue = txtUser.Text;
                        //use DialogResult to do so
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Validation Code Expired.");
                        return;
                    }


                    
                }
                else
                {
                    MessageBox.Show("Invalid Code");
                    return;
                }
            }
        }

        private void cmdResend_Click(object sender, EventArgs e)
        {
            string ValidationCode = RandomString(7);
            string sql = "";
            string result = "";
            string transID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Cursor = Cursors.WaitCursor;

            conn.Close();
            conn.Open();

            if (result == "" || result == null)
            {
                // Username, Pass, Email, Name, Validated, ValidationCode, TransID
                sql = $"UPDATE Users SET ValidationCode = '{ValidationCode}', TransID = '{transID}' WHERE Username = '{txtUser.Text}';";
                MySqlCommand update = new MySqlCommand(@sql, conn);
                update.CommandTimeout = 200;
                update.ExecuteNonQuery();

                sendEmail(ValidationCode);
                lblVerifyEmail.Visible = true;
                lblVerifyEmail.Text = "Verification Code has been sent to your Email.";
                lblValidate.Enabled = true;
                txtVerifyCode.Enabled = true;
                cmdVerify.Enabled = true;
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Error. Please contact support.");
                Cursor = Cursors.Default;
                return;
            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            if (txtPwd.Text.Length < 10)
            {
                lblPassChk.Visible = true;
                lblPassChk.ForeColor = Color.Red;
                lblPassChk.Text = "Password must be at least 10 characters";                
                
            }
            else
            {
                lblPassChk.Visible = false;                
            }
            
        }
    }
}
