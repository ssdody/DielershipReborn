using System;

namespace Dealership1._0
{
    partial class DielershipUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DielershipUI));
            this.carsListBox = new System.Windows.Forms.ListBox();
            this.brandLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.engineVolumeLabel = new System.Windows.Forms.Label();
            this.enginePowerLabel = new System.Windows.Forms.Label();
            this.fuelTypeLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.productionDateLabel = new System.Windows.Forms.Label();
            this.mileageLabel = new System.Windows.Forms.Label();
            this.EngineVolumeCCTextBox = new System.Windows.Forms.TextBox();
            this.productionDateTextBox = new System.Windows.Forms.TextBox();
            this.horsePowerTextBox = new System.Windows.Forms.TextBox();
            this.mileageTextBox = new System.Windows.Forms.TextBox();
            this.InfoTextboxLabel = new System.Windows.Forms.Label();
            this.additionalCarInfoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VinTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BrandsComboBox = new System.Windows.Forms.ComboBox();
            this.ModelCombobox = new System.Windows.Forms.ComboBox();
            this.BodyTypeCombobox = new System.Windows.Forms.ComboBox();
            this.FuelTypeCombobox = new System.Windows.Forms.ComboBox();
            this.ColorsCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GearboxesCombobox = new System.Windows.Forms.ComboBox();
            this.StatusRadioButton = new System.Windows.Forms.RadioButton();
            this.PriceRadioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.StatusCombobox = new System.Windows.Forms.ComboBox();
            this.AreRealMileageCheckbox = new System.Windows.Forms.CheckBox();
            this.NumberOfKeysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.NumberOfKeysLabel = new System.Windows.Forms.Label();
            this.TiresCombobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PayCaseComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryCombobox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ExtrasCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HidePricePanelButton = new System.Windows.Forms.Button();
            this.OwnerByBusinessTextbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.OwnerByVoucherLabel = new System.Windows.Forms.Label();
            this.OwnerByVoucherTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ContractNumberInfoLabel = new System.Windows.Forms.Label();
            this.DateOfCreatingAdLabel = new System.Windows.Forms.Label();
            this.HidablePricePanel = new System.Windows.Forms.Panel();
            this.CzsTextbox = new System.Windows.Forms.TextBox();
            this.ComissionTextbox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.FuelCostsTextbox = new System.Windows.Forms.TextBox();
            this.ServiceCostsTextbox = new System.Windows.Forms.TextBox();
            this.CosmeticsCostsTextbox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.MaxBillValueTextbox = new System.Windows.Forms.TextBox();
            this.MinBillValueTextbox = new System.Windows.Forms.TextBox();
            this.DDSTextbox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.RealSellingPriceTextbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ShowInfoFormButton = new System.Windows.Forms.Button();
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.soldButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.OpenPicDirButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfKeysNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.HidablePricePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // carsListBox
            // 
            resources.ApplyResources(this.carsListBox, "carsListBox");
            this.carsListBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.carsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.carsListBox.ForeColor = System.Drawing.Color.White;
            this.carsListBox.FormattingEnabled = true;
            this.carsListBox.Name = "carsListBox";
            this.carsListBox.Sorted = true;
            this.carsListBox.DoubleClick += new System.EventHandler(this.carsListBox_DoubleClick);
            this.carsListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.carsListBox_KeyPress);
            // 
            // brandLabel
            // 
            resources.ApplyResources(this.brandLabel, "brandLabel");
            this.brandLabel.BackColor = System.Drawing.Color.Transparent;
            this.brandLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.brandLabel.Name = "brandLabel";
            // 
            // modelLabel
            // 
            resources.ApplyResources(this.modelLabel, "modelLabel");
            this.modelLabel.BackColor = System.Drawing.Color.Transparent;
            this.modelLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.modelLabel.Name = "modelLabel";
            // 
            // typeLabel
            // 
            resources.ApplyResources(this.typeLabel, "typeLabel");
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.typeLabel.Name = "typeLabel";
            // 
            // engineVolumeLabel
            // 
            resources.ApplyResources(this.engineVolumeLabel, "engineVolumeLabel");
            this.engineVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.engineVolumeLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.engineVolumeLabel.Name = "engineVolumeLabel";
            // 
            // enginePowerLabel
            // 
            resources.ApplyResources(this.enginePowerLabel, "enginePowerLabel");
            this.enginePowerLabel.BackColor = System.Drawing.Color.Transparent;
            this.enginePowerLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.enginePowerLabel.Name = "enginePowerLabel";
            // 
            // fuelTypeLabel
            // 
            resources.ApplyResources(this.fuelTypeLabel, "fuelTypeLabel");
            this.fuelTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.fuelTypeLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.fuelTypeLabel.Name = "fuelTypeLabel";
            // 
            // colorLabel
            // 
            resources.ApplyResources(this.colorLabel, "colorLabel");
            this.colorLabel.BackColor = System.Drawing.Color.Transparent;
            this.colorLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.colorLabel.Name = "colorLabel";
            // 
            // productionDateLabel
            // 
            resources.ApplyResources(this.productionDateLabel, "productionDateLabel");
            this.productionDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.productionDateLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.productionDateLabel.Name = "productionDateLabel";
            // 
            // mileageLabel
            // 
            resources.ApplyResources(this.mileageLabel, "mileageLabel");
            this.mileageLabel.BackColor = System.Drawing.Color.Transparent;
            this.mileageLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.mileageLabel.Name = "mileageLabel";
            // 
            // EngineVolumeCCTextBox
            // 
            resources.ApplyResources(this.EngineVolumeCCTextBox, "EngineVolumeCCTextBox");
            this.EngineVolumeCCTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.EngineVolumeCCTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EngineVolumeCCTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.EngineVolumeCCTextBox.Name = "EngineVolumeCCTextBox";
            this.EngineVolumeCCTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EngineVolumeCCTextBox_KeyPress);
            // 
            // productionDateTextBox
            // 
            resources.ApplyResources(this.productionDateTextBox, "productionDateTextBox");
            this.productionDateTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.productionDateTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.productionDateTextBox.Name = "productionDateTextBox";
            // 
            // horsePowerTextBox
            // 
            resources.ApplyResources(this.horsePowerTextBox, "horsePowerTextBox");
            this.horsePowerTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.horsePowerTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.horsePowerTextBox.Name = "horsePowerTextBox";
            this.horsePowerTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.horsePowerTextBox_KeyPress);
            // 
            // mileageTextBox
            // 
            resources.ApplyResources(this.mileageTextBox, "mileageTextBox");
            this.mileageTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.mileageTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.mileageTextBox.Name = "mileageTextBox";
            this.mileageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mileageTextBox_KeyPress);
            // 
            // InfoTextboxLabel
            // 
            resources.ApplyResources(this.InfoTextboxLabel, "InfoTextboxLabel");
            this.InfoTextboxLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoTextboxLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.InfoTextboxLabel.Name = "InfoTextboxLabel";
            // 
            // additionalCarInfoTextBox
            // 
            resources.ApplyResources(this.additionalCarInfoTextBox, "additionalCarInfoTextBox");
            this.additionalCarInfoTextBox.BackColor = System.Drawing.Color.Black;
            this.additionalCarInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.additionalCarInfoTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.additionalCarInfoTextBox.Name = "additionalCarInfoTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Name = "label2";
            // 
            // priceTextBox
            // 
            resources.ApplyResources(this.priceTextBox, "priceTextBox");
            this.priceTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.priceTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTextBox_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Name = "label3";
            // 
            // VinTextBox
            // 
            resources.ApplyResources(this.VinTextBox, "VinTextBox");
            this.VinTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.VinTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.VinTextBox.Name = "VinTextBox";
            this.VinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WinTextBox_KeyPress);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Name = "label4";
            // 
            // BrandsComboBox
            // 
            resources.ApplyResources(this.BrandsComboBox, "BrandsComboBox");
            this.BrandsComboBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.BrandsComboBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BrandsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BrandsComboBox.ForeColor = System.Drawing.SystemColors.Window;
            this.BrandsComboBox.FormattingEnabled = true;
            this.BrandsComboBox.Items.AddRange(new object[] {
            resources.GetString("BrandsComboBox.Items"),
            resources.GetString("BrandsComboBox.Items1"),
            resources.GetString("BrandsComboBox.Items2"),
            resources.GetString("BrandsComboBox.Items3"),
            resources.GetString("BrandsComboBox.Items4"),
            resources.GetString("BrandsComboBox.Items5"),
            resources.GetString("BrandsComboBox.Items6"),
            resources.GetString("BrandsComboBox.Items7"),
            resources.GetString("BrandsComboBox.Items8"),
            resources.GetString("BrandsComboBox.Items9"),
            resources.GetString("BrandsComboBox.Items10"),
            resources.GetString("BrandsComboBox.Items11"),
            resources.GetString("BrandsComboBox.Items12"),
            resources.GetString("BrandsComboBox.Items13"),
            resources.GetString("BrandsComboBox.Items14"),
            resources.GetString("BrandsComboBox.Items15"),
            resources.GetString("BrandsComboBox.Items16"),
            resources.GetString("BrandsComboBox.Items17"),
            resources.GetString("BrandsComboBox.Items18"),
            resources.GetString("BrandsComboBox.Items19"),
            resources.GetString("BrandsComboBox.Items20"),
            resources.GetString("BrandsComboBox.Items21"),
            resources.GetString("BrandsComboBox.Items22"),
            resources.GetString("BrandsComboBox.Items23"),
            resources.GetString("BrandsComboBox.Items24"),
            resources.GetString("BrandsComboBox.Items25"),
            resources.GetString("BrandsComboBox.Items26"),
            resources.GetString("BrandsComboBox.Items27"),
            resources.GetString("BrandsComboBox.Items28"),
            resources.GetString("BrandsComboBox.Items29"),
            resources.GetString("BrandsComboBox.Items30"),
            resources.GetString("BrandsComboBox.Items31"),
            resources.GetString("BrandsComboBox.Items32"),
            resources.GetString("BrandsComboBox.Items33"),
            resources.GetString("BrandsComboBox.Items34"),
            resources.GetString("BrandsComboBox.Items35"),
            resources.GetString("BrandsComboBox.Items36"),
            resources.GetString("BrandsComboBox.Items37"),
            resources.GetString("BrandsComboBox.Items38"),
            resources.GetString("BrandsComboBox.Items39")});
            this.BrandsComboBox.Name = "BrandsComboBox";
            this.BrandsComboBox.Sorted = true;
            this.BrandsComboBox.SelectedIndexChanged += new System.EventHandler(this.BrandsComboBox_SelectedIndexChanged);
            // 
            // ModelCombobox
            // 
            resources.ApplyResources(this.ModelCombobox, "ModelCombobox");
            this.ModelCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.ModelCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ModelCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.ModelCombobox.FormattingEnabled = true;
            this.ModelCombobox.Name = "ModelCombobox";
            this.ModelCombobox.Sorted = true;
            // 
            // BodyTypeCombobox
            // 
            resources.ApplyResources(this.BodyTypeCombobox, "BodyTypeCombobox");
            this.BodyTypeCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.BodyTypeCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BodyTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BodyTypeCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.BodyTypeCombobox.FormattingEnabled = true;
            this.BodyTypeCombobox.Items.AddRange(new object[] {
            resources.GetString("BodyTypeCombobox.Items"),
            resources.GetString("BodyTypeCombobox.Items1"),
            resources.GetString("BodyTypeCombobox.Items2"),
            resources.GetString("BodyTypeCombobox.Items3"),
            resources.GetString("BodyTypeCombobox.Items4")});
            this.BodyTypeCombobox.Name = "BodyTypeCombobox";
            this.BodyTypeCombobox.Sorted = true;
            // 
            // FuelTypeCombobox
            // 
            resources.ApplyResources(this.FuelTypeCombobox, "FuelTypeCombobox");
            this.FuelTypeCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.FuelTypeCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FuelTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FuelTypeCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.FuelTypeCombobox.FormattingEnabled = true;
            this.FuelTypeCombobox.Items.AddRange(new object[] {
            resources.GetString("FuelTypeCombobox.Items"),
            resources.GetString("FuelTypeCombobox.Items1"),
            resources.GetString("FuelTypeCombobox.Items2")});
            this.FuelTypeCombobox.Name = "FuelTypeCombobox";
            // 
            // ColorsCombobox
            // 
            resources.ApplyResources(this.ColorsCombobox, "ColorsCombobox");
            this.ColorsCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.ColorsCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ColorsCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorsCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.ColorsCombobox.FormattingEnabled = true;
            this.ColorsCombobox.Items.AddRange(new object[] {
            resources.GetString("ColorsCombobox.Items"),
            resources.GetString("ColorsCombobox.Items1"),
            resources.GetString("ColorsCombobox.Items2"),
            resources.GetString("ColorsCombobox.Items3"),
            resources.GetString("ColorsCombobox.Items4"),
            resources.GetString("ColorsCombobox.Items5"),
            resources.GetString("ColorsCombobox.Items6"),
            resources.GetString("ColorsCombobox.Items7"),
            resources.GetString("ColorsCombobox.Items8"),
            resources.GetString("ColorsCombobox.Items9"),
            resources.GetString("ColorsCombobox.Items10"),
            resources.GetString("ColorsCombobox.Items11"),
            resources.GetString("ColorsCombobox.Items12")});
            this.ColorsCombobox.Name = "ColorsCombobox";
            this.ColorsCombobox.Sorted = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Name = "label5";
            // 
            // GearboxesCombobox
            // 
            resources.ApplyResources(this.GearboxesCombobox, "GearboxesCombobox");
            this.GearboxesCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.GearboxesCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.GearboxesCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GearboxesCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.GearboxesCombobox.FormattingEnabled = true;
            this.GearboxesCombobox.Items.AddRange(new object[] {
            resources.GetString("GearboxesCombobox.Items"),
            resources.GetString("GearboxesCombobox.Items1"),
            resources.GetString("GearboxesCombobox.Items2")});
            this.GearboxesCombobox.Name = "GearboxesCombobox";
            // 
            // StatusRadioButton
            // 
            resources.ApplyResources(this.StatusRadioButton, "StatusRadioButton");
            this.StatusRadioButton.Name = "StatusRadioButton";
            this.StatusRadioButton.TabStop = true;
            this.StatusRadioButton.UseVisualStyleBackColor = true;
            this.StatusRadioButton.CheckedChanged += new System.EventHandler(this.StatusRadioButton_CheckedChanged);
            // 
            // PriceRadioButton
            // 
            resources.ApplyResources(this.PriceRadioButton, "PriceRadioButton");
            this.PriceRadioButton.Name = "PriceRadioButton";
            this.PriceRadioButton.TabStop = true;
            this.PriceRadioButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Name = "label7";
            // 
            // StatusCombobox
            // 
            resources.ApplyResources(this.StatusCombobox, "StatusCombobox");
            this.StatusCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.StatusCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.StatusCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.StatusCombobox.FormattingEnabled = true;
            this.StatusCombobox.Items.AddRange(new object[] {
            resources.GetString("StatusCombobox.Items"),
            resources.GetString("StatusCombobox.Items1"),
            resources.GetString("StatusCombobox.Items2")});
            this.StatusCombobox.Name = "StatusCombobox";
            // 
            // AreRealMileageCheckbox
            // 
            resources.ApplyResources(this.AreRealMileageCheckbox, "AreRealMileageCheckbox");
            this.AreRealMileageCheckbox.Name = "AreRealMileageCheckbox";
            this.AreRealMileageCheckbox.UseVisualStyleBackColor = true;
            // 
            // NumberOfKeysNumericUpDown
            // 
            resources.ApplyResources(this.NumberOfKeysNumericUpDown, "NumberOfKeysNumericUpDown");
            this.NumberOfKeysNumericUpDown.BackColor = System.Drawing.SystemColors.WindowText;
            this.NumberOfKeysNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumberOfKeysNumericUpDown.ForeColor = System.Drawing.SystemColors.Window;
            this.NumberOfKeysNumericUpDown.Name = "NumberOfKeysNumericUpDown";
            this.NumberOfKeysNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumberOfKeysLabel
            // 
            resources.ApplyResources(this.NumberOfKeysLabel, "NumberOfKeysLabel");
            this.NumberOfKeysLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumberOfKeysLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.NumberOfKeysLabel.Name = "NumberOfKeysLabel";
            // 
            // TiresCombobox
            // 
            resources.ApplyResources(this.TiresCombobox, "TiresCombobox");
            this.TiresCombobox.BackColor = System.Drawing.SystemColors.WindowText;
            this.TiresCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TiresCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TiresCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.TiresCombobox.FormattingEnabled = true;
            this.TiresCombobox.Items.AddRange(new object[] {
            resources.GetString("TiresCombobox.Items"),
            resources.GetString("TiresCombobox.Items1"),
            resources.GetString("TiresCombobox.Items2")});
            this.TiresCombobox.Name = "TiresCombobox";
            this.TiresCombobox.Sorted = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Name = "label6";
            // 
            // PayCaseComboBox
            // 
            resources.ApplyResources(this.PayCaseComboBox, "PayCaseComboBox");
            this.PayCaseComboBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.PayCaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PayCaseComboBox.ForeColor = System.Drawing.SystemColors.Window;
            this.PayCaseComboBox.FormattingEnabled = true;
            this.PayCaseComboBox.Items.AddRange(new object[] {
            resources.GetString("PayCaseComboBox.Items"),
            resources.GetString("PayCaseComboBox.Items1")});
            this.PayCaseComboBox.Name = "PayCaseComboBox";
            this.PayCaseComboBox.Sorted = true;
            // 
            // CategoryCombobox
            // 
            resources.ApplyResources(this.CategoryCombobox, "CategoryCombobox");
            this.CategoryCombobox.BackColor = System.Drawing.SystemColors.InfoText;
            this.CategoryCombobox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CategoryCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryCombobox.ForeColor = System.Drawing.SystemColors.Window;
            this.CategoryCombobox.FormattingEnabled = true;
            this.CategoryCombobox.Items.AddRange(new object[] {
            resources.GetString("CategoryCombobox.Items"),
            resources.GetString("CategoryCombobox.Items1"),
            resources.GetString("CategoryCombobox.Items2"),
            resources.GetString("CategoryCombobox.Items3"),
            resources.GetString("CategoryCombobox.Items4"),
            resources.GetString("CategoryCombobox.Items5"),
            resources.GetString("CategoryCombobox.Items6"),
            resources.GetString("CategoryCombobox.Items7")});
            this.CategoryCombobox.Name = "CategoryCombobox";
            this.CategoryCombobox.Sorted = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Name = "label9";
            // 
            // ExtrasCheckedListBox
            // 
            resources.ApplyResources(this.ExtrasCheckedListBox, "ExtrasCheckedListBox");
            this.ExtrasCheckedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExtrasCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtrasCheckedListBox.CheckOnClick = true;
            this.ExtrasCheckedListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExtrasCheckedListBox.FormattingEnabled = true;
            this.ExtrasCheckedListBox.Items.AddRange(new object[] {
            resources.GetString("ExtrasCheckedListBox.Items"),
            resources.GetString("ExtrasCheckedListBox.Items1"),
            resources.GetString("ExtrasCheckedListBox.Items2"),
            resources.GetString("ExtrasCheckedListBox.Items3"),
            resources.GetString("ExtrasCheckedListBox.Items4"),
            resources.GetString("ExtrasCheckedListBox.Items5"),
            resources.GetString("ExtrasCheckedListBox.Items6"),
            resources.GetString("ExtrasCheckedListBox.Items7"),
            resources.GetString("ExtrasCheckedListBox.Items8"),
            resources.GetString("ExtrasCheckedListBox.Items9"),
            resources.GetString("ExtrasCheckedListBox.Items10"),
            resources.GetString("ExtrasCheckedListBox.Items11"),
            resources.GetString("ExtrasCheckedListBox.Items12"),
            resources.GetString("ExtrasCheckedListBox.Items13"),
            resources.GetString("ExtrasCheckedListBox.Items14"),
            resources.GetString("ExtrasCheckedListBox.Items15"),
            resources.GetString("ExtrasCheckedListBox.Items16"),
            resources.GetString("ExtrasCheckedListBox.Items17"),
            resources.GetString("ExtrasCheckedListBox.Items18"),
            resources.GetString("ExtrasCheckedListBox.Items19"),
            resources.GetString("ExtrasCheckedListBox.Items20"),
            resources.GetString("ExtrasCheckedListBox.Items21"),
            resources.GetString("ExtrasCheckedListBox.Items22"),
            resources.GetString("ExtrasCheckedListBox.Items23"),
            resources.GetString("ExtrasCheckedListBox.Items24"),
            resources.GetString("ExtrasCheckedListBox.Items25"),
            resources.GetString("ExtrasCheckedListBox.Items26"),
            resources.GetString("ExtrasCheckedListBox.Items27"),
            resources.GetString("ExtrasCheckedListBox.Items28"),
            resources.GetString("ExtrasCheckedListBox.Items29"),
            resources.GetString("ExtrasCheckedListBox.Items30"),
            resources.GetString("ExtrasCheckedListBox.Items31"),
            resources.GetString("ExtrasCheckedListBox.Items32"),
            resources.GetString("ExtrasCheckedListBox.Items33"),
            resources.GetString("ExtrasCheckedListBox.Items34"),
            resources.GetString("ExtrasCheckedListBox.Items35"),
            resources.GetString("ExtrasCheckedListBox.Items36"),
            resources.GetString("ExtrasCheckedListBox.Items37"),
            resources.GetString("ExtrasCheckedListBox.Items38"),
            resources.GetString("ExtrasCheckedListBox.Items39"),
            resources.GetString("ExtrasCheckedListBox.Items40"),
            resources.GetString("ExtrasCheckedListBox.Items41"),
            resources.GetString("ExtrasCheckedListBox.Items42"),
            resources.GetString("ExtrasCheckedListBox.Items43"),
            resources.GetString("ExtrasCheckedListBox.Items44"),
            resources.GetString("ExtrasCheckedListBox.Items45"),
            resources.GetString("ExtrasCheckedListBox.Items46"),
            resources.GetString("ExtrasCheckedListBox.Items47"),
            resources.GetString("ExtrasCheckedListBox.Items48"),
            resources.GetString("ExtrasCheckedListBox.Items49"),
            resources.GetString("ExtrasCheckedListBox.Items50"),
            resources.GetString("ExtrasCheckedListBox.Items51"),
            resources.GetString("ExtrasCheckedListBox.Items52"),
            resources.GetString("ExtrasCheckedListBox.Items53"),
            resources.GetString("ExtrasCheckedListBox.Items54"),
            resources.GetString("ExtrasCheckedListBox.Items55"),
            resources.GetString("ExtrasCheckedListBox.Items56"),
            resources.GetString("ExtrasCheckedListBox.Items57"),
            resources.GetString("ExtrasCheckedListBox.Items58"),
            resources.GetString("ExtrasCheckedListBox.Items59"),
            resources.GetString("ExtrasCheckedListBox.Items60"),
            resources.GetString("ExtrasCheckedListBox.Items61"),
            resources.GetString("ExtrasCheckedListBox.Items62"),
            resources.GetString("ExtrasCheckedListBox.Items63"),
            resources.GetString("ExtrasCheckedListBox.Items64"),
            resources.GetString("ExtrasCheckedListBox.Items65"),
            resources.GetString("ExtrasCheckedListBox.Items66"),
            resources.GetString("ExtrasCheckedListBox.Items67"),
            resources.GetString("ExtrasCheckedListBox.Items68"),
            resources.GetString("ExtrasCheckedListBox.Items69"),
            resources.GetString("ExtrasCheckedListBox.Items70"),
            resources.GetString("ExtrasCheckedListBox.Items71"),
            resources.GetString("ExtrasCheckedListBox.Items72"),
            resources.GetString("ExtrasCheckedListBox.Items73"),
            resources.GetString("ExtrasCheckedListBox.Items74"),
            resources.GetString("ExtrasCheckedListBox.Items75"),
            resources.GetString("ExtrasCheckedListBox.Items76"),
            resources.GetString("ExtrasCheckedListBox.Items77"),
            resources.GetString("ExtrasCheckedListBox.Items78"),
            resources.GetString("ExtrasCheckedListBox.Items79"),
            resources.GetString("ExtrasCheckedListBox.Items80"),
            resources.GetString("ExtrasCheckedListBox.Items81"),
            resources.GetString("ExtrasCheckedListBox.Items82"),
            resources.GetString("ExtrasCheckedListBox.Items83")});
            this.ExtrasCheckedListBox.MultiColumn = true;
            this.ExtrasCheckedListBox.Name = "ExtrasCheckedListBox";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.HidePricePanelButton);
            this.panel1.Controls.Add(this.OwnerByBusinessTextbox);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.OwnerByVoucherLabel);
            this.panel1.Controls.Add(this.OwnerByVoucherTextbox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ContractNumberInfoLabel);
            this.panel1.Controls.Add(this.DateOfCreatingAdLabel);
            this.panel1.Controls.Add(this.PayCaseComboBox);
            this.panel1.Name = "panel1";
            // 
            // HidePricePanelButton
            // 
            resources.ApplyResources(this.HidePricePanelButton, "HidePricePanelButton");
            this.HidePricePanelButton.BackColor = System.Drawing.Color.Transparent;
            this.HidePricePanelButton.ForeColor = System.Drawing.SystemColors.Window;
            this.HidePricePanelButton.Name = "HidePricePanelButton";
            this.HidePricePanelButton.UseVisualStyleBackColor = false;
            this.HidePricePanelButton.Click += new System.EventHandler(this.HidePricePanelButton_Click);
            // 
            // OwnerByBusinessTextbox
            // 
            resources.ApplyResources(this.OwnerByBusinessTextbox, "OwnerByBusinessTextbox");
            this.OwnerByBusinessTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.OwnerByBusinessTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.OwnerByBusinessTextbox.Name = "OwnerByBusinessTextbox";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.SystemColors.Window;
            this.label13.Name = "label13";
            // 
            // OwnerByVoucherLabel
            // 
            resources.ApplyResources(this.OwnerByVoucherLabel, "OwnerByVoucherLabel");
            this.OwnerByVoucherLabel.BackColor = System.Drawing.Color.Transparent;
            this.OwnerByVoucherLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.OwnerByVoucherLabel.Name = "OwnerByVoucherLabel";
            // 
            // OwnerByVoucherTextbox
            // 
            resources.ApplyResources(this.OwnerByVoucherTextbox, "OwnerByVoucherTextbox");
            this.OwnerByVoucherTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.OwnerByVoucherTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.OwnerByVoucherTextbox.Name = "OwnerByVoucherTextbox";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Name = "label10";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.SystemColors.Window;
            this.label12.Name = "label12";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.SystemColors.Window;
            this.label14.Name = "label14";
            // 
            // ContractNumberInfoLabel
            // 
            resources.ApplyResources(this.ContractNumberInfoLabel, "ContractNumberInfoLabel");
            this.ContractNumberInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContractNumberInfoLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.ContractNumberInfoLabel.Name = "ContractNumberInfoLabel";
            // 
            // DateOfCreatingAdLabel
            // 
            resources.ApplyResources(this.DateOfCreatingAdLabel, "DateOfCreatingAdLabel");
            this.DateOfCreatingAdLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DateOfCreatingAdLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.DateOfCreatingAdLabel.Name = "DateOfCreatingAdLabel";
            // 
            // HidablePricePanel
            // 
            resources.ApplyResources(this.HidablePricePanel, "HidablePricePanel");
            this.HidablePricePanel.Controls.Add(this.CzsTextbox);
            this.HidablePricePanel.Controls.Add(this.ComissionTextbox);
            this.HidablePricePanel.Controls.Add(this.label24);
            this.HidablePricePanel.Controls.Add(this.label25);
            this.HidablePricePanel.Controls.Add(this.FuelCostsTextbox);
            this.HidablePricePanel.Controls.Add(this.ServiceCostsTextbox);
            this.HidablePricePanel.Controls.Add(this.CosmeticsCostsTextbox);
            this.HidablePricePanel.Controls.Add(this.label21);
            this.HidablePricePanel.Controls.Add(this.label22);
            this.HidablePricePanel.Controls.Add(this.label23);
            this.HidablePricePanel.Controls.Add(this.label20);
            this.HidablePricePanel.Controls.Add(this.label19);
            this.HidablePricePanel.Controls.Add(this.label18);
            this.HidablePricePanel.Controls.Add(this.MaxBillValueTextbox);
            this.HidablePricePanel.Controls.Add(this.MinBillValueTextbox);
            this.HidablePricePanel.Controls.Add(this.DDSTextbox);
            this.HidablePricePanel.Controls.Add(this.label17);
            this.HidablePricePanel.Controls.Add(this.label16);
            this.HidablePricePanel.Controls.Add(this.RealSellingPriceTextbox);
            this.HidablePricePanel.Controls.Add(this.label15);
            this.HidablePricePanel.Name = "HidablePricePanel";
            // 
            // CzsTextbox
            // 
            resources.ApplyResources(this.CzsTextbox, "CzsTextbox");
            this.CzsTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.CzsTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CzsTextbox.Name = "CzsTextbox";
            this.CzsTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CzsTextbox_KeyPress);
            // 
            // ComissionTextbox
            // 
            resources.ApplyResources(this.ComissionTextbox, "ComissionTextbox");
            this.ComissionTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.ComissionTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.ComissionTextbox.Name = "ComissionTextbox";
            this.ComissionTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComissionTextbox_KeyPress);
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.ForeColor = System.Drawing.SystemColors.Window;
            this.label24.Name = "label24";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.ForeColor = System.Drawing.SystemColors.Window;
            this.label25.Name = "label25";
            // 
            // FuelCostsTextbox
            // 
            resources.ApplyResources(this.FuelCostsTextbox, "FuelCostsTextbox");
            this.FuelCostsTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.FuelCostsTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.FuelCostsTextbox.Name = "FuelCostsTextbox";
            this.FuelCostsTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FuelCostsTextbox_KeyPress);
            // 
            // ServiceCostsTextbox
            // 
            resources.ApplyResources(this.ServiceCostsTextbox, "ServiceCostsTextbox");
            this.ServiceCostsTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.ServiceCostsTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.ServiceCostsTextbox.Name = "ServiceCostsTextbox";
            this.ServiceCostsTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServiceCostsTextbox_KeyPress);
            // 
            // CosmeticsCostsTextbox
            // 
            resources.ApplyResources(this.CosmeticsCostsTextbox, "CosmeticsCostsTextbox");
            this.CosmeticsCostsTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.CosmeticsCostsTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.CosmeticsCostsTextbox.Name = "CosmeticsCostsTextbox";
            this.CosmeticsCostsTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CosmeticsCostsTextbox_KeyPress);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.SystemColors.Window;
            this.label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.SystemColors.Window;
            this.label22.Name = "label22";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.ForeColor = System.Drawing.SystemColors.Window;
            this.label23.Name = "label23";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.ForeColor = System.Drawing.SystemColors.Window;
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.ForeColor = System.Drawing.SystemColors.Window;
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.ForeColor = System.Drawing.SystemColors.Window;
            this.label18.Name = "label18";
            // 
            // MaxBillValueTextbox
            // 
            resources.ApplyResources(this.MaxBillValueTextbox, "MaxBillValueTextbox");
            this.MaxBillValueTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.MaxBillValueTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.MaxBillValueTextbox.Name = "MaxBillValueTextbox";
            this.MaxBillValueTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaxBillValueTextbox_KeyPress);
            // 
            // MinBillValueTextbox
            // 
            resources.ApplyResources(this.MinBillValueTextbox, "MinBillValueTextbox");
            this.MinBillValueTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.MinBillValueTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.MinBillValueTextbox.Name = "MinBillValueTextbox";
            this.MinBillValueTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MinBillValueTextbox_KeyPress);
            // 
            // DDSTextbox
            // 
            resources.ApplyResources(this.DDSTextbox, "DDSTextbox");
            this.DDSTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.DDSTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.DDSTextbox.Name = "DDSTextbox";
            this.DDSTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DDSTextbox_KeyPress);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.SystemColors.Window;
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.SystemColors.Window;
            this.label16.Name = "label16";
            // 
            // RealSellingPriceTextbox
            // 
            resources.ApplyResources(this.RealSellingPriceTextbox, "RealSellingPriceTextbox");
            this.RealSellingPriceTextbox.BackColor = System.Drawing.SystemColors.WindowText;
            this.RealSellingPriceTextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.RealSellingPriceTextbox.Name = "RealSellingPriceTextbox";
            this.RealSellingPriceTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RealSellingPriceTextbox_KeyPress);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.SystemColors.Window;
            this.label15.Name = "label15";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // ShowInfoFormButton
            // 
            resources.ApplyResources(this.ShowInfoFormButton, "ShowInfoFormButton");
            this.ShowInfoFormButton.BackColor = System.Drawing.Color.Transparent;
            this.ShowInfoFormButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ShowInfoFormButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ShowInfoFormButton.ForeColor = System.Drawing.SystemColors.Window;
            this.ShowInfoFormButton.Image = global::Dealership1._0.Properties.Resources.icons8_information_filled_24__1_;
            this.ShowInfoFormButton.Name = "ShowInfoFormButton";
            this.ShowInfoFormButton.UseVisualStyleBackColor = false;
            this.ShowInfoFormButton.Click += new System.EventHandler(this.ShowInfoFormButton_Click);
            // 
            // SaveImageButton
            // 
            resources.ApplyResources(this.SaveImageButton, "SaveImageButton");
            this.SaveImageButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveImageButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.SaveImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SaveImageButton.ForeColor = System.Drawing.SystemColors.Window;
            this.SaveImageButton.Image = global::Dealership1._0.Properties.Resources.icons8_upload_24__1_;
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.UseVisualStyleBackColor = false;
            this.SaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // UploadButton
            // 
            resources.ApplyResources(this.UploadButton, "UploadButton");
            this.UploadButton.BackColor = System.Drawing.Color.Transparent;
            this.UploadButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.UploadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UploadButton.ForeColor = System.Drawing.SystemColors.Window;
            this.UploadButton.Image = global::Dealership1._0.Properties.Resources.icons8_browse_folder_filled_24;
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // UpdateButton
            // 
            resources.ApplyResources(this.UpdateButton, "UpdateButton");
            this.UpdateButton.BackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.ForeColor = System.Drawing.SystemColors.Window;
            this.UpdateButton.Image = global::Dealership1._0.Properties.Resources.icons8_synchronize_26__1_;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.VisibleChanged += new System.EventHandler(this.UpdateButton_VisibleChanged);
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // soldButton
            // 
            resources.ApplyResources(this.soldButton, "soldButton");
            this.soldButton.BackColor = System.Drawing.Color.Transparent;
            this.soldButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.soldButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.soldButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.soldButton.ForeColor = System.Drawing.SystemColors.Window;
            this.soldButton.Image = global::Dealership1._0.Properties.Resources.icons8_trash_can_26;
            this.soldButton.Name = "soldButton";
            this.soldButton.UseVisualStyleBackColor = false;
            this.soldButton.Click += new System.EventHandler(this.soldButton_Click);
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addButton.ForeColor = System.Drawing.SystemColors.Window;
            this.addButton.Image = global::Dealership1._0.Properties.Resources.icons8_plus_math_24__1_;
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // OpenPicDirButton
            // 
            resources.ApplyResources(this.OpenPicDirButton, "OpenPicDirButton");
            this.OpenPicDirButton.BackColor = System.Drawing.Color.Transparent;
            this.OpenPicDirButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.OpenPicDirButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OpenPicDirButton.ForeColor = System.Drawing.SystemColors.Window;
            this.OpenPicDirButton.Image = global::Dealership1._0.Properties.Resources.icons8_pictures_folder_filled_24;
            this.OpenPicDirButton.Name = "OpenPicDirButton";
            this.OpenPicDirButton.UseVisualStyleBackColor = false;
            this.OpenPicDirButton.Click += new System.EventHandler(this.OpenPicDirButton_Click);
            // 
            // DielershipUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.OpenPicDirButton);
            this.Controls.Add(this.ShowInfoFormButton);
            this.Controls.Add(this.SaveImageButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HidablePricePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ExtrasCheckedListBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CategoryCombobox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TiresCombobox);
            this.Controls.Add(this.NumberOfKeysLabel);
            this.Controls.Add(this.NumberOfKeysNumericUpDown);
            this.Controls.Add(this.AreRealMileageCheckbox);
            this.Controls.Add(this.StatusCombobox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PriceRadioButton);
            this.Controls.Add(this.StatusRadioButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.GearboxesCombobox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ColorsCombobox);
            this.Controls.Add(this.FuelTypeCombobox);
            this.Controls.Add(this.BodyTypeCombobox);
            this.Controls.Add(this.ModelCombobox);
            this.Controls.Add(this.BrandsComboBox);
            this.Controls.Add(this.VinTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.additionalCarInfoTextBox);
            this.Controls.Add(this.soldButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.InfoTextboxLabel);
            this.Controls.Add(this.mileageTextBox);
            this.Controls.Add(this.productionDateTextBox);
            this.Controls.Add(this.horsePowerTextBox);
            this.Controls.Add(this.EngineVolumeCCTextBox);
            this.Controls.Add(this.mileageLabel);
            this.Controls.Add(this.productionDateLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.fuelTypeLabel);
            this.Controls.Add(this.enginePowerLabel);
            this.Controls.Add(this.engineVolumeLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.brandLabel);
            this.Controls.Add(this.carsListBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DielershipUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DielershipUI_FormClosed);
            this.Load += new System.EventHandler(this.DielershipUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfKeysNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.HidablePricePanel.ResumeLayout(false);
            this.HidablePricePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion
        private System.Windows.Forms.ListBox carsListBox;
        private System.Windows.Forms.Label brandLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label engineVolumeLabel;
        private System.Windows.Forms.Label enginePowerLabel;
        private System.Windows.Forms.Label fuelTypeLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label productionDateLabel;
        private System.Windows.Forms.Label mileageLabel;
        private System.Windows.Forms.TextBox EngineVolumeCCTextBox;
        private System.Windows.Forms.TextBox productionDateTextBox;
        private System.Windows.Forms.TextBox horsePowerTextBox;
        private System.Windows.Forms.TextBox mileageTextBox;
        private System.Windows.Forms.Label InfoTextboxLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button soldButton;
        private System.Windows.Forms.TextBox additionalCarInfoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VinTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BrandsComboBox;
        private System.Windows.Forms.ComboBox ModelCombobox;
        private System.Windows.Forms.ComboBox BodyTypeCombobox;
        private System.Windows.Forms.ComboBox FuelTypeCombobox;
        private System.Windows.Forms.ComboBox ColorsCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox GearboxesCombobox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.RadioButton StatusRadioButton;
        private System.Windows.Forms.RadioButton PriceRadioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox StatusCombobox;
        private System.Windows.Forms.CheckBox AreRealMileageCheckbox;
        private System.Windows.Forms.NumericUpDown NumberOfKeysNumericUpDown;
        private System.Windows.Forms.Label NumberOfKeysLabel;
        private System.Windows.Forms.ComboBox TiresCombobox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PayCaseComboBox;
        private System.Windows.Forms.ComboBox CategoryCombobox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox ExtrasCheckedListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox OwnerByBusinessTextbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label OwnerByVoucherLabel;
        private System.Windows.Forms.TextBox OwnerByVoucherTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label ContractNumberInfoLabel;
        private System.Windows.Forms.Label DateOfCreatingAdLabel;
        private System.Windows.Forms.Panel HidablePricePanel;
        private System.Windows.Forms.TextBox FuelCostsTextbox;
        private System.Windows.Forms.TextBox ServiceCostsTextbox;
        private System.Windows.Forms.TextBox CosmeticsCostsTextbox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox MaxBillValueTextbox;
        private System.Windows.Forms.TextBox MinBillValueTextbox;
        private System.Windows.Forms.TextBox DDSTextbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox RealSellingPriceTextbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button HidePricePanelButton;
        private System.Windows.Forms.TextBox CzsTextbox;
        private System.Windows.Forms.TextBox ComissionTextbox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button SaveImageButton;
        private System.Windows.Forms.Button ShowInfoFormButton;
        private System.Windows.Forms.Button OpenPicDirButton;
    }
}

