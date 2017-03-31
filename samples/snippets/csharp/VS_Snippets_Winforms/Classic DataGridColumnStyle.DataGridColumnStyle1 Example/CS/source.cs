using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void CreateNewDataGridColumnStyle(){
  DataSet myDataSet = new DataSet("myDataSet");
   // Insert code to populate the DataSet.
    
   // Get the CurrencyManager for the table you want to add a column to.
  CurrencyManager myCurrencyManager = 
  (CurrencyManager)this.BindingContext[myDataSet, "Suppliers"];

  // Get the PropertyDescriptor for the DataColumn.
  PropertyDescriptor pd = myCurrencyManager.GetItemProperties()["City"];

   // Construct the DataGridColumnStyle with the PropertyDescriptor.
  DataGridColumnStyle myColumn = new DataGridTextBoxColumn(pd);
  myColumn.MappingName = "City";
  dataGrid1.TableStyles[0].GridColumnStyles.Add(myColumn);
}
// </Snippet1>
}
