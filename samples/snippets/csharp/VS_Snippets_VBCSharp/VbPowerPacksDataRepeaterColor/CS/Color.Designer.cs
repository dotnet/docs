namespace RepeaterColor
{
    partial class Color
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Color));
            System.Windows.Forms.Label contactIDLabel;
            System.Windows.Forms.Label contactTypeLabel;
            System.Windows.Forms.Label companyNameLabel;
            System.Windows.Forms.Label contactNameLabel;
            System.Windows.Forms.Label contactTitleLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label regionLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label countryLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label extensionLabel;
            System.Windows.Forms.Label faxLabel;
            System.Windows.Forms.Label homePageLabel;
            System.Windows.Forms.Label photoPathLabel;
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.button1 = new System.Windows.Forms.Button();
            this.northwndDataSet = new RepeaterColor.northwndDataSet();
            this.contactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactsTableAdapter = new RepeaterColor.northwndDataSetTableAdapters.ContactsTableAdapter();
            this.tableAdapterManager = new RepeaterColor.northwndDataSetTableAdapters.TableAdapterManager();
            this.contactsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.contactsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.contactIDTextBox = new System.Windows.Forms.TextBox();
            this.contactTypeTextBox = new System.Windows.Forms.TextBox();
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.contactNameTextBox = new System.Windows.Forms.TextBox();
            this.contactTitleTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.postalCodeTextBox = new System.Windows.Forms.TextBox();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.extensionTextBox = new System.Windows.Forms.TextBox();
            this.faxTextBox = new System.Windows.Forms.TextBox();
            this.homePageTextBox = new System.Windows.Forms.TextBox();
            this.photoPathTextBox = new System.Windows.Forms.TextBox();
            contactIDLabel = new System.Windows.Forms.Label();
            contactTypeLabel = new System.Windows.Forms.Label();
            companyNameLabel = new System.Windows.Forms.Label();
            contactNameLabel = new System.Windows.Forms.Label();
            contactTitleLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            regionLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            countryLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            extensionLabel = new System.Windows.Forms.Label();
            faxLabel = new System.Windows.Forms.Label();
            homePageLabel = new System.Windows.Forms.Label();
            photoPathLabel = new System.Windows.Forms.Label();
            this.dataRepeater1.ItemTemplate.SuspendLayout();
            this.dataRepeater1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.northwndDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingNavigator)).BeginInit();
            this.contactsBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRepeater1
            // 
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Controls.Add(contactIDLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.contactIDTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(contactTypeLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.contactTypeTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(companyNameLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.companyNameTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(contactNameLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.contactNameTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(contactTitleLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.contactTitleTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(addressLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.addressTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(cityLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.cityTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(regionLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.regionTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(postalCodeLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.postalCodeTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(countryLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.countryTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(phoneLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.phoneTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(extensionLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.extensionTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(faxLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.faxTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(homePageLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.homePageTextBox);
            this.dataRepeater1.ItemTemplate.Controls.Add(photoPathLabel);
            this.dataRepeater1.ItemTemplate.Controls.Add(this.photoPathTextBox);
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(332, 458);
            this.dataRepeater1.Location = new System.Drawing.Point(29, 81);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(357, 463);
            this.dataRepeater1.TabIndex = 0;
            this.dataRepeater1.Text = "dataRepeater1";
            this.dataRepeater1.LayoutStyleChanged += new System.EventHandler(this.dataRepeater1_LayoutStyleChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // northwndDataSet
            // 
            this.northwndDataSet.DataSetName = "northwndDataSet";
            this.northwndDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contactsBindingSource
            // 
            this.contactsBindingSource.DataMember = "Contacts";
            this.contactsBindingSource.DataSource = this.northwndDataSet;
            // 
            // contactsTableAdapter
            // 
            this.contactsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ContactsTableAdapter = this.contactsTableAdapter;
            this.tableAdapterManager.UpdateOrder = RepeaterColor.northwndDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // contactsBindingNavigator
            // 
            this.contactsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.contactsBindingNavigator.BindingSource = this.contactsBindingSource;
            this.contactsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.contactsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.contactsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.contactsBindingNavigatorSaveItem});
            this.contactsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.contactsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.contactsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.contactsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.contactsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.contactsBindingNavigator.Name = "contactsBindingNavigator";
            this.contactsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.contactsBindingNavigator.Size = new System.Drawing.Size(595, 25);
            this.contactsBindingNavigator.TabIndex = 2;
            this.contactsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 13);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // contactsBindingNavigatorSaveItem
            // 
            this.contactsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.contactsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("contactsBindingNavigatorSaveItem.Image")));
            this.contactsBindingNavigatorSaveItem.Name = "contactsBindingNavigatorSaveItem";
            this.contactsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.contactsBindingNavigatorSaveItem.Text = "Save Data";
            this.contactsBindingNavigatorSaveItem.Click += new System.EventHandler(this.contactsBindingNavigatorSaveItem_Click);
            // 
            // contactIDLabel
            // 
            contactIDLabel.AutoSize = true;
            contactIDLabel.Location = new System.Drawing.Point(35, 39);
            contactIDLabel.Name = "contactIDLabel";
            contactIDLabel.Size = new System.Drawing.Size(61, 13);
            contactIDLabel.TabIndex = 0;
            contactIDLabel.Text = "Contact ID:";
            // 
            // contactIDTextBox
            // 
            this.contactIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "ContactID", true));
            this.contactIDTextBox.Location = new System.Drawing.Point(126, 36);
            this.contactIDTextBox.Name = "contactIDTextBox";
            this.contactIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactIDTextBox.TabIndex = 1;
            // 
            // contactTypeLabel
            // 
            contactTypeLabel.AutoSize = true;
            contactTypeLabel.Location = new System.Drawing.Point(35, 65);
            contactTypeLabel.Name = "contactTypeLabel";
            contactTypeLabel.Size = new System.Drawing.Size(74, 13);
            contactTypeLabel.TabIndex = 2;
            contactTypeLabel.Text = "Contact Type:";
            // 
            // contactTypeTextBox
            // 
            this.contactTypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "ContactType", true));
            this.contactTypeTextBox.Location = new System.Drawing.Point(126, 62);
            this.contactTypeTextBox.Name = "contactTypeTextBox";
            this.contactTypeTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactTypeTextBox.TabIndex = 3;
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new System.Drawing.Point(35, 91);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new System.Drawing.Size(85, 13);
            companyNameLabel.TabIndex = 4;
            companyNameLabel.Text = "Company Name:";
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "CompanyName", true));
            this.companyNameTextBox.Location = new System.Drawing.Point(126, 88);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.companyNameTextBox.TabIndex = 5;
            // 
            // contactNameLabel
            // 
            contactNameLabel.AutoSize = true;
            contactNameLabel.Location = new System.Drawing.Point(35, 117);
            contactNameLabel.Name = "contactNameLabel";
            contactNameLabel.Size = new System.Drawing.Size(78, 13);
            contactNameLabel.TabIndex = 6;
            contactNameLabel.Text = "Contact Name:";
            // 
            // contactNameTextBox
            // 
            this.contactNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "ContactName", true));
            this.contactNameTextBox.Location = new System.Drawing.Point(126, 114);
            this.contactNameTextBox.Name = "contactNameTextBox";
            this.contactNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactNameTextBox.TabIndex = 7;
            // 
            // contactTitleLabel
            // 
            contactTitleLabel.AutoSize = true;
            contactTitleLabel.Location = new System.Drawing.Point(35, 143);
            contactTitleLabel.Name = "contactTitleLabel";
            contactTitleLabel.Size = new System.Drawing.Size(70, 13);
            contactTitleLabel.TabIndex = 8;
            contactTitleLabel.Text = "Contact Title:";
            // 
            // contactTitleTextBox
            // 
            this.contactTitleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "ContactTitle", true));
            this.contactTitleTextBox.Location = new System.Drawing.Point(126, 140);
            this.contactTitleTextBox.Name = "contactTitleTextBox";
            this.contactTitleTextBox.Size = new System.Drawing.Size(100, 20);
            this.contactTitleTextBox.TabIndex = 9;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(35, 169);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 10;
            addressLabel.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(126, 166);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressTextBox.TabIndex = 11;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(35, 195);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(27, 13);
            cityLabel.TabIndex = 12;
            cityLabel.Text = "City:";
            // 
            // cityTextBox
            // 
            this.cityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "City", true));
            this.cityTextBox.Location = new System.Drawing.Point(126, 192);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(100, 20);
            this.cityTextBox.TabIndex = 13;
            // 
            // regionLabel
            // 
            regionLabel.AutoSize = true;
            regionLabel.Location = new System.Drawing.Point(35, 221);
            regionLabel.Name = "regionLabel";
            regionLabel.Size = new System.Drawing.Size(44, 13);
            regionLabel.TabIndex = 14;
            regionLabel.Text = "Region:";
            // 
            // regionTextBox
            // 
            this.regionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "Region", true));
            this.regionTextBox.Location = new System.Drawing.Point(126, 218);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(100, 20);
            this.regionTextBox.TabIndex = 15;
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(35, 247);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(67, 13);
            postalCodeLabel.TabIndex = 16;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "PostalCode", true));
            this.postalCodeTextBox.Location = new System.Drawing.Point(126, 244);
            this.postalCodeTextBox.Name = "postalCodeTextBox";
            this.postalCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.postalCodeTextBox.TabIndex = 17;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new System.Drawing.Point(35, 273);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(46, 13);
            countryLabel.TabIndex = 18;
            countryLabel.Text = "Country:";
            // 
            // countryTextBox
            // 
            this.countryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "Country", true));
            this.countryTextBox.Location = new System.Drawing.Point(126, 270);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(100, 20);
            this.countryTextBox.TabIndex = 19;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(35, 299);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(41, 13);
            phoneLabel.TabIndex = 20;
            phoneLabel.Text = "Phone:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "Phone", true));
            this.phoneTextBox.Location = new System.Drawing.Point(126, 296);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 21;
            // 
            // extensionLabel
            // 
            extensionLabel.AutoSize = true;
            extensionLabel.Location = new System.Drawing.Point(35, 325);
            extensionLabel.Name = "extensionLabel";
            extensionLabel.Size = new System.Drawing.Size(56, 13);
            extensionLabel.TabIndex = 22;
            extensionLabel.Text = "Extension:";
            // 
            // extensionTextBox
            // 
            this.extensionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "Extension", true));
            this.extensionTextBox.Location = new System.Drawing.Point(126, 322);
            this.extensionTextBox.Name = "extensionTextBox";
            this.extensionTextBox.Size = new System.Drawing.Size(100, 20);
            this.extensionTextBox.TabIndex = 23;
            // 
            // faxLabel
            // 
            faxLabel.AutoSize = true;
            faxLabel.Location = new System.Drawing.Point(35, 351);
            faxLabel.Name = "faxLabel";
            faxLabel.Size = new System.Drawing.Size(27, 13);
            faxLabel.TabIndex = 24;
            faxLabel.Text = "Fax:";
            // 
            // faxTextBox
            // 
            this.faxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "Fax", true));
            this.faxTextBox.Location = new System.Drawing.Point(126, 348);
            this.faxTextBox.Name = "faxTextBox";
            this.faxTextBox.Size = new System.Drawing.Size(100, 20);
            this.faxTextBox.TabIndex = 25;
            // 
            // homePageLabel
            // 
            homePageLabel.AutoSize = true;
            homePageLabel.Location = new System.Drawing.Point(35, 377);
            homePageLabel.Name = "homePageLabel";
            homePageLabel.Size = new System.Drawing.Size(66, 13);
            homePageLabel.TabIndex = 26;
            homePageLabel.Text = "Home Page:";
            // 
            // homePageTextBox
            // 
            this.homePageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "HomePage", true));
            this.homePageTextBox.Location = new System.Drawing.Point(126, 374);
            this.homePageTextBox.Name = "homePageTextBox";
            this.homePageTextBox.Size = new System.Drawing.Size(100, 20);
            this.homePageTextBox.TabIndex = 27;
            // 
            // photoPathLabel
            // 
            photoPathLabel.AutoSize = true;
            photoPathLabel.Location = new System.Drawing.Point(35, 403);
            photoPathLabel.Name = "photoPathLabel";
            photoPathLabel.Size = new System.Drawing.Size(63, 13);
            photoPathLabel.TabIndex = 28;
            photoPathLabel.Text = "Photo Path:";
            // 
            // photoPathTextBox
            // 
            this.photoPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactsBindingSource, "PhotoPath", true));
            this.photoPathTextBox.Location = new System.Drawing.Point(126, 400);
            this.photoPathTextBox.Name = "photoPathTextBox";
            this.photoPathTextBox.Size = new System.Drawing.Size(100, 20);
            this.photoPathTextBox.TabIndex = 29;
            // 
            // Color
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 544);
            this.Controls.Add(this.contactsBindingNavigator);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataRepeater1);
            this.Name = "Color";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Color_Load);
            this.dataRepeater1.ItemTemplate.ResumeLayout(false);
            this.dataRepeater1.ItemTemplate.PerformLayout();
            this.dataRepeater1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.northwndDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingNavigator)).EndInit();
            this.contactsBindingNavigator.ResumeLayout(false);
            this.contactsBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.Button button1;
        private northwndDataSet northwndDataSet;
        private System.Windows.Forms.BindingSource contactsBindingSource;
        private RepeaterColor.northwndDataSetTableAdapters.ContactsTableAdapter contactsTableAdapter;
        private RepeaterColor.northwndDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator contactsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton contactsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox contactIDTextBox;
        private System.Windows.Forms.TextBox contactTypeTextBox;
        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.TextBox contactNameTextBox;
        private System.Windows.Forms.TextBox contactTitleTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox extensionTextBox;
        private System.Windows.Forms.TextBox faxTextBox;
        private System.Windows.Forms.TextBox homePageTextBox;
        private System.Windows.Forms.TextBox photoPathTextBox;
    }
}

