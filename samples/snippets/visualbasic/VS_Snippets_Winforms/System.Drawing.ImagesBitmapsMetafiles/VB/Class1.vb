Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Imaging

Public Class Form1
    Inherits Form

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    ' 09f0c07a-19c0-43b4-90a2-862a10545ce8
    ' Drawing, Positioning, and Cloning Images in GDI+
    Public Sub Method11()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet11>
        Dim myBitmap As New Bitmap("Climber.jpg")
        myGraphics.DrawImage(myBitmap, 10, 10)

        ' </snippet11>
    End Sub
    Public Sub Method12()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet12>
        Dim myBMP As New Bitmap("SpaceCadet.bmp")
        Dim myGIF As New Bitmap("Soda.gif")
        Dim myJPEG As New Bitmap("Mango.jpg")
        Dim myPNG As New Bitmap("Flowers.png")
        Dim myTIFF As New Bitmap("MS.tif")

        myGraphics.DrawImage(myBMP, 10, 10)
        myGraphics.DrawImage(myGIF, 220, 10)
        myGraphics.DrawImage(myJPEG, 280, 10)
        myGraphics.DrawImage(myPNG, 150, 200)
        myGraphics.DrawImage(myTIFF, 300, 200)

        ' </snippet12>
    End Sub
    Public Sub Method13()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet13>
        Dim originalBitmap As New Bitmap("Spiral.png")
        Dim sourceRectangle As New Rectangle(0, 0, originalBitmap.Width, _
           CType(originalBitmap.Height / 2, Integer))

        Dim secondBitmap As Bitmap = originalBitmap.Clone(sourceRectangle, _
           PixelFormat.DontCare)

        myGraphics.DrawImage(originalBitmap, 10, 10)
        myGraphics.DrawImage(secondBitmap, 150, 10)

        ' </snippet13>
    End Sub
    ' 51da872c-c783-440f-8bf6-1e580a966c31
    ' Metafiles in GDI+
    ' <snippet21>
    Public Sub Example_DisplayMetafile(ByVal e As PaintEventArgs)
        Dim myGraphics As Graphics = e.Graphics
        Dim myMetafile As New Metafile("SampleMetafile.emf")
        myGraphics.DrawImage(myMetafile, 100, 100)
    End Sub

    ' </snippet21>
    ' ad5daf26-005f-45bc-a2af-e0e97777a21a
    ' Cropping and Scaling Images in GDI+
    Public Sub Method31()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet31>
        Dim myBitmap As New Bitmap("Spiral.png")

        Dim expansionRectangle As New Rectangle(135, 10, _
           myBitmap.Width, myBitmap.Height)

        Dim compressionRectangle As New Rectangle(300, 10, _
           CType(myBitmap.Width / 2, Integer), CType(myBitmap.Height / 2, Integer))

        myGraphics.DrawImage(myBitmap, 10, 10)
        myGraphics.DrawImage(myBitmap, expansionRectangle)
        myGraphics.DrawImage(myBitmap, compressionRectangle)

        ' </snippet31>
    End Sub
    Public Sub Method32()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet32>
        Dim myBitmap As New Bitmap("Runner.jpg")

        ' One hand of the runner
        Dim sourceRectangle As New Rectangle(80, 70, 80, 45)

        ' Compressed hand
        Dim destRectangle1 As New Rectangle(200, 10, 20, 16)

        ' Expanded hand
        Dim destRectangle2 As New Rectangle(200, 40, 200, 160)

        ' Draw the original image at (0, 0).
        myGraphics.DrawImage(myBitmap, 0, 0)

        ' Draw the compressed hand.
        myGraphics.DrawImage( _
           myBitmap, destRectangle1, sourceRectangle, GraphicsUnit.Pixel)

        ' Draw the expanded hand. 
        myGraphics.DrawImage( _
           myBitmap, destRectangle2, sourceRectangle, GraphicsUnit.Pixel)

        ' </snippet32>
    End Sub
End Class

