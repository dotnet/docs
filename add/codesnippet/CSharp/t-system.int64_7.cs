      long[] numbers = { -146, 11043, 2781913 };
      foreach (var number in numbers) {
         Console.WriteLine("{0} (Base 10):", number);
         Console.WriteLine("   Binary:  {0}", Convert.ToString(number, 2));
         Console.WriteLine("   Octal:   {0}", Convert.ToString(number, 8));
         Console.WriteLine("   Hex:     {0}\n", Convert.ToString(number, 16));
      }
      // The example displays the following output:
      //    -146 (Base 10):
      //       Binary:  1111111111111111111111111111111111111111111111111111111101101110
      //       Octal:   1777777777777777777556
      //       Hex:     ffffffffffffff6e
      //
      //    11043 (Base 10):
      //       Binary:  10101100100011
      //       Octal:   25443
      //       Hex:     2b23
      //
      //    2781913 (Base 10):
      //       Binary:  1010100111001011011001
      //       Octal:   12471331
      //       Hex:     2a72d9