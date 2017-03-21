      ulong originalNumber = UInt64.MaxValue;
      byte[] bytes = BitConverter.GetBytes(originalNumber);
      if (originalNumber > 0 && (bytes[bytes.Length - 1] & 0x80) > 0) 
      {
         byte[] temp = new byte[bytes.Length];
         Array.Copy(bytes, temp, bytes.Length);
         bytes = new byte[temp.Length + 1];
         Array.Copy(temp, bytes, temp.Length);
      }
      
      BigInteger newNumber = new BigInteger(bytes);
      Console.WriteLine("Converted the UInt64 value {0:N0} to {1:N0}.", 
                        originalNumber, newNumber); 
      // The example displays the following output:
      //    Converted the UInt64 value 18,446,744,073,709,551,615 to 18,446,744,073,709,551,615.