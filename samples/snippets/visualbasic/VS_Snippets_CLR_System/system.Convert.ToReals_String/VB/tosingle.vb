'<Snippet3>
' Example of the Convert.ToSingle( String ) and 
' Convert.ToSingle( String, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ToSingleProviderDemo

    Dim formatter As String = "{0,-22}{1,-20}{2}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        GetExceptionType = exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub ConvertToSingle( numericStr As String, _
        provider As IFormatProvider )

        Dim defaultValue    As Object
        Dim providerValue   As Object

        ' Convert numericStr to Single without a format provider.
        Try
            defaultValue = Convert.ToSingle( numericStr )
        Catch ex As Exception
            defaultValue = GetExceptionType( ex )
        End Try

        ' Convert numericStr to Single with a format provider.
        Try
            providerValue = Convert.ToSingle( numericStr, provider )
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
            "  Convert.ToSingle( String ) and " & vbCrLf & _
            "  Convert.ToSingle( String, IFormatProvider ) " & _
            vbCrLf & "generates the " & _
            "following output when run in the [{0}] culture.", _
            CultureInfo.CurrentCulture.Name )
        Console.WriteLine( vbCrLf & _
            "Several strings are converted to Single values, " & _
            "using " & vbCrLf & "default formatting " & _
            "and a NumberFormatInfo object." & vbCrLf )
        Console.WriteLine( formatter, "String to convert", _
            "Default/exception", "Provider/exception" )
        Console.WriteLine( formatter, "-----------------", _
            "-----------------", "------------------" )

        ' Convert strings, with and without an IFormatProvider.
        ConvertToSingle( "1234567", provider )
        ConvertToSingle( "1234.567", provider )
        ConvertToSingle( "1234,567", provider )
        ConvertToSingle( "12,345.67", provider )
        ConvertToSingle( "12.345,67", provider )
        ConvertToSingle( "1,234,567.89", provider )
        ConvertToSingle( "1.234.567,89", provider )
    End Sub 
End Module 

' This example of
'   Convert.ToSingle( String ) and
'   Convert.ToSingle( String, IFormatProvider )
' generates the following output when run in the [en-US] culture.
' 
' Several strings are converted to Single values, using
' default formatting and a NumberFormatInfo object.
' 
' String to convert     Default/exception   Provider/exception
' -----------------     -----------------   ------------------
' 1234567               1234567             1234567
' 1234.567              1234.567            1234567
' 1234,567              1234567             1234.567
' 12,345.67             12345.67            FormatException
' 12.345,67             FormatException     12345.67
' 1,234,567.89          1234568             FormatException
' 1.234.567,89          FormatException     1234568
'</Snippet3>