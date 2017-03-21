      int[] numbers = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue };
      sbyte result;
      
      foreach (int number in numbers)
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
      //    The Int32 value -2147483648 is outside the range of the SByte type.
      //    Converted the Int32 value -1 to the SByte value -1.
      //    Converted the Int32 value 0 to the SByte value 0.
      //    Converted the Int32 value 121 to the SByte value 121.
      //    The Int32 value 340 is outside the range of the SByte type.
      //    The Int32 value 2147483647 is outside the range of the SByte type.