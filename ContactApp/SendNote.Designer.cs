
using ContactApp.Components;

namespace ContactApp
{
    partial class SendNote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        ///
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
            this.legalNameLabel = new System.Windows.Forms.Label();
            this.dbaNameLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.legalNameTextBox = new System.Windows.Forms.TextBox();
            this.dbaNameTextBox = new System.Windows.Forms.TextBox();
            this.fromZipCodeLabel = new System.Windows.Forms.Label();
            this.toZipCodeLabel = new System.Windows.Forms.Label();
            this.fromZipCodeTextBox = new System.Windows.Forms.TextBox();
            this.toZipCoeTextBox = new System.Windows.Forms.TextBox();
            this.toPhoneTextBox = new System.Windows.Forms.TextBox();
            this.fromPhoneTextBox = new System.Windows.Forms.TextBox();
            this.toPhoneLabel = new System.Windows.Forms.Label();
            this.fromPhoneLabel = new System.Windows.Forms.Label();
            this.phoneBookLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.filteredDataGridView = new System.Windows.Forms.DataGridView();
            this.faxToTextBox = new System.Windows.Forms.TextBox();
            this.faxFromTextBox = new System.Windows.Forms.TextBox();
            this.faxToLabel = new System.Windows.Forms.Label();
            this.faxFromLabel = new System.Windows.Forms.Label();
            this.mcNumberTextBox = new System.Windows.Forms.TextBox();
            this.mcNumberLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.noteTxtBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.lastUpdateToLabel = new System.Windows.Forms.Label();
            this.lastUpdateFromLabel = new System.Windows.Forms.Label();
            this.toUSDOTLabel = new System.Windows.Forms.Label();
            this.fromUSDOTTextBox = new System.Windows.Forms.TextBox();
            this.toUSDOTTextBox = new System.Windows.Forms.TextBox();
            this.fromUSDOTLabel = new System.Windows.Forms.Label();
            this.fromCALabel = new System.Windows.Forms.Label();
            this.toCATextBox = new System.Windows.Forms.TextBox();
            this.fromCATextBox = new System.Windows.Forms.TextBox();
            this.toCALabel = new System.Windows.Forms.Label();
            this.fromApcantIDLabel = new System.Windows.Forms.Label();
            this.toApcantIDTextBox = new System.Windows.Forms.TextBox();
            this.fromApcantIDTextBox = new System.Windows.Forms.TextBox();
            this.toApcantIDLabel = new System.Windows.Forms.Label();
            this.phoneGroupBox = new System.Windows.Forms.GroupBox();
            this.lastUpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.toLastUpdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromLastUpdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.zipCodeGroupBox = new System.Windows.Forms.GroupBox();
            this.usDotNumerGroupBox = new System.Windows.Forms.GroupBox();
            this.faxGroupBox = new System.Windows.Forms.GroupBox();
            this.apcantIDGroupBox = new System.Windows.Forms.GroupBox();
            this.caNumberGroupBox = new System.Windows.Forms.GroupBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.categoryCheckedComboBox = new ContactApp.Components.CheckedComboBox();
            this.phoneBookCheckedComboBox = new ContactApp.Components.CheckedComboBox();
            this.countryCheckedComboBox = new ContactApp.Components.CheckedComboBox();
            this.stateCheckedComboBox = new ContactApp.Components.CheckedComboBox();
            this.cityCheckedComboBox = new ContactApp.Components.CheckedComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.filteredDataGridView)).BeginInit();
            this.phoneGroupBox.SuspendLayout();
            this.lastUpdateGroupBox.SuspendLayout();
            this.zipCodeGroupBox.SuspendLayout();
            this.usDotNumerGroupBox.SuspendLayout();
            this.faxGroupBox.SuspendLayout();
            this.apcantIDGroupBox.SuspendLayout();
            this.caNumberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // legalNameLabel
            // 
            this.legalNameLabel.AutoSize = true;
            this.legalNameLabel.Location = new System.Drawing.Point(43, 116);
            this.legalNameLabel.Name = "legalNameLabel";
            this.legalNameLabel.Size = new System.Drawing.Size(80, 17);
            this.legalNameLabel.TabIndex = 2;
            this.legalNameLabel.Text = "LegalName";
            // 
            // dbaNameLabel
            // 
            this.dbaNameLabel.AutoSize = true;
            this.dbaNameLabel.Location = new System.Drawing.Point(412, 116);
            this.dbaNameLabel.Name = "dbaNameLabel";
            this.dbaNameLabel.Size = new System.Drawing.Size(73, 17);
            this.dbaNameLabel.TabIndex = 3;
            this.dbaNameLabel.Text = "DBAName";
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(43, 293);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(31, 17);
            this.cityLabel.TabIndex = 11;
            this.cityLabel.Text = "City";
            // 
            // stateLabel
            // 
            this.stateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(412, 294);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(41, 17);
            this.stateLabel.TabIndex = 13;
            this.stateLabel.Text = "State";
            // 
            // countryLabel
            // 
            this.countryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(767, 294);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(57, 17);
            this.countryLabel.TabIndex = 14;
            this.countryLabel.Text = "Country";
            // 
            // legalNameTextBox
            // 
            this.legalNameTextBox.Location = new System.Drawing.Point(137, 112);
            this.legalNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.legalNameTextBox.Name = "legalNameTextBox";
            this.legalNameTextBox.Size = new System.Drawing.Size(165, 22);
            this.legalNameTextBox.TabIndex = 19;
            this.legalNameTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // dbaNameTextBox
            // 
            this.dbaNameTextBox.Location = new System.Drawing.Point(511, 112);
            this.dbaNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dbaNameTextBox.Name = "dbaNameTextBox";
            this.dbaNameTextBox.Size = new System.Drawing.Size(163, 22);
            this.dbaNameTextBox.TabIndex = 20;
            this.dbaNameTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // fromZipCodeLabel
            // 
            this.fromZipCodeLabel.AutoSize = true;
            this.fromZipCodeLabel.Location = new System.Drawing.Point(21, 25);
            this.fromZipCodeLabel.Name = "fromZipCodeLabel";
            this.fromZipCodeLabel.Size = new System.Drawing.Size(40, 17);
            this.fromZipCodeLabel.TabIndex = 28;
            this.fromZipCodeLabel.Text = "From";
            // 
            // toZipCodeLabel
            // 
            this.toZipCodeLabel.AutoSize = true;
            this.toZipCodeLabel.Location = new System.Drawing.Point(21, 54);
            this.toZipCodeLabel.Name = "toZipCodeLabel";
            this.toZipCodeLabel.Size = new System.Drawing.Size(25, 17);
            this.toZipCodeLabel.TabIndex = 29;
            this.toZipCodeLabel.Text = "To";
            // 
            // fromZipCodeTextBox
            // 
            this.fromZipCodeTextBox.Location = new System.Drawing.Point(91, 20);
            this.fromZipCodeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromZipCodeTextBox.Name = "fromZipCodeTextBox";
            this.fromZipCodeTextBox.Size = new System.Drawing.Size(165, 22);
            this.fromZipCodeTextBox.TabIndex = 30;
            this.fromZipCodeTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // toZipCoeTextBox
            // 
            this.toZipCoeTextBox.Location = new System.Drawing.Point(91, 50);
            this.toZipCoeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toZipCoeTextBox.Name = "toZipCoeTextBox";
            this.toZipCoeTextBox.Size = new System.Drawing.Size(165, 22);
            this.toZipCoeTextBox.TabIndex = 31;
            this.toZipCoeTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // toPhoneTextBox
            // 
            this.toPhoneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toPhoneTextBox.Location = new System.Drawing.Point(91, 50);
            this.toPhoneTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toPhoneTextBox.Name = "toPhoneTextBox";
            this.toPhoneTextBox.Size = new System.Drawing.Size(165, 22);
            this.toPhoneTextBox.TabIndex = 35;
            this.toPhoneTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // fromPhoneTextBox
            // 
            this.fromPhoneTextBox.Location = new System.Drawing.Point(91, 21);
            this.fromPhoneTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromPhoneTextBox.Name = "fromPhoneTextBox";
            this.fromPhoneTextBox.Size = new System.Drawing.Size(165, 22);
            this.fromPhoneTextBox.TabIndex = 34;
            this.fromPhoneTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // toPhoneLabel
            // 
            this.toPhoneLabel.AutoSize = true;
            this.toPhoneLabel.Location = new System.Drawing.Point(13, 54);
            this.toPhoneLabel.Name = "toPhoneLabel";
            this.toPhoneLabel.Size = new System.Drawing.Size(25, 17);
            this.toPhoneLabel.TabIndex = 33;
            this.toPhoneLabel.Text = "To";
            // 
            // fromPhoneLabel
            // 
            this.fromPhoneLabel.AutoSize = true;
            this.fromPhoneLabel.Location = new System.Drawing.Point(13, 28);
            this.fromPhoneLabel.Name = "fromPhoneLabel";
            this.fromPhoneLabel.Size = new System.Drawing.Size(40, 17);
            this.fromPhoneLabel.TabIndex = 32;
            this.fromPhoneLabel.Text = "From";
            // 
            // phoneBookLabel
            // 
            this.phoneBookLabel.AutoSize = true;
            this.phoneBookLabel.Location = new System.Drawing.Point(43, 39);
            this.phoneBookLabel.Name = "phoneBookLabel";
            this.phoneBookLabel.Size = new System.Drawing.Size(81, 17);
            this.phoneBookLabel.TabIndex = 38;
            this.phoneBookLabel.Text = "PhoneBook";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(413, 39);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(65, 17);
            this.categoryLabel.TabIndex = 39;
            this.categoryLabel.Text = "Category";
            // 
            // filteredDataGridView
            // 
            this.filteredDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filteredDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.filteredDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filteredDataGridView.Location = new System.Drawing.Point(37, 450);
            this.filteredDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filteredDataGridView.Name = "filteredDataGridView";
            this.filteredDataGridView.RowHeadersWidth = 51;
            this.filteredDataGridView.RowTemplate.Height = 24;
            this.filteredDataGridView.Size = new System.Drawing.Size(1027, 293);
            this.filteredDataGridView.TabIndex = 40;
            // 
            // faxToTextBox
            // 
            this.faxToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.faxToTextBox.Location = new System.Drawing.Point(99, 57);
            this.faxToTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.faxToTextBox.Name = "faxToTextBox";
            this.faxToTextBox.Size = new System.Drawing.Size(163, 22);
            this.faxToTextBox.TabIndex = 46;
            this.faxToTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // faxFromTextBox
            // 
            this.faxFromTextBox.Location = new System.Drawing.Point(96, 25);
            this.faxFromTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.faxFromTextBox.Name = "faxFromTextBox";
            this.faxFromTextBox.Size = new System.Drawing.Size(165, 22);
            this.faxFromTextBox.TabIndex = 45;
            this.faxFromTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // faxToLabel
            // 
            this.faxToLabel.AutoSize = true;
            this.faxToLabel.Location = new System.Drawing.Point(17, 60);
            this.faxToLabel.Name = "faxToLabel";
            this.faxToLabel.Size = new System.Drawing.Size(25, 17);
            this.faxToLabel.TabIndex = 44;
            this.faxToLabel.Text = "To";
            // 
            // faxFromLabel
            // 
            this.faxFromLabel.AutoSize = true;
            this.faxFromLabel.Location = new System.Drawing.Point(17, 32);
            this.faxFromLabel.Name = "faxFromLabel";
            this.faxFromLabel.Size = new System.Drawing.Size(40, 17);
            this.faxFromLabel.TabIndex = 43;
            this.faxFromLabel.Text = "From";
            // 
            // mcNumberTextBox
            // 
            this.mcNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mcNumberTextBox.Location = new System.Drawing.Point(868, 112);
            this.mcNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mcNumberTextBox.Name = "mcNumberTextBox";
            this.mcNumberTextBox.Size = new System.Drawing.Size(164, 22);
            this.mcNumberTextBox.TabIndex = 48;
            this.mcNumberTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // mcNumberLabel
            // 
            this.mcNumberLabel.AutoSize = true;
            this.mcNumberLabel.Location = new System.Drawing.Point(767, 116);
            this.mcNumberLabel.Name = "mcNumberLabel";
            this.mcNumberLabel.Size = new System.Drawing.Size(78, 17);
            this.mcNumberLabel.TabIndex = 47;
            this.mcNumberLabel.Text = "MCNumber";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(39, 810);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(38, 17);
            this.noteLabel.TabIndex = 49;
            this.noteLabel.Text = "Note";
            // 
            // noteTxtBox
            // 
            this.noteTxtBox.Location = new System.Drawing.Point(83, 807);
            this.noteTxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noteTxtBox.Multiline = true;
            this.noteTxtBox.Name = "noteTxtBox";
            this.noteTxtBox.Size = new System.Drawing.Size(808, 145);
            this.noteTxtBox.TabIndex = 50;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(983, 916);
            this.sendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(81, 36);
            this.sendButton.TabIndex = 51;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // lastUpdateToLabel
            // 
            this.lastUpdateToLabel.AutoSize = true;
            this.lastUpdateToLabel.Location = new System.Drawing.Point(17, 54);
            this.lastUpdateToLabel.Name = "lastUpdateToLabel";
            this.lastUpdateToLabel.Size = new System.Drawing.Size(25, 17);
            this.lastUpdateToLabel.TabIndex = 52;
            this.lastUpdateToLabel.Text = "To";
            // 
            // lastUpdateFromLabel
            // 
            this.lastUpdateFromLabel.AutoSize = true;
            this.lastUpdateFromLabel.Location = new System.Drawing.Point(17, 26);
            this.lastUpdateFromLabel.Name = "lastUpdateFromLabel";
            this.lastUpdateFromLabel.Size = new System.Drawing.Size(40, 17);
            this.lastUpdateFromLabel.TabIndex = 55;
            this.lastUpdateFromLabel.Text = "From";
            // 
            // toUSDOTLabel
            // 
            this.toUSDOTLabel.AutoSize = true;
            this.toUSDOTLabel.Location = new System.Drawing.Point(13, 65);
            this.toUSDOTLabel.Name = "toUSDOTLabel";
            this.toUSDOTLabel.Size = new System.Drawing.Size(25, 17);
            this.toUSDOTLabel.TabIndex = 52;
            this.toUSDOTLabel.Text = "To";
            // 
            // fromUSDOTTextBox
            // 
            this.fromUSDOTTextBox.Location = new System.Drawing.Point(91, 34);
            this.fromUSDOTTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromUSDOTTextBox.Name = "fromUSDOTTextBox";
            this.fromUSDOTTextBox.Size = new System.Drawing.Size(165, 22);
            this.fromUSDOTTextBox.TabIndex = 53;
            this.fromUSDOTTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // toUSDOTTextBox
            // 
            this.toUSDOTTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toUSDOTTextBox.Location = new System.Drawing.Point(91, 63);
            this.toUSDOTTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toUSDOTTextBox.Name = "toUSDOTTextBox";
            this.toUSDOTTextBox.Size = new System.Drawing.Size(165, 22);
            this.toUSDOTTextBox.TabIndex = 54;
            this.toUSDOTTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // fromUSDOTLabel
            // 
            this.fromUSDOTLabel.AutoSize = true;
            this.fromUSDOTLabel.Location = new System.Drawing.Point(13, 37);
            this.fromUSDOTLabel.Name = "fromUSDOTLabel";
            this.fromUSDOTLabel.Size = new System.Drawing.Size(40, 17);
            this.fromUSDOTLabel.TabIndex = 55;
            this.fromUSDOTLabel.Text = "From";
            // 
            // fromCALabel
            // 
            this.fromCALabel.AutoSize = true;
            this.fromCALabel.Location = new System.Drawing.Point(13, 28);
            this.fromCALabel.Name = "fromCALabel";
            this.fromCALabel.Size = new System.Drawing.Size(40, 17);
            this.fromCALabel.TabIndex = 59;
            this.fromCALabel.Text = "From";
            // 
            // toCATextBox
            // 
            this.toCATextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toCATextBox.Location = new System.Drawing.Point(91, 53);
            this.toCATextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toCATextBox.Name = "toCATextBox";
            this.toCATextBox.Size = new System.Drawing.Size(165, 22);
            this.toCATextBox.TabIndex = 58;
            this.toCATextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // fromCATextBox
            // 
            this.fromCATextBox.Location = new System.Drawing.Point(91, 25);
            this.fromCATextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromCATextBox.Name = "fromCATextBox";
            this.fromCATextBox.Size = new System.Drawing.Size(165, 22);
            this.fromCATextBox.TabIndex = 57;
            this.fromCATextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // toCALabel
            // 
            this.toCALabel.AutoSize = true;
            this.toCALabel.Location = new System.Drawing.Point(13, 57);
            this.toCALabel.Name = "toCALabel";
            this.toCALabel.Size = new System.Drawing.Size(25, 17);
            this.toCALabel.TabIndex = 56;
            this.toCALabel.Text = "To";
            // 
            // fromApcantIDLabel
            // 
            this.fromApcantIDLabel.AutoSize = true;
            this.fromApcantIDLabel.Location = new System.Drawing.Point(15, 36);
            this.fromApcantIDLabel.Name = "fromApcantIDLabel";
            this.fromApcantIDLabel.Size = new System.Drawing.Size(40, 17);
            this.fromApcantIDLabel.TabIndex = 63;
            this.fromApcantIDLabel.Text = "From";
            // 
            // toApcantIDTextBox
            // 
            this.toApcantIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toApcantIDTextBox.Location = new System.Drawing.Point(96, 62);
            this.toApcantIDTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toApcantIDTextBox.Name = "toApcantIDTextBox";
            this.toApcantIDTextBox.Size = new System.Drawing.Size(165, 22);
            this.toApcantIDTextBox.TabIndex = 62;
            this.toApcantIDTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // fromApcantIDTextBox
            // 
            this.fromApcantIDTextBox.Location = new System.Drawing.Point(97, 34);
            this.fromApcantIDTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromApcantIDTextBox.Name = "fromApcantIDTextBox";
            this.fromApcantIDTextBox.Size = new System.Drawing.Size(164, 22);
            this.fromApcantIDTextBox.TabIndex = 61;
            this.fromApcantIDTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // toApcantIDLabel
            // 
            this.toApcantIDLabel.AutoSize = true;
            this.toApcantIDLabel.Location = new System.Drawing.Point(15, 63);
            this.toApcantIDLabel.Name = "toApcantIDLabel";
            this.toApcantIDLabel.Size = new System.Drawing.Size(25, 17);
            this.toApcantIDLabel.TabIndex = 60;
            this.toApcantIDLabel.Text = "To";
            // 
            // phoneGroupBox
            // 
            this.phoneGroupBox.Controls.Add(this.fromPhoneTextBox);
            this.phoneGroupBox.Controls.Add(this.fromPhoneLabel);
            this.phoneGroupBox.Controls.Add(this.toPhoneLabel);
            this.phoneGroupBox.Controls.Add(this.toPhoneTextBox);
            this.phoneGroupBox.Location = new System.Drawing.Point(417, 346);
            this.phoneGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneGroupBox.Name = "phoneGroupBox";
            this.phoneGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneGroupBox.Size = new System.Drawing.Size(268, 89);
            this.phoneGroupBox.TabIndex = 66;
            this.phoneGroupBox.TabStop = false;
            this.phoneGroupBox.Text = "Phone";

            // 
            // lastUpdateGroupBox
            // 
            this.lastUpdateGroupBox.Controls.Add(this.toLastUpdateDateTimePicker);
            this.lastUpdateGroupBox.Controls.Add(this.fromLastUpdateDateTimePicker);
            this.lastUpdateGroupBox.Controls.Add(this.lastUpdateToLabel);
            this.lastUpdateGroupBox.Controls.Add(this.lastUpdateFromLabel);
            this.lastUpdateGroupBox.Location = new System.Drawing.Point(771, 14);
            this.lastUpdateGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastUpdateGroupBox.Name = "lastUpdateGroupBox";
            this.lastUpdateGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastUpdateGroupBox.Size = new System.Drawing.Size(349, 85);
            this.lastUpdateGroupBox.TabIndex = 67;
            this.lastUpdateGroupBox.TabStop = false;
            this.lastUpdateGroupBox.Text = "LastUpdate";

            // 
            // toLastUpdateDateTimePicker
            // 
            this.toLastUpdateDateTimePicker.Location = new System.Drawing.Point(71, 47);
            this.toLastUpdateDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.toLastUpdateDateTimePicker.Name = "toLastUpdateDateTimePicker";
            this.toLastUpdateDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.toLastUpdateDateTimePicker.TabIndex = 74;
            this.toLastUpdateDateTimePicker.ValueChanged += new System.EventHandler(this.toLastUpdateDateTimePicker_ValueChanged);
            // 
            // fromLastUpdateDateTimePicker
            // 
            this.fromLastUpdateDateTimePicker.Location = new System.Drawing.Point(71, 18);
            this.fromLastUpdateDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.fromLastUpdateDateTimePicker.Name = "fromLastUpdateDateTimePicker";
            this.fromLastUpdateDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.fromLastUpdateDateTimePicker.TabIndex = 73;
            this.fromLastUpdateDateTimePicker.ValueChanged += new System.EventHandler(this.fromLastUpdateDateTimePicker_ValueChanged);
            // 
            // zipCodeGroupBox
            // 
            this.zipCodeGroupBox.Controls.Add(this.fromZipCodeTextBox);
            this.zipCodeGroupBox.Controls.Add(this.fromZipCodeLabel);
            this.zipCodeGroupBox.Controls.Add(this.toZipCodeLabel);
            this.zipCodeGroupBox.Controls.Add(this.toZipCoeTextBox);
            this.zipCodeGroupBox.Location = new System.Drawing.Point(47, 346);
            this.zipCodeGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zipCodeGroupBox.Name = "zipCodeGroupBox";
            this.zipCodeGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zipCodeGroupBox.Size = new System.Drawing.Size(269, 89);
            this.zipCodeGroupBox.TabIndex = 68;
            this.zipCodeGroupBox.TabStop = false;
            this.zipCodeGroupBox.Text = "ZipCode";
            // 
            // usDotNumerGroupBox
            // 
            this.usDotNumerGroupBox.Controls.Add(this.fromUSDOTLabel);
            this.usDotNumerGroupBox.Controls.Add(this.toUSDOTLabel);
            this.usDotNumerGroupBox.Controls.Add(this.fromUSDOTTextBox);
            this.usDotNumerGroupBox.Controls.Add(this.toUSDOTTextBox);
            this.usDotNumerGroupBox.Location = new System.Drawing.Point(47, 161);
            this.usDotNumerGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usDotNumerGroupBox.Name = "usDotNumerGroupBox";
            this.usDotNumerGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usDotNumerGroupBox.Size = new System.Drawing.Size(269, 96);
            this.usDotNumerGroupBox.TabIndex = 69;
            this.usDotNumerGroupBox.TabStop = false;
            this.usDotNumerGroupBox.Text = "USDOTNumber";
            // 
            // faxGroupBox
            // 
            this.faxGroupBox.Controls.Add(this.faxFromLabel);
            this.faxGroupBox.Controls.Add(this.faxToLabel);
            this.faxGroupBox.Controls.Add(this.faxFromTextBox);
            this.faxGroupBox.Controls.Add(this.faxToTextBox);
            this.faxGroupBox.Location = new System.Drawing.Point(771, 346);
            this.faxGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.faxGroupBox.Name = "faxGroupBox";
            this.faxGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.faxGroupBox.Size = new System.Drawing.Size(269, 89);
            this.faxGroupBox.TabIndex = 70;
            this.faxGroupBox.TabStop = false;
            this.faxGroupBox.Text = "Fax";
            // 
            // apcantIDGroupBox
            // 
            this.apcantIDGroupBox.Controls.Add(this.fromApcantIDLabel);
            this.apcantIDGroupBox.Controls.Add(this.toApcantIDLabel);
            this.apcantIDGroupBox.Controls.Add(this.fromApcantIDTextBox);
            this.apcantIDGroupBox.Controls.Add(this.toApcantIDTextBox);
            this.apcantIDGroupBox.Location = new System.Drawing.Point(771, 161);
            this.apcantIDGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.apcantIDGroupBox.Name = "apcantIDGroupBox";
            this.apcantIDGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.apcantIDGroupBox.Size = new System.Drawing.Size(269, 86);
            this.apcantIDGroupBox.TabIndex = 71;
            this.apcantIDGroupBox.TabStop = false;
            this.apcantIDGroupBox.Text = "ApcantID";
            // 
            // caNumberGroupBox
            // 
            this.caNumberGroupBox.Controls.Add(this.fromCALabel);
            this.caNumberGroupBox.Controls.Add(this.toCALabel);
            this.caNumberGroupBox.Controls.Add(this.fromCATextBox);
            this.caNumberGroupBox.Controls.Add(this.toCATextBox);
            this.caNumberGroupBox.Location = new System.Drawing.Point(417, 170);
            this.caNumberGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.caNumberGroupBox.Name = "caNumberGroupBox";
            this.caNumberGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.caNumberGroupBox.Size = new System.Drawing.Size(268, 87);
            this.caNumberGroupBox.TabIndex = 72;
            this.caNumberGroupBox.TabStop = false;
            this.caNumberGroupBox.Text = "CANumber";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(43, 78);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(41, 17);
            this.codeLabel.TabIndex = 2;
            this.codeLabel.Text = "Code";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(137, 74);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(165, 22);
            this.codeTextBox.TabIndex = 19;
            this.codeTextBox.TextChanged += new System.EventHandler(this.component_TextChanged);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(92, 761);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(211, 22);
            this.titleTextBox.TabIndex = 74;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(39, 764);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 17);
            this.titleLabel.TabIndex = 73;
            this.titleLabel.Text = "Title";
            // 
            // categoryCheckedComboBox
            // 
            this.categoryCheckedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryCheckedComboBox.CheckOnClick = true;
            this.categoryCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.categoryCheckedComboBox.DropDownHeight = 1;
            this.categoryCheckedComboBox.FormattingEnabled = true;
            this.categoryCheckedComboBox.IntegralHeight = false;
            this.categoryCheckedComboBox.Location = new System.Drawing.Point(508, 34);
            this.categoryCheckedComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoryCheckedComboBox.Name = "categoryCheckedComboBox";
            this.categoryCheckedComboBox.Size = new System.Drawing.Size(165, 23);
            this.categoryCheckedComboBox.TabIndex = 65;
            this.categoryCheckedComboBox.ValueSeparator = ", ";
            this.categoryCheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.categoryCheckedComboBox_ItemCheck);
            // 
            // phoneBookCheckedComboBox
            // 
            this.phoneBookCheckedComboBox.CheckOnClick = true;
            this.phoneBookCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.phoneBookCheckedComboBox.DropDownHeight = 1;
            this.phoneBookCheckedComboBox.FormattingEnabled = true;
            this.phoneBookCheckedComboBox.IntegralHeight = false;
            this.phoneBookCheckedComboBox.Location = new System.Drawing.Point(137, 34);
            this.phoneBookCheckedComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneBookCheckedComboBox.Name = "phoneBookCheckedComboBox";
            this.phoneBookCheckedComboBox.Size = new System.Drawing.Size(165, 23);
            this.phoneBookCheckedComboBox.TabIndex = 64;
            this.phoneBookCheckedComboBox.ValueSeparator = ", ";
            this.phoneBookCheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.phoneBookCheckedComboBox_ItemCheck);
            // 
            // countryCheckedComboBox
            // 
            this.countryCheckedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countryCheckedComboBox.CheckOnClick = true;
            this.countryCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.countryCheckedComboBox.DropDownHeight = 1;
            this.countryCheckedComboBox.FormattingEnabled = true;
            this.countryCheckedComboBox.IntegralHeight = false;
            this.countryCheckedComboBox.Location = new System.Drawing.Point(868, 290);
            this.countryCheckedComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.countryCheckedComboBox.Name = "countryCheckedComboBox";
            this.countryCheckedComboBox.Size = new System.Drawing.Size(165, 23);
            this.countryCheckedComboBox.TabIndex = 42;
            this.countryCheckedComboBox.ValueSeparator = ", ";
            this.countryCheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.countryCheckedComboBox_ItemCheck);
            // 
            // stateCheckedComboBox
            // 
            this.stateCheckedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stateCheckedComboBox.CheckOnClick = true;
            this.stateCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.stateCheckedComboBox.DropDownHeight = 1;
            this.stateCheckedComboBox.FormattingEnabled = true;
            this.stateCheckedComboBox.IntegralHeight = false;
            this.stateCheckedComboBox.Location = new System.Drawing.Point(508, 290);
            this.stateCheckedComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stateCheckedComboBox.Name = "stateCheckedComboBox";
            this.stateCheckedComboBox.Size = new System.Drawing.Size(165, 23);
            this.stateCheckedComboBox.TabIndex = 41;
            this.stateCheckedComboBox.ValueSeparator = ", ";
            this.stateCheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.stateCheckedComboBox_ItemCheck);
            // 
            // cityCheckedComboBox
            // 
            this.cityCheckedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cityCheckedComboBox.CheckOnClick = true;
            this.cityCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cityCheckedComboBox.DropDownHeight = 1;
            this.cityCheckedComboBox.IntegralHeight = false;
            this.cityCheckedComboBox.Location = new System.Drawing.Point(137, 290);
            this.cityCheckedComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cityCheckedComboBox.Name = "cityCheckedComboBox";
            this.cityCheckedComboBox.Size = new System.Drawing.Size(165, 23);
            this.cityCheckedComboBox.TabIndex = 0;
            this.cityCheckedComboBox.ValueSeparator = ", ";
            this.cityCheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cityCheckedComboBox_ItemCheck);
            // 
            // SendNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1227, 1050);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.caNumberGroupBox);
            this.Controls.Add(this.apcantIDGroupBox);
            this.Controls.Add(this.faxGroupBox);
            this.Controls.Add(this.usDotNumerGroupBox);
            this.Controls.Add(this.zipCodeGroupBox);
            this.Controls.Add(this.lastUpdateGroupBox);
            this.Controls.Add(this.phoneGroupBox);
            this.Controls.Add(this.categoryCheckedComboBox);
            this.Controls.Add(this.phoneBookCheckedComboBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.noteTxtBox);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.mcNumberTextBox);
            this.Controls.Add(this.mcNumberLabel);
            this.Controls.Add(this.countryCheckedComboBox);
            this.Controls.Add(this.stateCheckedComboBox);
            this.Controls.Add(this.cityCheckedComboBox);
            this.Controls.Add(this.filteredDataGridView);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.phoneBookLabel);
            this.Controls.Add(this.dbaNameTextBox);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.legalNameTextBox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.dbaNameLabel);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.legalNameLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1245, 1101);
            this.Name = "SendNote";
            this.Text = "SendNote";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SendNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filteredDataGridView)).EndInit();
            this.phoneGroupBox.ResumeLayout(false);
            this.phoneGroupBox.PerformLayout();
            this.lastUpdateGroupBox.ResumeLayout(false);
            this.lastUpdateGroupBox.PerformLayout();
            this.zipCodeGroupBox.ResumeLayout(false);
            this.zipCodeGroupBox.PerformLayout();
            this.usDotNumerGroupBox.ResumeLayout(false);
            this.usDotNumerGroupBox.PerformLayout();
            this.faxGroupBox.ResumeLayout(false);
            this.faxGroupBox.PerformLayout();
            this.apcantIDGroupBox.ResumeLayout(false);
            this.apcantIDGroupBox.PerformLayout();
            this.caNumberGroupBox.ResumeLayout(false);
            this.caNumberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label legalNameLabel;
        private System.Windows.Forms.Label dbaNameLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox legalNameTextBox;
        private System.Windows.Forms.TextBox dbaNameTextBox;
        private System.Windows.Forms.Label fromZipCodeLabel;
        private System.Windows.Forms.Label toZipCodeLabel;
        private System.Windows.Forms.TextBox fromZipCodeTextBox;
        private System.Windows.Forms.TextBox toZipCoeTextBox;
        private System.Windows.Forms.TextBox toPhoneTextBox;
        private System.Windows.Forms.TextBox fromPhoneTextBox;
        private System.Windows.Forms.Label toPhoneLabel;
        private System.Windows.Forms.Label fromPhoneLabel;
        private System.Windows.Forms.Label phoneBookLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.DataGridView filteredDataGridView;
        private CheckedComboBox cityCheckedComboBox;
        private CheckedComboBox stateCheckedComboBox;
        private CheckedComboBox countryCheckedComboBox;
        private System.Windows.Forms.TextBox faxToTextBox;
        private System.Windows.Forms.TextBox faxFromTextBox;
        private System.Windows.Forms.Label faxToLabel;
        private System.Windows.Forms.Label faxFromLabel;
        private System.Windows.Forms.TextBox mcNumberTextBox;
        private System.Windows.Forms.Label mcNumberLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.TextBox noteTxtBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label lastUpdateToLabel;
        private System.Windows.Forms.Label lastUpdateFromLabel;
        private System.Windows.Forms.Label toUSDOTLabel;
        private System.Windows.Forms.TextBox fromUSDOTTextBox;
        private System.Windows.Forms.TextBox toUSDOTTextBox;
        private System.Windows.Forms.Label fromUSDOTLabel;
        private System.Windows.Forms.Label fromCALabel;
        private System.Windows.Forms.TextBox toCATextBox;
        private System.Windows.Forms.TextBox fromCATextBox;
        private System.Windows.Forms.Label toCALabel;
        private System.Windows.Forms.Label fromApcantIDLabel;
        private System.Windows.Forms.TextBox toApcantIDTextBox;
        private System.Windows.Forms.TextBox fromApcantIDTextBox;
        private System.Windows.Forms.Label toApcantIDLabel;
        private CheckedComboBox phoneBookCheckedComboBox;
        private CheckedComboBox categoryCheckedComboBox;
        private System.Windows.Forms.GroupBox phoneGroupBox;
        private System.Windows.Forms.GroupBox lastUpdateGroupBox;
        private System.Windows.Forms.GroupBox zipCodeGroupBox;
        private System.Windows.Forms.GroupBox usDotNumerGroupBox;
        private System.Windows.Forms.GroupBox faxGroupBox;
        private System.Windows.Forms.GroupBox apcantIDGroupBox;
        private System.Windows.Forms.GroupBox caNumberGroupBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.DateTimePicker fromLastUpdateDateTimePicker;
        private System.Windows.Forms.DateTimePicker toLastUpdateDateTimePicker;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
    }
}