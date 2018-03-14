using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
private void CopyDataTable(DataTable table){
    // Create an object variable for the copy.
    DataTable copyDataTable;
    copyDataTable = table.Copy();

    // Insert code to work with the copy.
 }
// </Snippet1>

}
