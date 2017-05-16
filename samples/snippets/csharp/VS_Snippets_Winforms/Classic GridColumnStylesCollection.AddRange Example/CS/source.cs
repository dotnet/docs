using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 
// <Snippet1>
private void AddStyleRange()
{
   // Create two DataGridColumnStyle objects.
   DataGridColumnStyle col1 = new DataGridTextBoxColumn();
   col1.MappingName = "FirstName";
   DataGridColumnStyle col2 = new DataGridBoolColumn();
   col2.MappingName = "Current";


   // Create an array and use AddRange to add to collection.
   DataGridColumnStyle[] cols = new DataGridColumnStyle[2] {col1, col2};
   dataGrid1.TableStyles[0].GridColumnStyles.AddRange(cols);
}
// </Snippet1>
}
