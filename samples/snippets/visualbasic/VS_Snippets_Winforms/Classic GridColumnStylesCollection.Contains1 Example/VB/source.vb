imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms


Public Class Form1: Inherits Form
    Protected DataGrid1 As DataGrid
    Protected ds As DataSet
    ' <Snippet1>
Private Sub ContainsThisDataCol()
   Dim myGridColumnCol As GridColumnStylesCollection
   myGridColumnCol = dataGrid1.TableStyles(0).GridColumnStyles
   ' Get the CurrencyManager for the table you want to add a column to.
   Dim myCurrencyManager As CurrencyManager = _
   CType(Me.BindingContext(ds.Tables("Suppliers")), CurrencyManager)
   ' Get the PropertyDescriptor for the DataColumn of the new column.
   Dim pd As PropertyDescriptor = _
   myCurrencyManager.GetItemProperties()("City")
   Dim myColumn As New DataGridTextBoxColumn()
   myColumn.PropertyDescriptor = pd
   ' Test to see if the present columns contains the new object.
   Console.WriteLine(DataGrid1.TableStyles(0).GridColumnStyles. _
   Contains(myColumn))
End Sub
    ' </Snippet1>
End Class
