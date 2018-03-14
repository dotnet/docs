Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
    Private flag As Boolean    
    
    Private Sub MyTextChangedHandler(sender As System.Object, e As System.EventArgs)
        ' Check the flag to prevent code re-entry. 
        If flag = False Then
            ' Set the flag to True to prevent re-entry of the code below.
            flag = True
            ' Determine if the text of the control is a number.
            If IsNumeric(textBox1.Text) = False Then
                ' Display a message box and clear the contents if not a number.
                MessageBox.Show("The text is not a valid number. Please re-enter")
                ' Clear the contents of the text box to allow re-entry.
                textBox1.Clear()
            End If
            ' Reset the flag so other TextChanged events are processed correctly.
            flag = False
        End If
    End Sub

' </Snippet1>
End Class

