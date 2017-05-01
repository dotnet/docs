'<Snippet1>
' Example of the Decimal( Integer ) constructor.
Imports System
Imports Microsoft.VisualBasic

Module DecimalCtorIDemo

    ' Create a Decimal object and display its value.
    Sub CreateDecimal( value As Integer, valToStr As String )

        Dim decimalNum As New Decimal( value )

        ' Format the constructor for display.
        Dim ctor As String = _
            String.Format( "Decimal( {0} )", valToStr )

        ' Display the constructor and its value.
        Console.WriteLine( "{0,-33}{1,16}", ctor, decimalNum )
    End Sub
    
    Sub Main( )

        Console.WriteLine( _
            "This example of the Decimal( Integer ) constructor " & _
            vbCrLf & "generates the following output." & vbCrLf )
        Console.WriteLine( "{0,-33}{1,16}", "Constructor", "Value" )
        Console.WriteLine( "{0,-33}{1,16}", "-----------", "-----" )

        ' Construct Decimal objects from Integer values.
        CreateDecimal( Integer.MinValue, "Integer.MinValue" )                
        CreateDecimal( Integer.MaxValue, "Integer.MaxValue" )                
        CreateDecimal( 0, "0" )                
        CreateDecimal( 999999999, "999999999" )                
        CreateDecimal( &H40000000, "&H40000000" )                
        CreateDecimal( &HC0000000, "&HC0000000" )                
    End Sub 
End Module 

' This example of the Decimal( Integer ) constructor
' generates the following output.
' 
' Constructor                                 Value
' -----------                                 -----
' Decimal( Integer.MinValue )           -2147483648
' Decimal( Integer.MaxValue )            2147483647
' Decimal( 0 )                                    0
' Decimal( 999999999 )                    999999999
' Decimal( &H40000000 )                  1073741824
' Decimal( &HC0000000 )                 -1073741824
'</Snippet1>