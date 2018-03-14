Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Sample
    
    Protected radioButton1 As RadioButton   
    
'<Snippet1>
 Private Sub radioButton1_CheckedChanged(sender As Object, e As EventArgs)
     ' Change the check box position to be opposite its current position.
     If radioButton1.CheckAlign = ContentAlignment.MiddleLeft Then
         radioButton1.CheckAlign = ContentAlignment.MiddleRight
     Else
         radioButton1.CheckAlign = ContentAlignment.MiddleLeft
     End If
 End Sub

'</Snippet1>
End Class

