      char[] chars = { 'a', 'z', '\u0007', '\u03FF',
                       '\u7FFF', '\uFFFE' };
      int result;
                              
      foreach (char ch in chars)
      {
         try {
            result = Convert.ToInt32(ch);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              ch.GetType().Name, ch,
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("Unable to convert u+{0} to an Int32.",
                              ((int)ch).ToString("X4"));
         }
      }   
      // The example displays the following output:
      //       Converted the Char value 'a' to the Int32 value 97.
      //       Converted the Char value 'z' to the Int32 value 122.
      //       Converted the Char value '' to the Int32 value 7.
      //       Converted the Char value '?' to the Int32 value 1023.
      //       Converted the Char value '?' to the Int32 value 32767.
      //       Converted the Char value '?' to the Int32 value 65534.