Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Imaging


Public Class SystemDrawingRecoloringImages

' 2106fb9a-4d60-4dcf-9220-9f189a6c4d19
' How to: Translate Image Colors
    Private Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim image As New Bitmap("ColorBars.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

        Dim colorMatrixElements As Single()() = { _
           New Single() {1, 0, 0, 0, 0}, _
           New Single() {0, 1, 0, 0, 0}, _
           New Single() {0, 0, 1, 0, 0}, _
           New Single() {0, 0, 0, 1, 0}, _
           New Single() {0.75F, 0, 0, 0, 1}}

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

        ' </snippet11>
    End Sub
' 44df4556-a433-49c0-ac0f-9a12063a5860
' How to: Use a Color Matrix to Transform a Single Color
    Private Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim image As New Bitmap("InputColor.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

        ' The following matrix consists of the following transformations:
        ' red scaling factor of 2
        ' green scaling factor of 1
        ' blue scaling factor of 1
        ' alpha scaling factor of 1
        ' three translations of 0.2
        Dim colorMatrixElements As Single()() = { _
           New Single() {2, 0, 0, 0, 0}, _
           New Single() {0, 1, 0, 0, 0}, _
           New Single() {0, 0, 1, 0, 0}, _
           New Single() {0, 0, 0, 1, 0}, _
           New Single() {0.2F, 0.2F, 0.2F, 0, 1}}

        Dim colorMatrix As New ColorMatrix(colorMatrixElements)

        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(image, 10, 10)

        e.Graphics.DrawImage( _
           image, _
           New Rectangle(120, 10, width, height), _
           0, _
           0, _
           width, _
           height, _
           GraphicsUnit.Pixel, _
           imageAttributes)

        ' </snippet21>
    End Sub
' 977df1ce-8665-42d4-9fb1-ef7f0ff63419
' How to: Use a Color Remap Table
    Private Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim image As New Bitmap("RemapInput.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        Dim colorMap As New ColorMap()

        colorMap.OldColor = Color.FromArgb(255, 255, 0, 0) ' opaque red
        colorMap.NewColor = Color.FromArgb(255, 0, 0, 255) ' opaque blue
        Dim remapTable As ColorMap() = {colorMap}

        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap)

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

        ' </snippet31>
    End Sub
' df23c887-7fd6-4b15-ad94-e30b5bd4b849
' Using Transformations to Scale Colors
    Private Sub Method41(ByVal e As PaintEventArgs)
        ' <snippet41>
        Dim image As New Bitmap("ColorBars2.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

        Dim colorMatrixElements As Single()() = { _
           New Single() {1, 0, 0, 0, 0}, _
           New Single() {0, 1, 0, 0, 0}, _
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

        ' </snippet41>
    End Sub
    Private Sub Method42(ByVal e As PaintEventArgs)
        ' <snippet42>
        Dim image As New Bitmap("ColorBars.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

        Dim colorMatrixElements As Single()() = { _
           New Single() {0.75F, 0, 0, 0, 0}, _
           New Single() {0, 0.65F, 0, 0, 0}, _
           New Single() {0, 0, 0.5F, 0, 0}, _
           New Single() {0, 0, 0, 1, 0}, _
           New Single() {0, 0, 0, 0, 1}}

        Dim colorMatrix As New ColorMatrix(colorMatrixElements)

        imageAttributes.SetColorMatrix( _
           colorMatrix, _
           ColorMatrixFlag.Default, _
           ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(image, 10, 10, width, height)

        ' Pass in the destination rectangle, and the upper-left corner, width, 
        ' and height of the source rectangle as in the previous example.
        e.Graphics.DrawImage( _
           image, _
           New Rectangle(150, 10, width, height), _
           0, 0, _
           width, _
           height, _
           GraphicsUnit.Pixel, _
           imageAttributes)

        ' </snippet42>
    End Sub
End Class

