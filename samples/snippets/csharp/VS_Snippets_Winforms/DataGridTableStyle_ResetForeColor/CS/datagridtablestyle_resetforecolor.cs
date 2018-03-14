    // System.Windows.Forms.DataGridTableStyle.ResetForeColor

   /*
      The following example demonstrates 'ResetForeColor' method of 'DataGridTableStyle' class.
      A DataGrid and two Buttons are added to the form. A 'DataGridTableStyle' instance is mapped to table of 
      'DataGrid'. When the user clicks on 'Set ForeColor' button foreground color is set to blue. When 
      'Reset ForeColor' button is clicked foreground color is reset to its default value. 
   */



    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Data;

    namespace MyDataGridColumnStyle
    {
        public class MyForm1 : Form
        {
            private DataGrid myDataGrid;
            private Button btnSetForeColor;
            private Button btnResetForeColor;
            private DataSet myDataSet;
            private DataGridTableStyle myDataGridTableStyle;
            private DataTable myDataTable;
            private DataColumn myDataColumn1;

            public MyForm1()
            {
                InitializeComponent();
                // Call 'SetUp' method to bind the controls.
                SetUp();
            }

            private void InitializeComponent()
            {
                btnResetForeColor = new Button();
                btnSetForeColor = new Button();
                myDataGrid = new DataGrid();

                // Initialize Buttons.
                btnSetForeColor.Location = new Point(35, 290);
                btnSetForeColor.Name = "btnSetForeColor";
                btnSetForeColor.Size = new Size(110, 30);
                btnSetForeColor.TabIndex = 1;
                btnSetForeColor.Text = "Set ForeColor";
                btnSetForeColor.Click += new EventHandler(BtnSetForeColor_Click);

                btnResetForeColor.Location = new Point(155, 290);
                btnResetForeColor.Name = "btnResetForeColor";
                btnResetForeColor.Size = new Size(110, 30);
                btnResetForeColor.TabIndex = 2;
                btnResetForeColor.Text = "Reset ForeColor";
                btnResetForeColor.Click += new EventHandler(BtnResetForeColor_Click);

                // Initialize DataGrid.
                myDataGrid.DataMember = "";
                myDataGrid.Location = new Point(48, 72);
                myDataGrid.Name = "myDataGrid";
                myDataGrid.Size = new Size(200, 200);
                myDataGrid.TabIndex = 0;
                ClientSize = new Size(296, 389);

                // Add the Buttons and the DataGrid to the Window.
                Controls.Add(myDataGrid);
                Controls.Add(btnSetForeColor);
                Controls.Add(btnResetForeColor);

                Name = "MyForm1";
                Text = "MyForm1";
                ((System.ComponentModel.ISupportInitialize)(myDataGrid)).EndInit();
                ResumeLayout(false);
            }
            
            static void Main() 
            {
                Application.Run(new MyForm1());
            }

// <Snippet1>
            private void BtnSetForeColor_Click(Object sender, EventArgs e)
            {
               // Set the foreground color of table.
               myDataGridTableStyle.ForeColor=Color.Blue;
               myDataGrid.TableStyles.Add(myDataGridTableStyle);
            }
           private void BtnResetForeColor_Click(Object sender, EventArgs e)
           {
              // Reset the foreground color of table to its default value.
              myDataGridTableStyle.ResetForeColor();
           }
// </Snippet1>

            private void AddCustomDataTableStyle()
            {
                myDataGridTableStyle = new DataGridTableStyle();
                myDataGridTableStyle.MappingName ="Customers";
            }
            void SetUp()
            {
                MakeDataSet();
                // Bind the datagrid to the dataset.
                myDataGrid.SetDataBinding(myDataSet, "Customers");
                AddCustomDataTableStyle();
            }

            private void MakeDataSet()
            {
                // Create dataset.
                myDataSet = new DataSet("myDataSet");
                myDataTable = new DataTable("Customers");
                myDataColumn1 = new DataColumn("CustName");
                myDataTable.Columns.Add(myDataColumn1);

                // Add table to dataset.
                myDataSet.Tables.Add(myDataTable);
                DataRow newRow1;
                for(int i = 1; i < 4; i++)
                {
                    newRow1 = myDataTable.NewRow();
                    // Add the row to the customers table.
                    myDataTable.Rows.Add(newRow1);
                }
                myDataTable.Rows[0]["custName"] = "Alpha";
                myDataTable.Rows[1]["custName"] = "Beta";
                myDataTable.Rows[2]["custName"] = "Omega";
            }
        }
    }


