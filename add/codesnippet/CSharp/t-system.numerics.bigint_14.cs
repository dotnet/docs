      BigInteger negativeNumber = -1000000;
      BigInteger positiveNumber  = 15777216;
      
      string negativeHex = negativeNumber.ToString("X");
      string positiveHex = positiveNumber.ToString("X");
      
      BigInteger negativeNumber2, positiveNumber2;  
      negativeNumber2 = BigInteger.Parse(negativeHex, 
                                         NumberStyles.HexNumber);
      positiveNumber2 = BigInteger.Parse(positiveHex,
                                         NumberStyles.HexNumber);

      Console.WriteLine("Converted {0:N0} to {1} back to {2:N0}.", 
                         negativeNumber, negativeHex, negativeNumber2);                                         
      Console.WriteLine("Converted {0:N0} to {1} back to {2:N0}.", 
                         positiveNumber, positiveHex, positiveNumber2);                                         
      // The example displays the following output:
      //       Converted -1,000,000 to F0BDC0 back to -1,000,000.
      //       Converted 15,777,216 to 0F0BDC0 back to 15,777,216.