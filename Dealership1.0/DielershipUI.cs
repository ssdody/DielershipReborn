namespace Dealership1._0
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using DielershipLibrary.Contracts;
    using DielershipLibrary.CarModelsLists;
    using DielershipLibrary;
    using Properties;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Drawing.Imaging;

    /// <summary>
    /// Dielership Main
    /// </summary>
    public partial class DielershipUI : Form, IClearTextboxes
    {
        //private Dieler dieler = new Dieler();
        private List<Car> soldCarsList = new List<Car>();
        private BindingSource carsListBinding = new BindingSource();
        private BindingSource soldCarsListBinding = new BindingSource();
        private int contractNumber;

        public DielershipUI()
        {
            this.InitializeComponent();
            this.SetupData();

            ////carsBinding.DataSource = dieler.CarsList.Where(x => x.IsSold == false).ToList();
            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();

            carsListBox.DataSource = this.carsListBinding;

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";

            HidablePricePanel.Visible = false;
            //MenuStrip menuStrip = new MenuStrip();
        }
        //// setupData empty
        private void SetupData()
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (BrandsComboBox.SelectedItem == null || ModelCombobox.SelectedItem == null)
            {
                MessageBox.Show("Трябва да избереш поне марка и модел!");
                return;
            }
            var id = this.NextContractNumber();
            Car newCar = new Car(id);
            newCar.Brand = BrandsComboBox.SelectedItem.ToString();//brandTextBox.Text;
            newCar.Model = ModelCombobox.SelectedItem.ToString();//modelTextBox.Text;
            newCar.BodyworkType = CategoryCombobox.SelectedItem.ToString();//typeTextBox.Text;
            newCar.EngineVolumeCc = EngineVolumeCCTextBox.Text;
            newCar.HorsePower = horsePowerTextBox.Text;
            newCar.FuelType = FuelTypeCombobox.SelectedItem.ToString();//fuelTypeTextBox.Text;
            newCar.Color = ColorsCombobox.SelectedItem.ToString();/*colorTextBox.Text*/;
            newCar.ProductionDate = productionDateTextBox.Text;
            newCar.Mileage = mileageTextBox.Text;
            newCar.Price = priceTextBox.Text;
            newCar.AdditionalInfo = additionalCarInfoTextBox.Text;
            newCar.Win = WinTextBox.Text;
            newCar.IsSold = false;
            newCar.Status = StatusCombobox.SelectedItem.ToString();
            //this.AddExtrasToCarExtrasFieldIfChecked(newCar);

            XMLDatabase.AppendNewCarDataToXML(newCar); // works fine

            this.carsListBinding.ResetBindings(false);


            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();

            this.ClearTextboxesAndComboboxes();
            //this.UncheckCheckboxes();

        }

        public void UpdateCarData(Car carToUpdateData) // to do
        {
            int carIndex = carToUpdateData.ContractNumber;

            XDocument xDoc = XDocument.Load("data.xml");



            var xElemAgent = xDoc.Descendants("Car")
                            .First(a => a.Element("ContractNumber").Value == carIndex.ToString());


            xElemAgent.Element("Price").Value = "5555555";

            xDoc.Save("data.xml");

        }

        //private void UncheckCheckboxes()
        //{
        //    AutoStartStopCheckBox.Checked = false;
        //    BluetoothHFCheckbox.Checked = false;
        //    DvdTvCheckbox.Checked = false;
        //    SteptronicTiptronicCheckbox.Checked = false;
        //    USBAudioVideoAUXCheckbox.Checked = false;
        //    AdaptiveAirSuspCheckbox.Checked = false;
        //    KeylessGoCheckbox.Checked = false;
        //    DifferentialLockCheckbox.Checked = false;
        //    ECUCheckbox.Checked = false;
        //    ElMirrorsCheckbox.Checked = false;
        //    ElWindowsCheckbox.Checked = false;
        //    ElAdjustmentSuspCheckbox.Checked = false;
        //    DPFFilterCheckbox.Checked = false;
        //    CoolingGloveboxCheckbox.Checked = false;
        //    StereoCheckbox.Checked = false;
        //    ElAdjustmentSeatsCheckbox.Checked = false;
        //    ElSteerAmplifierCheckbox.Checked = false;
        //    AirConditioningCheckbox.Checked = false;
        //    ClimatronicCheckbox.Checked = false;
        //    MultifunctionSteerCheckbox.Checked = false;
        //    NavigationCheckbox.Checked = false;
        //    SteeringHeaterCheckbox.Checked = false;
        //    FrontWindowHeatingCheckbox.Checked = false;
        //    AutopilotCheckbox.Checked = false;
        //    SeatsHeatingCheckbox.Checked = false;
        //    RainSensorCheckbox.Checked = false;
        //    SteeringAdjustmentCheckbox.Checked = false;
        //    ServoSteerAmplifierCheckbox.Checked = false;
        //    HeadlightsWashCheckbox.Checked = false;
        //    HeatingSysCheckbox.Checked = false;
        //}

        ////private void DeserializeXMLDatabase()
        ////{
        ////    if (!File.Exists("data.xml"))
        ////    {
        ////        XmlSerializer xSerializer = new XmlSerializer(typeof(Car));
        ////        using (FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
        ////        {
        ////            Car xmlCar = (Car)xSerializer.Deserialize(read);
        ////            dieler.CarsList.Add(xmlCar);
        ////        }
        ////    }
        //
        ////}

        private void soldButton_Click(object sender, EventArgs e)
        {

            // copy item to soldCarsList
            // erase from carsList
            if (carsListBox.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Check", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Car selectedCar = (Car)carsListBox.SelectedItem;
                    var selectedCarPrice = int.Parse(selectedCar.Price);
                    Settings.Default.MonthlyProfit += selectedCarPrice;
                    Settings.Default.Save();


                    XMLDatabase.Remove(carsListBox.SelectedItem);
                    this.soldCarsList.Add(selectedCar);
                    this.soldCarsListBinding.ResetBindings(false);

                    this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();
                    carsListBox.Refresh();
                    carsListBox.ClearSelected();

                    ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + "$";
                }
                else
                {
                    return;
                }
            }
        }

        //private void AddExtrasToCarExtrasFieldIfChecked(Car car)
        //{
        //    var tempBuilder = new StringBuilder();
        //    List<CheckBox> checkboxList = new List<CheckBox>();
        //    checkboxList.Add(AlluminRimsCheckbox);
        //    checkboxList.Add(BrakeAssistCheckbox);
        //    checkboxList.Add(BluetoothHFCheckbox);
        //    checkboxList.Add(BarterCheckbox);
        //    checkboxList.Add(AutoStartStopCheckBox);
        //    checkboxList.Add(AutopilotCheckbox);
        //    checkboxList.Add(AutoGasSysCheckbox);
        //    checkboxList.Add(ASRCheckbox);
        //    checkboxList.Add(ASCCheckbox);
        //    checkboxList.Add(AirConditioningCheckbox);
        //    checkboxList.Add(AigBagSysCheckbox);
        //    checkboxList.Add(AdaptiveAirSuspCheckbox);
        //    checkboxList.Add(HeatingSysCheckbox);
        //    checkboxList.Add(CoolingGloveboxCheckbox);
        //    checkboxList.Add(DPFFilterCheckbox);
        //    checkboxList.Add(StereoCheckbox);
        //    checkboxList.Add(HeadlightsWashCheckbox);
        //    checkboxList.Add(ServoSteerAmplifierCheckbox);
        //    checkboxList.Add(SteeringAdjustmentCheckbox);
        //    checkboxList.Add(SeatsHeatingCheckbox);
        //    checkboxList.Add(RainSensorCheckbox);
        //    checkboxList.Add(FrontWindowHeatingCheckbox);
        //    checkboxList.Add(NavigationCheckbox);
        //    checkboxList.Add(SteeringHeaterCheckbox);
        //    checkboxList.Add(MultifunctionSteerCheckbox);
        //    checkboxList.Add(ClimatronicCheckbox);
        //    checkboxList.Add(ElSteerAmplifierCheckbox);
        //    checkboxList.Add(ElAdjustmentSeatsCheckbox);
        //    checkboxList.Add(ElAdjustmentSuspCheckbox);
        //    checkboxList.Add(ElMirrorsCheckbox);
        //    checkboxList.Add(ElWindowsCheckbox);
        //    checkboxList.Add(ECUCheckbox);
        //    checkboxList.Add(DifferentialLockCheckbox);
        //    checkboxList.Add(KeylessGoCheckbox);
        //    checkboxList.Add(USBAudioVideoAUXCheckbox);
        //    checkboxList.Add(SteptronicTiptronicCheckbox);
        //    checkboxList.Add(DvdTvCheckbox);
        //    checkboxList.Add(InStockCheckbox);
        //    checkboxList.Add(LeasingCheckbox);
        //    checkboxList.Add(MethanSysCheckbox);
        //    checkboxList.Add(NewImportCheckbox);
        //    checkboxList.Add(SevenSeatsCheckbox);
        //    checkboxList.Add(ServiceBookCheckbox);
        //    checkboxList.Add(TuningCheckbox);
        //    checkboxList.Add(FullServicedCheckbox);
        //    checkboxList.Add(RegisteredCheckbox);
        //    checkboxList.Add(FourWheelDriveCheckbox);
        //    checkboxList.Add(MetallicCheckbox);
        //    checkboxList.Add(FourOrFiveDoorsCheckbox);
        //    checkboxList.Add(HeatingWipesCheckbox);
        //    checkboxList.Add(XenonHeadlightsCheckbox);
        //    checkboxList.Add(SpoilerCheckbox);
        //    checkboxList.Add(PanoramicHatchCheckbox);
        //    checkboxList.Add(LedHeadlightsCheckbox);
        //    checkboxList.Add(DrawbarCheckbox);
        //    checkboxList.Add(DSACheckbox);
        //    checkboxList.Add(DistronicCheckbox);
        //    checkboxList.Add(DryBrakeSysCheckbox);
        //    checkboxList.Add(ISOFIXCheckbox);
        //    checkboxList.Add(SmartTireCheckbox);
        //    checkboxList.Add(ParktronicCheckbox);
        //    checkboxList.Add(ESPCheckbox);
        //    checkboxList.Add(ABSCheckbox);
        //    checkboxList.Add(AdaptiveFrontLightsCheckbox);
        //    checkboxList.Add(GPSCheckbox);
        //    checkboxList.Add(TwoOrThreeDoorsCheckbox);
        //    checkboxList.Add(HalogenLightsCheckbox);
        //    checkboxList.Add(ShuttleCheckbox);


        //    foreach (var box in checkboxList)
        //    {
        //        if (box.Checked == true)
        //        {
        //            tempBuilder.Append(box.Text + "$");
        //        }
        //    }

        //    car.Extras += tempBuilder.ToString();
        //    ////if (this.AutoStartStopCheckBox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Auto start stop function" + "$");
        //    ////    //car.Extras += "Auto start stop function";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.BluetoothHFCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Bluetooth , handsfree система" + "$");
        //    ////    //car.Extras += "Bluetooth , handsfree система";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.DvdTvCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("DVD, TV" + "$");
        //    ////    //car.Extras += "DVD, TV";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.SteptronicTiptronicCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Steptronic, Tiptronic" + "$");
        //    ////    //car.Extras += "Steptronic, Tiptronic";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.USBAudioVideoAUXCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("USB, audio video, IN AUX изводи" + "$");
        //    ////    //car.Extras += "USB, audio video, IN AUX изводи";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.AdaptiveAirSuspCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Адаптивно въздушно окачване" + "$");
        //    ////    //car.Extras += "Адаптивно въздушно окачване";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.KeylessGoCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Безключово палене" + "$");
        //    ////    //car.Extras += "Безключово палене";
        //    ////    //car.Extras += "$";

        //    ////}

        //    ////if (this.DifferentialLockCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Блокаж на диференциала" + "$");
        //    ////    //car.Extras += "Блокаж на диференциала";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.ECUCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Бордкомпютър" + "$");
        //    ////    //car.Extras += "Бордкомпютър";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.ElMirrorsCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Ел. Огледала" + "$");
        //    ////    //car.Extras += "Ел. Огледала";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.ElWindowsCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Ел.стъкла" + "$");
        //    ////    //car.Extras += "Ел.стъкла";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.ElAdjustmentSuspCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Ел. регулиране на окачването" + "$");
        //    ////    //car.Extras += "Ел. регулиране на окачването";
        //    ////    //car.Extras += "$";
        //    ////}

        //    ////if (this.DPFFilterCheckbox.Checked)
        //    ////{
        //    ////    tempBuilder.Append("Филтър за твърди частици" + "$");
        //    ////    car.Extras += "Филтър за твърди частици";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.CoolingGloveboxCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Хладилна жабка";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.StereoCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Стерео уредба";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.ElAdjustmentSeatsCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Ел. регулиране на седалките";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.ElSteerAmplifierCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Ел. усилвател на волана";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.AirConditioningCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Климатик";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.ClimatronicCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Климатроник";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.MultifunctionSteerCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Мултифункционален волан";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.NavigationCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Навигация";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.SteeringHeaterCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Отопление на волана";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.FrontWindowHeatingCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Подгряване на предното стъкло";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.AutopilotCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Автопилот";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.SeatsHeatingCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Подгряване на седалките";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.RainSensorCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Сензор за дъжд";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.SteeringAdjustmentCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Регулиране на волана";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.ServoSteerAmplifierCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Серво усилвател на волана";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.HeadlightsWashCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Система за измиване на фаровете";
        //    ////    car.Extras += "$";
        //    ////}

        //    ////if (this.HeatingSysCheckbox.Checked)
        //    ////{
        //    ////    car.Extras += "Печка";
        //    ////    car.Extras += "$";
        //    ////}
        //}

        private void clearSoldCarsButton_Click(object sender, EventArgs e)
        {
            ////mark item as sold 
            ////clear soldCarsList

            foreach (var item in soldCarsList)
            {
                if (item == null)
                {
                    return;
                }

                item.IsSold = true;
            }

            this.soldCarsList.Clear();
            //this.carsBinding.DataSource = this.dieler.CarsList.Where(x => x.IsSold == false).ToList();

            this.soldCarsListBinding.ResetBindings(false);
            this.carsListBinding.ResetBindings(false);
        }

        public void ClearTextboxesAndComboboxes() // WORKS FINE
        {
            BrandsComboBox.SelectedIndex = -1;
            GearboxesCombobox.SelectedIndex = -1;
            ModelCombobox.SelectedIndex = -1;
            CategoryCombobox.SelectedIndex = -1;
            FuelTypeCombobox.SelectedIndex = -1;
            StatusCombobox.SelectedIndex = -1;
            ColorsCombobox.SelectedIndex = -1;


            EngineVolumeCCTextBox.Clear();
            horsePowerTextBox.Clear();

            productionDateTextBox.Clear();

            mileageTextBox.Clear();

            additionalCarInfoTextBox.Clear();

            priceTextBox.Clear();

            WinTextBox.Clear();

            ContractNumberLabel.Text = "#---";
        }

        public void TextboxesReadOnlyOrNot(bool condition) //// out of date
        {
            horsePowerTextBox.ReadOnly = condition;
            productionDateTextBox.ReadOnly = condition;
            mileageTextBox.ReadOnly = condition;
            additionalCarInfoTextBox.ReadOnly = condition;
            priceTextBox.ReadOnly = condition;
            EngineVolumeCCTextBox.ReadOnly = condition;
            WinTextBox.ReadOnly = condition;
        }

        private int NextContractNumber()
        {
            int result = int.Parse(Settings.Default["NumOfContracts"].ToString());
            Settings.Default["NumOfContracts"] = result + 1;
            Settings.Default.Save();
            return ++result;
        }



        private void carsListBox_DoubleClick(object sender, EventArgs e) //// WORK FINE
        {
            if (carsListBox.Items.Count > 0 && carsListBox.SelectedItem != null)
            {
                InfoForm infoForm = new InfoForm();

                infoForm.FillInfoFormTextbox(carsListBox.SelectedItem);

                infoForm.Show();

                ////soldCarsListBox.ClearSelected();
            }
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mileageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EngineVolumeCCTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void horsePowerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void WinTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            WinTextBox.CharacterCasing = CharacterCasing.Upper;
        }

        private void DielershipUI_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void DielershipUI_Load(object sender, EventArgs e)
        {
            carsListBox.Update();

            this.contractNumber = int.Parse(Settings.Default["NumOfContracts"].ToString());

            ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + " $";

            carsListBox.ClearSelected();
        }

        private void ResetProfitLabelButton_Click(object sender, EventArgs e)
        {
            Settings.Default.MonthlyProfit = 0;
            ProfitLabel.Text = Settings.Default.MonthlyProfit.ToString() + "$";
            Settings.Default.Save();
        }

        private void BrandsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (BrandsComboBox.SelectedItem.ToString())
            {
                case "Audi":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.AudiModels);
                    break;
                case "BMW":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.BMWModels);
                    break;
                case "Porsche":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.PorscheModels);
                    break;
                case "Mercedes":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.MercedesModels);
                    break;
                case "Volkswagen":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.VolkswagenModels);
                    break;
                case "Peugeot":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.PeugeotModels);
                    break;
                case "Alfa Romeo":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.AlfaRomeoModels);
                    break;
                case "Fiat":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.FiatModels);
                    break;
                case "Citroen":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.CitroenModels);
                    break;
                case "Ferrari":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.FerrariModels);
                    break;
            }
        } // todo

        private void UpdateButton_Click(object sender, EventArgs e)
        {


            if (StatusRadioButton.Checked)
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "Status", StatusCombobox.SelectedItem.ToString());
                MessageBox.Show("Готово!", "Промяна", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                StatusRadioButton.Checked = false;

            }
            else if (PriceRadioButton.Checked)
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "Price", priceTextBox.Text);
                MessageBox.Show("Готово!");
                PriceRadioButton.Checked = false;

            }
            else
            {
                MessageBox.Show("Нещо не е както трябва, опитай пак!");

            }
            ClearTextboxesAndComboboxes();
            //XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem,);
            //UpdateCarData((Car)carsListBox.SelectedItem);
        }

        private void StatusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (carsListBox.SelectedItem == null)
            {
                MessageBox.Show("Не е избран автомобил!", "Промяна", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                
            }
        }

        private void HidePricePanelButton_Click(object sender, EventArgs e)
        {
            if (HidablePricePanel.Visible == true)
            {
                HidablePricePanel.Visible = false;
            }
            else if (HidablePricePanel.Visible == false)
            {
                HidablePricePanel.Visible = true;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e) // OK! 05.02.18
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (carsListBox.SelectedItem == null)
            {
                MessageBox.Show("Избери автомобил от списъка!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.ShowDialog();

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    string fileName = ofd.FileName;
                    Image imageFromFile = Image.FromFile(fileName);
                    pictureBox1.Image = imageFromFile;

                }
                else
                {
                    return;
                }


            }
            


        }

        private void SaveImageButton_Click(object sender, EventArgs e) // OK! 05.02.18
        {
            Car currCar = (Car)carsListBox.SelectedItem;
            if (pictureBox1.Image != null && currCar != null)
            {

                int carNumber = currCar.ContractNumber;
                if (Directory.Exists($"..\\Images\\{carNumber}"))
                {

                    string fileName = carNumber.ToString();
                    if (File.Exists($"..\\Images\\{carNumber}\\{carNumber}.jpeg"))
                    {
                        System.IO.File.Move($"..\\Images\\{carNumber}\\{carNumber}.jpeg", $"..\\Images\\{carNumber}\\{carNumber}" + $"{DateTime.Now.Second}" + ".jpeg");
                    }
                    

                    pictureBox1.Image.Save($"..\\Images\\{carNumber}\\{fileName}" + ".jpeg", ImageFormat.Jpeg);
                    

                    //pictureBox1.Image.Save($"..\\Images\\{carNumber}\\{fileName}.jpeg", ImageFormat.Jpeg);

                }
                else
                {
                    Directory.CreateDirectory($"..\\Images\\{currCar.ContractNumber}");

                    string fileName = carNumber.ToString() + "1";
                    while (File.Exists($"{carNumber}" + "1"))
                    {
                        fileName += "1";
                    }
                    pictureBox1.Image.Save($"..\\Images\\{carNumber}\\{fileName}" + "1" + ".jpeg", ImageFormat.Jpeg);


                    //pictureBox1.Image.Save($"..\\Images\\{carNumber}.jpeg", ImageFormat.Jpeg);
                }
                pictureBox1.Image = null;


            }
        }
    }
}

