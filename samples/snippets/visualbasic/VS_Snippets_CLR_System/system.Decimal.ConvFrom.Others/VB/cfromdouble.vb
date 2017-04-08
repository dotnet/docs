'<Snippet2>
' Example of the explicit conversion from Double to Decimal.
Imports System
Imports Microsoft.VisualBasic

Module DecimalFromDoubleDemo

    Const formatter As String = "{0,25:E16}{1,33}"
 
    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Convert the Double argument; catch exceptions that are thrown.
    Sub DecimalFromDouble( argument As Double )

        Dim decValue    As Object
          
        ' Convert the Double argument to a Decimal value.
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
            "This example of the explicit conversion from Double " & _
            "to Decimal " & vbCrLf & "generates the following " & _
            "output." & vbCrLf )
        Console.WriteLine( formatter, "Double argument", _
            "Decimal value" )
        Console.WriteLine( formatter, "---------------", _
            "-------------" )
          
        ' Convert Double values and display the results.
        DecimalFromDouble( 1.234567890123E-30 )
        DecimalFromDouble( 1.2345678901234E-25 )
        DecimalFromDouble( 1.23456789012345E-20 )
        DecimalFromDouble( 1.234567890123456E-10 )
        DecimalFromDouble( 1.2345678901234567 )
        DecimalFromDouble( 1.23456789012345678E+12 )
        DecimalFromDouble( 1.234567890123456789E+28 ) 
        DecimalFromDouble( 1.234567890123456789E+30 )
    End Sub 
End Module

' This example of the explicit conversion from Double to Decimal
' generates the following output.
'
'           Double argument                    Decimal value
'           ---------------                    -------------
'   1.2345678901230000E-030                                0
'   1.2345678901233999E-025   0.0000000000000000000000001235
'   1.2345678901234499E-020   0.0000000000000000000123456789
'   1.2345678901234560E-010       0.000000000123456789012346
'   1.2345678901234567E+000                 1.23456789012346
'   1.2345678901234568E+012                 1234567890123.46
'   1.2345678901234568E+028    12345678901234600000000000000
'   1.2345678901234569E+030                OverflowException
'</Snippet2>