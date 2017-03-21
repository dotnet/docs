      ulong[] numbers= { UInt64.MinValue, 121, 340, UInt64.MaxValue };
      byte result;
      foreach (ulong number in numbers)
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
      //       Converted the UInt64 value 0 to the Byte value 0.
      //       Converted the UInt64 value 121 to the Byte value 121.
      //       The UInt64 value 340 is outside the range of the Byte type.
      //       The UInt64 value 18446744073709551615 is outside the range of the Byte type.