      BigInteger positiveValue = 15777216;
      BigInteger negativeValue  = -1000000;
      
      Console.WriteLine("Positive value: " + positiveValue.ToString("N0"));
      byte[] bytes = positiveValue.ToByteArray();

      foreach (byte byteValue in bytes)
         Console.Write("{0:X2} ", byteValue);
      Console.WriteLine();
      positiveValue = new BigInteger(bytes);
      Console.WriteLine("Restored positive value: " + positiveValue.ToString("N0"));
      
      Console.WriteLine();
         
      Console.WriteLine("Negative value: " + negativeValue.ToString("N0"));
      bytes = negativeValue.ToByteArray();
      foreach (byte byteValue in bytes)
         Console.Write("{0:X2} ", byteValue);
      Console.WriteLine();
      negativeValue = new BigInteger(bytes);
      Console.WriteLine("Restored negative value: " + negativeValue.ToString("N0"));
      // The example displays the following output:
      //       Positive value: 15,777,216
      //       C0 BD F0 00
      //       Restored positive value: 15,777,216
      //       
      //       Negative value: -1,000,000
      //       C0 BD F0
      //       Restored negative value: -1,000,000