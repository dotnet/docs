'<Snippet4>
' Example of the Decimal( UInt64 ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorULDemo

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( value As UInt64, valToStr As String )

        Dim decimalNum As New Decimal( value )

        ' Format the constructor for display.
        Dim ctor As String = _
            String.Format( "Decimal( {0} )", valToStr )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-33}{1,22}", ctor, decimalNum )
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the Decimal( UInt64 ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-33}{1,22}", "Constructor", "Value" )
        Console.WriteLine( "{0,-33}{1,22}", "-----------", "-----" )

        ' Construct Decimal objects from UInt64 values.
        ' UInt64.MinValue and UInt64.MaxValue are not defined in VB.
        CreateDecimal( Convert.ToUInt64( 0 ), """UInt64.MinValue""" )
        CreateDecimal( Convert.ToUInt64( 18446744073709551615D ), _
            """UInt64.MaxValue""" )
        CreateDecimal( Convert.ToUInt64( Long.MaxValue ), _
            "Long.MaxValue" )              
        CreateDecimal( Convert.ToUInt64( 999999999999999999 ), _
            "999999999999999999" )                
        CreateDecimal( Convert.ToUInt64( &H2000000000000000 ), _
            "&H2000000000000000" )                
        CreateDecimal( Convert.ToUInt64( 16140901064495857664.0 ), _
            "16140901064495857664.0" )                
    End Sub 
End Module 

' This example of the Decimal( UInt64 ) constructor
' generates the following output.
' 
' Constructor                                       Value
' -----------                                       -----
' Decimal( "UInt64.MinValue" )                          0
' Decimal( "UInt64.MaxValue" )       18446744073709551615
' Decimal( Long.MaxValue )            9223372036854775807
' Decimal( 999999999999999999 )        999999999999999999
' Decimal( &H2000000000000000 )       2305843009213693952
' Decimal( 16140901064495857664.0 )  16140901064495857664
'</Snippet4>