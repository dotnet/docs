      Dim number As BigInteger = 9867857831128
      number = BigInteger.Pow(number, 3) * BigInteger.MinusOne
      
      Dim bigIntegerProvider As New NumberFormatInfo()
      bigIntegerProvider.NegativeSign = "~"      
      
      Console.WriteLine(number.ToString(bigIntegerProvider))