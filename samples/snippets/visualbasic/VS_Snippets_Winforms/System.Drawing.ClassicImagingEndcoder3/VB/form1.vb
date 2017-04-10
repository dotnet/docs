' Snippet for: F:System.Drawing.Imaging.Encoder.Quality
' <snippet3>
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging


Class Example_SetJPEGQuality

    Public Shared Sub Main()
        Dim myBitmap As Bitmap
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        ' Create a Bitmap object based on a BMP file.
        myBitmap = New Bitmap("Shapes.bmp")

        ' Get an ImageCodecInfo object that represents the JPEG codec.
        myImageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg)

        ' Create an Encoder object based on the GUID
        ' for the Quality parameter category.
        myEncoder = Encoder.Quality

        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)

        ' Save the bitmap as a JPEG file with quality level 25.
        myEncoderParameter = New EncoderParameter(myEncoder, CType(25L, Int32))
        myEncoderParameters.Param(0) = myEncoderParameter
        myBitmap.Save("Shapes025.jpg", myImageCodecInfo, myEncoderParameters)

        ' Save the bitmap as a JPEG file with quality level 50.
        myEncoderParameter = New EncoderParameter(myEncoder, CType(50L, Int32))
        myEncoderParameters.Param(0) = myEncoderParameter
        myBitmap.Save("Shapes050.jpg", myImageCodecInfo, myEncoderParameters)

        ' Save the bitmap as a JPEG file with quality level 75.
        myEncoderParameter = New EncoderParameter(myEncoder, CType(75L, Int32))
        myEncoderParameters.Param(0) = myEncoderParameter
        myBitmap.Save("Shapes075.jpg", myImageCodecInfo, myEncoderParameters)

    End Sub 'Main

    Private Shared Function GetEncoderInfo(ByVal format As ImageFormat) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).FormatID = format.Guid Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo
End Class 'Example_SetJPEGQuality
' </snippet3>
