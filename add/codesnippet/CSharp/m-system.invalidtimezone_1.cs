   private void HandleInnerException()
   {   
      string timeZoneName = "Any Standard Time";
      TimeZoneInfo tz;
      try
      {
         tz = RetrieveTimeZone(timeZoneName);
         Console.WriteLine("The time zone display name is {0}.", tz.DisplayName);
      }
      catch (TimeZoneNotFoundException e)
      {
         Console.WriteLine("{0} thrown by application", e.GetType().Name);
         Console.WriteLine("   Message: {0}", e.Message);
         if (e.InnerException != null)
         {
            Console.WriteLine("   Inner Exception Information:");
            Exception innerEx = e.InnerException;
            while (innerEx != null)
            {
               Console.WriteLine("      {0}: {1}", innerEx.GetType().Name, innerEx.Message);
               innerEx = innerEx.InnerException;
            }
         }            
      }   
   }

   private TimeZoneInfo RetrieveTimeZone(string tzName)
   {
      try
      {
         return TimeZoneInfo.FindSystemTimeZoneById(tzName);
      }   
      catch (TimeZoneNotFoundException ex1)
      {
         throw new TimeZoneNotFoundException( 
               String.Format("The time zone '{0}' cannot be found.", tzName), 
               ex1);
      }          
      catch (InvalidTimeZoneException ex2)
      {
         throw new InvalidTimeZoneException( 
               String.Format("The time zone {0} contains invalid data.", tzName), 
               ex2); 
      }      
   }