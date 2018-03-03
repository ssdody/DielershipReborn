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

        public readonly string[] password = { "asda", "123" };
        private static bool _canContinue;

        public LogInForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {


            if (UsernameTextbox.Text.ToLower() != "exoticcars" && UsernameTextbox.Text.ToLower() != "admin")
            {
                MessageBox.Show("Invalid username or password!");
                UsernameTextbox.Text = string.Empty;
                PasswordTextbox.Text = string.Empty;
            }

            if (UsernameTextbox.Text.ToLower() == "admin" && PasswordTextbox.Text.ToLower() == password[0])
            {
                CanContinue = true;

                this.Hide();
            }

            if (UsernameTextbox.Text.ToLower() == "exoticcars" && PasswordTextbox.Text.ToLower() == password[1])
            {
                CanContinue = true;
               
                this.Hide();
            }

        }

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(UsernameTextbox.Text, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
                UsernameTextbox.Text = string.Empty;

            }
        }

        private void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(PasswordTextbox.Text, @"^\w+$"))
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
    }
}
