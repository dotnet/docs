Option Strict On
Option Explicit On
Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    ' <Snippet1>
    ' Handler for the OnStateChange event.
    Private Sub OnStateChange(ByVal sender As Object, _
        ByVal e As StateChangeEventArgs)
        PrintEventArgs(e)
    End Sub

    Sub Main()
        FillDataSet()
    End Sub

    Private Sub FillDataSet()
        Dim connectionString As String = GetConnectionString()
        Dim queryString As String = _
            "SELECT ProductID, UnitPrice from dbo.Products;"

        ' Create a DataAdapter.
        Using dataAdapter As New SqlDataAdapter( _
            queryString, connectionString)

            ' Add the handlers.
            AddHandler dataAdapter.SelectCommand.Connection.StateChange, _
                AddressOf OnStateChange

            ' Create a DataSet.
            Dim dataSet As New DataSet()

            ' Fill the DataSet, which fires several StateChange events.
            dataAdapter.Fill(dataSet, 0, 5, "Table")
        End Using
    End Sub

    Private Sub PrintEventArgs(ByVal args As StateChangeEventArgs)
        Console.WriteLine("StateChangeEventArgs")
        Console.WriteLine("  OriginalState= {0} CurrentState= {1}", _
            args.OriginalState, args.CurrentState)
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=true;"
    End Function

    ' </Snippet1>
    ' add Console.ReadLine() to Sub Main
End Module
