﻿using MalachiBudget.Properties;
using Microsoft.VisualBasic;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MalachiBudget
{
    public partial class LoginScreen : Form
    {        
            public MySqlConnection conn;

            public LoginScreen()
            {
                InitializeComponent();
            }

            private void LoginScreen_Load(object sender, EventArgs e)
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
                    ex.ToString();
                }
                
            // These are now useless, but I stored encrypted strings here for these values and then decrypted them at execution
            string dummyIP = "wLXoGks0fnJ13lOJkoi6dK/9t0";      //test ip
            string dummyUser = "Pr7YOaL0CvkNac0M/RRbBQ==";      //new user
            string dummyPass = "O6QletsAUBxItkkwyxhSR6NG";      //new pass
            string dummyDB = "7sHyZY3Cb2oF5Q2OQhA+r6VO37";      //test db
            string dummyport = "x7HfjBiQi2H+KNqL/wVBiA==";      
           

            try
                {
                    dummyUser = StringCypher.Decrypt(dummyUser);
                    dummyPass = StringCypher.Decrypt(dummyPass);
                    dummyIP = StringCypher.Decrypt(dummyIP);
                    dummyDB = StringCypher.Decrypt(dummyDB);
                    dummyport = StringCypher.Decrypt(dummyport);
                    conn = new MySqlConnection($"server={dummyIP};user={dummyUser};database={dummyDB};port={dummyport};password={dummyPass};SSL Mode=Required");

                    if (Settings.Default.rememberMe == true)
                    {
                        string pass = StringCypher.Decrypt(Settings.Default.loginPass);
                        txtUsername.Text = Settings.Default.loginUser;
                        txtPwd.Text = pass;
                        chkRemember.Checked = true;
                                             
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            private void cmdLogin_Click(object sender, EventArgs e)
            {
                string username = txtUsername.Text;
                string password = txtPwd.Text;
                string encryptedPassword = StringCypher.Encrypt(password);
                string sql;
                DialogResult DR;

                Cursor = Cursors.WaitCursor;
                //connect to login
                conn.Close();
                conn.Open();

                sql = $"SELECT Username FROM Users where Username = '{username}' AND Pass = '{password}'";
                string result = getStringFromTbl(sql);
                if (result != null)
                {
                    Cursor = Cursors.Default;

                    if (chkRemember.Checked == true)
                    {
                        Settings.Default.loginUser = txtUsername.Text;
                        string pass = txtPwd.Text;
                        Settings.Default.loginPass = StringCypher.Encrypt(pass);
                        Settings.Default.rememberMe = true;
                        Settings.Default.Save();
                    }   

                    //MessageBox.Show("Login Successfull");
                    mainForm form = new mainForm(username);
                    this.Hide();
                    form.ShowDialog();                    
                    Close();                   

                }
                else
                {
                    MessageBox.Show("Login Failed.");
                }
                Cursor = Cursors.Default;


            }
            public string getStringFromTbl(string sql)
            {
                string result = "";

                try
                {
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
                return null;
            }
            private void txtPwd_TextChanged(object sender, EventArgs e)
            {

            }

            private void login(string uname, string pwd)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {

                // MessageBox.Show($"Encrypted Information \nUserName = {dummyUser}\nPassword = {dummyPass}");
            }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Registration registerForm = new Registration();
            var result = registerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtUsername.Text = registerForm.ReturnValue;
            }
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemember.Checked == false)
            {
                string pass = "";
                Settings.Default.loginUser = "";
                Settings.Default.loginPass = StringCypher.Encrypt(pass);
                Settings.Default.rememberMe = false;
                Settings.Default.Save();
            }
            else
            {
                string pass = txtPwd.Text;
                Settings.Default.loginUser = txtUsername.Text;
                Settings.Default.loginPass = StringCypher.Encrypt(pass);
                Settings.Default.rememberMe = true;
                Settings.Default.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ForgotPass forgotForm = new ForgotPass();
            forgotForm.Show();
        }
    }
    }

