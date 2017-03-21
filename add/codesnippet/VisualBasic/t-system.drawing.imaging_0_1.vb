    Private Sub VaryQualityLevel()
        ' Get a bitmap.
        Dim bmp1 As New Bitmap("c:\TestPhoto.jpg")
        Dim jpgEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)

        ' Create an Encoder object based on the GUID
        ' for the Quality parameter category.
        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        Dim myEncoderParameters As New EncoderParameters(1)

        Dim myEncoderParameter As New EncoderParameter(myEncoder, 50&)
        myEncoderParameters.Param(0) = myEncoderParameter
        bmp1.Save("c:\TestPhotoQualityFifty.jpg", jpgEncoder, myEncoderParameters)

        myEncoderParameter = New EncoderParameter(myEncoder, 100&)
        myEncoderParameters.Param(0) = myEncoderParameter
        bmp1.Save("c:\TestPhotoQualityHundred.jpg", jpgEncoder, myEncoderParameters)

        ' Save the bitmap as a JPG file with zero quality level compression.
        myEncoderParameter = New EncoderParameter(myEncoder, 0&)
        myEncoderParameters.Param(0) = myEncoderParameter
        bmp1.Save("c:\TestPhotoQualityZero.jpg", jpgEncoder, myEncoderParameters)

    End Sub 'VaryQualityLevel
