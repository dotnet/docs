using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void AddRelation() 
    {
        DataTable table = new DataTable();
        DataColumn column1 = table.Columns.Add("Column1");
        DataColumn column2 = table.Columns.Add("Column2");
        table.ChildRelations.Add("New Relation", column1, column2);
    }
    // </Snippet1>

}
