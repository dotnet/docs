      string string1 = "244681903147";
      try {
         long number1 = Int64.Parse(string1);
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a 64-bit integer.", string1);
      }
      catch (FormatException) {
         Console.WriteLine("The format of '{0}' is invalid.", string1);
      }

      string string2 = "F9A3CFF0A";
      try {
         long number2 = Int64.Parse(string2,
                                    System.Globalization.NumberStyles.HexNumber);
         Console.WriteLine(number2);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a 64-bit integer.", string2);
      }
      catch (FormatException) {
         Console.WriteLine("The format of '{0}' is invalid.", string2);
      }
      // The example displays the following output:
      //    244681903147
      //    67012198154