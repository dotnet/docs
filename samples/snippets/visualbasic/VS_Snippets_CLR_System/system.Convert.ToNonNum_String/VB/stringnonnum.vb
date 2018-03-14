'<Snippet2>
Imports System.Globalization

Public Class DummyProvider
    Implements IFormatProvider

    ' Normally, GetFormat returns an object of the requested type
    ' (usually itself) if it is able; otherwise, it returns Nothing. 
    Public Function GetFormat( argType As Type ) As Object _
        Implements IFormatProvider.GetFormat

        ' Here, GetFormat displays the name of argType, after removing 
        ' the namespace information. GetFormat always returns Nothing.
        Dim argStr  As String = argType.ToString( )
        If argStr = "" Then argStr = "Empty"
        argStr = argStr.Substring( argStr.LastIndexOf( "."c ) + 1 )

        Console.Write( "{0,-20}", argStr )
        Return Nothing

    End Function 
End Class

Module ConvertNonNumericProviderDemo

    Sub Main( )

        ' Create an instance of IFormatProvider.
        Dim provider    As New DummyProvider( )
        Dim format      As String   = "{0,-17}{1,-17}{2}"

        ' Convert these values using DummyProvider.
        Dim Int32A      As String   = "-252645135"   
        Dim DoubleA     As String   = "61680.3855"
        Dim DayTimeA    As String   = "2001/9/11 13:45"

        Dim BoolA       As String   = "True"
        Dim StringA     As String   = "Qwerty"
        Dim CharA       As String   = "$"

        Console.WriteLine( "This example of selected " & _
            "Convert.To<Type>( String, IFormatProvider ) " & vbCrLf & _
            "methods generates the following output. The example " & _
            "displays the " & vbCrLf & "provider type if the " & _
            "IFormatProvider is called." )
        Console.WriteLine( vbCrLf & _
            "Note: For the ToBoolean, ToString, and ToChar " & _
            "methods, the " & vbCrLf & "IFormatProvider object " & _
            "is not referenced." )

        ' The format provider is called for the following conversions.
        Console.WriteLine( )
        Console.WriteLine( format, "ToInt32", Int32A, _
            Convert.ToInt32( Int32A, provider ) )
        Console.WriteLine( format, "ToDouble", DoubleA, _
            Convert.ToDouble( DoubleA, provider ) )
        Console.WriteLine( format, "ToDateTime", DayTimeA, _
            Convert.ToDateTime( DayTimeA, provider ) )

        ' The format provider is not called for these conversions.
        Console.WriteLine( )
        Console.WriteLine( format, "ToBoolean", BoolA, _
            Convert.ToBoolean( BoolA, provider ) )
        Console.WriteLine( format, "ToString", StringA, _
            Convert.ToString( StringA, provider ) )
        Console.WriteLine( format, "ToChar", CharA, _
            Convert.ToChar( CharA, provider ) )

    End Sub
End Module

' This example of selected Convert.To<Type>( String, IFormatProvider )
' methods generates the following output. The example displays the
' provider type if the IFormatProvider is called.
'
' Note: For the ToBoolean, ToString, and ToChar methods, the
' IFormatProvider object is not referenced.
' 
' NumberFormatInfo    ToInt32          -252645135       -252645135
' NumberFormatInfo    ToDouble         61680.3855       61680.3855
' DateTimeFormatInfo  ToDateTime       2001/9/11 13:45  9/11/2001 1:45:00 PM
' 
' ToBoolean        True             True
' ToString         Qwerty           Qwerty
' ToChar           $                $
'</Snippet2>
