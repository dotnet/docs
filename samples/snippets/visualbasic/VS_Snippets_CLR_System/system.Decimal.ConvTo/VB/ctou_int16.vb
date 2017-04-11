' <Snippet3>
' Example of the explicit conversions from Decimal to Short and 
' Decimal to UShort.
Module DecimalToU_Int16Demo

    Const formatter As String = "{0,16}{1,19}{2,19}"

    ' Convert the decimal argument and catch exceptions that are thrown.
    Public Sub DecimalToU_Int16(argument As Decimal)
        Dim Int16Value As Object
        Dim UInt16Value As Object

        ' Convert the argument to a Short value.
        Try
            Int16Value = CShort(argument)
        Catch ex As Exception 
            Int16Value = ex.GetType().Name
        End Try

        ' Convert the argument to a UShort value.
        Try
            UInt16Value = CUShort(argument)
        Catch ex As Exception
            UInt16Value = ex.GetType().Name
        End Try

        Console.WriteLine( formatter, argument, _
            Int16Value, UInt16Value )
    End Sub

    Public Sub Main( )
        Console.WriteLine( formatter, "Decimal argument", _ 
            "Short/Exception", "UShort/Exception" )
        Console.WriteLine( formatter, "----------------", _ 
            "---------------", "----------------" )

        ' Convert decimal values and display the results.
        DecimalToU_Int16(123d)
        DecimalToU_Int16(New Decimal( 123000, 0, 0, False, 3 ))
        DecimalToU_Int16(123.999d)
        DecimalToU_Int16(65535.999d)
        DecimalToU_Int16(65536d)
        DecimalToU_Int16(32767.999d)
        DecimalToU_Int16(32768d)
        DecimalToU_Int16(-0.999d)
        DecimalToU_Int16(-1d)
        DecimalToU_Int16(-32768.999d)
        DecimalToU_Int16(-32769d)
    End Sub
End Module
' This example displays the following output to the console:
'    Decimal argument    Short/Exception   UShort/Exception
'    ----------------    ---------------   ----------------
'                 123                123                123
'             123.000                123                123
'             123.999                124                124
'           65535.999  OverflowException  OverflowException
'               65536  OverflowException  OverflowException
'           32767.999  OverflowException              32768
'               32768  OverflowException              32768
'              -0.999                 -1  OverflowException
'                  -1                 -1  OverflowException
'          -32768.999  OverflowException  OverflowException
'              -32769  OverflowException  OverflowException
' </Snippet3>
