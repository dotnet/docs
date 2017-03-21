      uint[] numbers = { UInt32.MinValue, 121, 340, UInt32.MaxValue };
      long result;
      foreach (uint number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1:N0} to the {2} value {3:N0}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the UInt32 value 0 to the Int64 value 0.
      //    Converted the UInt32 value 121 to the Int64 value 121.
      //    Converted the UInt32 value 340 to the Int64 value 340.
      //    Converted the UInt32 value 4,294,967,295 to the Int64 value 4,294,967,295.