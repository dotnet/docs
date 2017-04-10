Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Public Sub MoveMyForm()
        ' Create a Point object that will be used as the location of the form.
        Dim tempPoint As New Point(100, 100)
        ' Set the location of the form using the Point object.
        DesktopLocation = tempPoint
    End Sub 'MoveMyForm
    ' </Snippet1>
End Class 'Form1 

