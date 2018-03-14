using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void SetAllowNull(){
    DataGridBoolColumn myGridColumn = (DataGridBoolColumn)dataGrid1.TableStyles[0].GridColumnStyles[0];
    myGridColumn.AllowNull = false;
 }
 
// </Snippet1>
}
