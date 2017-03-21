      char[] chars = { 'a', 'z', '\u0007', '\u03FF',
                       '\u7FFF', '\uFFFE' };
      long result;
                              
      foreach (char ch in chars)
      {
         result = Convert.ToInt64(ch);
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           ch.GetType().Name, ch,
                           result.GetType().Name, result);
      }   
      // The example displays the following output:
      //       Converted the Char value 'a' to the Int64 value 97.
      //       Converted the Char value 'z' to the Int64 value 122.
      //       Converted the Char value '' to the Int64 value 7.
      //       Converted the Char value '?' to the Int64 value 1023.
      //       Converted the Char value '?' to the Int64 value 32767.
      //       Converted the Char value '?' to the Int64 value 65534.