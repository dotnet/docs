Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


    ' <Snippet1>
Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    

    Private Sub GetHeight()
        Dim myGridColumn As MyGridColumn
        ' Get a DataGridColumnStyle of a DataGrid control.
        myGridColumn = CType(dataGrid1.TableStyles(0). _
        GridColumnStyles("CompanyName"), myGridColumn)
        ' Create a Graphics object.
        Dim g As Graphics = Me.CreateGraphics()
        Console.WriteLine(myGridColumn.GetPrefHeight(g, "A string"))
    End Sub 

End Class 

Public Class MyGridColumn
Inherits DataGridTextBoxColumn
   public Function GetPrefHeight (g As Graphics , _
   thisString As String ) As Integer
      return me.GetPreferredHeight(g,thisString)
   End Function
End Class
    ' </Snippet1>
