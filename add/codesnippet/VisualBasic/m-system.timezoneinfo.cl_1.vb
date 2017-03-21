      Dim cst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
      Dim local As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine(TimeZoneInfo.ConvertTime(Date.Now, local, cst))
      
      TimeZoneInfo.ClearCachedData()
      Try
         Console.WriteLine(TimeZoneInfo.ConvertTime(Date.Now, local, cst))
      Catch e As ArgumentException
         Console.WriteLine(e.GetType().Name & vbCrLf & "   " & e.Message)
      End Try