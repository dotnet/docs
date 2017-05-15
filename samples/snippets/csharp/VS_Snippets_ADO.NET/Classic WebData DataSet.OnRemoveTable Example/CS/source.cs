using System;
using System.Data;

public class Sample
{
    public static void Main()
    {
        DemonstrateOnRemoveTable();
    }

    // <Snippet1>

    public static void DemonstrateOnRemoveTable()
    {
        DerivedDataSet dataSet = CreateDataSet();
        if(dataSet.Tables.Count > 0)
            dataSet.Tables.RemoveAt(0);
    }

    public class DerivedDataSet: DataSet
    {
        protected override void OnRemoveTable(DataTable table)
        {
            Console.WriteLine(
                "The '{0}' DataTable has been removed from the DataSet", 
                table.TableName);
        }
    }

    public static DerivedDataSet CreateDataSet()
    {
        // Create a DataSet with one table containing two columns.
        DerivedDataSet derived = new DerivedDataSet();

        // Add table to DataSet.
        DataTable table = derived.Tables.Add("Items");

        // Add two columns.
        DataColumn column = table.Columns.Add("id", typeof(int));
        column.AutoIncrement = true;
        table.Columns.Add("item", typeof(int));

        // Set primary key.
        table.PrimaryKey = new DataColumn[] {table.Columns["id"]};

        return derived;
    }
    // </Snippet1>
}

