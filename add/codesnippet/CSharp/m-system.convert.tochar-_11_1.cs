      sbyte[] numbers = { SByte.MinValue, -1, 40, 80, 120, SByte.MaxValue };
      char result;
      foreach (sbyte number in numbers)
      {
         try {
            result = Convert.ToChar(number);
            Console.WriteLine("{0} converts to '{1}'.", number, result);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of the Char data type.",
                              number);
         }
      }
      // The example displays the following output:
      //       -128 is outside the range of the Char data type.
      //       -1 is outside the range of the Char data type.
      //       40 converts to '('.
      //       80 converts to 'P'.
      //       120 converts to 'x'.
      //       127 converts to '⌂'.