' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Imports System.Globalization
Imports System.Threading

Module Example17
    Public Sub Main17()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL")
        Dim composite As String = ChrW(&H41) + ChrW(&H300)
        Console.WriteLine("Comparing using Char:   {0}", composite.IndexOf(ChrW(&HC0)))
        Console.WriteLine("Comparing using String: {0}", composite.IndexOf(ChrW(&HC0).ToString()))
    End Sub
End Module
' The example displays the following output:
'       Comparing using Char:   -1
'       Comparing using String: 0
' </Snippet18>
