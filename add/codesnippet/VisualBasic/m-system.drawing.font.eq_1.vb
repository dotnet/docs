    Public Sub Equals_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim firstFont As New Font("Arial", 16)

        ' Create a second Font object.
        Dim secondFont As New Font(New FontFamily("Arial"), 16)

        ' Test to see if firstFont is identical to secondFont.
        Dim fontTest As Boolean = firstFont.Equals(secondFont)

        ' Display a message box with the result of the test.
        MessageBox.Show(fontTest.ToString())
    End Sub