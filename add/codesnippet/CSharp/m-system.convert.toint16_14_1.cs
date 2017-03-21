      char[] chars = { 'a', 'z', '\x0007', '\x03FF',
                       '\x7FFF', '\xFFFE' };
      short result;
      
      foreach (char ch in chars)
      {
         try {
            result = Convert.ToInt16(ch);
            Console.WriteLine("'{0}' converts to {1}.", ch, result);
         }
         catch (OverflowException) {
            Console.WriteLine("Unable to convert u+{0} to an Int16.",
                              ((int)ch).ToString("X4"));
         }
      }   
      // The example displays the following output:
      //       'a' converts to 97.
      //       'z' converts to 122.
      //       '' converts to 7.
      //       '?' converts to 1023.
      //       '?' converts to 32767.
      //       Unable to convert u+FFFE to a UInt16.