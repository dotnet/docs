   // System.Windows.Forms.DataGridColumnStyle.ReadOnlyChanged

   /*
     The following example demonstrates 'ReadOnlyChanged' Event of 'DataGridColumnStyle' class.
     It adds DataGrid and Button to a form. When user clicks on button the 'ReadOnly'  property of 'DataGridColumnStyle'
     is changed . This raises the 'ReadOnlyChanged' event which then calls the user defined EventHandler function .
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
         private Button myButton;
         
         private DataSet myDataSet;
         private DataGridTableStyle myDataGridTableStyle;
         private DataGridColumnStyle myDataGridColumnStyle;
         private DataTable myDataTable;
         private DataColumn myDataColumn1;

         public MyForm1()
         {
            InitializeComponent();
            SetUp();
         }

         private void InitializeComponent()
         {
            myDataGrid = new DataGrid();
            myDataGrid.Location = new Point(52, 32);
            myDataGrid.Size = new Size(115, 125);
            ClientSize = new Size(215, 273);
            myButton = new Button();
            myButton.Location = new Point(35, 210);
            myButton.Size = new Size(145, 24);
            myButton.Text = "Make column read only";
            myButton.Click += new EventHandler(Button_Click);

            Controls.AddRange(new Control[] {myDataGrid,myButton});
            Name = "MyForm1";
            Text = "DataGridColumnStyle";
         }

         static void Main() 
         {
            Application.Run(new MyForm1());
         }

// <Snippet1>
         private void Button_Click(Object sender, EventArgs e)
         { 
            if (myButton.Text == "Make column read/write")
            {
               myDataGridColumnStyle.ReadOnly = false;
               myButton.Text = "Make column read only";
            }
            else
            {
               myDataGridColumnStyle.ReadOnly = true;
               myButton.Text = "Make column read/write";
            }
         }

         private void AddCustomDataTableStyle()
         {
            myDataGridTableStyle = new DataGridTableStyle();
            myDataGridTableStyle.MappingName = "Customers";
            myDataGridColumnStyle = new DataGridTextBoxColumn();
            myDataGridColumnStyle.MappingName= "CustName";
            // Add EventHandler function for readonlychanged event.
            myDataGridColumnStyle.ReadOnlyChanged += new EventHandler(myDataGridColumnStyle_ReadOnlyChanged);
            myDataGridColumnStyle.HeaderText = "Customer";
            myDataGridTableStyle.GridColumnStyles.Add(myDataGridColumnStyle);
            // Add the 'DataGridTableStyle' instance to the 'DataGrid'.
            myDataGrid.TableStyles.Add(myDataGridTableStyle);
         }
         private void myDataGridColumnStyle_ReadOnlyChanged(Object sender, EventArgs e)
         {
            MessageBox.Show("'Readonly' property is changed");
         }
// </Snippet1>

         void SetUp()
         {
            MakeDataSet();
            myDataGrid.SetDataBinding(myDataSet, "Customers");
            AddCustomDataTableStyle();
         }

         private void MakeDataSet()
         {
            myDataSet = new DataSet("myDataSet");
            myDataTable = new DataTable("Customers");
            myDataColumn1 = new DataColumn("CustName");
            myDataTable.Columns.Add(myDataColumn1);
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
