imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub SetMinimumCapacity(ByVal table As DataTable)
    ' Change the MinimumCapacity.
    table.MinimumCapacity = 100
 End Sub
' </Snippet1>

End Class
