' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.Globalization

Module Example5
    Public Sub Main5()
        Dim dat1 As Date = #5/28/2012 11:30AM#
        Dim cultureNames() As String = {"en-US", "en-GB", "ru", "fr"}

        For Each name In cultureNames
            Dim dtfi As DateTimeFormatInfo = CultureInfo.CreateSpecificCulture(name).DateTimeFormat
            Console.WriteLine($"{name}: {dat1.ToString(dtfi)}")
        Next
    End Sub
End Module
' The example displays the following output:
'       en-US: 5/28/2012 11:30:00 AM
'       en-GB: 28/05/2012 11:30:00
'       ru: 28.05.2012 11:30:00
'       fr: 28/05/2012 11:30:00
' </Snippet18>

