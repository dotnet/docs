      Dim dto As DateTimeOffset
      Dim ctr As Integer
      Dim ms As Integer
      Do
         dto = DateTimeOffset.Now
         If dto.Millisecond <> ms Then
            ms = dto.Millisecond
            Console.WriteLine("{0}:{1:d3} ms. {2}", _
                              dto.ToString("M/d/yyyy h:mm:ss"), _
                              ms, dto.ToString("zzz"))
            ctr += 1
         End If
      Loop While ctr < 100