Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Odbc

Module Module1

    Sub Main()
        'Dim connectionString As String = _
        '"Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
        'dim x as String="DRIVER={SQL Server};SERVER=MyServer;Trusted_connection=yes;DATABASE=Northwind;"
    End Sub

    ' <Snippet1>
    Public Function GetDataSetFromAdapter( _
        ByVal dataSet As DataSet, ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Using connection As New OdbcConnection(connectionString)
            Dim adapter As New OdbcDataAdapter(queryString, connection)

            ' Set the parameters.
            adapter.SelectCommand.Parameters.Add( _
                "@CategoryName", OdbcType.VarChar, 80).Value = "toasters"
            adapter.SelectCommand.Parameters.Add( _
             "@SerialNum", OdbcType.Int).Value = 239

            ' Open the connection and fill the DataSet.
            Try
                connection.Open()
                adapter.Fill(dataSet)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            ' The connection is automatically closed when the
            ' code exits the Using block.
        End Using

        Return dataSet
    End Function
    ' </Snippet1>
End Module
