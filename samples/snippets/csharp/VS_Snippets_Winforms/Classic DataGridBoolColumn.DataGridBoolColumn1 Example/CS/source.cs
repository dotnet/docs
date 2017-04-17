using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet ds;
// <snippet1>
private void CreateNewDataGridColumn(){
   System.Windows.Forms.GridColumnStylesCollection myGridColumnCol;
   myGridColumnCol = dataGrid1.TableStyles[0].GridColumnStyles;
   // Get the CurrencyManager for the table.
   CurrencyManager myCurrencyManager = 
   (CurrencyManager)this.BindingContext[ds.Tables["Products"]];
   /* Get the PropertyDescriptor for the DataColumn of the new column.
   The column should contain a Boolean value. */
   PropertyDescriptor pd = myCurrencyManager.
   GetItemProperties()["Discontinued"];
   DataGridColumnStyle myColumn = 
   new System.Windows.Forms.DataGridBoolColumn(pd);
   myColumn.MappingName = "Discontinued";
   myGridColumnCol.Add(myColumn);
}
// </snippet1>
}
