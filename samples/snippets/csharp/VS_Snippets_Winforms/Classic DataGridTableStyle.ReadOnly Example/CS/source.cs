using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
protected DataGrid dataGrid1;
protected DataSet myDataSet;
// <Snippet1>
private void PrintReadOnlyValues()
{
    foreach(DataGridTableStyle tableStyle in dataGrid1.TableStyles)
    {
      Console.WriteLine(tableStyle.ReadOnly);
    }
}

// </Snippet1>
}
