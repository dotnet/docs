Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
   Inherits Form
   Protected myDataGrid As DataGrid
   Private myDataSet As DataSet
    
    
   Public Shared Sub Main()
      Dim f1 As New Form1()
      f1.myDataSet = New DataSet("myDataSet")
   End Sub 'Main
    
    ' <Snippet1>
Private Sub CreateDataGridGridTableStyle()
   Dim myCurrencyManager As CurrencyManager
   Dim myGridTableStyle As DataGridTableStyle
   ' Get the CurrencyManager for a DataTable named "Customers"
   ' found in a DataSet named "myDataSet". 
   myCurrencyManager = CType _
   (Me.BindingContext(myDataSet, "Customers"), CurrencyManager)
   myGridTableStyle = New DataGridTableStyle(myCurrencyManager)
   ' Add the table style to the collection of a DataGrid.
   myDataGrid.TableStyles.Add(myGridTableStyle)
End Sub 'CreateDataGridGridTableStyle
    ' </Snippet1>
End Class 'Form1 

