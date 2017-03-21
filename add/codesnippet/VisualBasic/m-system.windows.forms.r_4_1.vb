    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        MessageBox.Show(FindMyText(New Char() {"B"c, "r"c, "a"c, "v"c, "o"c}, 5).ToString())
    End Sub


    Public Function FindMyText(ByVal text() As Char, ByVal start As Integer) As Integer
        ' Initialize the return value to false by default.
        Dim returnValue As Integer = -1

        ' Ensure that a valid char array has been specified and a valid start point.
        If [text].Length > 0 And start >= 0 Then
            ' Obtain the location of the first character found in the control
            ' that matches any of the characters in the char array.
            Dim indexToText As Integer = richTextBox1.Find([text], start)
            ' Determine whether any of the chars are found in richTextBox1.
            If indexToText >= 0 Then
                ' Return the location of the character.
                returnValue = indexToText
            End If
        End If

        Return returnValue
    End Function