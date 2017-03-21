      sbyte[] numbers = { SByte.MinValue, -12, 0, 16, SByte.MaxValue };
      string result;
      
      foreach (sbyte number in numbers)
      {
         result = Convert.ToString(number);
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
      }
      // The example displays the following output:
      //    Converted the SByte value -128 to the String value -128.
      //    Converted the SByte value -12 to the String value -12.
      //    Converted the SByte value 0 to the String value 0.
      //    Converted the SByte value 16 to the String value 16.
      //    Converted the SByte value 127 to the String value 127.