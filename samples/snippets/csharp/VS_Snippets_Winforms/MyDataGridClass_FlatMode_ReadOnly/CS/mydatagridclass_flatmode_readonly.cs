// System.Windows.Forms.DataGrid.ReadOnlyChanged
// System.Windows.Forms.DataGrid.FlatModeChanged

/* The following program demonstrates the methods 'ReadOnlyChanged' and 
   'FlatModeChanged' of the 'DataGrid' class. It creates a 
   'GridControl' and checks the properties 'ReadOnly' and 'FlatMode'
   of data grid, depending on the selection of buttons.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyDataGridClass
{
   public class MyDataGridClass_FlatMode_ReadOnly : Form
   {
      private DataGrid myDataGrid;
      private Button button1;
      private Button button2;
      private DataSet myDataSet;
      private Container components = null;

      public MyDataGridClass_FlatMode_ReadOnly()
      {
         InitializeComponent();
         SetUp();
         
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
         this.FormBorderStyle = FormBorderStyle.FixedDialog;
         this.myDataGrid = new DataGrid();
         this.button1 = new Button();
         this.button2 = new Button();
         ((ISupportInitialize)(this.myDataGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // myDataGrid
         // 
         this.myDataGrid.CaptionText = "My Grid Control";
         this.myDataGrid.DataMember = "";
         this.myDataGrid.Location = new Point(16, 16);
         this.myDataGrid.Name = "myDataGrid";
         this.myDataGrid.Size = new Size(168, 112);
         this.myDataGrid.TabIndex = 0;

         AttachFlatModeChanged();
         AttachReadOnlyChanged();
         
         // 
         // button1
         // 
         this.button1.Location = new Point(24, 160);
         this.button1.Name = "button1";
         this.button1.Size = new Size(72, 40);
         this.button1.TabIndex = 1;
         this.button1.Text = "Toggle Flat Mode";
         this.button1.Click += new EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new Point(96, 160);
         this.button2.Name = "button2";
         this.button2.Size = new Size(72, 40);
         this.button2.TabIndex = 1;
         this.button2.Text = "Toggle Read Only";
         this.button2.Click += new EventHandler(this.button2_Click);
         // 
         // MyDataGridClass_FlatMode_ReadOnly
         // 
         this.ClientSize = new Size(208, 205);
         this.Controls.AddRange(new Control[] {
                                                                      this.button1,
                                                                      this.myDataGrid,
                                                                      this.button2});
         this.MaximizeBox = false;
         this.Name = "MyDataGridClass_FlatMode_ReadOnly";
         this.Text = "Grid Control";
         ((ISupportInitialize)(this.myDataGrid)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() 
      {
         Application.Run(new MyDataGridClass_FlatMode_ReadOnly());
      }
      private void SetUp()
      {
         MakeDataSet();
         myDataGrid.SetDataBinding(myDataSet, "Customers");
      }

      private void MakeDataSet()
      {
         // Create a DataSet.
         myDataSet = new DataSet("myDataSet");
         // Create a DataTable.
         DataTable myTable = new DataTable("Customers");
         // Create two columns, and add them to the table.
         DataColumn myColumn1 = new DataColumn("CustID", typeof(int));
         DataColumn myColumn2 = new DataColumn("CustName");
         myTable.Columns.Add(myColumn1);
         myTable.Columns.Add(myColumn2);
         // Add the table to the DataSet.
         myDataSet.Tables.Add(myTable);   
         // For the customer, create a 'DataRow' variable. 
         DataRow newRow;
         // Create one customer in the customers table.
         for(int i = 1; i < 2; i++)
         {
            newRow = myTable.NewRow();
            newRow["custID"] = i;
            // Add the row to the 'Customers' table.
            myTable.Rows.Add(newRow);
         }
         // Give the customer a name.
         myTable.Rows[0]["custName"] = "Customer";               
      }

// <Snippet1> 
      // Attach to event handler.
      private void AttachFlatModeChanged()
      {
         this.myDataGrid.FlatModeChanged += new EventHandler(this.myDataGrid_FlatModeChanged);
      }
      // Check if the 'FlatMode' property is changed.
      private void myDataGrid_FlatModeChanged(object sender, EventArgs e)
      {
         string strMessage = "false";
         if(myDataGrid.FlatMode == true)
            strMessage = "true";

         MessageBox.Show("Flat mode changed to "+strMessage,
            "Message",   MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
         
      }
      // Toggle the 'FlatMode'.
      private void button1_Click(object sender, EventArgs e)
      {
         if(myDataGrid.FlatMode == true)
            myDataGrid.FlatMode = false;
         else
            myDataGrid.FlatMode = true;
      }
// </Snippet1>
// <Snippet2>
      // Attach to event handler.
      private void AttachReadOnlyChanged()
      {
         this.myDataGrid.ReadOnlyChanged += new EventHandler(this.myDataGrid_ReadOnlyChanged);
      }
      // Check if the 'ReadOnly' property is changed.
      private void myDataGrid_ReadOnlyChanged(object sender, EventArgs e)
      {   
         string strMessage = "false";
         if(myDataGrid.ReadOnly == true)
            strMessage = "true";

         MessageBox.Show("Read only changed to "+strMessage,
            "Message",   MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);         
      }
      // Toggle the 'ReadOnly' property.
      private void button2_Click(object sender, EventArgs e)
      {
         if(myDataGrid.ReadOnly == true)
            myDataGrid.ReadOnly = false;
         else
            myDataGrid.ReadOnly = true;
      }      
// </Snippet2>
   }
}
