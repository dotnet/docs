'<Snippet4>
' Example of the Decimal.ToSByte and Decimal.ToByte methods.
Imports System
Imports Microsoft.VisualBasic

Module DecimalToS_ByteDemo

    Dim formatter As String = "{0,16}{1,19}{2,19}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return  exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Convert the Decimal argument; catch exceptions that are thrown.
    Sub DecimalToS_Byte( argument As Decimal )

        Dim SByteValue    As Object
        Dim ByteValue   As Object

        ' Convert the argument to an SByte value.
        Try
            SByteValue = Decimal.ToSByte( argument )
        Catch ex As Exception
            SByteValue = GetExceptionType( ex )
        End Try

        ' Convert the argument to a Byte value.
        Try
            ByteValue = Decimal.ToByte( argument )
        Catch ex As Exception
            ByteValue = GetExceptionType( ex )
        End Try

        Console.WriteLine( formatter, argument, _
            SByteValue, ByteValue )
    End Sub

    Sub Main( )

        Console.WriteLine( "This example of the " & vbCrLf & _
            "  Decimal.ToSByte( Decimal ) and " & vbCrLf & _
            "  Decimal.ToByte( Decimal ) " & vbCrLf & "methods " & _
            "generates the following output. It " & vbCrLf & _
            "displays several converted Decimal values." & vbCrLf )
        Console.WriteLine( formatter, "Decimal argument", _
            "SByte/exception", "Byte/exception" )
        Console.WriteLine( formatter, "----------------", _
            "---------------", "--------------" )

        ' Convert Decimal values and display the results.
        DecimalToS_Byte( 78D )
        DecimalToS_Byte( New Decimal( 78000, 0, 0, False, 3 ) )
        DecimalToS_Byte( 78.999D )
        DecimalToS_Byte( 255.999D )
        DecimalToS_Byte( 256D )
        DecimalToS_Byte( 127.999D )
        DecimalToS_Byte( 128D )
        DecimalToS_Byte( - 0.999D )
        DecimalToS_Byte( - 1D )
        DecimalToS_Byte( - 128.999D )
        DecimalToS_Byte( - 129D )
    End Sub 
End Module 

' This example of the
'   Decimal.ToSByte( Decimal ) and
'   Decimal.ToByte( Decimal )
' methods generates the following output. It
' displays several converted Decimal values.
' 
' Decimal argument    SByte/exception     Byte/exception
' ----------------    ---------------     --------------
'               78                 78                 78
'           78.000                 78                 78
'           78.999                 78                 78
'          255.999  OverflowException                255
'              256  OverflowException  OverflowException
'          127.999                127                127
'              128  OverflowException                128
'           -0.999                  0                  0
'               -1                 -1  OverflowException
'         -128.999               -128  OverflowException
'             -129  OverflowException  OverflowException
'</Snippet4>