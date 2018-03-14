Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub EditDataRowView(rowView As DataRowView, _
    columnToEdit As String)
    rowView.BeginEdit()
    rowView(columnToEdit) = textBox1.Text

    ' Validate the input with a function.
    If ValidateCompanyName(rowView(columnToEdit)) Then
        rowView.EndEdit()
    Else
        rowView.CancelEdit()
    End If
End Sub
     
Private Function ValidateCompanyName( _
    valuetoCheck As Object) As Boolean
    ' Insert code to validate the value.
    Return True
End Function
' </Snippet1>
End Class
