    ' This method demonstrates retrieving line numbers that 
    ' indicate the location of a particular word
    ' contained in a RichTextBox. The line numbers are zero-based.

    Private Sub Button1_Click(ByVal sender As System.Object, _ 
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Reset the results box.
        TextBox1.Text = ""

        ' Get the word to search from from TextBox2.
        Dim searchWord As String = TextBox2.Text

        Dim index As Integer = 0

        'Declare an ArrayList to store line numbers.
        Dim lineList As New System.Collections.ArrayList
        Do
            ' Find occurrences of the search word, incrementing  
            ' the start index. 
            index = RichTextBox1.Find(searchWord, index + 1, _
                RichTextBoxFinds.MatchCase)
            If (index <> -1) Then

                ' Find the word's line number and add the line 
                'number to the arrayList. 
                lineList.Add(RichTextBox1.GetLineFromCharIndex(index))
            End If
        Loop While (index <> -1)

        ' Iterate through the list and display the line numbers in TextBox1.
        Dim myEnumerator As System.Collections.IEnumerator = _
            lineList.GetEnumerator()
        If lineList.Count <= 0 Then
            TextBox1.Text = searchWord & " was not found"
        Else
            TextBox1.SelectedText = searchWord & " was found on line(s):"
            While (myEnumerator.MoveNext)
                TextBox1.SelectedText = myEnumerator.Current & " "
            End While
        End If

    End Sub