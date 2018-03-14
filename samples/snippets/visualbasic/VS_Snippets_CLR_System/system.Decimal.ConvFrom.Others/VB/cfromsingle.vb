'<Snippet3>
' Example of the explicit conversion from Single to Decimal.
Imports System
Imports Microsoft.VisualBasic

Module DecimalFromSingleDemo

    Const formatter As String = "{0,16:E7}{1,33}"
 
    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Convert the Single argument; catch exceptions that are thrown.
    Sub DecimalFromSingle( argument As Single )

        Dim decValue    As Object
          
        ' Convert the Single argument to a Decimal value.
        Try
            decValue = Decimal.op_Explicit( argument )
        Catch ex As Exception
            decValue = GetExceptionType( ex )
        End Try

        ' Display the Decimal.
        Console.WriteLine( formatter, argument, decValue )
    End Sub 
       
    Sub Main( )

        Console.WriteLine( _
            "This example of the explicit conversion from Single " & _
            "to Decimal " & vbCrLf & "generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "Single argument", _
            "Decimal value" )
        Console.WriteLine( formatter, "---------------", _
            "-------------" )
          
        ' Convert Single values and display the results.
        DecimalFromSingle( 1.2345E-30 )
        DecimalFromSingle( 1.2345E-26 )
        DecimalFromSingle( 1.23456E-22 )
        DecimalFromSingle( 1.23456E-12 )
        DecimalFromSingle( 1.234567 )
        DecimalFromSingle( 1.234567E+12 )
        DecimalFromSingle( 1.2345678E+28 ) 
        DecimalFromSingle( 1.2345678E+30 )
    End Sub 
End Module

' This example of the explicit conversion from Single to Decimal
' generates the following output.
' 
'  Single argument                    Decimal value
'  ---------------                    -------------
'   1.2345000E-030                                0
'   1.2345000E-026   0.0000000000000000000000000123
'   1.2345600E-022    0.000000000000000000000123456
'   1.2345600E-012              0.00000000000123456
'   1.2345671E+000                         1.234567
'   1.2345670E+012                    1234567000000
'   1.2345678E+028    12345680000000000000000000000
'   1.2345678E+030                OverflowException
'</Snippet3>