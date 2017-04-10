 ' Snippet for: F:System.Drawing.Imaging.Encoder.Transformation
' <snippet5>
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging


Class Example_RotateJPEG
    
    Public Shared Sub Main() 
        Dim myBitmap As Bitmap
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters
        
        ' Create a Bitmap object based on a JPEG file.
        myBitmap = New Bitmap("Shapes.jpg")
        
        ' Get an ImageCodecInfo object that represents the JPEG codec.
        myImageCodecInfo = GetEncoderInfo("image/jpeg")
        
        ' Create an Encoder object based on the GUID
        ' for the Transformation parameter category.
        myEncoder = Encoder.Transformation
        
        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)
        
        ' Rotate the image 90 degrees, and save it as a separate JPEG file.
        myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.TransformRotate90))
        myEncoderParameters.Param(0) = myEncoderParameter
        myBitmap.Save("ShapesR90.jpg", myImageCodecInfo, myEncoderParameters)
    
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
End Class 'Example_RotateJPEG
' </snippet5>