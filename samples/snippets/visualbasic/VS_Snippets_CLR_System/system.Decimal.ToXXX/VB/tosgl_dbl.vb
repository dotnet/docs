'<Snippet5>
' Example of the Decimal.ToSingle and Decimal.ToDouble methods.
Imports System
Imports Microsoft.VisualBasic

Module DecimalToSgl_DblDemo

    Dim formatter As String = "{0,30}{1,17}{2,23}"

    ' Convert the Decimal argument; no exceptions are thrown.
    Sub DecimalToSgl_Dbl( argument As Decimal )

        Dim SingleValue   As Object
        Dim DoubleValue   As Object

        ' Convert the argument to a Single value.
        SingleValue = Decimal.ToSingle( argument )

        ' Convert the argument to a Double value.
        DoubleValue = Decimal.ToDouble( argument )

        Console.WriteLine( formatter, argument, _
            SingleValue, DoubleValue )
    End Sub

    Sub Main( )

        Console.WriteLine( "This example of the " & vbCrLf & _
            "  Decimal.ToSingle( Decimal ) and " & vbCrLf & _
            "  Decimal.ToDouble( Decimal ) " & vbCrLf & "methods " & _
            "generates the following output. It " & vbCrLf & _
            "displays several converted Decimal values." & vbCrLf )
        Console.WriteLine( formatter, "Decimal argument", _
            "Single", "Double" )
        Console.WriteLine( formatter, "----------------", _
            "------", "------" )

        ' Convert Decimal values and display the results.
        DecimalToSgl_Dbl( 0.0000000000000000000000000001D )
        DecimalToSgl_Dbl( 0.0000000000112233445566778899D )
        DecimalToSgl_Dbl( 123D )
        DecimalToSgl_Dbl( New Decimal( 123000000, 0, 0, False, 6 ) )
        DecimalToSgl_Dbl( 123456789.123456789D )
        DecimalToSgl_Dbl( 123456789123456789123456789D )
        DecimalToSgl_Dbl( Decimal.MinValue )
        DecimalToSgl_Dbl( Decimal.MaxValue )
    End Sub 
End Module 

' This example of the
'   Decimal.ToSingle( Decimal ) and
'   Decimal.ToDouble( Decimal )
' methods generates the following output. It
' displays several converted Decimal values.
' 
'               Decimal argument           Single                 Double
'               ----------------           ------                 ------
' 0.0000000000000000000000000001            1E-28                  1E-28
' 0.0000000000112233445566778899     1.122334E-11   1.12233445566779E-11
'                            123              123                    123
'                     123.000000              123                    123
'            123456789.123456789     1.234568E+08       123456789.123457
'    123456789123456789123456789     1.234568E+26   1.23456789123457E+26
' -79228162514264337593543950335    -7.922816E+28  -7.92281625142643E+28
'  79228162514264337593543950335     7.922816E+28   7.92281625142643E+28
'</Snippet5>