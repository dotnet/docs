'<Snippet1>
' Example of the Decimal( Single ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorSDemo

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( value As Single, valToStr As String )

        ' Format and display the constructor.
        Console.Write( "{0,-27}", _
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
            "This example of the Decimal( Single ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-27}{1,31}", "Constructor", "Value or Exception" )
        Console.WriteLine( "{0,-27}{1,31}", "-----------", "------------------" )

        ' Construct Decimal objects from Single values.
        CreateDecimal( 1.2345E+5, "1.2345E+5" )                
        CreateDecimal( 1.234567E+15, "1.234567E+15" )                
        CreateDecimal( 1.23456789E+25, "1.23456789E+25" )                
        CreateDecimal( 1.23456789E+35, "1.23456789E+35" )                
        CreateDecimal( 1.2345E-5, "1.2345E-5" )                
        CreateDecimal( 1.234567E-15, "1.234567E-15" )                
        CreateDecimal( 1.23456789E-25, "1.23456789E-25" )                
        CreateDecimal( 1.23456789E-35, "1.23456789E-35" )                
        CreateDecimal( 1.0 / 7.0, "1.0 / 7.0" )                
    End Sub 
End Module 

' This example of the Decimal( Single ) constructor
' generates the following output.
' 
' Constructor                             Value or Exception
' -----------                             ------------------
' Decimal( 1.2345E+5 )                                123450
' Decimal( 1.234567E+15 )                   1234567000000000
' Decimal( 1.23456789E+25 )       12345680000000000000000000
' Decimal( 1.23456789E+35 )                OverflowException
' Decimal( 1.2345E-5 )                           0.000012345
' Decimal( 1.234567E-15 )            0.000000000000001234567
' Decimal( 1.23456789E-25 )   0.0000000000000000000000001235
' Decimal( 1.23456789E-35 )                                0
' Decimal( 1.0 / 7.0 )                             0.1428571
'</Snippet1>