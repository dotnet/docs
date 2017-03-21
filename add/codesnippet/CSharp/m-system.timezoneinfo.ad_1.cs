      string timeZoneName = "";
      // Get CST, Canadian CST, and Mexican CST adjustment rules
      TimeZoneInfo.AdjustmentRule[] usCstAdjustments = null;
      TimeZoneInfo.AdjustmentRule[] canCstAdjustments = null;
      TimeZoneInfo.AdjustmentRule[] mexCstAdjustments = null;
      try
      {
         timeZoneName = "Central Standard Time";
         usCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules();
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} time zone is not defined in the registry.", 
                           timeZoneName);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data for the {0} time zone is invalid.", 
                           timeZoneName);
      }
      try
      {
         timeZoneName = "Canada Central Standard Time";
         canCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules();
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} time zone is not defined in the registry.", 
                           timeZoneName);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data for the {0} time zone is invalid.", 
                           timeZoneName);
      }
      try
      {
         timeZoneName = "Central Standard Time (Mexico)";
         mexCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules();
      }   
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} time zone is not defined in the registry.", 
                           timeZoneName);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data for the {0} time zone is invalid.", 
                           timeZoneName);
      }
      // Determine if CST and other time zones have the same rules
      foreach(TimeZoneInfo.AdjustmentRule rule in usCstAdjustments)
      {
         Console.WriteLine("Comparing Central Standard Time rule for {0:d} to {1:d} with:", 
                           rule.DateStart, rule.DateEnd);
         // Compare with Canada Central Standard Time
         if (canCstAdjustments.Length == 0)
         {
            Console.WriteLine("   Canada Central Standard Time has no adjustment rules.");
         }   
         else
         {
            foreach (TimeZoneInfo.AdjustmentRule canRule in canCstAdjustments)
            {
               Console.WriteLine("   Canadian CST for {0:d} to {1:d}: {2}", 
                                 canRule.DateStart, canRule.DateEnd, 
                                 rule.Equals(canRule) ? "Equal" : "Not Equal");
            }              
         }          
   
         // Compare with Mexico Central Standard Time
         if (mexCstAdjustments.Length == 0)
         {
            Console.WriteLine("   Mexican Central Standard Time has no adjustment rules.");
         }
         else
         {
            foreach (TimeZoneInfo.AdjustmentRule mexRule in mexCstAdjustments)
            {
               Console.WriteLine("   Mexican CST for {0:d} to {1:d}: {2}", 
                                 mexRule.DateStart, mexRule.DateEnd, 
                                 rule.Equals(mexRule) ? "Equal" : "Not Equal");
            }              
         }
      }   
      // This code displays the following output to the console:
      // 
      // Comparing Central Standard Time rule for 1/1/0001 to 12/31/9999 with:
      //    Canada Central Standard Time has no adjustment rules.
      //    Mexican CST for 1/1/0001 to 12/31/9999: Equal