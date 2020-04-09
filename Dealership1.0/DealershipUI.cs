namespace Dealership1._0
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using DealershipLibrary.CarModelsLists;
    using DealershipLibrary;
    using Properties;
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Dielership Main
    /// </summary>
    public partial class DielershipUIForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// /
        /// </summary>

        private BindingSource carsListBinding = new BindingSource();
        private int GeneralContractNumber;
        private bool IsInfoShowed = false;
        private string logPath = "..\\Log.txt";
        public readonly string[] authorizedMacs = { "0026C7DFBD78", "002522C628DD", "5891CF96BAB8" };
        private readonly string mac = string.Empty;
        private bool IsAuth = false;
        private List<Car> expiredDateCars = new List<Car>();
        private bool IssoldCarsListShowed = false;
        private OrganizerForm organizationForm = OrganizerForm.CreateInstance();

        public DielershipUIForm()
        {
            this.InitializeComponent();

            //// authorization via MacAdress
            //mac = GetMacAddress();
            //bool IsAuth = false;
            //foreach (var auth in authorizedMacs)
            //{
            //    if (auth.ToLower() == mac.ToLower())
            //    {
            //        IsAuth = true;
            //        break;
            //    }
            //}
            //if (!IsAuth)
            //{
            //    MessageBox.Show("Not authorized!");
            //    Environment.Exit(1);
            //}


            //          log in block
            //LogInForm logForm = new LogInForm();
            //this.Enabled = false;

            //while (!IsAuth)
            //{
            //    logForm.ShowDialog();

            //    IsAuth = LogInForm.CanContinue;

            //}

            this.Enabled = true;
            RemoveButton.Visible = false;
            // 
            ////  auth end
            var AvailableCarsList = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "0").ToList();
            AvailableCarsList.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.DateOfCreatingAd), DateTime.Parse(y.DateOfCreatingAd)));
            AvailableCarsList.Reverse();
            //

            this.carsListBinding.DataSource = AvailableCarsList;//XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "0").ToList();
            carsListBox.DataSource = this.carsListBinding;

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";

            this.CarsListCounterLabel.Text = "(" + carsListBox.Items.Count.ToString() + ")";

            //  pop up message for unsold cars for 3 or more months
            //  notifyIcon start
            //
            foreach (var car in carsListBox.Items)
            {
                Car currCar = (Car)car;

                if (currCar.Status != "")
                {
                    var IsOlderThanThreeMonthsValue = IsOlderThanThreeMonths(currCar);

                    if (IsOlderThanThreeMonthsValue < 0)
                    {
                        expiredDateCars.Add(car as Car);
                    }
                }
            }

            if (expiredDateCars.Count >= 1)
            {
                NotifyIconTool.Icon = new Icon("..\\warning.ico");

                NotifyIconTool.Visible = true;
                NotifyIconTool.ShowBalloonTip(5000, "Известие", "Има обяви активни от 3 месеца или повече!", ToolTipIcon.Warning);
            }
            //
            //// notifyIcon stop

            this.SetButtonsToolTips();

            ////
            this.SetHidablePricePanelTextboxesToDefaultValue();
            ////
        }



        private void SetButtonsToolTips()
        {
            ToolTip InfoToolTip = new ToolTip();
            InfoToolTip.ShowAlways = true;
            InfoToolTip.AutoPopDelay = 10000;
            InfoToolTip.InitialDelay = 1000;
            InfoToolTip.ReshowDelay = 500;
            InfoToolTip.SetToolTip(InformationButton, "Информация");

            ToolTip AddToolTip = new ToolTip();
            AddToolTip.ShowAlways = true;
            AddToolTip.AutoPopDelay = 10000;
            AddToolTip.InitialDelay = 1000;
            AddToolTip.ReshowDelay = 500;
            AddToolTip.SetToolTip(addButton, "Добавяне / Изчистване на полетата");

            ToolTip ContractToolTip = new ToolTip();
            ContractToolTip.ShowAlways = true;
            ContractToolTip.AutoPopDelay = 10000;
            ContractToolTip.InitialDelay = 1000;
            ContractToolTip.ReshowDelay = 500;
            ContractToolTip.SetToolTip(ContractButton, "Договор");

            ToolTip PrintToolTip = new ToolTip();
            PrintToolTip.ShowAlways = true;
            PrintToolTip.AutoPopDelay = 10000;
            PrintToolTip.InitialDelay = 1000;
            PrintToolTip.ReshowDelay = 500;
            PrintToolTip.SetToolTip(PrintButton, "Принтиране");

            ToolTip SoldToolTip = new ToolTip();
            SoldToolTip.ShowAlways = true;
            SoldToolTip.AutoPopDelay = 10000;
            SoldToolTip.InitialDelay = 1000;
            SoldToolTip.ReshowDelay = 500;
            SoldToolTip.SetToolTip(soldButton, "Продай");

            ToolTip OpenPicDirToolTip = new ToolTip();
            OpenPicDirToolTip.ShowAlways = true;
            OpenPicDirToolTip.AutoPopDelay = 10000;
            OpenPicDirToolTip.InitialDelay = 1000;
            OpenPicDirToolTip.ReshowDelay = 500;
            OpenPicDirToolTip.SetToolTip(OpenPicDirButton, "Отваряне на папката със снимки");

            ToolTip UploadToolTip = new ToolTip();
            UploadToolTip.ShowAlways = true;
            UploadToolTip.AutoPopDelay = 10000;
            UploadToolTip.InitialDelay = 1000;
            UploadToolTip.ReshowDelay = 500;
            UploadToolTip.SetToolTip(UploadButton, "Качване на снимки");

            ToolTip NinjaToolTip = new ToolTip();
            NinjaToolTip.ShowAlways = true;
            NinjaToolTip.AutoPopDelay = 10000;
            NinjaToolTip.InitialDelay = 1000;
            NinjaToolTip.ReshowDelay = 500;
            NinjaToolTip.SetToolTip(HidePricePanelButton, "Нинджа");

            ToolTip SearchToolTip = new ToolTip();
            SearchToolTip.ShowAlways = true;
            SearchToolTip.AutoPopDelay = 10000;
            SearchToolTip.InitialDelay = 1000;
            SearchToolTip.ReshowDelay = 500;
            SearchToolTip.SetToolTip(SearchButton, "Търсене в списъка по номер на договор(до 5 символа) или рама(6 символа или повече)");

            ToolTip SoldCarsListToolTip = new ToolTip();
            SoldCarsListToolTip.ShowAlways = true;
            SoldCarsListToolTip.AutoPopDelay = 10000;
            SoldCarsListToolTip.InitialDelay = 1000;
            SoldCarsListToolTip.ReshowDelay = 500;
            SoldCarsListToolTip.SetToolTip(SoldCarsListButton, @"Смени списъка от ""налични"" на ""продадени"" или обратното");

            ToolTip RemoveButtonToolTip = new ToolTip();
            InfoToolTip.ShowAlways = true;
            InfoToolTip.AutoPopDelay = 10000;
            InfoToolTip.InitialDelay = 1000;
            InfoToolTip.ReshowDelay = 500;
            InfoToolTip.SetToolTip(RemoveButton, "Изтриване на обявата от списъка заедно с папката със снимки към обявата");

            ToolTip OrganizerToolTip = new ToolTip();
            AddToolTip.ShowAlways = true;
            AddToolTip.AutoPopDelay = 10000;
            AddToolTip.InitialDelay = 1000;
            AddToolTip.ReshowDelay = 500;
            AddToolTip.SetToolTip(OrganizerButton, "Органайзер");
        }

        private int IsOlderThanThreeMonths(Car car)
        {
            Car currCar = (Car)car;
            var date = DateTime.Parse(currCar.DateOfCreatingAd);
            var dateNow = DateTime.Parse(DateTime.Now.ToShortDateString());

            date = date.AddMonths(3);

            return DateTime.Compare(date, dateNow);
        }


        //buttonClick
        private void addButton_Click(object sender, EventArgs e)
        {
            if (IsInfoShowed == true)
            {
                this.MainPicturebox.Image = null;
                this.IsInfoShowed = false;
                this.ClearTextboxesComboboxesAndExtras();
                this.SetHidablePricePanelTextboxesToDefaultValue();
                this.ExtrasCheckedListBox.ClearSelected();
                this.UncheckCheckboxes();

                this.addButton.Image = new Bitmap(Resources.icons8_plus_math_24__1_);

                return;
            }
            List<TextBox> hidableTextboxes = new List<TextBox>
            {
                RealSellingPriceTextbox,
                MinBillValueTextbox,
                MaxBillValueTextbox,
                FuelCostsTextbox,
                ServiceCostsTextbox,
                CosmeticsCostsTextbox,
                CzsTextbox,
                ComissionTextbox
            };

            foreach (var box in hidableTextboxes)
            {
                if (string.IsNullOrEmpty(box.Text) || string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = "0";
                }
            }

            if (CheckIfAllComboboxesAreAssigned())
            {
                Car newCar = this.CreateCar();

                CheckIfAllPricePanelTextboxesHaveValueDifferentThanNullOfEmptyString();

                //this.AddExtrasToCarExtrasFieldIfChecked(newCar);

                XMLDatabase.AppendNewCarDataToXML(newCar); // works fine
                var carNumber = newCar.ContractNumber;
                if (!Directory.Exists($"..\\Images\\{carNumber}"))
                {
                    Directory.CreateDirectory($"..\\Images\\{carNumber}");

                }
            }
            else
            {

                List<ComboBox> comboboxesList = new List<ComboBox>();
                comboboxesList.Add(CategoryCombobox);
                comboboxesList.Add(BrandComboBox);
                comboboxesList.Add(ModelCombobox);
                comboboxesList.Add(FuelTypeCombobox);
                comboboxesList.Add(ColorCombobox);
                comboboxesList.Add(GearboxCombobox);
                comboboxesList.Add(StatusCombobox);
                comboboxesList.Add(TiresCombobox);

                if (comboboxesList.Any(x => x.SelectedItem == null))
                {
                    comboboxesList.Find(x => x.SelectedItem == null).Focus();
                    return;
                }
            }
            this.ResetCarsList();
            this.ClearTextboxesComboboxesAndExtras();

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
                ShowHideSecretOptions(false);
            }
            else if (HidablePricePanel.Visible == false)
            {
                ShowHideSecretOptions(true);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e) // OK! 21.02.18
        {
            Log("UploadButton() clicked!");

            MainPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            ////
            if (carsListBox.SelectedItem == null)
            {
                MessageBox.Show("Избери автомобил от списъка!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Избери снимка !";
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG";
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
                            SaveImageToDir((Car)carsListBox.SelectedItem, Path.GetFileName(file));
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

                InfoForm infoForm = new InfoForm();
                if (true)
                {

                }
                infoForm.FillTextbox((Car)carsListBox.SelectedItem);

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
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    Car selectedCar = (Car)carsListBox.SelectedItem;

                    ////pernament delete sold car data and refresh carsListbox
                    //XMLDatabase.Remove(carsListBox.SelectedItem);

                    //this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "0").ToList();
                    //carsListBox.Refresh();
                    //carsListBox.ClearSelected();

                    ////deletes all files in dir and then the delete the dir
                    //if (Directory.Exists($"..\\Images\\{selectedCar.ContractNumber}"))
                    //{
                    //    Directory.Delete($"..\\Images\\{selectedCar.ContractNumber}", true);

                    //}
                    //else
                    //{

                    //    return;
                    //}

                    ////30.03.2018 change isSold value and keep the data
                    if (selectedCar != null)
                    {
                        XMLDatabase.UpdateCarData(selectedCar, "IsSold", "1");
                        XMLDatabase.UpdateCarData(selectedCar, "Status", "Продадена");
                    }


                    ResetCarsList();

                    carsListBox.ClearSelected();
                    carsListBox.Refresh();
                }
            }
        }

        // IndexChanged
        private void carsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carsListBox.SelectedIndex >= 0 && IssoldCarsListShowed == false)
            {

                ClearTextboxesComboboxesAndExtras();
                UncheckCheckboxes();

                IsInfoShowed = true;
                addButton.Image = new Bitmap(Resources.icons8_erase_24);
                FillCarInfoToTextboxes((Car)carsListBox.SelectedItem);
                ShowPicture();

            }
            else if (IssoldCarsListShowed == true)
            {
                ClearTextboxesComboboxesAndExtras();
                UncheckCheckboxes();

                IsInfoShowed = true;
                addButton.Image = new Bitmap(Resources.icons8_erase_24);
                FillCarInfoToTextboxes((Car)carsListBox.SelectedItem);
                ShowPicture();

            }



        }

        //form load&close
        private void DielershipUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            //// clear sold cars directory + images
            MainPicturebox.Image = MainPicturebox.InitialImage;

            var directories = CustomSearcher.GetDirectories($"..\\Images\\");
            var carNumbers = new List<string>();

            //add sold cars
            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "1").ToList();
            carsListBox.DataSource = this.carsListBinding;
            foreach (var car in carsListBox.Items)
            {
                var currCar = (Car)car;
                carNumbers.Add(Convert.ToString(currCar.ContractNumber));
            }
            //
            //add available cars
            this.carsListBinding.DataSource = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "0").ToList();
            carsListBox.DataSource = this.carsListBinding;
            foreach (var car in carsListBox.Items)
            {
                var currCar = (Car)car;
                carNumbers.Add(Convert.ToString(currCar.ContractNumber));
            }


            //
            //check if dir exists and delete only dirs which are not needed
            foreach (var dir in directories)
            {
                var trimDir = dir.Replace("..\\Images\\", "");

                if (Directory.Exists($"..\\Images\\{trimDir}"))
                {

                    if (carNumbers.Contains(trimDir))
                    {
                        continue;
                    }
                    else
                    {
                        Directory.Delete($"..\\Images\\{trimDir}", true);
                    }

                }
            }
        }

        private void DielershipUI_Load(object sender, EventArgs e)
        {

            carsListBox.Update();

            this.GeneralContractNumber = int.Parse(Settings.Default["NumOfContracts"].ToString());

            carsListBox.ClearSelected();
            ClearTextboxesComboboxesAndExtras();
            MainPicturebox.Image = MainPicturebox.InitialImage;
            SetHidablePricePanelTextboxesToDefaultValue();
            //// timer
            //System.Timers.Timer aTimer = new System.Timers.Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 10000;
            //aTimer.Enabled = true;

            ClearTextboxesComboboxesAndExtras();
        }

        private void DielershipUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }




        private void BrandsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToString(BrandComboBox.SelectedItem))
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

            if (!IssoldCarsListShowed)
            {
                this.carsListBinding.ResetBindings(true);
                
                var list = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "0").ToList();
                list.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.DateOfCreatingAd), DateTime.Parse(y.DateOfCreatingAd)));
                list.Reverse();
               
                this.carsListBinding.DataSource = list;
                carsListBox.Refresh();

            }
            else if (IssoldCarsListShowed)
            {
                this.carsListBinding.ResetBindings(true);
                
                var list = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.IsSold == "1").ToList();
                list.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.DateOfCreatingAd), DateTime.Parse(y.DateOfCreatingAd)));
                list.Reverse();
              
                this.carsListBinding.DataSource = list;
                carsListBox.Refresh();

            }
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

        private void ShowHideSecretOptions(bool condition)
        {
            HidablePricePanel.Visible = condition;
            DateValueUpdateButton.Visible = condition;
            CategoryValueUpdateButton.Visible = condition;
            BrandValueUpdateButton.Visible = condition;
            ModelValueUpdateButton.Visible = condition;
            BodyworkTypeValueUpdateButton.Visible = condition;
            EngineVolumeCcValueUpdateButton.Visible = condition;
            HorsePowerValueUpdateButton.Visible = condition;
            FuelTypeValueUpdateButton.Visible = condition;
            ColorValueUpdateButton.Visible = condition;
            EngineVolumeCcValueUpdateButton.Visible = condition;
            ProductionDateValueUpdateButton.Visible = condition;
            MileageValueUpdateButton.Visible = condition;
            VinValueUpdateButton.Visible = condition;
            GearboxValueUpdateButton.Visible = condition;
            RegistrationNumberValueUpdateButton.Visible = condition;
            TiresValueUpdateButton.Visible = condition;
            ShoferValueUpdateButton.Visible = condition;
            CountryValueUpdateButton.Visible = condition;
            NumberOfKeysValueUpdateButton.Visible = condition;
            AdditionalInfoValueUpdateButton.Visible = condition;
            OwnerByVoucherValueUpdateButton.Visible = condition;
            OwnerByBusinessValueUpdateButton.Visible = condition;
            PayCaseValueUpdateButton.Visible = condition;

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
            newCar.Brand = Convert.ToString(BrandComboBox.SelectedItem);
            newCar.Model = Convert.ToString(ModelCombobox.SelectedItem);
            newCar.BodyworkType = Convert.ToString(BodyworkTypeCombobox.SelectedItem);
            newCar.EngineVolumeCc = EngineVolumeCCTextBox.Text;
            newCar.HorsePower = horsePowerTextBox.Text;
            newCar.FuelType = Convert.ToString(FuelTypeCombobox.SelectedItem);
            newCar.Color = Convert.ToString(ColorCombobox.SelectedItem);
            newCar.ProductionDate = ProductionDateTextBox.Text;
            newCar.Mileage = mileageTextBox.Text;
            newCar.Price = priceTextBox.Text;
            newCar.AdditionalInfo = AdditionalInfoTextBox.Text;
            newCar.Vin = VinTextBox.Text;
            newCar.IsSold = "0";
            newCar.Status = Convert.ToString(StatusCombobox.SelectedItem);
            newCar.Category = Convert.ToString(CategoryCombobox.SelectedItem);
            newCar.NumberOfKeys = NumberOfKeysNumericUpDown.Value.ToString();
            newCar.Tyres = Convert.ToString(TiresCombobox.SelectedItem);
            newCar.Gearbox = Convert.ToString(GearboxCombobox.SelectedItem);

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

        private void SaveImageToDir(Car car, string fileName)
        {
            Log("SaveImageToDir() invoked!");
            //Car currCar = /(Car)carsListBox.SelectedItem;
            if (MainPicturebox.Image != null && car != null)
            {

                int carNumber = car.ContractNumber;
                if (Directory.Exists($"..\\Images\\{carNumber}"))
                {
                    string carNumberStr = carNumber.ToString();

                    if (!File.Exists($"..\\Images\\{carNumber}\\{carNumber}header.jpeg"))
                    {
                        MainPicturebox.Image.Save($"..\\Images\\{carNumber}\\{carNumberStr}" + "header.jpeg", ImageFormat.Jpeg);
                        MessageBox.Show("Добавена е снимка!", "Upload");
                        return;
                    }
                    if (File.Exists($"..\\Images\\{carNumber}\\{fileName}"))
                    {
                        MessageBox.Show("Вече съществува снимка с такова име!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MainPicturebox.Image.Save($"..\\Images\\{carNumber}\\{fileName}", ImageFormat.Jpeg);
                        MessageBox.Show("Добавена е снимка!", "Upload");
                        return;
                    }

                }
                else
                {
                    SaveImageToDir((car), fileName);
                }
            }
        }

        public void ClearTextboxesComboboxesAndExtras()
        {
            //comboboxes
            CategoryCombobox.SelectedIndex = -1;
            PayCaseComboBox.SelectedIndex = -1;
            BrandComboBox.SelectedIndex = -1;
            GearboxCombobox.SelectedIndex = -1;
            ModelCombobox.SelectedIndex = -1;
            BodyworkTypeCombobox.SelectedIndex = -1;
            FuelTypeCombobox.SelectedIndex = -1;
            StatusCombobox.SelectedIndex = -1;
            ColorCombobox.SelectedIndex = -1;
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
            ProductionDateTextBox.Clear();
            mileageTextBox.Clear();
            AdditionalInfoTextBox.Clear();
            priceTextBox.Clear();
            VinTextBox.Clear();
            AdditionalInfoTextBox.Clear();
            ShoferTextbox.Clear();
            RegistrationNumberTextbox.Clear();

            AreRealMileageCheckbox.Checked = false;

            ContractNumberInfoLabel.Text = "";
            DateOfCreatingAdLabel.Text = "";

            NumberOfKeysNumericUpDown.Value = 1;

            ExtrasCheckedListBox.ClearSelected();

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
            try
            {


                if (File.Exists($"..\\Images\\{carNumber}\\{carNumber}header.jpeg"))
                {
                    MainPicturebox.Image = null;
                    MainPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;

                    MainPicturebox.Image = Image.FromFile($"..\\Images\\{carNumber}\\{carNumber}header.jpeg");

                }
                else
                {
                    MainPicturebox.Image = MainPicturebox.InitialImage;
                }
            }
            catch
            {

                MessageBox.Show("Добави снимка към обявата за да можеш да продължиш.");
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

        private void FillCarInfoToTextboxes(Car car)
        {
            if (car != null)
            {
                Car selectedCar = car;
                //TopPanel
                DateOfCreatingAdLabel.Text = selectedCar.DateOfCreatingAd ?? "";
                ContractNumberInfoLabel.Text = selectedCar.ContractNumber.ToString();
                PayCaseComboBox.SelectedIndex = PayCaseComboBox.FindStringExact(selectedCar.PayCase);
                OwnerByBusinessTextbox.Text = selectedCar.OwnerByBusiness;
                OwnerByVoucherTextbox.Text = selectedCar.OwnerByVoucher;
                //comboboxes
                CategoryCombobox.SelectedIndex = CategoryCombobox.FindStringExact(selectedCar.Category);
                BrandComboBox.SelectedIndex = BrandComboBox.FindStringExact(selectedCar.Brand);
                ModelCombobox.SelectedIndex = ModelCombobox.FindStringExact(selectedCar.Model);
                BodyworkTypeCombobox.SelectedIndex = BodyworkTypeCombobox.FindStringExact(selectedCar.BodyworkType);
                FuelTypeCombobox.SelectedIndex = FuelTypeCombobox.FindStringExact(selectedCar.FuelType);
                ColorCombobox.SelectedIndex = ColorCombobox.FindStringExact(selectedCar.Color);
                GearboxCombobox.SelectedIndex = GearboxCombobox.FindStringExact(selectedCar.Gearbox);
                StatusCombobox.SelectedIndex = StatusCombobox.FindStringExact(selectedCar.Status);
                TiresCombobox.SelectedIndex = TiresCombobox.FindStringExact(selectedCar.Tyres);

                NumberOfKeysNumericUpDown.Value = Convert.ToDecimal(selectedCar.NumberOfKeys);
                if (selectedCar.AreMileageReal == "1")
                {
                    AreRealMileageCheckbox.Checked = true;
                }
                else
                {
                    AreRealMileageCheckbox.Checked = false;
                }

                EngineVolumeCCTextBox.Text = selectedCar.EngineVolumeCc;
                horsePowerTextBox.Text = selectedCar.HorsePower;
                ProductionDateTextBox.Text = selectedCar.ProductionDate;
                mileageTextBox.Text = selectedCar.Mileage;
                priceTextBox.Text = selectedCar.Price;
                VinTextBox.Text = selectedCar.Vin;
                AdditionalInfoTextBox.Text = selectedCar.AdditionalInfo;

                RealSellingPriceTextbox.Text = selectedCar.RealSellingPrice.ToString();
                DDSTextbox.Text = (((double)selectedCar.RealSellingPrice / 100) * 20).ToString();
                MinBillValueTextbox.Text = selectedCar.MinBillValue.ToString();
                MaxBillValueTextbox.Text = selectedCar.MaxBillValue.ToString();
                FuelCostsTextbox.Text = selectedCar.FuelCosts.ToString();
                ServiceCostsTextbox.Text = selectedCar.ServiceCosts.ToString();
                CosmeticsCostsTextbox.Text = selectedCar.CosmeticsCosts.ToString();
                ComissionTextbox.Text = selectedCar.Comission.ToString();
                CzsTextbox.Text = selectedCar.Czs.ToString();
                RegistrationNumberTextbox.Text = selectedCar.RegistrationNumber;
                ShoferTextbox.Text = selectedCar.Shofer;
                CountryCombobox.SelectedIndex = CountryCombobox.FindStringExact(selectedCar.Country);

                for (int i = 0; i < ExtrasCheckedListBox.Items.Count; i++)
                {
                    if (car.Extras.Contains(ExtrasCheckedListBox.Items[i].ToString()))
                    {
                        ExtrasCheckedListBox.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void ComboboxesAndTextboxesReadonly(bool condition)
        {
            List<ComboBox> comboList = new List<ComboBox>();
            comboList.Add(CategoryCombobox);
            comboList.Add(BrandComboBox);
            comboList.Add(ModelCombobox);
            comboList.Add(BodyworkTypeCombobox);
            comboList.Add(FuelTypeCombobox);
            comboList.Add(ColorCombobox);
            comboList.Add(GearboxCombobox);
            comboList.Add(StatusCombobox);
            comboList.Add(TiresCombobox);

            this.IsInfoShowed = true;
            addButton.Image = new Bitmap(Resources.icons8_plus_math_24__1_);
        }

        private bool CheckIfAllComboboxesAreAssigned()
        {

            bool CanContinue = false;
            List<ComboBox> comboboxesList = new List<ComboBox>();
            comboboxesList.Add(CategoryCombobox);
            comboboxesList.Add(BrandComboBox);
            comboboxesList.Add(ModelCombobox);
            comboboxesList.Add(FuelTypeCombobox);
            comboboxesList.Add(ColorCombobox);
            comboboxesList.Add(GearboxCombobox);
            comboboxesList.Add(StatusCombobox);
            comboboxesList.Add(TiresCombobox);

            if (comboboxesList.Any(x => x.SelectedItem == null))
            {
                CanContinue = false;
            }
            else
            {
                CanContinue = true;
            }

            return CanContinue;
        }

        private void carsListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                IsInfoShowed = true;
                addButton.Image = new Bitmap(Resources.icons8_erase_24);
                ShowPicture();

                FillCarInfoToTextboxes((Car)carsListBox.SelectedItem);
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
            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
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
        private void TraderLabel_Click(object sender, EventArgs e)
        {
            if (IsInfoShowed)
            {
                var car = carsListBox.SelectedItem as Car;
                var content = car.OwnerByBusiness;
                MessageBox.Show(content);

            }
        }

        private void StatusValueUpdateButton_Click(object sender, EventArgs e)
        {

            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateComboboxButtonLogic(StatusCombobox, "Status", car.Status);
            }
        }

        private void PriceValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateTexboxButtonLogic(car, priceTextBox, "Price", car.Price);

            }

        }

        private void CzsValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateTexboxButtonLogic(car, CzsTextbox, "Czs", car.Czs);

            }


        }

        private void ComissionValueUpdateButton_Click(object sender, EventArgs e)
        {

            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, ComissionTextbox, "Comission", car.Comission);
            }
        }

        private void FuelCostValueUpdateButton_Click(object sender, EventArgs e)
        {

            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, FuelCostsTextbox, "FuelCosts", car.FuelCosts);
            }
        }

        private void ServiceCostsValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateTexboxButtonLogic(car, ServiceCostsTextbox, "ServiceCosts", car.ServiceCosts);

            }
        }

        private void CosmeticsCostsValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;

            if (car != null && IsInfoShowed)
            {
                var newValue = CosmeticsCostsTextbox.Text;
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
        }

        private void MaxBillValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                var newValue = MaxBillValueTextbox.Text;
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
        }

        private void MinBillValue_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {


                var newValue = MinBillValueTextbox.Text;
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
        }

        private void RealSellingPriceValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                var newValue = RealSellingPriceTextbox.Text;
                var oldValue = car.RealSellingPrice;

                if (newValue != oldValue.ToString())
                {
                    XMLDatabase.UpdateCarData(car, "RealSellingPrice", RealSellingPriceTextbox.Text);
                    MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}");

                    RealSellingPriceTextbox.Clear();
                    ResetCarsList();
                    RealSellingPriceTextbox.Text = newValue;
                }
            }
        }


        private void CategoryValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateComboboxButtonLogic(CategoryCombobox, "Category", car.Category);

            }
        }

        private void BrandValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(BrandComboBox, "Brand", car.Brand);
            }
        }

        private void ModelValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(ModelCombobox, "Model", car.Model);
            }
        }

        private void BodyworkTypeValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(BodyworkTypeCombobox, "BodyworkType", car.BodyworkType);
            }
        }

        private void EngineVolumeCcValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, EngineVolumeCCTextBox, "EngineVolumeCc", car.EngineVolumeCc);
            }
        }

        private void HorsePowerValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, horsePowerTextBox, "HorsePower", car.HorsePower);
            }
        }

        private void FuelTypeValueUpdateButton_Click(object sender, EventArgs e)
        {

            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(FuelTypeCombobox, "FuelType", car.FuelType);
            }
        }

        private void ColorValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(ColorCombobox, "Color", car.Color);
            }
        }

        private void EngineVolumeCcValueUpdateButton_Click_1(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, EngineVolumeCCTextBox, "EngineVolumeCc", car.EngineVolumeCc);
            }
        }

        private void ProductionDateValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, ProductionDateTextBox, "ProductionDate", car.ProductionDate);
            }
        }


        private void UpdateTexboxButtonLogic(Car car, TextBox textBox, string nodeElement, string oldValue)
        {
            if (IsInfoShowed && car != null)
            {
                if (textBox.Text != oldValue.ToString())
                {
                    var newValue = textBox.Text;

                    if (newValue != null)
                    {
                        if (car != null && IsInfoShowed)
                        {
                            XMLDatabase.UpdateCarData(car, nodeElement, newValue);
                            MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}", "Update");
                        }
                    }
                    textBox.Clear();
                    ResetCarsList();
                    textBox.Text = newValue;
                }
            }

        }

        private void UpdateComboboxButtonLogic(ComboBox comboBox, string nodeElement, string currentValue)
        {
            var car = (Car)carsListBox.SelectedItem;
            var oldValue = currentValue;
            var newValue = comboBox.SelectedItem.ToString();

            if (IsInfoShowed)
            {

                if (newValue != null)
                {
                    if (car != null && IsInfoShowed)
                    {

                        if (newValue != oldValue)
                        {
                            XMLDatabase.UpdateCarData((Car)carsListBox.SelectedItem, nodeElement, newValue);
                            MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}", "Update");

                        }
                    }
                }

                comboBox.SelectedIndex = -1;
                ResetCarsList();
                comboBox.SelectedItem = newValue;
            }
        }

        private void MileageValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateTexboxButtonLogic(car, mileageTextBox, "Mileage", car.Mileage);
            }
        }

        private void DateValueUpdateButton_Click(object sender, EventArgs e)
        {


            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                if (IsInfoShowed)
                {
                    var oldValue = car.DateOfCreatingAd;
                    var nodeElement = "DateOfCreatingAd";
                    var newValue = DateTime.Now.Date;


                    if (newValue != null)
                    {
                        if (car != null && IsInfoShowed)
                        {
                            XMLDatabase.UpdateCarData(car, nodeElement, newValue.ToShortDateString());
                            MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}", "Update");
                        }

                        ResetCarsList();
                    }
                }
            }

        }
        private void VinValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, VinTextBox, "Vin", car.Vin);
            }
        }

        private void GearboxValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(GearboxCombobox, "Gearbox", car.Gearbox);
            }
        }

        private void RegistrationNumberValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, RegistrationNumberTextbox, "RegistrationNumber", car.RegistrationNumber);
            }
        }

        private void TiresValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(TiresCombobox, "Tires", car.Tyres);
            }
        }

        private void ShoferValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, ShoferTextbox, "Shofer", car.Shofer);
            }
        }

        private void CountryValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(CountryCombobox, "Country", car.Country);
            }
        }

        private void NumberOfKeysValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                if (IsInfoShowed)
                {
                    var newValue = NumberOfKeysNumericUpDown.Text;
                    string oldValue = car.NumberOfKeys;


                    if (newValue != null)
                    {
                        if (car != null && IsInfoShowed)
                        {
                            XMLDatabase.UpdateCarData(car, "NumberOfKeys", newValue);
                            MessageBox.Show($"Стойноста е променена!\n{oldValue}->{newValue}", "Update");
                        }
                    }
                    NumberOfKeysNumericUpDown.ResetText();
                    ResetCarsList();
                    NumberOfKeysNumericUpDown.Text = newValue;
                }
            }
        }

        private void AdditionalInfoValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateTexboxButtonLogic(car, AdditionalInfoTextBox, "AdditionalInfo", car.AdditionalInfo);
            }
        }

        private void ContractButton_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("BuySellContract.txt");
            text = Regex.Replace(text, "city", "София");
            text = Regex.Replace(text, "date", DateTime.Now.Date.ToShortDateString());
            text = Regex.Replace(text, "prodavach, ", " Виктор Е. Донински ");
            text = Regex.Replace(text, "lichnaKarta, ", " 534234345 ");
            text = Regex.Replace(text, "dataNaIzdavaneNaKartata", "14.10.2000");
            text = Regex.Replace(text, "izdadenaVGrad", "София");
            text = Regex.Replace(text, "egn", "923234819");
            text = Regex.Replace(text, "jiveesht", "Перник");
            text = Regex.Replace(text, "kvartal", "Младост");

            File.WriteAllText("test.txt", text);
        }

        private void OwnerByVoucherValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateTexboxButtonLogic(car, OwnerByVoucherTextbox, "OwnerByVoucher", car.OwnerByVoucher);
            }
        }

        private void OwnerByBusinessValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {
                UpdateTexboxButtonLogic(car, OwnerByBusinessTextbox, "OwnerByBusiness", car.OwnerByBusiness);

            }


        }

        private void OwnerByVoucherTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var car = (Car)carsListBox.SelectedItem;
                if (OwnerByVoucherTextbox.Text != car.OwnerByVoucher && !IsInfoShowed)
                {
                    this.OwnerByVoucherValueUpdateButton_Click(sender, e);
                }
                else
                {
                    return;
                }
            }
        }

        private void PayCaseValueUpdateButton_Click(object sender, EventArgs e)
        {
            var car = (Car)carsListBox.SelectedItem;
            if (car != null && IsInfoShowed)
            {

                UpdateComboboxButtonLogic(PayCaseComboBox, "PayCase", car.PayCase);
            }

        }

        private void CaptureFormToBitmapButton_Click(object sender, EventArgs e)
        {
            var selectedCar = (Car)carsListBox.SelectedItem;
            if (selectedCar != null)
            {
                PrintForm printForm = new PrintForm();

                printForm.FillPrintForm(selectedCar);

                printForm.Show();
            }

        }

        private void NotifyIconTool_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();

            infoForm.FillTextbox(expiredDateCars);

            infoForm.Show();
        }

        private void NotifyIconTool_BalloonTipClicked(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();

            infoForm.FillTextbox(expiredDateCars);

            infoForm.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)// last update 12.06.18 -> search by brand
        {
            if (!string.IsNullOrWhiteSpace(SearchTextbox.Text))
            {   // true if it doesn't contain letters
                if (!SearchTextbox.Text.Any(char.IsLetter))
                {

                    int searchedId = Convert.ToInt32(SearchTextbox.Text);


                    foreach (var car in carsListBox.Items)
                    {
                        var currCar = (Car)car;
                        if (currCar.ContractNumber == searchedId)
                        {
                            var index = carsListBox.Items.IndexOf(car);
                            carsListBox.SelectedIndex = index;
                            return;
                        }
                    }
                }
                ////search by brand "logic"
                if (BrandComboBox.Items.Contains(FirstCharToUpper(SearchTextbox.Text.ToLower())) && !(SearchTextbox.Text.Any(char.IsDigit)))
                {
                    //
                    this.carsListBinding.ResetBindings(true);
                    //
                    var list = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.Brand == SearchTextbox.Text).ToList();
                    list.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.DateOfCreatingAd), DateTime.Parse(y.DateOfCreatingAd)));
                    list.Reverse();

                    this.carsListBinding.DataSource = list;
                    carsListBox.Refresh();
                    return;
                    //
                }
                //// special case
                if (BrandComboBox.Items.Contains("BMW") && !(SearchTextbox.Text.Any(char.IsDigit)))
                {
                    //
                    this.carsListBinding.ResetBindings(true);
                    //
                    var list = XMLDatabase.LoadCarsListFromXmlDB().Where(x => x.Brand == SearchTextbox.Text).ToList();
                    list.Sort((x, y) => DateTime.Compare(DateTime.Parse(x.DateOfCreatingAd), DateTime.Parse(y.DateOfCreatingAd)));
                    list.Reverse();

                    this.carsListBinding.DataSource = list;
                    carsListBox.Refresh();
                    return;
                    //
                }
                if (SearchTextbox.Text.Length > 5)
                {
                    foreach (var car in carsListBox.Items)
                    {
                        var currCar = (Car)car;
                        if (currCar.Vin.Contains(SearchTextbox.Text))
                        {
                            var index = carsListBox.Items.IndexOf(car);
                            carsListBox.SelectedIndex = index;
                            return;
                        }
                    }
                }

                MessageBox.Show("Няма намерен резултат!", "Търсене", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                SearchTextbox.Text = "";

            }
            ResetCarsList();
            SearchTextbox.Text = "";
        }

        private string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        private void SwitchCarsListsButton_Click(object sender, EventArgs e)
        {

            if (!IssoldCarsListShowed)
            {
                SoldCarsListButton.Image = new Bitmap(Resources.icons8_out_of_stock_24);

                RemoveButton.Visible = true;

                addButton.Visible = false;

                soldButton.Enabled = false;

                IssoldCarsListShowed = true;

                ResetCarsList();
                carsListBox.Refresh();

            }
            else if (IssoldCarsListShowed)
            {
                SoldCarsListButton.Image = new Bitmap(Resources.icons8_move_stock_24__1_);

                RemoveButton.Visible = false;

                addButton.Visible = true;

                soldButton.Enabled = true;

                IssoldCarsListShowed = false;

                ResetCarsList();
                carsListBox.Refresh();
            }

            //if (carsListBox.SelectedIndex <= 0)               /// now its ok
            {
                ExtrasCheckedListBox.ClearSelected();
                ClearTextboxesComboboxesAndExtras();
                if (MainPicturebox.Image != MainPicturebox.InitialImage)
                {
                    MainPicturebox.Image = MainPicturebox.InitialImage;
                }
            }
            ////else
            //{
            //    ClearTextboxesComboboxesAndExtras();
            //    MainPicturebox.Image = MainPicturebox.InitialImage;

            //}
            this.CarsListCounterLabel.Text = "(" + carsListBox.Items.Count.ToString() + ")";

        }

        private void SearchTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchTextbox.CharacterCasing = CharacterCasing.Upper;

            if (e.KeyChar == (char)13)
            {
                SearchButton_Click(null, null);
            }

            if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            e.Handled = true;
        }

        private void carsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

            carsListBox.DisplayMember = "Display";
            carsListBox.ValueMember = "Display";
            ////
            if (e.Index < 0)
            {
                return;
            }
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.LightGray);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(carsListBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();

        }

        private void CategoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(CategoryCombobox.SelectedItem) == "Мотоциклет")
            {

            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (carsListBox.SelectedItem != null)  // todo
            {
                //
                DialogResult dialogResult = MessageBox.Show("Сигурен ли си?", "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //MainPicturebox.Image = MainPicturebox.InitialImage;
                if (dialogResult == DialogResult.Yes)
                {
                    MainPicturebox.Image = MainPicturebox.InitialImage;
                    Car selectedCar = (Car)carsListBox.SelectedItem;


                    XMLDatabase.Remove(selectedCar);
                    ResetCarsList();
                    //deletes all files in dir and then the delete the dir

                    //if (Directory.Exists($"..\\Images\\{selectedCar.ContractNumber}"))
                    //{
                    //    Directory.Delete($"..\\Images\\{selectedCar.ContractNumber}", true);
                    //}





                    MainPicturebox.Image = MainPicturebox.InitialImage;
                }
                //
                ResetCarsList();
                ClearTextboxesComboboxesAndExtras();
                carsListBox.Refresh();
                carsListBox.ClearSelected();
            }
        }

        private void OrganizerButton_Click(object sender, EventArgs e)
        {
            if (organizationForm == null)
            {

                organizationForm.Show();

            }
            else
            {
                organizationForm.Visible = true;

            }



            //if (OrganizerForm.isOrganizerOn)
            //{

            //    organizationForm.DialogResult = DialogResult.None;
            //}
            //else if (organizationForm.DialogResult == DialogResult.Abort)
            //{

            //    organizationForm.DialogResult = DialogResult.None;

            //}

        }
    }
}

