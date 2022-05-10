using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            if(!File.Exists(@"login.txt"))
            {
                File.Create("login.txt").Close();
            }
        }
        public static string[] logins = ReadLoginFileToEnd().Replace("\r\n", " ").Replace("\n", " ").Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Test
            try
            {
                bool rightLogin = false;
                if(tbLogin.Text.Length > 0)
                {
                    if(tbPass.Text.Length > 0)
                    {
                        for(int i = 0; i < logins.Length; i += 3)
                        {
                            if(logins[i] == tbLogin.Text)
                            {
                                rightLogin = true;
                                if(logins[i + 1] == tbPass.Text)
                                {
                                    //User userLog = new User(logins[i], logins[i + 1], int.Parse(logins[i + 2]));

                                    tbLogin.Text = string.Empty;
                                    tbPass.Text = string.Empty;
                                    this.Visible = false;
                                    //Form2 form2 = new Form2(logins[i], logins[i + 1], int.Parse(logins[i + 2]));
                                    Form2 form2 = new Form2();
                                    form2.Show();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Wrong password");
                                    break;
                                }
                            }
                        }
                        if(!rightLogin)
                            MessageBox.Show($"Login not found");
                    }
                    else
                        MessageBox.Show("Enter password");
                }
                else
                    MessageBox.Show("Enter login");
                tbLogin.Text = string.Empty;
                tbPass.Text = string.Empty;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool loginExist = false;
                //string[] logins = ReadLoginFileToEnd().Replace("\r\n", " ").Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                if(tbLogin.Text.Length > 0)
                {
                    if(tbPass.Text.Length > 0)
                    {
                        for(int i = 0; i < logins.Length; i += 3)
                        {
                            if(tbLogin.Text == logins[i])
                            {
                                loginExist = true;
                                break;
                            }
                        }
                        if(!loginExist)
                            using(StreamWriter sr = new StreamWriter("login.txt", true))
                            {
                                sr.WriteLine($"{tbLogin.Text} {tbPass.Text} 0");
                                User user = new User(tbLogin.Text, tbPass.Text, 0);

                                tbLogin.Text = string.Empty;
                                tbPass.Text = string.Empty;
                                this.Visible = false;
                                MessageBox.Show("User created successful");
                                Form2 form2 = new Form2();
                                //Form2 form2 = new Form2(tbLogin.Text, tbPass.Text, 0);
                                form2.Show();
                            }
                        else
                        {
                            MessageBox.Show("User exist.Try another login");
                            tbLogin.Text = string.Empty;
                            tbPass.Text = string.Empty;
                        }
                    }
                    else
                        MessageBox.Show("Enter password");
                }
                else
                    MessageBox.Show("Enter login");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        public static string ReadLoginFileToEnd()
        {
            string result;
            using(StreamReader reader = File.OpenText("login.txt"))
                result = reader.ReadToEnd();
            return result;
        }
    }
}