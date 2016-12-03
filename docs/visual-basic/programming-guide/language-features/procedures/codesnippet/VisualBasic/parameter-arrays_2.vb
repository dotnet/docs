  Sub studentScores(ByVal name As String, ByVal ParamArray scores() As String)
      Debug.WriteLine("Scores for " & name & ":" & vbCrLf)
      ' Use UBound to determine largest subscript of the array.
      For i As Integer = 0 To UBound(scores, 1)
          Debug.WriteLine("Score " & i & ": " & scores(i))
      Next i
  End Sub