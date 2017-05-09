' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example
   Public Sub Main()
      CompareToLong()
      Console.WRiteLIne("-----")
      CompareToObject()
   End Sub

   Private Sub CompareToLong()
      ' <Snippet3>
      Dim bigIntValue As BigInteger = BigInteger.Parse("3221123045552")

      Dim byteValue As Byte = 16
      Dim sbyteValue As SByte = -16
      Dim shortValue As Short = 1233      
      Dim ushortValue As UShort = 1233
      Dim intValue As Integer = -12233
      Dim uintValue As UInteger = 12233
      Dim longValue As Long = 12382222
      Dim ulongValue As Integer = 1238222

      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, byteValue, _
                        bigIntValue.CompareTo(byteValue))
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, sbyteValue, _
                        bigIntValue.CompareTo(sbyteValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, shortValue, _
                        bigIntValue.CompareTo(shortValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, ushortValue, _
                        bigIntValue.CompareTo(ushortValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, intValue, _
                        bigIntValue.CompareTo(intValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, uintValue, _
                        bigIntValue.CompareTo(uintValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, longValue, _
                        bigIntValue.CompareTo(longValue)) 
      Console.WriteLine("Comparing {0} with {1}: {2}", _
                        bigIntValue, ulongValue, _
                        bigIntValue.CompareTo(ulongValue))
      ' The example displays the following output:
      '       Comparing 3221123045552 with 16: 1
      '       Comparing 3221123045552 with -16: 1
      '       Comparing 3221123045552 with 1233: 1
      '       Comparing 3221123045552 with 1233: 1
      '       Comparing 3221123045552 with -12233: 1
      '       Comparing 3221123045552 with 12233: 1
      '       Comparing 3221123045552 with 12382222: 1
      '       Comparing 3221123045552 with 1238222: 1
      ' </Snippet3>
   End Sub   

   Private Sub CompareTOObject()
     ' <Snippet4>
      Dim values() As Object = { BigInteger.Pow(Int64.MaxValue, 10), Nothing, 
                                 12.534, Int64.MaxValue, BigInteger.One }
      Dim number As BigInteger = UInt64.MaxValue
      
      For Each value As Object In values
         Try
            Console.WriteLine("Comparing {0} with '{1}': {2}", number, value, 
                              number.CompareTo(value))
         Catch e As ArgumentException
            Console.WriteLine("Unable to compare the {0} value {1} with a BigInteger.",
                              value.GetType().Name, value)
         End Try                     
      Next                                 
      ' The example displays the following output:
      '    Comparing 18446744073709551615 with '4.4555084156466750133735972424E+189': -1
      '    Comparing 18446744073709551615 with '': 1
      '    Unable to compare the Double value 12.534 with a BigInteger.
      '    Unable to compare the Int64 value 9223372036854775807 with a BigInteger.
      '    Comparing 18446744073709551615 with '1': 1
      ' </Snippet4>
   End Sub
End Module

