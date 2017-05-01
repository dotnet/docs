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
Private Sub PrintColumnInformation(grid as DataGrid)
   Console.WriteLine("Count: " & grid.TableStyles.Count)
   Dim myTableStyle As DataGridTableStyle
   Dim myColumns As GridColumnStylesCollection
   Dim dgCol As DataGridColumnStyle
   For Each myTableStyle in grid.TableStyles
      myColumns = myTableStyle.GridColumnStyles
   
      ' Iterate through the collection and print each 
      ' object's type and width.
      For Each dgCol in myColumns
         Console.WriteLine(dgCol.MappingName)
         Console.WriteLine(dgCol.GetType.ToString())
         Console.WriteLine(dgCol.Width)
      Next
   Next
End Sub
' </Snippet1>
End Class
