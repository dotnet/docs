Option Explicit
Option Strict

Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button1 As Button
    
    ' <Snippet1>
    Private Sub SetMyButtonProperties()
        ' Assign an image to the button.
        button1.Image = Image.FromFile("C:\Graphics\MyBitmap.bmp")
        ' Align the image and text on the button.
        button1.ImageAlign = ContentAlignment.MiddleRight
        button1.TextAlign = ContentAlignment.MiddleLeft
        ' Give the button a flat appearance.
        button1.FlatStyle = FlatStyle.Flat
    End Sub 'SetMyButtonProperties
    ' </Snippet1>
End Class 'Form1 
