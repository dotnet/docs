'<Snippet1>
' Example for the Byte.ToString( ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ByteToStringDemo
    
    Sub RunToStringDemo( )

        Dim smallValue As Byte = 13
        Dim largeValue As Byte = 234
            
        ' Format the Byte values without and with format strings.
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
            
        ' Set the digit grouping to 1, set the digit separator
        ' to underscore, and set decimal digits to 0.
        numInfo.NumberGroupSizes = New Integer( ) { 1 }
        numInfo.NumberGroupSeparator = "_"
        numInfo.NumberDecimalDigits = 0
            
        ' Use the NumberFormatInfo object for an IFormatProvider.
        Console.WriteLine( vbCrLf & _
            "A NumberFormatInfo object with digit group " & _
            "size = 1 and " & vbCrLf & "digit separator " & _
            "= '_' is used for the IFormatProvider:" )
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
            "   Byte.ToString( )," & vbCrLf & _ 
            "   Byte.ToString( String )," & vbCrLf & _
            "   Byte.ToString( IFormatProvider ), and" & vbCrLf & _
            "   Byte.ToString( String, IFormatProvider )" & _
            vbCrLf & "generates the following output when " & _
            "formatting Byte values " & vbCrLf & _
            "with combinations of format " & _
            "strings and IFormatProvider." )
            
        RunToStringDemo( )

    End Sub
End Module 

' This example of
'    Byte.ToString( ),
'    Byte.ToString( String ),
'    Byte.ToString( IFormatProvider ), and
'    Byte.ToString( String, IFormatProvider )
' generates the following output when formatting Byte values
' with combinations of format strings and IFormatProvider.
' 
' IFormatProvider is not used:
'    No format string:           13       234
'    'X2' format string:         0D        EA
'
' A NumberFormatInfo object with digit group size = 1 and
' digit separator = '_' is used for the IFormatProvider:
'    No format string:           13       234
'    'N' format string:         1_3     2_3_4
'</Snippet1>