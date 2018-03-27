using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dealership1._0
{
    public partial class LogInForm : Form
    {
        public readonly string[] usernames = { "exoticcars", "admin" };
        public readonly string[] password = { "1234", "123" };
        private static bool _canContinue;

        public LogInForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(1);
            
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {


            if (UsernameTextbox.Text.ToLower() != usernames[0] && UsernameTextbox.Text.ToLower() != usernames[1])
            {
                MessageBox.Show("Invalid username or password!");

                return;

            }
            if (UsernameTextbox.Text.ToLower() == "admin" && PasswordTextbox.Text.ToLower() == password[0])
            {
                CanContinue = true;

                this.Hide();
                return;
            }
            else if (UsernameTextbox.Text.ToLower() == "exoticcars" && PasswordTextbox.Text.ToLower() == password[1])
            {
                CanContinue = true;

                this.Hide();
                return;
            }
            
                MessageBox.Show("Invalid username or password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                UsernameTextbox.Clear();
                PasswordTextbox.Clear();
                return;
            




        }



        private void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(PasswordTextbox.Text, @"^\w+$"))
            {
                MessageBox.Show("Invalid symbol!");
                PasswordTextbox.Text = string.Empty;

            }
        }

        public static bool CanContinue
        {
            set { _canContinue = value; }
            get { return _canContinue; }
        }

        private void PasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LogInButton_Click(sender, e);
            }
        }

        private void UsernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasswordTextbox.Focus();
            }
        }

        private void HiddenLogInButton_Click(object sender, EventArgs e)
        {
            CanContinue = true;
            this.Hide();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            UsernameTextbox.Focus();
        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanContinue == true)
            {
                e.Cancel = true;

            }
        }

        private void UsernameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void PasswordTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            string oldText = string.Empty;
            if (UsernameTextbox.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = UsernameTextbox.Text;
                UsernameTextbox.Text = oldText;

                UsernameTextbox.BackColor = System.Drawing.Color.White;
                UsernameTextbox.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                UsernameTextbox.Text = oldText;
                UsernameTextbox.BackColor = System.Drawing.Color.Red;
                UsernameTextbox.ForeColor = System.Drawing.Color.White;
            }
            UsernameTextbox.SelectionStart = UsernameTextbox.Text.Length;
        }
    }
}

