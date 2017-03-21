         // Specify DateTimeKind in Date constructor
         DateTime baseTime = new DateTime(2007, 11, 4, 0, 59, 00, DateTimeKind.Unspecified);
         DateTime newTime;
      
         // Get Pacific Standard Time zone
         TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

         // List possible ambiguous times for 63-minute interval, from 12:59 AM to 2:01 AM 
         for (int ctr = 0; ctr < 63; ctr++)
         {
            // Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
            newTime = baseTime.AddMinutes(ctr);   
            Console.WriteLine("{0} is ambiguous: {1}", newTime, pstZone.IsAmbiguousTime(newTime));
         }