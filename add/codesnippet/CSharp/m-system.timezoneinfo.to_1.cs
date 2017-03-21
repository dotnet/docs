   private TimeZoneInfo InitializeTimeZone()
   {
      TimeZoneInfo southPole = null;
      // Determine if South Pole time zone is defined in system
      try
      {
         southPole = TimeZoneInfo.FindSystemTimeZoneById("Antarctica/South Pole Standard Time");
      }
      // Time zone does not exist; create it, store it in a text file, and return it
      catch
      {
         const string filename = @".\TimeZoneInfo.txt";
         bool found = false;
         
         if (File.Exists(filename))
         {
            StreamReader reader = new StreamReader(filename);
            string timeZoneInfo;
            while (reader.Peek() >= 0)
            {
               timeZoneInfo = reader.ReadLine();
               if (timeZoneInfo.Contains("Antarctica/South Pole"))
               {
                  southPole = TimeZoneInfo.FromSerializedString(timeZoneInfo);
                  reader.Close();
                  found = true;
                  break;
               }   
            }
         }
         if (! found)
         {               
            // Define transition times to/from DST
            TimeZoneInfo.TransitionTime startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 1, DayOfWeek.Sunday); 
            TimeZoneInfo.TransitionTime endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 3, DayOfWeek.Sunday);
            // Define adjustment rule
            TimeSpan delta = new TimeSpan(1, 0, 0);
            TimeZoneInfo.AdjustmentRule adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1989, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition);
            // Create array for adjustment rules
            TimeZoneInfo.AdjustmentRule[] adjustments = {adjustment};
            // Define other custom time zone arguments
            string displayName = "(GMT+12:00) Antarctica/South Pole";
            string standardName = "Antarctica/South Pole Standard Time";
            string daylightName = "Antarctica/South Pole Daylight Time";
            TimeSpan offset = new TimeSpan(12, 0, 0);
            southPole = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments);
            // Write time zone to the file
            StreamWriter writer = new StreamWriter(filename, true);
            writer.WriteLine(southPole.ToSerializedString());
            writer.Close();
         }
      }
      return southPole;
   }