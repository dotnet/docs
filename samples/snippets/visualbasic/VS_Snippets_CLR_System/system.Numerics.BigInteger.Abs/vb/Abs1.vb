' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO
Imports System.Numerics
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable> Public Structure SignAndMagnitude
   Dim Sign As Integer
   Dim Bytes() As Byte
End Structure

Module Example
   Public Sub Main()
      Dim fs As FileStream
      Dim formatter As New BinaryFormatter()

      Dim number As BigInteger = BigInteger.Pow(Int32.MaxValue, 20) * BigInteger.MinusOne
      Console.WriteLine("The original value is {0}.", number)
      Dim sm As New SignAndMagnitude()
      sm.Sign = number.Sign
      sm.Bytes = BigInteger.Abs(number).ToByteArray()
      
      ' Serialize SignAndMagnitude value.
      fs = New FileStream(".\data.bin", FileMode.Create)
      formatter.Serialize(fs, sm)
      fs.Close()
      
      ' Deserialize SignAndMagnitude value.
      fs = New FileStream(".\data.bin", FileMode.Open)
      Dim smRestored As SignAndMagnitude = DirectCast(formatter.Deserialize(fs), SignAndMagnitude)
      fs.Close()
      Dim restoredNumber As New BigInteger(smRestored.Bytes) 
      restoredNumber *= sm.Sign 
      Console.WriteLine("The deserialized value is {0}.", restoredNumber)      
   End Sub
End Module
' The example displays the following output:
'    The original value is -4.3510823966323432743748744058E+186.
'    The deserialized value is -4.3510823966323432743748744058E+186.
' </Snippet1>