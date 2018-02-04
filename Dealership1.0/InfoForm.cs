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
        public void FillInfoFormTextbox(object car)
        {
            if (car != null)
            {

                var carConv = (Car)car;
                XmlDocument doc = new XmlDocument();
                doc.Load("data.xml");
                XmlNodeList nodes = doc.SelectNodes("//Car[ContractNumber='" + carConv.ContractNumber + "']");
                //string[] sb = new string[nodes.Count];

                CarInfoTextbox.Text = CarInfoToStringBuilder(carConv).ToString();
            }
        }
        private StringBuilder CarInfoToStringBuilder(Car car) ////load car info to stringBuilder
        {
            StringBuilder sBuilder = new StringBuilder();
            AppendToStringBuilderIfValuesAreNotNullOrEmptyString(car, sBuilder);
            //sBuilder.AppendLine(car.Brand);
            //sBuilder.AppendLine(car.Model);
            //sBuilder.AppendLine(car.BodyworkType);
            //sBuilder.AppendLine(car.EngineVolumeCc);
            //sBuilder.AppendLine(car.HorsePower);
            //sBuilder.AppendLine(car.Color);
            //sBuilder.AppendLine(car.FuelType);
            //sBuilder.AppendLine(car.ProductionDate);
            //sBuilder.AppendLine(car.Mileage);
            //sBuilder.AppendLine(car.Price);
            //sBuilder.AppendLine(car.Win);
            //sBuilder.AppendLine(car.AdditionalInfo);
            //sBuilder.AppendLine("--------------------------------");
            //sBuilder.AppendLine(car.AutoStartStop);
            //sBuilder.AppendLine(car.BluetoothHF);
            //sBuilder.AppendLine(car.DvdTv);
            //sBuilder.AppendLine(car.SteptronicTiptronic);
            //sBuilder.AppendLine(car.USBAudioVideoAUX);
            //sBuilder.AppendLine(car.AdaptiveAirSusp);
            //sBuilder.AppendLine(car.KeylessGo);
            //sBuilder.AppendLine(car.DifferentialLock);
            //sBuilder.AppendLine(car.ECU);
            //sBuilder.AppendLine(car.ElMirrors);
            //sBuilder.AppendLine(car.ElWindows);
            //sBuilder.AppendLine(car.ElAdjustmentSusp);
            //sBuilder.AppendLine(car.DPFFilter);
            //sBuilder.AppendLine(car.CoolingGlovebox);
            //sBuilder.AppendLine(car.Stereo);
            //sBuilder.AppendLine(car.ElSteerAmplifier);
            //sBuilder.AppendLine(car.AirConditioning);
            //sBuilder.AppendLine(car.Climatronic);
            //sBuilder.AppendLine(car.MultifunctionSteer);
            //sBuilder.AppendLine(car.Navigation);
            //sBuilder.AppendLine(car.SteeringHeater);
            //sBuilder.AppendLine(car.FrontWindowHeating);
            //sBuilder.AppendLine(car.Autopilot);
            //sBuilder.AppendLine(car.SeatsHeating);
            //sBuilder.AppendLine(car.RainSensor);
            //sBuilder.AppendLine(car.SteeringAdjustment);
            //sBuilder.AppendLine(car.ServoSteerAmplifier);
            //sBuilder.AppendLine(car.HeatingSys);
            //sBuilder.AppendLine("--------------------------------");

            return sBuilder;
        }
        ////Check if props are not null or empty string and append to stingbuilder 
        private void AppendToStringBuilderIfValuesAreNotNullOrEmptyString(Car car, StringBuilder sBuilder)
        {
            List<string> propsList = new List<string>();
            propsList.Add(car.Brand);
            propsList.Add(car.Model);
            propsList.Add(car.BodyworkType);
            propsList.Add(car.EngineVolumeCc);
            propsList.Add(car.HorsePower);
            propsList.Add(car.Color);
            propsList.Add(car.FuelType);
            propsList.Add(car.ProductionDate);
            propsList.Add(car.Mileage);
            propsList.Add(car.Price);
            propsList.Add(car.Win);
            propsList.Add(car.AdditionalInfo);
            ////propsList.Add(car.AutoStartStop);
            ////propsList.Add(car.BluetoothHF);
            ////propsList.Add(car.DvdTv);
            ////propsList.Add(car.SteptronicTiptronic);
            ////propsList.Add(car.USBAudioVideoAUX);
            ////propsList.Add(car.AdaptiveAirSusp);
            ////propsList.Add(car.KeylessGo);
            ////propsList.Add(car.DifferentialLock);
            ////propsList.Add(car.ECU);
            ////propsList.Add(car.ElMirrors);
            ////propsList.Add(car.ElWindows);
            ////propsList.Add(car.ElAdjustmentSusp);
            ////propsList.Add(car.DPFFilter);
            ////propsList.Add(car.CoolingGlovebox);
            ////propsList.Add(car.Stereo);
            ////propsList.Add(car.ElSteerAmplifier);
            ////propsList.Add(car.AirConditioning);
            ////propsList.Add(car.Climatronic);
            ////propsList.Add(car.MultifunctionSteer);
            ////propsList.Add(car.Navigation);
            ////propsList.Add(car.SteeringHeater);
            ////propsList.Add(car.FrontWindowHeating);
            ////propsList.Add(car.Autopilot);
            ////propsList.Add(car.SeatsHeating);
            ////propsList.Add(car.RainSensor);
            ////propsList.Add(car.SteeringAdjustment);
            ////propsList.Add(car.ServoSteerAmplifier);
            ////propsList.Add(car.HeatingSys);
            ////propsList.Add(car.Extras.ToString());
            foreach (var prop in propsList)
            {
                if (!string.IsNullOrEmpty(prop))
                {
                    sBuilder.AppendLine(prop);
                }
            }
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
    }
}
