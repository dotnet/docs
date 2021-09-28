' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\{\d+(,-*\d+)*(\:\w{1,4}?)*\}(?x) # Looks for a composite format item."
        Dim input As String = "{0,-3:F}"
        Console.WriteLine("'{0}':", input)
        If Regex.IsMatch(input, pattern) Then
            Console.WriteLine("   contains a composite format item.")
        Else
            Console.WriteLine("   does not contain a composite format item.")
        End If
    End Sub
End Module
' The example displays the following output:
'       '{0,-3:F}':
'          contains a composite format item.
' </Snippet3>
