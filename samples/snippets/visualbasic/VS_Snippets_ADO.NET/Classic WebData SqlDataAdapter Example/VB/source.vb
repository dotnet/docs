Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
        
    ' <Snippet1>
    Public Function SelectRows( _
        ByVal dataSet As DataSet, ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Using connection As New SqlConnection(connectionString)
            Dim adapter As New SqlDataAdapter()
            adapter.SelectCommand = New SqlCommand( _
                queryString, connection)
            adapter.Fill(dataSet)
            Return dataSet
        End Using
    End Function
    ' </Snippet1>

End Class
