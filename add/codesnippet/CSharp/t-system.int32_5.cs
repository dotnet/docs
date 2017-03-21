      string string1 = "244681";
      try {
         int number1 = Int32.Parse(string1);
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a 32-bit integer.", string1);
      }
      catch (FormatException) {
         Console.WriteLine("The format of '{0}' is invalid.", string1);
      }

      string string2 = "F9A3C";
      try {
         int number2 = Int32.Parse(string2,
                                  System.Globalization.NumberStyles.HexNumber);
         Console.WriteLine(number2);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a 32-bit integer.", string2);
      }
      catch (FormatException) {
         Console.WriteLine("The format of '{0}' is invalid.", string2);
      }
      // The example displays the following output:
      //       244681
      //       1022524