' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example6
    Public Sub Main()
        Dim result As String = String.Empty
        For ctr As Integer = &H10107 To &H10110     ' Range of Aegean numbers.
            result += Char.ConvertFromUtf32(ctr)
        Next
        Dim si As New StringInfo(result)
        Console.WriteLine("The string contains {0} characters.", si.LengthInTextElements)
    End Sub
End Module
' The example displays the following output:
'       The string contains 10 characters.
' </Snippet4>
