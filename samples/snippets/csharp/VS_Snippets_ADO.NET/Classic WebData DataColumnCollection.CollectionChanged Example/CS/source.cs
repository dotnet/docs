using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddEventHandler(DataTable table)
    {
        DataColumnCollection columns = table.Columns;
        columns.CollectionChanged += new 
            System.ComponentModel.CollectionChangeEventHandler(
            ColumnsCollection_Changed);
    }
 
    private void ColumnsCollection_Changed(object sender, 
        System.ComponentModel.CollectionChangeEventArgs e)
    {
        DataColumnCollection columns = 
            (DataColumnCollection) sender;
        Console.WriteLine("ColumnsCollectionChanged: " 
            + columns.Count);
    }
    // </Snippet1>

}
