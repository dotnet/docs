' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Numerics

Module Example
   Public Sub Main()
      RoundtripBigInteger()
      Console.WriteLIne()
      RoundtripInt16()
      Console.WriteLine()
      HandleSignsInByteArray()
      Console.WriteLine()
      RoundtripAmbiguous()
      Console.WriteLine()
      RoundtripWithHex()
      Console.WriteLine()
   End Sub

   Private Sub RoundTripBigInteger()
      Console.WriteLine("Round-trip bytes")
      
      ' <Snippet1>
      Dim number As BigInteger = BigInteger.Pow(Int64.MaxValue, 2)     
      Console.WriteLine(number)
      
      ' Write the BigInteger value to a byte array.
      Dim bytes() As Byte = number.ToByteArray()

      ' Display the byte array.
      For Each byteValue As Byte In bytes
         Console.Write("0x{0:X2} ", byteValue)
      Next   
      Console.WriteLine()

      ' Restore the BigInteger value from a Byte array.
      Dim newNumber As BigInteger = New BigInteger(bytes)
      Console.WriteLine(newNumber)               
      ' The example displays the following output:
      '    8.5070591730234615847396907784E+37
      '    0x01 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0x3F
      '    
      '    8.5070591730234615847396907784E+37
      ' </Snippet1>
   End Sub

   Private Sub RoundTripInt16()
      Console.WriteLine()
      Console.WriteLine("Round-trip an Int16 value:")
      ' <Snippet2>
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
      ' </Snippet2>
   End Sub      
   
   PRivate Sub HandleSignsInByteArray()
      ' <Snippet3>
      Dim negativeNumber As Integer = -1000000
      Dim positiveNumber As UInteger = 4293967296
      
      Dim negativeBytes() As Byte = BitConverter.GetBytes(negativeNumber) 
      Dim negativeBigInt As New BigInteger(negativeBytes)
      Console.WriteLine(negativeBigInt.ToString("N0"))
      
      Dim tempPosBytes() As Byte = BitConverter.GetBytes(positiveNumber)
      Dim positiveBytes(tempposBytes.Length) As Byte
      Array.Copy(tempPosBytes, positiveBytes, tempPosBytes.Length)
      Dim positiveBigInt As New BigInteger(positiveBytes)
      Console.WriteLine(positiveBigInt.ToString("N0")) 
      ' The example displays the following output:
      '    -1,000,000
      '    4,293,967,296      
      ' </Snippet3>
   End Sub

   Private Sub RoundtripAmbiguous()
      ' <Snippet4>
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
      ' </Snippet4>
   End Sub
   
   Private Sub RoundtripWithHex()
      ' <Snippet5>
      Dim negativeNumber As BigInteger = -1000000
      Dim positiveNumber As BigInteger = 15777216
      
      Dim negativeHex As String = negativeNumber.ToString("X")
      Dim positiveHex As string = positiveNumber.ToString("X")
      
      Dim negativeNumber2, positiveNumber2 As BigInteger 
      negativeNumber2 = BigInteger.Parse(negativeHex, 
                                         NumberStyles.HexNumber)
      positiveNumber2 = BigInteger.Parse(positiveHex,
                                         NumberStyles.HexNumber)

      Console.WriteLine("Converted {0:N0} to {1} back to {2:N0}.", 
                         negativeNumber, negativeHex, negativeNumber2)                                         
      Console.WriteLine("Converted {0:N0} to {1} back to {2:N0}.", 
                         positiveNumber, positiveHex, positiveNumber2)                                         
      ' The example displays the following output:
      '       Converted -1,000,000 to F0BDC0 back to -1,000,000.
      '       Converted 15,777,216 to 0F0BDC0 back to 15,777,216.
      ' </Snippet5>
   End Sub
   
End Module

