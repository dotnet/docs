Imports System
Imports System.ComponentModel

Module Module1
    Sub Main()
	'<snippet1>
        Dim myEx As New WarningException("This is a warning")
        Console.WriteLine(myEx.Message)
        Console.WriteLine(myEx.ToString())
	'</snippet1>
    End Sub

End Module
