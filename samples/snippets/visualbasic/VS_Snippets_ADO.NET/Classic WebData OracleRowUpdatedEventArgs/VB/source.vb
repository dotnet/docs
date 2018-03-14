Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private DataSet1 As DataSet
    Private dataGrid1 As DataGrid
    
    ' <Snippet1>
    'Handler for RowUpdating event.
    Private Shared Sub OnRowUpdating(sender As Object, e As OracleRowUpdatingEventArgs)
        PrintEventArgs(e)
    End Sub 'OnRowUpdating

    'Handler for RowUpdated event.
    Private Shared Sub OnRowUpdated(sender As Object, e As OracleRowUpdatedEventArgs)
        PrintEventArgs(e)
    End Sub 'OnRowUpdated
    
    'Entry point which delegates to C-style main Private Function.
    Public Overloads Shared Sub Main()
        System.Environment.ExitCode = Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Function Main(args() As String) As Integer
        Const CONNECTION_STRING As String = "Data Source=Oracle8i;Integrated Security=yes"
        Const SELECT_ALL As String = "SELECT * FROM Scott.Emp"
        
        'Create DataAdapter.
        Dim rAdapter As New OracleDataAdapter(SELECT_ALL, CONNECTION_STRING)
        Dim cb As OracleCommandBuilder = New OracleCommandBuilder(rAdapter)
        
        'Create and fill DataSet (Select only first 5 rows.).
        Dim rDataSet As New DataSet()
        rAdapter.Fill(rDataSet, 0, 5, "Table")
        
        'Modify DataSet.
        Dim rTable As DataTable = rDataSet.Tables("Table")
        rTable.Rows(0)(1) = "DYZY"
        
        'Add handlers.
        AddHandler rAdapter.RowUpdating, AddressOf OnRowUpdating
        AddHandler rAdapter.RowUpdated, AddressOf OnRowUpdated
        
        'Update--this operation fires two events (RowUpdating and RowUpdated) for each changed row.
        rAdapter.Update(rDataSet, "Table")
        
        'Remove handlers.
        RemoveHandler rAdapter.RowUpdating, AddressOf OnRowUpdating
        RemoveHandler rAdapter.RowUpdated, AddressOf OnRowUpdated
        Return 0
    End Function 'Main
    
    
    Overloads Private Shared Sub PrintEventArgs(args As OracleRowUpdatingEventArgs)
        Console.WriteLine("OnRowUpdating")
        Console.WriteLine("  event args: (" & " command=" & args.Command.CommandText & _
                        " commandType=" & args.StatementType & " status=" & args.Status & ")")
    End Sub 'PrintEventArgs
    
    
    Overloads Private Shared Sub PrintEventArgs(args As OracleRowUpdatedEventArgs)
        Console.WriteLine("OnRowUpdated")
        Console.WriteLine("  event args: (" & " command=" & args.Command.CommandText & _
                        " commandType=" & args.StatementType & " recordsAffected=" & _
                        args.RecordsAffected & " status=" & args.Status & ")")
    End Sub 'PrintEventArgs
End Class 'Form1
' </Snippet1>
