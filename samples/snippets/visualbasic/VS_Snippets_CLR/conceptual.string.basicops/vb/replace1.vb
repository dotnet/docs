' Visual Basic .NET Document
Option Strict On

' <Snippet23>
Module Example
    Public Sub Main()
        Dim phrase As String = "a cold, dark night"
        Console.WriteLine("Before: {0}", phrase)
        phrase = phrase.Replace(",", "")
        Console.WriteLine("After: {0}", phrase)
    End Sub
End Module
' The example displays the following output:
'       Before: a cold, dark night
'       After: a cold dark night
' </Snippet23>
