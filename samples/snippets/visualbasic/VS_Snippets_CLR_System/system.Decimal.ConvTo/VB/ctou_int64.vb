' <Snippet1>
' Example of the explicit conversions from Decimal to Long and 
' Decimal to ULong.
Module DecimalToU_Int64Demo

    Const formatter As String = "{0,25}{1,22}{2,22}"

    ' Convert the decimal argument catch exceptions that are thrown.
    Public Sub DecimalToU_Int64(argument As Decimal)
        Dim Int64Value As Object
        Dim UInt64Value As Object

        ' Convert the argument to a long value.
        Try
            Int64Value = CLng(argument)
        Catch ex As Exception
            Int64Value = ex.GetType().Name
        End Try

        ' Convert the argument to a ulong value.
        Try
            UInt64Value = CULng(argument)
        Catch ex As Exception
            UInt64Value = ex.GetType().Name
        End Try

        Console.WriteLine(formatter, argument, _ 
            Int64Value, UInt64Value)
    End Sub

    Public Sub Main( )
        Console.WriteLine( formatter, "Decimal argument", _
            "Long/Exception", "ULong/Exception" )
        Console.WriteLine( formatter, "----------------", _
            "--------------", "---------------" )

        ' Convert decimal values and display the results.
        DecimalToU_Int64(123d)
        DecimalToU_Int64(New Decimal(123000, 0, 0, False, 3))
        DecimalToU_Int64(123.999d)
        DecimalToU_Int64(18446744073709551615.999d)
        DecimalToU_Int64(18446744073709551616d)
        DecimalToU_Int64(9223372036854775807.999d)
        DecimalToU_Int64(9223372036854775808d)
        DecimalToU_Int64(-0.999d)
        DecimalToU_Int64(-1d)
        DecimalToU_Int64(-9223372036854775808.999d)
        DecimalToU_Int64(-9223372036854775809d)
    End Sub
End Module
' The example displays the following output to the console:
'             Decimal argument        Long/Exception       ULong/Exception
'             ----------------        --------------       ---------------
'                          123                   123                   123
'                      123.000                   123                   123
'                      123.999                   124                   124
'     18446744073709551615.999     OverflowException     OverflowException
'         18446744073709551616     OverflowException     OverflowException
'      9223372036854775807.999     OverflowException   9223372036854775808
'          9223372036854775808     OverflowException   9223372036854775808
'                       -0.999                    -1     OverflowException
'                           -1                    -1     OverflowException
'     -9223372036854775808.999     OverflowException     OverflowException
'         -9223372036854775809     OverflowException     OverflowException
'</Snippet1>
