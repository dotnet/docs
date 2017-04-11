namespace CS
{
    partial class Form1
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
            this.components=new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources=new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.customersDataGridView=new System.Windows.Forms.DataGridView();
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
            this.textBox1=new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingNavigator)).BeginInit();
            this.customersBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).BeginInit();
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
            // customersDataGridView
            // 
            this.customersDataGridView.AutoGenerateColumns=false;
            this.customersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.customersDataGridView.DataSource=this.customersBindingSource;
            this.customersDataGridView.ImeMode=System.Windows.Forms.ImeMode.Disable;
            this.customersDataGridView.Location=new System.Drawing.Point(12, 43);
            this.customersDataGridView.Name="customersDataGridView";
            this.customersDataGridView.Size=new System.Drawing.Size(300, 220);
            this.customersDataGridView.TabIndex=1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName="CustomerID";
            this.dataGridViewTextBoxColumn1.HeaderText="CustomerID";
            this.dataGridViewTextBoxColumn1.Name="dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName="CompanyName";
            this.dataGridViewTextBoxColumn2.HeaderText="CompanyName";
            this.dataGridViewTextBoxColumn2.Name="dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName="ContactName";
            this.dataGridViewTextBoxColumn3.HeaderText="ContactName";
            this.dataGridViewTextBoxColumn3.Name="dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName="ContactTitle";
            this.dataGridViewTextBoxColumn4.HeaderText="ContactTitle";
            this.dataGridViewTextBoxColumn4.Name="dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName="Address";
            this.dataGridViewTextBoxColumn5.HeaderText="Address";
            this.dataGridViewTextBoxColumn5.Name="dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName="City";
            this.dataGridViewTextBoxColumn6.HeaderText="City";
            this.dataGridViewTextBoxColumn6.Name="dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName="Region";
            this.dataGridViewTextBoxColumn7.HeaderText="Region";
            this.dataGridViewTextBoxColumn7.Name="dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName="PostalCode";
            this.dataGridViewTextBoxColumn8.HeaderText="PostalCode";
            this.dataGridViewTextBoxColumn8.Name="dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName="Country";
            this.dataGridViewTextBoxColumn9.HeaderText="Country";
            this.dataGridViewTextBoxColumn9.Name="dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName="Phone";
            this.dataGridViewTextBoxColumn10.HeaderText="Phone";
            this.dataGridViewTextBoxColumn10.Name="dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName="Fax";
            this.dataGridViewTextBoxColumn11.HeaderText="Fax";
            this.dataGridViewTextBoxColumn11.Name="dataGridViewTextBoxColumn11";
            // 
            // textBox1
            // 
            this.textBox1.Location=new System.Drawing.Point(12, 284);
            this.textBox1.Name="textBox1";
            this.textBox1.Size=new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex=2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(357, 316);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.customersDataGridView);
            this.Controls.Add(this.customersBindingNavigator);
            this.Name="Form1";
            this.Text="Form1";
            this.Load+=new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingNavigator)).EndInit();
            this.customersBindingNavigator.ResumeLayout(false);
            this.customersBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customersDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView customersDataGridView;
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
        private System.Windows.Forms.TextBox textBox1;

    }
}

