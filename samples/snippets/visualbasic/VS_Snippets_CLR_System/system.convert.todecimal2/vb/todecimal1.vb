' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ConvertBoolean()
      Console.WriteLine("-----")
      ConvertInt16()
      Console.WriteLine("-----")
      ConvertInt32()
      Console.WriteLine("-----")
      ConvertObject()
      Console.WriteLine("-----")
      ConvertSByte()
      Console.WriteLine("-----")
      ConvertSingle()
      Console.WriteLine("-----")
      ConvertUInt16()
      Console.WriteLine("-----")
      ConvertUInt32()
      Console.WriteLine("-----")
      ConvertUInt64()
   End Sub
   
   Private Sub ConvertBoolean()
      ' <Snippet1>
      Dim flags() As Boolean = { True, False }
      Dim result As Decimal
      
      For Each flag As Boolean In flags
         result = Convert.ToDecimal(flag)
         Console.WriteLine("Converted {0} to {1}.", flag, result)
      Next
      ' The example displays the following output:
      '       Converted True to 1.
      '       Converted False to 0.      
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertInt16
      ' <Snippet2>
      Dim numbers() As Short = { Int16.MinValue, -1000, 0, 1000, Int16.MaxValue }
      Dim result As Decimal
      
      For Each number As Short In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the Int16 value {0} to the Decimal value {1}.", _
                           number, result)
      Next
      ' The example displays the following output:
      '       Converted the Int16 value -32768 to the Decimal value -32768.
      '       Converted the Int16 value -1000 to the Decimal value -1000.
      '       Converted the Int16 value 0 to the Decimal value 0.
      '       Converted the Int16 value 1000 to the Decimal value 1000.
      '       Converted the Int16 value 32767 to the Decimal value 32767.
      ' </Snippet2>
   End Sub   

   Private Sub ConvertInt32
      ' <Snippet3>
      Dim numbers() As Integer = { Int32.MinValue, -1000, 0, 1000, Int32.MaxValue }
      Dim result As Decimal
      
      For Each number As Integer In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the Int32 value {0} to the Decimal value {1}.", _
                           number, result)
      Next
      ' The example displays the following output:
      '    Converted the Int32 value -2147483648 to the Decimal value -2147483648.
      '    Converted the Int32 value -1000 to the Decimal value -1000.
      '    Converted the Int32 value 0 to the Decimal value 0.
      '    Converted the Int32 value 1000 to the Decimal value 1000.
      '    Converted the Int32 value 2147483647 to the Decimal value 2147483647.      
      ' </Snippet3>
   End Sub   

   Private Sub ConvertObject()
      ' <Snippet4>
      Dim values() As Object = { True, "a"c, 123, 1.764e32, "9.78", "1e-02", _
                                 1.67e03, "A100", "1,033.67", Date.Now, _
                                 Double.MaxValue }   
      Dim result As Decimal
      
      For Each value As Object In values
         Try
            result = Convert.ToDecimal(value)
            Console.WriteLine("Converted the {0} value {1} to {2}.", _
                              value.GetType().Name, value, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is out of range of the Decimal type.", _
                              value.GetType().Name, value)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not recognized as a valid Decimal value.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Decimal is not supported.", _
                              value.GetType().Name, value)
         End Try                     
      Next
      ' The example displays the following output:
      '    Converted the Boolean value True to 1.
      '    Conversion of the Char value a to a Decimal is not supported.
      '    Converted the Int32 value 123 to 123.
      '    The Double value 1.764E+32 is out of range of the Decimal type.
      '    Converted the String value 9.78 to 9.78.
      '    The String value 1e-02 is not recognized as a valid Decimal value.
      '    Converted the Double value 1670 to 1670.
      '    The String value A100 is not recognized as a valid Decimal value.
      '    Converted the String value 1,033.67 to 1033.67.
      '    Conversion of the DateTime value 10/15/2008 05:40:42 PM to a Decimal is not supported.
      '    The Double value 1.79769313486232E+308 is out of range of the Decimal type.      
      ' </Snippet4>
   End Sub

   Private Sub ConvertSByte()
      ' <Snippet5>
      Dim numbers() As SByte = { SByte.MinValue, -23, 0, 17, SByte.MaxValue }
      Dim result As Decimal
      
      For Each number As SByte In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the SByte value {0} to {1}.", number, result)
      Next
      '       Converted the SByte value -128 to -128.
      '       Converted the SByte value -23 to -23.
      '       Converted the SByte value 0 to 0.
      '       Converted the SByte value 17 to 17.
      '       Converted the SByte value 127 to 127.
      ' </Snippet5>
   End Sub
   
   Private Sub ConvertSingle()
      ' <Snippet6>
      Dim numbers() As Single = { Single.MinValue, -3e10, -1093.54, 0, 1e-03, _
                                  1034.23, Single.MaxValue }
      Dim result As Decimal
      
      For Each number As Single In numbers
         Try
            result = Convert.ToDecimal(number)
            Console.WriteLine("Converted the Single value {0} to {1}.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is out of range of the Decimal type.", number)
         End Try
      Next                                  
      ' The example displays the following output:
      '       -3.402823E+38 is out of range of the Decimal type.
      '       Converted the Single value -3E+10 to -30000000000.
      '       Converted the Single value -1093.54 to -1093.54.
      '       Converted the Single value 0 to 0.
      '       Converted the Single value 0.001 to 0.001.
      '       Converted the Single value 1034.23 to 1034.23.
      '       3.402823E+38 is out of range of the Decimal type.
      ' </Snippet6>
   End Sub
   
   Private Sub ConvertUInt16()
      ' <Snippet7>
      Dim numbers() As UShort = { UInt16.MinValue, 121, 12345, UInt16.MaxValue }
      Dim result As Decimal
      
      For Each number As UShort In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the UInt16 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '       Converted the UInt16 value 0 to 0.
      '       Converted the UInt16 value 121 to 121.
      '       Converted the UInt16 value 12345 to 12345.
      '       Converted the UInt16 value 65535 to 65535.      
      ' </Snippet7>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet8>
      Dim numbers() As UInteger = { UInt32.MinValue, 121, 12345, UInt32.MaxValue }
      Dim result As Decimal
      
      For Each number As UInteger In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the UInt32 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '       Converted the UInt32 value 0 to 0.
      '       Converted the UInt32 value 121 to 121.
      '       Converted the UInt32 value 12345 to 12345.
      '       Converted the UInt32 value 4294967295 to 4294967295.
      ' </Snippet8>
   End Sub

   Private Sub ConvertUInt64()
      ' <Snippet9>
      Dim numbers() As ULong = { UInt64.MinValue, 121, 12345, UInt64.MaxValue }
      Dim result As Decimal
      
      For Each number As ULong In numbers
         result = Convert.ToDecimal(number)
         Console.WriteLine("Converted the UInt64 value {0} to {1}.", _
                           number, result)
      Next   
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to 0.
      '    Converted the UInt64 value 121 to 121.
      '    Converted the UInt64 value 12345 to 12345.
      '    Converted the UInt64 value 18446744073709551615 to 18446744073709551615.
      ' </Snippet9>
   End Sub
End Module

