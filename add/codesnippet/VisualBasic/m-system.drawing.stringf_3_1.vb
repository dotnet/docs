    Public Sub ToStringExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim myFont As New Font("Times New Roman", 14)
        Dim myStringFormat As New StringFormat

        ' String variable to hold the values of the StringFormat object.
        Dim strFmtString As String

        ' Convert the string format object to a string (only certain
        ' information in the object is converted) and display the string.
        strFmtString = myStringFormat.ToString()
        g.DrawString("Before changing properties:   ", myFont, blueBrush, _
        20, 40, myStringFormat)

        ' Change some properties of the string format.
        myStringFormat.Trimming = StringTrimming.None
        myStringFormat.FormatFlags = StringFormatFlags.NoWrap Or _
        StringFormatFlags.NoClip

        ' Convert the string format object to a string and display the
        ' string. The string will be different because the properties of
        ' the string format have changed.
        strFmtString = myStringFormat.ToString()
        g.DrawString("After changing properties:   ", myFont, blueBrush, _
        20, 70, myStringFormat)
    End Sub