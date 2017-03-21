      int negativeNumber = -1000000;
      uint positiveNumber = 4293967296;
      
      byte[] negativeBytes = BitConverter.GetBytes(negativeNumber); 
      BigInteger negativeBigInt = new BigInteger(negativeBytes);
      Console.WriteLine(negativeBigInt.ToString("N0"));
      
      byte[] tempPosBytes = BitConverter.GetBytes(positiveNumber);
      byte[] positiveBytes = new byte[tempPosBytes.Length + 1];
      Array.Copy(tempPosBytes, positiveBytes, tempPosBytes.Length);
      BigInteger positiveBigInt = new BigInteger(positiveBytes);
      Console.WriteLine(positiveBigInt.ToString("N0")); 
      // The example displays the following output:
      //    -1,000,000
      //    4,293,967,296      