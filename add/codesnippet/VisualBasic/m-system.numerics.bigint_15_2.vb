      ' Instantiate BigInteger values.
      Dim positiveValue As BigInteger = BigInteger.Parse("4713143110832790377889")
      Dim negativeValue As BigInteger = BigInteger.Add(-Int64.MaxValue, -60000) 
      Dim positiveValue2, negativeValue2 As BigInteger
      
      ' Create two byte arrays.
      Dim positiveBytes() As Byte = positiveValue.ToByteArray()
      Dim negativeBytes() As Byte = negativeValue.ToByteArray()
      
      ' Instantiate new BigInteger from negativeBytes array.
      Console.Write("Converted {0:N0} to the byte array ", negativeValue)
      For Each byteValue As Byte In negativeBytes
         Console.Write("{0:X2} ", byteValue)
      Next 
      Console.WriteLine()
      negativeValue2 = New BigInteger(negativeBytes)
      Console.WriteLine("Converted the byte array to {0:N0}", negativeValue2)
      Console.WriteLine()
      
      ' Instantiate new BigInteger from positiveBytes array.
      Console.Write("Converted {0:N0} to the byte array ", positiveValue)
      For Each byteValue As Byte In positiveBytes
         Console.Write("{0:X2} ", byteValue)
      Next 
      Console.WriteLine()
      positiveValue2 = New BigInteger(positiveBytes)
      Console.WriteLine("Converted the byte array to {0:N0}", positiveValue2)
      Console.WriteLine()
      ' The example displays the following output:
      '    Converted -9,223,372,036,854,835,807 to the byte array A1 15 FF FF FF FF FF 7F FF
      '    Converted the byte array to -9,223,372,036,854,835,807
      '    
      '    Converted 4,713,143,110,832,790,377,889 to the byte array A1 15 FF FF FF FF FF 7F FF 00
      '    Converted the byte array to 4,713,143,110,832,790,377,889