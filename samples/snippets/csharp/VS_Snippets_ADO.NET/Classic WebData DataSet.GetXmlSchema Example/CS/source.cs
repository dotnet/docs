using System;
using System.Data;

public class Sample
{
    public static void Main()
    {
        DemonstrateGetXml();
    }

    // <Snippet1>
    private static void DemonstrateGetXml()
    {
        // Create a DataSet with one table containing 
        // two columns and 10 rows.
        DataSet dataSet = new DataSet("dataSet");
        DataTable table = dataSet.Tables.Add("Items");
        table.Columns.Add("id", typeof(int));
        table.Columns.Add("Item", typeof(string));

        // Add ten rows.
        DataRow row;
        for(int i = 0; i <10;i++)
        {
            row = table.NewRow();
            row["id"]= i;
            row["Item"]= "Item" + i;
            table.Rows.Add(row);
        }

        // Display the DataSet contents as XML.
        Console.WriteLine( dataSet.GetXml() );
    }
    // </Snippet1>
}

