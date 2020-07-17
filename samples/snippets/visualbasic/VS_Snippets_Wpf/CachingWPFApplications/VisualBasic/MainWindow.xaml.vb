'<Snippet1>
Imports System.Runtime.Caching
Imports System.IO

Class MainWindow

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Dim cache As ObjectCache = MemoryCache.Default
        Dim fileContents As String = TryCast(cache("filecontents"), _
            String)

        If fileContents Is Nothing Then
            Dim policy As New CacheItemPolicy()
            policy.AbsoluteExpiration = _
                DateTimeOffset.Now.AddSeconds(10.0)
            Dim filePaths As New List(Of String)()
            filePaths.Add("c:\cache\cacheText.txt")
            policy.ChangeMonitors.Add(New  _
                HostFileChangeMonitor(filePaths))

            ' Fetch the file contents.
            fileContents = File.ReadAllText("c:\cache\cacheText.txt") & vbCrLf & DateTime.Now.ToString()
            cache.Set("filecontents", fileContents, policy)
        End If
        MessageBox.Show(fileContents)
    End Sub
End Class
'</Snippet1>