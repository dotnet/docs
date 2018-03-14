using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet dataSet1;
// <Snippet1>
private void SetReadOnly()
{
    DataColumnCollection myDataColumns;
    // Get the columns for a table bound to a DataGrid.
    myDataColumns = dataSet1.Tables["Suppliers"].Columns;
    foreach(DataColumn dataColumn in myDataColumns)
    {
        dataGrid1.TableStyles[0].GridColumnStyles[dataColumn.ColumnName].ReadOnly = dataColumn.ReadOnly;
    }
}
 
// </Snippet1>
}
