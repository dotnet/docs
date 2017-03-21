      int int1 = 128;
      try {
         byte value1 = (byte) int1;
         Console.WriteLine(value1);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of a byte.", int1);
      }

      double dbl2 = 3.997;
      try {
         byte value2 = (byte) dbl2;
         Console.WriteLine(value2);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of a byte.", dbl2);
      }
      // The example displays the following output:
      //       128
      //       3