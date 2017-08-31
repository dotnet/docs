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
            this.northwindDataSet1=new CS.NorthwindDataSet();
            this.customersTableAdapter1=new CS.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.order_DetailsTableAdapter1=new CS.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter();
            this.ordersTableAdapter1=new CS.NorthwindDataSetTableAdapters.OrdersTableAdapter();
            this.regionTableAdapter1=new CS.NorthwindDataSetTableAdapters.RegionTableAdapter();
            this.dataSet1=new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
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
            // regionTableAdapter1
            // 
            this.regionTableAdapter1.ClearBeforeFill=true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName="NewDataSet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(292, 266);
            this.Name="Form1";
            this.Text="Form1";
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NorthwindDataSet northwindDataSet1;
        private CS.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter1;
        private CS.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter order_DetailsTableAdapter1;
        private CS.NorthwindDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter1;
        private CS.NorthwindDataSetTableAdapters.RegionTableAdapter regionTableAdapter1;
        private System.Data.DataSet dataSet1;
    }
}

