      // Initialize a BigInteger value.
      BigInteger value = BigInteger.Add(UInt64.MaxValue, 1024);

      // Display value using the default ToString method.
      Console.WriteLine(value.ToString());     
      // Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"));
      Console.WriteLine(value.ToString("C"));
      Console.WriteLine(value.ToString("D"));
      Console.WriteLine(value.ToString("F"));
      Console.WriteLine(value.ToString("N"));
      Console.WriteLine(value.ToString("X"));       
      // The example displays the following output on a system whose current 
      // culture is en-US:
      //       18446744073709552639
      //       18446744073709552639
      //       $18,446,744,073,709,552,639.00
      //       18446744073709552639
      //       18446744073709552639.00
      //       18,446,744,073,709,552,639.00
      //       100000000000003FF      