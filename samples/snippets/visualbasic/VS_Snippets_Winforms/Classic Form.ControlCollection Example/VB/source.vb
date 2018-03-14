Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Public Sub AddMyControls()
        Dim textBox1 As New TextBox()
        Dim label1 As New Label()
        
        ' Initialize the controls and their bounds.
        label1.Text = "First Name"
        label1.Location = New Point(48, 48)
        label1.Size = New Size(104, 16)
        textBox1.Text = ""
        textBox1.Location = New Point(48, 64)
        textBox1.Size = New Size(104, 16)
        
        ' Add the TextBox control to the form's control collection.
        Controls.Add(textBox1)
        ' Add the Label control to the form's control collection.
        Controls.Add(label1)
    End Sub 'AddMyControls
    ' </Snippet1>
End Class 'Form1 

