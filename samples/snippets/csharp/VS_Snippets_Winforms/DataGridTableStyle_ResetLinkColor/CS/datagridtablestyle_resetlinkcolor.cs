// System.Windows.Forms.DataGridTableStyle.ResetLinkColor

/* The following program demonstrates the 'ResetLinkColor'
   of 'System.Windows.Forms.DataGridTableStyle' class.
   It creates a windows form, a 'DataSet' containing two 'DataTable' 
   objects, and a 'DataRelation' that relates the two tables. To 
   display the data, a 'DataGrid' control is then bound to the 
   'DataSet' through the 'SetDataBinding' method.
   DataGridTableStyle is attached to one of 'DataTable'.
   Buttons are provided on form to demonstrate setting link color
   and 'ResetLinkColor' method.
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataGridSample
{
   /// <summary>
   /// Summary description for DatGridClass.
   /// </summary>
   public class DatGridClass : System.Windows.Forms.Form
   {
      private DataSet myDataSet;
      private System.Windows.Forms.DataGrid myDataGrid;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button btnResetLinkColor;
      private System.Windows.Forms.Button btnSetLinkColor;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public DatGridClass()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         // Setup GridControl data.
         SetUp();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.btnSetLinkColor = new System.Windows.Forms.Button();
         this.myDataGrid = new System.Windows.Forms.DataGrid();
         this.btnResetLinkColor = new System.Windows.Forms.Button();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).BeginInit();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnSetLinkColor
         // 
         this.btnSetLinkColor.Location = new System.Drawing.Point(16, 16);
         this.btnSetLinkColor.Name = "btnSetLinkColor";
         this.btnSetLinkColor.Size = new System.Drawing.Size(104, 32);
         this.btnSetLinkColor.TabIndex = 4;
         this.btnSetLinkColor.Text = "Set Link Color";
         this.btnSetLinkColor.Click += new System.EventHandler(this.btnSetLinkColor_Click);
         // 
         // myDataGrid
         // 
         this.myDataGrid.DataMember = "";
         this.myDataGrid.ForeColor = System.Drawing.Color.Blue;
         this.myDataGrid.Location = new System.Drawing.Point(12, 32);
         this.myDataGrid.Name = "myDataGrid";
         this.myDataGrid.ReadOnly = true;
         this.myDataGrid.Size = new System.Drawing.Size(272, 192);
         this.myDataGrid.TabIndex = 6;
         // 
         // btnResetLinkColor
         // 
         this.btnResetLinkColor.Location = new System.Drawing.Point(16, 48);
         this.btnResetLinkColor.Name = "btnResetLinkColor";
         this.btnResetLinkColor.Size = new System.Drawing.Size(104, 32);
         this.btnResetLinkColor.TabIndex = 1;
         this.btnResetLinkColor.Text = "Reset Link Color";
         this.btnResetLinkColor.Click += new System.EventHandler(this.btnResetLinkColor_Click);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.btnSetLinkColor,
                                                                                this.btnResetLinkColor});
         this.groupBox3.Location = new System.Drawing.Point(80, 232);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(136, 88);
         this.groupBox3.TabIndex = 7;
         this.groupBox3.TabStop = false;
         // 
         // DatGridClass
         // 
         this.ClientSize = new System.Drawing.Size(312, 341);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.groupBox3,
                                                                      this.myDataGrid});
         this.Name = "DatGridClass";
         this.Text = "Sample Program";
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).EndInit();
         this.groupBox3.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion
      DataGridTableStyle myDataGridTableStyle = new DataGridTableStyle();
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      
      [STAThread]
      static void Main() 
      {
         Application.Run(new DatGridClass());
      }
      private void SetUp()
      {
         // Create a 'DataSet' with two tables and one relation.
         MakeDataSet();
         // Bind the 'DataGrid' to the 'DataSet'. 
         myDataGrid.SetDataBinding(myDataSet, "Customers");
      }
      // Create a 'DataSet' with two tables and populate it.
      private void MakeDataSet()
      {
         // Create a 'DataSet'.
         myDataSet = new DataSet("myDataSet");
         // Create two 'DataTables'.
         DataTable tCust = new DataTable("Customers");
         DataTable tOrders = new DataTable("Orders");

         // Create two columns, and add them to the first table.
         DataColumn cCustID = new DataColumn("CustID", typeof(int));
         DataColumn cCustName = new DataColumn("CustName");
         DataColumn cCurrent = new DataColumn("Current", typeof(bool));
         tCust.Columns.Add(cCustID);
         tCust.Columns.Add(cCustName);
         tCust.Columns.Add(cCurrent);

         // Map 'myDataGridTableStyle' to 'Customers' table.
         myDataGridTableStyle.MappingName = "Customers";
         // Add the DataGridTableStyle objects to the collection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle);

         // Create three columns and add them to the second table.
         DataColumn cID = 
            new DataColumn("CustID", typeof(int));
         DataColumn cOrderDate = 
            new DataColumn("OrderDate",typeof(DateTime));
         DataColumn cOrderAmount = 
            new DataColumn("OrderAmount", typeof(string));
         tOrders.Columns.Add(cID);
         tOrders.Columns.Add(cOrderAmount);
         tOrders.Columns.Add(cOrderDate);

         // Add the tables to the 'DataSet'.
         myDataSet.Tables.Add(tCust);
         myDataSet.Tables.Add(tOrders);

         // Create a 'DataRelation' and add it to the 'DataSet'.
         DataRelation dr = new DataRelation
            ("custToOrders", cCustID , cID);
         myDataSet.Relations.Add(dr);
   
         // Populate the tables. 
         // Create two 'DataRow' variables for customer and order.
         DataRow newRow1;
         DataRow newRow2;

         // Create three customers in the 'Customers Table'.
         for(int i = 1; i < 4; i++)
         {
            newRow1 = tCust.NewRow();
            newRow1["custID"] = i;
            // Add the row to the 'Customers Table'.
            tCust.Rows.Add(newRow1);
         }
         // Give each customer a distinct name.
         tCust.Rows[0]["custName"] = "Customer1";
         tCust.Rows[1]["custName"] = "Customer2";
         tCust.Rows[2]["custName"] = "Customer3";

         // Give the current column a value.
         tCust.Rows[0]["Current"] = true;
         tCust.Rows[1]["Current"] = true;
         tCust.Rows[2]["Current"] = false;

         // For each customer, create five rows in the orders table.
         double myNumber = 0;
         string myString;
         
         for(int i = 1; i < 4; i++)
         {
            for(int j = 1; j < 6; j++)
            {
               newRow2 = tOrders.NewRow();
               newRow2["CustID"]= i;
               newRow2["orderDate"]= new DateTime(2001, i, j * 2);
               myNumber = i * 10 + j  * .1;
               myString = "$ ";
               myString += myNumber.ToString ();
               newRow2["OrderAmount"] = myString;
               // Add the row to the orders table.
               tOrders.Rows.Add(newRow2);
            }
         }
      }
      private void btnResetLinkColor_Click(object sender, System.EventArgs e)
      {
// <Snippet1>
         // String variable used to show message.   
         string myString = "Link color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGridTableStyle.LinkColor;
         myString += myCurrentColor.ToString();
         // Reset link color to default.
         myDataGridTableStyle.ResetLinkColor();
         myString += "  to ";
         myString += myDataGridTableStyle.LinkColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Link line color information");
// </Snippet1>
      }
      private void btnSetLinkColor_Click(object sender, System.EventArgs e)
      {
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color select to the current color.
         myColorDialog.Color = myDataGridTableStyle.LinkColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set link color to selected color.
         myDataGridTableStyle.LinkColor = myColorDialog.Color;
      }
   }
}