   // System.Windows.Forms.DataGridTableStyle.ResetHeaderForeColor

   /*
   The following example demonstrates 'ResetHeaderForeColor' method of 'DataGridTableStyle' class. 
   It adds a datagrid and two buttons to a form. A 'DataGridTableStyle' instance is mapped to the table of 'DataGrid'.
   When the user clicks on 'Set the HeaderForeColor' button it sets the header fore color. If the user clicks on 
   'Reset HeaderForeColor' button it resets the grid 'HeaderForeColor' to its default value.
   */

   using System;
   using System.Data;
   using System.Drawing;
   using System.Windows.Forms;

   public class MyForm1 : Form
   {
         private Button myButton1;
         private Button myButton2;
         private DataGrid myDataGrid;
         private DataSet myDataSet;
         private DataGridColumnStyle myDataGridColumnStyle;
         private DataGridTableStyle myDataTableStyle;

         public MyForm1()
         {
            InitializeComponent();
            // Create a dataset.
            MakeDataSet();
            // Bind datagrid to the dataset.
            myDataGrid.SetDataBinding(myDataSet, "Customers");
            AddCustomDataTableStyle();
         }

         private void InitializeComponent()
         {
            // Create the form and its controls.
            myButton1 = new Button();
            myButton2 = new Button();

            myDataGrid = new DataGrid();
            Text = "DataGridTableStyle Sample";
            ClientSize = new Size(450, 330);

            myButton1.Location = new Point(50, 16);
            myButton1.Size = new Size(176, 23);
            myButton1.Text = "Set the HeaderForeColor";
            myButton1.Click += new EventHandler(myButton1_Click);

            myButton2.Location = new Point(230, 16);
            myButton2.Size = new Size(140, 24);
            myButton2.Text = "Reset HeaderForeColor";
            myButton2.Click += new EventHandler(myButton2_Click);

            myDataGrid.Location = new  Point(24, 50);
            myDataGrid.Size = new Size(240, 150);
            myDataGrid.CaptionText = "DataGridTableStyle Example";
            Controls.Add(myButton1);
            Controls.Add(myDataGrid);
            Controls.Add(myButton2);
         }

         public static void Main()
         {
            Application.Run(new MyForm1());
         }

// <Snippet1>
         private void myButton1_Click(object sender, EventArgs e)
         {
            // Set the 'HeaderForeColor' property.
            myDataTableStyle.HeaderForeColor = Color.Blue;
         }
         private void myButton2_Click(object sender, EventArgs e)
         {
            // Reset the 'HeaderForeColor' property to its default value.
            myDataTableStyle.ResetHeaderForeColor();
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

      // Create a dataset with one table and populate it.
      private void MakeDataSet()
      {
         // Create a dataset.
         myDataSet = new DataSet("myDataSet");
         DataTable myTable = new DataTable("Customers");
         // Create a column, and add it to the table.
         DataColumn myColumn = new DataColumn("CustName", typeof(string));
         myTable.Columns.Add(myColumn);

         // Add the table to dataset.
         myDataSet.Tables.Add(myTable);

         DataRow newRow1;
         for(int i = 0; i < 5; i++)
         {
            newRow1 = myTable.NewRow();
            newRow1["CustName"] = i;
            // Add the row to customers table.
            myTable.Rows.Add(newRow1);
         }
            myTable.Rows[0]["CustName"] ="Jones";
            myTable.Rows[1]["CustName"] ="James";
            myTable.Rows[2]["CustName"] ="David";
            myTable.Rows[3]["CustName"] ="Robert";
            myTable.Rows[4]["CustName"] ="John";
      }
   }
