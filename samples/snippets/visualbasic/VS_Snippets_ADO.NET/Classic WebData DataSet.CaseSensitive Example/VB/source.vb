imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

Protected Sub Method()
' <Snippet1>
 DataSet1.CaseSensitive = DataSet1.CaseSensitive Xor True
' </Snippet1>
End Sub
End Class
