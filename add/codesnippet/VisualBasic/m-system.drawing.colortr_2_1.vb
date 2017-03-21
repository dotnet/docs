    Public Sub ToOle_Example(ByVal e As PaintEventArgs)

        ' Create an instance of a Color structure.
        Dim myColor As Color = Color.Green

        ' Translate myColor to an OLE color.
        Dim oleColor As Integer = ColorTranslator.ToOle(myColor)

        ' Show a message box with the value of htmlColor.
        MessageBox.Show(oleColor.ToString())
    End Sub