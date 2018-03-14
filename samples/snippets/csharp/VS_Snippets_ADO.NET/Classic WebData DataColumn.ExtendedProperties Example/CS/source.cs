using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void SetProperty(DataColumn column)
    {
        column.ExtendedProperties.Add("TimeStamp", DateTime.Now);
    }
 
    private void GetProperty(DataColumn column)
    {
        Console.WriteLine(column.ExtendedProperties["TimeStamp"].ToString());
    }
    // </Snippet1>

}
