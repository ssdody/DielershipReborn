using DealershipLibrary;
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
using System.Windows.Forms;

namespace Dealership1._0
{
    public partial class PrintForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {

        }

        public void FillPrintForm(Car car)
        {
            this.BrandLabel.Text = car.Brand;
            this.ModelLabel.Text = car.Model;
            this.TypeLabel.Text = car.BodyworkType;
            this.engineVolumeLabel.Text = car.EngineVolumeCc;
            this.HorsePowerLabel.Text = car.HorsePower;
            this.FuelTypeLabel.Text = car.FuelType;
            this.ColorLabel.Text = car.Color;
            this.ProductionDateLabel.Text = car.ProductionDate;
            this.MileageLabel.Text = car.Mileage;
            this.VinLabel.Text = car.Vin;
            this.GearboxLabel.Text = car.Gearbox;
            this.TyresLabel.Text = car.Tyres;
            this.CountryLabel.Text = car.Country;
            this.NumberOfKeysLabel.Text = car.NumberOfKeys;
            this.PriceLabel.Text = car.Price + "лв.";
            this.ContractLabel.Text = car.ContractNumber.ToString();

            this.ExtrasTextbox.Text = FillExtrasTextbox(car);

            LoadHeaderCarPictureInPrintFormPicturebox(car);
        }

        private void LoadHeaderCarPictureInPrintFormPicturebox(Car car)
        {
            string carNumber = car.ContractNumber.ToString();
            if (File.Exists($"..\\Images\\{carNumber}\\{carNumber}header.jpeg"))
            {
                PrintFormPicturebox.Image = null;
                PrintFormPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                var img = Image.FromFile($"..\\Images\\{carNumber}\\{carNumber}header.jpeg");

                PrintFormPicturebox.Image = img;
            }
            else
            {
                PrintFormPicturebox.Image = PrintFormPicturebox.InitialImage;
            }
        }

        private string FillExtrasTextbox(Car car)
        {
            var sBuilder = new StringBuilder();
            List<string> propsList = new List<string>();

            string[] listStr = car.Extras.Split('$');
            for (int i = 0; i < listStr.Count(); i++)
            {
                sBuilder.AppendLine(listStr[i]);
            }

            return sBuilder.ToString();
        }

        private void button_printForm_Click(object sender, EventArgs e)
        {
            try
            {
                int x = SystemInformation.WorkingArea.X;
                int y = SystemInformation.WorkingArea.Y;

                int width = this.Width;
                int height = this.Height;

                Rectangle bounds = new Rectangle(x, y, width, height);

                Bitmap image = new Bitmap(width, height);

                this.DrawToBitmap(image, bounds);
                string fileName = "..\\" + DateTime.Now.ToString("Mdyyyy");
                image.Save(fileName + ".bmp");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            DialogResult messageDialog = MessageBox.Show("Изображението е запазено.\nИскате ли да отворите изображението?", "Print", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (messageDialog == DialogResult.Yes)
            {
                string fileName = "..\\" + DateTime.Now.ToString("Mdyyyy") + ".bmp";
                Process.Start(fileName);
            }
            else if (messageDialog == DialogResult.No)
            {

            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
