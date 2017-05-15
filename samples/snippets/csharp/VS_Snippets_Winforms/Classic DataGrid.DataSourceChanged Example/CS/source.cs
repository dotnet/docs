using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
private System.Windows.Forms.DataGrid dataGrid1;
 
 private void CreateDataGrid()
 {
    dataGrid1 = new DataGrid();
    // Add the handler for the DataSourceChanged event.
    dataGrid1.DataSourceChanged += new EventHandler(DataGrid1_DataSourceChanged);
 
 }
 
 private void DataGrid1_DataSourceChanged(object sender, EventArgs e)
 {
    DataGrid thisGrid = (DataGrid) sender;
 }
    
// </Snippet1>
}
