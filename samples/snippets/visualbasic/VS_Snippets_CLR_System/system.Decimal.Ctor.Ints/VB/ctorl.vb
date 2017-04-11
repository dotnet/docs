'<Snippet3>
' Example of the Decimal( Long ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorLDemo

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( value As Long, valToStr As String )

        Dim decimalNum As New Decimal( value )

        ' Format the constructor for display.
        Dim ctor As String = _
            String.Format( "Decimal( {0} )", valToStr )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-30}{1,22}", ctor, decimalNum )
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the Decimal( Long ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-30}{1,22}", "Constructor", "Value" )
        Console.WriteLine( "{0,-30}{1,22}", "-----------", "-----" )

        ' Construct Decimal objects from Long values.
        CreateDecimal( Long.MinValue, "Long.MinValue" )                
        CreateDecimal( Long.MaxValue, "Long.MaxValue" )                
        CreateDecimal( 0L, "0" )                
        CreateDecimal( 999999999999999999, "999999999999999999" )                
        CreateDecimal( &H2000000000000000, "&H2000000000000000" )                
        CreateDecimal( &HE000000000000000, "&HE000000000000000" )                
    End Sub 
End Module 

' This example of the Decimal( Long ) constructor
' generates the following output.
' 
' Constructor                                    Value
' -----------                                    -----
' Decimal( Long.MinValue )        -9223372036854775808
' Decimal( Long.MaxValue )         9223372036854775807
' Decimal( 0 )                                       0
' Decimal( 999999999999999999 )     999999999999999999
' Decimal( &H2000000000000000 )    2305843009213693952
' Decimal( &HE000000000000000 )   -2305843009213693952
'</Snippet3>