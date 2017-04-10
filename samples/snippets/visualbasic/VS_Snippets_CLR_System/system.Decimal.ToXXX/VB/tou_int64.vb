'<Snippet1>
' Example of the Decimal.ToInt64 and Decimal.ToUInt64 methods.
Imports System
Imports Microsoft.VisualBasic

Module DecimalToU_Int64Demo

    Dim formatter As String = "{0,25}{1,22}{2,22}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Convert the Decimal argument; catch exceptions that are thrown.
    Sub DecimalToU_Int64( argument As Decimal )

        Dim Int64Value    As Object
        Dim UInt64Value   As Object

        ' Convert the argument to a Long value.
        Try
            Int64Value = Decimal.ToInt64( argument )
        Catch ex As Exception
            Int64Value = GetExceptionType( ex )
        End Try

        ' Convert the argument to a UInt64 value.
        Try
            UInt64Value = Decimal.ToUInt64( argument )
        Catch ex As Exception
            UInt64Value = GetExceptionType( ex )
        End Try

        Console.WriteLine( formatter, argument, _
            Int64Value, UInt64Value )
    End Sub

    Sub Main( )

        Console.WriteLine( "This example of the " & vbCrLf & _
            "  Decimal.ToInt64( Decimal ) and " & vbCrLf & _
            "  Decimal.ToUInt64( Decimal ) " & vbCrLf & "methods " & _
            "generates the following output. It " & vbCrLf & _
            "displays several converted Decimal values." & vbCrLf )
        Console.WriteLine( formatter, "Decimal argument", _
            "Long/exception", "UInt64/exception" )
        Console.WriteLine( formatter, "----------------", _
            "--------------", "----------------" )

        ' Convert Decimal values and display the results.
        DecimalToU_Int64( 123D )
        DecimalToU_Int64( New Decimal( 123000, 0, 0, False, 3 ) )
        DecimalToU_Int64( 123.999D )
        DecimalToU_Int64( 18446744073709551615.999D )
        DecimalToU_Int64( 18446744073709551616D )
        DecimalToU_Int64( 9223372036854775807.999D )
        DecimalToU_Int64( 9223372036854775808D )
        DecimalToU_Int64( - 0.999D )
        DecimalToU_Int64( - 1D )
        DecimalToU_Int64( - 9223372036854775808.999D )
        DecimalToU_Int64( - 9223372036854775809D )
    End Sub 
End Module 

' This example of the
'   Decimal.ToInt64( Decimal ) and
'   Decimal.ToUInt64( Decimal )
' methods generates the following output. It
' displays several converted Decimal values.
' 
'          Decimal argument        Long/exception      UInt64/exception
'          ----------------        --------------      ----------------
'                       123                   123                   123
'                   123.000                   123                   123
'                   123.999                   123                   123
'  18446744073709551615.999     OverflowException  18446744073709551615
'      18446744073709551616     OverflowException     OverflowException
'   9223372036854775807.999   9223372036854775807   9223372036854775807
'       9223372036854775808     OverflowException   9223372036854775808
'                    -0.999                     0                     0
'                        -1                    -1     OverflowException
'  -9223372036854775808.999  -9223372036854775808     OverflowException
'      -9223372036854775809     OverflowException     OverflowException
'</Snippet1>