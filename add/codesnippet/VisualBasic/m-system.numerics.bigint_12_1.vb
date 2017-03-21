      Dim decimalValues() As Decimal = { -1790.533d, -15.1514d, 18903.79d, 9180098.003d }
      For Each decimalValue As Decimal In decimalValues
         Dim number As New BigInteger(decimalValue)
         Console.WriteLine("Instantiated BigInteger value {0} from the Decimal value {1}.",
                           number, decimalValue)
      Next                 
      ' The example displays the following output:
      '    Instantiated BigInteger value -1790 from the Decimal value -1790.533.
      '    Instantiated BigInteger value -15 from the Decimal value -15.1514.
      '    Instantiated BigInteger value 18903 from the Decimal value 18903.79.
      '    Instantiated BigInteger value 9180098 from the Decimal value 9180098.003.