      ' Specify DateTimeKind in Date constructor
      Dim baseTime As New Date(2007, 3, 11, 1, 59, 0, DateTimeKind.Unspecified)
      Dim newTime As Date
      
      ' Get Pacific Standard Time zone
      Dim pstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
      
      ' List possible invalid times for 63-minute interval, from 1:59 AM to 3:01 AM
      For ctr As Integer = 0 To 62
         ' Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
         newTime = baseTime.AddMinutes(ctr)
         Console.WriteLine("{0} is invalid: {1}", newTime, pstZone.IsInvalidTime(newTime))
      Next