    Public Sub GetImageEncodersExample(ByVal e As PaintEventArgs)

        ' Get an array of available codecs.
        Dim myEncoders() As ImageCodecInfo
        myEncoders = ImageCodecInfo.GetImageEncoders()
        Dim numEncoders As Integer = myEncoders.GetLength(0)
        Dim strNumEncoders As String = numEncoders.ToString()
        Dim foreColor As Color = Color.Black
        Dim font As New Font("Arial", 8)
        Dim i As Integer = 0

        ' Get the info. for all encoders in the array.
        If numEncoders > 0 Then
            Dim myEncoderInfo(numEncoders * 10) As String
            For i = 0 To numEncoders - 1
                myEncoderInfo((i * 10)) = "Codec Name = " _
                + myEncoders(i).CodecName
                myEncoderInfo((i * 10 + 1)) = "Class ID = " _
                + myEncoders(i).Clsid.ToString()
                myEncoderInfo((i * 10 + 2)) = "DLL Name = " _
                + myEncoders(i).DllName
                myEncoderInfo((i * 10 + 3)) = "Filename Ext. = " _
                + myEncoders(i).FilenameExtension
                myEncoderInfo((i * 10 + 4)) = "Flags = " _
                + myEncoders(i).Flags.ToString()
                myEncoderInfo((i * 10 + 5)) = "Format Descrip. = " _
                + myEncoders(i).FormatDescription
                myEncoderInfo((i * 10 + 6)) = "Format ID = " _
                + myEncoders(i).FormatID.ToString()
                myEncoderInfo((i * 10 + 7)) = "MimeType = " _
                + myEncoders(i).MimeType
                myEncoderInfo((i * 10 + 8)) = "Version = " _
                + myEncoders(i).Version.ToString()
                myEncoderInfo((i * 10 + 9)) = " "
            Next i
            Dim numMyEncoderInfo As Integer = myEncoderInfo.GetLength(0)

            ' Render to the screen all the information.
            Dim j As Integer = 20
            For i = 0 To numMyEncoderInfo - 1
                e.Graphics.DrawString(myEncoderInfo(i), font, _
                New SolidBrush(foreColor), 20, j)
                j += 12
            Next i
        Else
            e.Graphics.DrawString("No Encoders Found", font, _
            New SolidBrush(foreColor), 20, 20)
        End If
    End Sub