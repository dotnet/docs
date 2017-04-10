' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Dim bytes() As Byte
      
   Public Sub Main()
      Dim numbers() As BigInteger = { BigInteger.MinusOne, BigInteger.One, 
                                      BigInteger.Zero, 120, 128, 255, 1024, 
                                      Int64.MinValue, Int64.MaxValue, 
                                      BigInteger.Parse("90123123981293054321") }
      For Each number As BigInteger In numbers
         bytes = number.ToByteArray()
         Console.Write("{0} ({1}) -> ", number, number.ToString(GetSpecifier()))
         Console.Write("{0} bytes: ", bytes.Length)
         For Each byteValue As Byte In bytes
            Console.Write("{0:X2} ", byteValue)
         Next
         Console.WriteLine()
      Next   
   End Sub
   
   Private Function GetSpecifier() As String
      Return "X" + CStr(bytes.Length * 2)
   End Function
End Module
' The example displays the following output:
'    -1 (FF) -> 1 bytes: FF
'    1 (01) -> 1 bytes: 01
'    0 (00) -> 1 bytes: 00
'    120 (78) -> 1 bytes: 78
'    128 (0080) -> 2 bytes: 80 00
'    255 (00FF) -> 2 bytes: FF 00
'    1024 (0400) -> 2 bytes: 00 04
'    -9223372036854775808 (8000000000000000) -> 8 bytes: 00 00 00 00 00 00 00 80
'    9223372036854775807 (7FFFFFFFFFFFFFFF) -> 8 bytes: FF FF FF FF FF FF FF 7F
'    90123123981293054321 (04E2B5A7C4A975E971) -> 9 bytes: 71 E9 75 A9 C4 A7 B5 E2 04
' </Snippet1>
