using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void PrintName(DataRelation relation)
    {
        // Print the name of the DataRelation.
        Console.WriteLine(relation.ToString());
    }
    // </Snippet1>

}
