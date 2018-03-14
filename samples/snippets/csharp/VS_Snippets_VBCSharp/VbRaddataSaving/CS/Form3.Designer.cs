namespace CS
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing&&(components!=null))
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
            this.components=new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources=new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label companyNameLabel;
            System.Windows.Forms.Label contactNameLabel;
            System.Windows.Forms.Label contactTitleLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label regionLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label countryLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label faxLabel;
            this.northwindDataSet=new CS.NorthwindDataSet();
            this.customersBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.customersTableAdapter=new CS.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.customersBindingNavigator=new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator=new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem=new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem=new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1=new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2=new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem=new System.Windows.Forms.ToolStripButton();
            this.customersBindingNavigatorSaveItem=new System.Windows.Forms.ToolStripButton();
            this.customerIDTextBox=new System.Windows.Forms.TextBox();
            this.companyNameTextBox=new System.Windows.Forms.TextBox();
            this.contactNameTextBox=new System.Windows.Forms.TextBox();
            this.contactTitleTextBox=new System.Windows.Forms.TextBox();
            this.addressTextBox=new System.Windows.Forms.TextBox();
            this.cityTextBox=new System.Windows.Forms.TextBox();
            this.regionTextBox=new System.Windows.Forms.TextBox();
            this.postalCodeTextBox=new System.Windows.Forms.TextBox();
            this.countryTextBox=new System.Windows.Forms.TextBox();
            this.phoneTextBox=new System.Windows.Forms.TextBox();
            this.faxTextBox=new System.Windows.Forms.TextBox();
            customerIDLabel=new System.Windows.Forms.Label();
            companyNameLabel=new System.Windows.Forms.Label();
            contactNameLabel=new System.Windows.Forms.Label();
            contactTitleLabel=new System.Windows.Forms.Label();
            addressLabel=new System.Windows.Forms.Label();
            cityLabel=new System.Windows.Forms.Label();
            regionLabel=new System.Windows.Forms.Label();
            postalCodeLabel=new System.Windows.Forms.Label();
            countryLabel=new System.Windows.Forms.Label();
            phoneLabel=new System.Windows.Forms.Label();
            faxLabel=new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingNavigator)).BeginInit();
            this.customersBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName="NorthwindDataSet";
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember="Customers";
            this.customersBindingSource.DataSource=this.northwindDataSet;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill=true;
            // 
            // customersBindingNavigator
            // 
            this.customersBindingNavigator.AddNewItem=this.bindingNavigatorAddNewItem;
            this.customersBindingNavigator.BindingSource=this.customersBindingSource;
            this.customersBindingNavigator.CountItem=this.bindingNavigatorCountItem;
            this.customersBindingNavigator.DeleteItem=this.bindingNavigatorDeleteItem;
            this.customersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.customersBindingNavigatorSaveItem});
            this.customersBindingNavigator.Location=new System.Drawing.Point(0, 0);
            this.customersBindingNavigator.MoveFirstItem=this.bindingNavigatorMoveFirstItem;
            this.customersBindingNavigator.MoveLastItem=this.bindingNavigatorMoveLastItem;
            this.customersBindingNavigator.MoveNextItem=this.bindingNavigatorMoveNextItem;
            this.customersBindingNavigator.MovePreviousItem=this.bindingNavigatorMovePreviousItem;
            this.customersBindingNavigator.Name="customersBindingNavigator";
            this.customersBindingNavigator.PositionItem=this.bindingNavigatorPositionItem;
            this.customersBindingNavigator.Size=new System.Drawing.Size(357, 25);
            this.customersBindingNavigator.TabIndex=0;
            this.customersBindingNavigator.Text="bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name="bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorMoveFirstItem.Size=new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text="Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name="bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorMovePreviousItem.Size=new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text="Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name="bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size=new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName="Position";
            this.bindingNavigatorPositionItem.AutoSize=false;
            this.bindingNavigatorPositionItem.Name="bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size=new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text="0";
            this.bindingNavigatorPositionItem.ToolTipText="Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name="bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size=new System.Drawing.Size(36, 13);
            this.bindingNavigatorCountItem.Text="of {0}";
            this.bindingNavigatorCountItem.ToolTipText="Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name="bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size=new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name="bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorMoveNextItem.Size=new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text="Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name="bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorMoveLastItem.Size=new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text="Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name="bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size=new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name="bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorAddNewItem.Size=new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text="Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name="bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorDeleteItem.Size=new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text="Delete";
            // 
            // customersBindingNavigatorSaveItem
            // 
            this.customersBindingNavigatorSaveItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.customersBindingNavigatorSaveItem.Image=((System.Drawing.Image)(resources.GetObject("customersBindingNavigatorSaveItem.Image")));
            this.customersBindingNavigatorSaveItem.Name="customersBindingNavigatorSaveItem";
            this.customersBindingNavigatorSaveItem.Size=new System.Drawing.Size(23, 23);
            this.customersBindingNavigatorSaveItem.Text="Save Data";
            this.customersBindingNavigatorSaveItem.Click+=new System.EventHandler(this.customersBindingNavigatorSaveItem_Click);
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize=true;
            customerIDLabel.Location=new System.Drawing.Point(12, 36);
            customerIDLabel.Name="customerIDLabel";
            customerIDLabel.Size=new System.Drawing.Size(68, 13);
            customerIDLabel.TabIndex=1;
            customerIDLabel.Text="Customer ID:";
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "CustomerID", true));
            this.customerIDTextBox.Location=new System.Drawing.Point(103, 33);
            this.customerIDTextBox.Name="customerIDTextBox";
            this.customerIDTextBox.Size=new System.Drawing.Size(100, 20);
            this.customerIDTextBox.TabIndex=2;
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize=true;
            companyNameLabel.Location=new System.Drawing.Point(12, 62);
            companyNameLabel.Name="companyNameLabel";
            companyNameLabel.Size=new System.Drawing.Size(85, 13);
            companyNameLabel.TabIndex=3;
            companyNameLabel.Text="Company Name:";
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "CompanyName", true));
            this.companyNameTextBox.Location=new System.Drawing.Point(103, 59);
            this.companyNameTextBox.Name="companyNameTextBox";
            this.companyNameTextBox.Size=new System.Drawing.Size(100, 20);
            this.companyNameTextBox.TabIndex=4;
            // 
            // contactNameLabel
            // 
            contactNameLabel.AutoSize=true;
            contactNameLabel.Location=new System.Drawing.Point(12, 88);
            contactNameLabel.Name="contactNameLabel";
            contactNameLabel.Size=new System.Drawing.Size(78, 13);
            contactNameLabel.TabIndex=5;
            contactNameLabel.Text="Contact Name:";
            // 
            // contactNameTextBox
            // 
            this.contactNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "ContactName", true));
            this.contactNameTextBox.Location=new System.Drawing.Point(103, 85);
            this.contactNameTextBox.Name="contactNameTextBox";
            this.contactNameTextBox.Size=new System.Drawing.Size(100, 20);
            this.contactNameTextBox.TabIndex=6;
            // 
            // contactTitleLabel
            // 
            contactTitleLabel.AutoSize=true;
            contactTitleLabel.Location=new System.Drawing.Point(12, 114);
            contactTitleLabel.Name="contactTitleLabel";
            contactTitleLabel.Size=new System.Drawing.Size(70, 13);
            contactTitleLabel.TabIndex=7;
            contactTitleLabel.Text="Contact Title:";
            // 
            // contactTitleTextBox
            // 
            this.contactTitleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "ContactTitle", true));
            this.contactTitleTextBox.Location=new System.Drawing.Point(103, 111);
            this.contactTitleTextBox.Name="contactTitleTextBox";
            this.contactTitleTextBox.Size=new System.Drawing.Size(100, 20);
            this.contactTitleTextBox.TabIndex=8;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize=true;
            addressLabel.Location=new System.Drawing.Point(12, 140);
            addressLabel.Name="addressLabel";
            addressLabel.Size=new System.Drawing.Size(48, 13);
            addressLabel.TabIndex=9;
            addressLabel.Text="Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Address", true));
            this.addressTextBox.Location=new System.Drawing.Point(103, 137);
            this.addressTextBox.Name="addressTextBox";
            this.addressTextBox.Size=new System.Drawing.Size(100, 20);
            this.addressTextBox.TabIndex=10;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize=true;
            cityLabel.Location=new System.Drawing.Point(12, 166);
            cityLabel.Name="cityLabel";
            cityLabel.Size=new System.Drawing.Size(27, 13);
            cityLabel.TabIndex=11;
            cityLabel.Text="City:";
            // 
            // cityTextBox
            // 
            this.cityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "City", true));
            this.cityTextBox.Location=new System.Drawing.Point(103, 163);
            this.cityTextBox.Name="cityTextBox";
            this.cityTextBox.Size=new System.Drawing.Size(100, 20);
            this.cityTextBox.TabIndex=12;
            // 
            // regionLabel
            // 
            regionLabel.AutoSize=true;
            regionLabel.Location=new System.Drawing.Point(12, 192);
            regionLabel.Name="regionLabel";
            regionLabel.Size=new System.Drawing.Size(44, 13);
            regionLabel.TabIndex=13;
            regionLabel.Text="Region:";
            // 
            // regionTextBox
            // 
            this.regionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Region", true));
            this.regionTextBox.Location=new System.Drawing.Point(103, 189);
            this.regionTextBox.Name="regionTextBox";
            this.regionTextBox.Size=new System.Drawing.Size(100, 20);
            this.regionTextBox.TabIndex=14;
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize=true;
            postalCodeLabel.Location=new System.Drawing.Point(12, 218);
            postalCodeLabel.Name="postalCodeLabel";
            postalCodeLabel.Size=new System.Drawing.Size(67, 13);
            postalCodeLabel.TabIndex=15;
            postalCodeLabel.Text="Postal Code:";
            // 
            // postalCodeTextBox
            // 
            this.postalCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "PostalCode", true));
            this.postalCodeTextBox.Location=new System.Drawing.Point(103, 215);
            this.postalCodeTextBox.Name="postalCodeTextBox";
            this.postalCodeTextBox.Size=new System.Drawing.Size(100, 20);
            this.postalCodeTextBox.TabIndex=16;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize=true;
            countryLabel.Location=new System.Drawing.Point(12, 244);
            countryLabel.Name="countryLabel";
            countryLabel.Size=new System.Drawing.Size(46, 13);
            countryLabel.TabIndex=17;
            countryLabel.Text="Country:";
            // 
            // countryTextBox
            // 
            this.countryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Country", true));
            this.countryTextBox.Location=new System.Drawing.Point(103, 241);
            this.countryTextBox.Name="countryTextBox";
            this.countryTextBox.Size=new System.Drawing.Size(100, 20);
            this.countryTextBox.TabIndex=18;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize=true;
            phoneLabel.Location=new System.Drawing.Point(12, 270);
            phoneLabel.Name="phoneLabel";
            phoneLabel.Size=new System.Drawing.Size(41, 13);
            phoneLabel.TabIndex=19;
            phoneLabel.Text="Phone:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Phone", true));
            this.phoneTextBox.Location=new System.Drawing.Point(103, 267);
            this.phoneTextBox.Name="phoneTextBox";
            this.phoneTextBox.Size=new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex=20;
            // 
            // faxLabel
            // 
            faxLabel.AutoSize=true;
            faxLabel.Location=new System.Drawing.Point(12, 296);
            faxLabel.Name="faxLabel";
            faxLabel.Size=new System.Drawing.Size(27, 13);
            faxLabel.TabIndex=21;
            faxLabel.Text="Fax:";
            // 
            // faxTextBox
            // 
            this.faxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Fax", true));
            this.faxTextBox.Location=new System.Drawing.Point(103, 293);
            this.faxTextBox.Name="faxTextBox";
            this.faxTextBox.Size=new System.Drawing.Size(100, 20);
            this.faxTextBox.TabIndex=22;
            // 
            // Form3
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(357, 330);
            this.Controls.Add(customerIDLabel);
            this.Controls.Add(this.customerIDTextBox);
            this.Controls.Add(companyNameLabel);
            this.Controls.Add(this.companyNameTextBox);
            this.Controls.Add(contactNameLabel);
            this.Controls.Add(this.contactNameTextBox);
            this.Controls.Add(contactTitleLabel);
            this.Controls.Add(this.contactTitleTextBox);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(cityLabel);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(regionLabel);
            this.Controls.Add(this.regionTextBox);
            this.Controls.Add(postalCodeLabel);
            this.Controls.Add(this.postalCodeTextBox);
            this.Controls.Add(countryLabel);
            this.Controls.Add(this.countryTextBox);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(faxLabel);
            this.Controls.Add(this.faxTextBox);
            this.Controls.Add(this.customersBindingNavigator);
            this.Name="Form3";
            this.Text="Form3";
            this.Load+=new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingNavigator)).EndInit();
            this.customersBindingNavigator.ResumeLayout(false);
            this.customersBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NorthwindDataSet northwindDataSet;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private CS.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private System.Windows.Forms.BindingNavigator customersBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton customersBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox customerIDTextBox;
        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.TextBox contactNameTextBox;
        private System.Windows.Forms.TextBox contactTitleTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.TextBox postalCodeTextBox;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox faxTextBox;
    }
}