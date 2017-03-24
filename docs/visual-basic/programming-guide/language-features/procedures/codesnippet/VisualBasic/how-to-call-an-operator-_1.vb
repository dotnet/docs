    Dim firstSpan As New TimeSpan(3, 30, 0)
    Dim secondSpan As New TimeSpan(1, 30, 30)
    Dim combinedSpan As TimeSpan = firstSpan + secondSpan
    Dim s As String = firstSpan.ToString() & 
              " + " & secondSpan.ToString() & 
              " = " & combinedSpan.ToString()
    MsgBox(s)