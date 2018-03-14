Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb

Module Module1

    Sub Main()
    End Sub
    ' <Snippet1>
    Public Function CreateCmdsAndUpdate(ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Using connection As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter()
            adapter.SelectCommand = New OleDbCommand(queryString, connection)
            Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(adapter)

            connection.Open()

            Dim customers As DataSet = New DataSet
            adapter.Fill(customers)

            ' Code to modify data in DataSet here 

            ' Insert new records from DataSet
            Dim rows() As DataRow = customers.Tables(0).Select( _
                Nothing, Nothing, DataViewRowState.Added)
            adapter.Update(rows)

            Return customers
        End Using
    End Function
    ' </Snippet1>
End Module
