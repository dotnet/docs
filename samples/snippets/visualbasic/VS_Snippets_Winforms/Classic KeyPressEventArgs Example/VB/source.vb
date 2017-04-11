Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

' <Snippet1>
Public Class myKeyPressClass
    Private Shared keyPressCount As Long = 0
    Private Shared backspacePressed As Long = 0
    Private Shared returnPressed As Long = 0
    Private Shared escPressed As Long = 0
    Private textBox1 As TextBox
    
    Private Sub myKeyCounter(sender As Object, ex As KeyPressEventArgs)
        Select Case ex.KeyChar
            ' Counts the backspaces.
            Case ControlChars.Back
                backspacePressed = backspacePressed + 1
            ' Counts the ENTER keys.
            Case ControlChars.Lf
                returnPressed = returnPressed + 1
            ' Counts the ESC keys.  
            Case Convert.ToChar(27)
                escPressed = escPressed + 1
            ' Counts all other keys.
            Case Else
                keyPressCount = keyPressCount + 1
        End Select
        
        textBox1.Text = backspacePressed & " backspaces pressed" & _
            ControlChars.Lf & ControlChars.Cr & escPressed & _
            " escapes pressed" & ControlChars.CrLf & returnPressed & _
            " returns pressed" & ControlChars.CrLf & keyPressCount & _
            " other keys pressed" & ControlChars.CrLf
        ex.Handled = True
    End Sub 'myKeyCounter
End Class 'myKeyPressClass
' </Snippet1>