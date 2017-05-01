   // System.Windows.Forms.DataGridTableStyle.ResetBackColor

   /*
      The following example demonstrates the 'ResetBackColor' method of 'DataGridTableStyle' class. 
      A  DataGrid and  a button are added to 'Form'. The initial back color of the DataGridTableStyle is set to
      pink. When the user clicks on 'ResetBackColor' button, then the value of DataGridBackColor is set to its 
      default value.
   */

   using System;
   using System.Drawing;
   using System.Collections;
   using System.Windows.Forms;
   using System.Data;

   public class MyForm : Form
   {
         private DataGrid myDataGrid;
         private Button myButton1;
         private DataSet myDataSet;
         private DataGridTableStyle myTableStyle;
         private DataGridColumnStyle myColumnStyle;
   
         public MyForm()
         {
            InitializeComponent();
            // Create a DataSet with a table.
            MakeDataSet();
            // Bind the DataGrid to the DataSet.
            myDataGrid.SetDataBinding(myDataSet, "customerTable");
            AddCustomColumnStyle();
         }

         // Initialilze form and its controls.
         private void InitializeComponent()
         {
            myDataGrid = new DataGrid();
            myTableStyle = new DataGridTableStyle();
            myColumnStyle = new DataGridTextBoxColumn();
            myButton1 = new Button();
            
            myDataGrid.Location = new Point(24, 24);
            myDataGrid.Name = "myDataGrid";
            myDataGrid.CaptionText = "DataGridColumn ";
            myDataGrid.Size = new Size(150,153);
            myDataGrid.TabIndex   =0;

            myButton1.Location = new Point(16, 184);
            myButton1.Name = "myButton1";
            myButton1.Size = new Size(112, 23);
            myButton1.TabIndex = 1;

            myButton1.Text = "Reset BackColor";
            myButton1.Click+=new EventHandler(myButton1_Click);
            ClientSize =   new Size(360, 273);
            Controls.AddRange(new Control[] {myButton1,myDataGrid});

            Name = "Form1";
            Text = "Reset BackColor";
            ResumeLayout(false);
         }

// <Snippet1>
         private void AddCustomColumnStyle()
         {
            // Set the TableStyle Mapping name.
            myTableStyle.MappingName = "customerTable";
            myTableStyle.BackColor = Color.Pink;

            // Set the ColumnStyle properties and add to TableStyle.
            myColumnStyle.MappingName = "Customers";
            myColumnStyle.HeaderText = "Customer Name";
            myColumnStyle.Width = 250;
            myTableStyle.GridColumnStyles.Add(myColumnStyle);
            myDataGrid.TableStyles.Add(myTableStyle);
         }

         private void myButton1_Click(object sender, EventArgs e)
         {
            // Reset the background color.
            myTableStyle.ResetBackColor();
         }
// </Snippet1>


         static void Main() 
         {
            Application.Run(new MyForm());
         }


         private void MakeDataSet()
         {
            myDataSet = new DataSet("myDataSet");
            DataTable customerTable = new DataTable("customerTable");
            DataColumn customerName = new DataColumn("Customers");
            customerTable.Columns.Add(customerName);
            myDataSet.Tables.Add(customerTable);
            DataRow newRow1;
            for(int i = 1; i < 6; i++)
            {
               newRow1 = customerTable.NewRow();
               newRow1["Customers"] = i;

               // Add the row to the Customers table.
               customerTable.Rows.Add(newRow1);
            }
            customerTable.Rows[0]["Customers"] = "Alpha";
            customerTable.Rows[1]["Customers"] = "Beta";
            customerTable.Rows[2]["Customers"] = "Omega";
            customerTable.Rows[3]["Customers"] = "Cust1";
            customerTable.Rows[4]["Customers"] = "Cust2";
         }
  }
