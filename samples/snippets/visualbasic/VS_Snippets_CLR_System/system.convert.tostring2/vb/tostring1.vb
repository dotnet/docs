' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ConvertDateTime()
      Console.WriteLine("-----")
      ConvertInt16()
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
   
   Private Sub ConvertDateTime()
      ' <Snippet1>
      Dim dates() As Date = { #07/14/2009#, #6:32PM#, #02/12/2009 7:16AM#}
      Dim result As String
      
      For Each dateValue As Date In dates
         result = Convert.ToString(dateValue)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              dateValue.GetType().Name, dateValue, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the DateTime value 7/14/2009 12:00:00 AM to a String value 7/14/2009 12:00:00 AM.
      '    Converted the DateTime value 1/1/0001 06:32:00 PM to a String value 1/1/0001 06:32:00 PM.
      '    Converted the DateTime value 2/12/2009 07:16:00 AM to a String value 2/12/2009 07:16:00 AM.
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertInt16()
      ' <Snippet2>
      Dim numbers() As Short = { Int16.MinValue, -138, 0, 19, Int16.MaxValue }
      Dim result As String
      
      For Each number As Short In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next     
      ' The example displays the following output:
      '    Converted the Int16 value -32768 to the String value -32768.
      '    Converted the Int16 value -138 to the String value -138.
      '    Converted the Int16 value 0 to the String value 0.
      '    Converted the Int16 value 19 to the String value 19.
      '    Converted the Int16 value 32767 to the String value 32767.
      ' </Snippet2>
   End Sub

   Private Sub ConvertObject()
      ' <Snippet3>
      Dim values() As Object = { False, 12.63d, #06/01/2009 6:32:15#, 16.09e-12, _
                                 "Z"c, 15.15322, SByte.MinValue, Int32.MaxValue}
      Dim result As String
      
      For Each value As Object In values
         result = Convert.ToString(value)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              value.GetType().Name, value, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the Boolean value False to the String value False.
      '    Converted the Decimal value 12.63 to the String value 12.63.
      '    Converted the DateTime value 6/1/2009 06:32:15 AM to the String value 6/1/2009 06:32:15 AM.
      '    Converted the Double value 1.609E-11 to the String value 1.609E-11.
      '    Converted the Char value Z to the String value Z.
      '    Converted the Double value 15.15322 to the String value 15.15322.
      '    Converted the SByte value -128 to the String value -128.
      '    Converted the Int32 value 2147483647 to the String value 2147483647.      
      ' </Snippet3>
   End Sub   

   Private Sub ConvertSByte()
      ' <Snippet4>
      Dim numbers() As SByte = { SByte.MinValue, -12, 0, 16, SByte.MaxValue }
      Dim result As String
      
      For Each number As SByte In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the SByte value -128 to the String value -128.
      '    Converted the SByte value -12 to the String value -12.
      '    Converted the SByte value 0 to the String value 0.
      '    Converted the SByte value 16 to the String value 16.
      '    Converted the SByte value 127 to the String value 127.
      ' </Snippet4>
   End Sub
   
   Private Sub ConvertSingle()
      ' <Snippet5>
      Dim numbers() As Single = { Single.MinValue, -1011.351, -17.45, -3e-16, _
                                  0, 4.56e-12, 16.0001, 10345.1221, Single.MaxValue }
      Dim result As String
      
      For Each number As Single In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next                            
      ' The example displays the following output:
      '    Converted the Single value -3.402823E+38 to the String value -3.402823E+38.
      '    Converted the Single value -1011.351 to the String value -1011.351.
      '    Converted the Single value -17.45 to the String value -17.45.
      '    Converted the Single value -3E-16 to the String value -3E-16.
      '    Converted the Single value 0 to the String value 0.
      '    Converted the Single value 4.56E-12 to the String value 4.56E-12.
      '    Converted the Single value 16.0001 to the String value 16.0001.
      '    Converted the Single value 10345.12 to the String value 10345.12.
      '    Converted the Single value 3.402823E+38 to the String value 3.402823E+38.
      ' </Snippet5>
   End Sub
   
   Private Sub ConvertUInt16()
      ' <Snippet6>
      Dim numbers() As UShort = { UInt16.MinValue, 103, 1045, UInt16.MaxValue }
      Dim result As String
      
      For Each number As UShort In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt16 value 0 to the String value 0.
      '    Converted the UInt16 value 103 to the String value 103.
      '    Converted the UInt16 value 1045 to the String value 1045.
      '    Converted the UInt16 value 65535 to the String value 65535.
      ' </Snippet6>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet7>
      Dim numbers() As UInteger = { UInt32.MinValue, 103, 1045, 119543, UInt32.MaxValue }
      Dim result As String
      
      For Each number As UInteger In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt32 value 0 to the String value 0.
      '    Converted the UInt32 value 103 to the String value 103.
      '    Converted the UInt32 value 1045 to the String value 1045.
      '    Converted the UInt32 value 119543 to the String value 119543.
      '    Converted the UInt32 value 4294967295 to the String value 4294967295.
      ' </Snippet7>
   End Sub
   
   Private Sub ConvertUInt64()
      ' <Snippet8>
      Dim numbers() As ULong = { UInt64.MinValue, 1031, 189045, UInt64.MaxValue }
      Dim result As String
      
      For Each number As ULong In numbers
         result = Convert.ToString(number)
         Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", _
                              number.GetType().Name, number, _
                              result.GetType().Name, result)
      Next
      ' The example displays the following output:
      '    Converted the UInt64 value 0 to the String value 0.
      '    Converted the UInt64 value 1031 to the String value 1031.
      '    Converted the UInt64 value 189045 to the String value 189045.
      '    Converted the UInt64 value 18446744073709551615 to the String value 18446744073709551615.
      ' </Snippet8>
   End Sub
End Module

