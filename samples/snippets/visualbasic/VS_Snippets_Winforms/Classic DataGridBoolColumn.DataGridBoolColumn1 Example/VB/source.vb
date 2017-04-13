Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    Protected ds As DataSet
    
    ' <Snippet1>
Private Sub CreateNewDataGridColumn()
   Dim myGridColumnCol As GridColumnStylesCollection
   myGridColumnCol = dataGrid1.TableStyles(0).GridColumnStyles
   ' Get the CurrencyManager for the table.
   Dim myCurrencyManager As CurrencyManager =  _
   CType(Me.BindingContext(ds.Tables("Products")), CurrencyManager)
   ' Get the PropertyDescriptor for the DataColumn of the new column.
   ' The column should contain a Boolean value. 
   Dim pd As PropertyDescriptor = _
   myCurrencyManager.GetItemProperties()("Discontinued")
   Dim myColumn As New DataGridBoolColumn(pd)
   myColumn.MappingName = "Discontinued"
   myGridColumnCol.Add(myColumn)
End Sub 
    ' </Snippet1>
End Class 'Form1 

