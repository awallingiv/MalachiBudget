using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MalachiBudget
{
    public partial class ForgotPass : Form
    {
        MySqlConnection conn;
        public string ReturnValue { get; set; }

        public ForgotPass()
        {
            InitializeComponent();
        }

        private void ForgotPass_Load(object sender, EventArgs e)
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
            string dummyIP = "wLXoGks0fnJ13lOJkoi6dK/9t0Jwtgup4Juso0kwqmURgF2Gt2bjP2vuuvp9V40IzH5jVNnCTpkvuMk22APy/mTMcUaMtZEZjTlDWFqNGLY4ma0u9jsWhzl6xM4D7H8g7he4jQ9SFGQ45Y3kmMLvMN3o9cKmiGfC0/+5T9IiL58=";                       //test ip
            string dummyUser = "Pr7YOaL0CvkNac0M/RRbBQ==";                                                                      //new user
            string dummyPass = "O6QletsAUBxItkkwyxhSR6NGMl/XxqYGoXt8Fy/2Z/F93LtwEWwsXDQ2tScEhlQGMc0LhPVyNHsLHfS+1GBJDQ==";      //new pass
            string dummyDB = "aqXbtw+u3H5Z5KwcEH86w35faamKGyOddUundp7pnVY=";                                                    //test db
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
                MessageBox.Show(ex.Message);
            }
        }
        public string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
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

        private void sendEmail(string ValidationCode, string useremail, string name)
        {
            string result = "";

            //EMLsupp12#$
            MailAddress to = new MailAddress(useremail);
            MailAddress from = new MailAddress("support@malachibudget.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Malachi Budget E-Mail verification code";
            email.Body = $"Hello {name}, \r\n \r\n Your verification code is {ValidationCode}";

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
                lblVerifyEmail.Visible = true;
                lblVerifyEmail.ForeColor = Color.Red;
                lblVerifyEmail.Text = ("Verification E-Mai Sent! Please Check your E-Mail.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }


        }
        private void cmdValidate_Click(object sender, EventArgs e)
        {
            string ValidationCode = RandomString(7);
            string sql = "";
            string result = "";
            string email = "";
            string name = "";
            string transID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Cursor = Cursors.WaitCursor;

            lblUser.Enabled = false;
            txtUser.Enabled = false;
            lblEmail.Enabled = false;
            txtEmail.Enabled = false;


            conn.Close();
            conn.Open();

            sql = $"SELECT Name FROM Users WHERE Username = '{txtUser.Text}'";
            name = getStringFromTbl(sql);
            sql = $"SELECT Email FROM Users WHERE Username = '{txtUser.Text}'";
            email = getStringFromTbl(sql);

            if (txtEmail.Text == email)
            {
                // Username, Pass, Email, Name, Validated, ValidationCode, TransID
                sql = $"UPDATE Users SET ValidationCode = '{ValidationCode}', TransID ='{transID}', Validated = 0 WHERE Username = '{txtUser.Text}';";
                MySqlCommand insert = new MySqlCommand(@sql, conn);
                insert.CommandTimeout = 200;
                insert.ExecuteNonQuery();

                sendEmail(ValidationCode, email, name);
                lblVerifyEmail.Visible = true;
                lblVerifyEmail.Text = "Verification Code has been sent to your Email.";
                lblValidate.Enabled = true;
                txtVerifyCode.Enabled = true;
                cmdVerify.Enabled = true;
                Cursor = Cursors.Default;
            }
            else if (email == null || email == "")
            {
                MessageBox.Show("The email/username combination you entered is wrong.");
                return;
            }
            else
            {
                MessageBox.Show("Error. Either you have entered an Invalid Username or \r\n the server did not respond. \r\n Please try again.");
                Cursor = Cursors.Default;
                return;
            }


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
                        lblUser.Enabled = false;
                        lblEmail.Enabled = false;
                        txtUser.Enabled = false;
                        txtEmail.Enabled = false;
                        cmdValidate.Enabled = false;


                        lblValidate.Enabled = false;
                        txtVerifyCode.Enabled = false;
                        cmdVerify.Enabled = false;

                        lblPwd.Visible = true;
                        lblPwd2.Visible = true;
                        txtPwd.Visible = true;
                        txtPwd2.Visible = true;
                        cmdSubmit2.Visible = true;
                        MessageBox.Show("Success! Please Enter a new password and click submit below.");

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

        private void cmdSubmit2_Click(object sender, EventArgs e)
        {
            string sql;

            Cursor = Cursors.WaitCursor;

            conn.Close();
            conn.Open();

            try
            {
                sql = $"UPDATE Users SET Pass = '{txtPwd2.Text}', Validated = 1 WHERE Username = '{txtUser.Text}';";
                MySqlCommand insert = new MySqlCommand(@sql, conn);
                insert.CommandTimeout = 200;
                insert.ExecuteNonQuery();
                Cursor = Cursors.Default;
                MessageBox.Show("Success! Your password has been changed.");
                sendChgPassEmail(txtUser.Text, txtEmail.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


            
        }

        private void sendChgPassEmail(string username, string useremail)
        {
            
            //EMLsupp12#$
            MailAddress to = new MailAddress(useremail);
            MailAddress from = new MailAddress("support@malachibudget.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Malachi Budget Password Change";
            email.Body = $"Hello {username}, \r\n \r\n Your password has been successfully changed.";

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
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
