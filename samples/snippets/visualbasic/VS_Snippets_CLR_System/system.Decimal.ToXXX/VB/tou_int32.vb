'<Snippet2>
' Example of the Decimal.ToInt32 and Decimal.ToUInt32 methods.
Imports System
Imports Microsoft.VisualBasic

Module DecimalToU_Int32Demo

    Dim formatter As String = "{0,17}{1,19}{2,19}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return  exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Convert the Decimal argument; catch exceptions that are thrown.
    Sub DecimalToU_Int32( argument As Decimal )

        Dim Int32Value    As Object
        Dim UInt32Value   As Object

        ' Convert the argument to an Integer value.
        Try
            Int32Value = Decimal.ToInt32( argument )
        Catch ex As Exception
            Int32Value = GetExceptionType( ex )
        End Try

        ' Convert the argument to a UInt32 value.
        Try
            UInt32Value = Decimal.ToUInt32( argument )
        Catch ex As Exception
            UInt32Value = GetExceptionType( ex )
        End Try

        Console.WriteLine( formatter, argument, _
            Int32Value, UInt32Value )
    End Sub

    Sub Main( )

        Console.WriteLine( "This example of the " & vbCrLf & _
            "  Decimal.ToInt32( Decimal ) and " & vbCrLf & _
            "  Decimal.ToUInt32( Decimal ) " & vbCrLf & "methods " & _
            "generates the following output. It " & vbCrLf & _
            "displays several converted Decimal values." & vbCrLf )
        Console.WriteLine( formatter, "Decimal argument", _
            "Integer/exception", "UInt32/exception" )
        Console.WriteLine( formatter, "----------------", _
            "-----------------", "----------------" )

        ' Convert Decimal values and display the results.
        DecimalToU_Int32( 123D )
        DecimalToU_Int32( New Decimal( 123000, 0, 0, False, 3 ) )
        DecimalToU_Int32( 123.999D )
        DecimalToU_Int32( 4294967295.999D )
        DecimalToU_Int32( 4294967296D )
        DecimalToU_Int32( 2147483647.999D )
        DecimalToU_Int32( 2147483648D )
        DecimalToU_Int32( - 0.999D )
        DecimalToU_Int32( - 1D )
        DecimalToU_Int32( - 2147483648.999D )
        DecimalToU_Int32( - 2147483649D )
    End Sub 
End Module 

' This example of the
'   Decimal.ToInt32( Decimal ) and
'   Decimal.ToUInt32( Decimal )
' methods generates the following output. It
' displays several converted Decimal values.
' 
'  Decimal argument  Integer/exception   UInt32/exception
'  ----------------  -----------------   ----------------
'               123                123                123
'           123.000                123                123
'           123.999                123                123
'    4294967295.999  OverflowException         4294967295
'        4294967296  OverflowException  OverflowException
'    2147483647.999         2147483647         2147483647
'        2147483648  OverflowException         2147483648
'            -0.999                  0                  0
'                -1                 -1  OverflowException
'   -2147483648.999        -2147483648  OverflowException
'       -2147483649  OverflowException  OverflowException
'</Snippet2>