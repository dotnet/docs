      Dim negativeNumber As BigInteger = -1000000
      Dim positiveNumber As BigInteger = 15777216
      
      Dim negativeHex As String = negativeNumber.ToString("X")
      Dim positiveHex As string = positiveNumber.ToString("X")
      
      Dim negativeNumber2, positiveNumber2 As BigInteger 
      negativeNumber2 = BigInteger.Parse(negativeHex, 
                                         NumberStyles.HexNumber)
      positiveNumber2 = BigInteger.Parse(positiveHex,
                                         NumberStyles.HexNumber)

      Console.WriteLine("Converted {0:N0} to {1} back to {2:N0}.", 
                         negativeNumber, negativeHex, negativeNumber2)                                         
      Console.WriteLine("Converted {0:N0} to {1} back to {2:N0}.", 
                         positiveNumber, positiveHex, positiveNumber2)                                         
      ' The example displays the following output:
      '       Converted -1,000,000 to F0BDC0 back to -1,000,000.
      '       Converted 15,777,216 to 0F0BDC0 back to 15,777,216.