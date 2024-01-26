' Visual Basic .NET Document
Option Strict On

Module Example2
    Public Sub Main()
        ShowFormattingCode()
        Console.WriteLine("---")
        ShowParsingCode()
    End Sub

    Private Sub ShowFormattingCode()
        ' <Snippet1>
        Dim interval As New TimeSpan(12, 30, 45)
        Dim output As String
        Try
            output = String.Format("{0:r}", interval)
        Catch e As FormatException
            output = "Invalid Format"
        End Try
        Console.WriteLine(output)
        ' Output from .NET Framework 3.5 and earlier versions:
        '       12:30:45
        ' Output from .NET Framework 4:
        '       Invalid Format
        ' </Snippet1>   
    End Sub

    Private Sub ShowParsingCode()
        Dim values() As String = {"000000006", "12.12:12:12.12345678"}
        For Each value As String In values
            Try
                Dim interval As TimeSpan = TimeSpan.Parse(value)
                Console.WriteLine("{0} --> {1}", value, interval)
            Catch e As FormatException
                Console.WriteLine("{0}: Bad Format", value)
            Catch e As OverflowException
                Console.WriteLine("{0}: Overflow", value)
            End Try
        Next
        ' Output from .NET Framework 3.5 and earlier versions:

        ' Output from .NET Framework 4:
        '       000000006: Overflow
    End Sub
End Module


