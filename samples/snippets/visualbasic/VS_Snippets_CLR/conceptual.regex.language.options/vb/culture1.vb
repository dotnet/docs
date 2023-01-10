' Visual Basic .NET Document
Option Strict On

Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Threading

Module CultureExample
    Public Sub Main()
        ShowIllegalAccess()
        Console.WriteLine("-----")
        ShowNoAccess()
    End Sub

    Public Sub ShowIllegalAccess()
        ' <Snippet14>
        Dim defaultCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
        Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")

        Dim input As String = "file://c:/Documents.MyReport.doc"
        Dim pattern As String = "$FILE://"

        Console.WriteLine("Culture-sensitive matching ({0} culture)...",
                          Thread.CurrentThread.CurrentCulture.Name)
        If Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase) Then
            Console.WriteLine("URLs that access files are not allowed.")
        Else
            Console.WriteLine("Access to {0} is allowed.", input)
        End If

        Thread.CurrentThread.CurrentCulture = defaultCulture
        ' The example displays the following output:
        '       Culture-sensitive matching (tr-TR culture)...
        '       Access to file://c:/Documents.MyReport.doc is allowed.
        ' </Snippet14>
    End Sub

    Public Sub ShowNoAccess()
        ' <Snippet15>  
        Dim defaultCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
        Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")

        Dim input As String = "file://c:/Documents.MyReport.doc"
        Dim pattern As String = "$FILE://"

        Console.WriteLine("Culture-insensitive matching...")
        If Regex.IsMatch(input, pattern,
                       RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant) Then
            Console.WriteLine("URLs that access files are not allowed.")
        Else
            Console.WriteLine("Access to {0} is allowed.", input)
        End If
        Thread.CurrentThread.CurrentCulture = defaultCulture
        ' The example displays the following output:
        '        Culture-insensitive matching...
        '        URLs that access files are not allowed.
        ' </Snippet15>
    End Sub
End Module

