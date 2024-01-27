' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example3
    Public Sub Main()
        Dim culture As CultureInfo = CultureInfo.InvariantCulture
        Dim provider As IFormatProvider = culture

        Dim dt As DateTimeFormatInfo = CType(provider, DateTimeFormatInfo)
    End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.InvalidCastException: 
'       Unable to cast object of type 'System.Globalization.CultureInfo' to 
'           type 'System.Globalization.DateTimeFormatInfo'.
'       at Example.Main()
' </Snippet3>
