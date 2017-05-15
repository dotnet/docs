// System.Windows.Forms.GridColumnStylesCollection.RemoveAt

/*
   The following program demonstrates the 'RemoveAt(int)' method of
   'GridColumnStylesCollection' class. An instance of DataGrid is created
   by associating the DataGrid with a data source and column style
   collections are added to it. A Remove button is provided to delete the
   CustomerName column style collection.
*/

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

public class MyForm : Form
{
   private Container components;
   private DataGrid myDataGrid;
   private DataSet myDataSet;
   private Button removeStyle;
   private GridColumnStylesCollection myColumns;

   public MyForm()
   {
      InitializeComponent();
      SetUp();
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      components = new Container();
      myDataGrid = new DataGrid();
      removeStyle = new Button();


      // Set the myDataGrid properties.
      myDataGrid.Location = new  Point(24, 50);
      myDataGrid.Size = new Size(300, 200);
      myDataGrid.CaptionText = "Microsoft DataGrid Control";

      // Set the removeStyle properties.
      removeStyle.Location = new Point(276, 16);
      removeStyle.Name = "removeStyle";
      removeStyle.Size = new Size(120, 24);
      removeStyle.Text = "Remove";
      removeStyle.Click +=
         new System.EventHandler(this.RemoveColumnStyle_Clicked);


      ClientSize = new Size(600, 500);
      Name = "GridColumnStylesCollection_RemoveAt";
      Text = "DataGrid Control Sample";

      // Add the controls to the form.
      Controls.Add(removeStyle);
      Controls.Add(myDataGrid);
   }

   public static void Main()
   {
      Application.Run(new MyForm());
   }

   private void SetUp()
   {
      // Create the data source.
      MakeDataSet();

      // Associate the data set.
      myDataGrid.SetDataBinding(myDataSet, "Customers");
   }

   // Create a DataSet with two tables and populate it.
   private void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = new DataSet("myDataSet");

      // Create two DataTables.
      DataTable myCustomer = new DataTable("Customers");
      DataTable myOrders = new DataTable("Orders");

      // Create two columns, and add them to the first table.
      DataColumn myCustomerID = new DataColumn("CustID", typeof(int));
      DataColumn myCustomerName = new DataColumn("CustName");
      DataColumn myCurrent = new DataColumn("Current", typeof(bool));
      myCustomer.Columns.Add(myCustomerID);
      myCustomer.Columns.Add(myCustomerName);
      myCustomer.Columns.Add(myCurrent);

      // Create three columns, and add them to the second table.
      DataColumn myID = new DataColumn("CustID", typeof(int));
      DataColumn myOrderDate = new DataColumn("OrderDate",typeof(DateTime));
      DataColumn myOrderAmount = new DataColumn("OrderAmount", typeof(decimal));
      myOrders.Columns.Add(myOrderAmount);
      myOrders.Columns.Add(myID);
      myOrders.Columns.Add(myOrderDate);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(myCustomer);
      myDataSet.Tables.Add(myOrders);

      // Create a DataRelation, and add it to the DataSet.
      DataRelation myDataRelation =
         new DataRelation("custToOrders", myCustomerID , myID);
      myDataSet.Relations.Add(myDataRelation);

      DataRow myNewRow1;
      DataRow myNewRow2;

      // Create three customers in the Customers Table.
      for(int i = 1; i < 5; i++)
      {
         myNewRow1 = myCustomer.NewRow();
         myNewRow1["CustID"] = i;
         myNewRow1["CustName"] = "Item" + i.ToString();
         myNewRow1["Current"] = true;

         // Add the row to the Customers table.
         myCustomer.Rows.Add(myNewRow1);
      }

      // For each customer, create five rows in the Orders table.
      for(int i = 1; i < 5; i++)
      {
         for(int j = 1; j < 6; j++)
         {
            myNewRow2 = myOrders.NewRow();
            myNewRow2["CustID"]= i;
            myNewRow2["OrderDate"]= new DateTime(2001, i, j * 2);
            myNewRow2["OrderAmount"] = i * 10 + j  * .1;

            // Add the row to the Orders table.
            myOrders.Rows.Add(myNewRow2);
         }
      }
      // Add column styles collection.
      AddCustomDataTableStyle();
   }


   private void AddCustomDataTableStyle()
   {
      // Create a 'DataGridTableStyle'.
      DataGridTableStyle myTableStyle1 = new DataGridTableStyle();

      // Map the table style.
      myTableStyle1.MappingName = "Customers";
      myTableStyle1.AlternatingBackColor = Color.LightGray;

      // Add a Name column style.
      DataGridColumnStyle myTextCol = new DataGridTextBoxColumn();
      myTextCol.MappingName = "CustName";
      myTextCol.HeaderText = "Customer Name";
      myTextCol.Width = 100;
      myTableStyle1.GridColumnStyles.Add(myTextCol);

      // Add a Current column style.
      DataGridColumnStyle myBoolCol = new DataGridBoolColumn();
      myBoolCol.MappingName = "Current";
      myBoolCol.HeaderText = "IsCurrent Customer";
      myBoolCol.Width = 125;
      myTableStyle1.GridColumnStyles.Add(myBoolCol);

      // Create the second table style with columns.
      DataGridTableStyle myTableStyle2 = new DataGridTableStyle();
      myTableStyle2.MappingName = "Orders";
      myTableStyle2.AlternatingBackColor = Color.LightBlue;

      // Create Order Date Column Style.
      DataGridColumnStyle myOrderDate = new DataGridTextBoxColumn();
      myOrderDate.MappingName = "OrderDate";
      myOrderDate.HeaderText = "Order Date";
      myOrderDate.Width = 100;
      myTableStyle2.GridColumnStyles.Add(myOrderDate);

      // Get the PropertyDescriptor of data set.
      PropertyDescriptorCollection myPCol = this.BindingContext
         [myDataSet, "Customers.custToOrders"].GetItemProperties();

      // Create the Order Amount Column style.
      DataGridColumnStyle myOrderAmount =
         new DataGridTextBoxColumn(myPCol["OrderAmount"], "c", true);
      myOrderAmount.MappingName = "OrderAmount";
      myOrderAmount.HeaderText = "Total";
      myOrderAmount.Width = 100;
      myTableStyle2.GridColumnStyles.Add(myOrderAmount);

      // Add the DataGridTableStyle objects to the GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle1);
      myDataGrid.TableStyles.Add(myTableStyle2);
   }
// <Snippet1>
   private void RemoveColumnStyle_Clicked(object sender, EventArgs e)
   {
      DataGridTableStyle myTableStyle = myDataGrid.TableStyles[0];

      // Get the GridColumnStylesCollection of Data Grid.
      myColumns = myTableStyle.GridColumnStyles;
      int i;

      // Remove the CustName ColumnStyle from the data grid.
      if(myColumns.Contains("CustName"))
      {
         DataGridColumnStyle myDataColumnStyle= myColumns["CustName"];
         i= myColumns.IndexOf(myDataColumnStyle);
         myColumns.RemoveAt(i);
      }
   }
// </Snippet1>
}