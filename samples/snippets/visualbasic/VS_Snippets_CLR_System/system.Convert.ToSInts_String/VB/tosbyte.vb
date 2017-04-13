'<Snippet4>
' Example of the Convert.ToSByte( String ) and 
' Convert.ToSByte( String, IFormatProvider ) methods.
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module ToSByteProviderDemo

    Dim format As String = "{0,-20}{1,-20}{2}"

    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub ConvertToSByte( numericStr As String, _
        provider As IFormatProvider )

        Dim defaultValue    As Object
        Dim providerValue   As Object

        ' Convert numericStr to SByte without a format provider.
        Try
            defaultValue = Convert.ToSByte( numericStr )
        Catch ex As Exception
            defaultValue = GetExceptionType( ex )
        End Try

        ' Convert numericStr to SByte with a format provider.
        Try
            providerValue = Convert.ToSByte( numericStr, provider )
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
        provider.NumberNegativePattern = 0

        Console.WriteLine( "This example of" & vbCrLf & _
            "  Convert.ToSByte( String ) and " & vbCrLf & _
            "  Convert.ToSByte( String, IFormatProvider ) " & _
            vbCrLf & "generates the following output. It " & _
            "converts several strings to " & vbCrLf & "SByte " & _
            "values, using default formatting " & _
            "or a NumberFormatInfo object." & vbCrLf )
        Console.WriteLine( format, "String to convert", _
            "Default/exception", "Provider/exception" )
        Console.WriteLine( format, "-----------------", _
            "-----------------", "------------------" )

        ' Convert strings, with and without an IFormatProvider.
        ConvertToSByte( "123", provider )
        ConvertToSByte( "+123", provider )
        ConvertToSByte( "pos 123", provider )
        ConvertToSByte( "-123", provider )
        ConvertToSByte( "neg 123", provider )
        ConvertToSByte( "123.", provider )
        ConvertToSByte( "(123)", provider )
        ConvertToSByte( "128", provider )
        ConvertToSByte( "-129", provider )
    End Sub 
End Module 

' This example of
'   Convert.ToSByte( String ) and
'   Convert.ToSByte( String, IFormatProvider )
' generates the following output. It converts several strings to
' SByte values, using default formatting or a NumberFormatInfo object.
' 
' String to convert   Default/exception   Provider/exception
' -----------------   -----------------   ------------------
' 123                 123                 123
' +123                123                 FormatException
' pos 123             FormatException     123
' -123                -123                FormatException
' neg 123             FormatException     -123
' 123.                FormatException     FormatException
' (123)               FormatException     FormatException
' 128                 OverflowException   OverflowException
' -129                OverflowException   FormatException
'</Snippet4>