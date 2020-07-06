' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim fileUrl = "file"
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Console.WriteLine("Culture = {0}", _
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        Console.WriteLine("(file == FILE) = {0}", _
                         fileUrl.StartsWith("FILE", True, Nothing))
        Console.WriteLine()

        Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")
        Console.WriteLine("Culture = {0}", _
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        Console.WriteLine("(file == FILE) = {0}", _
                          fileUrl.StartsWith("FILE", True, Nothing))
    End Sub
End Module
' The example displays the following output:
'       Culture = English (United States)
'       (file == FILE) = True
'       
'       Culture = Turkish (Turkey)
'       (file == FILE) = False
' </Snippet11>

Public Class Example2
    ' <Snippet12>   
    Public Shared Function IsFileURI(path As String) As Boolean
        Return path.StartsWith("FILE:", True, Nothing)
    End Function
    ' </Snippet12>
End Class

Public Class Example3
    ' <Snippet13>
    Public Shared Function IsFileURI(path As String) As Boolean
        Return path.StartsWith("FILE:", StringComparison.OrdinalIgnoreCase)
    End Function
    ' </Snippet13>
End Class

Public Class Example4
    ' <Snippet14>
    Public Shared Function IsFileURI(path As String) As Boolean
        If (path.Length < 5) Then Return False

        Return String.Equals(path.Substring(0, 5), "FILE:", _
                             StringComparison.OrdinalIgnoreCase)
    End Function
    ' </Snippet14>
End Class
