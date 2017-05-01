Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetBrushRemapTable(System.Drawing.Imaging.ColorMap[])
    ' <snippet1>
    Public Sub SetBrushRemapTableExample(ByVal e As PaintEventArgs)

        ' Create a color map.
        Dim myColorMap(0) As ColorMap
        myColorMap(0) = New ColorMap
        myColorMap(0).OldColor = Color.Red
        myColorMap(0).NewColor = Color.Green

        ' Create an ImageAttributes object, passing it to the myColorMap

        ' array.
        Dim imageAttr As New System.Drawing.Imaging.ImageAttributes
        imageAttr.SetBrushRemapTable(myColorMap)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetColorKey(System.Drawing.Color,System.Drawing.Color,System.Drawing.Imaging.ColorAdjustType)
    ' <snippet2>
    Public Sub SetColorKeyExample(ByVal e As PaintEventArgs)

        ' Open an Image file, and draw it to the screen.
        Dim myImage As Image = Image.FromFile("Circle.bmp")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create an ImageAttributes object and set the color key.
        Dim lowerColor As Color = Color.FromArgb(245, 0, 0)
        Dim upperColor As Color = Color.FromArgb(255, 0, 0)
        Dim imageAttr As New ImageAttributes
        imageAttr.SetColorKey(lowerColor, upperColor, _
        ColorAdjustType.Default)

        ' Draw the image with the color key set.
        Dim rect As New Rectangle(150, 20, 100, 100)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 100, 100, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetColorMatrix(System.Drawing.Imaging.ColorMatrix)
    ' <snippet3>
    Public Sub SetColorMatrixExample(ByVal e As PaintEventArgs)

        ' Create a rectangle image with all colors set to 128 (medium

        ' gray).
        Dim myBitmap As New Bitmap(50, 50, PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 128, 128, _
        128)), New Rectangle(0, 0, 50, 50))
        myBitmap.Save("Rectangle1.jpg")

        ' Open an Image file and draw it to the screen.
        Dim myImage As Image = Image.FromFile("Rectangle1.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Initialize the color matrix.
        Dim myColorMatrix As New ColorMatrix
        myColorMatrix.Matrix00 = 1.75F
        ' Red
        myColorMatrix.Matrix11 = 1.0F
        ' Green
        myColorMatrix.Matrix22 = 1.0F
        ' Blue
        myColorMatrix.Matrix33 = 1.0F
        ' alpha
        myColorMatrix.Matrix44 = 1.0F
        ' w

        ' Create an ImageAttributes object and set the color matrix.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetColorMatrix(myColorMatrix)

        ' Draw the image using the color matrix.
        Dim rect As New Rectangle(100, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub
    'SetColorMatrixExample
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetGamma(System.Single)
    ' <snippet4>
    Public Sub SetGammaExample(ByVal e As PaintEventArgs)

        ' Create an Image object from the file Camera.jpg, and draw

        ' it to screen.
        Dim myImage As Image = Image.FromFile("Camera.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create an ImageAttributes object and set the gamma to 2.2.
        Dim imageAttr As New System.Drawing.Imaging.ImageAttributes
        imageAttr.SetGamma(2.2F)

        ' Draw the image with gamma set to 2.2.
        Dim rect As New Rectangle(250, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetNoOp
    ' <snippet5>
    Public Sub SetNoOpExample(ByVal e As PaintEventArgs)

        ' Create an Image object from the file Camera.jpg.
        Dim myImage As Image = Image.FromFile("Camera.jpg")

        ' Create an ImageAttributes object, and set the gamma to 0.25.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetGamma(0.25F)

        ' Draw the image with gamma set to 0.25.
        Dim rect1 As New Rectangle(20, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect1, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)

        ' Call the ImageAttributes NoOp method.
        imageAttr.SetNoOp()

        ' Draw the image with gamma set to 0.25, but now NoOp is set,    
        ' so the uncorrected image will be shown.
        Dim rect2 As New Rectangle(250, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect2, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetRemapTable(System.Drawing.Imaging.ColorMap[])
    ' <snippet6>
    Public Sub SetRemapTableExample(ByVal e As PaintEventArgs)

        ' Create a filled, red image and save it to Circle2.jpg.
        Dim myBitmap As New Bitmap(50, 50)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.Clear(Color.White)
        g.FillEllipse(New SolidBrush(Color.Red), New Rectangle(0, 0, _
        50, 50))
        myBitmap.Save("Circle2.jpg")

        ' Create an Image object from the Circle2.jpg file, and draw

        ' it to the screen.
        Dim myImage As Image = Image.FromFile("Circle2.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create a color map.
        Dim myColorMap(0) As ColorMap
        myColorMap(0) = New ColorMap
        myColorMap(0).OldColor = Color.Red
        myColorMap(0).NewColor = Color.Green

        ' Create an ImageAttributes object, and then pass the

        ' myColorMap object to the SetRemapTable method.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetRemapTable(myColorMap)

        ' Draw the image with the remap table set.
        Dim rect As New Rectangle(150, 20, 50, 50)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 50, 50, _
        GraphicsUnit.Pixel, imageAttr)
        ' Image
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetThreshold(System.Single)
    ' <snippet7>
    Public Sub SetThresholdExample(ByVal e As PaintEventArgs)

        ' Open an Image file, and draw it to the screen.
        Dim myImage As Image = Image.FromFile("Camera.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Create an ImageAttributes object, and set its color threshold.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetThreshold(0.7F)

        ' Draw the image with the colors bifurcated.
        Dim rect As New Rectangle(300, 20, 200, 200)
        e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, _
        GraphicsUnit.Pixel, imageAttr)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetWrapMode(System.Drawing.Drawing2D.WrapMode)
    ' <snippet8>
    Public Sub SetWrapModeExample(ByVal e As PaintEventArgs)

        ' Create a filled, red circle, and save it to Circle3.jpg.
        Dim myBitmap As New Bitmap(50, 50)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.Clear(Color.White)
        g.FillEllipse(New SolidBrush(Color.Red), New Rectangle(0, 0, _
        25, 25))
        myBitmap.Save("Circle3.jpg")

        ' Create an Image object from the Circle3.jpg file, and draw

        ' it to the screen.
        Dim myImage As Image = Image.FromFile("Circle3.jpg")
        e.Graphics.DrawImage(myImage, 20, 20)

        ' Set the wrap mode.
        Dim imageAttr As New ImageAttributes
        imageAttr.SetWrapMode(WrapMode.Tile)

        ' Create a TextureBrush.
        Dim brushRect As New Rectangle(0, 0, 25, 25)
        Dim myTBrush As New TextureBrush(myImage, brushRect, imageAttr)

        ' Draw to the screen a rectangle filled with red circles.
        e.Graphics.FillRectangle(myTBrush, 100, 20, 200, 200)
    End Sub
    ' </snippet8>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class

