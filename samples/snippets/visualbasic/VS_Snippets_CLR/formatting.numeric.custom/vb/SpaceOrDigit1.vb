' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Module SpaceExample
    Public Sub Main()
        Dim value As Double = 0.324
        Console.WriteLine("The value is: '{0,5:#.###}'", value)
    End Sub
End Module

' The example displays the following output if the current culture
' is en-US:
'      The value is: ' .324'
' </Snippet12>
