' Visual Basic .NET Document
'Option Strict On

' <Snippet20>
Module Example5
    Public Sub Main()
        Dim values() As Object = {Byte.MinValue, Byte.MaxValue, Decimal.MinValue,
                                 Decimal.MaxValue, Double.MinValue, Double.MaxValue,
                                 Int16.MinValue, Int16.MaxValue, Int32.MinValue,
                                 Int32.MaxValue, Int64.MinValue, Int64.MaxValue,
                                 SByte.MinValue, SByte.MaxValue, UInt16.MinValue,
                                 UInt16.MaxValue, UInt32.MinValue, UInt32.MaxValue,
                                 UInt64.MinValue, UInt64.MaxValue}
        Dim sngValue As Single
        For Each value In values
            If value.GetType() = GetType(Double) Then
                sngValue = CSng(value)
            Else
                sngValue = value
            End If
            Console.WriteLine("{0} ({1}) --> {2:R} ({3})",
                           value, value.GetType().Name,
                           sngValue, sngValue.GetType().Name)
        Next
    End Sub
End Module
' The example displays the following output:
'       0 (Byte) --> 0 (Single)
'       255 (Byte) --> 255 (Single)
'       -79228162514264337593543950335 (Decimal) --> -7.92281625E+28 (Single)
'       79228162514264337593543950335 (Decimal) --> 7.92281625E+28 (Single)
'       -1.79769313486232E+308 (Double) --> -Infinity (Single)
'       1.79769313486232E+308 (Double) --> Infinity (Single)
'       -32768 (Int16) --> -32768 (Single)
'       32767 (Int16) --> 32767 (Single)
'       -2147483648 (Int32) --> -2.14748365E+09 (Single)
'       2147483647 (Int32) --> 2.14748365E+09 (Single)
'       -9223372036854775808 (Int64) --> -9.223372E+18 (Single)
'       9223372036854775807 (Int64) --> 9.223372E+18 (Single)
'       -128 (SByte) --> -128 (Single)
'       127 (SByte) --> 127 (Single)
'       0 (UInt16) --> 0 (Single)
'       65535 (UInt16) --> 65535 (Single)
'       0 (UInt32) --> 0 (Single)
'       4294967295 (UInt32) --> 4.2949673E+09 (Single)
'       0 (UInt64) --> 0 (Single)
'       18446744073709551615 (UInt64) --> 1.84467441E+19 (Single)
' </Snippet20>

