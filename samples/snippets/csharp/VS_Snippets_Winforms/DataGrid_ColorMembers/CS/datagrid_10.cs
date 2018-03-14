// System.Windows.Forms.DataGrid.SelectionBackColor
// System.Windows.Forms.DataGrid.SelectionForeColor
// System.Windows.Forms.DataGrid.ResetSelectionBackColor
// System.Windows.Forms.DataGrid.ResetSelectionForeColor
// System.Windows.Forms.DataGrid.ResetBackColor
// System.Windows.Forms.DataGrid.ResetForeColor
// System.Windows.Forms.DataGrid.ForeColor
// System.Windows.Forms.DataGrid.ResetAlternatingBackColor
// System.Windows.Forms.DataGrid.ResetLinkColor
// System.Windows.Forms.DataGrid.ResetGridLineColor

/* The following program demonstrates various members of
   'System.Windows.Forms.DataGrid class' relating to Color. 
   It creates a windows form, a 'DataSet' containing two 'DataTable' 
   objects, and a 'DataRelation' that relates the two tables. To 
   display the data, a 'DataGrid' control is then bound to the 
   'DataSet' through the 'SetDataBinding' method. 
   Ten buttons are provided on form to demonstrate each property.
   Effet of each property can be seen on 'DataGrid'.
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
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private DataSet myDataSet;
      private System.Windows.Forms.DataGrid myDataGrid;
      private System.Windows.Forms.Button btnResetSelectionBkColor;
      private System.Windows.Forms.Button btnSeSelectiontBkColor;
      private System.Windows.Forms.Button btnSetSelectionForeColor;
      private System.Windows.Forms.Button btnResetSelectionForeColor;
      private System.Windows.Forms.Button btnSetForeColor;
      private System.Windows.Forms.Button btnResetForeColor;
      private System.Windows.Forms.Button btnSetBkColor;
      private System.Windows.Forms.Button btnResetBkColor;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button btnResetLinkColor;
      private System.Windows.Forms.Button btnResetAlternatingBackColor;
      private System.Windows.Forms.Button btnSetLinkColor;
      private System.Windows.Forms.Button btnSetAlternatingBkColor;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Button btnResetGridLineColor;
      private System.Windows.Forms.Button btnSetGridLineColor;
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
         this.btnResetBkColor = new Button();
         this.btnSetBkColor = new Button();
         this.btnResetForeColor = new Button();
         this.groupBox1 = new GroupBox();
         this.btnSeSelectiontBkColor = new Button();
         this.btnResetSelectionBkColor = new Button();
         this.btnSetSelectionForeColor = new Button();
         this.btnResetSelectionForeColor = new Button();
         this.groupBox2 = new GroupBox();
         this.btnSetForeColor = new Button();
         this.groupBox3 = new GroupBox();
         this.btnSetAlternatingBkColor = new Button();
         this.btnSetLinkColor = new Button();
         this.btnResetAlternatingBackColor = new Button();
         this.btnResetLinkColor = new Button();
         this.groupBox4 = new GroupBox();
         this.btnSetGridLineColor = new Button();
         this.btnResetGridLineColor = new Button();
         this.myDataGrid = new DataGrid();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox4.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // btnResetBkColor
         // 
         this.btnResetBkColor.Location = new System.Drawing.Point(120, 56);
         this.btnResetBkColor.Name = "btnResetBkColor";
         this.btnResetBkColor.Size = new System.Drawing.Size(104, 32);
         this.btnResetBkColor.TabIndex = 3;
         this.btnResetBkColor.Text = "Reset background color";
         this.btnResetBkColor.Click += new System.EventHandler(this.btnResetBkColor_Click);
         // 
         // btnSetBkColor
         // 
         this.btnSetBkColor.Location = new System.Drawing.Point(120, 24);
         this.btnSetBkColor.Name = "btnSetBkColor";
         this.btnSetBkColor.Size = new System.Drawing.Size(104, 32);
         this.btnSetBkColor.TabIndex = 2;
         this.btnSetBkColor.Text = "Set background color";
         this.btnSetBkColor.Click += new System.EventHandler(this.btnSetBkColor_Click);
         // 
         // btnResetForeColor
         // 
         this.btnResetForeColor.Location = new System.Drawing.Point(16, 56);
         this.btnResetForeColor.Name = "btnResetForeColor";
         this.btnResetForeColor.Size = new System.Drawing.Size(104, 32);
         this.btnResetForeColor.TabIndex = 1;
         this.btnResetForeColor.Text = "Reset foreground color";
         this.btnResetForeColor.Click += new System.EventHandler(this.btnResetForeColor_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.btnSeSelectiontBkColor,
                                                                                this.btnResetSelectionBkColor,
                                                                                this.btnSetSelectionForeColor,
                                                                                this.btnResetSelectionForeColor});
         this.groupBox1.Location = new System.Drawing.Point(296, 24);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(248, 96);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         // 
         // btnSeSelectiontBkColor
         // 
         this.btnSeSelectiontBkColor.Location = new System.Drawing.Point(125, 24);
         this.btnSeSelectiontBkColor.Name = "btnSeSelectiontBkColor";
         this.btnSeSelectiontBkColor.Size = new System.Drawing.Size(112, 32);
         this.btnSeSelectiontBkColor.TabIndex = 0;
         this.btnSeSelectiontBkColor.Text = "Set selection  background color";
         this.btnSeSelectiontBkColor.Click += new System.EventHandler(this.btnSetSelectionBkColor_Click);
         // 
         // btnResetSelectionBkColor
         // 
         this.btnResetSelectionBkColor.Location = new System.Drawing.Point(125, 56);
         this.btnResetSelectionBkColor.Name = "btnResetSelectionBkColor";
         this.btnResetSelectionBkColor.Size = new System.Drawing.Size(112, 32);
         this.btnResetSelectionBkColor.TabIndex = 1;
         this.btnResetSelectionBkColor.Text = "Reset selection background color";
         this.btnResetSelectionBkColor.Click += new System.EventHandler(this.btnResetSelectionBkColor_Click);
         // 
         // btnSetSelectionForeColor
         // 
         this.btnSetSelectionForeColor.Location = new System.Drawing.Point(13, 24);
         this.btnSetSelectionForeColor.Name = "btnSetSelectionForeColor";
         this.btnSetSelectionForeColor.Size = new System.Drawing.Size(112, 32);
         this.btnSetSelectionForeColor.TabIndex = 2;
         this.btnSetSelectionForeColor.Text = "Set selection  foreground color";
         this.btnSetSelectionForeColor.Click += new System.EventHandler(this.btnSetSelectionForeColor_Click);
         // 
         // btnResetSelectionForeColor
         // 
         this.btnResetSelectionForeColor.Location = new System.Drawing.Point(13, 56);
         this.btnResetSelectionForeColor.Name = "btnResetSelectionForeColor";
         this.btnResetSelectionForeColor.Size = new System.Drawing.Size(112, 32);
         this.btnResetSelectionForeColor.TabIndex = 3;
         this.btnResetSelectionForeColor.Text = "Reset selection  foreground color";
         this.btnResetSelectionForeColor.Click += new System.EventHandler(this.btnResetSelectionForeColor_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.btnResetBkColor,
                                                                                this.btnSetBkColor,
                                                                                this.btnResetForeColor,
                                                                                this.btnSetForeColor});
         this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.groupBox2.Location = new System.Drawing.Point(296, 128);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(248, 96);
         this.groupBox2.TabIndex = 5;
         this.groupBox2.TabStop = false;
         // 
         // btnSetForeColor
         // 
         this.btnSetForeColor.Location = new System.Drawing.Point(16, 24);
         this.btnSetForeColor.Name = "btnSetForeColor";
         this.btnSetForeColor.Size = new System.Drawing.Size(104, 32);
         this.btnSetForeColor.TabIndex = 0;
         this.btnSetForeColor.Text = "Set foreground color";
         this.btnSetForeColor.Click += new System.EventHandler(this.btnSetForeColor_Click);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.btnSetAlternatingBkColor,
                                                                                this.btnSetLinkColor,
                                                                                this.btnResetAlternatingBackColor,
                                                                                this.btnResetLinkColor});
         this.groupBox3.Location = new System.Drawing.Point(296, 224);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(248, 96);
         this.groupBox3.TabIndex = 7;
         this.groupBox3.TabStop = false;
         // 
         // btnSetAlternatingBkColor
         // 
         this.btnSetAlternatingBkColor.Location = new System.Drawing.Point(121, 24);
         this.btnSetAlternatingBkColor.Name = "btnSetAlternatingBkColor";
         this.btnSetAlternatingBkColor.Size = new System.Drawing.Size(104, 32);
         this.btnSetAlternatingBkColor.TabIndex = 5;
         this.btnSetAlternatingBkColor.Text = "Set alternating back color";
         this.btnSetAlternatingBkColor.Click += new System.EventHandler(this.btnSetAlternatingBkColor_Click);
         // 
         // btnSetLinkColor
         // 
         this.btnSetLinkColor.Location = new System.Drawing.Point(17, 24);
         this.btnSetLinkColor.Name = "btnSetLinkColor";
         this.btnSetLinkColor.Size = new System.Drawing.Size(104, 32);
         this.btnSetLinkColor.TabIndex = 4;
         this.btnSetLinkColor.Text = "Set link color";
         this.btnSetLinkColor.Click += new System.EventHandler(this.btnSetLinkColor_Click);
         // 
         // btnResetAlternatingBackColor
         // 
         this.btnResetAlternatingBackColor.Location = new System.Drawing.Point(121, 56);
         this.btnResetAlternatingBackColor.Name = "btnResetAlternatingBackColor";
         this.btnResetAlternatingBackColor.Size = new System.Drawing.Size(104, 32);
         this.btnResetAlternatingBackColor.TabIndex = 3;
         this.btnResetAlternatingBackColor.Text = "Reset alternating back color";
         this.btnResetAlternatingBackColor.Click += new System.EventHandler(this.btnResetAlternatingBackColor_Click);
         // 
         // btnResetLinkColor
         // 
         this.btnResetLinkColor.Location = new System.Drawing.Point(17, 56);
         this.btnResetLinkColor.Name = "btnResetLinkColor";
         this.btnResetLinkColor.Size = new System.Drawing.Size(104, 32);
         this.btnResetLinkColor.TabIndex = 1;
         this.btnResetLinkColor.Text = "Reset link color";
         this.btnResetLinkColor.Click += new System.EventHandler(this.btnResetLinkColor_Click);
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.btnSetGridLineColor,
                                                                                this.btnResetGridLineColor});
         this.groupBox4.Location = new System.Drawing.Point(164, 226);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(124, 93);
         this.groupBox4.TabIndex = 8;
         this.groupBox4.TabStop = false;
         // 
         // btnSetGridLineColor
         // 
         this.btnSetGridLineColor.Location = new System.Drawing.Point(8, 16);
         this.btnSetGridLineColor.Name = "btnSetGridLineColor";
         this.btnSetGridLineColor.Size = new System.Drawing.Size(104, 32);
         this.btnSetGridLineColor.TabIndex = 3;
         this.btnSetGridLineColor.Text = "Set grid line color";
         this.btnSetGridLineColor.Click += new System.EventHandler(this.btnSetGridLineColor_Click);
         // 
         // btnResetGridLineColor
         // 
         this.btnResetGridLineColor.Location = new System.Drawing.Point(8, 48);
         this.btnResetGridLineColor.Name = "btnResetGridLineColor";
         this.btnResetGridLineColor.Size = new System.Drawing.Size(104, 32);
         this.btnResetGridLineColor.TabIndex = 0;
         this.btnResetGridLineColor.Text = "Reset grid line color";
         this.btnResetGridLineColor.Click += new System.EventHandler(this.btnResetGridLineColor_Click);
         // 
         // myDataGrid
         // 
         this.myDataGrid.DataMember = "";
         this.myDataGrid.ForeColor = System.Drawing.Color.Blue;
         this.myDataGrid.Location = new System.Drawing.Point(12, 32);
         this.myDataGrid.Name = "myDataGrid";
         this.myDataGrid.Size = new System.Drawing.Size(272, 192);
         this.myDataGrid.TabIndex = 6;
         this.myDataGrid.ReadOnly = true; 
         // 
         // DatGridClass
         // 
         this.ClientSize = new System.Drawing.Size(560, 333);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.groupBox4,
                                                                      this.groupBox3,
                                                                      this.myDataGrid,
                                                                      this.groupBox2,
                                                                      this.groupBox1});
         this.Name = "DatGridClass";
         this.Text = "Sample Program";
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox4.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

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
         // Bind the 'DataGrid' to the 'DataSet'. The data member
         // specifies that the 'Customers Table' should be displayed.
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
   
         // Populate the tables. For each customer and order, 
         // create need two 'DataRow' variables. 
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
         tCust.Rows[0]["custName"] = "Alpha";
         tCust.Rows[1]["custName"] = "Beta";
         tCust.Rows[2]["custName"] = "Omega";

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
      private void btnSetSelectionBkColor_Click(object sender, System.EventArgs e)
      {
// <Snippet1> 
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
         // Keep the user from selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help.
         myColorDialog.ShowHelp = true ;
         // Set the initial color select to the current color.
         myColorDialog.Color = myDataGrid.SelectionBackColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set selection background color to selected color.
         myDataGrid.SelectionBackColor = myColorDialog.Color;
// </Snippet1>
      }
      private void btnResetSelectionBkColor_Click(object sender, System.EventArgs e)
      {
// <Snippet2>
         // String variable used to show message.
         string myString = "Selection backgound color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.SelectionBackColor;
         myString += myCurrentColor.ToString();
         // Reset selection background color to default.
         myDataGrid.ResetSelectionBackColor();
         myString += "  to ";
         myString += myDataGrid.SelectionBackColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Selection background color information");
// </Snippet2>
      }
      private void btnSetSelectionForeColor_Click(object sender, System.EventArgs e)
      {
// <Snippet3>
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
         // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Enable the help button.
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.SelectionForeColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set selection foreground color to selected color.
         myDataGrid.SelectionForeColor = myColorDialog.Color;
// </Snippet3>           
      }
      private void btnResetSelectionForeColor_Click(object sender, System.EventArgs e)
      {
// <Snippet4>
         // String variable used to show message.   
         string myString = "Selection foreground color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.SelectionForeColor;
         myString += myCurrentColor.ToString();
         // Reset selection foreground color to default.
         myDataGrid.ResetSelectionForeColor();
         myString += "  to ";
         myString += myDataGrid.SelectionForeColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Selection foreground color information");
// </Snippet4>
      }
      private void btnSetForeColor_Click(object sender, System.EventArgs e)
      {
// <Snippet5>
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
         // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Enable the help button. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.ForeColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set foreground color to selected color.
         myDataGrid.ForeColor = myColorDialog.Color;
// </Snippet5>
      }
      private void btnResetForeColor_Click(object sender, System.EventArgs e)
      {
// <Snippet6>
         // String variable used to show message.   
         string myString = "Foreground color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.ForeColor;
         myString += myCurrentColor.ToString();
         // Reset foreground color to default.
         myDataGrid.ResetForeColor();
         myString += "  to ";
         myString += myDataGrid.ForeColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Foreground color information");
// </Snippet6>
      }
      private void btnSetBkColor_Click(object sender, System.EventArgs e)
      {
         // Create a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
          // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.BackColor ;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set background color to selected color.
         myDataGrid.BackColor = myColorDialog.Color;
      }
      private void btnResetBkColor_Click(object sender, System.EventArgs e)
      {
// <Snippet7>
         // String variable used to show message.   
         string myString = "Backgound color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.BackColor;
         myString += myCurrentColor.ToString();
         // Reset background color to default.
         myDataGrid.ResetBackColor();
         myString += "  to ";
         myString += myDataGrid.BackColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Background color information");
// </Snippet7>
      }
      private void btnResetGridLineColor_Click(object sender, System.EventArgs e)
      {
// <Snippet8>
         // String variable used to show message.   
         string myString = "Grid line color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.GridLineColor;
         myString += myCurrentColor.ToString();
         // Reset grid line color to default.
         myDataGrid.ResetGridLineColor();
         myString += "  to ";
         myString += myDataGrid.GridLineColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Grid line color information");
// </Snippet8>
      }
      private void btnResetLinkColor_Click(object sender, System.EventArgs e)
      {
// <Snippet9>
         // String variable used to show message.   
         string myString = "Link color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.LinkColor;
         myString += myCurrentColor.ToString();
         // Reset link color to default.
         myDataGrid.ResetLinkColor();
         myString += "  to ";
         myString += myDataGrid.LinkColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Link line color information");
// </Snippet9>
      }
      private void btnResetAlternatingBackColor_Click(object sender, System.EventArgs e)
      {
// <Snippet10>
         // String variable used to show message.   
         string myString = "Alternating back color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid.AlternatingBackColor;
         myString += myCurrentColor.ToString();
         // Reset alternating back color to default.
         myDataGrid.ResetAlternatingBackColor();
         myString += "  to ";
         myString += myDataGrid.AlternatingBackColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Alternating back color information");
// </Snippet10>
      }
      private void btnSetGridLineColor_Click(object sender, System.EventArgs e)
      {
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
          // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.GridLineColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set grid line color to selected color.
         myDataGrid.GridLineColor = myColorDialog.Color;
      }
      private void btnSetLinkColor_Click(object sender, System.EventArgs e)
      {
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
          // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.LinkColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set link color to selected color.
         myDataGrid.LinkColor = myColorDialog.Color;
      }
      private void btnSetAlternatingBkColor_Click(object sender, System.EventArgs e)
      {
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
          // Disable selecting a custom color.
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color to the current color.
         myColorDialog.Color = myDataGrid.AlternatingBackColor;
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set alternating background color to selected color.
         myDataGrid.AlternatingBackColor = myColorDialog.Color;
      }
   }
}