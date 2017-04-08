// System.Windows.Forms.GridColumnStylesCollection.ResetPropertyDescriptors()

/*
   The following program demonstrates the 'ResetPropertyDecriptors()'
   method of 'GridColumnStylesCollection' class. An instance of DataGrid is
   created and associate the data source to DataGrid. Then
   column styles are added to the data grid. A Reset button is
   provided to reset the property descriptors of the DataGrid
   columns.
*/


using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : Form
{
   private Container myComponents;
   private Button resetButton;
   private DataGrid myDataGrid;
   private DataSet myDataSet;

   public MyForm()
   {
      // Required for Windows Form Designer support.
      InitializeComponent();

      // Call MyDataSource to bind the controls.
      MyDataSource();
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      this.myComponents = new Container();
      this.Text = "DataGrid Control Sample";

      this.resetButton = new Button();
      resetButton.Location = new Point(24, 16);
      resetButton.Size = new Size(124, 30);
      resetButton.Text = "Reset Property Descriptor";
      resetButton.Click += new System.EventHandler(ResetButton_Click);

      this.myDataGrid = new DataGrid();
      myDataGrid.Location = new  Point(24, 50);
      myDataGrid.Size = new Size(300, 200);
      myDataGrid.CaptionText = "Microsoft DataGrid Control";

      this.Controls.Add(resetButton);
      this.Controls.Add(myDataGrid);
   }

   public static void Main()
   {
      Application.Run(new MyForm());
   }

   private void MyDataSource()
   {
      // Create a DataSet with one table
      MakeDataSet();
      // Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Customers");
   }

// <Snippet1>
   private void ResetButton_Click(object sender, EventArgs e)
   {
      DataGridTableStyle myTableStyle = myDataGrid.TableStyles[0];
      GridColumnStylesCollection myColumns= myTableStyle.GridColumnStyles;

      // Reset the property descriptor of column styles collection.
      myColumns.ResetPropertyDescriptors();
   }
// </Snippet1>


   private void AddCustomDataTableStyle()
   {
      // Get the currency manager for 'myDataSet' data source.
      CurrencyManager myCurrencyManger =
         (CurrencyManager)this.BindingContext[myDataSet];

      // Associate the 'DataGridTableStyle' to the 'myDataSet' data source.
      DataGridTableStyle myTableStyle = new DataGridTableStyle();
      myTableStyle.MappingName = "Customers";

      // Add style for 'Name' column.
      PropertyDescriptor pdName =
         myCurrencyManger.GetItemProperties()["CustName"];

      // Create an instance of 'DataGridColumnStyle'.
      DataGridColumnStyle myCustomerNameStyle =
         new DataGridTextBoxColumn(pdName);

      myCustomerNameStyle.MappingName = "custName";
      myCustomerNameStyle.HeaderText = "Customer Name";
      myTableStyle.GridColumnStyles.Add(myCustomerNameStyle);

      // Add style for 'Date' column.
      PropertyDescriptor myDateDescriptor =
         myCurrencyManger.GetItemProperties()["Date"];

      DataGridColumnStyle myDateStyle =
         new DataGridTextBoxColumn(myDateDescriptor,"G");

      myDateStyle.MappingName = "Date";
      myDateStyle.HeaderText = "Date";
      myDateStyle.Width = 150;
      myTableStyle.GridColumnStyles.Add(myDateStyle);

      // Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle);
   }

   private void MakeDataSet()
   {
      myDataSet = new DataSet("myDataSet");

      DataTable myCustomerTable = new DataTable("Customers");

      // Create two columns, and add them to the table.
      DataColumn myCustomerName = new DataColumn("CustName");
      DataColumn myDate = new DataColumn("Date",typeof(System.DateTime));
      myCustomerTable.Columns.Add(myCustomerName);
      myCustomerTable.Columns.Add(myDate);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomerTable);

      DataRow myNewRow;
      for(int i = 1; i < 3; i++)
      {
         myNewRow = myCustomerTable.NewRow();

         // Add the row to the Customers table.
         myCustomerTable.Rows.Add(myNewRow);
      }

      myCustomerTable.Rows[0]["custName"] = "Customer1";
      myCustomerTable.Rows[1]["custName"] = "Customer2";

      myCustomerTable.Rows[0]["Date"] = System.DateTime.Now;
      myCustomerTable.Rows[1]["Date"] = System.DateTime.Today;

      // Add column style collections.
      AddCustomDataTableStyle();
   }
}