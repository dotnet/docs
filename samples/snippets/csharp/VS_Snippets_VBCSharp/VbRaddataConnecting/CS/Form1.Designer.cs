namespace ObjectBindingWalkthrough
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources=new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.customerBindingNavigator=new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem=new System.Windows.Forms.ToolStripButton();
            this.customerBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem=new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator=new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem=new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1=new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem=new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2=new System.Windows.Forms.ToolStripSeparator();
            this.customerBindingNavigatorSaveItem=new System.Windows.Forms.ToolStripButton();
            this.customerDataGridView=new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.ordersDataGridView=new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.northwindDataSet1=new ObjectBindingWalkthrough.NorthwindDataSet();
            this.customersTableAdapter1=new ObjectBindingWalkthrough.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.ordersTableAdapter1=new ObjectBindingWalkthrough.NorthwindDataSetTableAdapters.OrdersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingNavigator)).BeginInit();
            this.customerBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerBindingNavigator
            // 
            this.customerBindingNavigator.AddNewItem=this.bindingNavigatorAddNewItem;
            this.customerBindingNavigator.BindingSource=this.customerBindingSource;
            this.customerBindingNavigator.CountItem=this.bindingNavigatorCountItem;
            this.customerBindingNavigator.DeleteItem=this.bindingNavigatorDeleteItem;
            this.customerBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.customerBindingNavigatorSaveItem});
            this.customerBindingNavigator.Location=new System.Drawing.Point(0, 0);
            this.customerBindingNavigator.MoveFirstItem=this.bindingNavigatorMoveFirstItem;
            this.customerBindingNavigator.MoveLastItem=this.bindingNavigatorMoveLastItem;
            this.customerBindingNavigator.MoveNextItem=this.bindingNavigatorMoveNextItem;
            this.customerBindingNavigator.MovePreviousItem=this.bindingNavigatorMovePreviousItem;
            this.customerBindingNavigator.Name="customerBindingNavigator";
            this.customerBindingNavigator.PositionItem=this.bindingNavigatorPositionItem;
            this.customerBindingNavigator.Size=new System.Drawing.Size(646, 25);
            this.customerBindingNavigator.TabIndex=0;
            this.customerBindingNavigator.Text="bindingNavigator1";
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
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource=typeof(ObjectBindingWalkthrough.Customer);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name="bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size=new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text="of {0}";
            this.bindingNavigatorCountItem.ToolTipText="Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name="bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorDeleteItem.Size=new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text="Delete";
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
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name="bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size=new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name="bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorMoveNextItem.Size=new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text="Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image=((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name="bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage=true;
            this.bindingNavigatorMoveLastItem.Size=new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text="Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name="bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size=new System.Drawing.Size(6, 25);
            // 
            // customerBindingNavigatorSaveItem
            // 
            this.customerBindingNavigatorSaveItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.customerBindingNavigatorSaveItem.Enabled=false;
            this.customerBindingNavigatorSaveItem.Image=((System.Drawing.Image)(resources.GetObject("customerBindingNavigatorSaveItem.Image")));
            this.customerBindingNavigatorSaveItem.Name="customerBindingNavigatorSaveItem";
            this.customerBindingNavigatorSaveItem.Size=new System.Drawing.Size(23, 22);
            this.customerBindingNavigatorSaveItem.Text="Save Data";
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.AutoGenerateColumns=false;
            this.customerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.customerDataGridView.DataSource=this.customerBindingSource;
            this.customerDataGridView.ImeMode=System.Windows.Forms.ImeMode.Disable;
            this.customerDataGridView.Location=new System.Drawing.Point(12, 52);
            this.customerDataGridView.Name="customerDataGridView";
            this.customerDataGridView.Size=new System.Drawing.Size(300, 220);
            this.customerDataGridView.TabIndex=1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName="Fax";
            this.dataGridViewTextBoxColumn1.HeaderText="Fax";
            this.dataGridViewTextBoxColumn1.Name="dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName="City";
            this.dataGridViewTextBoxColumn2.HeaderText="City";
            this.dataGridViewTextBoxColumn2.Name="dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName="PostalCode";
            this.dataGridViewTextBoxColumn3.HeaderText="PostalCode";
            this.dataGridViewTextBoxColumn3.Name="dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName="CustomerID";
            this.dataGridViewTextBoxColumn4.HeaderText="CustomerID";
            this.dataGridViewTextBoxColumn4.Name="dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName="Phone";
            this.dataGridViewTextBoxColumn5.HeaderText="Phone";
            this.dataGridViewTextBoxColumn5.Name="dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName="Address";
            this.dataGridViewTextBoxColumn6.HeaderText="Address";
            this.dataGridViewTextBoxColumn6.Name="dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName="Country";
            this.dataGridViewTextBoxColumn7.HeaderText="Country";
            this.dataGridViewTextBoxColumn7.Name="dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName="ContactTitle";
            this.dataGridViewTextBoxColumn8.HeaderText="ContactTitle";
            this.dataGridViewTextBoxColumn8.Name="dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName="CompanyName";
            this.dataGridViewTextBoxColumn9.HeaderText="CompanyName";
            this.dataGridViewTextBoxColumn9.Name="dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName="ContactName";
            this.dataGridViewTextBoxColumn10.HeaderText="ContactName";
            this.dataGridViewTextBoxColumn10.Name="dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName="Region";
            this.dataGridViewTextBoxColumn11.HeaderText="Region";
            this.dataGridViewTextBoxColumn11.Name="dataGridViewTextBoxColumn11";
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember="Orders";
            this.ordersBindingSource.DataSource=this.customerBindingSource;
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AutoGenerateColumns=false;
            this.ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25});
            this.ordersDataGridView.DataSource=this.ordersBindingSource;
            this.ordersDataGridView.ImeMode=System.Windows.Forms.ImeMode.Disable;
            this.ordersDataGridView.Location=new System.Drawing.Point(334, 52);
            this.ordersDataGridView.Name="ordersDataGridView";
            this.ordersDataGridView.Size=new System.Drawing.Size(300, 220);
            this.ordersDataGridView.TabIndex=2;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName="ShipCountry";
            this.dataGridViewTextBoxColumn12.HeaderText="ShipCountry";
            this.dataGridViewTextBoxColumn12.Name="dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName="ShipName";
            this.dataGridViewTextBoxColumn13.HeaderText="ShipName";
            this.dataGridViewTextBoxColumn13.Name="dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName="ShippedDate";
            this.dataGridViewTextBoxColumn14.HeaderText="ShippedDate";
            this.dataGridViewTextBoxColumn14.Name="dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName="ShipAddress";
            this.dataGridViewTextBoxColumn15.HeaderText="ShipAddress";
            this.dataGridViewTextBoxColumn15.Name="dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName="ShipCity";
            this.dataGridViewTextBoxColumn16.HeaderText="ShipCity";
            this.dataGridViewTextBoxColumn16.Name="dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName="Freight";
            this.dataGridViewTextBoxColumn17.HeaderText="Freight";
            this.dataGridViewTextBoxColumn17.Name="dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName="CustomerID";
            this.dataGridViewTextBoxColumn18.HeaderText="CustomerID";
            this.dataGridViewTextBoxColumn18.Name="dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName="OrderID";
            this.dataGridViewTextBoxColumn19.HeaderText="OrderID";
            this.dataGridViewTextBoxColumn19.Name="dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName="OrderDate";
            this.dataGridViewTextBoxColumn20.HeaderText="OrderDate";
            this.dataGridViewTextBoxColumn20.Name="dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName="RequiredDate";
            this.dataGridViewTextBoxColumn21.HeaderText="RequiredDate";
            this.dataGridViewTextBoxColumn21.Name="dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName="ShipRegion";
            this.dataGridViewTextBoxColumn22.HeaderText="ShipRegion";
            this.dataGridViewTextBoxColumn22.Name="dataGridViewTextBoxColumn22";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName="EmployeeID";
            this.dataGridViewTextBoxColumn23.HeaderText="EmployeeID";
            this.dataGridViewTextBoxColumn23.Name="dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName="ShipPostalCode";
            this.dataGridViewTextBoxColumn24.HeaderText="ShipPostalCode";
            this.dataGridViewTextBoxColumn24.Name="dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName="ShipVia";
            this.dataGridViewTextBoxColumn25.HeaderText="ShipVia";
            this.dataGridViewTextBoxColumn25.Name="dataGridViewTextBoxColumn25";
            // 
            // northwindDataSet1
            // 
            this.northwindDataSet1.DataSetName="NorthwindDataSet";
            // 
            // customersTableAdapter1
            // 
            this.customersTableAdapter1.ClearBeforeFill=true;
            // 
            // ordersTableAdapter1
            // 
            this.ordersTableAdapter1.ClearBeforeFill=true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(646, 439);
            this.Controls.Add(this.ordersDataGridView);
            this.Controls.Add(this.customerDataGridView);
            this.Controls.Add(this.customerBindingNavigator);
            this.Name="Form1";
            this.Text="Form1";
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingNavigator)).EndInit();
            this.customerBindingNavigator.ResumeLayout(false);
            this.customerBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.BindingNavigator customerBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton customerBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private System.Windows.Forms.DataGridView ordersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private NorthwindDataSet northwindDataSet1;
        private ObjectBindingWalkthrough.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter1;
        private ObjectBindingWalkthrough.NorthwindDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter1;
    }
}