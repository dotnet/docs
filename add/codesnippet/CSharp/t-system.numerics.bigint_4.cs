      byte[] byteArray = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
      BigInteger newBigInt = new BigInteger(byteArray);
      Console.WriteLine("The value of newBigInt is {0} (or 0x{0:x}).", newBigInt);    
      // The example displays the following output:
      //   The value of newBigInt is 4759477275222530853130 (or 0x102030405060708090a).