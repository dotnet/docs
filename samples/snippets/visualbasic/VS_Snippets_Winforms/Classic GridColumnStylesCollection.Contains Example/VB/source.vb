imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms


Public Class Form1: Inherits Form

Shared Sub Main()

End Sub

 Protected DataGrid1 As DataGrid
 Protected DataSet1 As DataSet
' <Snippet1>
Private Sub ContainsThisDataCol()
   Dim myPropertyDescriptor As PropertyDescriptor
   Dim myPropertyDescriptorCollection As PropertyDescriptorCOllection
   myPropertyDescriptorCollection = _
   me.BindingContext(DataSet1, "Customers").GetItemProperties()
   myPropertyDescriptor = myPropertyDescriptorCollection("FirstName")

   Dim trueOrFalse As Boolean
   ' Set the variable to a known column in the grid's DataTable.
   trueOrFalse = DataGrid1.TableStyles(0).GridColumnStyles. _
   Contains(myPropertyDescriptor)
   Console.WriteLine(trueOrFalse)
End Sub 
' </Snippet1>
End Class
