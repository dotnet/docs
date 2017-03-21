      Dim number As BigInteger 
      ' Method should succeed (white space and sign allowed)
      number = BigInteger.Parse("   -68054   ", NumberStyles.Integer)
      Console.WriteLine(number)
      ' Method should succeed (string interpreted as hexadecimal)
      number = BigInteger.Parse("68054", NumberStyles.AllowHexSpecifier)
      Console.WriteLine(number)
      ' Method call should fail: sign not allowed
      Try
         number = BigInteger.Parse("   -68054  ", NumberStyles.AllowLeadingWhite _
                                                  Or NumberStyles.AllowTrailingWhite)
         Console.WriteLine(number)
      Catch e As FormatException
         Console.WriteLine(e.Message)
      End Try                                                     
      ' Method call should fail: white space not allowed
      Try
         number = BigInteger.Parse("   68054  ", NumberStyles.AllowLeadingSign)
         Console.WriteLine(number)
      Catch e As FormatException
         Console.WriteLine(e.Message)
      End Try    
      '
      ' The method produces the following output:
      '
      '     -68054
      '     426068
      '     Input string was not in a correct format.
      '     Input string was not in a correct format.                                                 