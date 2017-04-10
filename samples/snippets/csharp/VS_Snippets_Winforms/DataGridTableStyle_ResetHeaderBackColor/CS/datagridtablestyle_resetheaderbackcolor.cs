// System.Windows.Forms.DataGridTableStyle.ResetHeaderBackColor

/*
The following example demonstrates the 'ResetHeaderBackColor' method of 'DataGridTableStyle' class. 
It adds a 'DataGrid' and two buttons to a form. Then it creates a 'DataGridTableStyle' and maps it to the table of 
'DataGrid'. When the user clicks on  'Change the ResetHeaderBackColor' button it changes the Header Background 
color to light pink. If the user clicks the 'ResetHeaderBackColor' button it changes the Header Background 
Color to default color.
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
         myButton = new Button();
         myButton1 = new Button();

         myDataGrid = new DataGrid();
         Text = "DataGridTableStyle Sample";
         ClientSize = new Size(450, 330);

         myButton.Location = new Point(50, 16);
         myButton.Name = "button1";
         myButton.Size = new Size(176, 23);
         myButton.TabIndex = 2;
         myButton.Text = "Change the HeaderBackColor";
         myButton.Click += new EventHandler(Button_Click);

         myButton1.Location = new Point(230, 16);
         myButton1.Name = "myButton";
         myButton1.Size = new Size(140, 24);
         myButton1.TabIndex = 0;
         myButton1.Text = "Reset HeaderBackColor";
         myButton1.Click += new EventHandler(Button1_Click);

         myDataGrid.Location = new  Point(24, 50);
         myDataGrid.Size = new Size(240, 150);
         myDataGrid.CaptionText = "DataGridTableStyle";
         Controls.Add(myButton);
         Controls.Add(myDataGrid);
         Controls.Add(myButton1);
      }

      public static void Main()
      {
         Application.Run(new Form1());
      }

// <Snippet1>

      private void Button_Click(object sender, EventArgs e)
      {
         // Change the color of 'HeaderBack'.
         myDataTableStyle.HeaderBackColor = Color.LightPink;
      }

      private void Button1_Click(object sender, EventArgs e)
      {
          // Reset the 'HeaderBack' to its origanal color.
          myDataTableStyle.ResetHeaderBackColor();
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
