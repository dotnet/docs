    Public Sub ToHtml_Example(ByVal e As PaintEventArgs)

        ' Create an instance of a Color structure.
        Dim myColor As Color = Color.Red

        ' Translate myColor to an HTML color.
        Dim htmlColor As String = ColorTranslator.ToHtml(myColor)

        ' Show a message box with the value of htmlColor.
        MessageBox.Show(htmlColor)
    End Sub