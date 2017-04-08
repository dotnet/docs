Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected pictureBox1 As PictureBox
    Protected hScrollBar1, vScrollBar1 As ScrollBar
    
    ' <Snippet1>
    Public Sub DisplayScrollBars()
        ' Display or hide the scroll bars based upon  
        ' whether the image is larger than the PictureBox.
        If pictureBox1.Width > pictureBox1.Image.Width Then
            hScrollBar1.Visible = False
        Else
            hScrollBar1.Visible = True
        End If
        
        If pictureBox1.Height > pictureBox1.Image.Height Then
            vScrollBar1.Visible = False
        Else
            vScrollBar1.Visible = True
        End If
    End Sub 'DisplayScrollBars
    ' </Snippet1>
End Class 'Form1 
