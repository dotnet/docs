Option Explicit On
Option Strict On
Imports System.Data.OleDb
Imports System.Data

Module Module1

    Sub Main()
        Dim connectionString As String = GetConnectionString()
        Dim queryString As String = _
            "SELECT CompanyName FROM dbo.Shippers;"
        Dim dataSet As DataSet = CreateCommandAndUpdate( _
            connectionString, queryString)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Public Function CreateCommandAndUpdate( _
        ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Dim dataSet As DataSet = New DataSet

        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Dim adapter As New OleDbDataAdapter()

            adapter.SelectCommand = New OleDbCommand( _
                queryString, connection)

            Dim builder As OleDbCommandBuilder = _
                New OleDbCommandBuilder(adapter)

            adapter.Fill(dataSet)

            ' Code to modify the data in the DataSet here. 

            ' Without the OleDbCommandBuilder this line would fail.
            builder.GetUpdateCommand()
            adapter.Update(dataSet)
        End Using
        Return dataSet
    End Function
    ' </Snippet1>

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Provider=sqloledb;Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=SSPI;"
    End Function

End Module
