      sbyte[] numbers = { SByte.MinValue, -1, 0, 10, SByte.MaxValue };
      byte result;
      foreach (sbyte number in numbers)
      {
         try {
            result = Convert.ToByte(number);
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                              number.GetType().Name, number, 
                              result.GetType().Name, result);
         }                     
         catch (OverflowException)
         {
            Console.WriteLine("The {0} value {1} is outside the range of the Byte type.", 
                              number.GetType().Name, number);
         }
      }
      // The example displays the following output:
      //       The SByte value -128 is outside the range of the Byte type.
      //       The SByte value -1 is outside the range of the Byte type.
      //       Converted the SByte value 0 to the Byte value 0.
      //       Converted the SByte value 10 to the Byte value 10.
      //       Converted the SByte value 127 to the Byte value 127.