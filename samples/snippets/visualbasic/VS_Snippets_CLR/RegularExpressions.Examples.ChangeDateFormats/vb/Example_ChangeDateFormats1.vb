' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Text.RegularExpressions

Module DateFormatReplacement
    Public Sub Main()
        Dim dateString As String = Date.Today.ToString("d", _
                                             DateTimeFormatInfo.InvariantInfo)
        Dim resultString As String = MDYToDMY(dateString)
        Console.WriteLine("Converted {0} to {1}.", dateString, resultString)
    End Sub

    ' <Snippet1>
    Function MDYToDMY(input As String) As String
        Try
            Return Regex.Replace(input, _
                   "\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b", _
                   "${day}-${month}-${year}", RegexOptions.None,
                   TimeSpan.FromMilliseconds(150))
        Catch e As RegexMatchTimeoutException
            Return input
        End Try
    End Function
    ' </Snippet1>
End Module
' The example displays the following output to the console if run on 8/21/2007:
'      Converted 08/21/2007 to 21-08-2007.
' </Snippet2>
