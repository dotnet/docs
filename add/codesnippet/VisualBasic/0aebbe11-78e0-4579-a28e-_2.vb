      Dim number1 As Long = 1234567890
      Dim number2 As Long = 9876543210
      Try
         Dim product As Long
         product = number1 * number2
         Console.WriteLine(product.ToString("N0"))
      Catch e As OverflowException
         Dim product As BigInteger
         product = BigInteger.Multiply(number1, number2)
         Console.WriteLine(product.ToString)
      End Try   