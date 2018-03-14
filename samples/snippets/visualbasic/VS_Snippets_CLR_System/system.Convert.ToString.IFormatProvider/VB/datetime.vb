'<Snippet1>
' Example of the Convert.ToString( DateTime ) and 
' Convert.ToString( DateTime, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module DateTimeIFormatProviderDemo
    
    Sub DisplayDateNCultureName( testDate As DateTime, _
        cultureName as String )

        ' Create the CultureInfo object for the specified culture,
        ' and use it as the IFormatProvider when converting the date.
        Dim culture  As CultureInfo = new CultureInfo( cultureName )
        Dim dateString As String = _
            Convert.ToString( testDate, culture )

        ' Bracket the culture name, and display the name and date.
        Console.WriteLine( "   {0,-12}{1}", _
            String.Concat( "[", cultureName, "]" ), dateString )
    End Sub

    Sub Main( )
        ' Specify the date to be formatted under various cultures.
        Dim tDate As DateTime = _
            new DateTime( 2003, 4, 15, 20, 30, 40, 333 )

        Console.WriteLine( "This example of " & vbCrLf & _
            "   Convert.ToString( DateTime ) and " & vbCrLf & _
            "   Convert.ToString( DateTime, IFormatProvider )" & _
            vbCrLf & "generates the following output. It " & _
            "creates CultureInfo objects " & vbCrLf & "for " & _
            "several cultures and formats " & _
            "a DateTime value with each." & vbCrLf )

        ' Format the date without an IFormatProvider.
        Console.WriteLine( "   {0,-12}{1}", _
            Nothing, "No IFormatProvider" )
        Console.WriteLine( "   {0,-12}{1}", _
            Nothing, "------------------" )
        Console.WriteLine( "   {0,-12}{1}" & vbCrLf, _
            String.Concat( _
                "[", CultureInfo.CurrentCulture.Name, "]" ), _
            Convert.ToString( tDate ) )

        ' Format the date with IFormatProvider for several cultures.
        Console.WriteLine( "   {0,-12}{1}", _
            "Culture", "With IFormatProvider" )
        Console.WriteLine( "   {0,-12}{1}", _
            "-------", "--------------------" )
        
        DisplayDateNCultureName( tDate, "" )
        DisplayDateNCultureName( tDate, "en-US" )
        DisplayDateNCultureName( tDate, "es-AR" )
        DisplayDateNCultureName( tDate, "fr-FR" )
        DisplayDateNCultureName( tDate, "hi-IN" )
        DisplayDateNCultureName( tDate, "ja-JP" )
        DisplayDateNCultureName( tDate, "nl-NL" )
        DisplayDateNCultureName( tDate, "ru-RU" )
        DisplayDateNCultureName( tDate, "ur-PK" )
    End Sub 
End Module 

' This example of
'    Convert.ToString( DateTime ) and
'    Convert.ToString( DateTime, IFormatProvider )
' generates the following output. It creates CultureInfo objects
' for several cultures and formats a DateTime value with each.
' 
'                No IFormatProvider
'                ------------------
'    [en-US]     4/15/2003 8:30:40 PM
' 
'    Culture     With IFormatProvider
'    -------     --------------------
'    []          04/15/2003 20:30:40
'    [en-US]     4/15/2003 8:30:40 PM
'    [es-AR]     15/04/2003 08:30:40 p.m.
'    [fr-FR]     15/04/2003 20:30:40
'    [hi-IN]     15-04-2003 20:30:40
'    [ja-JP]     2003/04/15 20:30:40
'    [nl-NL]     15-4-2003 20:30:40
'    [ru-RU]     15.04.2003 20:30:40
'    [ur-PK]     15/04/2003 8:30:40 PM
'</Snippet1>