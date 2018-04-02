using System.Xml.Serialization;
using DielershipLibrary;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System;

namespace Dealership1._0
{
    public class XMLDatabase
    {
        private static XmlSerializer seriliazer = new XmlSerializer(typeof(Car));
        private const string filename = "data.xml";
        private XMLDatabase()
        {

        }
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

            XmlNode PayCaseNode = doc.CreateElement("PayCase");
            PayCaseNode.InnerText = car.PayCase.ToString();
            headNode.AppendChild(PayCaseNode);

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

            XmlNode isSoldNode = doc.CreateElement("IsSold");
            isSoldNode.InnerText = car.IsSold;
            headNode.AppendChild(isSoldNode);

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
            TiresNode.InnerText = car.TYres.ToString();
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
            FuelCostsNode.InnerText = car.FuelCosts;
            headNode.AppendChild(FuelCostsNode);

            XmlNode ServiceCostsNode = doc.CreateElement("ServiceCosts");
            ServiceCostsNode.InnerText = car.ServiceCosts.ToString();
            headNode.AppendChild(ServiceCostsNode);

            XmlNode CosmeticsCostsNode = doc.CreateElement("CosmeticsCosts");
            CosmeticsCostsNode.InnerText = car.CosmeticsCosts;
            headNode.AppendChild(CosmeticsCostsNode);

            XmlNode ComissionNode = doc.CreateElement("Comission");
            ComissionNode.InnerText = car.Comission;
            headNode.AppendChild(ComissionNode);

            XmlNode CzsNode = doc.CreateElement("Czs");
            CzsNode.InnerText = car.Czs.ToString();
            headNode.AppendChild(CzsNode);

            XmlNode AreMileageRealNode = doc.CreateElement("AreMileageReal");
            AreMileageRealNode.InnerText = car.AreMileageReal.ToString();
            headNode.AppendChild(AreMileageRealNode);

            XmlNode CountryNode = doc.CreateElement("Country");
            CountryNode.InnerText = car.Country;
            headNode.AppendChild(CountryNode);

            XmlNode RegistrationNumberNode = doc.CreateElement("RegistrationNumber");
            RegistrationNumberNode.InnerText = car.RegistrationNumber;
            headNode.AppendChild(RegistrationNumberNode);

            XmlNode ShoferNode = doc.CreateElement("Shofer");
            ShoferNode.InnerText = car.Shofer;
            headNode.AppendChild(ShoferNode);

            //add to elements collection
            doc.DocumentElement.AppendChild(headNode);

            //save back
            doc.Save(filename);



        }

        public static List<Car> LoadCarsListFromXmlDB() //CHECKED ! WORKS FINE
        {

            XDocument xDoc = new XDocument(new XElement("Car"));
            if (!File.Exists(filename))
            {

                xDoc.Save(filename, SaveOptions.None);
            }

            List<Car> xmlCarList = new List<Car>();
            xDoc = XDocument.Load(filename);

            if (!xDoc.Root.Elements().Any())
            {
                return xmlCarList;
            }

            int outParamValue = 0;
            foreach (var d in xDoc.Descendants("Car"))
            {
                var newCar = new Car();
                newCar.Category = d.Element("Category").Value;
                newCar.DateOfCreatingAd = d.Element("DateOfCreatingAd").Value;
                newCar.PayCase = d.Element("PayCase").Value;
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

                newCar.IsSold = d.Element("IsSold").Value;

                newCar.Extras = d.Element("Extras").Value;
                newCar.Gearbox = d.Element("Gearbox").Value;
                newCar.NumberOfKeys = d.Element("NumberOfKeys").Value;
                newCar.TYres = d.Element("Tires").Value;

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
                newCar.FuelCosts = d.Element("FuelCosts").Value;
                newCar.ServiceCosts = d.Element("ServiceCosts").Value;
                newCar.CosmeticsCosts = d.Element("CosmeticsCosts").Value;
                newCar.Comission = d.Element("Comission").Value;
                newCar.Czs = d.Element("Czs").Value;
                newCar.AreMileageReal = d.Element("AreMileageReal").Value;
                newCar.Country = d.Element("Country").Value;
                newCar.RegistrationNumber = d.Element("RegistrationNumber").Value;
                newCar.Shofer = d.Element("Shofer").Value;

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
            car.SetElementValue(nodeElement, newValue);

            //car.Element(nodeElement).Value = newValue;

            xDoc.Save(filename);

        }

    }
}
