using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  private DataSet DataSet1;
  private DataGrid dataGrid1;


// <Snippet1>
// handler for RowUpdating event
 private static void OnRowUpdating(object sender, OracleRowUpdatingEventArgs e) {
    PrintEventArgs(e);
 }
 
 //Handler for RowUpdated event.
 private static void OnRowUpdated(object sender, OracleRowUpdatedEventArgs e) {
    PrintEventArgs(e);
 }
 
 public static int Main(String[] args) {
    const string CONNECTION_STRING = "Data Source=Oracle8i;Integrated Security=yes";
    const string SELECT_ALL = "SELECT * FROM Scott.Emp";
 
    //Create DataAdapter.
    OracleDataAdapter rAdapter = new OracleDataAdapter(SELECT_ALL, CONNECTION_STRING);
    OracleCommandBuilder cb = new OracleCommandBuilder(rAdapter);
 
    //Create and fill DataSet (Select only first 5 rows.).
    DataSet rDataSet = new DataSet();
    rAdapter.Fill(rDataSet, 0, 5, "Table");
 
    //Modify DataSet.
    DataTable rTable = rDataSet.Tables["Table"];
    rTable.Rows[0][1] = "DYZY";
 
    //Add handlers.
    rAdapter.RowUpdating += new OracleRowUpdatingEventHandler( OnRowUpdating );
    rAdapter.RowUpdated += new OracleRowUpdatedEventHandler( OnRowUpdated );
 
    //Update--this operation fires two events (RowUpdating and RowUpdated) for each changed row. 
    rAdapter.Update(rDataSet, "Table");
 
    //Remove handlers.
    rAdapter.RowUpdating -= new OracleRowUpdatingEventHandler( OnRowUpdating );
    rAdapter.RowUpdated -= new OracleRowUpdatedEventHandler( OnRowUpdated );
    return 0;
 }
 
 private static void PrintEventArgs(OracleRowUpdatingEventArgs args) {
    Console.WriteLine("OnRowUpdating");
    Console.WriteLine("  event args: ("+
           " command=" + args.Command + 
           " commandType=" + args.StatementType + 
           " status=" + args.Status + ")");
 }
 
 private static void PrintEventArgs(OracleRowUpdatedEventArgs args) {
    Console.WriteLine("OnRowUpdated");
    Console.WriteLine( "  event args: ("+
           " command=" + args.Command +
           " commandType=" + args.StatementType + 
           " recordsAffected=" + args.RecordsAffected + 
           " status=" + args.Status + ")" );
 }
 // </Snippet1>

}
