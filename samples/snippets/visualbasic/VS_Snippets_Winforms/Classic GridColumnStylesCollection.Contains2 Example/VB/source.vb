imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected DataGrid1 As DataGrid
 Protected DataSet1 As DataSet
Shared Sub Main()
End Sub

' <Snippet1>
Private Sub ContainsThisDataCol()
    ' Use the Contains method to determine whether a specific
    ' DataGridColumnStyle with the same MappingName exists.
    Console.WriteLine(DataGrid1.TableStyles(0). _
    GridColumnStyles.Contains("FirstName"))
End Sub    
' </Snippet1>
End Class
