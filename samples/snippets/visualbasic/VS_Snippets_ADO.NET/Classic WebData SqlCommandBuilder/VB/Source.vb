Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Function SelectSqlRows(ByVal connectionString As String, _
        ByVal queryString As String, ByVal tableName As String) As DataSet

        Using connection As New SqlConnection(connectionString)

            Dim adapter As New SqlDataAdapter()
            adapter.SelectCommand = New SqlCommand(queryString, connection)
            Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)

            connection.Open()

            Dim dataSet As DataSet = New DataSet
            adapter.Fill(dataSet, tableName)

            ' Code to modify data in DataSet here 

            builder.GetUpdateCommand()

            ' Without the SqlCommandBuilder this line would fail.
            adapter.Update(dataSet, tableName)

            Return dataSet
        End Using
    End Function
    ' </Snippet1>

End Module
