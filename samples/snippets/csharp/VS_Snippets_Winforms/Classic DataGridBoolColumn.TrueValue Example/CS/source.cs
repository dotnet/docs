using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid myDataGrid;
 protected DataSet DataSet1;
 static void Main(){}
// <Snippet1>
private void SetBoolColumnValues(){
   DataGridBoolColumn myGridColumn;
   // Get the DataGridBoolColumn you are setting.
   myGridColumn = (DataGridBoolColumn) myDataGrid.
   TableStyles["Customers"].GridColumnStyles["Current"];
   // Set TrueValue, FalseValue, and NullValue.
   myGridColumn.TrueValue = true;
   myGridColumn.FalseValue = false;
   myGridColumn.NullValue = Convert.DBNull;
}

 
// </Snippet1>
}
