'<Snippet1>
' Example for the Decimal.ToString( ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module DecimalToStringDemo
    
    Sub Main( )

        Dim nineBillPlus As Decimal = 9876543210.9876543210D
            
        Console.WriteLine( "This example of" & vbCrLf & _
            "   Decimal.ToString( ), " & vbCrLf & _
            "   Decimal.ToString( String )," & vbCrLf & _
            "   Decimal.ToString( IFormatProvider ), and " & _ 
            vbCrLf & "   Decimal.ToString( String, IFormat" & _
            "Provider )" & vbCrLf & "generates the following " & _
            "output when run in the [{0}] culture." & vbCrLf & _
            "Decimal numbers are formatted with various " & _
            "combinations " & vbCrLf & _
            "of format strings and IFormatProvider.", _
            CultureInfo.CurrentCulture.Name )

        ' Format the number without and with format strings.
        Console.WriteLine( vbCrLf & "IFormatProvider is not " & _
            "used; the default culture is [{0}]:", _
            CultureInfo.CurrentCulture.Name )
        Console.WriteLine( "   {0,-30}{1}", _
            "No format string:", nineBillPlus.ToString( ) )
        Console.WriteLine( "   {0,-30}{1}", _
            "'N' format string:", nineBillPlus.ToString( "N" ) )
        Console.WriteLine( "   {0,-30}{1}", _
            "'N5' format string:", nineBillPlus.ToString( "N5" ) )
            
        ' Create a CultureInfo object for another culture. Use
        ' [Dutch - The Netherlands] unless the current culture
        ' is Dutch language. In that case use [English - U.S.].
        Dim cultureName As String = IIf( _
            CultureInfo.CurrentCulture.Name.Substring( 0, 2 ) = _
                "nl", "en-US", "nl-NL" )
        Dim culture As New CultureInfo( cultureName )
            
        ' Use the CultureInfo object for an IFormatProvider.
        Console.WriteLine( vbCrLf & "A CultureInfo object " & _
            "for [{0}] is used for the IFormatProvider: ", _
            cultureName )
        Console.WriteLine( "   {0,-30}{1}", "No format string:", _
            nineBillPlus.ToString( culture ) )
        Console.WriteLine( "   {0,-30}{1}", _
            "'N5' format string:", _
            nineBillPlus.ToString( "N5", culture ) )
            
        ' Get the NumberFormatInfo object from CultureInfo, and
        ' then change the digit group size to 4 and the digit
        ' separator to '_'.
        Dim numInfo As NumberFormatInfo = culture.NumberFormat
        numInfo.NumberGroupSizes = New Integer( ) { 4 }
        numInfo.NumberGroupSeparator = "_"
            
        ' Use a NumberFormatInfo object for IFormatProvider.
        Console.WriteLine( vbCrLf & _
            "A NumberFormatInfo object with digit group " & _
            "size = 4 and " & vbCrLf & "digit separator " & _
            "= '_' is used for the IFormatProvider:" )
        Console.WriteLine( "   {0,-30}{1}", _
            "'N5' format string:", _
            nineBillPlus.ToString( "N5", culture ) )
    End Sub 
End Module 

' This example of
'    Decimal.ToString( ),
'    Decimal.ToString( String ),
'    Decimal.ToString( IFormatProvider ), and
'    Decimal.ToString( String, IFormatProvider )
' generates the following output when run in the [en-US] culture.
' Decimal numbers are formatted with various combinations
' of format strings and IFormatProvider.
' 
' IFormatProvider is not used; the default culture is [en-US]:
'    No format string:             9876543210.987654321
'    'N' format string:            9,876,543,210.99
'    'N5' format string:           9,876,543,210.98765
' 
' A CultureInfo object for [nl-NL] is used for the IFormatProvider:
'    No format string:             9876543210,987654321
'    'N5' format string:           9.876.543.210,98765
' 
' A NumberFormatInfo object with digit group size = 4 and
' digit separator = '_' is used for the IFormatProvider:
'    'N5' format string:           98_7654_3210,98765
'</Snippet1>