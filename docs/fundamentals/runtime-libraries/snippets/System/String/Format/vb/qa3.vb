' Visual Basic .NET Document
Option Strict On

Module Example11
    Public Sub Main()
        WillThrow()
        Console.WriteLine()
        WontThrow()
        Console.WriteLine()
        Recommended()
    End Sub

    Public Sub WillThrow()
        Dim result As String
        Dim nOpen As Integer = 1
        Dim nClose As Integer = 2
        Try
            ' <Snippet23>
            result = String.Format("The text has {0} '{' characters and {1} '}' characters.",
                             nOpen, nClose)
            ' </Snippet23>
            Console.WriteLine(result)
        Catch e As FormatException
            Console.WriteLine("FormatException")
        End Try
    End Sub

    Public Sub WontThrow()
        Dim result As String
        Dim nOpen As Integer = 1
        Dim nClose As Integer = 2
        Try
            ' <Snippet24>
            result = String.Format("The text has {0} '{{' characters and {1} '}}' characters.",
                             nOpen, nClose)
            ' </Snippet24>
            Console.WriteLine(result)
        Catch e As FormatException
            Console.WriteLine("FormatException")
        End Try
    End Sub

    Public Sub Recommended()
        Dim result As String
        Dim nOpen As Integer = 1
        Dim nClose As Integer = 2
        Try
            ' <Snippet25>
            result = String.Format("The text has {0} '{1}' characters and {2} '{3}' characters.",
                             nOpen, "{", nClose, "}")
            ' </Snippet25>
            Console.WriteLine(result)
        Catch e As FormatException
            Console.WriteLine("FormatException")
        End Try
    End Sub
End Module

