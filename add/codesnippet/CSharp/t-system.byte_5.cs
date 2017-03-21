      byte[] numbers = { 0, 16, 104, 213 };
      foreach (byte number in numbers) {
         // Display value using default formatting.
         Console.Write("{0,-3}  -->   ", number.ToString());
         // Display value with 3 digits and leading zeros.
         Console.Write(number.ToString("D3") + "   ");
         // Display value with hexadecimal.
         Console.Write(number.ToString("X2") + "   ");
         // Display value with four hexadecimal digits.
         Console.WriteLine(number.ToString("X4"));
      }   
      // The example displays the following output:
      //       0    -->   000   00   0000
      //       16   -->   016   10   0010
      //       104  -->   104   68   0068
      //       213  -->   213   D5   00D5      