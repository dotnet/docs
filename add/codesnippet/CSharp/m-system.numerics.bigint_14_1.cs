      BigInteger number = 9867857831128;
      number = BigInteger.Pow(number, 3) * BigInteger.MinusOne;
      
      NumberFormatInfo bigIntegerProvider = new NumberFormatInfo();
      bigIntegerProvider.NegativeSign = "~";
      
      Console.WriteLine(number.ToString(bigIntegerProvider));