using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void CreateRowsWithItemArray()
    {
        // Make a DataTable using the function below.
        DataTable dt = MakeTableWithAutoIncrement();
        DataRow relation;
        // Declare the array variable.
        object [] rowArray = new object[2];
        // Create 10 new rows and add to DataRowCollection.
        for(int i = 0; i <10; i++)
        {
            rowArray[0]=null;
            rowArray[1]= "item " + i;
            relation = dt.NewRow();
            relation.ItemArray = rowArray;
            dt.Rows.Add(relation);
        }
        PrintTable(dt);
    }
 
    private DataTable MakeTableWithAutoIncrement()
    {
        // Make a table with one AutoIncrement column.
        DataTable table = new DataTable("table");
        DataColumn idColumn = new DataColumn("id", 
            Type.GetType("System.Int32"));
        idColumn.AutoIncrement = true;
        idColumn.AutoIncrementSeed = 10;
        table.Columns.Add(idColumn);
    
        DataColumn firstNameColumn = new DataColumn("Item", 
            Type.GetType("System.String"));
        table.Columns.Add(firstNameColumn);
        return table;
    }
 
    private void PrintTable(DataTable table)
    {
        foreach(DataRow row in table.Rows)
        {
            foreach(DataColumn column in table.Columns)
            {
                Console.WriteLine(row[column]);
            }
        }
    }
    // </Snippet1>

}
