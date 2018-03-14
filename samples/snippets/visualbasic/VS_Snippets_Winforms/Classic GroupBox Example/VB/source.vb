Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
' <Snippet1>
Private Sub InitializeMyGroupBox()
   ' Create and initialize a GroupBox and a Button control.
        Dim groupBox1 As New GroupBox()
        Dim button1 As New Button()
        button1.Location = New Point(20, 10)

        ' Set the FlatStyle of the GroupBox.
        groupBox1.FlatStyle = FlatStyle.Flat

        ' Add the Button to the GroupBox.
        groupBox1.Controls.Add(button1)

        ' Add the GroupBox to the Form.
        Controls.Add(groupBox1)

        ' Create and initialize a GroupBox and a Button control.
        Dim groupBox2 As New GroupBox()
        Dim button2 As New Button()
        button2.Location = New Point(20, 10)
        groupBox2.Location = New Point(0, 120)

        ' Set the FlatStyle of the GroupBox.
        groupBox2.FlatStyle = FlatStyle.Standard

        ' Add the Button to the GroupBox.
        groupBox2.Controls.Add(button2)

        ' Add the GroupBox to the Form.
        Controls.Add(groupBox2)
End Sub 
' </Snippet1>

End Class 'Form1 

