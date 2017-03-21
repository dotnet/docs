      long[] numbers = { Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue };
      byte result;
      foreach (long number in numbers)
      {
         try {
            result = Convert.ToByte(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }                     
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the Byte type.", 
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //       The Int64 value -9223372036854775808 is outside the range of the Byte type.
      //       The Int64 value -1 is outside the range of the Byte type.
      //       Converted the Int64 value 0 to the Byte value 0.
      //       Converted the Int64 value 121 to the Byte value 121.
      //       The Int64 value 340 is outside the range of the Byte type.
      //       The Int64 value 9223372036854775807 is outside the range of the Byte type.      