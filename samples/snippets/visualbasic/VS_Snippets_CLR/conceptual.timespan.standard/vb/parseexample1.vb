' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
    Public Sub Main()
        Dim value As String = "1.03:14:56.1667"
        Dim interval As TimeSpan
        Try
            interval = TimeSpan.ParseExact(value, "c", Nothing)
            Console.WriteLine("Converted '{0}' to {1}", value, interval)
        Catch e As FormatException
            Console.WriteLine("{0}: Bad Format", value)
        Catch e As OverflowException
            Console.WriteLine("{0}: Out of Range", value)
        End Try

        If TimeSpan.TryParseExact(value, "c", Nothing, interval) Then
            Console.WriteLine("Converted '{0}' to {1}", value, interval)
        Else
            Console.WriteLine("Unable to convert {0} to a time interval.",
                              value)
        End If
    End Sub
End Module
' The example displays the following output:
'       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
'       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
' </Snippet3>
