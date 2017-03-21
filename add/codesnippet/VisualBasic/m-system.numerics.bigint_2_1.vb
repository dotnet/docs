      ' Create a BigInteger from a large double value.
      Dim doubleValue As Double = -6e20
      Dim bigIntValue As New BigInteger(doubleValue)
      Console.WriteLine("Original Double value: {0:N0}", doubleValue)
      Console.WriteLine("Original BigInteger value: {0:N0}", bigIntValue)
      ' Increment and then display both values.
      doubleValue += 1
      bigIntValue += BigInteger.One
      Console.WriteLine("Incremented Double value: {0:N0}", doubleValue)
      Console.WriteLine("Incremented BigInteger value: {0:N0}", bigIntValue)
      ' The example displays the following output:
      '    Original Double value: -600,000,000,000,000,000,000
      '    Original BigInteger value: -600,000,000,000,000,000,000
      '    Incremented Double value: -600,000,000,000,000,000,000
      '    Incremented BigInteger value: -599,999,999,999,999,999,999