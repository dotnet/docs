' Snippet for: F:System.Drawing.Imaging.Encoder.ColorDepth

' <snippet1>
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Microsoft.VisualBasic


Class Example_SetColorDepth

    Public Shared Sub Main()
        Dim myBitmap As Bitmap
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        ' Create a Bitmap object based on a BMP file.
        myBitmap = New Bitmap("C:\Documents and Settings\All Users\Documents\My Music\music.bmp")

        ' Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff")

        ' Create an Encoder object based on the GUID
        ' for the ColorDepth parameter category.
        myEncoder = Encoder.ColorDepth

        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)

        ' Save the image with a color depth of 24 bits per pixel.
        myEncoderParameter = New EncoderParameter(myEncoder, CType(24L, Int32))
        myEncoderParameters.Param(0) = myEncoderParameter
        myBitmap.Save("Shapes24bpp.tiff", myImageCodecInfo, myEncoderParameters)

    End Sub


    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function
End Class
' </snippet1>


