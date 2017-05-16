'<Snippet1>
' Example of the Convert.ToDecimal( String ) and 
' Convert.ToDecimal( String, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ToDecimalProviderDemo

    Dim formatter As String = "{0,-22}{1,-20}{2}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        GetExceptionType = exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub ConvertToDecimal( numericStr As String, _
        provider As IFormatProvider )

        Dim defaultValue    As Object
        Dim providerValue   As Object

        ' Convert numericStr to Decimal without a format provider.
        Try
            defaultValue = Convert.ToDecimal( numericStr )
        Catch ex As Exception
            defaultValue = GetExceptionType( ex )
        End Try

        ' Convert numericStr to Decimal with a format provider.
        Try
            providerValue = Convert.ToDecimal( numericStr, provider )
        Catch ex As Exception
            providerValue = GetExceptionType( ex )
        End Try

        Console.WriteLine( formatter, numericStr, _
            defaultValue, providerValue )
    End Sub

    Sub Main( )

        ' Create a NumberFormatInfo object and set several of its
        ' properties that apply to numbers.
        Dim provider  As NumberFormatInfo = new NumberFormatInfo( )

        provider.NumberDecimalSeparator = ","
        provider.NumberGroupSeparator = "."
        provider.NumberGroupSizes = New Integer( ) { 3 }

        Console.WriteLine( "This example of" & vbCrLf & _
            "  Convert.ToDecimal( String ) and " & vbCrLf & _
            "  Convert.ToDecimal( String, IFormatProvider ) " & _
            vbCrLf & "generates the " & _
            "following output when run in the [{0}] culture.", _
            CultureInfo.CurrentCulture.Name )
        Console.WriteLine( vbCrLf & _
            "Several strings are converted to Decimal values, " & _
            "using " & vbCrLf & "default formatting " & _
            "and a NumberFormatInfo object." & vbCrLf )
        Console.WriteLine( formatter, "String to convert", _
            "Default/exception", "Provider/exception" )
        Console.WriteLine( formatter, "-----------------", _
            "-----------------", "------------------" )

        ' Convert strings, with and without an IFormatProvider.
        ConvertToDecimal( "123456789", provider )
        ConvertToDecimal( "12345.6789", provider )
        ConvertToDecimal( "12345,6789", provider )
        ConvertToDecimal( "123,456.789", provider )
        ConvertToDecimal( "123.456,789", provider )
        ConvertToDecimal( "123,456,789.0123", provider )
        ConvertToDecimal( "123.456.789,0123", provider )
    End Sub 
End Module 

' This example of
'   Convert.ToDecimal( String ) and
'   Convert.ToDecimal( String, IFormatProvider )
' generates the following output when run in the [en-US] culture.
' 
' Several strings are converted to Decimal values, using
' default formatting and a NumberFormatInfo object.
' 
' String to convert     Default/exception   Provider/exception
' -----------------     -----------------   ------------------
' 123456789             123456789           123456789
' 12345.6789            12345.6789          123456789
' 12345,6789            123456789           12345.6789
' 123,456.789           123456.789          FormatException
' 123.456,789           FormatException     123456.789
' 123,456,789.0123      123456789.0123      FormatException
' 123.456.789,0123      FormatException     123456789.0123
'</Snippet1>