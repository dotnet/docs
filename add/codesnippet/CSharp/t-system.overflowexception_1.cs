      int value = 780000000;
      checked {
      try {
         // Square the original value.
         int square = value * value; 
         Console.WriteLine("{0} ^ 2 = {1}", value, square);
      }
      catch (OverflowException) {
         double square = Math.Pow(value, 2);
         Console.WriteLine("Exception: {0} > {1:E}.", 
                           square, Int32.MaxValue);
      } }
      // The example displays the following output:
      //       Exception: 6.084E+17 > 2.147484E+009.