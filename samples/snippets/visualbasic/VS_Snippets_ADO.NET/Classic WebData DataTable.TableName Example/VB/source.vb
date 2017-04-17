Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub GetTableNames(dataSet As DataSet)
     ' Print each table's TableName.
     Dim table As DataTable
     For Each table In dataSet.Tables
         Console.WriteLine(table.TableName)
     Next table
End Sub
' </Snippet1>
End Class
