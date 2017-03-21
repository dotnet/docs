      ulong[] numbers = { UInt64.MinValue, 1031, 189045, UInt64.MaxValue };
      string result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the UInt64 value 0 to the String value 0.
      //    Converted the UInt64 value 1031 to the String value 1031.
      //    Converted the UInt64 value 189045 to the String value 189045.
      //    Converted the UInt64 value 18446744073709551615 to the String value 18446744073709551615.