'<Snippet3>
' Example of the Decimal.ToInt16 and Decimal.ToUInt16 methods.
Imports System
Imports Microsoft.VisualBasic

Module DecimalToU_Int16Demo

    Dim formatter As String = "{0,16}{1,19}{2,19}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return  exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Convert the Decimal argument; catch exceptions that are thrown.
    Sub DecimalToU_Int16( argument As Decimal )

        Dim Int16Value    As Object
        Dim UInt16Value   As Object

        ' Convert the argument to a Short value.
        Try
            Int16Value = Decimal.ToInt16( argument )
        Catch ex As Exception
            Int16Value = GetExceptionType( ex )
        End Try

        ' Convert the argument to a UInt16 value.
        Try
            UInt16Value = Decimal.ToUInt16( argument )
        Catch ex As Exception
            UInt16Value = GetExceptionType( ex )
        End Try

        Console.WriteLine( formatter, argument, _
            Int16Value, UInt16Value )
    End Sub

    Sub Main( )

        Console.WriteLine( "This example of the " & vbCrLf & _
            "  Decimal.ToInt16( Decimal ) and " & vbCrLf & _
            "  Decimal.ToUInt16( Decimal ) " & vbCrLf & "methods " & _
            "generates the following output. It " & vbCrLf & _
            "displays several converted Decimal values." & vbCrLf )
        Console.WriteLine( formatter, "Decimal argument", _
            "Short/exception", "UInt16/exception" )
        Console.WriteLine( formatter, "----------------", _
            "---------------", "----------------" )

        ' Convert Decimal values and display the results.
        DecimalToU_Int16( 123D )
        DecimalToU_Int16( New Decimal( 123000, 0, 0, False, 3 ) )
        DecimalToU_Int16( 123.999D )
        DecimalToU_Int16( 65535.999D )
        DecimalToU_Int16( 65536D )
        DecimalToU_Int16( 32767.999D )
        DecimalToU_Int16( 32768D )
        DecimalToU_Int16( - 0.999D )
        DecimalToU_Int16( - 1D )
        DecimalToU_Int16( - 32768.999D )
        DecimalToU_Int16( - 32769D )
    End Sub 
End Module 

' This example of the
'   Decimal.ToInt16( Decimal ) and
'   Decimal.ToUInt16( Decimal )
' methods generates the following output. It
' displays several converted Decimal values.
' 
' Decimal argument    Short/exception   UInt16/exception
' ----------------    ---------------   ----------------
'              123                123                123
'          123.000                123                123
'          123.999                123                123
'        65535.999  OverflowException              65535
'            65536  OverflowException  OverflowException
'        32767.999              32767              32767
'            32768  OverflowException              32768
'           -0.999                  0                  0
'               -1                 -1  OverflowException
'       -32768.999             -32768  OverflowException
'           -32769  OverflowException  OverflowException
'</Snippet3>