' Visual Basic .NET Document
Option Strict On

Module Example
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
      ConvertInt32()
      Console.WriteLine("-----")
      ConvertInt64()
      Console.WriteLine("-----")
      ConvertObject()
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
      Dim falseFlag As Boolean = False
      Dim trueFlag As Boolean = True
      
      Console.WriteLine("{0} converts to {1}.", falseFlag, _
                        Convert.ToSByte(falseFlag))
      Console.WriteLine("{0} converts to {1}.", trueFlag, _
                        Convert.ToSByte(trueFlag))
      ' The example displays the following output:
      '       False converts to 0.
      '       True converts to 1.
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertByte()
      ' <Snippet2>
      Dim numbers() As Byte = { Byte.MinValue, 10, 100, Byte.MaxValue }
      Dim result As SByte
      For Each number As Byte In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the Byte value 0 to the SByte value 0.
      '    Converted the Byte value 10 to the SByte value 10.
      '    Converted the Byte value 100 to the SByte value 100.
      '    The Byte value 255 is outside the range of the SByte type.
      ' </Snippet2>
   End Sub
   
   Private Sub ConvertChar()
      ' <Snippet3>
      Dim chars() As Char = { "a"c, "z"c, ChrW(7), ChrW(200), ChrW(1023) }
      For Each ch As Char in chars
         Try
            Dim result As SByte = Convert.ToSByte(ch)
            Console.WriteLine("{0} is converted to {1}.", ch, result)
         Catch e As OverflowException
            Console.WriteLine("Unable to convert u+{0} to a byte.", _
                              AscW(ch).ToString("X4"))
         End Try
      Next   
      ' The example displays the following output:
      '    a is converted to 97.
      '    z is converted to 122.
      '     is converted to 7.
      '    Unable to convert u+00C8 to a byte.
      '    Unable to convert u+03FF to a byte.
      ' </Snippet3>
   End Sub
   
   Private Sub ConvertDecimal()
      ' <Snippet4>
      Dim numbers() As Decimal = { Decimal.MinValue, -129.5d, -12.7d, 0d, 16d, _
                                   103.6d, 255.0d, Decimal.MaxValue }
      Dim result As SByte
      
      For Each number As Decimal In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next                         
      ' The example displays the following output:
      '    The Decimal value -79228162514264337593543950335 is outside the range of the SByte type.
      '    The Decimal value -129.5 is outside the range of the SByte type.
      '    Converted the Decimal value -12.7 to the SByte value -13.
      '    Converted the Decimal value 0 to the SByte value 0.
      '    Converted the Decimal value 16 to the SByte value 16.
      '    Converted the Decimal value 103.6 to the SByte value 104.
      '    The Decimal value 255 is outside the range of the SByte type.
      '    The Decimal value 79228162514264337593543950335 is outside the range of the SByte type.
      ' </Snippet4>
   End Sub
   
   Private Sub ConvertDouble()
      ' <Snippet5>
      Dim numbers() As Double = { Double.MinValue, -129.5, -12.7, 0, 16, _
                                  103.6, 255.0, 1.63509e17, Double.MaxValue}
      Dim result As SByte
      
      For Each number As Double In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next                                  
      ' The example displays the following output:
      '    The Double value -1.79769313486232E+308 is outside the range of the SByte type.
      '    The Double value -129.5 is outside the range of the SByte type.
      '    Converted the Double value -12.7 to the SByte value -13.
      '    Converted the Double value 0 to the SByte value 0.
      '    Converted the Double value 16 to the SByte value 16.
      '    Converted the Double value 103.6 to the SByte value 104.
      '    The Double value 255 is outside the range of the SByte type.
      '    The Double value 1.63509E+17 is outside the range of the SByte type.
      '    The Double value 1.79769313486232E+308 is outside the range of the SByte type.
      ' </Snippet5>
   End Sub
   
   Private Sub ConvertInt16()
      ' <Snippet6>
      Dim numbers() As Short = { Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue }
      Dim result As SByte
      For Each number As Short In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    The Int16 value -32768 is outside the range of the SByte type.
      '    Converted the Int16 value -1 to the SByte value -1.
      '    Converted the Int16 value 0 to the SByte value 0.
      '    Converted the Int16 value 121 to the SByte value 121.
      '    The Int16 value 340 is outside the range of the SByte type.
      '    The Int16 value 32767 is outside the range of the SByte type.
      ' </Snippet6>
   End Sub
   
   Private Sub ConvertInt32()
      ' <Snippet7>
      Dim numbers() As Integer = { Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue }
      Dim result As SByte
      For Each number As Integer In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    The Int32 value -2147483648 is outside the range of the SByte type.
      '    Converted the Int32 value -1 to the SByte value -1.
      '    Converted the Int32 value 0 to the SByte value 0.
      '    Converted the Int32 value 121 to the SByte value 121.
      '    The Int32 value 340 is outside the range of the SByte type.
      '    The Int32 value 2147483647 is outside the range of the SByte type.
      ' </Snippet7>
   End Sub
   
   Private Sub ConvertInt64
      ' <Snippet8>
      Dim numbers() As Long = { Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue }
      Dim result As SByte
      For Each number As Long In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    The Int64 value -9223372036854775808 is outside the range of the SByte type.
      '    Converted the Int64 value -1 to the SByte value -1.
      '    Converted the Int64 value 0 to the SByte value 0.
      '    Converted the Int64 value 121 to the SByte value 121.
      '    The Int64 value 340 is outside the range of the SByte type.
      '    The Int64 value 9223372036854775807 is outside the range of the SByte type.
      ' </Snippet8>   
   End Sub   
   
   Private Sub ConvertObject()
      ' <Snippet9>
      Dim values() As Object = { True, -12, 163, 935, "x"c, "104", "103.0", "-1", _
                                 "1.00e2", "One", 1.00e2}
      Dim result As SByte
      For Each value As Object In values
         Try
            result = Convert.ToSByte(value)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              value.GetType().Name, value)
         Catch e As FormatException
            Console.WriteLine("The {0} value {1} is not in a recognizable format.", _
                              value.GetType().Name, value)
         Catch e As InvalidCastException
            Console.WriteLine("No conversion to a Byte exists for the {0} value {1}.", _
                              value.GetType().Name, value)
                              
         End Try
      Next                           
      ' The example displays the following output:
      '    Converted the Boolean value True to the SByte value 1.
      '    Converted the Int32 value -12 to the SByte value -12.
      '    The Int32 value 163 is outside the range of the SByte type.
      '    The Int32 value 935 is outside the range of the SByte type.
      '    Converted the Char value x to the SByte value 120.
      '    Converted the String value 104 to the SByte value 104.
      '    The String value 103.0 is not in a recognizable format.
      '    Converted the String value -1 to the SByte value -1.
      '    The String value 1.00e2 is not in a recognizable format.
      '    The String value One is not in a recognizable format.
      '    Converted the Double value 100 to the SByte value 100.
      ' </Snippet9>
   End Sub
   
   Private Sub ConvertSingle()
      ' <Snippet10>
      Dim numbers() As Single = { Single.MinValue, -129.5, -12.7, 0, 16, _
                                  103.6, 255.0, 1.63509e17, Single.MaxValue}
      Dim result As SByte
      
      For Each number As Single In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next                                  
      ' The example displays the following output:
      '    The Single value -3.402823E+38 is outside the range of the SByte type.
      '    The Single value -129.5 is outside the range of the SByte type.
      '    Converted the Single value -12.7 to the SByte value -13.
      '    Converted the Single value 0 to the SByte value 0.
      '    Converted the Single value 16 to the SByte value 16.
      '    Converted the Single value 103.6 to the SByte value 104.
      '    The Single value 255 is outside the range of the SByte type.
      '    The Single value 1.63509E+17 is outside the range of the SByte type.
      '    The Single value 3.402823E+38 is outside the range of the SByte type.       
      ' </Snippet10>
   End Sub
   
   Private Sub ConvertUInt16()
      ' <Snippet11>
      Dim numbers() As UShort = { UInt16.MinValue, 121, 340, UInt16.MaxValue }
      Dim result As SByte
      For Each number As UShort In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt16 value 0 to the SByte value 0.
      '    Converted the UInt16 value 121 to the SByte value 121.
      '    The UInt16 value 340 is outside the range of the SByte type.
      '    The UInt16 value 65535 is outside the range of the SByte type.
      ' </Snippet11>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet12>
      Dim numbers() As UInteger = { UInt32.MinValue, 121, 340, UInt32.MaxValue }
      Dim result As SByte
      For Each number As UInteger In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt32 value 0 to the SByte value 0.
      '    Converted the UInt32 value 121 to the SByte value 121.
      '    The UInt32 value 340 is outside the range of the SByte type.
      '    The UInt32 value 4294967295 is outside the range of the SByte type.
      ' </Snippet12>
   End Sub
   
   Private Sub ConvertUInt64
      ' <Snippet13>
      Dim numbers() As ULong = { UInt64.MinValue, 121, 340, UInt64.MaxValue }
      Dim result As SByte
      For Each number As ULong In numbers
         Try
            result = Convert.ToSByte(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the SByte type.", _
                              number.GetType().Name, number)
         End Try
      Next
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to the SByte value 0.
      '    Converted the UInt64 value 121 to the SByte value 121.
      '    The UInt64 value 340 is outside the range of the SByte type.
      '    The UInt64 value 18446744073709551615 is outside the range of the SByte type.
      ' </Snippet13>   
   End Sub
End Module
