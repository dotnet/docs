      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
      long result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToInt64(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result);
      }
      // The example displays the following output:
      //       Converted the SByte value -128 to the Int64 value -128.
      //       Converted the SByte value -1 to the Int64 value -1.
      //       Converted the SByte value 0 to the Int64 value 0.
      //       Converted the SByte value 10 to the Int64 value 10.
      //       Converted the SByte value 127 to the Int64 value 127.