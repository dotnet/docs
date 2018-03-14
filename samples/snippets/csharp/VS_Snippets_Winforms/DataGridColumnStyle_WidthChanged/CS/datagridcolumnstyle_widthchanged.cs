// System.Windows.Forms.DataGridColumnStyle.WidthChanged

/*
   The following example demonstrates the 'WidthChanged' event of 
   the 'DataGridColumnStyle' class. In the example a message will be 
   displayed whenever the width of the 'Customer ID' column of the 
   data grid is changed.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyWidthChangedEventExample
{
   public class MyForm : Form
   {
      private Container components = null;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private Button myButtonNone;
      private Button myButtonSolid;
      private Label myLabel;

      public MyForm()
      {
         InitializeComponent();
         SetUp();
      }

      protected override void Dispose( bool disposing )
      {
         if ( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      [STAThread]
      static void Main() 
      {
         Application.Run(new MyForm());
      }

      private void InitializeComponent()
      {
         try
         {
            // Create a Label.
            myLabel = new Label();
            myLabel.Text = "Change width of 'Customer ID' column to see"+
                           "'WidthChanged' event message.";
            myLabel.Location = new Point(0, 0);
            myLabel.Size = new System.Drawing.Size(400, 20);
            myLabel.ForeColor = Color.Blue;

            // Create the first button.
            myButtonNone = new Button();
            myButtonNone.Location = new Point(24, 21);
            myButtonNone.Size = new System.Drawing.Size(150, 24);
            myButtonNone.Text = "Apply 'None' Line Style ";
            myButtonNone.Click += new EventHandler(OnNoneButtonClick);

            // Create the second button.
            myButtonSolid = new Button();
            myButtonSolid.Location = new Point(180, 21);
            myButtonSolid.Size = new System.Drawing.Size(150, 24);
            myButtonSolid.Text = "Apply 'Solid' Line Style ";
            myButtonSolid.Click += new EventHandler(OnSolidButtonClick);

            Text = "DataGridColumnStyle Sample";
            ClientSize = new System.Drawing.Size(400, 300);

            // Create a data grid.
            myDataGrid = new DataGrid();
            myDataGrid.Location = new  Point(24, 55);
            myDataGrid.Size = new Size(345, 200);
            myDataGrid.CaptionText = "Microsoft DataGrid Control";
            
            // Create a data grid table style.
            DataGridTableStyle myDataGridTableStyle = new DataGridTableStyle();
            myDataGridTableStyle.MappingName = "Customers";
            myDataGridTableStyle.AlternatingBackColor = Color.LightGray;

// <Snippet1>
            // Add the 'Customer ID' column style.
            DataGridColumnStyle myIDCol = new DataGridTextBoxColumn();
            myIDCol.MappingName = "custID";
            myIDCol.HeaderText = "Customer ID";
            myIDCol.Width = 100;
            myIDCol.WidthChanged += new EventHandler(MyIDColumnWidthChanged);
            myDataGridTableStyle.GridColumnStyles.Add(myIDCol);
// </Snippet1>

            // Add the 'Customer Name' column style.
            DataGridColumnStyle myNameCol = new DataGridTextBoxColumn();
            myNameCol.MappingName = "custName";
            myNameCol.HeaderText = "Customer Name";
            myNameCol.Width = 150;
            myDataGridTableStyle.GridColumnStyles.Add(myNameCol);
            myDataGrid.TableStyles.Add(myDataGridTableStyle);

            // Add the controls.
            Controls.Add(myLabel);
            Controls.Add(myButtonNone);
            Controls.Add(myButtonSolid);
            Controls.Add(myDataGrid);
         }
         catch(Exception exc)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + exc.Source);
            Console.WriteLine("Message : " + exc.Message);
         }
      }

      private void SetUp()
      {
         try
         {
            // Create a DataSet with one table.
            MakeDataSet();
            // Bind the DataGrid to the DataSet.
            myDataGrid.SetDataBinding(myDataSet, "Customers");
         }
         catch(Exception exc)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + exc.Source);
            Console.WriteLine("Message : " + exc.Message);
         }
      }

      private void MakeDataSet()
      {
         try
         {
            // Create a DataSet.
            myDataSet = new DataSet("myDataSet");
            // Create a DataTable.
            DataTable myCustTable = new DataTable("Customers");
            // Create two columns and add them to the table.
            DataColumn cCustID = new DataColumn("CustID", typeof(int));
            DataColumn cCustName = new DataColumn("CustName");
            
            myCustTable.Columns.Add(cCustID);
            myCustTable.Columns.Add(cCustName);

            myDataSet.Tables.Add(myCustTable);

            DataRow newRow1;
            for (int i = 1; i < 4; i++)
            {
               newRow1 = myCustTable.NewRow();
               newRow1["custID"] = i;
               // Add the row to the Customers table.
               myCustTable.Rows.Add(newRow1);
            }
            // Add the customers to the table.
            myCustTable.Rows[0]["custName"] = "Alpha";
            myCustTable.Rows[1]["custName"] = "Beta";
            myCustTable.Rows[2]["custName"] = "Omega";
         }
         catch(Exception exc)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + exc.Source);
            Console.WriteLine("Message : " + exc.Message);
         }
      }

      private void MyIDColumnWidthChanged(Object obj, EventArgs e)
      {
         try
         {
            // Get the changed width of the 'Customer ID' column and display.
            DataGridTableStyle myTableStyle = myDataGrid.TableStyles["Customers"];
            int myWidth = myTableStyle.GridColumnStyles["custID"].Width;
            MessageBox.Show("Width of 'Customer ID' column is " +
                            "changed to :" +  myWidth.ToString() + 
                            " pixels");
         }
         catch(Exception exc)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + exc.Source);
            Console.WriteLine("Message : " + exc.Message);
         }
      }

      private void OnNoneButtonClick(Object obj, EventArgs e)
      {
         try
         {
            DataGridTableStyle myTableStyle = myDataGrid.TableStyles["Customers"];
            myTableStyle.GridLineStyle = DataGridLineStyle.None;
         }
         catch(Exception exc)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + exc.Source);
            Console.WriteLine("Message : " + exc.Message);
         }
      }

      private void OnSolidButtonClick(Object obj, EventArgs e)
      {
         try
         {
            DataGridTableStyle myTableStyle = myDataGrid.TableStyles["Customers"];
            myTableStyle.GridLineStyle = DataGridLineStyle.Solid;
         }
         catch(Exception exc)
         {
            Console.WriteLine("Exception caught!!!");
            Console.WriteLine("Source : " + exc.Source);
            Console.WriteLine("Message : " + exc.Message);
         }
      }
    }
}