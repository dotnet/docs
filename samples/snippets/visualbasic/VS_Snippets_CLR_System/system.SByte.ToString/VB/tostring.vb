'<Snippet1>
' Example for the SByte.ToString( ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module SByteToStringDemo
    
    Sub RunToStringDemo( )

        Dim smallValue As SByte = Convert.ToSByte( -99 )
        Dim largeValue As SByte = Convert.ToSByte( 123 )
            
        ' Format the SByte values without and with format strings.
        Console.WriteLine( vbCrLf & "IFormatProvider is not used:" )
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", _
            "No format string:", smallValue.ToString( ), _
            largeValue.ToString( ) )
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", _
            "'X2' format string:", smallValue.ToString( "X2" ), _
            largeValue.ToString( "X2" ) )
            
        ' Get the NumberFormatInfo object from the 
        ' invariant culture.
        Dim culture As New CultureInfo( "" )
        Dim numInfo As NumberFormatInfo = culture.NumberFormat
            
        ' Set decimal digits to 0. Set the negative pattern to ( ).
        numInfo.NumberNegativePattern = 0
        numInfo.NumberDecimalDigits = 0
            
        ' Use the NumberFormatInfo object for an IFormatProvider.
        Console.WriteLine( vbCrLf & _
            "A NumberFormatInfo object with negative pattern " & _
            "= ( ) and " & vbCrLf & "no decimal digits " & _
            "is used for the IFormatProvider:" )
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", _
            "No format string:", smallValue.ToString( numInfo ), _
            largeValue.ToString( numInfo ) )
        Console.WriteLine( "   {0,-20}{1,10}{2,10}", _
            "'N' format string:", _
            smallValue.ToString( "N", numInfo ), _
            largeValue.ToString( "N", numInfo ) )
    End Sub 
        
    Sub Main( )

        Console.WriteLine( "This example of" & vbCrLf & _
            "   SByte.ToString( )," & vbCrLf & _ 
            "   SByte.ToString( String )," & vbCrLf & _
            "   SByte.ToString( IFormatProvider ), and" & vbCrLf & _
            "   SByte.ToString( String, IFormatProvider )" & _
            vbCrLf & "generates the following output when " & _
            "formatting SByte values " & vbCrLf & _
            "with combinations of format " & _
            "strings and IFormatProvider." )

        RunToStringDemo( )

    End Sub 
End Module 

' This example of
'    SByte.ToString( ),
'    SByte.ToString( String ),
'    SByte.ToString( IFormatProvider ), and
'    SByte.ToString( String, IFormatProvider )
' generates the following output when formatting SByte values
' with combinations of format strings and IFormatProvider.
'
' IFormatProvider is not used:
'    No format string:          -99       123
'    'X2' format string:         9D        7B
'
' A NumberFormatInfo object with negative pattern = ( ) and
' no decimal digits is used for the IFormatProvider:
'    No format string:          -99       123
'    'N' format string:        (99)       123
'</Snippet1>