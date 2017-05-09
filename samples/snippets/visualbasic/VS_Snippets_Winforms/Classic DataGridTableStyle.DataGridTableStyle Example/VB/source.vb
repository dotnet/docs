Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
   Inherits Form
   Protected dataGrid1 As DataGrid
   Protected myDataSet As DataSet
    
   ' <Snippet1>
   Private Sub AddGridTable()
      Dim myGridTableStyle As DataGridTableStyle
      myGridTableStyle = New DataGridTableStyle()
      myGridTableStyle.MappingName = "Customers"
      dataGrid1.TableStyles.Add(myGridTableStyle)
   End Sub 
    ' </Snippet1>
End Class 'Form1 

