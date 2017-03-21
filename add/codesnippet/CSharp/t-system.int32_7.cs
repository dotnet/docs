      int[] numbers = { -146, 11043, 2781913 };
      Console.WriteLine("{0,8}   {1,32}   {2,11}   {3,10}", 
                        "Value", "Binary", "Octal", "Hex");
      foreach (int number in numbers) {
         Console.WriteLine("{0,8}   {1,32}   {2,11}   {3,10}", 
                           number, Convert.ToString(number, 2), 
                           Convert.ToString(number, 8), 
                           Convert.ToString(number, 16));
      }      
      // The example displays the following output:
      //       Value                             Binary         Octal          Hex
      //        -146   11111111111111111111111101101110   37777777556     ffffff6e
      //       11043                     10101100100011         25443         2b23
      //     2781913             1010100111001011011001      12471331       2a72d9