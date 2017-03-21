      byte[] numbers = { Byte.MinValue, 10, 100, Byte.MaxValue };
      sbyte result;
      
      foreach (byte number in numbers)
      {
         try {
            result = Convert.ToSByte(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result);
         }                           
         catch (OverflowException) {
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.",
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //    Converted the Byte value 0 to the SByte value 0.
      //    Converted the Byte value 10 to the SByte value 10.
      //    Converted the Byte value 100 to the SByte value 100.
      //    The Byte value 255 is outside the range of the SByte type.