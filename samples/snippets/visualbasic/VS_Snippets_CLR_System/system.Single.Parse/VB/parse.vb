'<Snippet1>
' Example of the Single.Parse( ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module SingleParseDemo
    
    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub SingleParse( styles As NumberStyles, _
        provider As IFormatProvider )

        Dim singleFormats As String( ) = { _
            " 987.654E-2",    " 987,654E-2",    "(98765,43210)", _
            "9,876,543.210",  "9.876.543,210",  "98_76_54_32,19" }
            
        ' Parse each string in the singleFormats array, using 
        ' NumberStyles and IFormatProvider, if specified.
        Dim singleString As String
        For Each singleString In  singleFormats

            Dim singleNumber As Single

            ' Display the first part of the output line.
            Console.Write( "  Parse of {0,-20}", _
                String.Format( """{0}""", singleString ) )

            ' Use the appropriate Single.Parse overload, based on 
            ' the parameters that are specified.
            Try
                If provider Is Nothing Then
                    If styles < 0 Then
                        singleNumber = Single.Parse( singleString )
                    Else
                        singleNumber = _
                            Single.Parse( singleString, styles )
                    End If
                ElseIf styles < 0 Then
                    singleNumber = _
                        Single.Parse( singleString, provider )
                Else
                    singleNumber = Single.Parse( _
                        singleString, styles, provider )
                End If
                
                ' Display the resulting value if Parse succeeded.
                Console.WriteLine( "success: {0}", singleNumber )

            ' Display the exception type if Parse failed.
            Catch ex As Exception
                Console.WriteLine( "failed:  {0}", _
                    GetExceptionType( ex ) )
            End Try
        Next singleString
    End Sub 
    
    Sub Main( )
        Console.WriteLine( "This example of" & vbCrLf & _
            "  Single.Parse( String )," & vbCrLf & _
            "  Single.Parse( String, NumberStyles )," & vbCrLf & _
            "  Single.Parse( String, IFormatProvider ), and" & _
            vbCrLf & "  Single.Parse( String, NumberStyles, " & _
            "IFormatProvider )" & vbCrLf & "generates the " & _
            "following output when run in the [{0}] culture.", _
            CultureInfo.CurrentCulture.Name )
        Console.WriteLine( "Several string representations " & _
            "of Single values are parsed." )

        ' Do not use IFormatProvider or NumberStyles.
        Console.WriteLine( vbCrLf & _
            "NumberStyles and IFormatProvider are not " & _
            "used; current culture is [{0}]:", _
            CultureInfo.CurrentCulture.Name )
        SingleParse( CType( -1, NumberStyles ), Nothing )

        ' Use the NumberStyle for Currency.
        Console.WriteLine( vbCrLf & "NumberStyles.Currency " & _
            "is used; IFormatProvider is not used:" )
        SingleParse( NumberStyles.Currency, Nothing )
            
        ' Create a CultureInfo object for another culture. Use
        ' [Dutch - The Netherlands] unless the current culture
        ' is Dutch language. In that case use [English - U.S.].
        Dim cultureName As String = IIf( _
            CultureInfo.CurrentCulture.Name.Substring( 0, 2 ) = _
                "nl", "en-US", "nl-NL" )
        Dim culture As New CultureInfo( cultureName )
            
        Console.WriteLine( vbCrLf & _
            "NumberStyles is not used; [{0}] culture " & _
            "IFormatProvider is used:", culture.Name )
        SingleParse( CType( -1, NumberStyles ), culture )
            
        ' Get the NumberFormatInfo object from CultureInfo, and
        ' then change the digit group size to 2 and the digit
        ' separator to '_'.
        Dim numInfo As NumberFormatInfo = culture.NumberFormat
        numInfo.NumberGroupSizes = New Integer( ) { 2 }
        numInfo.NumberGroupSeparator = "_"
            
        ' Use the NumberFormatInfo object as the IFormatProvider.
        Console.WriteLine( vbCrLf & _
            "NumberStyles.Currency is used, group size = 2, " & _
            "separator = ""_"":" )
        SingleParse( NumberStyles.Currency, numInfo )
    End Sub 
End Module 

' This example of
'   Single.Parse( String ),
'   Single.Parse( String, NumberStyles ),
'   Single.Parse( String, IFormatProvider ), and
'   Single.Parse( String, NumberStyles, IFormatProvider )
' generates the following output when run in the [en-US] culture.
' Several string representations of Single values are parsed.
' 
' NumberStyles and IFormatProvider are not used; current culture is [en-US]:
'   Parse of " 987.654E-2"       success: 9.87654
'   Parse of " 987,654E-2"       success: 9876.54
'   Parse of "(98765,43210)"     failed:  FormatException
'   Parse of "9,876,543.210"     success: 9876543
'   Parse of "9.876.543,210"     failed:  FormatException
'   Parse of "98_76_54_32,19"    failed:  FormatException
' 
' NumberStyles.Currency is used; IFormatProvider is not used:
'   Parse of " 987.654E-2"       failed:  FormatException
'   Parse of " 987,654E-2"       failed:  FormatException
'   Parse of "(98765,43210)"     success: -9.876543E+09
'   Parse of "9,876,543.210"     success: 9876543
'   Parse of "9.876.543,210"     failed:  FormatException
'   Parse of "98_76_54_32,19"    failed:  FormatException
' 
' NumberStyles is not used; [nl-NL] culture IFormatProvider is used:
'   Parse of " 987.654E-2"       success: 9876.54
'   Parse of " 987,654E-2"       success: 9.87654
'   Parse of "(98765,43210)"     failed:  FormatException
'   Parse of "9,876,543.210"     failed:  FormatException
'   Parse of "9.876.543,210"     success: 9876543
'   Parse of "98_76_54_32,19"    failed:  FormatException
' 
' NumberStyles.Currency is used, group size = 2, separator = "_":
'   Parse of " 987.654E-2"       failed:  FormatException
'   Parse of " 987,654E-2"       failed:  FormatException
'   Parse of "(98765,43210)"     success: -98765.43
'   Parse of "9,876,543.210"     failed:  FormatException
'   Parse of "9.876.543,210"     success: 9876543
'   Parse of "98_76_54_32,19"    success: 9.876543E+07
'</Snippet1>