// System.Windows.Forms.GridColumnStylesCollection.Clear
// System.Windows.Forms.GridColumnStylesCollection.Item [int index]
// System.Windows.Forms.GridColumnStylesCollection.Item [string columnName]

/*
  The following program demonstrates the Clear method , the Item[index] and Item[columnName]
  indexers for the 'GridColumnStylesCollection' class.
  In this program the user can add custom styles and clear them. The information on the styles
  is displayed depending on the option chosen by user.
*/

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

public class MyForm : System.Windows.Forms.Form
{
   private System.ComponentModel.Container components;
   private DataGrid myDataGrid;
   private DataSet myDataSet;
   private Label myLabel;
   private Button clearButton;
   private Button addStylesButton;
   private Button selectChoiceButton;
   private System.Windows.Forms.RadioButton columnNameRadioButton;
   private System.Windows.Forms.RadioButton indexRadioButton;
   private System.Windows.Forms.Label myLabel2;
   private bool TablesAlreadyAdded;
   public MyForm()
   {
      InitializeComponent();
      SetUp();
   }

   private void InitializeComponent()
   {
      // Create the form and its controls.
      components = new System.ComponentModel.Container();

      clearButton = new System.Windows.Forms.Button();
      addStylesButton = new System.Windows.Forms.Button();
      myDataGrid = new System.Windows.Forms.DataGrid();
      myLabel = new System.Windows.Forms.Label();
      selectChoiceButton = new System.Windows.Forms.Button();
      columnNameRadioButton = new System.Windows.Forms.RadioButton();
      indexRadioButton = new System.Windows.Forms.RadioButton();
      myLabel2 = new System.Windows.Forms.Label();

      clearButton.Location = new System.Drawing.Point(24, 16);
      clearButton.Name = "clearButton";
      clearButton.Size = new System.Drawing.Size(120, 24);
      clearButton.Text = "Clear Table Styles";
      clearButton.Click += new System.EventHandler(this.Clear_Clicked);

      addStylesButton.Location = new System.Drawing.Point(150, 16);
      addStylesButton.Name = "addStylesButton";
      addStylesButton.Size = new System.Drawing.Size(120, 24);
      addStylesButton.Text = "Add Custom Styles";
      addStylesButton.Click += new System.EventHandler(this.AddStyles_Clicked);

      myDataGrid.Location = new  Point(24, 50);
      myDataGrid.Size = new Size(300, 200);
      myDataGrid.CaptionText = "Microsoft DataGrid Control";

      myLabel.Location = new System.Drawing.Point(48, 328);
      myLabel.Name = "myLabel";
      myLabel.Size = new System.Drawing.Size(464, 90);
      myLabel.TabIndex = 7;
      myLabel.Text = "Message.";

      myLabel2.Location = new System.Drawing.Point(412, 24);
      myLabel2.Size = new System.Drawing.Size(100, 20);
      myLabel2.Text = "Print info using:";

      selectChoiceButton.Location = new System.Drawing.Point(276, 16);
      selectChoiceButton.Name = "selectChoiceButton";
      selectChoiceButton.Size = new System.Drawing.Size(120, 24);
      selectChoiceButton.Text = "Print Info";
      selectChoiceButton.Click += new System.EventHandler(this.SelectChoice_Clicked);

      columnNameRadioButton.Location = new System.Drawing.Point(432, 56);
      columnNameRadioButton.Name = "columnNameRadioButton";
      columnNameRadioButton.Text = "ColumnName";

      indexRadioButton.Location = new System.Drawing.Point(432, 88);
      indexRadioButton.Name = "indexRadioButton";
      indexRadioButton.Text = "Index";

      ClientSize = new System.Drawing.Size(600, 500);
      Name = "MyForm";
      Text = "DataGrid Control Sample";

      Controls.Add(clearButton);
      Controls.Add(addStylesButton);
      Controls.Add(selectChoiceButton);
      Controls.Add(myDataGrid);
      Controls.Add(columnNameRadioButton);
      Controls.Add(indexRadioButton);
      Controls.Add(myLabel);
      Controls.Add(myLabel2);
   }

   public static void Main()
   {
      Application.Run(new MyForm());
   }

   private void SetUp()
   {
      MakeDataSet();
      myDataGrid.SetDataBinding(myDataSet, "Customers");
   }

   // Create a DataSet with two tables and populate it.
   private void MakeDataSet()
   {
      myDataSet = new DataSet("myDataSet");

      DataTable customerTable = new DataTable("Customers");
      DataTable ordersTable = new DataTable("Orders");

      // Create two columns, add them to the first table.
      DataColumn customerID = new DataColumn("CustID", typeof(int));
      DataColumn customerName = new DataColumn("CustName");
      DataColumn current = new DataColumn("Current", typeof(bool));
      customerTable.Columns.Add(customerID);
      customerTable.Columns.Add(customerName);
      customerTable.Columns.Add(current);

      // Create three columns, add them to the second table.
      DataColumn customerID2 = new DataColumn("CustID", typeof(int));
      DataColumn orderDate = new DataColumn("OrderDate",typeof(DateTime));
      DataColumn orderAmount = new DataColumn("OrderAmount", typeof(decimal));
      ordersTable.Columns.Add(orderAmount);
      ordersTable.Columns.Add(customerID2);
      ordersTable.Columns.Add(orderDate);

      // Add the tables to the DataSet.
      myDataSet.Tables.Add(customerTable);
      myDataSet.Tables.Add(ordersTable);

      // Create a DataRelation, add it to the DataSet.
      DataRelation myDataRelation = new DataRelation
         ("custToOrders", customerID , customerID2);
      myDataSet.Relations.Add(myDataRelation);

      DataRow newRow1;
      DataRow newRow2;

      // Create three customers in the Customers Table.
      for(int index = 1; index < 5; index++)
      {
         newRow1 = customerTable.NewRow();
         newRow1["CustID"] = index;
         newRow1["CustName"] = "Item" + index.ToString();
         newRow1["Current"] = true;
         // Add the row to the Customers table.
         customerTable.Rows.Add(newRow1);
      }

      // For each customer, create five rows in the Orders table.
      for(int index = 1; index < 5; index++)
      {
         for(int j = 1; j < 6; j++)
         {
            newRow2 = ordersTable.NewRow();
            newRow2["CustID"]= index;
            newRow2["OrderDate"]= new DateTime(2001, index, j * 2);
            newRow2["OrderAmount"] = index * 10 + j  * .1;
            // Add the row to the Orders table.
            ordersTable.Rows.Add(newRow2);
         }
      }
   }

   private void AddStyles_Clicked(object sender, System.EventArgs e)
   {
      myLabel.Text = "Styles added to the grid.";
      if(TablesAlreadyAdded) return;
      AddCustomDataTableStyle();
   }

   private void AddCustomDataTableStyle()
   {
      DataGridTableStyle tableStyle1 = new DataGridTableStyle();
      tableStyle1.MappingName = "Customers";
      // Set other properties.
      tableStyle1.AlternatingBackColor = Color.LightGray;

      // Add a second column style.
      DataGridColumnStyle textBoxColumnStyle = new DataGridTextBoxColumn();
      textBoxColumnStyle.MappingName = "CustName";
      textBoxColumnStyle.HeaderText = "Customer Name";
      textBoxColumnStyle.Width = 100;
      tableStyle1.GridColumnStyles.Add(textBoxColumnStyle);

      // Add a GridColumnStyle and set its MappingName to the name of a DataColumn in the DataTable.
      DataGridColumnStyle gridColumnStyle = new DataGridBoolColumn();
      gridColumnStyle.MappingName = "Current";

      // Set the HeaderText and Width properties.
      gridColumnStyle.HeaderText = "IsCurrent Customer";
      gridColumnStyle.Width = 125;
      tableStyle1.GridColumnStyles.Add(gridColumnStyle);

      // Create the second table style with columns.
      DataGridTableStyle tableStyle2 = new DataGridTableStyle();
      tableStyle2.MappingName = "Orders";

      // Set other properties.
      tableStyle2.AlternatingBackColor = Color.LightBlue;

      // Create new ColumnStyle object.
      DataGridColumnStyle orderDate = new DataGridTextBoxColumn();
      orderDate.MappingName = "OrderDate";
      orderDate.HeaderText = "Order Date";
      orderDate.Width = 100;
      tableStyle2.GridColumnStyles.Add(orderDate);

      // Create a formatted column using a PropertyDescriptor.
      PropertyDescriptorCollection pcol = this.BindingContext
         [myDataSet, "Customers.custToOrders"].GetItemProperties();

      DataGridColumnStyle csOrderAmount =
         new DataGridTextBoxColumn(pcol["OrderAmount"], "c", true);
      csOrderAmount.MappingName = "OrderAmount";
      csOrderAmount.HeaderText = "Total";
      csOrderAmount.Width = 100;
      tableStyle2.GridColumnStyles.Add(csOrderAmount);

      // Add the DataGridTableStyle objects to the GridTableStylesCollection.
      myDataGrid.TableStyles.Add(tableStyle1);
      myDataGrid.TableStyles.Add(tableStyle2);

      // Set the TablesAlreadyAdded to true so we don't try to do this again.
      TablesAlreadyAdded=true;
   }

   private void SelectChoice_Clicked(object sender, System.EventArgs e)
   {
      if(columnNameRadioButton.Checked)
         PrintColumnInformationUsingColumnName();
      else if(indexRadioButton.Checked)
         PrintColumnInformationUsingIndex();
   }

// <Snippet1>
   private void Clear_Clicked(object sender, System.EventArgs e)
   {
      // TablesAlreadyAdded set to false so that table styles can be added again.
      TablesAlreadyAdded = false;
      myLabel.Text = "All Table Styles Cleared.";
      // Clear all the column styles and also table style for the grid.
      foreach (DataGridTableStyle myTableStyle in myDataGrid.TableStyles)
      {
         GridColumnStylesCollection myColumns = myTableStyle.GridColumnStyles;
         myColumns.Clear();
      }
      myDataGrid.TableStyles.Clear();
   }
// </Snippet1>

// <Snippet2>
   private void PrintColumnInformationUsingColumnName()
   {
      myLabel.Text = "Table Styles info: No of Styles " + myDataGrid.TableStyles.Count;
      foreach (DataGridTableStyle myTableStyle in myDataGrid.TableStyles)
      {
         myLabel.Text += "\nTable Name : " + myTableStyle.MappingName;
         GridColumnStylesCollection myColumns = myTableStyle.GridColumnStyles;
         // 'myTableStyle.GridColumnStyles[index].MappingName' specifies the column came for the table.
         for(int index=0;index < myColumns.Count;index++)
            myLabel.Text +=  "\nMapping Name: " +
               myColumns[myTableStyle.GridColumnStyles[index].MappingName].MappingName;
      }
   }
// </Snippet2>

// <Snippet3>
   private void PrintColumnInformationUsingIndex()
   {
      myLabel.Text = "Table Styles info: No of Styles " + myDataGrid.TableStyles.Count;
      foreach (DataGridTableStyle myTableStyle in myDataGrid.TableStyles)
      {
         myLabel.Text += "\nTable Name : " + myTableStyle.MappingName;
         GridColumnStylesCollection myColumns = myTableStyle.GridColumnStyles;
         for(int index=0;index < myColumns.Count;index++)
            myLabel.Text +=  "\nMapping Name: " + myColumns[index].MappingName;
      }
   }
// </Snippet3>
}