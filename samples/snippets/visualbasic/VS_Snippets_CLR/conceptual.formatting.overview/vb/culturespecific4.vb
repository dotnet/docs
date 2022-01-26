' Visual Basic .NET Document
Option Strict On

' <Snippet20>
Imports System.Globalization

Module Example7
    Public Sub Main7()
        Dim value As Double = 1043.62957
        Dim cultureNames() As String = {"en-US", "en-GB", "ru", "fr"}

        For Each name In cultureNames
            Dim nfi As NumberFormatInfo = CultureInfo.CreateSpecificCulture(name).NumberFormat
            Console.WriteLine("{0,-6} {1}", name + ":", value.ToString("N3", nfi))
        Next
    End Sub
End Module
' The example displays the following output:
'       en-US: 1,043.630
'       en-GB: 1,043.630
'       ru:    1 043,630
'       fr:    1 043,630
' </Snippet20>

