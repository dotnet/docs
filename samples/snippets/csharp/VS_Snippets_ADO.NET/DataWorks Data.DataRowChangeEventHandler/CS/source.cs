using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 private DataTable dataTable;
 
 private void AddHandler(){
    dataTable = new DataTable("dataTable");
    dataTable.RowChanged +=
       new System.Data.DataRowChangeEventHandler(dataTable_Changed);
 }
 
 private void dataTable_Changed(object sender,
 System.Data.DataRowChangeEventArgs e) 
 { 
    Console.WriteLine("Row Changed", e.Action,
       e.Row[dataGrid1.CurrentCell.ColumnNumber]);
 }
 // </Snippet1>

}
