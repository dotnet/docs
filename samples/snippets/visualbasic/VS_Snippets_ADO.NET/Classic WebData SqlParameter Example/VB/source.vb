Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected categoriesDataSet As DataSet
    Protected dataGrid1 As DataGrid
    Protected categoriesAdapter As SqlDataAdapter
    
    
    
    ' <Snippet1>
    Public Sub AddSqlParameters()
        ' ...
        ' create categoriesDataSet and categoriesAdapter
        ' ...
        categoriesAdapter.SelectCommand.Parameters.Add( _
            "@CategoryName", SqlDbType.VarChar, 80).Value = "toasters"
        categoriesAdapter.SelectCommand.Parameters.Add( _
            "@SerialNum", SqlDbType.Int).Value = 239
        
        categoriesAdapter.Fill(categoriesDataSet)
    End Sub  
    ' </Snippet1>
End Class 'Form1

