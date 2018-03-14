Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
    ' <Snippet1>
Public Class Form1
   Inherits Form
   Protected dataGrid1 As DataGrid
    
   Private Sub GetHeight()
      Dim myGridColumn As MyGridColumn = _
      CType(dataGrid1.TableStyles(1).GridColumnStyles(0), _
      MyGridColumn)
      Console.WriteLine(myGridColumn.GetMinHeight())
   End Sub 

End Class 

Public Class MyGridColumn
Inherits DataGridBoolColumn
   Public Function GetMinHeight() As Integer
      return me.GetMinimumHeight()
   End Function
End Class

    ' </Snippet1>
