using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet ds;
// <Snippet1>
private void GetPropertyDescriptor()
{
    PropertyDescriptor pd;
    pd = dataGrid1.TableStyles[0].GridColumnStyles[0].PropertyDescriptor;
    Console.WriteLine(pd.ToString());
}
 
private void CreateNewDataGridColumnStyle()
{
    GridColumnStylesCollection myGridColumnCol;
    myGridColumnCol = dataGrid1.TableStyles[0].GridColumnStyles;
    // Get the CurrencyManager for the table you want to add a column to.
    CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[ds.Tables["Suppliers"]];
    // Get the PropertyDescriptor for the DataColumn of the new column.
    PropertyDescriptor pd = myCurrencyManager.GetItemProperties()["City"];
    DataGridColumnStyle myColumn = new DataGridTextBoxColumn(pd);
    myGridColumnCol.Add(myColumn);
 }

// </Snippet1>
}
