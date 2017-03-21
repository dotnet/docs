    Public Sub ToWin32_Example(ByVal e As PaintEventArgs)

        ' Create an instance of a Color structure.
        Dim myColor As Color = Color.Red

        ' Translate myColor to an OLE color.
        Dim winColor As Integer = ColorTranslator.ToWin32(myColor)

        ' Show a message box with the value of winColor.
        MessageBox.Show(winColor)
    End Sub