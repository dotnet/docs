' Visual Basic .NET Document
Option Strict On

Module modMain2
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
        ConvertObject()
        Console.WriteLine("-----")
        ConvertSByte()
        Console.WriteLine("-----")
        ConvertSingle()
        Console.WriteLine("----")
        ConvertString()
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
                        Convert.ToInt64(falseFlag))
        Console.WriteLine("{0} converts to {1}.", trueFlag,
                        Convert.ToInt64(trueFlag))
        ' The example displays the following output:
        '       False converts to 0.
        '       True converts to 1.
        ' </Snippet1>
    End Sub

    Private Sub ConvertByte()
        ' <Snippet2>
        Dim bytes() As Byte = {Byte.MinValue, 14, 122, Byte.MaxValue}
        Dim result As Long

        For Each byteValue As Byte In bytes
            result = Convert.ToInt64(byteValue)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           byteValue.GetType().Name, byteValue,
                           result.GetType().Name, result)
        Next
        ' The example displays the following output:
        '    Converted the Byte value 0 to the Int64 value 0.
        '    Converted the Byte value 14 to the Int64 value 14.
        '    Converted the Byte value 122 to the Int64 value 122.
        '    Converted the Byte value 255 to the Int64 value 255.
        ' </Snippet2>
    End Sub

    Private Sub ConvertChar()
        ' <Snippet3>
        Dim chars() As Char = {"a"c, "z"c, ChrW(7), ChrW(1023),
                              ChrW(Short.MaxValue), ChrW(&HFFFE)}
        Dim result As Long

        For Each ch As Char In chars
            result = Convert.ToInt64(ch)
            Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                           ch.GetType().Name, ch,
                           result.GetType().Name, result)
        Next
        ' The example displays the following output:
        '       Converted the Char value 'a' to the Int64 value 97.
        '       Converted the Char value 'z' to the Int64 value 122.
        '       Converted the Char value '' to the Int64 value 7.
        '       Converted the Char value 'Ͽ' to the Int64 value 1023.
        '       Converted the Char value '翿' to the Int64 value 32767.
        '       Converted the Char value '￾' to the Int64 value 65534.
        ' </Snippet3>
    End Sub

    Private Sub ConvertDecimal()
        ' <Snippet4>
        Dim values() As Decimal = {Decimal.MinValue, -1034.23D, -12D, 0D, 147D,
                                  199.55D, 9214.16D, Decimal.MaxValue}
        Dim result As Long

        For Each value As Decimal In values
            Try
                result = Convert.ToInt64(value)
                Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("{0} is outside the range of the Int64 type.",
                              value)
            End Try
        Next
        ' The example displays the following output:
        '    -79228162514264337593543950335 is outside the range of the Int64 type.
        '    Converted the Decimal value '-1034.23' to the Int64 value -1034.
        '    Converted the Decimal value '-12' to the Int64 value -12.
        '    Converted the Decimal value '0' to the Int64 value 0.
        '    Converted the Decimal value '147' to the Int64 value 147.
        '    Converted the Decimal value '199.55' to the Int64 value 200.
        '    Converted the Decimal value '9214.16' to the Int64 value 9214.
        '    79228162514264337593543950335 is outside the range of the Int64 type.
        ' </Snippet4>
    End Sub

    Private Sub ConvertDouble()
        ' <Snippet5>
        Dim values() As Double = {Double.MinValue, -13800000000.0, -1023.299, -12.98,
                                 0, 0.0000000000000009113, 103.919, 17834.191, Double.MaxValue}
        Dim result As Long

        For Each value As Double In values
            Try
                result = Convert.ToInt64(value)
                Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("{0} is outside the range of the Int64 type.", value)
            End Try
        Next
        '    -1.79769313486232E+308 is outside the range of the Int64 type.
        '    Converted the Double value '-13800000000' to the Int64 value -13800000000.
        '    Converted the Double value '-1023.299' to the Int64 value -1023.
        '    Converted the Double value '-12.98' to the Int64 value -13.
        '    Converted the Double value '0' to the Int64 value 0.
        '    Converted the Double value '9.113E-16' to the Int64 value 0.
        '    Converted the Double value '103.919' to the Int64 value 104.
        '    Converted the Double value '17834.191' to the Int64 value 17834.
        '    1.79769313486232E+308 is outside the range of the Int64 type.
        ' </Snippet5>
    End Sub

    Private Sub ConvertInt16()
        ' <Snippet6>
        Dim numbers() As Short = {Int16.MinValue, -1, 0, 121, 340, Int16.MaxValue}
        Dim result As Long

        For Each number As Short In numbers
            result = Convert.ToInt64(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
        Next
        ' The example displays the following output:
        '    Converted the Int16 value -32768 to the Int64 value -32768.
        '    Converted the Int16 value -1 to the Int64 value -1.
        '    Converted the Int16 value 0 to the Int64 value 0.
        '    Converted the Int16 value 121 to the Int64 value 121.
        '    Converted the Int16 value 340 to the Int64 value 340.
        '    Converted the Int16 value 32767 to the Int64 value 32767.
        ' </Snippet6>
    End Sub

    Private Sub ConvertInt32()
        ' <Snippet7>
        Dim numbers() As Integer = {Int32.MinValue, -1, 0, 121, 340, Int32.MaxValue}
        Dim result As Long
        For Each number As Integer In numbers
            result = Convert.ToInt64(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result)
        Next
        ' The example displays the following output:
        '    Converted the Int32 value -2147483648 to the Int64 value -2147483648.
        '    Converted the Int32 value -1 to the Int64 value -1.
        '    Converted the Int32 value 0 to the Int64 value 0.
        '    Converted the Int32 value 121 to the Int64 value 121.
        '    Converted the Int32 value 340 to the Int64 value 340.
        '    Converted the Int32 value 2147483647 to the Int64 value 2147483647.
        ' </Snippet7>
    End Sub

    Private Sub ConvertObject()
        ' <Snippet8>
        Dim values() As Object = {True, -12, 163, 935, "x"c, #5/12/2009#,
                                 "104", "103.0", "-1",
                                 "1.00e2", "One", 100.0, 1.63E+43}
        Dim result As Long

        For Each value As Object In values
            Try
                result = Convert.ToInt64(value)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Int64 type.",
                              value.GetType().Name, value)
            Catch e As FormatException
                Console.WriteLine("The {0} value {1} is not in a recognizable format.",
                              value.GetType().Name, value)
            Catch e As InvalidCastException
                Console.WriteLine("No conversion to an Int64 exists for the {0} value {1}.",
                              value.GetType().Name, value)

            End Try
        Next
        ' The example displays the following output:
        '    Converted the Boolean value True to the Int64 value 1.
        '    Converted the Int64 value -12 to the Int64 value -12.
        '    Converted the Int64 value 163 to the Int64 value 163.
        '    Converted the Int64 value 935 to the Int64 value 935.
        '    Converted the Char value x to the Int64 value 120.
        '    No conversion to an Int64 exists for the DateTime value 5/12/2009 12:00:00 AM.
        '    Converted the String value 104 to the Int64 value 104.
        '    The String value 103.0 is not in a recognizable format.
        '    Converted the String value -1 to the Int64 value -1.
        '    The String value 1.00e2 is not in a recognizable format.
        '    The String value One is not in a recognizable format.
        '    Converted the Double value 100 to the Int64 value 100.
        '    The Double value 1.63E+43 is outside the range of the Int64 type.
        ' </Snippet8>
    End Sub

    Private Sub ConvertSByte()
        ' <Snippet9>
        Dim numbers() As SByte = {SByte.MinValue, -1, 0, 10, SByte.MaxValue}
        Dim result As Long

        For Each number As SByte In numbers
            result = Convert.ToInt64(number)
            Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result)
        Next
        ' The example displays the following output:
        '       Converted the SByte value -128 to the Int64 value -128.
        '       Converted the SByte value -1 to the Int64 value -1.
        '       Converted the SByte value 0 to the Int64 value 0.
        '       Converted the SByte value 10 to the Int64 value 10.
        '       Converted the SByte value 127 to the Int64 value 127.
        ' </Snippet9>
    End Sub

    Private Sub ConvertSingle()
        ' <Snippet10>
        Dim values() As Single = {Single.MinValue, -13800000000.0, -1023.299, -12.98,
                                 0, 0.0000000000000009113, 103.919, 17834.191, Single.MaxValue}
        Dim result As Long

        For Each value As Single In values
            Try
                result = Convert.ToInt64(value)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("{0} is outside the range of the Int64 type.", value)
            End Try
        Next
        ' The example displays the following output:
        '    -3.4028235E+38 is outside the range of the Int64 type.
        '    Converted the Single value -1.38E+10 to the Int64 value -13799999488.
        '    Converted the Single value -1023.299 to the Int64 value -1023.
        '    Converted the Single value -12.98 to the Int64 value -13.
        '    Converted the Single value 0 to the Int64 value 0.
        '    Converted the Single value 9.113E-16 to the Int64 value 0.
        '    Converted the Single value 103.919 to the Int64 value 104.
        '    Converted the Single value 17834.191 to the Int64 value 17834.
        '    3.4028235E+38 is outside the range of the Int64 type.
        ' </Snippet10>
    End Sub

    Private Sub ConvertString()
        ' <Snippet11>
        Dim values() As String = {"One", "1.34e28", "-26.87", "-18", "-6.00",
                                 " 0", "137", "1601.9", Int32.MaxValue.ToString()}
        Dim result As Long

        For Each value As String In values
            Try
                result = Convert.ToInt64(value)
                Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
                              value.GetType().Name, value, result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("{0} is outside the range of the Int64 type.", value)
            Catch e As FormatException
                Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
                              value.GetType().Name, value)
            End Try
        Next
        ' The example displays the following output:
        '    The String value 'One' is not in a recognizable format.
        '    The String value '1.34e28' is not in a recognizable format.
        '    The String value '-26.87' is not in a recognizable format.
        '    Converted the String value '-18' to the Int64 value -18.
        '    The String value '-6.00' is not in a recognizable format.
        '    Converted the String value ' 0' to the Int64 value 0.
        '    Converted the String value '137' to the Int64 value 137.
        '    The String value '1601.9' is not in a recognizable format.
        '    Converted the String value '2147483647' to the Int64 value 2147483647.
        ' </Snippet11>
    End Sub

    Private Sub ConvertUInt16()
        ' <Snippet12>
        Dim numbers() As UShort = {UInt16.MinValue, 121, 340, UInt16.MaxValue}
        Dim result As Long
        For Each number As UShort In numbers
            Try
                result = Convert.ToInt64(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Int64 type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '    Converted the UInt16 value 0 to the Int64 value 0.
        '    Converted the UInt16 value 121 to the Int64 value 121.
        '    Converted the UInt16 value 340 to the Int64 value 340.
        '    Converted the UInt16 value 65535 to the Int64 value 65535.
        ' </Snippet12>
    End Sub

    Private Sub ConvertUInt32()
        ' <Snippet13>
        Dim numbers() As UInteger = {UInt32.MinValue, 121, 340, UInt32.MaxValue}
        Dim result As Long
        For Each number As UInteger In numbers
            result = Convert.ToInt64(number)
            Console.WriteLine("Converted the {0} value {1:N0} to the {2} value {3:N0}.",
                           number.GetType().Name, number,
                           result.GetType().Name, result)
        Next
        ' The example displays the following output:
        '    Converted the UInt32 value 0 to the Int64 value 0.
        '    Converted the UInt32 value 121 to the Int64 value 121.
        '    Converted the UInt32 value 340 to the Int64 value 340.
        '    Converted the UInt32 value 4,294,967,295 to the Int64 value 4,294,967,295.
        ' </Snippet13>
    End Sub

    Private Sub ConvertUInt64()
        ' <Snippet14>
        Dim numbers() As ULong = {UInt64.MinValue, 121, 340, UInt64.MaxValue}
        Dim result As Long

        For Each number As ULong In numbers
            Try
                result = Convert.ToInt64(number)
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",
                              number.GetType().Name, number,
                              result.GetType().Name, result)
            Catch e As OverflowException
                Console.WriteLine("The {0} value {1} is outside the range of the Int64 type.",
                              number.GetType().Name, number)
            End Try
        Next
        ' The example displays the following output:
        '    Converted the UInt64 value 0 to the Int64 value 0.
        '    Converted the UInt64 value 121 to the Int64 value 121.
        '    Converted the UInt64 value 340 to the Int64 value 340.
        '    The UInt64 value 18446744073709551615 is outside the range of the Int64 type.
        ' </Snippet14>
    End Sub
End Module

