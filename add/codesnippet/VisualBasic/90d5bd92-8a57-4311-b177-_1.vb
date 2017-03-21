    Public Function FindMyText(ByVal searchText As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer
        ' Initialize the return value to false by default.
        Dim returnValue As Integer = -1

        ' Ensure that a search string and a valid starting point are specified.
        If searchText.Length > 0 And searchStart >= 0 Then
            ' Ensure that a valid ending value is provided.
            If searchEnd > searchStart Or searchEnd = -1 Then
                ' Obtain the location of the search string in richTextBox1.
            Dim indexToText As Integer = richTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase)
                ' Determine whether the text was found in richTextBox1.
                If indexToText >= 0 Then
                    ' Return the index to the specified search text.
                    returnValue = indexToText
                End If
            End If
        End If

        Return returnValue
    End Function