' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
    Public Sub Main()
        Dim interval As New TimeSpan(12, 30, 45)
        Dim output As String
        Try
            output = String.Format("{0:r}", interval)
        Catch e As FormatException
            output = "Invalid Format"
        End Try
        Console.WriteLine(output)
    End Sub
End Module
' </Snippet1>
