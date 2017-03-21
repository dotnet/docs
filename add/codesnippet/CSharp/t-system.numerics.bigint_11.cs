      short originalValue = 30000;
      Console.WriteLine(originalValue);
      
      // Convert the Int16 value to a byte array.
      byte[] bytes = BitConverter.GetBytes(originalValue);

      // Display the byte array.
      foreach (byte byteValue in bytes)
         Console.Write("0x{0} ", byteValue.ToString("X2"));
      Console.WriteLine();

      // Pass byte array to the BigInteger constructor.
      BigInteger number = new BigInteger(bytes);
      Console.WriteLine(number);
      // The example displays the following output:
      //       30000
      //       0x30 0x75
      //       30000