Imports System.Runtime.CompilerServices

Module StringExtensions

    <Extension()> 
    Public Sub Print(ByVal aString As String)
        Console.WriteLine(aString)
    End Sub

End Module