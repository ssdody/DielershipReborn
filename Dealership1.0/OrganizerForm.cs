using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Dealership1._0
{
    public partial class OrganizerForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();

        private string path = "tasklist.txt";
        private static OrganizerForm organizationFormField;
        private System.Timers.Timer timer;
        private bool isElapsedAssign;
        public static bool isOrganizerOnState;
        public int PopBackInterval;

        private OrganizerForm()
        {
            InitializeComponent();
        }

        public static OrganizerForm CreateInstance()
        {
            if (organizationFormField == null)
            {
                organizationFormField = new OrganizerForm();
            }
            return organizationFormField;
        }

        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path, String.Empty);

            var lines = TaskTextbox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            using (var streamWriter = new StreamWriter(path, true))
            {
                foreach (var line in lines)
                {
                    streamWriter.WriteLine(line);
                }
            }

            OrganizerOnOff(true);

            StartButton.Enabled = false;
            ElapsedTimeNumericUpDown.Enabled = false;
            isOrganizerOnState = true;
            TaskTextbox.Enabled = false;
            StopButton.Enabled = true;           
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            OrganizerOnOff(false);

            StartButton.Enabled = true;
            ElapsedTimeNumericUpDown.Enabled = true;
            isOrganizerOnState = false;
            TaskTextbox.Enabled = true;
            StopButton.Enabled = false;
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            this.StopButton.Enabled = false;
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    TaskTextbox.Text += line;
                    TaskTextbox.Text += "\r\n";
                }
            }
        }

        private void OrganizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer = null;
            this.Hide();
        }

        public void OrganizerOnOff(bool condition)
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer();

            }
            if (!condition)
            {
                timer.Stop();

                return;

            }

            timer.Enabled = true;
            if (timer.Enabled)
            {

                if (!isElapsedAssign)
                {
                    timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    timer.Interval = 1000 * 60 * Convert.ToDouble(ElapsedTimeNumericUpDown.Value);
                    //timer.Enabled = condition;
                    isElapsedAssign = true;

                    PopBackInterval = 1000 * 60 * Convert.ToInt32(ElapsedTimeNumericUpDown.Value) - 50000;
                }
                timer.Start();
            }




        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var tasklist = File.ReadAllLines("tasklist.txt").ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var line in tasklist)
            {
                sb.AppendLine(line);
            }
            AutoClosingMessageBox.Show(sb.ToString(), "Caption", PopBackInterval);
            //MessageBox.Show(sb.ToString());

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void OrganizerForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ElapsedTimeTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
