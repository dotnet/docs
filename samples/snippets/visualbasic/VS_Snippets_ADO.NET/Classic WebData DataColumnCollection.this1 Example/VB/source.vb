Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub PrintDataType(table As DataTable)
     ' Get the DataColumnCollection from a DataTable in a DataSet.
     Dim columns As DataColumnCollection = table.Columns

     ' Print the column's data type.
     Console.WriteLine(columns("id").DataType)
End Sub
' </Snippet1>
End Class
