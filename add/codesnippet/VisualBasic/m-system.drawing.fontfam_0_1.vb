    Public Sub Equals_Example(ByVal e As PaintEventArgs)

        ' Create two FontFamily objects.
        Dim firstFontFamily As New FontFamily("Arial")
        Dim secondFontFamily As New FontFamily("Times New Roman")

        ' Check to see if the two font families are equivalent.
        Dim equalFonts As Boolean = _
        firstFontFamily.Equals(secondFontFamily)

        ' Display the result of the test in a message box.
        MessageBox.Show(equalFonts.ToString())
    End Sub