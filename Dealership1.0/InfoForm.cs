using DielershipLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Dealership1._0
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }
        public void FillTextbox(Car car)
        {

            CarInfoTextbox.Text = CarInfoToStringBuilder(car).ToString();

        }
        public void FillTextbox(IEnumerable<Car> collection)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var thing in collection)
            {

                sb.AppendLine(thing.ContractNumber + " " + thing.Display);
                sb.AppendLine();
                
            }
            CarInfoTextbox.Text = sb.ToString();

        }
        private StringBuilder CarInfoToStringBuilder(Car car) ////load car info to stringBuilder
        {
            StringBuilder sBuilder = new StringBuilder();
            AppendToStringBuilderIfValuesAreNotNullOrEmptyString(car, sBuilder);

            return sBuilder;
        }
        ////Check if props are not null or empty string and append to stingbuilder 
        private void AppendToStringBuilderIfValuesAreNotNullOrEmptyString(Car car, StringBuilder sBuilder)
        {
            List<string> propsList = new List<string>();
            //propsList.Add(car.Brand);
            //propsList.Add(car.Model);
            //propsList.Add(car.BodyworkType);
            //propsList.Add(car.EngineVolumeCc);
            //propsList.Add(car.HorsePower);
            //propsList.Add(car.Color);
            //propsList.Add(car.FuelType);
            //propsList.Add(car.ProductionDate);
            //propsList.Add(car.Mileage);
            //propsList.Add(car.Price);
            //propsList.Add(car.Vin);
            //propsList.Add(car.AdditionalInfo);
            //////propsList.Add(car.AutoStartStop);
            //////propsList.Add(car.BluetoothHF);
            //////propsList.Add(car.DvdTv);
            //////propsList.Add(car.SteptronicTiptronic);
            //////propsList.Add(car.USBAudioVideoAUX);
            //////propsList.Add(car.AdaptiveAirSusp);
            //////propsList.Add(car.KeylessGo);
            //////propsList.Add(car.DifferentialLock);
            //////propsList.Add(car.ECU);
            //////propsList.Add(car.ElMirrors);
            //////propsList.Add(car.ElWindows);
            //////propsList.Add(car.ElAdjustmentSusp);
            //////propsList.Add(car.DPFFilter);
            //////propsList.Add(car.CoolingGlovebox);
            //////propsList.Add(car.Stereo);
            //////propsList.Add(car.ElSteerAmplifier);
            //////propsList.Add(car.AirConditioning);
            //////propsList.Add(car.Climatronic);
            //////propsList.Add(car.MultifunctionSteer);
            //////propsList.Add(car.Navigation);
            //////propsList.Add(car.SteeringHeater);
            //////propsList.Add(car.FrontWindowHeating);
            //////propsList.Add(car.Autopilot);
            //////propsList.Add(car.SeatsHeating);
            //////propsList.Add(car.RainSensor);
            //////propsList.Add(car.SteeringAdjustment);
            //////propsList.Add(car.ServoSteerAmplifier);
            //////propsList.Add(car.HeatingSys);
            //////propsList.Add(car.Extras.ToString());
            //foreach (var prop in propsList)
            //{
            //    if (!string.IsNullOrEmpty(prop))
            //    {
            //        sBuilder.AppendLine(prop);
            //    }
            //}
            string[] listStr = car.Extras.Split('$');
            for (int i = 0; i < listStr.Count(); i++)
            {
                sBuilder.AppendLine(listStr[i]);
            }



        }
        private void InfoForm_Load(object sender, EventArgs e)
        {

        }

        private void CarInfoTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void TopMostButton_Click(object sender, EventArgs e)
        {
            if (TopMost == false)
            {
                this.TopMost = true;

                TopMostButton.Image = new Bitmap(Properties.Resources.icons8_push_pin_24);
                CarInfoTextbox.Focus();
            }
            else
            {
                this.TopMost = false;
                TopMostButton.Image = new Bitmap(Properties.Resources.icons8_pin_24);
                CarInfoTextbox.Focus();
            }
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.CarInfoTextbox.Text);
        }

        private void ExtrasInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
