' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      Console.WindowWidth = 90
      CreateSimpleArray()
      Console.WriteLine()
      RoundtripValue()
      Console.WriteLine()
      EnsureSign()
   End Sub
   
   Private Sub CreateSimpleArray()
      ' <Snippet1>
      Dim bytes() As Byte = { 5, 4, 3, 2, 1 }
      Dim number As New BigInteger(bytes)
      Console.WriteLine("The value of number is {0} (or 0x{0:x}).", number) 
      ' The example displays the following output:
      '    The value of number is 4328719365 (or 0x102030405).   
      ' </Snippet1>
   End Sub
   
   Private Sub RoundtripValue()
      ' <Snippet2>
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
      ' </Snippet2>
   End Sub
   
   Private Sub EnsureSign()
      ' <Snippet3>
      Dim originalNumber As ULong = UInt64.MaxValue
      ' Convert an unsigned integer to a byte array.
      Dim bytes() As Byte = BitConverter.GetBytes(originalNumber)
      ' Determine whether the MSB of the highest-order byte is set.
      If originalNumber > 0 And (bytes(bytes.Length - 1) And &h80) > 0 Then
         ' If the MSB is set, add one zero-value byte to the end of the array.
         ReDim Preserve bytes(bytes.Length)
      End If
      
      Dim newNumber As New BigInteger(bytes)
      Console.WriteLine("Converted the UInt64 value {0:N0} to {1:N0}.", 
                        originalNumber, newNumber) 
      ' The example displays the following output:
      '    Converted the UInt64 value 18,446,744,073,709,551,615 to 18,446,744,073,709,551,615.
      ' </Snippet3>
   End Sub
End Module

