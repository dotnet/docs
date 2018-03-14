 ' Snippet for: F:System.Drawing.Imaging.Encoder.Compression
' <snippet2>
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging


Class Example_SetTIFFCompression
    
    Public Shared Sub Main() 
        Dim myBitmap As Bitmap
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters
        
        ' Create a Bitmap object based on a BMP file.
        myBitmap = New Bitmap("Shapes.bmp")
        
        ' Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff")
        
        ' Create an Encoder object based on the GUID
        ' for the Compression parameter category.
        myEncoder = Encoder.Compression
        
        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)
        
        ' Save the bitmap as a TIFF file with LZW compression.
        myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.CompressionLZW))
        myEncoderParameters.Param(0) = myEncoderParameter
        myBitmap.Save("ShapesLZW.tif", myImageCodecInfo, myEncoderParameters)
    
    End Sub 'Main
    
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
    
    End Function 'GetEncoderInfo
End Class 'Example_SetTIFFCompression
' </snippet2>