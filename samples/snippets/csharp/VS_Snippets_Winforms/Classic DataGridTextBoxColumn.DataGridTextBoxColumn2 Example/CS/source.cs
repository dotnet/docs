using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;

class Form1: Form
{

DataGrid dataGrid1 = new DataGrid();
// <Snippet1>
private void AddColumn(DataTable myTable){
    // Add a new DataColumn to the DataTable.
    DataColumn myColumn = new DataColumn("myTextBoxColumn");
    myColumn.DataType = typeof(String);
    myColumn.DefaultValue="default string";
    myTable.Columns.Add(myColumn);
    // Get the ListManager for the DataTable.
    CurrencyManager cm = (CurrencyManager)this.BindingContext[myTable];
    // Use the ListManager to get the PropertyDescriptor for the new column.
    PropertyDescriptor pd = cm.GetItemProperties()["myTextBoxColumn"];
    // Create a new DataTimeFormat object.
    DateTimeFormatInfo fmt = new DateTimeFormatInfo();
    // Insert code to set format.
    DataGridTextBoxColumn myColumnTextColumn;
    // Create the DataGridTextBoxColumn with the PropertyDescriptor and Format.
    myColumnTextColumn = new DataGridTextBoxColumn(pd, fmt.SortableDateTimePattern);
    // Add the new DataGridColumnStyle to the GridColumnsCollection.
    dataGrid1.TableStyles[0].GridColumnStyles.Add(myColumnTextColumn);
 }

// </Snippet1>
}
