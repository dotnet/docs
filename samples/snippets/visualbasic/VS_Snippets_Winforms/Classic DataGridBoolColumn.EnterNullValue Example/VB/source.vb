Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Class1
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub EnterNull()
   ' Creates an instance of a class derived from DataGridBoolColumn.
   Dim colBool As MyDataGridBoolColumn
   colBool = CType(dataGrid1.TableStyles(0).GridColumnStyles(2), MyDataGridBoolColumn)
   colBool.CallEnterNullValue()
End Sub    
    
 ' Class derived from DataGridBoolColumn.
Friend Class MyDataGridBoolColumn
   Inherits DataGridBoolColumn        
        
   Public Sub CallEnterNullValue()
      Me.EnterNullValue()
   End Sub
End Class
' </Snippet1>
End Class

