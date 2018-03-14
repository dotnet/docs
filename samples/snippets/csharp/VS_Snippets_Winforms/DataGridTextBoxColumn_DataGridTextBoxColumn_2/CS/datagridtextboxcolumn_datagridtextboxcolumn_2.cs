// System.Windows.Forms.DataGridTextBoxColumn.DataGridTextBoxColumn(PropertyDescriptor)
// System.Windows.Forms.DataGridTextBoxColumn.DataGridTextBoxColumn(PropertyDescriptor, string)

/*
   The following program demonstrates various constructors of
   'DataGridTextBoxColumn' class. An instance of 'DataGrid' class is constructed and
   it is associated with data source. When the button "Change Appearance" is clicked,
   the format of the Date column in the grid is modified to a specific format.
*/


using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class MyForm : Form
{
   private Container myComponents;
   private Button myButton;
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

      this.myButton = new Button();
      myButton.Location = new Point(24, 16);
      myButton.Size = new Size(124, 30);
      myButton.Text = "Change Appearance";
      myButton.Click+=new System.EventHandler(Button_Click);

      this.myDataGrid = new DataGrid();
      myDataGrid.Location = new  Point(24, 50);
      myDataGrid.Size = new Size(300, 200);
      myDataGrid.CaptionText = "Microsoft DataGrid Control";

      this.Controls.Add(myButton);
      this.Controls.Add(myDataGrid);
   }

   public static void Main()
   {
      Application.Run(new MyForm());
   }

   private void MyDataSource()
   {
      // Create a DataSet with one table
      CreateDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid.SetDataBinding(myDataSet, "Customers");
   }

   private void Button_Click(object sender, EventArgs e)
   {
      MyAddCustomDataTableStyle();
      myButton.Enabled = false;
   }

// <Snippet1>
// <Snippet2>

   private void MyAddCustomDataTableStyle()
   {
      // Get the currency manager for 'myDataSet'.
      CurrencyManager myCurrencyManger =
               (CurrencyManager)this.BindingContext[myDataSet];

      DataGridTableStyle myTableStyle = new DataGridTableStyle();
      myTableStyle.MappingName = "Customers";

      PropertyDescriptor proprtyDescriptorName =
               myCurrencyManger.GetItemProperties()["CustName"];

      DataGridColumnStyle myCustomerNameStyle =
               new DataGridTextBoxColumn(proprtyDescriptorName);

      myCustomerNameStyle.MappingName = "custName";
      myCustomerNameStyle.HeaderText = "Customer Name";
      myTableStyle.GridColumnStyles.Add(myCustomerNameStyle);

      // Add style for 'Date' column.
      PropertyDescriptor myDateDescriptor =
               myCurrencyManger.GetItemProperties()["Date"];
      // 'G' is for MM/dd/yyyy HH:mm:ss date format.
      DataGridColumnStyle myDateStyle =
               new DataGridTextBoxColumn(myDateDescriptor,"G");

      myDateStyle.MappingName = "Date";
      myDateStyle.HeaderText = "Date";
      myDateStyle.Width = 150;
      myTableStyle.GridColumnStyles.Add(myDateStyle);

      // Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle);
   }

// </Snippet2>
// </Snippet1>

   private void CreateDataSet()
   {
      // Create a DataSet.
      myDataSet = new DataSet("myDataSet");

      // Create an instance of 'DataTable'.
      DataTable myCustomerTable = new DataTable("Customers");

      // Create two columns, and add them to the table.
      DataColumn myCustomerName = new DataColumn("CustName");
      DataColumn myDate = new DataColumn("Date",typeof(System.DateTime));
      myCustomerTable.Columns.Add(myCustomerName);
      myCustomerTable.Columns.Add(myDate);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomerTable);

      // Create two customers in the Customers Table.
      DataRow myNewRow;
      for(int i = 1; i < 3; i++)
      {
         myNewRow = myCustomerTable.NewRow();

         // Add the row to the Customers table.
         myCustomerTable.Rows.Add(myNewRow);
      }

      // Populate customer name column.
      myCustomerTable.Rows[0]["custName"] = "Customer1";
      myCustomerTable.Rows[1]["custName"] = "Customer2";

      // Populate date column.
      myCustomerTable.Rows[0]["Date"] = System.DateTime.Now;
      myCustomerTable.Rows[1]["Date"] = System.DateTime.Today;

   }
}