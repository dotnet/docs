'<Snippet1>
' Example of Convert.ToDateTime( String, IFormatProvider ).
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Module StringToDateTimeDemo

    Const lineFmt As String = "{0,-18}{1,-12}{2}"
    
    ' Get the exception type name; remove the namespace prefix.
    Function GetExceptionType( ex As Exception ) As String

        Dim exceptionType   As String = ex.GetType( ).ToString( )
        Return exceptionType.Substring( _
            exceptionType.LastIndexOf( "."c ) + 1 )
    End Function

    Sub StringToDateTime( cultureName As String )

        Dim dateStrings As String( ) = { "01/02/03", _
            "2001/02/03",  "01/2002/03", "01/02/2003", _
            "21/02/03",    "01/22/03",   "01/02/23" }
        Dim culture As CultureInfo = New CultureInfo( cultureName )
            
        Console.WriteLine( )

        ' Convert each string in the dateStrings array.
        Dim dateStr As String
        For Each dateStr In  dateStrings

            Dim dateTimeValue As DateTime

            ' Display the first part of the output line.
            Console.Write( lineFmt, dateStr, cultureName, Nothing )

            ' Convert the string to a DateTime object.
            Try
                dateTimeValue = _
                    Convert.ToDateTime( dateStr, culture )

                ' Display the DateTime object in a fixed format 
                ' if Convert succeeded.
                Console.WriteLine( "{0:yyyy-MMM-dd}", dateTimeValue )

            ' Display the exception type if Parse failed.
            Catch ex As Exception
                Console.WriteLine( "{0}", GetExceptionType( ex ) )
            End Try
        Next dateStr
    End Sub 
    
    Sub Main( )
        Console.WriteLine( "This example of " & _
            "Convert.ToDateTime( String, IFormatProvider ) " & _
            vbCrLf & "generates the following output. Several " & _
            "strings are converted " & vbCrLf & "to DateTime " & _
            "objects using formatting information from different " & _
            vbCrLf & "cultures, and then the strings are " & _
            "displayed in a " & vbCrLf & "culture-invariant form." & _
            vbCrLf )
        Console.WriteLine( lineFmt, "Date String", "Culture", _
            "DateTime or Exception" )
        Console.WriteLine( lineFmt, "-----------", "-------", _
            "---------------------" )

        StringToDateTime( "en-US" )
        StringToDateTime( "ru-RU" )
        StringToDateTime( "ja-JP" )
    End Sub 
End Module 

' This example of Convert.ToDateTime( String, IFormatProvider )
' generates the following output. Several strings are converted
' to DateTime objects using formatting information from different
' cultures, and then the strings are displayed in a
' culture-invariant form.
' 
' Date String       Culture     DateTime or Exception
' -----------       -------     ---------------------
' 
' 01/02/03          en-US       2003-Jan-02
' 2001/02/03        en-US       2001-Feb-03
' 01/2002/03        en-US       2002-Jan-03
' 01/02/2003        en-US       2003-Jan-02
' 21/02/03          en-US       FormatException
' 01/22/03          en-US       2003-Jan-22
' 01/02/23          en-US       2023-Jan-02
' 
' 01/02/03          ru-RU       2003-Feb-01
' 2001/02/03        ru-RU       2001-Feb-03
' 01/2002/03        ru-RU       2002-Jan-03
' 01/02/2003        ru-RU       2003-Feb-01
' 21/02/03          ru-RU       2003-Feb-21
' 01/22/03          ru-RU       FormatException
' 01/02/23          ru-RU       2023-Feb-01
' 
' 01/02/03          ja-JP       2001-Feb-03
' 2001/02/03        ja-JP       2001-Feb-03
' 01/2002/03        ja-JP       2002-Jan-03
' 01/02/2003        ja-JP       2003-Jan-02
' 21/02/03          ja-JP       2021-Feb-03
' 01/22/03          ja-JP       FormatException
' 01/02/23          ja-JP       2001-Feb-23
'</Snippet1>