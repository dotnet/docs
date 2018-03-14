// System.Windows.Forms.DataGridTableStyle.ResetGridLineColor

/*
 The following example demonstrates the 'ResetGridLineColor'  method of 'DataGridTableStyle' class. 
 It adds a 'DataGrid' and two buttons to a form. Then it creates a 'DataGridTableStyle' and adds it to the 'DataGrid'.
 When the user clicks, the 'Change the GridLineColor' button it changes the GridLineColor to 'blue'. If the user clicks 
 the 'Reset GridLineColor' button it changes the GridLineColor to  default color.
 */

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
      private Button myButton;
      private Button myButton1;
      private DataGrid myDataGrid;
      private DataSet myDataSet;
      private DataGridColumnStyle myDataGridColumnStyle;
      private DataGridTableStyle myDataTableStyle;

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
         this.myButton1 = new Button();

         this.myDataGrid = new DataGrid();
         this.Text = "DataGridTableStyle Sample";
         this.ClientSize = new Size(450, 330);

         this.myButton.Location = new Point(50, 16);
         this.myButton.Name = "button1";
         this.myButton.Size = new Size(176, 23);
         this.myButton.TabIndex = 2;
         this.myButton.Text = "Change the GridLineColor";
         this.myButton.Click += new EventHandler(this.Button_Click);

         this.myButton1.Location = new Point(230, 16);
         this.myButton1.Name = "myButton";
         this.myButton1.Size = new Size(140, 24);
         this.myButton1.TabIndex = 0;
         this.myButton1.Text = "Reset GridLineColor";
         this.myButton1.Click += new EventHandler(this.Button1_Click);

         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(240, 150);
         myDataGrid.CaptionText = "DataGridTableStyle";
         this.Controls.Add(myButton);
         this.Controls.Add(myDataGrid);
         this.Controls.Add(myButton1);
      }

      public static void Main()
      {
         Application.Run(new Form1());
      }

// <Snippet1>

      private void Button_Click(object sender, EventArgs e)
      {
           // Change the 'GridLineColor'.
           myDataTableStyle.GridLineColor = Color.Blue;
      }

      private void Button1_Click(object sender, EventArgs e)
      {
         // Reset the 'GridLineColor' to its orginal color.
          myDataTableStyle.ResetGridLineColor();
      }
// </Snippet1>


      private void AddCustomDataTableStyle()
      {
         // Create a 'DataGridTableStyle'.
         myDataTableStyle = new DataGridTableStyle();
         myDataTableStyle.MappingName = "Customers";
         // Create a 'DataGridColumnStyle'.
         myDataGridColumnStyle = new DataGridTextBoxColumn();
         myDataGridColumnStyle.MappingName = "CustName";
         myDataGridColumnStyle.HeaderText = "Customer Name";
         myDataGridColumnStyle.Width = 150;

         // Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
         myDataTableStyle.GridColumnStyles.Add(myDataGridColumnStyle);
         // Add the 'DataGridTableStyle' to 'DataGrid'.
         myDataGrid.TableStyles.Add(myDataTableStyle);
      }

   // Create a DataSet with two tables and populate it.
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
          myTable.Rows.Add(newRow1);
      }
           myTable.Rows[0]["CustName"] ="Jones";
           myTable.Rows[1]["CustName"] ="James";
           myTable.Rows[2]["CustName"] ="David";
           myTable.Rows[3]["CustName"] ="Robert";
           myTable.Rows[4]["CustName"] ="John";
    }
   }
