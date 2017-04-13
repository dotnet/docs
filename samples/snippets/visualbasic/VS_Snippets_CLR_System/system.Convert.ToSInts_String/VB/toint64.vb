'<Snippet1>
' Example of the Convert.ToInt64( String ) and 
' Convert.ToInt64( String, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ToInt64ProviderDemo

    Dim format As String = "{0,-22}{1,-20}{2}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub ConvertToInt64( numericStr As String, _
        provider As IFormatProvider )

        Dim defaultValue    As Object
        Dim providerValue   As Object

        ' Convert numericStr to Int64 without a format provider.
        Try
            defaultValue = Convert.ToInt64( numericStr )
        Catch ex As Exception
            defaultValue = GetExceptionType( ex )
        End Try

        ' Convert numericStr to Int64 with a format provider.
        Try
            providerValue = Convert.ToInt64( numericStr, provider )
        Catch ex As Exception
            providerValue = GetExceptionType( ex )
        End Try

        Console.WriteLine( format, numericStr, _
            defaultValue, providerValue )
    End Sub

    Sub Main( )

        ' Create a NumberFormatInfo object and set several of its
        ' properties that apply to numbers.
        Dim provider  As NumberFormatInfo = new NumberFormatInfo( )

        ' These properties affect the conversion.
        provider.NegativeSign = "neg "
        provider.PositiveSign = "pos "

        ' These properties do not affect the conversion.
        ' The input string cannot have decimal and group separators.
        provider.NumberDecimalSeparator = "."
        provider.NumberGroupSeparator = ","
        provider.NumberGroupSizes = New Integer( ) { 3 }
        provider.NumberNegativePattern = 0

        Console.WriteLine( "This example of" & vbCrLf & _
            "  Convert.ToInt64( String ) and " & vbCrLf & _
            "  Convert.ToInt64( String, IFormatProvider ) " & _
            vbCrLf & "generates the following output. It " & _
            "converts several strings to " & vbCrLf & "Long " & _
            "values, using default formatting " & _
            "or a NumberFormatInfo object." & vbCrLf )
        Console.WriteLine( format, "String to convert", _
            "Default/exception", "Provider/exception" )
        Console.WriteLine( format, "-----------------", _
            "-----------------", "------------------" )

        ' Convert strings, with and without an IFormatProvider.
        ConvertToInt64( "123456789", provider )
        ConvertToInt64( "+123456789", provider )
        ConvertToInt64( "pos 123456789", provider )
        ConvertToInt64( "-123456789", provider )
        ConvertToInt64( "neg 123456789", provider )
        ConvertToInt64( "123456789.", provider )
        ConvertToInt64( "123,456,789", provider )
        ConvertToInt64( "(123456789)", provider )
        ConvertToInt64( "9223372036854775808", provider )
        ConvertToInt64( "-9223372036854775809", provider )
    End Sub 
End Module 

' This example of
'   Convert.ToInt64( String ) and
'   Convert.ToInt64( String, IFormatProvider )
' generates the following output. It converts several strings to
' Long values, using default formatting or a NumberFormatInfo object.
' 
' String to convert     Default/exception   Provider/exception
' -----------------     -----------------   ------------------
' 123456789             123456789           123456789
' +123456789            123456789           FormatException
' pos 123456789         FormatException     123456789
' -123456789            -123456789          FormatException
' neg 123456789         FormatException     -123456789
' 123456789.            FormatException     FormatException
' 123,456,789           FormatException     FormatException
' (123456789)           FormatException     FormatException
' 9223372036854775808   OverflowException   OverflowException
' -9223372036854775809  OverflowException   FormatException
'</Snippet1>