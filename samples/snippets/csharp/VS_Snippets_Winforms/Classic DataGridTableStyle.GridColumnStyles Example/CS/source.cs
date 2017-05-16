using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
protected DataGrid myDataGrid;
protected DataSet myDataSet;
// <Snippet1>
private void WriteMappingNames(){
    foreach(DataGridTableStyle dgt in myDataGrid.TableStyles)
    {
        Console.WriteLine(dgt.MappingName);
        foreach(DataGridColumnStyle dgc in dgt.GridColumnStyles)
        {
            Console.WriteLine(dgc.MappingName);
        }
    }
}
// </Snippet1>
}
