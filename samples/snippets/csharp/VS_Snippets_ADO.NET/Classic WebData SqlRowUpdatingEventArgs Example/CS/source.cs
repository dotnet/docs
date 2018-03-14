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
 
    //Handler for RowUpdated event.
    private static void OnRowUpdated(object sender, SqlRowUpdatedEventArgs e) 
    {
        PrintEventArgs(e);
    }
 
    public static int Main() 
    {
        const string CONNECTION_STRING = "Persist Security Info=False;Integrated Security=SSPI;database=northwind;server=mySQLServer";
        const string SELECT_ALL = "select * from Products";
 
        //Create DataAdapter.
        SqlDataAdapter rAdapter    = new SqlDataAdapter(SELECT_ALL, CONNECTION_STRING);
 
        //Create and fill DataSet (Select only first 5 rows.).
        DataSet rDataSet = new DataSet();
        rAdapter.Fill(rDataSet, 0, 5, "Table");
 
        //Modify DataSet.
        DataTable rTable = rDataSet.Tables["Table"];
        rTable.Rows[0][1] = "new product";
 
        //Add handlers.
        rAdapter.RowUpdating += new SqlRowUpdatingEventHandler( OnRowUpdating );
        rAdapter.RowUpdated += new SqlRowUpdatedEventHandler( OnRowUpdated );
 
        //Update--this operation fires two events (RowUpdating and RowUpdated) for each changed row. 
        rAdapter.Update(rDataSet, "Table");
 
        //Remove handlers.
        rAdapter.RowUpdating -= new SqlRowUpdatingEventHandler( OnRowUpdating );
        rAdapter.RowUpdated -= new SqlRowUpdatedEventHandler( OnRowUpdated );
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
        Console.WriteLine("  event args: ("+
            " command=" + args.Command +
            " commandType=" + args.StatementType + 
            " recordsAffected=" + args.RecordsAffected + 
            " status=" + args.Status + ")");
    }
    // </Snippet1>

}
