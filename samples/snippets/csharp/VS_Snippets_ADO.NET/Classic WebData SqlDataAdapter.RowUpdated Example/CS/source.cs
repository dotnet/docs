using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    private DataSet DataSet1;
    private DataGrid dataGrid1;


    // <Snippet1>
    // handler for RowUpdating event
    private static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs e) 
    {
        PrintEventArgs(e);
    }
 
    // handler for RowUpdated event
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e) 
    {
        PrintEventArgs(e);
    }
 
    public static int Main() 
    {
        const string connectionString = 
                  "Integrated Security=SSPI;database=Northwind;server=MSSQL1";
        const string queryString = "SELECT * FROMProducts";
 
        // create DataAdapter
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString);
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
 
        // Create and fill DataSet (select only first 5 rows)
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet, 0, 5, "Table");
 
        // Modify DataSet
        DataTable table = dataSet.Tables["Table"];
        table.Rows[0][1] = "new product";
 
        // add handlers
        adapter.RowUpdating += new SqlRowUpdatingEventHandler( OnRowUpdating );
        adapter.RowUpdated += new SqlRowUpdatedEventHandler( OnRowUpdated );
 
        // update, this operation fires two events 
        // (RowUpdating/RowUpdated) per changed row 
        adapter.Update(dataSet, "Table");
 
        // remove handlers
        adapter.RowUpdating -= new SqlRowUpdatingEventHandler( OnRowUpdating );
        adapter.RowUpdated -= new SqlRowUpdatedEventHandler( OnRowUpdated );
        return 0;
    }
 
    private static void PrintEventArgs(SqlRowUpdatingEventArgs args) 
    {
        Console.WriteLine("OnRowUpdating");
        Console.WriteLine("  event args: ("+
            " command=" + args.Command + 
            " commandType=" + args.StatementType + 
            " status=" + args.Status + ")");
    }
 
    private static void PrintEventArgs(SqlRowUpdatedEventArgs args) 
    {
        Console.WriteLine("OnRowUpdated");
        Console.WriteLine( "  event args: ("+
            " command=" + args.Command +
            " commandType=" + args.StatementType + 
            " recordsAffected=" + args.RecordsAffected + 
            " status=" + args.Status + ")");
    }
    // </Snippet1>

}
