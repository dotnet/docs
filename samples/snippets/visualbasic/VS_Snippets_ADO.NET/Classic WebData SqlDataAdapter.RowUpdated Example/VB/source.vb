Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private DataSet1 As DataSet
    Private dataGrid1 As DataGrid
    
    ' <Snippet1>
    ' handler for RowUpdating event
    Private Shared Sub OnRowUpdating(sender As Object, e As SqlRowUpdatingEventArgs)
        PrintEventArgs(e)
    End Sub 

    ' handler for RowUpdated event
    Private Shared Sub OnRowUpdated(sender As Object, e As SqlRowUpdatedEventArgs)
        PrintEventArgs(e)
    End Sub 
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        System.Environment.ExitCode = Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Function Main(args() As String) As Integer
        Const connectionString As String = _
            "Integrated Security=SSPI;database=Northwind;server=MSSQL1"
        Const queryString As String = "SELECT * FROMProducts"
        
        ' create DataAdapter
        Dim adapter As New SqlDataAdapter(queryString, connectionString)
        Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
        
        ' Create and fill DataSet (select only first 5 rows)
        Dim dataSet As New DataSet()
        adapter.Fill(dataSet, 0, 5, "Table")
        
        ' Modify DataSet
        Dim table As DataTable = dataSet.Tables("Table")
        table.Rows(0)(1) = "new product"
        
        ' add handlers
        AddHandler adapter.RowUpdating, AddressOf OnRowUpdating
        AddHandler adapter.RowUpdated, AddressOf OnRowUpdated
        
        ' update, this operation fires two events 
        '(RowUpdating/RowUpdated) per changed row 
        adapter.Update(dataSet, "Table")
        
        ' remove handlers
        RemoveHandler adapter.RowUpdating, AddressOf OnRowUpdating
        RemoveHandler adapter.RowUpdated, AddressOf OnRowUpdated
        Return 0
    End Function 
    
    
    Overloads Private Shared Sub PrintEventArgs(args As SqlRowUpdatingEventArgs)
        Console.WriteLine("OnRowUpdating")
        Console.WriteLine("  event args: (" & " command=" & args.Command.CommandText & _
           " commandType=" & args.StatementType & " status=" & args.Status & ")")
    End Sub 
    
    
    Overloads Private Shared Sub PrintEventArgs(args As SqlRowUpdatedEventArgs)
        Console.WriteLine("OnRowUpdated")
        Console.WriteLine("  event args: (" & " command=" & args.Command.CommandText & _
           " commandType=" & args.StatementType & " recordsAffected=" & _
           args.RecordsAffected & " status=" & args.Status & ")")
    End Sub 
End Class 
' </Snippet1>
