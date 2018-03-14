// System.Windows.Forms.DataGridTableStyle.SelectionForeColor
// System.Windows.Forms.DataGridTableStyle.ResetSelectionForeColor

/* The following program demonstrates the use of 'SelectionForeColor' 
   property  and 'ResetSelectionForeColor' method of 
   'System.Windows.Forms.DataGridTableStyle'. 
   It creates a windows form, a 'DataSet' containing one 'DataTable' 
   object. A 'DataGridTableStyle' is attached to 'DataTable'.
   To display the data, a 'DataGrid' control is then bound to the 
   'DataSet' through the 'SetDataBinding' method. 
   Two button are provided on form to show 'SelectionForeColor' and
   'ResetSelectionForeColor'.
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyDataGridNamespace
{
   public class MyForm : System.Windows.Forms.Form
   {
      private System.ComponentModel.Container components = null;

      public MyForm()
      {
         InitializeComponent();
      }

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
         this.myDataGrid = new System.Windows.Forms.DataGrid();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // myDataGrid
         // 
         this.myDataGrid.DataMember = "";
         this.myDataGrid.Location = new System.Drawing.Point(32, 16);
         this.myDataGrid.Name = "dataGrid1";
         this.myDataGrid.Size = new System.Drawing.Size(232, 144);
         this.myDataGrid.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(16, 16);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(144, 24);
         this.button1.TabIndex = 0;
         this.button1.Text = "SetSelectionForeColor";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(16, 40);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(144, 24);
         this.button2.TabIndex = 1;
         this.button2.Text = "ResetSelectionForeColor";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.button2,
                                                                                this.button1});
         this.groupBox1.Location = new System.Drawing.Point(64, 168);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(176, 80);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         // 
         // MyForm
         // 
         this.ClientSize = new System.Drawing.Size(320, 266);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.groupBox1,
                                                                      this.myDataGrid});
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "MyForm";
         this.Text = "MyForm";
         this.Load += new System.EventHandler(this.MyFormLoad);
         ((System.ComponentModel.ISupportInitialize)(this.myDataGrid)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion
      DataGridTableStyle customersStyle = new DataGridTableStyle ();
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.DataGrid myDataGrid;
      [STAThread]
      static void Main() 
      {
         Application.Run(new MyForm());
      }

      private void MyFormLoad(object sender, System.EventArgs e)
      {
          myDataGrid.SetDataBinding(MakeDataSet(), "Customers");
         // Add data grid control to form.
         Controls.Add( myDataGrid);
      }
      private DataSet MakeDataSet()
      {
         // Create a DataSet.
         DataSet myDataSet = new DataSet("myDataSet");

         // Create two DataTables.
         DataTable tCustomers = new DataTable("Customers");
         // Map 'CustomersStyle' to 'Customers' table.
         customersStyle.MappingName = "Customers";
         // Add the DataGridTableStyle objects to the collection.
         myDataGrid.TableStyles.Add (customersStyle);


         // Create two columns and add them to the first table.
         DataColumn cCustID = new DataColumn("CustID", typeof(int));
         DataColumn cCustName = new DataColumn("CustName");
         DataColumn cCurrent = new DataColumn("Current", typeof(bool));
         tCustomers.Columns.Add(cCustID);
         tCustomers.Columns.Add(cCustName);
         tCustomers.Columns.Add(cCurrent);
         

         // Create three columns, and add them to the second table.
         DataColumn cID = new DataColumn("CustID", typeof(int));
         DataColumn cOrderDate = new DataColumn("orderDate",typeof(DateTime));
         DataColumn cOrderAmount = new DataColumn("OrderAmount", typeof(decimal));

         // Add the tables to the DataSet.
         myDataSet.Tables.Add( tCustomers);

         // Populate the tables. 
         // Create two DataRow variables for each customer and order.
         DataRow newRow1;

         // Create three customers in the Customers Table.
         for(int i = 1; i < 4; i++)
         {
            newRow1 =  tCustomers.NewRow();
            newRow1["custID"] = i;
            // Add the row to the Customers table.
             tCustomers.Rows.Add(newRow1);
         }
         // Give each customer a distinct name.
          tCustomers.Rows[0]["custName"] = "Customer 1";
          tCustomers.Rows[1]["custName"] = "Customer 2";
          tCustomers.Rows[2]["custName"] = "Customer 3";

         // Give the Current column a value.
          tCustomers.Rows[0]["Current"] = true;
          tCustomers.Rows[1]["Current"] = true;
          tCustomers.Rows[2]["Current"] = false;
         return myDataSet;
      }

      private void button1_Click(object sender, System.EventArgs e)
      {
// <Snippet1>
         // Creates a common color dialog box.
         ColorDialog myColorDialog = new ColorDialog();
         myColorDialog.AllowFullOpen = false ;
         // Allow the user to get help. 
         myColorDialog.ShowHelp = true ;
         // Set the initial color select to the current color.
         myColorDialog.Color = customersStyle.SelectionForeColor; 
         // Show color dialog box.
         myColorDialog.ShowDialog();
         // Set selection fore color to selected color.
         customersStyle.SelectionForeColor = myColorDialog.Color;
// </Snippet1>
      }

      private void button2_Click(object sender, System.EventArgs e)
      {
// <Snippet2>
         // String variable used to show message.   
         string myString = "Fore color changed from: ";
         // Store current foreground color of selected cells.
         Color myCurrentColor = customersStyle.SelectionForeColor;
         myString += myCurrentColor.ToString();
         // Reset selection fore color to default.
         customersStyle.ResetSelectionForeColor();
         myString += "  to ";
         myString += customersStyle.SelectionForeColor.ToString();
         // Show information about changes in color setting.  
         MessageBox.Show(myString, "Selection fore color information");
// </Snippet2>
     }
   }
}