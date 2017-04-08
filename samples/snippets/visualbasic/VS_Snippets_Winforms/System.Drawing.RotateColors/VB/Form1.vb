Imports System.Drawing.Imaging
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        MyBase.New()
    End Sub

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    Private Sub Me_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) _
        Handles Me.Paint

        RotateColors(e)
    End Sub

    '<snippet1>
    Private Sub RotateColors(ByVal e As PaintEventArgs)
        Dim image As Bitmap = New Bitmap("RotationInput.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        Dim degrees As Single = 60.0F
        Dim r As Double = degrees * System.Math.PI / 180 ' degrees to radians
        Dim colorMatrixElements As Single()() = { _
           New Single() {CSng(System.Math.Cos(r)), _
                         CSng(System.Math.Sin(r)), 0, 0, 0}, _
           New Single() {CSng(-System.Math.Sin(r)), _
                         CSng(-System.Math.Cos(r)), 0, 0, 0}, _
           New Single() {0, 0, 2, 0, 0}, _
           New Single() {0, 0, 0, 1, 0}, _
           New Single() {0, 0, 0, 0, 1}}

        Dim colorMatrix As New ColorMatrix(colorMatrixElements)

        imageAttributes.SetColorMatrix( _
           colorMatrix, _
           ColorMatrixFlag.Default, _
           ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(image, 10, 10, width, height)

        ' Pass in the destination rectangle (2nd argument), the upper-left corner 
        ' (3rd and 4th arguments), width (5th argument),  and height (6th 
        ' argument) of the source rectangle.
        e.Graphics.DrawImage( _
           image, _
           New Rectangle(150, 10, width, height), _
           0, 0, _
           width, _
           height, _
           GraphicsUnit.Pixel, _
           imageAttributes)
    End Sub
    '</snippet1>

  

End Class
