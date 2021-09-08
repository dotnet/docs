Imports System.Collections.Concurrent
Imports System.Net.Http

Module Snippets
    Class DownloadCache
        Private Shared ReadOnly s_cachedDownloads As ConcurrentDictionary(Of String, String) =
            New ConcurrentDictionary(Of String, String)()
        Private Shared ReadOnly s_httpClient As HttpClient = New HttpClient()

        Public Function DownloadStringAsync(address As String) As Task(Of String)
            Dim content As String = Nothing

            If s_cachedDownloads.TryGetValue(address, content) Then
                Return Task.FromResult(Of String)(content)
            End If

            Return Task.Run(
                Async Function()
                    content = Await s_httpClient.GetStringAsync(address)
                    s_cachedDownloads.TryAdd(address, content)
                    Return content
                End Function)
        End Function
    End Class

    Public Sub StopAndLogElapsedTime(
            attemptNumber As Integer,
            stopwatch As Stopwatch,
            downloadTasks As Task(Of String()))

        stopwatch.Stop()

        Dim charCount As Integer = downloadTasks.Result.Sum(Function(result) result.Length)
        Dim elapsedMs As Long = stopwatch.ElapsedMilliseconds

        Console.WriteLine(
            $"Attempt number: {attemptNumber}{vbCrLf}" &
            $"Retrieved characters: {charCount:#,0}{vbCrLf}" &
            $"Elapsed retrieval time: {elapsedMs:#,0} milliseconds.{vbCrLf}")
    End Sub

    Sub Main()
        Dim cache As DownloadCache = New DownloadCache()
        Dim urls As String() = {
                "https://docs.microsoft.com/aspnet/core",
                "https://docs.microsoft.com/dotnet",
                "https://docs.microsoft.com/dotnet/architecture/dapr-for-net-developers",
                "https://docs.microsoft.com/dotnet/azure",
                "https://docs.microsoft.com/dotnet/desktop/wpf",
                "https://docs.microsoft.com/dotnet/devops/create-dotnet-github-action",
                "https://docs.microsoft.com/dotnet/machine-learning",
                "https://docs.microsoft.com/xamarin",
                "https://dotnet.microsoft.com/",
                "https://www.microsoft.com"
            }
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Dim downloads As IEnumerable(Of Task(Of String)) =
                urls.Select(AddressOf cache.DownloadStringAsync)
        Task.WhenAll(downloads).ContinueWith(
                Sub(downloadTasks)
                    StopAndLogElapsedTime(1, stopwatch, downloadTasks)
                End Sub).Wait()

        stopwatch.Restart()
        downloads = urls.Select(AddressOf cache.DownloadStringAsync)
        Task.WhenAll(downloads).ContinueWith(
                Sub(downloadTasks)
                    StopAndLogElapsedTime(2, stopwatch, downloadTasks)
                End Sub).Wait()
    End Sub
    ' Sample output:
    '     Attempt number 1
    '     Retrieved characters: 754,585
    '     Elapsed retrieval time: 2,857 milliseconds.
    '
    '     Attempt number 2
    '     Retrieved characters: 754,585
    '     Elapsed retrieval time: 1 milliseconds.
End Module
