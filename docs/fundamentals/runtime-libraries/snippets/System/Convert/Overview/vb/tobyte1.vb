' Visual Basic .NET Document
Option Strict On

Module Example3
    Public Sub Main()
        ConvertBoolean()
        Console.WriteLine("-----")
        ConvertChar()
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

        Console.WriteLine("{0} converts to {1}.", falseFlag,
                        Convert.ToByte(falseFlag))
        Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToByte(trueFlag))
        ' The example displays the following output:
        '       False converts to 0.
        '       True converts to 1.
        ' </Snippet1>
    End Sub

    Private Sub ConvertChar()
        ' <Snippet2>
        Dim chars() As Char = {"a"c, "z"c, ChrW(7), ChrW(1023)}
        For Each ch As Char In chars
            Try
                Dim result As Byte = Convert.ToByte(ch)
                Console.WriteLine("{0} is converted to {1}.", ch, result)
            Catch e As OverflowException
                Console.WriteLine("Unable to convert u+{0} to a byte.",
                              AscW(ch).ToString("X4"))
            End Try
        Next
        ' The example displays the following output:
        '       a is converted to 97.
        '       z is converted to 122.
        '        is converted to 7.
        '       Unable to convert u+03FF to a byte.      
        ' </Snippet2>
    End Sub

    Private Sub ConvertInt16()
        ' <Snippet3>
        Dim numbers() As Short = {Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue}
        Dim result As Byte
        For Each number As Short In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       The Int16 value -32768 is outside the range of the Byte type.
        '       The Int16 value -1 is outside the range of the Byte type.
        '       Converted the Int16 value 0 to the Byte value 0.
        '       Converted the Int16 value 121 to the Byte value 121.
        '       The Int16 value 340 is outside the range of the Byte type.
        '       The Int16 value 32767 is outside the range of the Byte type.
        ' </Snippet3>
    End Sub

    Private Sub ConvertInt32()
        ' <Snippet4>
        Dim numbers() As Integer = {Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue}
        Dim result As Byte
        For Each number As Integer In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       The Int32 value -2147483648 is outside the range of the Byte type.
        '       The Int32 value -1 is outside the range of the Byte type.
        '       Converted the Int32 value 0 to the Byte value 0.
        '       Converted the Int32 value 121 to the Byte value 121.
        '       The Int32 value 340 is outside the range of the Byte type.
        '       The Int32 value 2147483647 is outside the range of the Byte type.      
        ' </Snippet4>
    End Sub

    Private Sub ConvertInt64()
        ' <Snippet5>
        Dim numbers() As Long = {Int64.MinValue, -1, 0, 121, 340, Int64.MaxValue}
        Dim result As Byte
        For Each number As Long In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       The Int64 value -9223372036854775808 is outside the range of the Byte type.
        '       The Int64 value -1 is outside the range of the Byte type.
        '       Converted the Int64 value 0 to the Byte value 0.
        '       Converted the Int64 value 121 to the Byte value 121.
        '       The Int64 value 340 is outside the range of the Byte type.
        '       The Int64 value 9223372036854775807 is outside the range of the Byte type.      
        ' </Snippet5>   
    End Sub

    Private Sub ConvertObject()
        ' <Snippet6>
        Dim values() As Object = {True, -12, 163, 935, "x"c, "104", "103.0", "-1",
                                 "1.00e2", "One", 100.0}
        Dim result As Byte
        For Each value As Object In values
            Try
                result = Convert.ToByte(value)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              value.GetType().Name, value)
            Catch e As FormatException
                Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value)
            Catch e As InvalidCastException
                Console.WriteLine("No conversion to a Byte exists for the {0} value {1}.",
                              value.GetType().Name, value)

            End Try
        Next
        ' The example displays the following output:
        '       Converted the Boolean value True to the Byte value 1.
        '       The Int32 value -12 is outside the range of the Byte type.
        '       Converted the Int32 value 163 to the Byte value 163.
        '       The Int32 value 935 is outside the range of the Byte type.
        '       Converted the Char value x to the Byte value 120.
        '       Converted the String value 104 to the Byte value 104.
        '       The String value 103.0 is not in a recognizable format.
        '       The String value -1 is outside the range of the Byte type.
        '       The String value 1.00e2 is not in a recognizable format.
        '       The String value One is not in a recognizable format.
        '       Converted the Double value 100 to the Byte value 100.      
        ' </Snippet6>
    End Sub

    Private Sub ConvertSByte()
        ' <Snippet7>
        Dim numbers() As SByte = {SByte.MinValue, -1, 0, 10, SByte.MaxValue}
        Dim result As Byte
        For Each number As SByte In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       The SByte value -128 is outside the range of the Byte type.
        '       The SByte value -1 is outside the range of the Byte type.
        '       Converted the SByte value 0 to the Byte value 0.
        '       Converted the SByte value 10 to the Byte value 10.
        '       Converted the SByte value 127 to the Byte value 127.
        ' </Snippet7>
    End Sub

    Private Sub ConvertUInt16()
        ' <Snippet8>
        Dim numbers() As UShort = {UInt16.MinValue, 121, 340, UInt16.MaxValue}
        Dim result As Byte
        For Each number As UShort In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       Converted the UInt16 value 0 to the Byte value 0.
        '       Converted the UInt16 value 121 to the Byte value 121.
        '       The UInt16 value 340 is outside the range of the Byte type.
        '       The UInt16 value 65535 is outside the range of the Byte type.
        ' </Snippet8>
    End Sub

    Private Sub ConvertUInt32()
        ' <Snippet9>
        Dim numbers() As UInteger = {UInt32.MinValue, 121, 340, UInt32.MaxValue}
        Dim result As Byte
        For Each number As UInteger In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       Converted the UInt32 value 0 to the Byte value 0.
        '       Converted the UInt32 value 121 to the Byte value 121.
        '       The UInt32 value 340 is outside the range of the Byte type.
        '       The UInt32 value 4294967295 is outside the range of the Byte type.
        ' </Snippet9>
    End Sub

    Private Sub ConvertUInt64()
        ' <Snippet10>
        Dim numbers() As ULong = {UInt64.MinValue, 121, 340, UInt64.MaxValue}
        Dim result As Byte
        For Each number As ULong In numbers
            Try
                result = Convert.ToByte(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Byte type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '       Converted the UInt64 value 0 to the Byte value 0.
        '       Converted the UInt64 value 121 to the Byte value 121.
        '       The UInt64 value 340 is outside the range of the Byte type.
        '       The UInt64 value 18446744073709551615 is outside the range of the Byte type.
        ' </Snippet10>   
    End Sub
End Module
