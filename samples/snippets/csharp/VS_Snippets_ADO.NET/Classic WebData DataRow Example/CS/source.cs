using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;

    // <Snippet1>
    private void CreateNewDataRow()
    {
        // Use the MakeTable function below to create a new table.
        DataTable table;
        table = MakeNamesTable();

        // Once a table has been created, use the 
        // NewRow to create a DataRow.
        DataRow row;
        row = table.NewRow();

        // Then add the new row to the collection.
        row["fName"] = "John";
        row["lName"] = "Smith";
        table.Rows.Add(row);
    
        foreach(DataColumn column in table.Columns)
            Console.WriteLine(column.ColumnName);
        dataGrid1.DataSource=table;
    }
 
    private DataTable MakeNamesTable()
    {
        // Create a new DataTable titled 'Names.'
        DataTable namesTable = new DataTable("Names"); 

        // Add three column objects to the table.
        DataColumn idColumn = new  DataColumn();
        idColumn.DataType = System.Type.GetType("System.Int32");
        idColumn.ColumnName = "id";
        idColumn.AutoIncrement = true;
        namesTable.Columns.Add(idColumn);

        DataColumn fNameColumn = new DataColumn();
        fNameColumn.DataType = System.Type.GetType("System.String");
        fNameColumn.ColumnName = "Fname";
        fNameColumn.DefaultValue = "Fname";
        namesTable.Columns.Add(fNameColumn);

        DataColumn lNameColumn = new DataColumn();
        lNameColumn.DataType = System.Type.GetType("System.String");
        lNameColumn.ColumnName = "LName";
        namesTable.Columns.Add(lNameColumn);

        // Create an array for DataColumn objects.
        DataColumn [] keys = new DataColumn [1];
        keys[0] = idColumn;
        namesTable.PrimaryKey = keys;

        // Return the new DataTable.
        return namesTable;
    }
    // </Snippet1>

}
