Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub CopyAllMyText()
     ' Determine if any text is selected in the TextBox control.
     If textBox1.SelectionLength = 0 Then
         ' Select all text in the text box.
         textBox1.SelectAll()
     End If 
     ' Copy the contents of the control to the Clipboard.
     textBox1.Copy()
 End Sub

' </Snippet1>
End Class

