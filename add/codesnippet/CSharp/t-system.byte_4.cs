      string string1 = "244";
      try {
         byte byte1 = Byte.Parse(string1);
         Console.WriteLine(byte1);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a byte.", string1);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}' is out of range of a byte.", string1);
      }
   
      string string2 = "F9";
      try {
         byte byte2 = Byte.Parse(string2, 
                                 System.Globalization.NumberStyles.HexNumber);
         Console.WriteLine(byte2);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a byte.", string2);
      }
      catch (FormatException) {
         Console.WriteLine("'{0}' is out of range of a byte.", string2);
      }
      // The example displays the following output:
      //       244
      //       249