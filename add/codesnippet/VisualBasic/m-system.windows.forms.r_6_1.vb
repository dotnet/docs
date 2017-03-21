    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        MessageBox.Show(FindMyText(New Char() {"B"c, "r"c, "a"c, "v"c, "o"c}).ToString())
    End Sub


    Public Function FindMyText(ByVal [text]() As Char) As Integer
        ' Initialize the return value to false by default.
        Dim returnValue As Integer = -1

        ' Ensure that a search string has been specified and a valid start point.
        If [text].Length > 0 Then
            ' Obtain the location of the first character found in the control
            ' that matches any of the characters in the char array.
            Dim indexToText As Integer = richTextBox1.Find([text])
            ' Determine whether the text was found in richTextBox1.
            If indexToText >= 0 Then
                ' Return the location of the character.
                returnValue = indexToText
            End If
        End If

        Return returnValue
    End Function