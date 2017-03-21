      string nullString = null;
      string[] strings = { "A", "This",  '\u0007'.ToString(), nullString };
      char result;
      foreach (string strng in strings)
      {
         try {
            result = Convert.ToChar(strng);
            Console.WriteLine("'{0}' converts to '{1}'.", strng, result);
         }   
         catch (FormatException)
         {
            Console.WriteLine("'{0}' is not in the correct format for conversion to a Char.",
                              strng);
         }
         catch (ArgumentNullException) {
            Console.WriteLine("A null string cannot be converted to a Char.");
         }   
      }
      // The example displays the following output:
      //       'A' converts to 'A'.
      //       'This' is not in the correct format for conversion to a Char.
      //       '       ' converts to ' '.
      //       A null string cannot be converted to a Char.