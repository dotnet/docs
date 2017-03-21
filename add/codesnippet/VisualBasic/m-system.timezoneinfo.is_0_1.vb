      ' Specify DateTimeKind in Date constructor
      Dim baseTime As New Date(2007, 11, 4, 0, 59, 00, DateTimeKind.Unspecified)
      Dim newTime As Date
      
      ' Get Pacific Standard Time zone
      Dim pstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")

      ' List possible ambiguous times for 63-minute interval, from 12:59 AM to 2:01 AM 
      For ctr As Integer = 0 To 62
         ' Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
         newTime = baseTime.AddMinutes(ctr)   
         Console.WriteLine("{0} is ambiguous: {1}", newTime, pstZone.IsAmbiguousTime(newTime))
      Next