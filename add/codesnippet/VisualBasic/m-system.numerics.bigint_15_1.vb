      Dim bytes() As Byte = { 5, 4, 3, 2, 1 }
      Dim number As New BigInteger(bytes)
      Console.WriteLine("The value of number is {0} (or 0x{0:x}).", number) 
      ' The example displays the following output:
      '    The value of number is 4328719365 (or 0x102030405).   