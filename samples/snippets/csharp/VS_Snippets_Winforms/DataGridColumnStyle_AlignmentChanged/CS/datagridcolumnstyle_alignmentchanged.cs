// System.Windows.Forms.DataGridColumnStyle.AlignmentChanged

/*
 The following example demonstrates the 'AlignmentChanged' event of 'DataGridColumnStyle' class. 
 It adds a DataGrid and a button to a form. Then it creates a 'DataGridColumnStyle' object  and 
adds an eventhandler for the 'AlignmentChanged' event. When  user clicks the 'Change Alignment' 
button it changes the alignment of the 'DataGridColumnStyle' and the 'AlignmentChanged' event is 
raised.
 */

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
      private Button myButton;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private DataGridColumnStyle myDataGridColumnStyle;

      public Form1()
      {
         InitializeComponent();
         MakeDataSet();
         myDataGrid.SetDataBinding(myDataSet, "Customers");
         AddCustomDataTableStyle();
      }

      private void InitializeComponent()
      {
         // Create the form and its controls.
         this.myButton = new Button();

         this.myDataGrid = new DataGrid();
         this.Text = "DataGrid Control Sample";
         this.ClientSize = new Size(450, 330);
         myButton.Location = new Point(150, 16);
         myButton.Size = new Size(120, 24);
         myButton.Text = "Change Alignment";
         myButton.Click+=new EventHandler(Button_Click);

         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(300, 200);
         myDataGrid.CaptionText = "DataGridColumnStyle";
         this.Controls.Add(myButton);
         this.Controls.Add(myDataGrid);
      }

      public static void Main()
      {
         Application.Run(new Form1());
      }
    String myMessage = null;



      private void Button_Click(object sender, EventArgs e)
      {
         myDataGridColumnStyle.Alignment = HorizontalAlignment.Center;
         MessageBox.Show(myMessage);
      }

// <Snippet1>
      private void AlignmentChanged_Click(object sender, EventArgs e)
      {
           myMessage = "Alignment has been Changed"; 
      }
      private void AddCustomDataTableStyle()
      {
         // Create a 'DataGridTableStyle'.
         DataGridTableStyle myDataTableStyle = new DataGridTableStyle();
         myDataTableStyle.MappingName = "Customers";
         // Create a 'DataGridColumnStyle'.
         myDataGridColumnStyle = new DataGridTextBoxColumn();
         myDataGridColumnStyle.MappingName = "CustName";
         myDataGridColumnStyle.HeaderText = "Customer Name";
         myDataGridColumnStyle.Width = 250;
         myDataGridColumnStyle.AlignmentChanged+=new EventHandler(AlignmentChanged_Click);
         // Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
         myDataTableStyle.GridColumnStyles.Add(myDataGridColumnStyle);
         // Add the 'DataGridTableStyle' to 'DataGrid'.
         myDataGrid.TableStyles.Add(myDataTableStyle);
      }
// </Snippet1>

   private void MakeDataSet()
   {
      myDataSet = new DataSet("myDataSet");
      DataTable myTable = new DataTable("Customers");
      DataColumn myColumn = new DataColumn("CustName", typeof(string));
      myTable.Columns.Add(myColumn);

      myDataSet.Tables.Add(myTable);

      DataRow newRow1;
       for(int i = 0; i < 5; i++)
      {
         newRow1 = myTable.NewRow();
         newRow1["CustName"] = i;
         // Add the row to the Customers table.
          myTable.Rows.Add(newRow1);
      }
           myTable.Rows[0]["CustName"] ="Jones";
           myTable.Rows[1]["CustName"] ="James";
           myTable.Rows[2]["CustName"] ="David";
           myTable.Rows[3]["CustName"] ="Robert";
           myTable.Rows[4]["CustName"] ="John";
         
    }
   }
