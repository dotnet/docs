' <Snippet2>
' Example of the explicit conversions from Decimal to Integer and 
' Decimal to UInteger.
Module DecimalToU_Int32Demo

    Const formatter As String = "{0,17}{1,19}{2,19}"

    ' Convert the decimal argument catch exceptions that are thrown.
    Public Sub DecimalToU_Int32(argument As Decimal)
        Dim Int32Value As Object
        Dim UInt32Value As Object

        ' Convert the argument to an int value.
        Try
            Int32Value = CInt(argument)
        Catch ex As Exception 
            Int32Value = ex.GetType().Name
        End Try

        ' Convert the argument to a uint value.
        Try
            UInt32Value = CUInt(argument)
        Catch ex As Exception
            UInt32Value = ex.GetType().Name
        End Try

        Console.WriteLine(formatter, argument, _
            Int32Value, UInt32Value)
    End Sub

    Public Sub Main( )
        Console.WriteLine( formatter, "Decimal Argument", _ 
            "Integer/Exception", "UInteger/Exception" )
        Console.WriteLine( formatter, "----------------", _ 
            "-------------", "--------------" )

        ' Convert decimal values and display the results.
        DecimalToU_Int32( 123d)
        DecimalToU_Int32(New Decimal(123000, 0, 0, False, 3))
        DecimalToU_Int32(123.999d)
        DecimalToU_Int32(4294967295.999d)
        DecimalToU_Int32(4294967296d)
        DecimalToU_Int32(2147483647.999d)
        DecimalToU_Int32(2147483648d)
        DecimalToU_Int32(-0.999d)
        DecimalToU_Int32(-1d)
        DecimalToU_Int32(-2147483648.999d)
        DecimalToU_Int32(-2147483649d)
    End Sub
End Module
' The example displays the following output to the console:
'     Decimal Argument  Integer/Exception UInteger/Exception
'     ----------------      -------------     --------------
'                  123                123                123
'              123.000                123                123
'              123.999                124                124
'       4294967295.999  OverflowException  OverflowException
'           4294967296  OverflowException  OverflowException
'       2147483647.999  OverflowException         2147483648
'           2147483648  OverflowException         2147483648
'               -0.999                 -1  OverflowException
'                   -1                 -1  OverflowException
'      -2147483648.999  OverflowException  OverflowException
'          -2147483649  OverflowException  OverflowException
' </Snippet2>
