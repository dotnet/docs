 ' Snippet for: F:System.Drawing.Imaging.Encoder.SaveFlag
' <snippet4>
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging


Class Example_MultiFrame
    
    Public Shared Sub Main() 
        Dim multi As Bitmap
        Dim page2 As Bitmap
        Dim page3 As Bitmap
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters
        
        ' Create three Bitmap objects.
        multi = New Bitmap("Shapes.bmp")
        page2 = New Bitmap("Iron.jpg")
        page3 = New Bitmap("House.png")
        
        ' Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff")
        
        ' Create an Encoder object based on the GUID
        ' for the SaveFlag parameter category.
        myEncoder = Encoder.SaveFlag
        
        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)
        
        ' Save the first page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.MultiFrame))
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.Save("Multiframe.tiff", myImageCodecInfo, myEncoderParameters)
        
        ' Save the second page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.FrameDimensionPage))
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(page2, myEncoderParameters)
        
        ' Save the third page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.FrameDimensionPage))
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(page3, myEncoderParameters)
        
        ' Close the multiple-frame file.
        myEncoderParameter = New EncoderParameter(myEncoder, Fix(EncoderValue.Flush))
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(myEncoderParameters)
    
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
End Class 'Example_MultiFrame
' </snippet4>