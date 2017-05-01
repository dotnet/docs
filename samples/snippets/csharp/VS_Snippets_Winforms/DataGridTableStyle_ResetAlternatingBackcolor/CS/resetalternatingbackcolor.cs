   // System.Windows.Forms.DataGridTableStyle.ResetAlternatingBackColor

   /*
     The following example demonstrates the 'ResetAlternatingBackColor' method of 'DataGridTableStyle' class.
     It adds a 'DataGrid' and two buttons to a form. The instance of 'DataGridTableStyle' is mapped
     to a table of DataGrid. One button sets the Alternating background color of 'DataGrid' and other resets 
     it to its default value.
   */

         using System;
         using System.Drawing;
         using System.Collections;
         using System.ComponentModel;
         using System.Windows.Forms;
         using System.Data;

         public class DataGridTableStyle_resetcolor : Form
         {
            DataGridTableStyle myDataGridTableStyle = new DataGridTableStyle();
            private DataGrid myDataGrid;
            private Button myButton1;
            private Button myButton2;
            private void InitializeComponent()
            {
               myButton1 = new Button();
               myButton2 = new Button();
               myDataGrid = new DataGrid();
               
               myButton1.Location = new Point(56, 184);
               myButton1.Size = new Size(176, 24);
               myButton1.Text = "Alternating back color ";
               myButton1.Click += new EventHandler(myButton1_Click);
               
               myButton2.Location = new Point(56, 224);
               myButton2.Size = new Size(184, 24);
               myButton2.Text = "Reset";
               myButton2.Click += new EventHandler(myButton2_Click);

               myDataGrid.LinkColor =SystemColors.Desktop;
               myDataGrid.Location = new Point(56, 32);
               myDataGrid.Name = "myDataGrid";
               myDataGrid.Size = new Size(168, 144);
               myDataGrid.TabIndex = 1;

               ClientSize = new Size(292, 273);
               Controls.AddRange(new Control[] {myButton2,myDataGrid,myButton1});
               Text ="Test DataGridTableStyle.ResetAlternatingBackColor method";
               Load += new EventHandler(DataGridTableStyle_Reset_color);
            }
            static void Main() 
            {
               Application.Run(new DataGridTableStyle_resetcolor());
            }

            public DataGridTableStyle_resetcolor()
            {
               InitializeComponent();
               // Create and bind DataSet to DataGrid.
               CreateDataSet();
            }
            private void CreateDataSet()
            {
               // Create a DataSet
               DataSet myDataSet = new DataSet("myDataSet");
               // Create a DataTable.
               DataTable myEmpTable = new DataTable("Employee");
               DataColumn myEmpID = new DataColumn("EmpID", typeof(int));
               myEmpTable.Columns.Add(myEmpID); 
               // Add the table to the DataSet.
               myDataSet.Tables.Add(myEmpTable);
               DataRow newRow1;
               for(int i = 1; i < 6; i++)
               {
                  newRow1 = myEmpTable.NewRow();
                  newRow1["EmpID"] = i;
                  // Add the row to the Employee table.
                  myEmpTable.Rows.Add(newRow1);
               }

               // Bind the DataGrid to the DataSet.
               myDataGrid.SetDataBinding(myDataSet, "Employee");
            }
            private void DataGridTableStyle_Reset_color(object sender,EventArgs e)
            {
               myDataGridTableStyle.MappingName = "Employee";
               myDataGrid.TableStyles.Add(myDataGridTableStyle);
            }
// <Snippet1>
            private void myButton1_Click(object sender,EventArgs e)
            {
               //Set the 'AlternatingBackColor'.
               myDataGridTableStyle.AlternatingBackColor=Color.Blue;
            }
            private void myButton2_Click(object sender,EventArgs e)
            {
               // Reset the 'AlternatingBackColor'.
               myDataGridTableStyle.ResetAlternatingBackColor();
            }
// </Snippet1>
         }
