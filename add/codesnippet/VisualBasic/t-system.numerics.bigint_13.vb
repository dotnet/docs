      Dim positiveValue As BigInteger = 15777216
      Dim negativeValue As BigInteger = -1000000
      
      Console.WriteLine("Positive value: " + positiveValue.ToString("N0"))
      Dim bytes() As Byte = positiveValue.ToByteArray()
      For Each byteValue As Byte In bytes
         Console.Write("{0:X2} ", byteValue)
      Next
      Console.WriteLine()
      positiveValue = New BigInteger(bytes)
      Console.WriteLine("Restored positive value: " + positiveValue.ToString("N0"))
      
      Console.WriteLine()
         
      Console.WriteLIne("Negative value: " + negativeValue.ToString("N0"))
      bytes = negativeValue.ToByteArray()
      For Each byteValue As Byte In bytes
         Console.Write("{0:X2} ", byteValue)
      Next
      Console.WriteLine()
      negativeValue = New BigInteger(bytes)
      Console.WriteLine("Restored negative value: " + negativeValue.ToString("N0"))
      ' The example displays the following output:
      '       Positive value: 15,777,216
      '       C0 BD F0 00
      '       Restored positive value: 15,777,216
      '       
      '       Negative value: -1,000,000
      '       C0 BD F0
      '       Restored negative value: -1,000,000