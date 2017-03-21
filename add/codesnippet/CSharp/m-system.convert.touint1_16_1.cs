      char[] chars = { 'a', 'z', '\x0007', '\x03FF',
                       '\x7FFF', '\xFFFE' };
      ushort result;
      
      foreach (char ch in chars)
      {
         try {
            result = Convert.ToUInt16(ch);
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", 
                              ch.GetType().Name, ch, 
                              result.GetType().Name, result);
         }
         catch (OverflowException) {
            Console.WriteLine("Unable to convert u+{0} to a UInt16.",
                              ((int)ch).ToString("X4"));
         }
      }   
      // The example displays the following output:
      //    Converted the Char value 'a' to the UInt16 value 97.
      //    Converted the Char value 'z' to the UInt16 value 122.
      //    Converted the Char value '' to the UInt16 value 7.
      //    Converted the Char value '?' to the UInt16 value 1023.
      //    Converted the Char value '?' to the UInt16 value 32767.
      //    Converted the Char value '?' to the UInt16 value 65534.