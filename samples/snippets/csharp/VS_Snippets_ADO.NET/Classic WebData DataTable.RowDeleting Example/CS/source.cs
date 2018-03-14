using System;
using System.Data;
using System.Data.OleDb;

public class Sample
{
    static void Main()
    {
        DataTableRowDeleting();
    }
    // <Snippet1>
    private static void DataTableRowDeleting()
    {
        DataTable customerTable = new DataTable("Customers");
        // add columns
        customerTable.Columns.Add( "id", typeof(int));
        customerTable.Columns.Add( "name", typeof(string));
        customerTable.Columns.Add( "address", typeof(string));

        // set PrimaryKey
        customerTable.Columns[ "id" ].Unique = true;
        customerTable.PrimaryKey = new DataColumn[] 
            { customerTable.Columns["id"] };

        // add a RowDeleting event handler for the table.
        customerTable.RowDeleting += new DataRowChangeEventHandler( Row_Deleting );


        // add ten rows
        for( int id=1; id<=10; id++)
        {
            customerTable.Rows.Add( 
                new object[] { id, string.Format("customer{0}", id), 
                string.Format("address{0}", id) });
        }
	
        customerTable.AcceptChanges();

        // Delete all the rows
        foreach( DataRow row in customerTable.Rows )
            row.Delete();
    }

    private static void Row_Deleting( object sender, 
        DataRowChangeEventArgs e )
    {
        Console.WriteLine( "Row_Deleting Event: name={0}; action={1}", 
            e.Row["name"], e.Action );
    }
    // </Snippet1>
}