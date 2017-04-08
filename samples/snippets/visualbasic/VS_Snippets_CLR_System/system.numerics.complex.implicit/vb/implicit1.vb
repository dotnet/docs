' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      ComplexFromByte()
      Console.WriteLine("-----") 
      ComplexFromDouble()
      Console.WriteLine("-----") 
      ComplexFromInt16()
      Console.WriteLine("-----") 
      ComplexFromInt32()     
      Console.WriteLine("-----") 
      ComplexFromInt64()     
      Console.WriteLine("-----") 
      ComplexFromSByte()     
      Console.WriteLine("-----") 
      ComplexFromSingle()     
      Console.WriteLine("-----") 
      ComplexFromUInt16()
      Console.WriteLine("-----") 
      ComplexFromUInt32()     
      Console.WriteLine("-----") 
      ComplexFromUInt64()     
   End Sub
   
   Private Sub ComplexFromByte()
      ' <Snippet1>
      Dim byteValue As Byte = 122
      Dim c1 As System.Numerics.Complex = byteValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (122, 0) 
      ' </Snippet1>
   End Sub
   
   Private Sub ComplexFromDouble()
      ' <Snippet2>
      Dim doubleValue As Double = 1.032e-16
      Dim c1 As System.Numerics.Complex = doubleValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (1.032E-16, 0) 
      ' </Snippet2>
   End Sub
   
   Private Sub ComplexFromInt16()
      ' <Snippet3>
      Dim shortValue As Short = 16024
      Dim c1 As System.Numerics.Complex = shortValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (16024, 0)
      ' </Snippet3>
   End Sub
   
   Private Sub ComplexFromInt32()
      ' <Snippet4>
      Dim intValue As Integer = 1034217
      Dim c1 As System.Numerics.Complex = intValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (1034217, 0)
      ' </Snippet4>
   End Sub
   
   Private Sub ComplexFromInt64()
      ' <Snippet5>
      Dim longValue As Long = 951034217
      Dim c1 As System.Numerics.Complex = longValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (951034217, 0)
      ' </Snippet5>
   End Sub

   Private Sub ComplexFromSByte()
      ' <Snippet6>
      Dim sbyteValue As SByte = -12
      Dim c1 As System.Numerics.Complex = sbyteValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (-12, 0)
      ' </Snippet6>
   End Sub
   
   Private Sub ComplexFromSingle()
      ' <Snippet7>
      Dim singleValue As Single = 1.032e-08
      Dim c1 As System.Numerics.Complex = singleValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (1.03199999657022E-08, 0) 
      ' </Snippet7>
   End Sub

   Private Sub ComplexFromUInt16()
      ' <Snippet8>
      Dim shortValue As UShort = 421
      Dim c1 As System.Numerics.Complex = shortValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (421, 0)
      ' </Snippet8>
   End Sub
   
   Private Sub ComplexFromUInt32()
      ' <Snippet9>
      Dim intValue As UInteger = 197461
      Dim c1 As System.Numerics.Complex = intValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (197461, 0)
      ' </Snippet9>
   End Sub
   
   Private Sub ComplexFromUInt64()
      ' <Snippet10>
      Dim longValue As ULong = 951034217
      Dim c1 As System.Numerics.Complex = longValue
      Console.WriteLine(c1)
      ' The example displays the following output:
      '       (951034217, 0)
      ' </Snippet10>
   End Sub
End Module

