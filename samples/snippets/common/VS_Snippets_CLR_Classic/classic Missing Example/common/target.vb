' This source file is compiled by each of the language 
' examples, and then used to illustrate Missing.Value. 
'
' The code below is included in a PLAIN CODE BLOCK in the 
' description for the code example (without this comment,
' of course :-), so that users of any language can see it 
' and use VBC to compile it. It must be written in VB
' because that's the only .NET language that can create
' optional parameters in managed code.

Imports System

Public Class MissingSample
    
    Public Shared Sub MyMethod(Optional k As Integer = 33)
        Console.WriteLine("k = " & k.ToString())
    End Sub

End Class
