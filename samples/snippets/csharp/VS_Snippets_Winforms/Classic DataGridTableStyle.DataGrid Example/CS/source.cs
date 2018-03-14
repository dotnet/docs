using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
protected DataGrid myDataGrid;
protected DataSet myDataSet;
// <Snippet1>
private void GetSelectedIndex(DataGridTableStyle myGridTable)
{
   /* Get the name of the DataGrid of the DataGridTable 
      passed as an argument. */
   Console.WriteLine(myGridTable.DataGrid.CurrentCell.ToString());
}

// </Snippet1>
}

