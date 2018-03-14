
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Imaging



Public Class Form1
    Inherits Form
    
    Public Sub New()
        
    End Sub 'New


    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())

    End Sub


    '<snippet1>
    Private Sub GetImageEncodersExample(ByVal e As PaintEventArgs)
        ' Get an array of available encoders.
        Dim myCodecs() As ImageCodecInfo
        myCodecs = ImageCodecInfo.GetImageEncoders()
        Dim numCodecs As Integer = myCodecs.GetLength(0)

        ' Set up display variables.
        Dim foreColor As Color = Color.Black
        Dim font As New Font("Arial", 8)
        Dim i As Integer = 0

        ' Check to determine whether any codecs were found.
        If numCodecs > 0 Then

            ' Set up an array to hold codec information. There are 9
            ' information elements plus 1 space for each codec, so 10 times
            ' the number of codecs found is allocated.
            Dim myCodecInfo(numCodecs * 10) As String

            ' Write all the codec information to the array.
            For i = 0 To numCodecs - 1
                myCodecInfo((i * 10)) = "Codec Name = " + myCodecs(i).CodecName
                myCodecInfo((i * 10 + 1)) = "Class ID = " + myCodecs(i).Clsid.ToString()
                myCodecInfo((i * 10 + 2)) = "DLL Name = " + myCodecs(i).DllName
                myCodecInfo((i * 10 + 3)) = "Filename Ext. = " + myCodecs(i).FilenameExtension
                myCodecInfo((i * 10 + 4)) = "Flags = " + myCodecs(i).Flags.ToString()
                myCodecInfo((i * 10 + 5)) = "Format Descrip. = " + myCodecs(i).FormatDescription
                myCodecInfo((i * 10 + 6)) = "Format ID = " + myCodecs(i).FormatID.ToString()
                myCodecInfo((i * 10 + 7)) = "MimeType = " + myCodecs(i).MimeType
                myCodecInfo((i * 10 + 8)) = "Version = " + myCodecs(i).Version.ToString()
                myCodecInfo((i * 10 + 9)) = " "
            Next i
            Dim numMyCodecInfo As Integer = myCodecInfo.GetLength(0)

            ' Render all of the information to the screen.
            Dim j As Integer = 20
            For i = 0 To numMyCodecInfo - 1
                e.Graphics.DrawString(myCodecInfo(i), _
                    font, New SolidBrush(foreColor), 20, j)
                j += 12
            Next i
        Else
            e.Graphics.DrawString("No Codecs Found", _
                font, New SolidBrush(foreColor), 20, 20)
        End If

    End Sub
    '</snippet1>

    '<snippet2>
    Private Sub GetImageDecodersExample(ByVal e As PaintEventArgs)
        ' Get an array of available decoders.
        Dim myCodecs() As ImageCodecInfo
        myCodecs = ImageCodecInfo.GetImageDecoders()
        Dim numCodecs As Integer = myCodecs.GetLength(0)

        ' Set up display variables.
        Dim foreColor As Color = Color.Black
        Dim font As New Font("Arial", 8)
        Dim i As Integer = 0

        ' Check to determine whether any codecs were found.
        If numCodecs > 0 Then
            ' Set up an array to hold codec information. There are 9
            ' information elements plus 1 space for each codec, so 10 times
            ' the number of codecs found is allocated.
            Dim myCodecInfo(numCodecs * 10) As String

            ' Write all the codec information to the array.
            For i = 0 To numCodecs - 1
                myCodecInfo((i * 10)) = "Codec Name = " + myCodecs(i).CodecName
                myCodecInfo((i * 10 + 1)) = "Class ID = " + myCodecs(i).Clsid.ToString()
                myCodecInfo((i * 10 + 2)) = "DLL Name = " + myCodecs(i).DllName
                myCodecInfo((i * 10 + 3)) = "Filename Ext. = " + myCodecs(i).FilenameExtension
                myCodecInfo((i * 10 + 4)) = "Flags = " + myCodecs(i).Flags.ToString()
                myCodecInfo((i * 10 + 5)) = "Format Descrip. = " + myCodecs(i).FormatDescription
                myCodecInfo((i * 10 + 6)) = "Format ID = " + myCodecs(i).FormatID.ToString()
                myCodecInfo((i * 10 + 7)) = "MimeType = " + myCodecs(i).MimeType
                myCodecInfo((i * 10 + 8)) = "Version = " + myCodecs(i).Version.ToString()
                myCodecInfo((i * 10 + 9)) = " "
            Next i
            Dim numMyCodecInfo As Integer = myCodecInfo.GetLength(0)

            ' Render all of the information to the screen.
            Dim j As Integer = 20
            For i = 0 To numMyCodecInfo - 1
                e.Graphics.DrawString(myCodecInfo(i), _
                    font, New SolidBrush(foreColor), 20, j)
                j += 12
            Next i
        Else
            e.Graphics.DrawString("No Codecs Found", _
                font, New SolidBrush(foreColor), 20, 20)
        End If
    End Sub
    '</snippet2>

    '<snippet3>
    Private Sub GetSupportedParameters(ByVal e As PaintEventArgs)
        Dim bitmap1 As New Bitmap(1, 1)
        Dim jpgEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        Dim paramList As EncoderParameters = _
        bitmap1.GetEncoderParameterList(jpgEncoder.Clsid)
        Dim encParams As EncoderParameter() = paramList.Param
        Dim paramInfo As New StringBuilder()

        Dim i As Integer
        For i = 0 To encParams.Length - 1
            paramInfo.Append("Param " & i & " holds " & _
                encParams(i).NumberOfValues & " items of type " & _
                encParams(i).Type.ToString() & vbCr & vbLf & "Guid category: " & _
                 encParams(i).Encoder.Guid.ToString() & vbCr & vbLf)
        Next i

        e.Graphics.DrawString(paramInfo.ToString(), _
           Me.Font, Brushes.Red, 10.0F, 10.0F)
    End Sub

    '<snippet6>
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function
    '</snippet6>
    '</snippet3>

    '<snippet4>
    Private Sub SaveBmpAsPNG()
        Dim bmp1 As New Bitmap(GetType(Button), "Button.bmp")
        bmp1.Save("c:\button.png", ImageFormat.Png)

    End Sub
    '</snippet4>

    '<snippet8>
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

    '</snippet8>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    'SaveBmpAsPng();

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles Me.Paint
        'GetSupportedParameters(e)
        'GetImageDecodersExample(e)
        GetImageEncodersExample(e)
        SaveBmpAsPNG()
        VaryQualityLevel()

    End Sub
End Class

