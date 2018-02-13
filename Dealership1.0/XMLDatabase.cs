using System.Xml.Serialization;
using DielershipLibrary;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Dealership1._0
{
    public class XMLDatabase
    {
        private static XmlSerializer seriliazer = new XmlSerializer(typeof(Car));
        private static string filename = "data.xml";

        public static void AppendNewCarDataToXML(Car car)        // CHECKED
        {


            XmlDocument doc = new XmlDocument();

            doc.Load(filename);
            //create node and add value
            XmlNode headNode = doc.CreateNode(XmlNodeType.Element, "Car", null);


            //create title node
            XmlNode contractNumNode = doc.CreateElement("ContractNumber");
            contractNumNode.InnerText = car.ContractNumber.ToString();
            headNode.AppendChild(contractNumNode);

            XmlNode CategoryNode = doc.CreateElement("Category");
            CategoryNode.InnerText = car.Category.ToString();
            headNode.AppendChild(CategoryNode);

            XmlNode nodeTitle = doc.CreateElement("Brand");
            nodeTitle.InnerText = car.Brand;
            headNode.AppendChild(nodeTitle);

            XmlNode modelNode = doc.CreateElement("Model");
            modelNode.InnerText = car.Model;
            headNode.AppendChild(modelNode);

            XmlNode bodyNode = doc.CreateElement("BodyworkType");
            bodyNode.InnerText = car.BodyworkType;
            headNode.AppendChild(bodyNode);

            XmlNode horsePowerNode = doc.CreateElement("HorsePower");
            horsePowerNode.InnerText = car.HorsePower;
            headNode.AppendChild(horsePowerNode);

            XmlNode fuelTypeNode = doc.CreateElement("FuelType");
            fuelTypeNode.InnerText = car.FuelType;
            headNode.AppendChild(fuelTypeNode);
            //todo the same for every car prop !

            XmlNode colorNode = doc.CreateElement("Color");
            colorNode.InnerText = car.Color;
            headNode.AppendChild(colorNode);

            XmlNode productionDateNode = doc.CreateElement("ProductionDate");
            productionDateNode.InnerText = car.ProductionDate;
            headNode.AppendChild(productionDateNode);

            XmlNode mileageNode = doc.CreateElement("Mileage");
            mileageNode.InnerText = car.Mileage;
            headNode.AppendChild(mileageNode);

            XmlNode priceNode = doc.CreateElement("Price");
            priceNode.InnerText = car.Price;
            headNode.AppendChild(priceNode);

            XmlNode addictionalInfoNode = doc.CreateElement("AdditionalInfo");
            addictionalInfoNode.InnerText = car.AdditionalInfo;
            headNode.AppendChild(addictionalInfoNode);

            XmlNode engineVolumeNode = doc.CreateElement("EngineVolumeCc");
            engineVolumeNode.InnerText = car.EngineVolumeCc;
            headNode.AppendChild(engineVolumeNode);

            XmlNode VINNode = doc.CreateElement("Vin");
            VINNode.InnerText = car.Vin;
            headNode.AppendChild(VINNode);

            XmlNode StatusNode = doc.CreateElement("Status");
            StatusNode.InnerText = car.Status;
            headNode.AppendChild(StatusNode);

            XmlNode AutoStartStopNode = doc.CreateElement("AutoStartStop");
            AutoStartStopNode.InnerText = car.AutoStartStop;
            headNode.AppendChild(AutoStartStopNode);

            XmlNode BluetoothHFNode = doc.CreateElement("BluetoothHF");
            BluetoothHFNode.InnerText = car.BluetoothHF;
            headNode.AppendChild(BluetoothHFNode);

            XmlNode DvdTvNode = doc.CreateElement("DvdTv");
            DvdTvNode.InnerText = car.DvdTv;
            headNode.AppendChild(DvdTvNode);

            XmlNode SteptronicTiptronicNode = doc.CreateElement("SteptronicTiptronic");
            SteptronicTiptronicNode.InnerText = car.SteptronicTiptronic;
            headNode.AppendChild(SteptronicTiptronicNode);

            XmlNode USBAudioVideoAUXNode = doc.CreateElement("USBAudioVideoAUX");
            USBAudioVideoAUXNode.InnerText = car.USBAudioVideoAUX;
            headNode.AppendChild(USBAudioVideoAUXNode);

            XmlNode AdaptiveAirSuspNode = doc.CreateElement("AdaptiveAirSusp");
            AdaptiveAirSuspNode.InnerText = car.AdaptiveAirSusp;
            headNode.AppendChild(AdaptiveAirSuspNode);

            XmlNode KeylessGoNode = doc.CreateElement("KeylessGo");
            KeylessGoNode.InnerText = car.KeylessGo;
            headNode.AppendChild(KeylessGoNode);

            XmlNode DifferentialLockNode = doc.CreateElement("DifferentialLock");
            DifferentialLockNode.InnerText = car.DifferentialLock;
            headNode.AppendChild(DifferentialLockNode);

            XmlNode ECUNode = doc.CreateElement("ECU");
            ECUNode.InnerText = car.ECU;
            headNode.AppendChild(ECUNode);

            XmlNode ElMirrorsNode = doc.CreateElement("ElMirrors");
            ElMirrorsNode.InnerText = car.ElMirrors;
            headNode.AppendChild(ElMirrorsNode);

            XmlNode ElWindowsNode = doc.CreateElement("ElWindows");
            ElWindowsNode.InnerText = car.ElWindows;
            headNode.AppendChild(ElWindowsNode);


            XmlNode ElAdjustmentSuspNode = doc.CreateElement("ElAdjustmentSusp");
            ElAdjustmentSuspNode.InnerText = car.ElAdjustmentSusp;
            headNode.AppendChild(ElAdjustmentSuspNode);

            XmlNode DPFFilterNode = doc.CreateElement("DPFFilter");
            DPFFilterNode.InnerText = car.DPFFilter;
            headNode.AppendChild(DPFFilterNode);

            XmlNode CoolingGloveboxNode = doc.CreateElement("CoolingGlovebox");
            CoolingGloveboxNode.InnerText = car.CoolingGlovebox;
            headNode.AppendChild(CoolingGloveboxNode);

            XmlNode StereoNode = doc.CreateElement("Stereo");
            StereoNode.InnerText = car.Stereo;
            headNode.AppendChild(StereoNode);

            XmlNode ElAdjustmentSeatsNode = doc.CreateElement("ElAdjustmentSeats");
            ElAdjustmentSeatsNode.InnerText = car.ElAdjustmentSeats;
            headNode.AppendChild(ElAdjustmentSeatsNode);

            XmlNode ElSteerAmplifierNode = doc.CreateElement("ElSteerAmplifier");
            ElSteerAmplifierNode.InnerText = car.ElSteerAmplifier;
            headNode.AppendChild(ElSteerAmplifierNode);

            XmlNode AirConditioningNode = doc.CreateElement("AirConditioning");
            AirConditioningNode.InnerText = car.AirConditioning;
            headNode.AppendChild(AirConditioningNode);

            XmlNode ClimatronicNode = doc.CreateElement("Climatronic");
            ClimatronicNode.InnerText = car.Climatronic;
            headNode.AppendChild(ClimatronicNode);

            XmlNode MultifunctionSteerNode = doc.CreateElement("MultifunctionSteer");
            MultifunctionSteerNode.InnerText = car.MultifunctionSteer;
            headNode.AppendChild(MultifunctionSteerNode);

            XmlNode NavigationNode = doc.CreateElement("Navigation");
            NavigationNode.InnerText = car.Navigation;
            headNode.AppendChild(NavigationNode);

            XmlNode SteeringHeaterNode = doc.CreateElement("SteeringHeater");
            SteeringHeaterNode.InnerText = car.SteeringHeater;
            headNode.AppendChild(SteeringHeaterNode);

            XmlNode FrontWindowHeatingNode = doc.CreateElement("FrontWindowHeating");
            FrontWindowHeatingNode.InnerText = car.FrontWindowHeating;
            headNode.AppendChild(FrontWindowHeatingNode);

            XmlNode AutopilotNode = doc.CreateElement("Autopilot");
            AutopilotNode.InnerText = car.Autopilot;
            headNode.AppendChild(AutopilotNode);

            XmlNode SeatsHeatingNode = doc.CreateElement("SeatsHeating");
            SeatsHeatingNode.InnerText = car.SeatsHeating;
            headNode.AppendChild(SeatsHeatingNode);

            XmlNode RainSensorNode = doc.CreateElement("RainSensor");
            RainSensorNode.InnerText = car.RainSensor;
            headNode.AppendChild(RainSensorNode);

            XmlNode SteeringAdjustmentNode = doc.CreateElement("SteeringAdjustment");
            SteeringAdjustmentNode.InnerText = car.SteeringAdjustment;
            headNode.AppendChild(SteeringAdjustmentNode);

            XmlNode ServoSteerAmplifierNode = doc.CreateElement("ServoSteerAmplifier");
            ServoSteerAmplifierNode.InnerText = car.ServoSteerAmplifier;
            headNode.AppendChild(ServoSteerAmplifierNode);

            XmlNode HeadlightsWashNode = doc.CreateElement("HeadlightsWash");
            HeadlightsWashNode.InnerText = car.HeadlightsWash;
            headNode.AppendChild(HeadlightsWashNode);

            XmlNode HeatingSysNode = doc.CreateElement("HeatingSys");
            HeatingSysNode.InnerText = car.HeatingSys;
            headNode.AppendChild(HeatingSysNode);

            XmlNode GearboxNode = doc.CreateElement("Gearbox");
            GearboxNode.InnerText = car.Gearbox.ToString();
            headNode.AppendChild(GearboxNode);

            XmlNode extrasNode = doc.CreateElement("Extras");
            extrasNode.InnerText = car.Extras.ToString();
            headNode.AppendChild(extrasNode);

            XmlNode NumberOfKeysNode = doc.CreateElement("NumberOfKeys");
            NumberOfKeysNode.InnerText = car.NumberOfKeys.ToString();
            headNode.AppendChild(NumberOfKeysNode);

            XmlNode TiresNode = doc.CreateElement("Tires");
            TiresNode.InnerText = car.Tires.ToString();
            headNode.AppendChild(TiresNode);

            XmlNode DateOfCreatingAdNode = doc.CreateElement("DateOfCreatingAd");
            DateOfCreatingAdNode.InnerText = car.DateOfCreatingAd.ToString();
            headNode.AppendChild(DateOfCreatingAdNode);

            XmlNode RealSellingPriceNode = doc.CreateElement("RealSellingPrice");
            RealSellingPriceNode.InnerText = car.RealSellingPrice.ToString();
            headNode.AppendChild(RealSellingPriceNode);

            XmlNode MinBillValueNode = doc.CreateElement("MinBillValue");
            MinBillValueNode.InnerText = car.MinBillValue.ToString();
            headNode.AppendChild(MinBillValueNode);

            XmlNode MaxBillValueNode = doc.CreateElement("MaxBillValue");
            MaxBillValueNode.InnerText = car.MaxBillValue.ToString();
            headNode.AppendChild(MaxBillValueNode);

            XmlNode OwnerByVoucherNode = doc.CreateElement("OwnerByVoucher");
            OwnerByVoucherNode.InnerText = car.OwnerByVoucher.ToString();
            headNode.AppendChild(OwnerByVoucherNode);

            XmlNode OwnerByBusinessNode = doc.CreateElement("OwnerByBusiness");
            OwnerByBusinessNode.InnerText = car.OwnerByBusiness.ToString();
            headNode.AppendChild(OwnerByBusinessNode);

            XmlNode FuelCostsNode = doc.CreateElement("FuelCosts");
            FuelCostsNode.InnerText = car.FuelCosts.ToString();
            headNode.AppendChild(FuelCostsNode);

            XmlNode ServiceCostsNode = doc.CreateElement("ServiceCosts");
            ServiceCostsNode.InnerText = car.ServiceCosts.ToString();
            headNode.AppendChild(ServiceCostsNode);

            XmlNode CosmeticsCostsNode = doc.CreateElement("CosmeticsCosts");
            CosmeticsCostsNode.InnerText = car.CosmeticsCosts.ToString();
            headNode.AppendChild(CosmeticsCostsNode);

            XmlNode ComissionNode = doc.CreateElement("Comission");
            ComissionNode.InnerText = car.Comission.ToString();
            headNode.AppendChild(ComissionNode);

            XmlNode CzsNode = doc.CreateElement("Czs");
            CzsNode.InnerText = car.Czs.ToString();
            headNode.AppendChild(CzsNode);

           




            //add to elements collection
            doc.DocumentElement.AppendChild(headNode);

            //save back
            doc.Save(filename);



        }

        public static List<Car> LoadCarsListFromXmlDB() //CHECKED ! WORKS FINE
        {
            List<Car> xmlCarList = new List<Car>();
            XDocument xDoc = XDocument.Load(filename);
            int outParamValue;
            foreach (var d in xDoc.Descendants("Car"))
            {
                var newCar = new Car();
                newCar.Category = d.Element("Category").Value;
                newCar.DateOfCreatingAd = d.Element("DateOfCreatingAd").Value;
                //newCar.ContractNumber = int.TryParse(d.Element("ContractNumber").Value, out outParamValue) ? outParamValue : 1;
                newCar.ContractNumber = int.Parse(d.Element("ContractNumber").Value);
                newCar.Brand = d.Element("Brand").Value;
                newCar.Model = d.Element("Model").Value;
                newCar.BodyworkType = d.Element("BodyworkType").Value;
                newCar.EngineVolumeCc = d.Element("EngineVolumeCc").Value;
                newCar.HorsePower = d.Element("HorsePower").Value;
                newCar.FuelType = d.Element("FuelType").Value;
                newCar.Color = d.Element("Color").Value;
                newCar.ProductionDate = d.Element("ProductionDate").Value;
                newCar.Mileage = d.Element("Mileage").Value;
                newCar.Price = d.Element("Price").Value;
                newCar.AdditionalInfo = d.Element("AdditionalInfo").Value;
                newCar.Vin = d.Element("Vin").Value;
                newCar.Status = d.Element("Status").Value;
                newCar.AutoStartStop = d.Element("AutoStartStop").Value;
                newCar.BluetoothHF = d.Element("BluetoothHF").Value;
                newCar.DvdTv = d.Element("DvdTv").Value;
                newCar.SteptronicTiptronic = d.Element("SteptronicTiptronic").Value;
                newCar.USBAudioVideoAUX = d.Element("USBAudioVideoAUX").Value;
                newCar.AdaptiveAirSusp = d.Element("AdaptiveAirSusp").Value;
                newCar.KeylessGo = d.Element("KeylessGo").Value;
                newCar.DifferentialLock = d.Element("DifferentialLock").Value;
                newCar.ECU = d.Element("ECU").Value;
                newCar.ElMirrors = d.Element("ElMirrors").Value;
                newCar.ElWindows = d.Element("ElWindows").Value;
                newCar.ElAdjustmentSusp = d.Element("ElAdjustmentSusp").Value;
                newCar.DPFFilter = d.Element("DPFFilter").Value;
                newCar.CoolingGlovebox = d.Element("CoolingGlovebox").Value;
                newCar.Stereo = d.Element("Stereo").Value;
                newCar.ElAdjustmentSeats = d.Element("ElAdjustmentSeats").Value;
                newCar.ElSteerAmplifier = d.Element("ElSteerAmplifier").Value;
                newCar.AirConditioning = d.Element("AirConditioning").Value;
                newCar.Climatronic = d.Element("Climatronic").Value;
                newCar.MultifunctionSteer = d.Element("MultifunctionSteer").Value;
                newCar.Navigation = d.Element("Navigation").Value;
                newCar.SteeringHeater = d.Element("SteeringHeater").Value;
                newCar.FrontWindowHeating = d.Element("FrontWindowHeating").Value;
                newCar.Autopilot = d.Element("Autopilot").Value;
                newCar.SeatsHeating = d.Element("SeatsHeating").Value;
                newCar.RainSensor = d.Element("RainSensor").Value;
                newCar.SteeringAdjustment = d.Element("SteeringAdjustment").Value;
                newCar.ServoSteerAmplifier = d.Element("ServoSteerAmplifier").Value;
                newCar.HeadlightsWash = d.Element("HeadlightsWash").Value;
                newCar.HeatingSys = d.Element("HeatingSys").Value;
                newCar.Extras = d.Element("Extras").Value;
                newCar.Gearbox = d.Element("Gearbox").Value;

                if (int.TryParse(d.Element("RealSellingPrice").Value, out outParamValue))
                {
                    newCar.RealSellingPrice = outParamValue;
                }
                if (int.TryParse(d.Element("MinBillValue").Value, out outParamValue))
                {
                    newCar.MinBillValue = outParamValue;
                }
                if (int.TryParse(d.Element("MaxBillValue").Value, out outParamValue))
                {
                    newCar.MaxBillValue = outParamValue;
                }
                newCar.DateOfCreatingAd = d.Element("DateOfCreatingAd").Value;
                newCar.OwnerByVoucher = d.Element("OwnerByVoucher").Value;
                newCar.OwnerByBusiness = d.Element("OwnerByBusiness").Value;
                if (int.TryParse(d.Element("FuelCosts").Value, out outParamValue))
                {
                    newCar.FuelCosts = outParamValue;
                }
                if (int.TryParse(d.Element("ServiceCosts").Value, out outParamValue))
                {
                    newCar.ServiceCosts = outParamValue;
                }
                if (int.TryParse(d.Element("CosmeticsCosts").Value, out outParamValue))
                {
                    newCar.CosmeticsCosts = outParamValue;
                }
                if (int.TryParse(d.Element("Comission").Value, out outParamValue))
                {
                    newCar.Comission = outParamValue;
                }
                if (int.TryParse(d.Element("Czs").Value, out outParamValue))
                {
                    newCar.Czs = outParamValue;
                }


                xmlCarList.Add(newCar);
            }
            //var studentLst = dox.Descendants("Car").Select(d =>
            //    new {
            //              Brand = d.Element("Brand").Value;
            //              Name = d.Element("Model").Value
            //        }).ToList();
            //xmlCarList = xDoc.Descendants("Car").Select(d =>
            //    new Car
            //    {
            //        ContractNumber = int.Parse(d.Element("ContractNumber").Value);
            //        Brand = d.Element("Brand").Value;
            //        Model = d.Element("Model").Value;
            //        BodyworkType = d.Element("BodyworkType").Value;
            //        EngineVolumeCc = d.Element("EngineVolumeCc").Value;
            //        HorsePower = d.Element("HorsePower").Value;
            //        FuelType = d.Element("FuelType").Value;
            //        Color = d.Element("Color").Value;
            //        ProductionDate = d.Element("ProductionDate").Value;
            //        Mileage = d.Element("Mileage").Value;
            //        Price = d.Element("Price").Value;
            //        AdditionalInfo = d.Element("AdditionalInfo").Value;
            //        Win = d.Element("Win").Value;
            //        Status = d.Element("Status").Value;////
            //        AutoStartStop = d.Element("AutoStartStop").Value;
            //        BluetoothHF = d.Element("BluetoothHF").Value;
            //        DvdTv = d.Element("DvdTv").Value;
            //        SteptronicTiptronic = d.Element("SteptronicTiptronic").Value;
            //        USBAudioVideoAUX = d.Element("USBAudioVideoAUX").Value;
            //        AdaptiveAirSusp = d.Element("AdaptiveAirSusp").Value;
            //        KeylessGo = d.Element("KeylessGo").Value;
            //        DifferentialLock = d.Element("DifferentialLock").Value;
            //        ECU = d.Element("ECU").Value;
            //        ElMirrors = d.Element("ElMirrors").Value;
            //        ElWindows = d.Element("ElWindows").Value;
            //        ElAdjustmentSusp = d.Element("ElAdjustmentSusp").Value;
            //        DPFFilter = d.Element("DPFFilter").Value;
            //        CoolingGlovebox = d.Element("CoolingGlovebox").Value;
            //        Stereo = d.Element("Stereo").Value;
            //        ElAdjustmentSeats = d.Element("ElAdjustmentSeats").Value;
            //        ElSteerAmplifier = d.Element("ElSteerAmplifier").Value;
            //        AirConditioning = d.Element("AirConditioning").Value;
            //        Climatronic = d.Element("Climatronic").Value;
            //        MultifunctionSteer = d.Element("MultifunctionSteer").Value;
            //        Navigation = d.Element("Navigation").Value;
            //        SteeringHeater = d.Element("SteeringHeater").Value;
            //        FrontWindowHeating = d.Element("FrontWindowHeating").Value;
            //        Autopilot = d.Element("Autopilot").Value;
            //        SeatsHeating = d.Element("SeatsHeating").Value;
            //        RainSensor = d.Element("RainSensor").Value;
            //        SteeringAdjustment = d.Element("SteeringAdjustment").Value;
            //        ServoSteerAmplifier = d.Element("ServoSteerAmplifier").Value;
            //        HeadlightsWash = d.Element("HeadlightsWash").Value;
            //        HeatingSys = d.Element("HeatingSys").Value;
            //        Extras = d.Element("Extras").Value;
            //        //RealSellingPrice = int.Parse(d.Element("RealSellingPrice").Value);


            //    }).ToList();

            return xmlCarList;

        }

        public static void Remove(object car)
        {
            if (car != null)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                var carConv = (Car)car;
                XmlNodeList nodes = doc.SelectNodes("//Car[ContractNumber='" + carConv.ContractNumber + "']");

                foreach (XmlNode node in nodes)
                {
                    node.ParentNode.RemoveChild(node);
                }

                doc.Save(filename);
            }
        }

        public static void UpdateCarData(Car carToUpdateData, string nodeElement, string newValue) // to do
        {

            if (newValue == null || newValue == string.Empty)
            {
                return;
            }

            int carIndex = carToUpdateData.ContractNumber;

            XDocument xDoc = XDocument.Load(filename);



            var car = xDoc.Descendants("Car")
                            .First(a => a.Element("ContractNumber").Value == carIndex.ToString());


            car.Element(nodeElement).Value = newValue;

            xDoc.Save(filename);

        }

    }
}
