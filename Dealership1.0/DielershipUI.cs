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
    using System.Xml.Linq;
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Diagnostics;

    /// <summary>
    /// Dielership Main
    /// </summary>
    public partial class DielershipUIForm : Form, IClearTextboxes
    {
        private BindingSource carsListBinding = new BindingSource();
        private int contractNumber;
        private bool IsInfoShowed;
        private string logPath = "..\\Log.txt";


        public DielershipUIForm()
        {
            this.InitializeComponent();

            ////login form
            LogInForm logForm = new LogInForm();
            logForm.ShowDialog();

            bool IsAuth = false;

            while (!IsAuth)
            {
                this.Enabled = false;
                IsAuth = LogInForm.CanContinue;
            }
            this.Enabled = true;
            ////

            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();

            carsListBox.DataSource = this.carsListBinding;

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";

            HidablePricePanel.Visible = false;
            UpdateButton.Visible = false;
            AreRealMileageCheckbox.Visible = false;
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
                pictureBox1.Image = null;
                this.SetHidablePricePanelTextboxesToDefaultValue();
                this.IsInfoShowed = false;
                return;
            }


            if (CheckIfAllComboboxesAreAssigned())
            {
                Car newCar = this.CreateCar();

                this.AddExtrasToCarExtrasFieldIfChecked(newCar);

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
                OpenFolder(carsListBox.SelectedItem);
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
                HidablePricePanel.Visible = false;
                UpdateButton.Visible = false;
                AreRealMileageCheckbox.Visible = false;
            }
            else if (HidablePricePanel.Visible == false)
            {
                HidablePricePanel.Visible = true;
                UpdateButton.Visible = true;
                AreRealMileageCheckbox.Visible = true;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e) // OK! 21.02.18
        {
            Log("UploadButton() clicked!");

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

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

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    Image imageFromFile = Image.FromFile(fileName);
                    pictureBox1.Image = imageFromFile;

                }
                else
                {
                    return;
                }
                if (pictureBox1.Image != null)
                {
                    SaveImageToDir();
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
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();

            }
            // erase from carsList
            if (carsListBox.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Check", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Log("UpdateButton clicked!");

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
            ResetCarsList();
        }
        // IndexChanged
        private void carsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTextboxesAndComboboxes();
            IsInfoShowed = true;
            ShowPicture();

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
            pictureBox1.Image = pictureBox1.InitialImage;
        }

        private void DielershipUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //indexChanged


        private void ResetCarsList()
        {
            this.carsListBinding.ResetBindings(false);
            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == false).ToList();
        }

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

        private Car CreateCar()
        {
            Log("CreateCar method invoked!");

            var Id = /*IsIdAlreadyTaken(*/this.GetContractNumber();
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
            newCar.FuelCosts = Convert.ToInt32(FuelCostsTextbox.Text);
            newCar.ServiceCosts = Convert.ToInt32(ServiceCostsTextbox.Text);
            newCar.CosmeticsCosts = Convert.ToInt32(CosmeticsCostsTextbox.Text);
            newCar.Czs = Convert.ToInt32(CzsTextbox.Text);
            newCar.Comission = Convert.ToInt32(ComissionTextbox.Text);
            newCar.OwnerByBusiness = OwnerByBusinessTextbox.Text;
            newCar.OwnerByVoucher = OwnerByVoucherTextbox.Text;
            //this.AddExtrasToCarExtrasFieldIfChecked(newCar);
            if (AreRealMileageCheckbox.Checked)
            {

                newCar.AreMileageReal = "1";
            }
            else
            {
                newCar.AreMileageReal = "0";
            }
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
            if (pictureBox1.Image != null && currCar != null)
            {

                int carNumber = currCar.ContractNumber;
                if (Directory.Exists($"..\\Images\\{carNumber}"))
                {

                    string fileName = carNumber.ToString();
                    // wallpaper pic naming
                    if (!File.Exists($"..\\Images\\{carNumber}\\{carNumber}header.jpeg"))
                    {
                        pictureBox1.Image.Save($"..\\Images\\{carNumber}\\{fileName}" + "header.jpeg", ImageFormat.Jpeg);
                        MessageBox.Show("Добавена е снимка!", "Upload");
                        return;
                    }

                    if (File.Exists($"..\\Images\\{carNumber}\\{carNumber}.jpeg"))
                    {
                        File.Move($"..\\Images\\{carNumber}\\{carNumber}.jpeg", $"..\\Images\\{carNumber}\\{carNumber}" + $"{DateTime.Now.Second}" + ".jpeg");
                        pictureBox1.Image.Save($"..\\Images\\{carNumber}\\{fileName}" + ".jpeg", ImageFormat.Jpeg);
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
            //checkbox
            AreRealMileageCheckbox.Checked = false;

            //labels
            ContractNumberInfoLabel.Text = "";
            DateOfCreatingAdLabel.Text = "";
            //numericUpDown
            NumberOfKeysNumericUpDown.Value = 1;

        }

        public void TextboxesReadOnlyOrNot(bool condition) //// out of date
        {
            horsePowerTextBox.ReadOnly = condition;
            productionDateTextBox.ReadOnly = condition;
            mileageTextBox.ReadOnly = condition;
            additionalCarInfoTextBox.ReadOnly = condition;
            priceTextBox.ReadOnly = condition;
            EngineVolumeCCTextBox.ReadOnly = condition;
            VinTextBox.ReadOnly = condition;
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
                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                var img = Image.FromFile($"..\\Images\\{carNumber}\\{carNumber}header.jpeg");

                pictureBox1.Image = img;
            }
            else
            {
                pictureBox1.Image = pictureBox1.InitialImage;

            }
        }

        private void OpenFolder(object car)
        {
            Log("OpenFolder() method invoked!");
            Car carCasted = (Car)car;
            if (!Directory.Exists($"..\\Images\\{carCasted.ContractNumber}\\"))
            {
                Directory.CreateDirectory($"..\\Images\\{carCasted.ContractNumber}\\");
                DialogResult dialR = MessageBox.Show("Папката е празна!\r\nИскате ли да отворите папката все пак ?","Галерия",MessageBoxButtons.RetryCancel);
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
                DialogResult dialR = MessageBox.Show("Папката е празна!\r\nИскате ли да отворите папката все пак ?", "Галерия", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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

        //visiblechange
        private void UpdateButton_VisibleChanged(object sender, EventArgs e)
        {
            if (UpdateButton.Visible)
            {

                PriceRadioButton.Visible = true;
                StatusRadioButton.Visible = true;
            }
            else
            {
                PriceRadioButton.Visible = false;
                StatusRadioButton.Visible = false;
            }
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



    }
}

