' <snippet1> 
Imports System
Imports System.Collections.Concurrent
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading.Tasks

' Demonstrates how to use Task<TResult>.FromResult to create a task 
' that holds a pre-computed result.
Friend Class CachedDownloads
   ' Holds the results of download operations.
   Private Shared cachedDownloads As New ConcurrentDictionary(Of String, String)()

   ' Asynchronously downloads the requested resource as a string.
   Public Shared Function DownloadStringAsync(ByVal address As String) As Task(Of String)
      ' First try to retrieve the content from cache.
      Dim content As String
      If cachedDownloads.TryGetValue(address, content) Then
         Return Task.FromResult(Of String)(content)
      End If

      ' If the result was not in the cache, download the 
      ' string and add it to the cache.
      Return Task.Run(async Function()
          content = await New WebClient().DownloadStringTaskAsync(address)
          cachedDownloads.TryAdd(address, content)
          Return content
      End Function)
   End Function

   Shared Sub Main(ByVal args() As String)
      ' The URLs to download.
      Dim urls() As String = { "http://msdn.microsoft.com", "http://www.contoso.com", "http://www.microsoft.com" }

      ' Used to time download operations.
      Dim stopwatch As New Stopwatch()

      ' Compute the time required to download the URLs.
      stopwatch.Start()
      Dim downloads = From url In urls _
                      Select DownloadStringAsync(url)
      Task.WhenAll(downloads).ContinueWith(Sub(results)
         ' Print the number of characters download and the elapsed time.
          stopwatch.Stop()
          Console.WriteLine("Retrieved {0} characters. Elapsed time was {1} ms.", results.Result.Sum(Function(result) result.Length), stopwatch.ElapsedMilliseconds)
      End Sub).Wait()

      ' Perform the same operation a second time. The time required
      ' should be shorter because the results are held in the cache.
      stopwatch.Restart()
      downloads = From url In urls _
                  Select DownloadStringAsync(url)
      Task.WhenAll(downloads).ContinueWith(Sub(results)
         ' Print the number of characters download and the elapsed time.
          stopwatch.Stop()
          Console.WriteLine("Retrieved {0} characters. Elapsed time was {1} ms.", results.Result.Sum(Function(result) result.Length), stopwatch.ElapsedMilliseconds)
      End Sub).Wait()
   End Sub
End Class

' Sample output:
'Retrieved 27798 characters. Elapsed time was 1045 ms.
'Retrieved 27798 characters. Elapsed time was 0 ms.
'
' </snippet1>
