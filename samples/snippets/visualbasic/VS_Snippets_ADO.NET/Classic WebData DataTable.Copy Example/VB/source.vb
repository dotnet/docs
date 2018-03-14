imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CopyDataTable(ByVal table As DataTable )
    ' Create an object variable for the copy.
    Dim copyDataTable As DataTable
    copyDataTable = table.Copy()

    ' Insert code to work with the copy.
 End Sub
' </Snippet1>

End Class
