Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Public Sub InitializeMyForm()
        BackColor = Color.Red
        ' Make the background color of form display transparently.
        TransparencyKey = BackColor
    End Sub 'InitializeMyForm
    ' </Snippet1>
End Class 'Form1 

