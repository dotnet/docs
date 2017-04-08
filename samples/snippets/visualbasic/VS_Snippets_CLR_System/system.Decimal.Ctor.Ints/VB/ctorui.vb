'<Snippet2>
' Example of the Decimal( UInt32 ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorUIDemo

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( value As UInt32, valToStr As String )

        Dim decimalNum As New Decimal( value )

        ' Format the constructor for display.
        Dim ctor As String = _
            String.Format( "Decimal( {0} )", valToStr )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-33}{1,16}", ctor, decimalNum )
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the Decimal( UInt32 ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-33}{1,16}", "Constructor", "Value" )
        Console.WriteLine( "{0,-33}{1,16}", "-----------", "-----" )

        ' Construct Decimal objects from UInt32 values.
        ' UInt32.MinValue and UInt32.MaxValue are not defined in VB.
        CreateDecimal( Convert.ToUInt32( 0 ), """UInt32.MinValue""" )
        CreateDecimal( Convert.ToUInt32( 4294967295 ), _
            """UInt32.MaxValue""" )
        CreateDecimal( Convert.ToUInt32( Integer.MaxValue ), _
            "Integer.MaxValue" )              
        CreateDecimal( Convert.ToUInt32( 999999999 ), "999999999" ) 
        CreateDecimal( Convert.ToUInt32( &H40000000 ), "&H40000000" ) 
        CreateDecimal( Convert.ToUInt32( &HC0000000L ), "&HC0000000" )
    End Sub 
End Module 

' This example of the Decimal( UInt32 ) constructor
' generates the following output.
' 
' Constructor                                 Value
' -----------                                 -----
' Decimal( "UInt32.MinValue" )                    0
' Decimal( "UInt32.MaxValue" )           4294967295
' Decimal( Integer.MaxValue )            2147483647
' Decimal( 999999999 )                    999999999
' Decimal( &H40000000 )                  1073741824
' Decimal( &HC0000000 )                  3221225472
'</Snippet2>