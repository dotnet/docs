'<Snippet3>
' Example of the Convert.ToInt16( String ) and 
' Convert.ToInt16( String, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ToInt16ProviderDemo

    Dim format As String = "{0,-20}{1,-20}{2}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub ConvertToInt16( numericStr As String, _
        provider As IFormatProvider )

        Dim defaultValue    As Object
        Dim providerValue   As Object

        ' Convert numericStr to Int16 without a format provider.
        Try
            defaultValue = Convert.ToInt16( numericStr )
        Catch ex As Exception
            defaultValue = GetExceptionType( ex )
        End Try

        ' Convert numericStr to Int16 with a format provider.
        Try
            providerValue = Convert.ToInt16( numericStr, provider )
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
            "  Convert.ToInt16( String ) and " & vbCrLf & _
            "  Convert.ToInt16( String, IFormatProvider ) " & _
            vbCrLf & "generates the following output. It " & _
            "converts several strings to " & vbCrLf & "Short " & _
            "values, using default formatting " & _
            "or a NumberFormatInfo object." & vbCrLf )
        Console.WriteLine( format, "String to convert", _
            "Default/exception", "Provider/exception" )
        Console.WriteLine( format, "-----------------", _
            "-----------------", "------------------" )

        ' Convert strings, with and without an IFormatProvider.
        ConvertToInt16( "12345", provider )
        ConvertToInt16( "+12345", provider )
        ConvertToInt16( "pos 12345", provider )
        ConvertToInt16( "-12345", provider )
        ConvertToInt16( "neg 12345", provider )
        ConvertToInt16( "12345.", provider )
        ConvertToInt16( "12,345", provider )
        ConvertToInt16( "(12345)", provider )
        ConvertToInt16( "32768", provider )
        ConvertToInt16( "-32769", provider )
    End Sub 
End Module 

' This example of
'   Convert.ToInt16( String ) and
'   Convert.ToInt16( String, IFormatProvider )
' generates the following output. It converts several strings to
' Short values, using default formatting or a NumberFormatInfo object.
' 
' String to convert   Default/exception   Provider/exception
' -----------------   -----------------   ------------------
' 12345               12345               12345
' +12345              12345               FormatException
' pos 12345           FormatException     12345
' -12345              -12345              FormatException
' neg 12345           FormatException     -12345
' 12345.              FormatException     FormatException
' 12,345              FormatException     FormatException
' (12345)             FormatException     FormatException
' 32768               OverflowException   OverflowException
' -32769              OverflowException   FormatException
'</Snippet3>