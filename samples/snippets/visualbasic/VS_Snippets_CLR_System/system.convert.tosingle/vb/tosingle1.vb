' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ConvertBoolean()
      Console.WriteLine("-----")
      ConvertByte()
      Console.WriteLine("-----")
      ConvertDecimal()
      Console.WriteLine("-----")
      ConvertDouble()
      Console.WriteLine("-----")      
      ConvertInt16()
      Console.WriteLine("-----")
      ConvertInt32()
      Console.WriteLine("-----")
      ConvertInt64()
      Console.WriteLine("-----")
      ConvertObject()
      Console.WriteLine("-----")
      ConvertSByte()
      Console.WriteLine("-----")
      ConvertString()
      Console.WriteLine("----")
      ConvertUInt16()
      Console.WriteLine("-----")
      ConvertUInt32()
      Console.WriteLIne("------")
      ConvertUInt64()
   End Sub
   
   Private Sub ConvertBoolean()
      ' <Snippet1>
      Dim flags() As Boolean = { True, False }
      Dim result As Single
      
      For Each flag As Boolean In flags
         result = Convert.ToSingle(flag)
         Console.WriteLine("Converted {0} to {1}.", flag, result)
      Next
      ' The example displays the following output:
      '       Converted True to 1.
      '       Converted False to 0.      
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertByte()
      ' <Snippet2>
      Dim numbers() As Byte = { Byte.MinValue, 10, 100, Byte.MaxValue }
      Dim result As Single
      
      For Each number As Byte In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '       Converted the Byte value 0 to the Single value 0.
      '       Converted the Byte value 10 to the Single value 10.
      '       Converted the Byte value 100 to the Single value 100.
      '       Converted the Byte value 255 to the Single value 255.
      ' </Snippet2>
   End Sub

   Private Sub ConvertDecimal()
      ' <Snippet3>
      Dim values() As Decimal = { Decimal.MinValue, -1034.23d, -12d, 0d, 147d, _
                                  199.55d, 9214.16d, Decimal.MaxValue }
      Dim result As Single
      
      For Each value As Decimal In values
         result = Convert.ToSingle(value)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           value.GetType().Name, value, _
                           result.GetType().Name, result)
      Next                                  
      ' The example displays the following output:
      '    Converted the Decimal value '-79228162514264337593543950335' to the Single value -7.922816E+28.
      '    Converted the Decimal value '-1034.23' to the Single value -1034.23.
      '    Converted the Decimal value '-12' to the Single value -12.
      '    Converted the Decimal value '0' to the Single value 0.
      '    Converted the Decimal value '147' to the Single value 147.
      '    Converted the Decimal value '199.55' to the Single value 199.55.
      '    Converted the Decimal value '9214.16' to the Single value 9214.16.
      '    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.
      ' </Snippet3>
   End Sub

   Private Sub ConvertDouble()
      ' <Snippet4>
      Dim values() As Double = { Double.MinValue, -1.38e10, -1023.299, -12.98, _
                                 0, 9.113e-16, 103.919, 17834.191, Double.MaxValue }
      Dim result As Single
      
      For Each value As Double In values
         result = Convert.ToSingle(value)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           value.GetType().Name, value, _
                           result.GetType().Name, result)
      Next                                 
      ' The example displays the following output:
      '    Converted the Double value '-1.79769313486232E+308' to the Single value -Infinity.
      '    Converted the Double value '-13800000000' to the Single value -1.38E+10.
      '    Converted the Double value '-1023.299' to the Single value -1023.299.
      '    Converted the Double value '-12.98' to the Single value -12.98.
      '    Converted the Double value '0' to the Single value 0.
      '    Converted the Double value '9.113E-16' to the Single value 9.113E-16.
      '    Converted the Double value '103.919' to the Single value 103.919.
      '    Converted the Double value '17834.191' to the Single value 17834.19.
      '    Converted the Double value '1.79769313486232E+308' to the Single value Infinity.
      ' </Snippet4>
   End Sub
   
   Private Sub ConvertInt16()
      ' <Snippet5>
      Dim numbers() As Short = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue }
      Dim result As Single
      
      For Each number As Short In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next                     
      ' The example displays the following output:
      '    Converted the Int16 value '-32768' to the Single value -32768.
      '    Converted the Int16 value '-1032' to the Single value -1032.
      '    Converted the Int16 value '0' to the Single value 0.
      '    Converted the Int16 value '192' to the Single value 192.
      '    Converted the Int16 value '32767' to the Single value 32767.
      ' </Snippet5>
   End Sub
   
   Private Sub ConvertInt32
      ' <Snippet6>
      Dim numbers() As Integer = { Int32.MinValue, -1000, 0, 1000, Int32.MaxValue }
      Dim result As Single
      
      For Each number As Integer In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the Int32 value '-2147483648' to the Single value -2.147484E+09.
      '    Converted the Int32 value '-1000' to the Single value -1000.
      '    Converted the Int32 value '0' to the Single value 0.
      '    Converted the Int32 value '1000' to the Single value 1000.
      '    Converted the Int32 value '2147483647' to the Single value 2.147484E+09.
      ' </Snippet6>
   End Sub   

   Private Sub ConvertInt64()
      ' <Snippet7>
      Dim numbers() As Long = { Int64.MinValue, -903, 0, 172, Int64.MaxValue}
      Dim result As Single
      
      For Each number As Long In numbers
         result = Convert.ToSingle(number)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)

      Next
      ' The example displays the following output:
      '    Converted the Int64 value '-9223372036854775808' to the Single value -9.223372E+18.
      '    Converted the Int64 value '-903' to the Single value -903.
      '    Converted the Int64 value '0' to the Single value 0.
      '    Converted the Int64 value '172' to the Single value 172.
      '    Converted the Int64 value '9223372036854775807' to the Single value 9.223372E+18.
      ' </Snippet7>
   End Sub
   
   Private Sub ConvertObject()
      ' <Snippet8>
      Dim values() As Object = { True, "a"c, 123, 1.764e32, "9.78", "1e-02", _
                                 1.67e03, "A100", "1,033.67", Date.Now, _
                                 Decimal.MaxValue }   
      Dim result As Single
      
      For Each value As Object In values
         Try
            result = Convert.ToSingle(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)

         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not recognized as a valid Single value.", _
                              value.GetType().Name, value)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Single type.", _
                              value.GetType().Name, value)
         
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Single is not supported.", _
                              value.GetType().Name, value)
         End Try                     
      Next
      ' The example displays the following output:
      '    Converted the Boolean value 'True' to the Single value 1.
      '    Conversion of the Char value a to a Single is not supported.
      '    Converted the Int32 value '123' to the Single value 123.
      '    Converted the Double value '1.764E+32' to the Single value 1.764E+32.
      '    Converted the String value '9.78' to the Single value 9.78.
      '    Converted the String value '1e-02' to the Single value 0.01.
      '    Converted the Double value '1670' to the Single value 1670.
      '    The String value A100 is not recognized as a valid Single value.
      '    Converted the String value '1,033.67' to the Single value 1033.67.
      '    Conversion of the DateTime value 11/7/2008 07:56:24 AM to a Single is not supported.
      '    Converted the Decimal value '79228162514264337593543950335' to the Single value 7.922816E+28.
      ' </Snippet8>
   End Sub   
   
   Private Sub ConvertSByte()
      ' <Snippet9>
      Dim numbers() As SByte = { SByte.MinValue, -23, 0, 17, SByte.MaxValue }
      Dim result As Single
      
      For Each number As SByte In numbers
         result = Convert.ToSingle(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the SByte value '-128' to the Single value -128.
      '    Converted the SByte value '-23' to the Single value -23.
      '    Converted the SByte value '0' to the Single value 0.
      '    Converted the SByte value '17' to the Single value 17.
      '    Converted the SByte value '127' to the Single value 127.
      ' </Snippet9>
   End Sub

   Private Sub ConvertString()
      ' <Snippet10>
      Dim values() As String = { "-1,035.77219", "1AFF", "1e-35", "1.63f",
                                 "1,635,592,999,999,999,999,999,999", "-17.455",
                                 "190.34001", "1.29e325"}
      Dim result As Single
      
      For Each value As String In values
         Try
            result = Convert.ToSingle(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As FormatException
            Console.WriteLine("Unable to convert '{0}' to a Single.", value)            
         Catch e As OverflowException
            Console.WriteLine("'{0}' is outside the range of a Single.", value)
         End Try
      Next       
      ' The example displays the following output:
      '    Converted the String value '-1,035.77219' to the Single value -1035.772.
      '    Unable to convert '1AFF' to a Single.
      '    Converted the String value '1e-35' to the Single value 1E-35.
      '    Unable to convert '1.63f' to a Single.
      '    Converted the String value '1,635,592,999,999,999,999,999,999' to the Single value 1.635593E+24.
      '    Converted the String value '-17.455' to the Single value -17.455.
      '    Converted the String value '190.34001' to the Single value 190.34.
      '    '1.29e325' is outside the range of a Single.
      ' </Snippet10>
   End Sub

   Private Sub ConvertUInt16()
      ' <Snippet11>
      Dim numbers() As UShort = { UInt16.MinValue, 121, 12345, UInt16.MaxValue }
      Dim result As Single
      
      For Each number As UShort In numbers
         result = Convert.ToSingle(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next   
      ' The example displays the following output:
      '    Converted the UInt16 value '0' to the Single value 0.
      '    Converted the UInt16 value '121' to the Single value 121.
      '    Converted the UInt16 value '12345' to the Single value 12345.
      '    Converted the UInt16 value '65535' to the Single value 65535.
      ' </Snippet11>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet12>
      Dim numbers() As UInteger = { UInt32.MinValue, 121, 12345, UInt32.MaxValue }
      Dim result As Single
      
      For Each number As UInteger In numbers
         result = Convert.ToSingle(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next   
      ' The example displays the following output:
   '    Converted the UInt32 value '0' to the Single value 0.
   '    Converted the UInt32 value '121' to the Single value 121.
   '    Converted the UInt32 value '12345' to the Single value 12345.
   '    Converted the UInt32 value '4294967295' to the Single value 4.294967E+09.
      ' </Snippet12>
   End Sub

   Private Sub ConvertUInt64()
      ' <Snippet13>
      Dim numbers() As ULong = { UInt64.MinValue, 121, 12345, UInt64.MaxValue }
      Dim result As Single
      
      For Each number As ULong In numbers
         result = Convert.ToSingle(number)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next   
      ' The example displays the following output:
      '    Converted the UInt64 value '0' to the Single value 0.
      '    Converted the UInt64 value '121' to the Single value 121.
      '    Converted the UInt64 value '12345' to the Single value 12345.
      '    Converted the UInt64 value '18446744073709551615' to the Single value 1.844674E+19.
      ' </Snippet13>
   End Sub
End Module

