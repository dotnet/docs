Imports System.Net.Http

Module Program
    Sub Main()
        MainAsync().GetAwaiter().GetResult()
    End Sub

    Async Function MainAsync() As Task
        Console.WriteLine($"learn.microsoft.com/dotnet content length = {Await AccessWeb.Example.GetUrlContentLengthAsync()}")
    End Function
End Module

Class AccessWeb
    Public Shared Example As New AccessWeb()

    ' <ControlFlow>
    Public Async Function GetUrlContentLengthAsync() As Task(Of Integer)
        Using client As New HttpClient()

            Dim getStringTask As Task(Of String) =
                client.GetStringAsync("https://learn.microsoft.com/dotnet")

            DoIndependentWork()

            Dim contents As String = Await getStringTask

            Return contents.Length
        End Using
    End Function

    Sub DoIndependentWork()
        Console.WriteLine("Working...")
    End Sub
    ' </ControlFlow>
End Class