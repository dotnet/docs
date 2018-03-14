using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
protected DataGrid dataGrid1;
 
static void Main(){}
// <Snippet1>
private void AddDataGridBoolColumnStyle(){
   DataGridBoolColumn myColumn = new DataGridBoolColumn();
   myColumn.MappingName = "Current";
   myColumn.Width = 200;
   dataGrid1.TableStyles["Customers"].GridColumnStyles.Add(myColumn);
} 
// </Snippet1>
}
