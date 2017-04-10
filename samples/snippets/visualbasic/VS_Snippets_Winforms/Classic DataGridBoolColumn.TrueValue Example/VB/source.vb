Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    Protected myDataGrid As DataGrid
    
    ' <Snippet1>
Private Sub SetBoolColumnValues()
   Dim myGridColumn As DataGridBoolColumn 
   ' Get the DataGridBoolColumn you are setting.
   myGridColumn = CType(myDataGrid.TableStyles _
   ("Customers").GridColumnStyles("Current"), DataGridBoolColumn)
   ' Set TrueValue, FalseValue, and NullValue.
   myGridColumn.TrueValue = true
   myGridColumn.FalseValue = false
   myGridColumn.NullValue = Convert.DBNull
End Sub

    ' </Snippet1>
End Class 'Form1 


