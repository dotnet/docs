      byte[] numbers ={ 0, 16, 104, 213 };
      Console.WriteLine("{0}   {1,8}   {2,5}   {3,5}",
                        "Value", "Binary", "Octal", "Hex");
      foreach (byte number in numbers) {
         Console.WriteLine("{0,5}   {1,8}   {2,5}   {3,5}",
                           number, Convert.ToString(number, 2),
                           Convert.ToString(number, 8),
                           Convert.ToString(number, 16));
      }      
      // The example displays the following output:
      //       Value     Binary   Octal     Hex
      //           0          0       0       0
      //          16      10000      20      10
      //         104    1101000     150      68
      //         213   11010101     325      d5      