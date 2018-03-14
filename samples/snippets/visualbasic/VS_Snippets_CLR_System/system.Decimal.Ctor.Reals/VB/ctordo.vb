'<Snippet2>
' Example of the Decimal( Double ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorDoDemo

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( value As Double, valToStr As String )

        ' Format and display the constructor.
        Console.Write( "{0,-34}", _
            String.Format( "Decimal( {0} )", valToStr ) )

        ' Construct the Decimal value.
        Try
            Dim decimalNum As New Decimal( value )

            ' Display the value if it was created successfully.
            Console.WriteLine( "{0,31}", decimalNum )

        ' Display the exception type if an exception was thrown.
        Catch ex As Exception
            Console.WriteLine( "{0,31}", GetExceptionType( ex ) )
        End Try
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the Decimal( Double ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-34}{1,31}", "Constructor", _
            "Value or Exception" )
        Console.WriteLine( "{0,-34}{1,31}", "-----------", _
            "------------------" )

        ' Construct Decimal objects from Double values.
        CreateDecimal( 1.23456789E+5, "1.23456789E+5" )                
        CreateDecimal( 1.234567890123E+15, "1.234567890123E+15" )                
        CreateDecimal( 1.2345678901234567E+25, _
            "1.2345678901234567E+25" )
        CreateDecimal( 1.2345678901234567E+35, _
            "1.2345678901234567E+35" )
        CreateDecimal( 1.23456789E-5, "1.23456789E-5" )                
        CreateDecimal( 1.234567890123E-15, "1.234567890123E-15" )      
        CreateDecimal( 1.2345678901234567E-25, _
            "1.2345678901234567E-25" ) 
        CreateDecimal( 1.2345678901234567E-35, _
            "1.2345678901234567E-35" ) 
        CreateDecimal( 1.0 / 7.0, "1.0 / 7.0" ) 
    End Sub 
End Module 

' This example of the Decimal( Double ) constructor
' generates the following output.
' 
' Constructor                                    Value or Exception
' -----------                                    ------------------
' Decimal( 1.23456789E+5 )                               123456.789
' Decimal( 1.234567890123E+15 )                    1234567890123000
' Decimal( 1.2345678901234567E+25 )      12345678901234600000000000
' Decimal( 1.2345678901234567E+35 )               OverflowException
' Decimal( 1.23456789E-5 )                          0.0000123456789
' Decimal( 1.234567890123E-15 )       0.000000000000001234567890123
' Decimal( 1.2345678901234567E-25 )  0.0000000000000000000000001235
' Decimal( 1.2345678901234567E-35 )                               0
' Decimal( 1.0 / 7.0 )                            0.142857142857143
'</Snippet2>