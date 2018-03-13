namespace Dealership1._0
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using DielershipLibrary.CarModelsLists;
    using DielershipLibrary;
    using Properties;
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Diagnostics;
    using System.Net.NetworkInformation;

    /// <summary>
    /// Dielership Main
    /// </summary>
    public partial class DielershipUIForm : Form
    {
        private BindingSource carsListBinding = new BindingSource();
        private int contractNumber;
        private bool IsInfoShowed;
        private string logPath = "..\\Log.txt";
        public readonly string[] authorized = { "0026C7DFBD78", "002522C628DD" };
        private readonly string mac = string.Empty;

        public DielershipUIForm()
        {

            this.InitializeComponent();

            ////login form
            mac = GetMacAddress();
            bool IsAuth = false;
            foreach (var auth in authorized)
            {
                if (auth.ToLower() == mac.ToLower())
                {
                    IsAuth = true;
                    break;
                }
            }
            if (!IsAuth)
            {
                MessageBox.Show("You are not authorized!");
                Environment.Exit(1);
            }

            //login form
            //LogInForm logForm = new LogInForm();
            //logForm.ShowDialog();


            //while (!IsAuth)
            //{
            //    this.Enabled = false;
            //    IsAuth = LogInForm.CanContinue;
            //}
            //this.Enabled = true;
            ////

            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();

            carsListBox.DataSource = this.carsListBinding;

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";

            HideOrShowPrivateOptions(false);
            SetHidablePricePanelTextboxesToDefaultValue();




        }
        //// setupData empty
        private void SetupData()
        {

        }
        //buttonClick
        private void addButton_Click(object sender, EventArgs e)
        {
            Log("addButton() clicked!");
            if (IsInfoShowed == true)
            {
                this.ClearTextboxesAndComboboxes();
                MainPicturebox.Image = null;
                this.SetHidablePricePanelTextboxesToDefaultValue();
                this.IsInfoShowed = false;
                ExtrasCheckedListBox.ClearSelected();
                UncheckCheckboxes();

                return;
            }


            if (CheckIfAllComboboxesAreAssigned())
            {
                Car newCar = this.CreateCar();

                CheckIfAllPricePanelTextboxesHaveValueDifferentThanNullOfEmptyString();

                //this.AddExtrasToCarExtrasFieldIfChecked(newCar);

                XMLDatabase.AppendNewCarDataToXML(newCar); // works fine
            }
            else
            {
                List<ComboBox> comboboxesList = new List<ComboBox>();
                comboboxesList.Add(CategoryCombobox);
                comboboxesList.Add(BrandsComboBox);
                comboboxesList.Add(ModelCombobox);
                comboboxesList.Add(FuelTypeCombobox);
                comboboxesList.Add(ColorsCombobox);
                comboboxesList.Add(GearboxesCombobox);
                comboboxesList.Add(StatusCombobox);
                comboboxesList.Add(TiresCombobox);

                if (comboboxesList.Any(x => x.SelectedItem == null))
                {
                    comboboxesList.Find(x => x.SelectedItem == null).Focus();
                    return;
                }
            }
            this.ResetCarsList();
            this.ClearTextboxesAndComboboxes();

            this.UncheckCheckboxes();
            this.SetHidablePricePanelTextboxesToDefaultValue();



        }

        private void OpenPicDirButton_Click(object sender, EventArgs e)
        {
            if (carsListBox.SelectedItem != null)
            {
                OpenSelectedCarDirectoryFolder(carsListBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Избери кола от списъка и опитай пак.", "Опа");
            }
        }

        private void AddExtrasToCarExtrasFieldIfChecked(Car newCar)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var box in ExtrasCheckedListBox.CheckedItems)
            {
                sb.Append(box);
                sb.Append("$");
            }
            newCar.Extras = sb.ToString();
        }

        private void HidePricePanelButton_Click(object sender, EventArgs e)
        {
            Log("Hide price panel button clicked!");
            if (HidablePricePanel.Visible == true)
            {
                HideOrShowPrivateOptions(false);
            }
            else if (HidablePricePanel.Visible == false)
            {
                HideOrShowPrivateOptions(true);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e) // OK! 21.02.18
        {
            Log("UploadButton() clicked!");

            MainPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (carsListBox.SelectedItem == null)
            {
                MessageBox.Show("Избери автомобил от списъка!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Избери снимка !";
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in openFileDialog.FileNames)
                    {
                        
                        
                        Image imageFromFile = Image.FromFile(file);
                        MainPicturebox.Image = imageFromFile;
                        if (MainPicturebox.Image != null)
                        {
                            SaveImageToDir();
                        }
                    }
                    //string fileName = openFileDialog.FileName;
                    //Image imageFromFile = Image.FromFile(fileName);
                    //MainPicturebox.Image = imageFromFile;
                    //if (MainPicturebox.Image != null)
                    //{
                    //    SaveImageToDir();
                    //}

                }
                else
                {
                    return;
                }
            }



        }

        private void ShowInfoFormButton_Click(object sender, EventArgs e)
        {
            Log("Info button clicked!");
            if (carsListBox.Items.Count > 0 && carsListBox.SelectedItem != null)
            {
                //FillCarInfoToTextboxes(carsListBox.SelectedItem);

                ExtrasInfoForm infoForm = new ExtrasInfoForm();
                if (true)
                {

                }
                infoForm.FillExtrasListFormTextbox(carsListBox.SelectedItem);

                infoForm.Show();


            }
        }

        private void soldButton_Click(object sender, EventArgs e)
        {
            Log("soldButton clicked!");
            if (MainPicturebox.Image != null)
            {
                MainPicturebox.Image.Dispose();

            }
            // erase from carsList
            if (carsListBox.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    Car selectedCar = (Car)carsListBox.SelectedItem;
                    var selectedCarPrice = int.Parse(selectedCar.Price);

                    XMLDatabase.Remove(carsListBox.SelectedItem);

                    this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();
                    carsListBox.Refresh();
                    carsListBox.ClearSelected();

                    //deletes all files in dir and then the delete the dir
                    if (Directory.Exists($"..\\Images\\{selectedCar.ContractNumber}"))
                    {
                        Directory.Delete($"..\\Images\\{selectedCar.ContractNumber}", true);

                    }
                    else
                    {

                        return;
                    }
                }
            }
        }

        // IndexChanged
        private void carsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTextboxesAndComboboxes();
            IsInfoShowed = true;
            ShowPicture();
            UncheckCheckboxes();
            FillCarInfoToTextboxes(carsListBox.SelectedItem);
        }

        //form load&close
        private void DielershipUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log("Form closed");
            Log("-----------------------------------");

        }

        private void DielershipUI_Load(object sender, EventArgs e)
        {
            Log("Form load!");
            carsListBox.Update();

            this.contractNumber = int.Parse(Settings.Default["NumOfContracts"].ToString());

            carsListBox.ClearSelected();
            ClearTextboxesAndComboboxes();
            MainPicturebox.Image = MainPicturebox.InitialImage;
        }

        private void DielershipUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }
        //indexChanged



        private void BrandsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToString(BrandsComboBox.SelectedItem))
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
                case "Ford":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.FordModels);
                    break;
                case "Toyota":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.ToyotaModels);
                    break;
                case "Subaru":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.SubaruModels);
                    break;
                case "Nissan":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.NissanModels);
                    break;
                case "Mazda":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.MazdaModels);
                    break;
                case "Mitsubishi":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.MitsubishiModels);
                    break;
                case "Opel":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.OpelModels);
                    break;
                case "Acura":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.AcuraModels);
                    break;
                case "Honda":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.HondaModels);
                    break;
                case "Infinity":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.InfinityModels);
                    break;
                case "Hyundai":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.HyundaiModels);
                    break;
                case "Kia":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.KiaModels);
                    break;
                case "Volvo":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.VolvoModels);
                    break;
                case "Dacia":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.DaciaModels);
                    break;
                case "Aston Martin":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.AstonMartinModels);
                    break;
                case "Bugatti":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.BugattiModels);
                    break;
                case "Lexus":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.LexusModels);
                    break;
                case "Smart":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.SmartModels);
                    break;
                case "Renault":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.RenaultModels);
                    break;
                case "Great Wall":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.GreatWallModels);
                    break;
                case "Land Rover":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.LandRoverModels);
                    break;
                case "Dodge":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.DodgeModels);
                    break;
                case "SsangYong":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.SsangYongModels);
                    break;
                case "Chrysler":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.ChryslerModels);
                    break;
                case "Jeep":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.JeepModels);
                    break;
                case "Cadillac":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.CadillacModels);
                    break;
                case "Chevrolet":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.ChevroletModels);
                    break;
                case "Jaguar":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.AddRange(CarsModelsLists.JaguarModels);
                    break;
                case "OTHER":
                    ModelCombobox.Items.Clear();
                    ModelCombobox.Items.Add("Other");
                    ModelCombobox.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        } // todo

        private void StatusRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (carsListBox.SelectedItem == null)
            {
                MessageBox.Show("Не е избран автомобил!", "Промяна", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }


        }
        //methods
        private void Log(string content)
        {
            string fullContent = DateTime.Now + " - " + content;
            if (!File.Exists(logPath))
            {
                File.Create(logPath).Dispose();
            }
            File.AppendAllText(logPath, fullContent);
            File.AppendAllText(logPath, "\r\n");
        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        private void ResetCarsList()
        {
            this.carsListBinding.ResetBindings(false);
            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();
        }

        private void CheckIfAllPricePanelTextboxesHaveValueDifferentThanNullOfEmptyString()
        {
            List<TextBox> PriceTexboxes = new List<TextBox> { RealSellingPriceTextbox,
            MinBillValueTextbox,
            MaxBillValueTextbox,
            ServiceCostsTextbox,
            FuelCostsTextbox,
            CosmeticsCostsTextbox,
            CzsTextbox,
            ComissionTextbox,
        };
            foreach (var box in PriceTexboxes)
            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    box.Text = "0";
                }
            }

        }

        private void HideOrShowPrivateOptions(bool condition)
        {
            HidablePricePanel.Visible = condition;
            AreRealMileageCheckbox.Visible = condition;
            PriceValueUpdateButton.Visible = condition;
            StatusValueUpdateButton.Visible = condition;
        }


        private Car CreateCar()
        {
            Log("CreateCar method invoked!");

            var Id = this.GetContractNumber();
            Car newCar = new Car(Id);
            newCar.DateOfCreatingAd = DateTime.Now.Date.ToShortDateString();
            newCar.Category = Convert.ToString(CategoryCombobox.SelectedItem);
            newCar.PayCase = Convert.ToString(PayCaseComboBox.SelectedItem);
            newCar.Brand = Convert.ToString(BrandsComboBox.SelectedItem);
            newCar.Model = Convert.ToString(ModelCombobox.SelectedItem);
            newCar.BodyworkType = Convert.ToString(BodyTypeCombobox.SelectedItem);
            newCar.EngineVolumeCc = EngineVolumeCCTextBox.Text;
            newCar.HorsePower = horsePowerTextBox.Text;
            newCar.FuelType = Convert.ToString(FuelTypeCombobox.SelectedItem);
            newCar.Color = Convert.ToString(ColorsCombobox.SelectedItem);
            newCar.ProductionDate = productionDateTextBox.Text;
            newCar.Mileage = mileageTextBox.Text;
            newCar.Price = priceTextBox.Text;
            newCar.AdditionalInfo = additionalCarInfoTextBox.Text;
            newCar.Vin = VinTextBox.Text;
            newCar.IsSold = false;
            newCar.Status = Convert.ToString(StatusCombobox.SelectedItem);
            newCar.Category = Convert.ToString(CategoryCombobox.SelectedItem);
            newCar.NumberOfKeys = NumberOfKeysNumericUpDown.Value.ToString();
            newCar.Tires = Convert.ToString(TiresCombobox.SelectedItem);
            newCar.Gearbox = Convert.ToString(GearboxesCombobox.SelectedItem);
            newCar.RealSellingPrice = Convert.ToInt32(RealSellingPriceTextbox.Text);
            newCar.MinBillValue = Convert.ToInt32(MinBillValueTextbox.Text);
            newCar.MaxBillValue = Convert.ToInt32(MaxBillValueTextbox.Text);
            newCar.OwnerByVoucher = OwnerByVoucherTextbox.Text;
            newCar.OwnerByBusiness = OwnerByBusinessTextbox.Text;
            newCar.FuelCosts = FuelCostsTextbox.Text;
            newCar.ServiceCosts = ServiceCostsTextbox.Text;
            newCar.CosmeticsCosts = CosmeticsCostsTextbox.Text;
            newCar.Czs = CzsTextbox.Text;
            newCar.Comission = ComissionTextbox.Text;
            newCar.OwnerByBusiness = OwnerByBusinessTextbox.Text;
            newCar.OwnerByVoucher = OwnerByVoucherTextbox.Text;
            this.AddExtrasToCarExtrasFieldIfChecked(newCar);
            if (AreRealMileageCheckbox.Checked)
            {

                newCar.AreMileageReal = "1";
            }
            else
            {
                newCar.AreMileageReal = "0";
            }
            newCar.RegistrationNumber = RegistrationNumberTextbox.Text;
            newCar.Country = Convert.ToString(CountryCombobox.SelectedItem);
            newCar.Shofer = ShoferTextbox.Text;
            return newCar;
        }

        private void SetHidablePricePanelTextboxesToDefaultValue()
        {
            RealSellingPriceTextbox.Text = "0";
            MinBillValueTextbox.Text = "0";
            MaxBillValueTextbox.Text = "0";
            ServiceCostsTextbox.Text = "0";
            FuelCostsTextbox.Text = "0";
            CosmeticsCostsTextbox.Text = "0";
            CzsTextbox.Text = "0";
            ComissionTextbox.Text = "0";

        }

        private void SaveImageToDir()
        {
            Log("SaveImageToDir() invoked!");
            Car currCar = (Car)carsListBox.SelectedItem;
            if (MainPicturebox.Image != null && currCar != null)
            {

                int carNumber = currCar.ContractNumber;
                if (Directory.Exists($"..\\Images\\{carNumber}"))
                {

                    string carNumberStr = carNumber.ToString();
                    // wallpaper pic naming
                    if (!File.Exists($"..\\Images\\{carNumber}\\{carNumber}header.jpeg"))
                    {
                        MainPicturebox.Image.Save($"..\\Images\\{carNumber}\\{carNumberStr}" + "header.jpeg", ImageFormat.Jpeg);
                        MessageBox.Show("Добавена е снимка!", "Upload");
                        return;
                    }
                    if (!File.Exists($"..\\Images\\{carNumber}\\{carNumber}.jpeg"))
                    {
                        MainPicturebox.Image.Save($"..\\Images\\{carNumber}\\{carNumberStr}" + ".jpeg", ImageFormat.Jpeg);
                        MessageBox.Show("Добавена е снимка!", "Upload");
                        return;
                    }
                    if (File.Exists($"..\\Images\\{carNumber}\\{carNumber}.jpeg"))
                    {
                        var name = $"{carNumber}" + DateTime.Now.Second + ".jpeg";
                        if (!File.Exists(name))
                        {
                            //{carNumber}" + $"{DateTime.Now.Second}" + ".jpeg"
                            //File.Move($"..\\Images\\{carNumber}\\{carNumber}.jpeg", $"..\\Images\\{carNumber}\\{name}");
                        MainPicturebox.Image.Save($"..\\Images\\{carNumber}\\{name}", ImageFormat.Jpeg);
                        MessageBox.Show("Добавена е снимка!", "Upload");
                        return;
                        }
                    }



                }
                else
                {
                    Directory.CreateDirectory($"..\\Images\\{carNumber}");
                    SaveImageToDir();
                }
            }
        }

        public void ClearTextboxesAndComboboxes() // WORKS FINE
        {
            //comboboxes
            CategoryCombobox.SelectedIndex = -1;
            PayCaseComboBox.SelectedIndex = -1;
            BrandsComboBox.SelectedIndex = -1;
            GearboxesCombobox.SelectedIndex = -1;
            ModelCombobox.SelectedIndex = -1;
            BodyTypeCombobox.SelectedIndex = -1;
            FuelTypeCombobox.SelectedIndex = -1;
            StatusCombobox.SelectedIndex = -1;
            ColorsCombobox.SelectedIndex = -1;
            TiresCombobox.SelectedIndex = -1;
            CountryCombobox.SelectedIndex = -1;
            //textboxes
            OwnerByBusinessTextbox.Clear();
            OwnerByVoucherTextbox.Clear();
            RealSellingPriceTextbox.Clear();
            DDSTextbox.Clear();
            MinBillValueTextbox.Clear();
            MaxBillValueTextbox.Clear();
            FuelCostsTextbox.Clear();
            ServiceCostsTextbox.Clear();
            CosmeticsCostsTextbox.Clear();
            CzsTextbox.Clear();
            ComissionTextbox.Clear();
            EngineVolumeCCTextBox.Clear();
            horsePowerTextBox.Clear();
            productionDateTextBox.Clear();
            mileageTextBox.Clear();
            additionalCarInfoTextBox.Clear();
            priceTextBox.Clear();
            VinTextBox.Clear();
            additionalCarInfoTextBox.Clear();
            ShoferTextbox.Clear();
            RegistrationNumberTextbox.Clear();

            //checkbox
            AreRealMileageCheckbox.Checked = false;

            //labels
            ContractNumberInfoLabel.Text = "";
            DateOfCreatingAdLabel.Text = "";
            //numericUpDown
            NumberOfKeysNumericUpDown.Value = 1;

        }

        private int GetContractNumber()
        {
            int id = int.Parse(Settings.Default["NumOfContracts"].ToString());
            Car currentCar;
            int finalId = id;
            foreach (var car in carsListBox.Items)
            {
                currentCar = (Car)car;
                if (currentCar.ContractNumber >= finalId)
                {
                    finalId = currentCar.ContractNumber + 1;
                }

            }
            Settings.Default["NumOfContracts"] = finalId + 1;
            Settings.Default.Save();

            return finalId;
        }

        private void UncheckCheckboxes()
        {
            Log("UncheckCheckboxes() invoked!");

            for (int i = 0; i < ExtrasCheckedListBox.Items.Count; i++)
            {
                ExtrasCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            }

        }

        private void ShowPicture()
        {
            Log("ShowPicture() method invoked!");
            var car = (Car)carsListBox.SelectedItem;
            if (car == null)
            {
                carsListBox.SelectedIndex = 0;
            }
            car = (Car)carsListBox.SelectedItem;
            string carNumber = car.ContractNumber.ToString();
            if (File.Exists($"..\\Images\\{carNumber}\\{carNumber}header.jpeg"))
            {
                MainPicturebox.Image = null;
                MainPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                var img = Image.FromFile($"..\\Images\\{carNumber}\\{carNumber}header.jpeg");

                MainPicturebox.Image = img;
            }
            else
            {
                MainPicturebox.Image = MainPicturebox.InitialImage;

            }
        }

        private void OpenSelectedCarDirectoryFolder(object car)
        {
            Log("OpenFolder() method invoked!");
            Car carCasted = (Car)car;
            if (!Directory.Exists($"..\\Images\\{carCasted.ContractNumber}\\"))
            {
                Directory.CreateDirectory($"..\\Images\\{carCasted.ContractNumber}\\");
                DialogResult dialR = MessageBox.Show("Папката е празна!\r\nИскате ли да отворите папката все пак ?", "Галерия", MessageBoxButtons.RetryCancel);
                if (dialR == DialogResult.Retry)
                {
                    Process.Start("explorer.exe", $"..\\Images\\{carCasted.ContractNumber}\\");
                    return;
                }
                if (dialR == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (!Directory.EnumerateFileSystemEntries($"..\\Images\\{carCasted.ContractNumber}\\").Any())
            {
                DialogResult dialR = MessageBox.Show("Папката е празна!\r\nИскате ли да отворите папката все пак ?", "Галерия", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialR == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", $"..\\Images\\{carCasted.ContractNumber}\\");
                    return;
                }
                if (dialR == DialogResult.No)
                {
                    return;
                }

            }
            Process.Start("explorer.exe", $"..\\Images\\{carCasted.ContractNumber}\\");

        }

        //private int IsIdAlreadyTaken(int id)
        //{
        //    int finalId = id;
        //    foreach (var car in carsListBox.Items)
        //    {
        //        Car currentCar = (Car)car;
        //        if (currentCar.ContractNumber >= id)
        //        {
        //            finalId++;
        //        }

        //    }
        //    return finalId;
        //}

        private void FillCarInfoToTextboxes(object selectedItem)
        {

            Car selectedCar = (Car)selectedItem;
            //TopPanel
            DateOfCreatingAdLabel.Text = selectedCar.DateOfCreatingAd;
            ContractNumberInfoLabel.Text = selectedCar.ContractNumber.ToString();
            PayCaseComboBox.SelectedIndex = PayCaseComboBox.FindStringExact(selectedCar.PayCase);
            OwnerByBusinessTextbox.Text = selectedCar.OwnerByBusiness;
            OwnerByVoucherTextbox.Text = selectedCar.OwnerByVoucher;
            //comboboxes
            CategoryCombobox.SelectedIndex = CategoryCombobox.FindStringExact(selectedCar.Category);
            BrandsComboBox.SelectedIndex = BrandsComboBox.FindStringExact(selectedCar.Brand);
            ModelCombobox.SelectedIndex = ModelCombobox.FindStringExact(selectedCar.Model);
            BodyTypeCombobox.SelectedIndex = BodyTypeCombobox.FindStringExact(selectedCar.BodyworkType);
            FuelTypeCombobox.SelectedIndex = FuelTypeCombobox.FindStringExact(selectedCar.FuelType);
            ColorsCombobox.SelectedIndex = ColorsCombobox.FindStringExact(selectedCar.Color);
            GearboxesCombobox.SelectedIndex = GearboxesCombobox.FindStringExact(selectedCar.Gearbox);
            StatusCombobox.SelectedIndex = StatusCombobox.FindStringExact(selectedCar.Status);
            TiresCombobox.SelectedIndex = TiresCombobox.FindStringExact(selectedCar.Tires);

            NumberOfKeysNumericUpDown.Value = Convert.ToDecimal(selectedCar.NumberOfKeys);
            if (selectedCar.AreMileageReal == "1")
            {
                AreRealMileageCheckbox.Checked = true;
            }
            else
            {
                AreRealMileageCheckbox.Checked = false;
            }
            //textboxes
            EngineVolumeCCTextBox.Text = selectedCar.EngineVolumeCc;
            horsePowerTextBox.Text = selectedCar.HorsePower;
            productionDateTextBox.Text = selectedCar.ProductionDate;
            mileageTextBox.Text = selectedCar.Mileage;
            priceTextBox.Text = selectedCar.Price;
            VinTextBox.Text = selectedCar.Vin;
            additionalCarInfoTextBox.Text = selectedCar.AdditionalInfo;
            //hidable additional price panel
            RealSellingPriceTextbox.Text = selectedCar.RealSellingPrice.ToString();
            DDSTextbox.Text = (((double)selectedCar.RealSellingPrice / 100) * 20).ToString();
            MinBillValueTextbox.Text = selectedCar.MinBillValue.ToString();
            MaxBillValueTextbox.Text = selectedCar.MaxBillValue.ToString();
            FuelCostsTextbox.Text = selectedCar.FuelCosts.ToString();
            ServiceCostsTextbox.Text = selectedCar.ServiceCosts.ToString();
            CosmeticsCostsTextbox.Text = selectedCar.CosmeticsCosts.ToString();
            ComissionTextbox.Text = selectedCar.Comission.ToString();
            CzsTextbox.Text = selectedCar.Czs.ToString();

            //ComboboxesAndTextboxesReadonly();

        }

        private void ComboboxesAndTextboxesReadonly(bool condition)
        {
            List<System.Windows.Forms.ComboBox> comboList = new List<System.Windows.Forms.ComboBox>();
            comboList.Add(CategoryCombobox);
            comboList.Add(BrandsComboBox);
            comboList.Add(ModelCombobox);
            comboList.Add(BodyTypeCombobox);
            comboList.Add(FuelTypeCombobox);
            comboList.Add(ColorsCombobox);
            comboList.Add(GearboxesCombobox);
            comboList.Add(StatusCombobox);
            comboList.Add(TiresCombobox);
            foreach (var box in comboList)
            {

            }
            this.IsInfoShowed = true;


        }// todo

        private bool CheckIfAllComboboxesAreAssigned()
        {

            bool CanContinue = false;
            List<ComboBox> comboboxesList = new List<ComboBox>();
            comboboxesList.Add(CategoryCombobox);
            comboboxesList.Add(BrandsComboBox);
            comboboxesList.Add(ModelCombobox);
            comboboxesList.Add(FuelTypeCombobox);
            comboboxesList.Add(ColorsCombobox);
            comboboxesList.Add(GearboxesCombobox);
            comboboxesList.Add(StatusCombobox);
            comboboxesList.Add(TiresCombobox);

            if (comboboxesList.Any(x => x.SelectedItem == null))
            {
                //comboboxesList.Find(x => x.SelectedItem == null).Focus();
                CanContinue = false;
            }
            else
            {
                CanContinue = true;
            }

            //}

            //foreach (var box in comboboxesList)
            //{
            //    if (box.SelectedItem == null)
            //    {
            //        MessageBox.Show("Всички полета трябва да са попълнени");
            //        box.Focus();
            //        CanContinue = false;
            //        break;
            //    }
            //    else
            //    {
            //        CanContinue = true;
            //    }
            //}


            return CanContinue;

        }

        //keypresses
        private void carsListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                IsInfoShowed = true;
                ShowPicture();

                FillCarInfoToTextboxes(carsListBox.SelectedItem);
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
            VinTextBox.CharacterCasing = CharacterCasing.Upper;
        }

        private void RealSellingPriceTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MinBillValueTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MaxBillValueTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FuelCostsTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ServiceCostsTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CosmeticsCostsTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CzsTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComissionTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void DDSTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 0)
            {
                e.Handled = true;
            }
        }

        private void StatusValueUpdateButton_Click(object sender, EventArgs e)
        {

            int index = StatusCombobox.SelectedIndex;
            var item = StatusCombobox.SelectedItem.ToString();
            var car = (Car)carsListBox.SelectedItem;
            if (item != car.Status)
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "Status", StatusCombobox.SelectedItem.ToString());
                MessageBox.Show("Готово!");
                StatusCombobox.SelectedIndex = -1;
                ResetCarsList();
                StatusCombobox.SelectedIndex = index;
            }
        }

        private void PriceValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = priceTextBox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.Price;
            if (newValue != oldValue)
            {

                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "Price", priceTextBox.Text);
                MessageBox.Show($"Цената променена!\n{oldValue}->{newValue}");

                priceTextBox.Clear();
                ResetCarsList();
                priceTextBox.Text = newValue;
            }
        }

        private void CzsValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = CzsTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.Czs;
            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "Czs", CzsTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                CzsTextbox.Clear();
                ResetCarsList();
                CzsTextbox.Text = newValue;
            }
        }

        private void ComissionValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = ComissionTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.Comission;
            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "Comission", ComissionTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                ComissionTextbox.Clear();
                ResetCarsList();
                ComissionTextbox.Text = newValue;
            }
        }

        private void FuelCostValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = FuelCostsTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.FuelCosts;

            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "FuelCosts", FuelCostsTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                FuelCostsTextbox.Clear();
                ResetCarsList();
                FuelCostsTextbox.Text = newValue;
            }

        }

        private void ServiceCostsValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = ServiceCostsTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.ServiceCosts;

            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "ServiceCosts", ServiceCostsTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                ServiceCostsTextbox.Clear();
                ResetCarsList();
                ServiceCostsTextbox.Text = newValue;
            }
        }

        private void CosmeticsCostsValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = CosmeticsCostsTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.CosmeticsCosts;

            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "CosmeticsCosts", CosmeticsCostsTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                CosmeticsCostsTextbox.Clear();
                ResetCarsList();
                CosmeticsCostsTextbox.Text = newValue;
            }
        }

        private void MaxBillValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = MaxBillValueTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.MaxBillValue;

            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "MaxBillValue", MaxBillValueTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                MaxBillValueTextbox.Clear();
                ResetCarsList();
                MaxBillValueTextbox.Text = newValue;
            }
        }

        private void MinBillValue_Click(object sender, EventArgs e)
        {
            var newValue = MinBillValueTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.MinBillValue;

            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "MinBillValue", MinBillValueTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                MinBillValueTextbox.Clear();
                ResetCarsList();
                MinBillValueTextbox.Text = newValue;
            }
        }

        private void RealSellingPriceValueUpdateButton_Click(object sender, EventArgs e)
        {
            var newValue = RealSellingPriceTextbox.Text;
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = car.RealSellingPrice;

            if (newValue != oldValue.ToString())
            {
                XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, "RealSellingPrice", RealSellingPriceTextbox.Text);
                MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                RealSellingPriceTextbox.Clear();
                ResetCarsList();
                RealSellingPriceTextbox.Text = newValue;
            }
        }

        private void TraderLabel_Click(object sender, EventArgs e)
        {
            if (IsInfoShowed)
            {
                var car = carsListBox.SelectedItem as Car;
                var content = car.OwnerByBusiness;
                MessageBox.Show(content);

            }
        }
    }
}

