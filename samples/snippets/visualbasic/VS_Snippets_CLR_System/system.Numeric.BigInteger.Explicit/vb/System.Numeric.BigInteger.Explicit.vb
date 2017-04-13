' Illustrates explicit BigInteger conversions defined
' using the op_Explicit method.

Option Strict On

Imports System.Collections
Imports System.Numerics

Module modExplicit
   Public Sub Main()
      ' <Snippet1>
      ' BigInteger to Byte conversion.
      Dim goodByte As BigInteger = BigInteger.One
      Dim badByte As BigInteger = 256
      
      Dim byteFromBigInteger As Byte   
      
      ' Convert using CType function.
      byteFromBigInteger = CType(goodByte, Byte)
      Console.WriteLine(byteFromBigInteger)
      ' Convert using CByte function.
      byteFromBigInteger = CByte(goodByte)
      Console.WriteLine(byteFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         byteFromBigInteger = CType(badByte, Byte)
         Console.WriteLine(byteFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badByte, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet1>
      
      ' <Snippet2>
      ' BigInteger to Decimal conversion.
      Dim goodDecimal As BigInteger = 761652543
      Dim badDecimal As BigInteger = CType(Decimal.MaxValue, BigInteger) 
      badDecimal += BigInteger.One
      
      Dim decimalFromBigInteger As Decimal

      ' Convert using CType function.
      decimalFromBigInteger = CType(goodDecimal, Decimal)
      Console.WriteLine(decimalFromBigInteger)
      ' Convert using CDec function.
      decimalFromBigInteger = CDec(goodDecimal)
      Console.WriteLine(decimalFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         decimalFromBigInteger = CType(badDecimal, Decimal)
         Console.WriteLine(decimalFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badDecimal, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet2>
            
      ' <Snippet3>
      ' BigInteger to Double conversion.
      Dim goodDouble As BigInteger = 102.43e22
      Dim badDouble As BigInteger = CType(Double.MaxValue, BigInteger)  
      badDouble = badDouble * 2
      
      Dim doubleFromBigInteger As Double
      
      ' Convert using CType function.
      doubleFromBigInteger = CType(goodDouble, Double)
      Console.WriteLine(doubleFromBigInteger)
      ' Convert using CDbl function.
      doubleFromBigInteger = CDbl(goodDouble)
      Console.WriteLine(doubleFromBigInteger)
      
      ' Convert an out-of-bounds BigInteger value to a Double.
      doubleFromBigInteger = CType(badDouble, Double)
      Console.WriteLine(doubleFromBigInteger)
      ' </Snippet3>
      
      ' <Snippet4>
      ' BigInteger to Int16 conversion.
      Dim goodShort As BigInteger = 20000
      Dim badShort As BigInteger = 33000
      
      Dim shortFromBigInteger As Short
      
      ' Convert using CType function.
      shortFromBigInteger = CType(goodShort, Short)
      Console.WriteLine(shortFromBigInteger)
      ' Convert using CShort function.
      shortFromBigInteger = CShort(goodShort)
      Console.WriteLine(shortFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         shortFromBigInteger = CType(badShort, Short)
         Console.WriteLine(shortFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badShort, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet4>
            
      ' <Snippet5>
      ' BigInteger to Int32 conversion.
      Dim goodInteger As BigInteger = 200000
      Dim badInteger As BigInteger = 65000000000
      
      Dim integerFromBigInteger As Integer

      ' Convert using CType function.
      integerFromBigInteger = CType(goodInteger, Integer)
      Console.WriteLine(integerFromBigInteger)
      ' Convert using CInt function.
      integerFromBigInteger = CInt(goodInteger)
      Console.WriteLIne(integerFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         integerFromBigInteger = CType(badInteger, Integer)
         Console.WriteLine(integerFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badInteger, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet5>
      
      ' <Snippet6>
      ' BigInteger to Int64 conversion.
      Dim goodLong As BigInteger = 2000000000
      Dim badLong As BigInteger = BigInteger.Pow(goodLong, 3)
      
      Dim longFromBigInteger As Long
      
      ' Convert using CType function.
      longFromBigInteger = CType(goodLong, Long)
      Console.WriteLine(longFromBigInteger)
      ' Convert using CLng function.
      longFromBigInteger = CLng(goodLong)
      Console.WriteLine(longFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         longFromBigInteger = CType(badLong, Long)
         Console.WriteLine(longFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badLong, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet6>

      ' <Snippet7>
      ' BigInteger to SByte conversion.
      Dim goodSByte As BigInteger = BigInteger.MinusOne
      Dim badSByte As BigInteger = -130
      
      Dim sByteFromBigInteger As SByte

      ' Convert using CType function.
      sByteFromBigInteger = CType(goodSByte, SByte)
      Console.WriteLine(sByteFromBigInteger)
      ' Convert using CSByte function.
      sByteFromBigInteger = CSByte(goodSByte)
      Console.WriteLine(sByteFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         sByteFromBigInteger = CType(badSByte, SByte)
         Console.WriteLine(sByteFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badSByte, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet7>
 
      ' <Snippet8>
      ' BigInteger to Single conversion.
      Dim goodSingle As BigInteger = 102.43e22
      Dim badSingle As BigInteger = CType(Single.MaxValue, BigInteger)  
      badSingle = badSingle * 2
      
      Dim singleFromBigInteger As Single
      
      ' Convert using CType function.
      singleFromBigInteger = CType(goodSingle, Single)
      Console.WriteLine(singleFromBigInteger)
      ' Convert using CSng function.
      singleFromBigInteger = CSng(goodSingle)
      Console.WriteLine(singleFromBigInteger)
      
      ' Convert an out-of-bounds BigInteger value to a Single.
      singleFromBigInteger = CType(badSingle, Single)
      Console.WriteLine(singleFromBigInteger)
     ' </Snippet8>
     
      ' <Snippet9>
      ' BigInteger to UInt16 conversion.
      Dim goodUShort As BigInteger = 20000
      Dim badUShort As BigInteger = 66000
      
      Dim uShortFromBigInteger As UShort
      
      ' Convert using CType function.
      uShortFromBigInteger = CType(goodUShort, UShort)
      Console.WriteLine(uShortFromBigInteger)
      ' Convert using CUShort function.
      uShortFromBigInteger = CUShort(goodUShort)
      Console.WriteLine(uShortFromBigInteger)

      ' Handle conversion that should result in overflow.
      Try
         uShortFromBigInteger = CType(badUShort, UShort)
         Console.WriteLine(uShortFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badUShort, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet9> 
      
      ' <Snippet10>
      ' BigInteger to UInt32 conversion.
      Dim goodUInteger As BigInteger = 200000
      Dim badUInteger As BigInteger = 65000000000
      
      Dim uIntegerFromBigInteger As UInteger
      
      ' Convert using CType function.
      uIntegerFromBigInteger = CType(goodInteger, UInteger)
      Console.WriteLine(uIntegerFromBigInteger)
      ' Convert using CUInt function.
      uIntegerFromBigInteger = CUInt(goodInteger)
      Console.WriteLine(uIntegerFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         uIntegerFromBigInteger = CType(badUInteger, UInteger)
         Console.WriteLine(uIntegerFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badUInteger, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet10>
      
      ' <Snippet11>
      ' BigInteger to UInt64 conversion.
      Dim goodULong As BigInteger = 2000000000
      Dim badULong As BigInteger = BigInteger.Pow(goodULong, 3)
      
      Dim uLongFromBigInteger As ULong
      
      ' Convert using CType function.
      uLongFromBigInteger = CType(goodULong, ULong)
      Console.WriteLine(uLongFromBigInteger)
      ' Convert using CULng function.
      uLongFromBigInteger = CULng(goodULong)
      Console.WriteLine(uLongFromBigInteger)
      
      ' Handle conversion that should result in overflow.
      Try
         uLongFromBigInteger = CType(badULong, ULong)
         Console.WriteLine(uLongFromBigInteger)
      Catch e As OverflowException
         Console.WriteLine("Unable to convert {0}:{1}   {2}", _
                           badULong, vbCrLf, e.Message)
      End Try
      Console.WriteLine()
      ' </Snippet11>
      
      ' <Snippet12>
      ' BigInteger to Decimal conversion.
      '
      ' Assign a decimal to a BigInteger
      Dim decimalValue As Decimal = 31043639504.621D
      Dim hugeValueFromDecimal As BigInteger = CType(decimalValue, BigInteger)
      hugeValueFromDecimal = BigInteger.Pow(hugeValueFromDecimal, 2)
      ' Convert the value back to a Decimal if it's in range
      If hugeValuefromDecimal <= CType(Decimal.MaxValue, BigInteger) Then
         decimalValue = CDec(hugeValueFromDecimal)
         Console.WriteLine("The decimal value is {0}", decimalValue)
      Else
         Console.WriteLine("Unable to convert {0} to a Decimal", hugeValueFromDecimal)            
      End If
      ' </Snippet12>

      ' <Snippet13>
      ' BigInteger to Double conversion
      '
      ' Assign a Double to a BigInteger
      Dim doubleValue As Double = 3104363950465.621984
      Dim hugeValueFromDouble As BigInteger = CType(doubleValue, BigInteger)
      hugeValueFromDouble = BigInteger.Pow(hugeValueFromDouble, 3)
      ' Convert the value back to a Double if it's in range
      If hugeValueFromDouble <= CType(Double.MaxValue, BigInteger) Then
         doubleValue = CDbl(hugeValueFromDouble)
         Console.WriteLine("The value of the Double is {0}", doubleValue)
      Else
         Console.WriteLine("Unable to convert {0} to a Double", hugeValueFromDouble)            
      End If
      ' </Snippet13>

      ' <Snippet14>
      ' BigInteger to Single conversion.
      '
      ' Assign a Single to a BigInteger
      Dim singleValue As Single = 3104363950465.621984
      Dim hugeValueFromSingle As BigInteger = CType(singleValue, BigInteger)
      hugeValueFromSingle = BigInteger.Pow(hugeValueFromSingle, 2)
      ' Convert the value back to a Single if it's in range
      If hugeValueFromSingle <= CType(Single.MaxValue, BigInteger) Then
         singleValue = CSng(hugeValueFromSingle)
         Console.WriteLine("The value of the Single is {0}", singleValue)
      Else
         Console.WriteLine("Unable to convert {0} to a Single", hugeValueFromSingle)
      End If
      ' </Snippet14>
   End Sub
End Module   
      
      
