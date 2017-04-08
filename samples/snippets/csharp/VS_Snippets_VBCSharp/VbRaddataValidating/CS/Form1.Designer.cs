namespace CS
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
            System.Windows.Forms.Label orderIDLabel;
            System.Windows.Forms.Label productIDLabel;
            System.Windows.Forms.Label unitPriceLabel;
            System.Windows.Forms.Label quantityLabel;
            System.Windows.Forms.Label discountLabel;
            this.northwindDataSet1=new CS.NorthwindDataSet();
            this.customersTableAdapter1=new CS.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.order_DetailsTableAdapter1=new CS.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter();
            this.ordersTableAdapter1=new CS.NorthwindDataSetTableAdapters.OrdersTableAdapter();
            this.order_DetailsBindingSource=new System.Windows.Forms.BindingSource(this.components);
            this.order_DetailsBindingNavigator=new System.Windows.Forms.BindingNavigator(this.components);
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
            this.order_DetailsBindingNavigatorSaveItem=new System.Windows.Forms.ToolStripButton();
            this.orderIDTextBox=new System.Windows.Forms.TextBox();
            this.productIDTextBox=new System.Windows.Forms.TextBox();
            this.unitPriceTextBox=new System.Windows.Forms.TextBox();
            this.quantityTextBox=new System.Windows.Forms.TextBox();
            this.discountTextBox=new System.Windows.Forms.TextBox();
            this.errorProvider1=new System.Windows.Forms.ErrorProvider(this.components);
            orderIDLabel=new System.Windows.Forms.Label();
            productIDLabel=new System.Windows.Forms.Label();
            unitPriceLabel=new System.Windows.Forms.Label();
            quantityLabel=new System.Windows.Forms.Label();
            discountLabel=new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_DetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_DetailsBindingNavigator)).BeginInit();
            this.order_DetailsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // northwindDataSet1
            // 
            this.northwindDataSet1.DataSetName="NorthwindDataSet";
            // 
            // customersTableAdapter1
            // 
            this.customersTableAdapter1.ClearBeforeFill=true;
            // 
            // order_DetailsTableAdapter1
            // 
            this.order_DetailsTableAdapter1.ClearBeforeFill=true;
            // 
            // ordersTableAdapter1
            // 
            this.ordersTableAdapter1.ClearBeforeFill=true;
            // 
            // order_DetailsBindingSource
            // 
            this.order_DetailsBindingSource.DataMember="Order Details";
            this.order_DetailsBindingSource.DataSource=this.northwindDataSet1;
            // 
            // order_DetailsBindingNavigator
            // 
            this.order_DetailsBindingNavigator.AddNewItem=this.bindingNavigatorAddNewItem;
            this.order_DetailsBindingNavigator.BindingSource=this.order_DetailsBindingSource;
            this.order_DetailsBindingNavigator.CountItem=this.bindingNavigatorCountItem;
            this.order_DetailsBindingNavigator.DeleteItem=this.bindingNavigatorDeleteItem;
            this.order_DetailsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.order_DetailsBindingNavigatorSaveItem});
            this.order_DetailsBindingNavigator.Location=new System.Drawing.Point(0, 0);
            this.order_DetailsBindingNavigator.MoveFirstItem=this.bindingNavigatorMoveFirstItem;
            this.order_DetailsBindingNavigator.MoveLastItem=this.bindingNavigatorMoveLastItem;
            this.order_DetailsBindingNavigator.MoveNextItem=this.bindingNavigatorMoveNextItem;
            this.order_DetailsBindingNavigator.MovePreviousItem=this.bindingNavigatorMovePreviousItem;
            this.order_DetailsBindingNavigator.Name="order_DetailsBindingNavigator";
            this.order_DetailsBindingNavigator.PositionItem=this.bindingNavigatorPositionItem;
            this.order_DetailsBindingNavigator.Size=new System.Drawing.Size(292, 25);
            this.order_DetailsBindingNavigator.TabIndex=0;
            this.order_DetailsBindingNavigator.Text="bindingNavigator1";
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
            // order_DetailsBindingNavigatorSaveItem
            // 
            this.order_DetailsBindingNavigatorSaveItem.DisplayStyle=System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.order_DetailsBindingNavigatorSaveItem.Image=((System.Drawing.Image)(resources.GetObject("order_DetailsBindingNavigatorSaveItem.Image")));
            this.order_DetailsBindingNavigatorSaveItem.Name="order_DetailsBindingNavigatorSaveItem";
            this.order_DetailsBindingNavigatorSaveItem.Size=new System.Drawing.Size(23, 23);
            this.order_DetailsBindingNavigatorSaveItem.Text="Save Data";
            this.order_DetailsBindingNavigatorSaveItem.Click+=new System.EventHandler(this.order_DetailsBindingNavigatorSaveItem_Click);
            // 
            // orderIDLabel
            // 
            orderIDLabel.AutoSize=true;
            orderIDLabel.Location=new System.Drawing.Point(26, 42);
            orderIDLabel.Name="orderIDLabel";
            orderIDLabel.Size=new System.Drawing.Size(50, 13);
            orderIDLabel.TabIndex=1;
            orderIDLabel.Text="Order ID:";
            // 
            // orderIDTextBox
            // 
            this.orderIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_DetailsBindingSource, "OrderID", true));
            this.orderIDTextBox.Location=new System.Drawing.Point(93, 39);
            this.orderIDTextBox.Name="orderIDTextBox";
            this.orderIDTextBox.Size=new System.Drawing.Size(100, 20);
            this.orderIDTextBox.TabIndex=2;
            // 
            // productIDLabel
            // 
            productIDLabel.AutoSize=true;
            productIDLabel.Location=new System.Drawing.Point(26, 68);
            productIDLabel.Name="productIDLabel";
            productIDLabel.Size=new System.Drawing.Size(61, 13);
            productIDLabel.TabIndex=3;
            productIDLabel.Text="Product ID:";
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_DetailsBindingSource, "ProductID", true));
            this.productIDTextBox.Location=new System.Drawing.Point(93, 65);
            this.productIDTextBox.Name="productIDTextBox";
            this.productIDTextBox.Size=new System.Drawing.Size(100, 20);
            this.productIDTextBox.TabIndex=4;
            // 
            // unitPriceLabel
            // 
            unitPriceLabel.AutoSize=true;
            unitPriceLabel.Location=new System.Drawing.Point(26, 94);
            unitPriceLabel.Name="unitPriceLabel";
            unitPriceLabel.Size=new System.Drawing.Size(56, 13);
            unitPriceLabel.TabIndex=5;
            unitPriceLabel.Text="Unit Price:";
            // 
            // unitPriceTextBox
            // 
            this.unitPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_DetailsBindingSource, "UnitPrice", true));
            this.unitPriceTextBox.Location=new System.Drawing.Point(93, 91);
            this.unitPriceTextBox.Name="unitPriceTextBox";
            this.unitPriceTextBox.Size=new System.Drawing.Size(100, 20);
            this.unitPriceTextBox.TabIndex=6;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize=true;
            quantityLabel.Location=new System.Drawing.Point(26, 120);
            quantityLabel.Name="quantityLabel";
            quantityLabel.Size=new System.Drawing.Size(49, 13);
            quantityLabel.TabIndex=7;
            quantityLabel.Text="Quantity:";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_DetailsBindingSource, "Quantity", true));
            this.quantityTextBox.Location=new System.Drawing.Point(93, 117);
            this.quantityTextBox.Name="quantityTextBox";
            this.quantityTextBox.Size=new System.Drawing.Size(100, 20);
            this.quantityTextBox.TabIndex=8;
            // 
            // discountLabel
            // 
            discountLabel.AutoSize=true;
            discountLabel.Location=new System.Drawing.Point(26, 146);
            discountLabel.Name="discountLabel";
            discountLabel.Size=new System.Drawing.Size(52, 13);
            discountLabel.TabIndex=9;
            discountLabel.Text="Discount:";
            // 
            // discountTextBox
            // 
            this.discountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.order_DetailsBindingSource, "Discount", true));
            this.discountTextBox.Location=new System.Drawing.Point(93, 143);
            this.discountTextBox.Name="discountTextBox";
            this.discountTextBox.Size=new System.Drawing.Size(100, 20);
            this.discountTextBox.TabIndex=10;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl=this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(292, 266);
            this.Controls.Add(orderIDLabel);
            this.Controls.Add(this.orderIDTextBox);
            this.Controls.Add(productIDLabel);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(unitPriceLabel);
            this.Controls.Add(this.unitPriceTextBox);
            this.Controls.Add(quantityLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(discountLabel);
            this.Controls.Add(this.discountTextBox);
            this.Controls.Add(this.order_DetailsBindingNavigator);
            this.Name="Form1";
            this.Text="Form1";
            this.Load+=new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_DetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_DetailsBindingNavigator)).EndInit();
            this.order_DetailsBindingNavigator.ResumeLayout(false);
            this.order_DetailsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NorthwindDataSet northwindDataSet1;
        private CS.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter1;
        private CS.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter order_DetailsTableAdapter1;
        private CS.NorthwindDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter1;
        private System.Windows.Forms.BindingSource order_DetailsBindingSource;
        private System.Windows.Forms.BindingNavigator order_DetailsBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton order_DetailsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox orderIDTextBox;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox unitPriceTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

