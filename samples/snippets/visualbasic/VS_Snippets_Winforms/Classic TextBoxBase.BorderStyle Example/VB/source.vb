Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
    Public Sub CreateTextBox()
        ' Create an instance of the TextBox control.
        Dim textBox1 As New TextBox()
        
        ' Set the TextBox Font property to Arial 20.
        textBox1.Font = New Font("Arial", 20)
        ' Set the BorderStyle property to FixedSingle.
        textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        ' Make the height of the control equal to the preferred height.
        textBox1.Height = textBox1.PreferredHeight
    End Sub

' </Snippet1>
End Class

