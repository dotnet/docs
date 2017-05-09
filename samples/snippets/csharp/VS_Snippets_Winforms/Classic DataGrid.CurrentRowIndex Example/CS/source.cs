using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void GetSelectedIndex(DataGrid myGrid){
    Console.WriteLine(myGrid.CurrentRowIndex);
 }
 
 private void SetSelectedIndex(DataGrid myGrid, int selIndex){
    myGrid.CurrentRowIndex = selIndex;
 }
 
// </Snippet1>
}
