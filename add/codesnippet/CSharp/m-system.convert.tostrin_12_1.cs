      DateTime[] dates = { new DateTime(2009, 7, 14), 
                           new DateTime(1, 1, 1, 18, 32, 0), 
                           new DateTime(2009, 2, 12, 7, 16, 0) };
      string result;
      
      foreach (DateTime dateValue in dates)
      {
         result = Convert.ToString(dateValue);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              dateValue.GetType().Name, dateValue,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the DateTime value 7/14/2009 12:00:00 AM to a String value 7/14/2009 12:00:00 AM.
      //    Converted the DateTime value 1/1/0001 06:32:00 PM to a String value 1/1/0001 06:32:00 PM.
      //    Converted the DateTime value 2/12/2009 07:16:00 AM to a String value 2/12/2009 07:16:00 AM.