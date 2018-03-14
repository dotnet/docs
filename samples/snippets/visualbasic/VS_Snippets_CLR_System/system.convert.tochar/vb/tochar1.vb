' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      ConvertByte()
      Console.WriteLine("-----")
      ConvertInt16()
      Console.WriteLine("-----")
      ConvertInt32()
      Console.WriteLine("-----")
      ConvertSByte()
      Console.WriteLine("-----")
      ConvertString()
      Console.WriteLine("-----")
      ConvertUInt16()
      Console.WriteLine("-----")
      ConvertUInt32()
      Console.WriteLine("-----")
      ConvertUInt64()
      Console.WriteLine("-----")
      ConvertObject()
   End Sub
   
   Private Sub ConvertByte()
      ' <Snippet1>
      Dim bytes() As Byte = {Byte.MinValue, 40, 80, 120, 180, Byte.MaxValue}
      Dim result As Char
      For Each number As Byte In bytes
         result = Convert.ToChar(number)
         Console.WriteLine("{0} converts to '{1}'.", number, result)
      Next
      ' The example displays the following output:
      '       0 converts to ' '.
      '       40 converts to '('.
      '       80 converts to 'P'.
      '       120 converts to 'x'.
      '       180 converts to '''.
      '       255 converts to 'ÿ'.      
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertInt16()
      ' <Snippet2>
      Dim numbers() As Short = { Int16.MinValue, 0, 40, 160, 255, 1028, _
                                 2011, Int16.MaxValue }
      Dim result As Char
      For Each number As Short In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next   
      ' The example displays the following output:
      '       -32768 is outside the range of the Char data type.
      '       0 converts to ' '.
      '       40 converts to '('.
      '       160 converts to ' '.
      '       255 converts to 'ÿ'.
      '       1028 converts to '?'.
      '       2011 converts to '?'.
      '       32767 converts to '?'.      
      ' </Snippet2>
   End Sub
   
   Private Sub ConvertInt32()
      ' <Snippet3>
      Dim numbers() As Integer = { -1, 0, 40, 160, 255, 1028, _
                                 2011, 30001, 207154, Int32.MaxValue }
      Dim result As Char
      For Each number As Integer In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next   
   End Sub
   '       -1 is outside the range of the Char data type.
   '       0 converts to ' '.
   '       40 converts to '('.
   '       160 converts to ' '.
   '       255 converts to 'ÿ'.
   '       1028 converts to '?'.
   '       2011 converts to '?'.
   '       30001 converts to '?'.
   '       207154 is outside the range of the Char data type.
   '       2147483647 is outside the range of the Char data type.   
   ' </Snippet3>

   Private Sub ConvertSByte()
      ' <Snippet4>
      Dim numbers() As SByte = { SByte.MinValue, -1, 40, 80, 120, SByte.MaxValue }
      Dim result As Char
      For Each number As SByte In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next
      ' The example displays the following output:
      '       -128 is outside the range of the Char data type.
      '       -1 is outside the range of the Char data type.
      '       40 converts to '('.
      '       80 converts to 'P'.
      '       120 converts to 'x'.
      '       127 converts to '⌂'.
      ' </Snippet4>
   End Sub
   
   Private Sub ConvertString()
      ' <Snippet5>
      Dim nullString As String = Nothing
      Dim strings() As String = { "A", "This", vbTab, nullString }
      Dim result As Char
      For Each strng As String In strings
         Try
            result = Convert.ToChar(strng)
            Console.WriteLine("'{0}' converts to '{1}'.", strng, result)
         Catch e As FormatException
            Console.WriteLine("'{0}' is not in the correct format for conversion to a Char.", _
                              strng)
         Catch e As ArgumentNullException
            Console.WriteLine("A null string cannot be converted to a Char.")
         End Try
      Next
      ' The example displays the following output:
      '       'A' converts to 'A'.
      '       'This' is not in the correct format for conversion to a Char.
      '       '       ' converts to ' '.
      '       A null string cannot be converted to a Char.
      ' </Snippet5>
   End Sub
   
   Private Sub ConvertUInt16()
      ' <Snippet6>
      Dim numbers() As UShort = { UInt16.MinValue, 40, 160, 255, 1028, _
                                  2011, UInt16.MaxValue }
      Dim result As Char
      For Each number As UShort In numbers
         result = Convert.ToChar(number)
         Console.WriteLine("{0} converts to '{1}'.", number, result)
      Next   
      ' The example displays the following output:
      '       0 converts to ' '.
      '       40 converts to '('.
      '       160 converts to ' '.
      '       255 converts to 'ÿ'.
      '       1028 converts to '?'.
      '       2011 converts to '?'.
      '       65535 converts to '?'.
      ' </Snippet6>
   End Sub
   
   Private Sub ConvertUInt32()
      ' <Snippet7>
      Dim numbers() As UInteger = { UInt32.MinValue, 40, 160, 255, 1028, _
                                    2011, 30001, 207154, Int32.MaxValue }
      Dim result As Char
      For Each number As UInteger In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next   
      ' The example displays the following output:
      '       0 converts to ' '.
      '       40 converts to '('.
      '       160 converts to ' '.
      '       255 converts to 'ÿ'.
      '       1028 converts to '?'.
      '       2011 converts to '?'.
      '       30001 converts to '?'.
      '       207154 is outside the range of the Char data type.
      '       2147483647 is outside the range of the Char data type.
      ' </Snippet7>
   End Sub

   Private Sub ConvertUInt64()
      ' <Snippet8>
      Dim numbers() As ULong = { UInt64.MinValue, 40, 160, 255, 1028, _
                                    2011, 30001, 207154, Int64.MaxValue }
      Dim result As Char
      For Each number As ULong In numbers
         Try
            result = Convert.ToChar(number)
            Console.WriteLine("{0} converts to '{1}'.", number, result)
         Catch e As OverflowException
            Console.WriteLine("{0} is outside the range of the Char data type.", _
                              number)
         End Try
      Next   
      ' The example displays the following output:
      '       0 converts to ' '.
      '       40 converts to '('.
      '       160 converts to ' '.
      '       255 converts to 'ÿ'.
      '       1028 converts to '?'.
      '       2011 converts to '?'.
      '       30001 converts to '?'.
      '       207154 is outside the range of the Char data type.
      '       9223372036854775807 is outside the range of the Char data type.
      ' </Snippet8>
   End Sub   

   Private Sub ConvertObject()
      ' <Snippet9>
      Dim values() As Object = { "r"c, "s", "word", CByte(83), 77, 109324, _
                                 335812911, #3/10/2009#, CUInt(1934), _ 
                                 CSByte(-17), 169.34, 175.6d, Nothing }
      Dim result As Char
      
      For Each value As Object In values
         Try
            result = Convert.ToChar(value)
            Console.WriteLine("The {0} value {1} converts to {2}.", _ 
                              value.GetType().Name, value, result)
         Catch e As FormatException
            Console.WriteLine(e.Message)
         Catch e As InvalidCastException
            Console.WriteLine("Conversion of the {0} value {1} to a Char is not supported.", _
                              value.GetType().Name, value)
         Catch e As OverflowException
            Console.WriteLine("The {0} value {1} is outside the range of the Char data type.", _
                              value.GetType().Name, value)
         Catch e As NullReferenceException
            Console.WriteLine("Cannot convert a null reference to a Char.")
         End Try
      Next
      ' The example displays the following output:
      '       The Char value r converts to r.
      '       The String value s converts to s.
      '       String must be exactly one character long.
      '       The Byte value 83 converts to S.
      '       The Int32 value 77 converts to M.
      '       The Int32 value 109324 is outside the range of the Char data type.
      '       The Int32 value 335812911 is outside the range of the Char data type.
      '       Conversion of the DateTime value 3/10/2009 12:00:00 AM to a Char is not supported.
      '       The UInt32 value 1934 converts to ?.
      '       The SByte value -17 is outside the range of the Char data type.
      '       Conversion of the Double value 169.34 to a Char is not supported.
      '       Conversion of the Decimal value 175.6 to a Char is not supported.
      '       Cannot convert a null reference to a Char.      
      ' </Snippet9>
   End Sub
End Module

