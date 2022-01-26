' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Globalization
Imports System.Threading

Module Example11
    Public Sub Main11()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR")
        Dim uri As String = "file:\\c:\users\username\Documents\bio.txt"
        If Not AccessesFileSystem(uri) Then
            ' Permit access to resource specified by URI
            Console.WriteLine("Access is allowed.")
        Else
            ' Prohibit access.
            Console.WriteLine("Access is not allowed.")
        End If
    End Sub

    Private Function AccessesFileSystem(uri As String) As Boolean
        Return uri.StartsWith("FILE", StringComparison.OrdinalIgnoreCase)
    End Function
End Module
' The example displays the following output:
'       Access is not allowed.
' </Snippet13>
