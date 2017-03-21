         // Specify DateTimeKind in Date constructor
         DateTime baseTime = new DateTime(2007, 3, 11, 1, 59, 0, DateTimeKind.Unspecified);
         DateTime newTime;
         
         // Get Pacific Standard Time zone
         TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
         
         // List possible invalid times for a 63-minute interval, from 1:59 AM to 3:01 AM
         for (int ctr = 0; ctr < 63; ctr++)
         {
            // Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
            newTime = baseTime.AddMinutes(ctr);
            Console.WriteLine("{0} is invalid: {1}", newTime, pstZone.IsInvalidTime(newTime));
         }