' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Resources

Module Example6
    Public Sub Main()
        Dim rm As New ResourceManager("Strings", GetType(Example6).Assembly)
        Dim timeString As String = rm.GetString("TimeHeader")
        Console.WriteLine("{0} {1:T}", timeString, Date.Now)
    End Sub
End Module
' The example displays output similar to the following:
'       The current time is 2:03:14 PM
' </Snippet1>
