' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Module Example6
    Public Sub Main()
        Dim values() As Single = {Single.MinValue, -67890.1234, -12345.6789,
                                 12345.6789, 67890.1234, Single.MaxValue,
                                 Single.NaN, Single.PositiveInfinity,
                                 Single.NegativeInfinity}
        For Each value In values
            Try
                Dim lValue As Long = CLng(value)
                Console.WriteLine("{0} ({1}) --> {2} (0x{2:X16}) ({3})",
                               value, value.GetType().Name,
                               lValue, lValue.GetType().Name)
            Catch e As OverflowException
                Console.WriteLine("Unable to convert {0} to Int64.", value)
            End Try
            Try
                Dim ulValue As UInt64 = CULng(value)
                Console.WriteLine("{0} ({1}) --> {2} (0x{2:X16}) ({3})",
                               value, value.GetType().Name,
                               ulValue, ulValue.GetType().Name)
            Catch e As OverflowException
                Console.WriteLine("Unable to convert {0} to UInt64.", value)
            End Try
            Try
                Dim dValue As Decimal = CDec(value)
                Console.WriteLine("{0} ({1}) --> {2} ({3})",
                               value, value.GetType().Name,
                               dValue, dValue.GetType().Name)
            Catch e As OverflowException
                Console.WriteLine("Unable to convert {0} to Decimal.", value)
            End Try

            Dim dblValue As Double = value
            Console.WriteLine("{0} ({1}) --> {2} ({3})",
                           value, value.GetType().Name,
                           dblValue, dblValue.GetType().Name)
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output for conversions performed
' in a checked context:
'       Unable to convert -3.402823E+38 to Int64.
'       Unable to convert -3.402823E+38 to UInt64.
'       Unable to convert -3.402823E+38 to Decimal.
'       -3.402823E+38 (Single) --> -3.40282346638529E+38 (Double)
'
'       -67890.13 (Single) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
'       Unable to convert -67890.13 to UInt64.
'       -67890.13 (Single) --> -67890.12 (Decimal)
'       -67890.13 (Single) --> -67890.125 (Double)
'
'       -12345.68 (Single) --> -12346 (0xFFFFFFFFFFFFCFC6) (Int64)
'       Unable to convert -12345.68 to UInt64.
'       -12345.68 (Single) --> -12345.68 (Decimal)
'       -12345.68 (Single) --> -12345.6787109375 (Double)
'
'       12345.68 (Single) --> 12346 (0x000000000000303A) (Int64)
'       12345.68 (Single) --> 12346 (0x000000000000303A) (UInt64)
'       12345.68 (Single) --> 12345.68 (Decimal)
'       12345.68 (Single) --> 12345.6787109375 (Double)
'
'       67890.13 (Single) --> 67890 (0x0000000000010932) (Int64)
'       67890.13 (Single) --> 67890 (0x0000000000010932) (UInt64)
'       67890.13 (Single) --> 67890.12 (Decimal)
'       67890.13 (Single) --> 67890.125 (Double)
'
'       Unable to convert 3.402823E+38 to Int64.
'       Unable to convert 3.402823E+38 to UInt64.
'       Unable to convert 3.402823E+38 to Decimal.
'       3.402823E+38 (Single) --> 3.40282346638529E+38 (Double)
'
'       Unable to convert NaN to Int64.
'       Unable to convert NaN to UInt64.
'       Unable to convert NaN to Decimal.
'       NaN (Single) --> NaN (Double)
'
'       Unable to convert Infinity to Int64.
'       Unable to convert Infinity to UInt64.
'       Unable to convert Infinity to Decimal.
'       Infinity (Single) --> Infinity (Double)
'
'       Unable to convert -Infinity to Int64.
'       Unable to convert -Infinity to UInt64.
'       Unable to convert -Infinity to Decimal.
'       -Infinity (Single) --> -Infinity (Double)
' The example displays the following output for conversions performed
' in an unchecked context:
'       -3.402823E+38 (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       -3.402823E+38 (Single) --> 9223372036854775808 (0x8000000000000000) (UInt64)
'       Unable to convert -3.402823E+38 to Decimal.
'       -3.402823E+38 (Single) --> -3.40282346638529E+38 (Double)
'
'       -67890.13 (Single) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
'       -67890.13 (Single) --> 18446744073709483726 (0xFFFFFFFFFFFEF6CE) (UInt64)
'       -67890.13 (Single) --> -67890.12 (Decimal)
'       -67890.13 (Single) --> -67890.125 (Double)
'
'       -12345.68 (Single) --> -12346 (0xFFFFFFFFFFFFCFC6) (Int64)
'       -12345.68 (Single) --> 18446744073709539270 (0xFFFFFFFFFFFFCFC6) (UInt64)
'       -12345.68 (Single) --> -12345.68 (Decimal)
'       -12345.68 (Single) --> -12345.6787109375 (Double)
'
'       12345.68 (Single) --> 12346 (0x000000000000303A) (Int64)
'       12345.68 (Single) --> 12346 (0x000000000000303A) (UInt64)
'       12345.68 (Single) --> 12345.68 (Decimal)
'       12345.68 (Single) --> 12345.6787109375 (Double)
'
'       67890.13 (Single) --> 67890 (0x0000000000010932) (Int64)
'       67890.13 (Single) --> 67890 (0x0000000000010932) (UInt64)
'       67890.13 (Single) --> 67890.12 (Decimal)
'       67890.13 (Single) --> 67890.125 (Double)
'
'       3.402823E+38 (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       3.402823E+38 (Single) --> 0 (0x0000000000000000) (UInt64)
'       Unable to convert 3.402823E+38 to Decimal.
'       3.402823E+38 (Single) --> 3.40282346638529E+38 (Double)
'
'       NaN (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       NaN (Single) --> 0 (0x0000000000000000) (UInt64)
'       Unable to convert NaN to Decimal.
'       NaN (Single) --> NaN (Double)
'
'       Infinity (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       Infinity (Single) --> 0 (0x0000000000000000) (UInt64)
'       Unable to convert Infinity to Decimal.
'       Infinity (Single) --> Infinity (Double)
'
'       -Infinity (Single) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       -Infinity (Single) --> 9223372036854775808 (0x8000000000000000) (UInt64)
'       Unable to convert -Infinity to Decimal.
'       -Infinity (Single) --> -Infinity (Double)
' </Snippet21>
