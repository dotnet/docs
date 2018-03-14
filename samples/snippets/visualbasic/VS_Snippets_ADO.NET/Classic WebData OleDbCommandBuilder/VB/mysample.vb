Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common

Public Class Form1
    Shared Sub Main()

    End Sub
    ' <Snippet1>
    Public Shared Function UpdateRows(ByVal connectionString As String, _
    ByVal queryString As String, ByVal tableName As String) As DataSet

        Dim dataSet As DataSet = New DataSet

        Using connection As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter()
            adapter.SelectCommand = New OleDbCommand(queryString, connection)
            Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(adapter)

            connection.Open()

            adapter.Fill(dataSet, tableName)

            ' Code to modify data in DataSet here 

            builder.GetUpdateCommand()

            ' Without the OleDbCommandBuilder this line would fail.
            adapter.Update(dataSet, tableName)
        End Using

        Return dataSet
    End Function
    ' </Snippet1>

End Class