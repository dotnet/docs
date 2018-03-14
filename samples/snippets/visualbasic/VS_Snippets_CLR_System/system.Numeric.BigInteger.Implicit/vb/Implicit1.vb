' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module ImplicitConversions
   Public Sub Main()
      ShowByteConversion()
      ShowShortConversion()
      ShowIntegerConversion()
      ShowLongConversion()
      ShowSByteConversion()
      ShowUShortConversion()
      ShowUIntegerConversion()
      ShowULongConversion()
   End Sub
   
   Private Sub ShowByteConversion()
      Console.WriteLine("Implicit Byte Conversion:")
      ' <Snippet1>
      Dim byteValue As Byte = 254
      Dim number As BigInteger = byteValue
      number = BigInteger.Add(number, byteValue)
      Console.WriteLine(number > byteValue)           ' Displays True     
      ' </Snippet1>
      Console.WriteLine()
   End Sub
   
   Private Sub ShowShortConversion()
      Console.WriteLine("Implicit Short Conversion:")
      ' <Snippet2>
      Dim shortValue As Short = 25064
      Dim number As BigInteger = shortValue
      number += shortValue
      Console.WriteLine(number < shortValue)           ' Displays False     
      ' </Snippet2>
      Console.WriteLine()
   End Sub
   
   Private Sub ShowIntegerConversion()
      Console.WriteLine("Implicit Integer Conversion:")
      ' <Snippet3>
      Dim integerValue As Integer = 65000
      Dim number As BigInteger = integerValue
      number = BigInteger.Multiply(number, integerValue)
      Console.WriteLine(number = integerValue)           ' Displays False     
      ' </Snippet3>
      Console.WriteLine()
   End Sub

   Private Sub ShowLongConversion()
      Console.WriteLine("Implicit Long Conversion:")
      ' <Snippet4>
      Dim longValue As Long = 1358754982
      Dim number As BigInteger = longValue
      number = number + (longValue \ 2)
      Console.WriteLine(number * longValue / longValue)  ' Displays 2038132473     
      ' </Snippet4>
      Console.WriteLine()
   End Sub
   
   Private Sub ShowSByteConversion()
      Console.WriteLine("Implicit SByte Conversion:")
      ' <Snippet5>
      Dim sByteValue As SByte = -12
      Dim number As BigInteger = BigInteger.Pow(sByteValue, 3)
      Console.WriteLine(number < sByteValue)  ' Displays True     
      ' </Snippet5>
      Console.WriteLine()
   End Sub
   
   Private Sub ShowUShortConversion()
      Console.WriteLine("Implicit UShort Conversion:")
      ' <Snippet6>
      Dim uShortValue As UShort = 25064
      Dim number As BigInteger = uShortValue
      number += uShortValue
      Console.WriteLine(number < uShortValue)           ' Displays False     
      ' </Snippet6>
      Console.WriteLine()
   End Sub
   
   Private Sub ShowUIntegerConversion()
      Console.WriteLine("Implicit UInteger Conversion:")
      ' <Snippet7>
      Dim uIntegerValue As UInteger = 65000
      Dim number As BigInteger = uIntegerValue
      number = BigInteger.Multiply(number, uIntegerValue)
      Console.WriteLine(number = uIntegerValue)           ' Displays False     
      ' </Snippet7>
      Console.WriteLine()
   End Sub

   Private Sub ShowULongConversion()
      Console.WriteLine("Implicit ULong Conversion:")
      ' <Snippet8>
      Dim uLongValue As ULong = 1358754982
      Dim number As BigInteger = uLongValue
      number = number * 2 - uLongValue
      Console.WriteLine(number * uLongValue / uLongValue)  ' Displays 1358754982     
      ' </Snippet8>
      Console.WriteLine()
   End Sub
End Module

