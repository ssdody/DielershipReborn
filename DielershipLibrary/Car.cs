using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DielershipLibrary
{
    [Serializable]
    public class Car
    {   //
        private int _contractNumber = 0;
        private string _category = string.Empty;
        private string _brand = string.Empty;
        private string _model = string.Empty;
        private string _bodywork = string.Empty;
        private string _horsePower = string.Empty;
        private string _fuelType = string.Empty;
        private string _color = string.Empty;
        private string _productionDate = string.Empty;
        private string _mileage = string.Empty;
        private bool _isSold;
        private string _additionalCarInfo = string.Empty;
        private string _price = string.Empty;
        private string _engineVolumeCc = string.Empty;
        private string _vin = string.Empty;
        private string _tires = string.Empty;
        private string _gearbox = string.Empty;
        private string _numberOfKeys = string.Empty;
        //hideable additional price info panel
        private int _realSellingPrice = 0;
        private int _minBillValue = 0;
        private int _maxBillValue = 0;
        private string _dateOfCreatingAd = string.Empty;
        private string _ownerByVoucher = string.Empty;
        private string _ownerByBusiness = string.Empty;
        private int _fuelCosts = 0;
        private int _serviceCosts = 0;
        private int _cosmeticsCosts = 0;
        private int _comission = 0;
        private int _czs = 0;

        //checkboxes
        private string _autoStartStop = string.Empty;
        private string _bluetoothHf = string.Empty;
        private string _dvdTv = string.Empty;
        private string _steptronicTiptronic = string.Empty;
        private string _usbAudioVideoAux = string.Empty;
        private string _adaptiveSusp = string.Empty;
        private string _keylessGo = string.Empty;
        private string _differentialLock = string.Empty;
        private string _ecu = string.Empty;
        private string _elMirrors = string.Empty;
        private string _elWindows = string.Empty;
        private string _elAdjustmentSusp = string.Empty;
        private string _elAdjustmentSeats = string.Empty;
        private string _elSteerAmplifier = string.Empty;
        private string _airConditioning = string.Empty;//"Климатик";
        private string _climatronic = string.Empty;//"Климатроник";
        private string _multifuntionSteer = string.Empty;//"Мултифункционален волан";
        private string _navigation = string.Empty;//"Навигация";
        private string _steeringHeater = string.Empty;// "Отопление на волана";
        private string _heatingSys = string.Empty;//"Печка";
        private string _frontWindowHeating = string.Empty;//"Подгряване на предното стъкло";
        private string _seatsHeating = string.Empty;//"Подгряване на седалките";
        private string _steeringAdjustment = string.Empty;//"Регулиране на волана";
        private string _rainSensor = string.Empty;//"Сензор за дъжд";
        private string _servoSteerAmplifier = string.Empty;//"Серво усилвател на волана";
        private string _headlightWash = string.Empty;//"Система за измиване на фаровете";
        private string _autopilot = string.Empty;//"Автопилот";
        private string _stereo = string.Empty;//"Стерео уредба";
        private string _dpfFilter = string.Empty;// "Филтър за твърди частици";
        private string _coolingGlovebox = string.Empty;//"Хладилна жабка";
        private string _extras = string.Empty;
        private string _status = string.Empty;

        public string AutoStartStop
        {
            get
            {
                return _autoStartStop;
            }
            set
            {
                _autoStartStop = value;
            }
        }
        public string BluetoothHF
        {
            get
            {
                return _bluetoothHf;
            }
            set
            {
                _bluetoothHf = value;
            }
        }
        public string DvdTv
        {
            get
            {
                return _dvdTv;
            }
            set
            {
                _dvdTv = value;
            }
        }
        public string SteptronicTiptronic
        {
            get
            {
                return _steptronicTiptronic;
            }
            set
            {
                _steptronicTiptronic = value;
            }
        }
        public string USBAudioVideoAUX
        {
            get
            {
                return _usbAudioVideoAux;
            }
            set
            {
                _usbAudioVideoAux = value;
            }
        }
        public string AdaptiveAirSusp
        {
            get
            {
                return _adaptiveSusp;
            }
            set
            {
                _adaptiveSusp = value;
            }
        }
        public string KeylessGo
        {
            get
            {
                return _keylessGo;
            }
            set
            {
                _keylessGo = value;
            }
        }
        public string DifferentialLock
        {
            get
            {
                return _differentialLock;
            }
            set
            {
                _differentialLock = value;
            }
        }
        public string ECU
        {
            get
            {
                return _ecu;
            }
            set
            {
                _ecu = value;
            }
        }
        public string ElMirrors
        {
            get
            {
                return _elMirrors;
            }
            set
            {
                _elMirrors = value;
            }
        }
        public string ElWindows
        {
            get
            {
                return _elWindows;
            }
            set
            {
                _elWindows = value;
            }
        }
        public string ElAdjustmentSusp
        {
            get
            {
                return _elAdjustmentSusp;
            }
            set
            {
                _elAdjustmentSusp = value;
            }
        }
        public string DPFFilter
        {
            get
            {
                return _dpfFilter;
            }
            set
            {
                _dpfFilter = value;
            }
        }
        public string CoolingGlovebox
        {
            get
            {
                return _coolingGlovebox;
            }
            set
            {
                _coolingGlovebox = value;
            }
        }
        public string Stereo
        {
            get
            {
                return _stereo;
            }
            set
            {
                _stereo = value;
            }
        }
        public string ElAdjustmentSeats
        {
            get
            {
                return _elAdjustmentSeats;
            }
            set
            {
                _elAdjustmentSeats = value;
            }
        }
        public string ElSteerAmplifier
        {
            get
            {
                return _elSteerAmplifier;
            }
            set
            {
                _elSteerAmplifier = value;
            }
        }
        public string AirConditioning
        {
            get
            {
                return _airConditioning;
            }
            set
            {
                _airConditioning = value;
            }
        }
        public string Climatronic
        {
            get
            {
                return _climatronic;
            }
            set
            {
                _climatronic = value;
            }
        }
        public string MultifunctionSteer
        {
            get
            {
                return _multifuntionSteer;
            }
            set
            {
                _multifuntionSteer = value;
            }
        }
        public string Navigation
        {
            get
            {
                return _navigation;
            }
            set
            {
                _navigation = value;
            }
        }
        public string SteeringHeater
        {
            get
            {
                return _steeringHeater;
            }
            set
            {
                _steeringHeater = value;
            }
        }
        public string FrontWindowHeating
        {
            get
            {
                return _frontWindowHeating;
            }
            set
            {
                _frontWindowHeating = value;
            }
        }
        public string Autopilot
        {
            get
            {
                return _autopilot;
            }
            set
            {
                _autopilot = value;
            }
        }
        public string SeatsHeating
        {
            get
            {
                return _seatsHeating;
            }
            set
            {
                _seatsHeating = value;
            }
        }
        public string RainSensor
        {
            get
            {
                return _rainSensor;
            }
            set
            {
                _rainSensor = value;
            }
        }
        public string SteeringAdjustment
        {
            get
            {
                return _steeringAdjustment;
            }
            set
            {
                _steeringAdjustment = value;
            }
        }
        public string ServoSteerAmplifier
        {
            get
            {
                return _servoSteerAmplifier;
            }
            set
            {
                _servoSteerAmplifier = value;
            }
        }
        public string HeadlightsWash
        {
            get
            {
                return _headlightWash;
            }
            set
            {
                _headlightWash = value;
            }
        }
        public string HeatingSys
        {
            get
            {
                return _heatingSys;
            }
            set
            {
                _heatingSys = value;
            }
        }
        public string Extras
        {
            get
            {
                return _extras;
            }

            set
            {
                _extras = value;
            }
        }


        [System.Xml.Serialization.XmlElement("Brand")]
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                if (value.Count() < 2 || string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Invalid brand digit lenght !");
                    return;
                }
                else
                    _brand = value.ToUpper();
            }
        }
        [System.Xml.Serialization.XmlElement("Model")]
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                else
                    _model = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Bodytype")]
        public string BodyworkType
        {
            get
            {
                return _bodywork;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    value = "----";
                }
                else
                    _bodywork = FirstLetterToUpperCaseOrConvertNullToEmptyString(value);
            }
        }
        [System.Xml.Serialization.XmlElement("HorsePower")]
        public string HorsePower
        {
            get
            {
                return _horsePower;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    value = "----";
                }
                else
                    _horsePower = value;
            }
        }
        [System.Xml.Serialization.XmlElement("FuelType")]
        public string FuelType
        {
            get
            {
                return _fuelType;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    value = "----";

                }
                else
                    _fuelType = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Color")]
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    value = "----";
                }
                else
                {
                    _color = FirstLetterToUpperCaseOrConvertNullToEmptyString(value);

                }
            }
        }
        [System.Xml.Serialization.XmlElement("ProductionDate")]
        public string ProductionDate
        {
            get
            {
                return _productionDate;
            }
            set
            {
                if (value == null)
                {
                    value = "----";
                }
                else
                {
                    _productionDate = value;

                }
            }
        }
        [System.Xml.Serialization.XmlElement("Mileage")]
        public string Mileage
        {
            get
            {
                return _mileage;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                else
                    _mileage = value;
            }
        }
        [System.Xml.Serialization.XmlElement("IsSold")]
        public bool IsSold
        {
            get
            {
                return _isSold;
            }
            set
            {
                _isSold = value;
            }
        }
        [System.Xml.Serialization.XmlElement("AdditionalCarInfo")]
        public string AdditionalInfo
        {
            get
            {
                return _additionalCarInfo;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "----";
                }
                else
                    _additionalCarInfo = value;
            }
        }
        [System.Xml.Serialization.XmlElement("ContractNumber")]
        public int ContractNumber
        {
            get
            {
                return _contractNumber;
            }
            set
            {
                _contractNumber = value;
            }

        }
        [System.Xml.Serialization.XmlElement("Price")]
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _price = "0";
                    return;
                }
                _price = value;
            }
        }
        [System.Xml.Serialization.XmlElement("EngineVolumeCc")]
        public string EngineVolumeCc
        {
            get
            {
                return _engineVolumeCc;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _engineVolumeCc = "----";

                }
                else
                    _engineVolumeCc = value;
            }
        }
        [System.Xml.Serialization.XmlElement("WIN")]
        public string Vin
        {
            get
            {
                return _vin;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _vin = "----";
                }
                else
                    _vin = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Status")]
        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    _status = "Неясен";
                }
                else
                {
                    _vin = value;

                }
            }
        }
        [System.Xml.Serialization.XmlElement("Tires")]
        public string Tires
        {
            get
            {
                return _tires;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    _tires = string.Empty;
                }
                else
                {
                    _tires = value;

                }
            }
        }
        [System.Xml.Serialization.XmlElement("NumberOfKeys")]
        public string NumberOfKeys
        {
            get
            {
                return _numberOfKeys;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _numberOfKeys = "1";
                }
                else
                {
                    _numberOfKeys = value;
                }
            }
        }
        [System.Xml.Serialization.XmlElement("Category")]
        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _category = string.Empty;
                }
                else
                {
                    _category = value;

                }
            }
        }
        [System.Xml.Serialization.XmlElement("Gearbox")]
        public string Gearbox
        {
            get
            {
                return _gearbox;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    _gearbox = string.Empty;
                }
                else
                {
                    _gearbox = value;

                }
            }
        }
        [System.Xml.Serialization.XmlElement("RealSellingPrice")]
        public int RealSellingPrice
        {
            get
            {
                return _realSellingPrice;
            }


            set
            {


                _realSellingPrice = value;

            }
        }
        [System.Xml.Serialization.XmlElement("MinBillValue")]
        public int MinBillValue
        {
            get
            {
                return _minBillValue;
            }

            set
            {
                _minBillValue = value;
            }
        }
        [System.Xml.Serialization.XmlElement("MaxBillValue")]
        public int MaxBillValue
        {
            get
            {
                return _maxBillValue;
            }

            set
            {
                _maxBillValue = value;
            }
        }
        [System.Xml.Serialization.XmlElement("DateOfCreatingAd")]
        public string DateOfCreatingAd
        {
            get
            {
                return _dateOfCreatingAd;
            }

            set
            {
                _dateOfCreatingAd = value;
            }
        }
        [System.Xml.Serialization.XmlElement("OwnerByVoucher")]
        public string OwnerByVoucher
        {
            get
            {
                return _ownerByVoucher;
            }

            set
            {
                if ((string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)))
                {
                    _ownerByVoucher = string.Empty;
                }
                else
                {
                    _ownerByVoucher = value;

                }
                _ownerByVoucher = value;
            }
        }
        [System.Xml.Serialization.XmlElement("OwnerByBusiness")]
        public string OwnerByBusiness
        {
            get
            {
                return _ownerByBusiness;
            }

            set
            {
                if ((string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)))
                {
                    _ownerByBusiness = string.Empty;
                }
                else
                {
                    _ownerByBusiness = value;

                }
            }
        }
        [System.Xml.Serialization.XmlElement("FuelCosts")]
        public int FuelCosts
        {
            get
            {
                return _fuelCosts;
            }

            set
            {
                _fuelCosts = value;
            }
        }
        [System.Xml.Serialization.XmlElement("ServiceCosts")]
        public int ServiceCosts
        {
            get
            {
                return _serviceCosts;
            }

            set
            {
                _serviceCosts = value;
            }
        }
        [System.Xml.Serialization.XmlElement("CosmeticsCosts")]
        public int CosmeticsCosts
        {
            get
            {
                return _cosmeticsCosts;
            }

            set
            {
                _cosmeticsCosts = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Comission")]
        public int Comission
        {
            get
            {
                return _comission;
            }

            set
            {
                _comission = value;
            }
        }
        [System.Xml.Serialization.XmlElement("Czs")]
        public int Czs
        {
            get
            {
                return _czs;
            }

            set
            {
                _czs = value;
            }
        }


        public Car()
        {

        }
        public Car(int contractNumber)
        {
            this._contractNumber = contractNumber;

        }




        public string Display
        {
            get
            {
                return string.Format("#{0}      {1} {2} {3}", ContractNumber, Brand, Model, ProductionDate);
            }
        }

        public static string FirstLetterToUpperCaseOrConvertNullToEmptyString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            char[] result = value.ToCharArray();
            result[0] = char.ToUpper(result[0]);
            return new string(result);
        }


    }
}

