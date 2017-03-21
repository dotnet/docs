      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
      ulong result;
      
      foreach (sbyte number in numbers)
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
      //    The SByte value -128 is outside the range of the UInt64 type.
      //    The SByte value -1 is outside the range of the UInt64 type.
      //    Converted the SByte value 0 to the UInt64 value 0.
      //    Converted the SByte value 10 to the UInt64 value 10.
      //    Converted the SByte value 127 to the UInt64 value 127.