Public Module Example
   Public Sub Main
      Console.WindowWidth = 100
      
      Dim byteValue As Byte = 124
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} (binary: {0:B}) (hex: {0:H})", byteValue))
      
      Dim intValue As Integer = 23045
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} (binary: {0:B}) (hex: {0:H})", intValue))
      
      Dim ulngValue As ULong = 31906574882
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} {1}   (binary: {0:B}) {1}   (hex: {0:H})", _
                                      ulngValue, vbCrLf))

      Dim bigIntValue As BigInteger = BigInteger.Multiply(Int64.MaxValue, 2)
      Console.WriteLine(String.Format(New BinaryFormatter(), _
                                      "{0} {1}   (binary: {0:B}) {1}   (hex: {0:H})", _
                                      bigIntValue, vbCrLf))
   End Sub
End Module
' The example displays the following output:
'    124 (binary: 01111100) (hex: 7c)
'    23045 (binary: 00000000 00000000 01011010 00000101) (hex: 00 00 5a 05)
'    31906574882
'       (binary: 00000000 00000000 00000000 00000111 01101101 11000111 10110010 00100010)
'       (hex: 00 00 00 07 6d c7 b2 22)
'    18446744073709551614
'       (binary: 00000000 11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111110)
'       (hex: 00 ff ff ff ff ff ff ff fe)