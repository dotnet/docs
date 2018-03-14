Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Public Sub MoveMyForm()
        ' Create a Rectangle object that will be used as the bound of the form.
        Dim tempRect As New Rectangle(50, 50, 100, 100)
        '  Set the bounds of the form using the Rectangle object.
        DesktopBounds = tempRect
    End Sub 'MoveMyForm
    ' </Snippet1>
End Class 'Form1 
