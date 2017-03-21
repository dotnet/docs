      BigInteger number = BigInteger.Pow(Int64.MaxValue, 2);     
      Console.WriteLine(number);
      
      // Write the BigInteger value to a byte array.
      byte[] bytes = number.ToByteArray();
      
      // Display the byte array.
      foreach (byte byteValue in bytes)
         Console.Write("0x{0:X2} ", byteValue);
      Console.WriteLine();

      // Restore the BigInteger value from a Byte array.
      BigInteger newNumber = new BigInteger(bytes);
      Console.WriteLine(newNumber);
      // The example displays the following output:
      //    8.5070591730234615847396907784E+37
      //    0x01 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0x3F
      //    
      //    8.5070591730234615847396907784E+37