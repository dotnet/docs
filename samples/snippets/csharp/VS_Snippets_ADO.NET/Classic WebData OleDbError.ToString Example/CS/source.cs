using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 public void DisplayOleDbErrors(OleDbException exception) 
 {
    for (int i=0; i < exception.Errors.Count; i++)
    {
       MessageBox.Show("Index #" + i + "\n" +
            "Error: " + exception.Errors[i].ToString() + "\n");
    }
 }
// </Snippet1>

}
