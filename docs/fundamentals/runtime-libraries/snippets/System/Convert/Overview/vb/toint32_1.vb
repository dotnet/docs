' Visual Basic .NET Document
Option Strict On

Module modMain
   Public Sub Main()
      ConvertBoolean()
      Console.WriteLine("-----")
      ConvertByte()
      Console.WriteLine("-----")
      ConvertChar()
      Console.WriteLine("-----")
      ConvertDecimal()
      Console.WriteLine("-----")
      ConvertDouble()
      Console.WriteLine("-----")
      ConvertInt16()
      Console.WriteLine("-----")
      ConvertInt64()
      Console.WriteLine("-----")
      ConvertObject()
      Console.WriteLine("-----")
      ConvertSByte()
      Console.WriteLine("-----")
      ConvertSingle()
      Console.WriteLine("----")
      ConvertString()            ' NEW
      Console.WriteLine("-----")
      ConvertUInt16()
      Console.WriteLine("-----")
      ConvertUInt32()
      Console.WriteLine("-----")
      ConvertUInt64()
   End Sub

   Private Sub ConvertBoolean()
      ' <Snippet1>
      Dim falseFlag As Boolean = False
      Dim trueFlag As Boolean = True
      
      Console.WriteLine("{0} converts to {1}.", falseFlag, _
                        Convert.ToInt32(falseFlag))
      Console.WriteLine("{0} converts to {1}.", trueFlag, _
                        Convert.ToInt32(trueFlag))
      ' The example displays the following output:
      '       False converts to 0.
      '       True converts to 1.
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertByte()
      ' <Snippet2>
      Dim bytes() As Byte = { Byte.MinValue, 14, 122, Byte.MaxValue}
      Dim result As Integer
      
      For Each byteValue As Byte In bytes
         result = Convert.ToInt32(byteValue)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           byteValue.GetType().Name, byteValue, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '       Converted the Byte value 0 to the Int32 value 0.
      '       Converted the Byte value 14 to the Int32 value 14.
      '       Converted the Byte value 122 to the Int32 value 122.
      '       Converted the Byte value 255 to the Int32 value 255.
      ' </Snippet2>
   End Sub   
   
   Private Sub ConvertChar()
      ' <Snippet3>
      Dim chars() As Char = { "a"c, "z"c, ChrW(7), ChrW(1023), _
                              ChrW(Short.MaxValue), ChrW(&hFFFE) }
      Dim result As Integer
                              
      For Each ch As Char in chars
         Try
            result = Convert.ToInt32(ch)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              ch.GetType().Name, ch, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("Unable to convert u+{0} to an Int32.", _
                              AscW(ch).ToString("X4"))
         End Try
      Next   
      ' The example displays the following output:
      '       Converted the Char value 'a' to the Int32 value 97.
      '       Converted the Char value 'z' to the Int32 value 122.
      '       Converted the Char value '' to the Int32 value 7.
      '       Converted the Char value 'Ͽ' to the Int32 value 1023.
      '       Converted the Char value '翿' to the Int32 value 32767.
      '       Converted the Char value '￾' to the Int32 value 65534.
      ' </Snippet3>
   End Sub
   
   Private Sub ConvertDecimal()
      ' <Snippet4>
      Dim values() As Decimal = { Decimal.MinValue, -1034.23d, -12d, 0d, 147d, _
                                  199.55d, 9214.16d, Decimal.MaxValue }
      Dim result As Integer
      
      For Each value As Decimal In values
         Try
            result = Convert.ToInt32(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int32 type.", _
                              value)
         End Try   
      Next                                  
      ' The example displays the following output:
      '    -79228162514264337593543950335 is outside the range of the Int32 type.
      '    Converted the Decimal value '-1034.23' to the Int32 value -1034.
      '    Converted the Decimal value '-12' to the Int32 value -12.
      '    Converted the Decimal value '0' to the Int32 value 0.
      '    Converted the Decimal value '147' to the Int32 value 147.
      '    Converted the Decimal value '199.55' to the Int32 value 200.
      '    Converted the Decimal value '9214.16' to the Int32 value 9214.
      '    79228162514264337593543950335 is outside the range of the Int32 type.
      ' </Snippet4>
   End Sub
   
   Private Sub ConvertDouble()
      ' <Snippet5>
      Dim values() As Double = { Double.MinValue, -1.38e10, -1023.299, -12.98, _
                                 0, 9.113e-16, 103.919, 17834.191, Double.MaxValue }
      Dim result As Integer
      
      For Each value As Double In values
         Try
            result = Convert.ToInt32(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int32 type.", value)
         End Try   
      Next                                 
      '    -1.79769313486232E+308 is outside the range of the Int32 type.
      '    -13800000000 is outside the range of the Int32 type.
      '    Converted the Double value '-1023.299' to the Int32 value -1023.
      '    Converted the Double value '-12.98' to the Int32 value -13.
      '    Converted the Double value '0' to the Int32 value 0.
      '    Converted the Double value '9.113E-16' to the Int32 value 0.
      '    Converted the Double value '103.919' to the Int32 value 104.
      '    Converted the Double value '17834.191' to the Int32 value 17834.
      '    1.79769313486232E+308 is outside the range of the Int32 type.
      ' </Snippet5>
   End Sub
      
   Private Sub ConvertInt16()
      ' <Snippet6>
      Dim numbers() As Short = { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue }
      Dim result As Integer
      
      For Each number As Short In numbers
         result = Convert.ToInt32(number)
         Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the Int16 value -32768 to a Int32 value -32768.
      '    Converted the Int16 value -1 to a Int32 value -1.
      '    Converted the Int16 value 0 to a Int32 value 0.
      '    Converted the Int16 value 121 to a Int32 value 121.
      '    Converted the Int16 value 340 to a Int32 value 340.
      '    Converted the Int16 value 32767 to a Int32 value 32767.
      ' </Snippet6>
   End Sub
   
   Private Sub ConvertInt64
      ' <Snippet7>
      Dim numbers() As Long = { Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue }
      Dim result As Integer
      For Each number As Long In numbers
         Try
            result = Convert.ToInt32(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    The Int64 value -9223372036854775808 is outside the range of the Int32 type.
      '    Converted the Int64 value -1 to the Int32 value -1.
      '    Converted the Int64 value 0 to the Int32 value 0.
      '    Converted the Int64 value 121 to the Int32 value 121.
      '    Converted the Int64 value 340 to the Int32 value 340.
      '    The Int64 value 9223372036854775807 is outside the range of the Int32 type.
      ' </Snippet7>   
   End Sub   
   
   Private Sub ConvertObject()
      ' <Snippet8>
      Dim values() As Object = { True, -12, 163, 935, "x"c, #5/12/2009#, _
                                 "104", "103.0", "-1", _
                                 "1.00e2", "One", 1.00e2, 16.3e42}
      Dim result As Integer
      
      For Each value As Object In values
         Try
            result = Convert.ToInt32(value)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.", _
                              value.GetType().Name, value)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not in a recognizable format.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("No conversion to an Int32 exists for the {0} value {1}.", _
                              value.GetType().Name, value)
                              
         End Try
      Next                           
      ' The example displays the following output:
      '    Converted the Boolean value True to the Int32 value 1.
      '    Converted the Int32 value -12 to the Int32 value -12.
      '    Converted the Int32 value 163 to the Int32 value 163.
      '    Converted the Int32 value 935 to the Int32 value 935.
      '    Converted the Char value x to the Int32 value 120.
      '    No conversion to an Int32 exists for the DateTime value 5/12/2009 12:00:00 AM.
      '    Converted the String value 104 to the Int32 value 104.
      '    The String value 103.0 is not in a recognizable format.
      '    Converted the String value -1 to the Int32 value -1.
      '    The String value 1.00e2 is not in a recognizable format.
      '    The String value One is not in a recognizable format.
      '    Converted the Double value 100 to the Int32 value 100.
      '    The Double value 1.63E+43 is outside the range of the Int32 type.
      ' </Snippet8>
   End Sub
   
   Private Sub ConvertSByte()
      ' <Snippet9>
      Dim numbers() As SByte = { SByte.MinValue, -1, 0, 10, SByte.MaxValue }
      Dim result As Integer
      
      For Each number As SByte In numbers
         result = Convert.ToInt32(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                           number.GetType().Name, number, _
                           result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '       Converted the SByte value -128 to the Int32 value -128.
      '       Converted the SByte value -1 to the Int32 value -1.
      '       Converted the SByte value 0 to the Int32 value 0.
      '       Converted the SByte value 10 to the Int32 value 10.
      '       Converted the SByte value 127 to the Int32 value 127.
      ' </Snippet9>
   End Sub
   
   Private Sub ConvertSingle()
      ' <Snippet10>
      Dim values() As Single = { Single.MinValue, -1.38e10, -1023.299, -12.98, _
                                 0, 9.113e-16, 103.919, 17834.191, Single.MaxValue }
      Dim result As Integer
      
      For Each value As Single In values
         Try
            result = Convert.ToInt32(value)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int32 type.", value)
         End Try   
      Next                                 
      ' The example displays the following output:
      '    -3.40282346638529E+38 is outside the range of the Int32 type.
      '    -13799999488 is outside the range of the Int32 type.
      '    Converted the Double value -1023.29901123047 to the Int32 value -1023.
      '    Converted the Double value -12.9799995422363 to the Int32 value -13.
      '    Converted the Double value 0 to the Int32 value 0.
      '    Converted the Double value 9.11299983940444E-16 to the Int32 value 0.
      '    Converted the Double value 103.918998718262 to the Int32 value 104.
      '    Converted the Double value 17834.19140625 to the Int32 value 17834.
      '    3.40282346638529E+38 is outside the range of the Int32 type.
      ' </Snippet10>
   End Sub

   Private Sub ConvertString()
      ' <Snippet11>
      Dim values() As String = { "One", "1.34e28", "-26.87", "-18", "-6.00", _
                                 " 0", "137", "1601.9", Int32.MaxValue.ToString() }
      Dim result As Integer
      
      For Each value As String In values
         Try
            result = Convert.ToInt32(value)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.", _
                              value.GetType().Name, value, result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Int32 type.", value)
         Catch e As FormatException
            Console.WriteLine("The {0} value '{1}' is not in a recognizable format.", _
                              value.GetType().Name, value)
         End Try   
      Next                                 
      ' The example displays the following output:
      '    The String value 'One' is not in a recognizable format.
      '    The String value '1.34e28' is not in a recognizable format.
      '    The String value '-26.87' is not in a recognizable format.
      '    Converted the String value '-18' to the Int32 value -18.
      '    The String value '-6.00' is not in a recognizable format.
      '    Converted the String value ' 0' to the Int32 value 0.
      '    Converted the String value '137' to the Int32 value 137.
      '    The String value '1601.9' is not in a recognizable format.
      '    Converted the String value '2147483647' to the Int32 value 2147483647.
      ' </Snippet11>
   End Sub

   Private Sub ConvertUInt16()
      ' <Snippet12>
      Dim numbers() As UShort = { UInt16.MinValue, 121, 340, UInt16.MaxValue }
      Dim result As Integer
      For Each number As UShort In numbers
         Try
            result = Convert.ToInt32(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt16 value 0 to the Int32 value 0.
      '    Converted the UInt16 value 121 to the Int32 value 121.
      '    Converted the UInt16 value 340 to the Int32 value 340.
      '    Converted the UInt16 value 65535 to the Int32 value 65535.
      ' </Snippet12>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet13>
      Dim numbers() As UInteger = { UInt32.MinValue, 121, 340, UInt32.MaxValue }
      Dim result As Integer
      For Each number As UInteger In numbers
         Try
            result = Convert.ToInt32(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt32 value 0 to the Int32 value 0.
      '    Converted the UInt32 value 121 to the Int32 value 121.
      '    Converted the UInt32 value 340 to the Int32 value 340.
      '    The UInt32 value 4294967295 is outside the range of the Int32 type.
      ' </Snippet13>
   End Sub
   
   Private Sub ConvertUInt64
      ' <Snippet14>
      Dim numbers() As ULong = { UInt64.MinValue, 121, 340, UInt64.MaxValue }
      Dim result As Integer
      For Each number As ULong In numbers
         Try
            result = Convert.ToInt32(number)
            Console.WriteLine("Converted the {0} value {1} to a {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Int32 type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to a Int32 value 0.
      '    Converted the UInt64 value 121 to a Int32 value 121.
      '    Converted the UInt64 value 340 to a Int32 value 340.
      '    The UInt64 value 18446744073709551615 is outside the range of the Int32 type.
      ' </Snippet14>   
   End Sub
End Module
