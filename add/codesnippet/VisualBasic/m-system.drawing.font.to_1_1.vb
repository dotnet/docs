    Public Sub ToString_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Get a string that represents myFont.
        Dim fontString As String = myFont.ToString()

        ' Display a message box with fontString.
        MessageBox.Show(fontString)
    End Sub