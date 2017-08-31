namespace CS
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources=new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.northwindDataSet=new CS.NorthwindDataSet();
            this.regionBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.regionTableAdapter=new CS.NorthwindDataSetTableAdapters.RegionTableAdapter();
            this.regionBindingNavigator=new System.Windows.Forms.BindingNavigator(this.components);
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
            this.regionBindingNavigatorSaveItem=new System.Windows.Forms.ToolStripButton();
            this.regionDataGridView=new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1=new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2=new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingNavigator)).BeginInit();
            this.regionBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName="NorthwindDataSet";
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember="Region";
            this.regionBindingSource.DataSource=this.northwindDataSet;
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill=true;
            // 
            // regionBindingNavigator
            // 
            this.regionBindingNavigator.AddNewItem=this.bindingNavigatorAddNewItem;
            this.regionBindingNavigator.BindingSource=this.regionBindingSource;
            this.regionBindingNavigator.CountItem=this.bindingNavigatorCountItem;
            this.regionBindingNavigator.DeleteItem=this.bindingNavigatorDeleteItem;
            this.regionBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.regionBindingNavigatorSaveItem});
            this.regionBindingNavigator.Location=new System.Drawing.Point(0, 0);
            this.regionBindingNavigator.MoveFirstItem=this.bindingNavigatorMoveFirstItem;
            this.regionBindingNavigator.MoveLastItem=this.bindingNavigatorMoveLastItem;
            this.regionBindingNavigator.MoveNextItem=this.bindingNavigatorMoveNextItem;
            this.regionBindingNavigator.MovePreviousItem=this.bindingNavigatorMovePreviousItem;
            this.regionBindingNavigator.Name="regionBindingNavigator";
            this.regionBindingNavigator.PositionItem=this.bindingNavigatorPositionItem;
            this.regionBindingNavigator.Size=new System.Drawing.Size(350, 25);
            this.regionBindingNavigator.TabIndex=0;
            this.regionBindingNavigator.Text="bindingNavigator1";
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
            // regionBindingNavigatorSaveItem
            // 
            this.regionBindingNavigatorSaveItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.regionBindingNavigatorSaveItem.Image=((System.Drawing.Image)(resources.GetObject("regionBindingNavigatorSaveItem.Image")));
            this.regionBindingNavigatorSaveItem.Name="regionBindingNavigatorSaveItem";
            this.regionBindingNavigatorSaveItem.Size=new System.Drawing.Size(23, 23);
            this.regionBindingNavigatorSaveItem.Text="Save Data";
            this.regionBindingNavigatorSaveItem.Click+=new System.EventHandler(this.regionBindingNavigatorSaveItem_Click);
            // 
            // regionDataGridView
            // 
            this.regionDataGridView.AutoGenerateColumns=false;
            this.regionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.regionDataGridView.DataSource=this.regionBindingSource;
            this.regionDataGridView.ImeMode=System.Windows.Forms.ImeMode.Disable;
            this.regionDataGridView.Location=new System.Drawing.Point(12, 28);
            this.regionDataGridView.Name="regionDataGridView";
            this.regionDataGridView.Size=new System.Drawing.Size(300, 220);
            this.regionDataGridView.TabIndex=1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName="RegionID";
            this.dataGridViewTextBoxColumn1.HeaderText="RegionID";
            this.dataGridViewTextBoxColumn1.Name="dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName="RegionDescription";
            this.dataGridViewTextBoxColumn2.HeaderText="RegionDescription";
            this.dataGridViewTextBoxColumn2.Name="dataGridViewTextBoxColumn2";
            // 
            // Form5
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(350, 267);
            this.Controls.Add(this.regionDataGridView);
            this.Controls.Add(this.regionBindingNavigator);
            this.Name="Form5";
            this.Text="Form5";
            this.Load+=new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingNavigator)).EndInit();
            this.regionBindingNavigator.ResumeLayout(false);
            this.regionBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NorthwindDataSet northwindDataSet;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private CS.NorthwindDataSetTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.BindingNavigator regionBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton regionBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView regionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}