      long[] numbers = { Int64.MinValue, -19432, -18, 0, 121, 340, Int64.MaxValue };
      ulong result;
      foreach (long number in numbers)
      {
         try {
            result = Convert.ToUInt64(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the UInt64 type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    The Int64 value -9223372036854775808 is outside the range of the UInt64 type.
      //    The Int64 value -19432 is outside the range of the UInt64 type.
      //    The Int64 value -18 is outside the range of the UInt64 type.
      //    Converted the Int64 value 0 to the UInt64 value 0.
      //    Converted the Int64 value 121 to the UInt64 value 121.
      //    Converted the Int64 value 340 to the UInt64 value 340.
      //    Converted the Int64 value 9223372036854775807 to a UInt64 value 9223372036854775807.