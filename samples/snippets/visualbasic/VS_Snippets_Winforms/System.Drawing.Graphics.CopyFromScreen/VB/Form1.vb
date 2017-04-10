'<snippet1>
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Form1
    Inherits Form
    Private WithEvents printButton As New Button
    Private WithEvents printDocument1 As New PrintDocument

    Public Sub New()
        printButton.Text = "Print Form"
        Me.Controls.Add(printButton)
    End Sub

    Dim memoryImage As Bitmap

    Private Sub CaptureScreen()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = Me.Size
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, s)
    End Sub

    Private Sub printDocument1_PrintPage(ByVal sender As System.Object, _
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles _
       printDocument1.PrintPage
        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

    Private Sub printButton_Click(ByVal sender As System.Object, ByVal e As _
       System.EventArgs) Handles printButton.Click
        CaptureScreen()
        printDocument1.Print()
    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
'</snippet1>