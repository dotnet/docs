namespace CS
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources=new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.northwindDataSet=new CS.NorthwindDataSet();
            this.ordersBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.ordersTableAdapter=new CS.NorthwindDataSetTableAdapters.OrdersTableAdapter();
            this.ordersBindingNavigator=new System.Windows.Forms.BindingNavigator(this.components);
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
            this.ordersBindingNavigatorSaveItem=new System.Windows.Forms.ToolStripButton();
            this.ordersDataGridView=new System.Windows.Forms.DataGridView();
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
            this.dataGridViewTextBoxColumn12=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14=new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingNavigator)).BeginInit();
            this.ordersBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName="NorthwindDataSet";
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember="Orders";
            this.ordersBindingSource.DataSource=this.northwindDataSet;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill=true;
            // 
            // ordersBindingNavigator
            // 
            this.ordersBindingNavigator.AddNewItem=this.bindingNavigatorAddNewItem;
            this.ordersBindingNavigator.BindingSource=this.ordersBindingSource;
            this.ordersBindingNavigator.CountItem=this.bindingNavigatorCountItem;
            this.ordersBindingNavigator.DeleteItem=this.bindingNavigatorDeleteItem;
            this.ordersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.ordersBindingNavigatorSaveItem});
            this.ordersBindingNavigator.Location=new System.Drawing.Point(0, 0);
            this.ordersBindingNavigator.MoveFirstItem=this.bindingNavigatorMoveFirstItem;
            this.ordersBindingNavigator.MoveLastItem=this.bindingNavigatorMoveLastItem;
            this.ordersBindingNavigator.MoveNextItem=this.bindingNavigatorMoveNextItem;
            this.ordersBindingNavigator.MovePreviousItem=this.bindingNavigatorMovePreviousItem;
            this.ordersBindingNavigator.Name="ordersBindingNavigator";
            this.ordersBindingNavigator.PositionItem=this.bindingNavigatorPositionItem;
            this.ordersBindingNavigator.Size=new System.Drawing.Size(343, 25);
            this.ordersBindingNavigator.TabIndex=0;
            this.ordersBindingNavigator.Text="bindingNavigator1";
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
            // ordersBindingNavigatorSaveItem
            // 
            this.ordersBindingNavigatorSaveItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ordersBindingNavigatorSaveItem.Image=((System.Drawing.Image)(resources.GetObject("ordersBindingNavigatorSaveItem.Image")));
            this.ordersBindingNavigatorSaveItem.Name="ordersBindingNavigatorSaveItem";
            this.ordersBindingNavigatorSaveItem.Size=new System.Drawing.Size(23, 23);
            this.ordersBindingNavigatorSaveItem.Text="Save Data";
            this.ordersBindingNavigatorSaveItem.Click+=new System.EventHandler(this.ordersBindingNavigatorSaveItem_Click);
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AutoGenerateColumns=false;
            this.ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.ordersDataGridView.DataSource=this.ordersBindingSource;
            this.ordersDataGridView.ImeMode=System.Windows.Forms.ImeMode.Disable;
            this.ordersDataGridView.Location=new System.Drawing.Point(12, 34);
            this.ordersDataGridView.Name="ordersDataGridView";
            this.ordersDataGridView.Size=new System.Drawing.Size(300, 220);
            this.ordersDataGridView.TabIndex=1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName="OrderID";
            this.dataGridViewTextBoxColumn1.HeaderText="OrderID";
            this.dataGridViewTextBoxColumn1.Name="dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly=true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName="CustomerID";
            this.dataGridViewTextBoxColumn2.HeaderText="CustomerID";
            this.dataGridViewTextBoxColumn2.Name="dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName="EmployeeID";
            this.dataGridViewTextBoxColumn3.HeaderText="EmployeeID";
            this.dataGridViewTextBoxColumn3.Name="dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName="OrderDate";
            this.dataGridViewTextBoxColumn4.HeaderText="OrderDate";
            this.dataGridViewTextBoxColumn4.Name="dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName="RequiredDate";
            this.dataGridViewTextBoxColumn5.HeaderText="RequiredDate";
            this.dataGridViewTextBoxColumn5.Name="dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName="ShippedDate";
            this.dataGridViewTextBoxColumn6.HeaderText="ShippedDate";
            this.dataGridViewTextBoxColumn6.Name="dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName="ShipVia";
            this.dataGridViewTextBoxColumn7.HeaderText="ShipVia";
            this.dataGridViewTextBoxColumn7.Name="dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName="Freight";
            this.dataGridViewTextBoxColumn8.HeaderText="Freight";
            this.dataGridViewTextBoxColumn8.Name="dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName="ShipName";
            this.dataGridViewTextBoxColumn9.HeaderText="ShipName";
            this.dataGridViewTextBoxColumn9.Name="dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName="ShipAddress";
            this.dataGridViewTextBoxColumn10.HeaderText="ShipAddress";
            this.dataGridViewTextBoxColumn10.Name="dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName="ShipCity";
            this.dataGridViewTextBoxColumn11.HeaderText="ShipCity";
            this.dataGridViewTextBoxColumn11.Name="dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName="ShipRegion";
            this.dataGridViewTextBoxColumn12.HeaderText="ShipRegion";
            this.dataGridViewTextBoxColumn12.Name="dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName="ShipPostalCode";
            this.dataGridViewTextBoxColumn13.HeaderText="ShipPostalCode";
            this.dataGridViewTextBoxColumn13.Name="dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName="ShipCountry";
            this.dataGridViewTextBoxColumn14.HeaderText="ShipCountry";
            this.dataGridViewTextBoxColumn14.Name="dataGridViewTextBoxColumn14";
            // 
            // Form2
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(343, 266);
            this.Controls.Add(this.ordersDataGridView);
            this.Controls.Add(this.ordersBindingNavigator);
            this.Name="Form2";
            this.Text="Form2";
            this.Load+=new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingNavigator)).EndInit();
            this.ordersBindingNavigator.ResumeLayout(false);
            this.ordersBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NorthwindDataSet northwindDataSet;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private CS.NorthwindDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.BindingNavigator ordersBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton ordersBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView ordersDataGridView;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}