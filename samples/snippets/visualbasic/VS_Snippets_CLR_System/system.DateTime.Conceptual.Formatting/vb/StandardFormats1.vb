' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
    Public Sub Main()
        ShowDefaultFormat()
        UseSpecificCulture()
        UseSpecificFormattingInfo()
    End Sub

    Private Sub ShowDefaultFormat()
        ' <Snippet1>
        ' Display using current (en-us) culture's short date format
        Dim thisDate As Date = #03/15/2008#
        Console.WriteLine(thisDate.ToString("d"))     ' Displays 3/15/2008
        ' </Snippet1>
    End Sub

    Private Sub UseSpecificCulture()
        ' <Snippet2>
        ' Display using pt-BR culture's short date format
        Dim thisDate As Date = #03/15/2008#
        Dim culture As New CultureInfo("pt-BR")
        Console.WriteLine(thisDate.ToString("d", culture))   ' Displays 15/3/2008
        ' </Snippet2>
    End Sub

    Private Sub UseSpecificFormattingInfo()
        ' <Snippet3>
        ' Display using date format information from hr-HR culture
        Dim thisDate As Date = #03/15/2008#
        Dim fmt As DateTimeFormatInfo = (New CultureInfo("hr-HR")).DateTimeFormat
        Console.WriteLine(thisDate.ToString("d", fmt))   ' Displays 15.3.2008
        ' </Snippet3>
    End Sub
End Module

