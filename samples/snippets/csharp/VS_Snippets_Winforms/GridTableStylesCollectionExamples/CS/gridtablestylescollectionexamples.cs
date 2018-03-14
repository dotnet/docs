using System;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Windows.Forms;


public class DataGridTableStuff:Form
{

private DataGrid myDataGrid;
private DataSet myDataSet;

public static void Main()

{
   DataGridTableStuff dg = new DataGridTableStuff();
   
}

private void SetUp()
{
   myDataSet = new DataSet("myDataSet");
    myDataGrid = new DataGrid();
}  

//<snippet1>
private void AddCustomDataTableStyle(){
   DataGridTableStyle ts1 = new DataGridTableStyle();
   ts1.MappingName = "Customers";
   // Set other properties.
   ts1.AlternatingBackColor = Color.LightGray;

   /* Add a GridColumnStyle and set its MappingName 
   to the name of a DataColumn in the DataTable. 
   Set the HeaderText and Width properties. */
   
   DataGridColumnStyle boolCol = new DataGridBoolColumn();
   boolCol.MappingName = "Current";
   boolCol.HeaderText = "IsCurrent Customer";
   boolCol.Width = 150;
   ts1.GridColumnStyles.Add(boolCol);
   
   // Add a second column style.
   DataGridColumnStyle TextCol = new DataGridTextBoxColumn();
   TextCol.MappingName = "custName";
   TextCol.HeaderText = "Customer Name";
   TextCol.Width = 250;
   ts1.GridColumnStyles.Add(TextCol);

   // Create the second table style with columns.
   DataGridTableStyle ts2 = new DataGridTableStyle();
   ts2.MappingName = "Orders";

   // Set other properties.
   ts2.AlternatingBackColor = Color.LightBlue;
   
   // Create new ColumnStyle objects.
   DataGridColumnStyle cOrderDate = 
   new DataGridTextBoxColumn();
   cOrderDate.MappingName = "OrderDate";
   cOrderDate.HeaderText = "Order Date";
   cOrderDate.Width = 100;
   ts2.GridColumnStyles.Add(cOrderDate);

   /*Use a PropertyDescriptor to create a formatted
   column. First get the PropertyDescriptorCollection
   for the data source and data member. */
   System.ComponentModel.PropertyDescriptorCollection pcol = 
      this.BindingContext[myDataSet, "Customers.custToOrders"]
      .GetItemProperties();
 
   /* Create a formatted column using a PropertyDescriptor.
   The formatting character "c" specifies a currency format. */     
   DataGridColumnStyle csOrderAmount = 
   new DataGridTextBoxColumn(pcol["OrderAmount"], "c", true);
   csOrderAmount.MappingName = "OrderAmount";
   csOrderAmount.HeaderText = "Total";
   csOrderAmount.Width = 100;
   ts2.GridColumnStyles.Add(csOrderAmount);

   /* Add the DataGridTableStyle instances to 
   the GridTableStylesCollection. */
   myDataGrid.TableStyles.Add(ts1);
   myDataGrid.TableStyles.Add(ts2);
}
  //</snippet1>

  //<snippet2>
   private void GetGridTableByIndex()
   {
      DataGridTableStyle myGridStyle = 
      myDataGrid.TableStyles[0] ;
      Console.WriteLine(myGridStyle.MappingName);
   }
   //</snippet2>

  //<snippet3>
   private void GetGridTableByName()
   {
      DataGridTableStyle myGridStyle = 
      myDataGrid.TableStyles["customers"] ;
      Console.WriteLine(myGridStyle.MappingName);
   }
   //</snippet3>

   //<snippet4>
   private void AddDataGridTableStyle()
   {
      // Create a new DataGridTableStyle and set MappingName.
      DataGridTableStyle myGridStyle = 
      new DataGridTableStyle();
      myGridStyle.MappingName = "Customers";

      // Create two DataGridColumnStyle objects.
      DataGridColumnStyle colStyle1 =
      new DataGridTextBoxColumn();
      colStyle1.MappingName = "firstName";
      
      DataGridColumnStyle colStyle2 =
      new DataGridBoolColumn();
      colStyle2.MappingName = "Current";

      // Add column styles to table style.
      myGridStyle.GridColumnStyles.Add(colStyle1);
      myGridStyle.GridColumnStyles.Add(colStyle2);   

      // Add the grid style to the GridStylesCollection.
      myDataGrid.TableStyles.Add(myGridStyle);
   }
   //</snippet4>


   //<snippet5>
   private void AddArray()
   {
   

   /* Get three CurrencyManager objects used to construct 
   DataGridTableSTyle objects. */
   CurrencyManager customersManager = (CurrencyManager)
   this.BindingContext[myDataSet, "Customers"];

   CurrencyManager regionsManager = (CurrencyManager)
   this.BindingContext[myDataSet, "Customers"];

   CurrencyManager productsManager = (CurrencyManager)
   this.BindingContext[myDataSet, "Customers"];


   DataGridTableStyle gridCustomers = 
   new DataGridTableStyle(customersManager);
   DataGridTableStyle gridRegions = 
   new DataGridTableStyle(regionsManager);
   DataGridTableStyle gridProducts = 
   new DataGridTableStyle(productsManager);

   // Create a DataGridTableStyle array.
   DataGridTableStyle[] myGrids = {gridCustomers, gridRegions, gridProducts};

   // Use AddRange to add to the collection.
   myDataGrid.TableStyles.AddRange(myGrids);

   }
   //</snippet5>

   //<snippet6>
   private void TestContains()
   {
      bool isContained;
      isContained = myDataGrid.TableStyles.Contains("Customers");
      Console.WriteLine(isContained);
   }
   //</snippet6>

}


