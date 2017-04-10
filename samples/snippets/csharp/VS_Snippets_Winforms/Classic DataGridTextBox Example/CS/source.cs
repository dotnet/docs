using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
// <Snippet1>
private void GetDataGridTextBox()
{
   // Gets the DataGridTextBoxColumn from the DataGrid control.
   DataGridTextBoxColumn myTextBoxColumn;
   // Assumes the CompanyName column is a DataGridTextBoxColumn.
    myTextBoxColumn = (DataGridTextBoxColumn)dataGrid1.
   TableStyles[0].GridColumnStyles["CompanyName"];
   // Gets the DataGridTextBox for the column.
   DataGridTextBox myGridTextBox;
   myGridTextBox = (DataGridTextBox) myTextBoxColumn.TextBox;
}

// </Snippet1>
}
