' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ConvertInt16()
      Console.WriteLIne("-----")
      ConvertInt64()
      Console.WriteLine("-----")
      ConvertObject()
      Console.WriteLine("-----")
      ConvertSByte()
      Console.WriteLine("----")
      ConvertUInt16()
      Console.WriteLine("-----")
      ConvertUInt32()
      Console.WriteLIne("------")
      ConvertUInt64()
      Console.WriteLine("-----")
      ConvertString()
   End Sub
   
   Private Sub ConvertInt16()
      ' <Snippet1>
      Dim numbers() As Short = { Int16.MinValue, -1032, 0, 192, Int16.MaxValue }
      Dim result As Double
      
      For Each number As Short In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the UInt16 value {0} to {1}.", _
                           number, result)
      Next                     
      '       Converted the UInt16 value -32768 to -32768.
      '       Converted the UInt16 value -1032 to -1032.
      '       Converted the UInt16 value 0 to 0.
      '       Converted the UInt16 value 192 to 192.
      '       Converted the UInt16 value 32767 to 32767.
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertInt64()
      ' <Snippet2>
      Dim numbers() As Long = { Int64.MinValue, -903, 0, 172, Int64.MaxValue}
      Dim result As Double
      
      For Each number As Long In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)

      Next
      ' The example displays the following output:
      '    Converted the Int64 value '-9223372036854775808' to the Double value -9.22337203685478E+18.
      '    Converted the Int64 value '-903' to the Double value -903.
      '    Converted the Int64 value '0' to the Double value 0.
      '    Converted the Int64 value '172' to the Double value 172.
      '    Converted the Int64 value '9223372036854775807' to the Double value 9.22337203685478E+18.
      ' </Snippet2>
   End Sub
   
   Private Sub COnvertObject()
      ' <Snippet3>
      Dim values() As Object = { True, "a"c, 123, CSng(1.764e32), "9.78", "1e-02", _
                                 CSng(1.67e03), "A100", "1,033.67", Date.Now, _
                                 Decimal.MaxValue }   
      Dim result As Double
      
      For Each value As Object In values
         Try
            result = Convert.ToDouble(value)
            Console.WriteLine("Converted the {0} value {1} to {2}.", _
                              value.GetType().Name, value, result)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not recognized as a valid Double value.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Double is not supported.", _
                              value.GetType().Name, value)
         End Try                     
      Next
      ' The example displays the following output:
      '    Converted the Boolean value True to 1.
      '    Conversion of the Char value a to a Double is not supported.
      '    Converted the Int32 value 123 to 123.
      '    Converted the Single value 1.764E+32 to 1.76399995098587E+32.
      '    Converted the String value 9.78 to 9.78.
      '    Converted the String value 1e-02 to 0.01.
      '    Converted the Single value 1670 to 1670.
      '    The String value A100 is not recognized as a valid Double value.
      '    Converted the String value 1,033.67 to 1033.67.
      '    Conversion of the DateTime value 10/21/2008 07:12:12 AM to a Double is not supported.
      '    Converted the Decimal value 79228162514264337593543950335 to 7.92281625142643E+28.      
      ' </Snippet3>
   End Sub   
   
   Private Sub ConvertSByte()
      ' <Snippet4>
      Dim numbers() As SByte = { SByte.MinValue, -23, 0, 17, SByte.MaxValue }
      Dim result As Double
      
      For Each number As SByte In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the SByte value {0} to {1}.", number, result)
      Next
      '       Converted the SByte value -128 to -128.
      '       Converted the SByte value -23 to -23.
      '       Converted the SByte value 0 to 0.
      '       Converted the SByte value 17 to 17.
      '       Converted the SByte value 127 to 127.
      ' </Snippet4>
   End Sub

   Private Sub ConvertUInt16()
      ' <Snippet5>
      Dim numbers() As UShort = { UInt16.MinValue, 121, 12345, UInt16.MaxValue }
      Dim result As Double
      
      For Each number As UShort In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the UInt16 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '       Converted the UInt16 value 0 to 0.
      '       Converted the UInt16 value 121 to 121.
      '       Converted the UInt16 value 12345 to 12345.
      '       Converted the UInt16 value 65535 to 65535.      
      ' </Snippet5>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet6>
      Dim numbers() As UInteger = { UInt32.MinValue, 121, 12345, UInt32.MaxValue }
      Dim result As Double
      
      For Each number As UInteger In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the UInt32 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '       Converted the UInt32 value 0 to 0.
      '       Converted the UInt32 value 121 to 121.
      '       Converted the UInt32 value 12345 to 12345.
      '       Converted the UInt32 value 4294967295 to 4294967295.
      ' </Snippet6>
   End Sub

   Private Sub ConvertUInt64()
      ' <Snippet7>
      Dim numbers() As ULong = { UInt64.MinValue, 121, 12345, UInt64.MaxValue }
      Dim result As Double
      
      For Each number As ULong In numbers
         result = Convert.ToDouble(number)
         Console.WriteLine("Converted the UInt64 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to 0.
      '    Converted the UInt64 value 121 to 121.
      '    Converted the UInt64 value 12345 to 12345.
      '    Converted the UInt64 value 18446744073709551615 to 1.84467440737096E+19.
      ' </Snippet7>
   End Sub
   
   Private Sub ConvertString()
      ' unused
      Dim values() As String = { "-1,035.77219", "1AFF", "1e-35", _
                                 "1,635,592,999,999,999,999,999,999", "-17.455", _
                                 "190.34001", "1.29e325"}
      Dim result As Double
      
      For Each value As String In values
         Try
            result = Convert.ToDouble(value)
            Console.WriteLine("Converted '{0}' to {1}.", value, result)
         Catch e As FormatException
            Console.WriteLine("Unable to convert '{0}' to a Double.", value)            
         Catch e As OverflowException
            Console.WriteLine("'{0}' is outside the range of a Double.", value)
         End Try
      Next       
      ' The example displays the following output:
      '       Converted '-1,035.77219' to -1035.77219.
      '       Unable to convert '1AFF' to a Double.
      '       Converted '1e-35' to 1E-35.
      '       Converted '1,635,592,999,999,999,999,999,999' to 1.635593E+24.
      '       Converted '-17.455' to -17.455.
      '       Converted '190.34001' to 190.34001.
      '       '1.29e325' is outside the range of a Double.
   End Sub   
End Module

