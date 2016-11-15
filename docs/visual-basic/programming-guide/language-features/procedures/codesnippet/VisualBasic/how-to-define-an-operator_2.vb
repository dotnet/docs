  Public Sub consumeHeight()
      Dim p1 As New height(3, 10)
      Dim p2 As New height(4, 8)
      Dim p3 As height = p1 + p2
      Dim s As String = p1.ToString() & " + " & p2.ToString() &
            " = " & p3.ToString() & " (= 8' 6"" ?)"
      Dim p4 As New height(2, 14)
      s &= vbCrLf & "2' 14"" = " & p4.ToString() & " (= 3' 2"" ?)"
      Dim p5 As New height(4, 24)
      s &= vbCrLf & "4' 24"" = " & p5.ToString() & " (= 6' 0"" ?)"
      MsgBox(s)
  End Sub