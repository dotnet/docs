Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class SystemDrawingAlphaBlending

' 8f2508af-f495-4223-b5cc-646cbbb520eb
' How to: Draw Opaque and Semitransparent Lines
    Public Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim bitmap As New Bitmap("Texture1.jpg")
        e.Graphics.DrawImage(bitmap, 10, 5, bitmap.Width, bitmap.Height)

        Dim opaquePen As New Pen(Color.FromArgb(255, 0, 0, 255), 15)
        Dim semiTransPen As New Pen(Color.FromArgb(128, 0, 0, 255), 15)

        e.Graphics.DrawLine(opaquePen, 0, 20, 100, 20)
        e.Graphics.DrawLine(semiTransPen, 0, 40, 100, 40)

        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected
        e.Graphics.DrawLine(semiTransPen, 0, 60, 100, 60)

        ' </snippet11>
    End Sub
' a27121e6-f7e9-4c09-84e2-f05aa9d2a1bb
' How to: Use a Color Matrix to Set Alpha Values in Images
    Public Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        ' Create the Bitmap object and load it with the texture image.
        Dim bitmap As New Bitmap("Texture.jpg")

        ' Initialize the color matrix.
        ' Note the value 0.8 in row 4, column 4.
        Dim matrixItems As Single()() = { _
           New Single() {1, 0, 0, 0, 0}, _
           New Single() {0, 1, 0, 0, 0}, _
           New Single() {0, 0, 1, 0, 0}, _
           New Single() {0, 0, 0, 0.8F, 0}, _
           New Single() {0, 0, 0, 0, 1}}

        Dim colorMatrix As New ColorMatrix(matrixItems)

        ' Create an ImageAttributes object and set its color matrix.
        Dim imageAtt As New ImageAttributes()
        imageAtt.SetColorMatrix( _
           colorMatrix, _
           ColorMatrixFlag.Default, _
           ColorAdjustType.Bitmap)

        ' First draw a wide black line.
        e.Graphics.DrawLine( _
           New Pen(Color.Black, 25), _
           New Point(10, 35), _
           New Point(200, 35))

        ' Now draw the semitransparent bitmap image.
        Dim iWidth As Integer = bitmap.Width
        Dim iHeight As Integer = bitmap.Height

        ' Pass in the destination rectangle (2nd argument) and the x _
        ' coordinate (3rd argument), x coordinate (4th argument), width _
        ' (5th argument), and height (6th argument) of the source rectangle.
        e.Graphics.DrawImage( _
           bitmap, _
           New Rectangle(30, 0, iWidth, iHeight), _
           0.0F, _
           0.0F, _
           iWidth, _
           iHeight, _
           GraphicsUnit.Pixel, _
           imageAtt)

        ' </snippet21>
    End Sub
' a4f6f6b8-3bc8-440a-84af-d62ef0f8ff40
' How to: Draw with Opaque and Semitransparent Brushes
    Public Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim bitmap As New Bitmap("Texture1.jpg")
        e.Graphics.DrawImage(bitmap, 50, 50, bitmap.Width, bitmap.Height)

        Dim opaqueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim semiTransBrush As New SolidBrush(Color.FromArgb(128, 0, 0, 255))

        e.Graphics.FillEllipse(opaqueBrush, 35, 45, 45, 30)
        e.Graphics.FillEllipse(semiTransBrush, 86, 45, 45, 30)

        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected
        e.Graphics.FillEllipse(semiTransBrush, 40, 90, 86, 30)

        ' </snippet31>
    End Sub
' f331df2d-b395-4b0a-95be-24fec8c9bbb5
' How to: Use Compositing Mode to Control Alpha Blending
    Public Sub Method41()
        ' Create a blank bitmap.
        Dim myBitmap As New Bitmap(180, 100)

        ' Create a Graphics object that we can use to draw on the bitmap.
        Dim bitmapGraphics As Graphics = Graphics.FromImage(myBitmap)
        ' <snippet41>
        bitmapGraphics.CompositingMode = CompositingMode.SourceCopy

        ' </snippet41>
    End Sub
    Public Sub Method42()
        ' Create a blank bitmap.
        Dim myBitmap As New Bitmap(180, 100)

        ' Create a Graphics object that we can use to draw on the bitmap.
        Dim bitmapGraphics As Graphics = Graphics.FromImage(myBitmap)
        ' <snippet42>
        bitmapGraphics.CompositingMode = CompositingMode.SourceOver

        ' </snippet42>
    End Sub
    Public Sub Method43(ByVal e As PaintEventArgs)
        ' <snippet43>
        ' Create a blank bitmap.
        Dim myBitmap As New Bitmap(180, 100)

        ' Create a Graphics object that we can use to draw on the bitmap.
        Dim bitmapGraphics As Graphics = Graphics.FromImage(myBitmap)

        ' Create a red brush and a green brush, each with an alpha value of 160.
        Dim redBrush As New SolidBrush(Color.FromArgb(160, 255, 0, 0))
        Dim greenBrush As New SolidBrush(Color.FromArgb(160, 0, 255, 0))

        ' Set the compositing mode so that when we draw overlapping ellipses,
        ' the colors of the ellipses are not blended.
        bitmapGraphics.CompositingMode = CompositingMode.SourceCopy

        ' Fill an ellipse using a red brush that has an alpha value of 160.
        bitmapGraphics.FillEllipse(redBrush, 0, 0, 150, 70)

        ' Fill a second ellipse using a green brush that has an alpha value of 
        ' 160. The green ellipse overlaps the red ellipse, but the green is not 
        ' blended with the red.
        bitmapGraphics.FillEllipse(greenBrush, 30, 30, 150, 70)

        'Set the compositing quality of the form's Graphics object. 
        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected

        ' Draw a multicolored background.
        Dim colorBrush As New SolidBrush(Color.Aqua)
        e.Graphics.FillRectangle(colorBrush, 200, 0, 60, 100)
        colorBrush.Color = Color.Yellow
        e.Graphics.FillRectangle(colorBrush, 260, 0, 60, 100)
        colorBrush.Color = Color.Fuchsia
        e.Graphics.FillRectangle(colorBrush, 320, 0, 60, 100)

        'Display the bitmap on a white background.
        e.Graphics.DrawImage(myBitmap, 0, 0)

        ' Display the bitmap on a multicolored background.
        e.Graphics.DrawImage(myBitmap, 200, 0)

        ' </snippet43>
    End Sub
End Class

