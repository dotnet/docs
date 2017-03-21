      char[] chars = { 'a', 'z', '\u0007', '\u0200', '\u1023' };
      foreach (char ch in chars)
      {
         try {
            sbyte result = Convert.ToSByte(ch);
            Console.WriteLine("{0} is converted to {1}.", ch, result);
         }   
         catch (OverflowException) {
            Console.WriteLine("Unable to convert u+{0} to a byte.",
                              Convert.ToInt16(ch).ToString("X4"));
         }
      }   
      // The example displays the following output:
      //    a is converted to 97.
      //    z is converted to 122.
      //     is converted to 7.
      //    Unable to convert u+00C8 to a byte.
      //    Unable to convert u+03FF to a byte.