' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Module Example6
    Public Sub Main()
        Dim values() As Double = {Double.MinValue, -67890.1234, -12345.6789,
                                 12345.6789, 67890.1234, Double.MaxValue,
                                 Double.NaN, Double.PositiveInfinity,
                                 Double.NegativeInfinity}
        For Each value In values
            Try
                Dim lValue As Int64 = CLng(value)
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
            Try
                Dim sValue As Single = CSng(value)
                Console.WriteLine("{0} ({1}) --> {2} ({3})",
                               value, value.GetType().Name,
                               sValue, sValue.GetType().Name)
            Catch e As OverflowException
                Console.WriteLine("Unable to convert {0} to Single.", value)
            End Try
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output for conversions performed
' in a checked context:
'       Unable to convert -1.79769313486232E+308 to Int64.
'       Unable to convert -1.79769313486232E+308 to UInt64.
'       Unable to convert -1.79769313486232E+308 to Decimal.
'       -1.79769313486232E+308 (Double) --> -Infinity (Single)
'
'       -67890.1234 (Double) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
'       Unable to convert -67890.1234 to UInt64.
'       -67890.1234 (Double) --> -67890.1234 (Decimal)
'       -67890.1234 (Double) --> -67890.13 (Single)
'
'       -12345.6789 (Double) --> -12346 (0xFFFFFFFFFFFFCFC6) (Int64)
'       Unable to convert -12345.6789 to UInt64.
'       -12345.6789 (Double) --> -12345.6789 (Decimal)
'       -12345.6789 (Double) --> -12345.68 (Single)
'
'       12345.6789 (Double) --> 12346 (0x000000000000303A) (Int64)
'       12345.6789 (Double) --> 12346 (0x000000000000303A) (UInt64)
'       12345.6789 (Double) --> 12345.6789 (Decimal)
'       12345.6789 (Double) --> 12345.68 (Single)
'
'       67890.1234 (Double) --> 67890 (0x0000000000010932) (Int64)
'       67890.1234 (Double) --> 67890 (0x0000000000010932) (UInt64)
'       67890.1234 (Double) --> 67890.1234 (Decimal)
'       67890.1234 (Double) --> 67890.13 (Single)
'
'       Unable to convert 1.79769313486232E+308 to Int64.
'       Unable to convert 1.79769313486232E+308 to UInt64.
'       Unable to convert 1.79769313486232E+308 to Decimal.
'       1.79769313486232E+308 (Double) --> Infinity (Single)
'
'       Unable to convert NaN to Int64.
'       Unable to convert NaN to UInt64.
'       Unable to convert NaN to Decimal.
'       NaN (Double) --> NaN (Single)
'
'       Unable to convert Infinity to Int64.
'       Unable to convert Infinity to UInt64.
'       Unable to convert Infinity to Decimal.
'       Infinity (Double) --> Infinity (Single)
'
'       Unable to convert -Infinity to Int64.
'       Unable to convert -Infinity to UInt64.
'       Unable to convert -Infinity to Decimal.
'       -Infinity (Double) --> -Infinity (Single)
' The example displays the following output for conversions performed
' in an unchecked context:
'       -1.79769313486232E+308 (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       -1.79769313486232E+308 (Double) --> 9223372036854775808 (0x8000000000000000) (UInt64)
'       Unable to convert -1.79769313486232E+308 to Decimal.
'       -1.79769313486232E+308 (Double) --> -Infinity (Single)
'
'       -67890.1234 (Double) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
'       -67890.1234 (Double) --> 18446744073709483726 (0xFFFFFFFFFFFEF6CE) (UInt64)
'       -67890.1234 (Double) --> -67890.1234 (Decimal)
'       -67890.1234 (Double) --> -67890.13 (Single)
'
'       -12345.6789 (Double) --> -12346 (0xFFFFFFFFFFFFCFC6) (Int64)
'       -12345.6789 (Double) --> 18446744073709539270 (0xFFFFFFFFFFFFCFC6) (UInt64)
'       -12345.6789 (Double) --> -12345.6789 (Decimal)
'       -12345.6789 (Double) --> -12345.68 (Single)
'
'       12345.6789 (Double) --> 12346 (0x000000000000303A) (Int64)
'       12345.6789 (Double) --> 12346 (0x000000000000303A) (UInt64)
'       12345.6789 (Double) --> 12345.6789 (Decimal)
'       12345.6789 (Double) --> 12345.68 (Single)
'
'       67890.1234 (Double) --> 67890 (0x0000000000010932) (Int64)
'       67890.1234 (Double) --> 67890 (0x0000000000010932) (UInt64)
'       67890.1234 (Double) --> 67890.1234 (Decimal)
'       67890.1234 (Double) --> 67890.13 (Single)
'
'       1.79769313486232E+308 (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       1.79769313486232E+308 (Double) --> 0 (0x0000000000000000) (UInt64)
'       Unable to convert 1.79769313486232E+308 to Decimal.
'       1.79769313486232E+308 (Double) --> Infinity (Single)
'
'       NaN (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       NaN (Double) --> 0 (0x0000000000000000) (UInt64)
'       Unable to convert NaN to Decimal.
'       NaN (Double) --> NaN (Single)
'
'       Infinity (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       Infinity (Double) --> 0 (0x0000000000000000) (UInt64)
'       Unable to convert Infinity to Decimal.
'       Infinity (Double) --> Infinity (Single)
'
'       -Infinity (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
'       -Infinity (Double) --> 9223372036854775808 (0x8000000000000000) (UInt64)
'       Unable to convert -Infinity to Decimal.
'       -Infinity (Double) --> -Infinity (Single)
' </Snippet21>
