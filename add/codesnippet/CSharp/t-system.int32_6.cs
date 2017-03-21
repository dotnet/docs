      int[] numbers = { -1403, 0, 169, 1483104 };
      foreach (int number in numbers) {
         // Display value using default formatting.
         Console.Write("{0,-8}  -->   ", number.ToString());
         // Display value with 3 digits and leading zeros.
         Console.Write("{0,11:D3}", number);
         // Display value with 1 decimal digit.
         Console.Write("{0,13:N1}", number);
         // Display value as hexadecimal.
         Console.Write("{0,12:X2}", number);
         // Display value with eight hexadecimal digits.
         Console.WriteLine("{0,14:X8}", number);
      }   
      // The example displays the following output:
      //    -1403     -->         -1403     -1,403.0    FFFFFA85      FFFFFA85
      //    0         -->           000          0.0          00      00000000
      //    169       -->           169        169.0          A9      000000A9
      //    1483104   -->       1483104  1,483,104.0      16A160      0016A160