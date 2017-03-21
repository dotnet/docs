      Dim fmt As New NumberFormatInfo()
      fmt.NegativeSign = "~"
      
      Dim number As BigInteger = BigInteger.Parse("~6354129876", fmt)
      ' Display value using same formatting information
      Console.WriteLine(number.ToString(fmt))
      ' Display value using formatting of current culture
      Console.WriteLine(number)