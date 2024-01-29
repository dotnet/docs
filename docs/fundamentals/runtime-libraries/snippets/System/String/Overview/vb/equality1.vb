' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Globalization
Imports System.Threading

Module Example7
    Public Sub Main()
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR")

        Dim filePath As String = "file://c:/notes.txt"

        Console.WriteLine("Culture-sensitive test for equality:")
        If Not TestForEquality(filePath, StringComparison.CurrentCultureIgnoreCase) Then
            Console.WriteLine("Access to {0} is allowed.", filePath)
        Else
            Console.WriteLine("Access to {0} is not allowed.", filePath)
        End If
        Console.WriteLine()

        Console.WriteLine("Ordinal test for equality:")
        If Not TestForEquality(filePath, StringComparison.OrdinalIgnoreCase) Then
            Console.WriteLine("Access to {0} is allowed.", filePath)
        Else
            Console.WriteLine("Access to {0} is not allowed.", filePath)
        End If
    End Sub

    Private Function TestForEquality(str As String, cmp As StringComparison) As Boolean
        Dim position As Integer = str.IndexOf("://")
        If position < 0 Then Return False

        Dim substring As String = str.Substring(0, position)
        Return substring.Equals("FILE", cmp)
    End Function
End Module
' The example displays the following output:
'       Culture-sensitive test for equality:
'       Access to file://c:/notes.txt is allowed.
'       
'       Ordinal test for equality:
'       Access to file://c:/notes.txt is not allowed.
' </Snippet11>

