Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected listBox1 As ListBox
    Protected radioButton1 As RadioButton
    Protected radioButton2 As RadioButton
    
' <Snippet1>
 Private Sub ClickMyRadioButton()
     ' If Item1 is selected and radioButton2 
     ' is checked, click radioButton1.
     If (listBox1.Text = "Item1") And radioButton2.Checked Then
         radioButton1.PerformClick()
     End If
 End Sub

' </Snippet1>
End Class

