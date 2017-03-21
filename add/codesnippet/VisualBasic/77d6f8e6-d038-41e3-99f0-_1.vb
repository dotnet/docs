    Private Sub CharacterRangeEquality1() 
        
        ' Declare the string to draw.
        Dim message As String = "Strings or strings; that is the question."
        
        ' Compare the ranges for equality. The should not be equal.
        Dim range1 As New CharacterRange(message.IndexOf("Strings"), _
            "Strings".Length)
        Dim range2 As New CharacterRange(message.IndexOf("strings"), _
            "strings".Length)
        
        If range1 = range2 Then
            MessageBox.Show("The ranges are equal.")
        Else
            MessageBox.Show("The ranges are not equal.")
        End If
     
    End Sub
    