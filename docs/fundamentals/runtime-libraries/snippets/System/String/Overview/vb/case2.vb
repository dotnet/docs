' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Imports System.Globalization
Imports System.Threading

Module Example2
    Const disallowed = "file"

    Public Sub Main()
        IsAccessAllowed("FILE:\\\c:\users\user001\documents\FinancialInfo.txt")
    End Sub

    Private Sub IsAccessAllowed(resource As String)
        Dim cultures() As CultureInfo = {CultureInfo.CreateSpecificCulture("en-US"),
                                        CultureInfo.CreateSpecificCulture("tr-TR")}
        Dim scheme As String = Nothing
        Dim index As Integer = resource.IndexOfAny({"\"c, "/"c})
        If index > 0 Then scheme = resource.Substring(0, index - 1)

        ' Change the current culture and perform the comparison.
        For Each culture In cultures
            Thread.CurrentThread.CurrentCulture = culture
            Console.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.DisplayName)
            Console.WriteLine(resource)
            Console.WriteLine("Access allowed: {0}",
                           Not String.Equals(disallowed, scheme, StringComparison.CurrentCultureIgnoreCase))
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       Culture: English (United States)
'       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
'       Access allowed: False
'       
'       Culture: Turkish (Turkey)
'       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
'       Access allowed: True
' </Snippet17>
