imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
 Private Sub AcceptOrReject(ByVal row As DataRow)
    ' Use a function to validate the row's values.
    ' If the function returns true, end the edit; 
    ' otherwise cancel it.
    If ValidateRow(row) Then
       row.EndEdit()
    Else
       row.CancelEdit()
    End If
End Sub
 
Private Function ValidateRow(ByVal row As DataRow) As Boolean
    Dim isValid As Boolean
    ' Insert code to validate the row values. 
    ' Set the isValid variable.
    ValidateRow = isValid
End Function
' </Snippet1>

End Class
