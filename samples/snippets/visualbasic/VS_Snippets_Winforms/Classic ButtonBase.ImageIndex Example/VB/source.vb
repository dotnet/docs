Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected ImageList1 As ImageList
    
    ' <Snippet1>
    Private Sub AddMyImage()
        ' Assign an image to the ImageList.
        ImageList1.Images.Add(Image.FromFile("C:\Graphics\MyBitmap.bmp"))
        ' Assign the ImageList to the button control.   
        button1.ImageList = ImageList1
        ' Select the image from the ImageList (using the ImageIndex property).    
        button1.ImageIndex = 0
    End Sub 'AddMyImage
    ' </Snippet1>
End Class 'Form1 
