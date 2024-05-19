' Visual Basic .NET Document
Option Strict On
Option Infer On

Imports System.IO
' <Snippet16>
Imports System.Text.RegularExpressions

Module Ecma1Example
    Public Sub Main()
        Dim values() As String = {"целый мир", "the whole world"}
        Dim pattern As String = "\b(\w+\s*)+"
        For Each value In values
            Console.Write("Canonical matching: ")
            If Regex.IsMatch(value, pattern) Then
                Console.WriteLine("'{0}' matches the pattern.", value)
            Else
                Console.WriteLine("{0} does not match the pattern.", value)
            End If

            Console.Write("ECMAScript matching: ")
            If Regex.IsMatch(value, pattern, RegexOptions.ECMAScript) Then
                Console.WriteLine("'{0}' matches the pattern.", value)
            Else
                Console.WriteLine("{0} does not match the pattern.", value)
            End If
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       Canonical matching: 'целый мир' matches the pattern.
'       ECMAScript matching: целый мир does not match the pattern.
'       
'       Canonical matching: 'the whole world' matches the pattern.
'       ECMAScript matching: 'the whole world' matches the pattern.
' </Snippet16>
