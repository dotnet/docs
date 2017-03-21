      Dim originalValue As Short = 30000
      Console.WriteLine(originalValue)
      
      ' Convert the Int16 value to a byte array.
      Dim bytes() As Byte = BitConverter.GetBytes(originalValue)

      ' Display the byte array.
      For Each byteValue As Byte In bytes
         Console.Write("0x{0} ", byteValue.ToString("X2"))
      Next    
      Console.WriteLine() 

      ' Pass byte array to the BigInteger constructor.
      Dim number As BigInteger = New BigInteger(bytes)
      Console.WriteLine(number)
      ' The example displays the following output:
      '       30000
      '       0x30 0x75
      '       30000