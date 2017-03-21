    Private Sub CharacterRangeInequality() 
        
        ' Declare the string to draw.
        Dim message As String = "Strings or strings; that is the question."
        
        ' Compare the ranges for equality. The should not be equal.
        Dim range1 As New CharacterRange(message.IndexOf("Strings"), "Strings".Length)
        Dim range2 As New CharacterRange(message.IndexOf("string"), "strings".Length)
        
        If range1 <> range2 Then
            MessageBox.Show("The ranges are not equal.")
        Else
            MessageBox.Show("The ranges are equal.")
        End If
    End Sub