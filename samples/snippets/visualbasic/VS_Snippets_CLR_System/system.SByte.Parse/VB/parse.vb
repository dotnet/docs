'<Snippet1>
' Example of the SByte.Parse( ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module SByteParseDemo
    
    Sub SByteParse( styles As NumberStyles, _
        provider As IFormatProvider )

        Dim sbyteFormats As String( ) = { _
            " 99 ",     " +123 ",   " (123) ", _
            " -123 ",   " 1_2_3",   " 7E " }
            
        ' Parse each string in the sbyteFormats array, using 
        ' NumberStyles and IFormatProvider, if specified.
        Dim sbyteString As String
        For Each sbyteString In  sbyteFormats

            Dim sbyteNumber As SByte
                
            ' Display the first part of the output line.
            Console.Write( "  Parse of {0,-12}", _
                String.Format( """{0}""", sbyteString ) )

            ' Use the appropriate SByte.Parse overload, based on 
            ' the parameters that are specified.
            Try
                If provider Is Nothing Then
                    If styles < 0 Then
                        sbyteNumber = SByte.Parse( sbyteString )
                    Else
                        sbyteNumber = _
                            SByte.Parse( sbyteString, styles )
                    End If
                ElseIf styles < 0 Then
                    sbyteNumber = _
                        SByte.Parse( sbyteString, provider )
                Else
                    sbyteNumber = SByte.Parse( _
                        sbyteString, styles, provider )
                End If
                
                ' Display the resulting value if Parse succeeded.
                Console.WriteLine( "succeeded: {0}", _
                    sbyteNumber )

            ' Display the exception message if Parse failed.
            Catch ex As Exception
                Console.WriteLine( "failed: {0}", ex.Message )
            End Try
        Next sbyteString
    End Sub 
        
    Sub RunParseDemo( )
            
        ' Do not use IFormatProvider or NumberStyles.
        Console.WriteLine( vbCrLf & _
            "NumberStyles and IFormatProvider are not used:" )
        SByteParse( CType( -1, NumberStyles ), Nothing )
            
        ' Use NumberStyles.HexNumber; do not use IFormatProvider.
        Console.WriteLine( vbCrLf & "NumberStyles." & _
            "HexNumber is used; IFormatProvider is not used:" )
        SByteParse( NumberStyles.HexNumber, Nothing )
            
        ' Get the NumberFormatInfo object from the invariant 
        ' culture, and enable parentheses to indicate negative.
        Dim culture As New CultureInfo( "" )
        Dim numFormat As NumberFormatInfo = culture.NumberFormat
        numFormat.NumberNegativePattern = 0
            
        ' Change the digit group separator to '_' and the digit
        ' group size to 1.
        numFormat.NumberGroupSeparator = "_"
        numFormat.NumberGroupSizes = New Integer( ) { 1 }
            
        ' Use the NumberFormatInfo object as the IFormatProvider.
        Console.WriteLine( vbCrLf & _
            "A NumberStyles value is not used, but the " & _
            "IFormatProvider sets the group " & vbCrLf & "" & _
            "separator = '_', group size = 1, and negative " & _
            "pattern = ( ):" )
        SByteParse( CType( -1, NumberStyles ), numFormat )
            
        ' Use NumberStyles.Number and NumberStyles.AllowParentheses.
        Console.WriteLine( vbCrLf & _
            "NumberStyles.Number, NumberStyles.AllowParentheses, " & _
            "and the same " & vbCrLf & "IFormatProvider are used:" )
        SByteParse( NumberStyles.Number + _
            NumberStyles.AllowParentheses, numFormat )
    End Sub 
        
    Sub Main( )
        Console.WriteLine( "This example of" & vbCrLf & _
            "  SByte.Parse( String )," & vbCrLf & _
            "  SByte.Parse( String, NumberStyles )," & vbCrLf & _
            "  SByte.Parse( String, IFormatProvider ), and" & _
            vbCrLf & "  SByte.Parse( String, NumberStyles, " & _
            "IFormatProvider )" & vbCrLf & _
            "generates the following output when parsing " & _
            "string representations" & vbCrLf & "of SByte " & _
            "values with each of these forms of SByte.Parse( )." )
            
        RunParseDemo( )

    End Sub 
End Module 

' This example of
'   SByte.Parse( String ),
'   SByte.Parse( String, NumberStyles ),
'   SByte.Parse( String, IFormatProvider ), and
'   SByte.Parse( String, NumberStyles, IFormatProvider )
' generates the following output when parsing string representations
' of SByte values with each of these forms of SByte.Parse( ).
' 
' NumberStyles and IFormatProvider are not used:
'   Parse of " 99 "      succeeded: 99
'   Parse of " +123 "    succeeded: 123
'   Parse of " (123) "   failed: Input string was not in a correct format.
'   Parse of " -123 "    succeeded: -123
'   Parse of " 1_2_3"    failed: Input string was not in a correct format.
'   Parse of " 7E "      failed: Input string was not in a correct format.
' 
' NumberStyles.HexNumber is used; IFormatProvider is not used:
'   Parse of " 99 "      succeeded: -103
'   Parse of " +123 "    failed: Input string was not in a correct format.
'   Parse of " (123) "   failed: Input string was not in a correct format.
'   Parse of " -123 "    failed: Input string was not in a correct format.
'   Parse of " 1_2_3"    failed: Input string was not in a correct format.
'   Parse of " 7E "      succeeded: 126
' 
' A NumberStyles value is not used, but the IFormatProvider sets the group
' separator = '_', group size = 1, and negative pattern = ( ):
'   Parse of " 99 "      succeeded: 99
'   Parse of " +123 "    succeeded: 123
'   Parse of " (123) "   failed: Input string was not in a correct format.
'   Parse of " -123 "    succeeded: -123
'   Parse of " 1_2_3"    failed: Input string was not in a correct format.
'   Parse of " 7E "      failed: Input string was not in a correct format.
' 
' NumberStyles.Number, NumberStyles.AllowParentheses, and the same
' IFormatProvider are used:
'   Parse of " 99 "      succeeded: 99
'   Parse of " +123 "    succeeded: 123
'   Parse of " (123) "   succeeded: -123
'   Parse of " -123 "    succeeded: -123
'   Parse of " 1_2_3"    succeeded: 123
'   Parse of " 7E "      failed: Input string was not in a correct format.
'</Snippet1>