Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
Private Sub CreateNewDataGridColumnStyle()
   Dim myDataSet As New DataSet("myDataSet")
   ' Insert code to populate the DataSet.

   ' Get the CurrencyManager for the table you want to add a column to.
   Dim myCurrencyManager As CurrencyManager = CType _
   (Me.BindingContext(myDataSet.Tables("Suppliers")), CurrencyManager)

   ' Get the PropertyDescriptor for the DataColumn.
   Dim pd As PropertyDescriptor = _
   myCurrencyManager.GetItemProperties()("City")

   ' Construct the DataGridColumnStyle with the PropertyDescriptor.
   Dim myColumn As New DataGridTextBoxColumn(pd)
   myColumn.MappingName = "City"
   dataGrid1.TableStyles(0).GridColumnStyles.Add(myColumn)

End Sub 
    ' </Snippet1>
End Class 'Form1 

