// System.Windows.Forms.DataGridColumnStyle.NullTextChanged

   /*
     The following example demonstrates the 'NullTextChanged' event of 'DataGridColumnStyle' class.
     It adds  a DataGrid and a Button.to a 'Form'. When user clicks the 'Delete Column values' button, 
     the column becomes empty and  'NullTextChanged' event is raised  which is handled by event handler
     function.
   */

      using System;
      using System.Drawing;
      using System.Collections;
      using System.Windows.Forms;
      using System.Data;

      public class MyForm : Form
      {
            private DataGrid myDataGrid;
            private Button myButton;
            private DataSet myDataSet;
            private DataGridTableStyle myTableStyle;
            private DataGridCell myCell;
            private DataGridColumnStyle myColumnStyle;
            private CurrencyManager myCurrencyManager;
            public int myRowcount;
            public MyForm() 
            {
               InitializeComponent();
               MakeDataSet();
               myDataGrid.SetDataBinding(myDataSet, "CustTable"); 
               myCurrencyManager = (CurrencyManager)this.BindingContext[myDataSet, "CustTable"];
            }
            private void InitializeComponent()
            {
               myDataGrid = new DataGrid();
             
               myCell = new DataGridCell();
               myButton = new Button(); 
               
               myDataGrid.Location   = new Point(24, 24);
               myDataGrid.Name = "myDataGrid";
               myDataGrid.CaptionText   = "DataGridColumn ";
               myDataGrid.Size = new Size(130,93);
               
               
               myButton.Location =   new Point(60,208);
               myButton.Size = new Size(130, 20);
               myButton.Text  = "Delete Column Values";
               myButton.Click += new EventHandler(button_Click);
               
               ClientSize =   new Size(360, 273);
               Controls.AddRange(new Control[] {myButton,myDataGrid});
               Text =   "NullTextChanged ";
            }
            

            static void Main() 
            {
               Application.Run(new MyForm());
            }
           
            private void MakeDataSet()
            {
               myDataSet = new DataSet("myDataSet");
               DataTable custTable = new DataTable("CustTable");
               DataColumn custName = new DataColumn("Customers");
               custTable.Columns.Add(custName);
               // Add the tables to the DataSet.
               myDataSet.Tables.Add(custTable);
               // Create a DataRow variable.
               DataRow newRow1;
               for(int i = 1; i < 4; i++)
               {
                  newRow1 = custTable.NewRow();
                  newRow1["Customers"] = i;
                  // Add the row to the Customers table.
                  custTable.Rows.Add(newRow1);
               }
               // Give each customer a distinct name.
               custTable.Rows[0]["Customers"] = "Alpha";
               custTable.Rows[1]["Customers"] = "Beta";
               custTable.Rows[2]["Customers"] = "Omega";
               AddCustomColumnStyle();
            }
// <Snippet1>
         private void AddCustomColumnStyle()
         {
            myTableStyle = new DataGridTableStyle();
            myColumnStyle = new DataGridTextBoxColumn();
            myColumnStyle.NullTextChanged += new EventHandler(columnStyle_NullTextChanged);
            myTableStyle.GridColumnStyles.Add(myColumnStyle);
            myDataGrid.TableStyles.Add(myTableStyle);
 
         }
         // NullTextChanged event handler of DataGridColumnStyle.
         private void columnStyle_NullTextChanged(object sender, EventArgs e)
         {
            for(int i=0;i<myRowcount;i++)
            {
               myCell.RowNumber = i;
               myDataGrid[myCell] = null;
            }
            MessageBox.Show("NullTextChanged Event is handled");
         }
// </Snippet1>
         private void button_Click(object sender, EventArgs e)
         {  
            myRowcount = myCurrencyManager.Count;
            // Set the column to null reference.
            for(int i=0;i<myRowcount;i++)
            {
               myCell.RowNumber = i;
               myDataGrid[myCell]="";
            }
            myColumnStyle.NullText = null;
         }

}
