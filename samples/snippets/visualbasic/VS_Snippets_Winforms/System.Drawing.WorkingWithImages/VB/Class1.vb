Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D


Public Class SystemDrawingWorkingWithImages
Inherits Form

	<STAThread()> _ 
	Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New SystemDrawingWorkingWithImages())

    End Sub

    ' 053e3360-bca0-4b25-9afa-0e77a6f17b03
    ' How to: Crop and Scale Images
    Private Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim image As New Bitmap("Apple.gif")

        ' Draw the image unaltered with its upper-left corner at (0, 0).
        e.Graphics.DrawImage(image, 0, 0)

        ' Make the destination rectangle 30 percent wider and
        ' 30 percent taller than the original image.
        ' Put the upper-left corner of the destination
        ' rectangle at (150, 20).
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        Dim destinationRect As New RectangleF( _
            150, _
            20, _
            1.3F * width, _
            1.3F * height)

        ' Draw a portion of the image. Scale that portion of the image
        ' so that it fills the destination rectangle.
        Dim sourceRect As New RectangleF(0, 0, 0.75F * width, 0.75F * height)
        e.Graphics.DrawImage( _
            image, _
            destinationRect, _
            sourceRect, _
            GraphicsUnit.Pixel)

        ' </snippet11>
    End Sub
    ' 5bc558d7-b326-4050-a834-b8600da0de95
    ' How to: Load and Display Bitmaps
    Private Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim bitmap As New Bitmap("Grapes.jpg")
        e.Graphics.DrawImage(bitmap, 60, 10)

        ' </snippet21>
    End Sub
    ' 5fe2c95d-8653-4d55-bf0d-e5afa28f223b
    ' How to: Improve Performance by Avoiding Automatic Scaling
    Private Sub Method31(ByVal e As PaintEventArgs)
        Dim image As New Bitmap("Texture.jpg")
        ' <snippet31>
        e.Graphics.DrawImage(image, 50, 30) ' upper-left corner at (50, 30)
        ' </snippet31>
    End Sub
    Private Sub Method32(ByVal e As PaintEventArgs)
        ' <snippet32>
        Dim image As New Bitmap("Texture.jpg")

        e.Graphics.DrawImage(image, 10, 10)
        e.Graphics.DrawImage(image, 120, 10, image.Width, image.Height)
        ' </snippet32>
    End Sub
    ' 60af1714-f148-4d85-a739-0557965ffa73
    ' How to: Load and Display Metafiles
    Private Sub Method41(ByVal e As PaintEventArgs)
        ' <snippet41>
        Dim metafile As New Metafile("SampleMetafile.emf")
        e.Graphics.DrawImage(metafile, 60, 10)

        ' </snippet41>
    End Sub
    ' 72ec0b31-0be7-444a-9575-1dbcb864e0be
    ' How to: Read Image Metadata
    Private Sub Method51(ByVal e As PaintEventArgs)
        ' <snippet51>
        'Create an Image object. 
        Dim image As Bitmap = New Bitmap("c:\FakePhoto.jpg")

        'Get the PropertyItems property from image.
        Dim propItems As PropertyItem() = image.PropertyItems

        'Set up the display.
        Dim font As New Font("Arial", 12)
        Dim blackBrush As New SolidBrush(Color.Black)
        Dim X As Integer = 0
        Dim Y As Integer = 0

        'For each PropertyItem in the array, display the ID, type, and length.
        Dim count As Integer = 0
        Dim propItem As PropertyItem
        For Each propItem In propItems
            e.Graphics.DrawString( _
               "Property Item " & count.ToString(), _
               font, _
               blackBrush, _
               X, Y)

            Y += font.Height

            e.Graphics.DrawString( _
               "   iD: 0x" & propItem.Id.ToString("x"), _
               font, _
               blackBrush, _
               X, Y)

            Y += font.Height

            e.Graphics.DrawString( _
               "   type: " & propItem.Type.ToString(), _
               font, _
               blackBrush, _
               X, Y)

            Y += font.Height

            e.Graphics.DrawString( _
               "   length: " & propItem.Len.ToString() & " bytes", _
               font, _
               blackBrush, _
               X, Y)

            Y += font.Height

            count += 1
        Next propItem
        'Convert the value of the second property to a string, and display it.
        Dim encoding As New System.Text.ASCIIEncoding()
        Dim manufacturer As String = encoding.GetString(propItems(1).Value)

        e.Graphics.DrawString( _
           "The equipment make is " & manufacturer & ".", _
           font, _
           blackBrush, _
           X, Y)

        ' </snippet51>
    End Sub
    ' a3bf97eb-63ed-425a-ba07-dcc65efb567c
    ' How to: Rotate, Reflect, and Skew Images
    Private Sub Method61(ByVal e As PaintEventArgs)
        ' <snippet61>
        ' New Point(200, 20)  = destination for upper-left point of original
        ' New Point(110, 100) = destination for upper-right point of original
        ' New Point(250, 30)  = destination for lower-left point of original
        Dim destinationPoints As Point() = { _
            New Point(200, 20), _
            New Point(110, 100), _
            New Point(250, 30)}

        Dim image As New Bitmap("Stripes.bmp")

        ' Draw the image unaltered with its upper-left corner at (0, 0).
        e.Graphics.DrawImage(image, 0, 0)

        ' Draw the image mapped to the parallelogram.
        e.Graphics.DrawImage(image, destinationPoints)

        ' </snippet61>
    End Sub
    ' e956242a-1e5b-4217-a3cf-5f3fb45d00ba
    ' How to: Create Thumbnail Images

    
        ' <snippet71>
	Public Function ThumbnailCallback() As Boolean 
    		Return True 
	End Function 

	Private Sub GetThumbnail(ByVal e As PaintEventArgs) 
    
    		Dim callback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback) 
    		Dim image As Image = New Bitmap("c:\FakePhoto.jpg") 
    		Dim pThumbnail As Image = image.GetThumbnailImage(100, 100, callback, New IntPtr()) 
    		e.Graphics.DrawImage(pThumbnail, 10, 10, pThumbnail.Width, pThumbnail.Height) 
	End Sub 
        ' </snippet71>

  
    ' fde9bccf-8aa5-4b0d-ba4b-788740627b02
    ' How to: Use Interpolation Mode to Control Image Quality During Scaling
    Private Sub Method81(ByVal e As PaintEventArgs)
        ' <snippet81>
        Dim image As New Bitmap("GrapeBunch.bmp")
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

        ' Draw the image with no shrinking or stretching. Pass in the destination
        ' rectangle (2nd argument), the upper-left corner (3rd and 4th arguments),
        ' width (5th argument),  and height (6th argument) of the source 
        ' rectangle.
        e.Graphics.DrawImage( _
            image, _
            New Rectangle(10, 10, width, height), _
            0, _
            0, _
            width, _
            height, _
            GraphicsUnit.Pixel, _
            Nothing)

        ' Shrink the image using low-quality interpolation. 
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor

        ' Pass in the destination rectangle, and the upper-left corner, width, 
        ' and height of the source rectangle as above.
        e.Graphics.DrawImage( _
        image, _
        New Rectangle(10, 250, CInt(0.6 * width), CInt(0.6 * height)), _
        0, _
        0, _
        width, _
        height, _
        GraphicsUnit.Pixel)

        ' Shrink the image using medium-quality interpolation.
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear

        ' Pass in the destination rectangle, and the upper-left corner, width, 
        ' and height of the source rectangle as above.
        e.Graphics.DrawImage( _
        image, _
        New Rectangle(150, 250, CInt(0.6 * width), _
        CInt(0.6 * height)), _
        0, _
        0, _
        width, _
        height, _
        GraphicsUnit.Pixel)

        ' Shrink the image using high-quality interpolation.
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic

        ' Pass in the destination rectangle, and the upper-left corner, width, 
        ' and height of the source rectangle as above.
        e.Graphics.DrawImage( _
            image, _
            New Rectangle(290, 250, CInt(0.6 * width), CInt(0.6 * height)), _
            0, _
            0, _
            width, _
            height, _
            GraphicsUnit.Pixel)

        ' </snippet81>
    End Sub
End Class

