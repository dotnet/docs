      short[] numbers = { Int16.MinValue, 0, 40, 160, 255, 1028, 
                          2011, Int16.MaxValue };
      char result;
      foreach (short number in numbers)
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
      //       -32768 is outside the range of the Char data type.
      //       0 converts to ' '.
      //       40 converts to '('.
      //       160 converts to ' '.
      //       255 converts to 'ÿ'.
      //       1028 converts to '?'.
      //       2011 converts to '?'.
      //       32767 converts to '?'.      