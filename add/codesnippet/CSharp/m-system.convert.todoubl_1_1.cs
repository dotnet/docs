      ulong[] numbers = { UInt64.MinValue, 121, 12345, UInt64.MaxValue };
      double result;
      
      foreach (ulong number in numbers)
      {
         result = Convert.ToDouble(number);
         Console.WriteLine("Converted the UInt64 value {0} to {1}.",
                           number, result);
      }   
      // The example displays the following output:
      //    Converted the UInt64 value 0 to 0.
      //    Converted the UInt64 value 121 to 121.
      //    Converted the UInt64 value 12345 to 12345.
      //    Converted the UInt64 value 18446744073709551615 to 1.84467440737096E+19.