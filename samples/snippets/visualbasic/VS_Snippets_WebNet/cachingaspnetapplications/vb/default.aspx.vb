'<Snippet1>
Imports System.Runtime.Caching
Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, _
            ByVal e As System.EventArgs) Handles Button1.Click
        Dim cache As ObjectCache = MemoryCache.Default
        Dim fileContents As String = TryCast(cache("filecontents"), _
            String)
        If fileContents Is Nothing Then
            Dim policy As New CacheItemPolicy()
            policy.AbsoluteExpiration = _
                DateTimeOffset.Now.AddSeconds(10.0)
            Dim filePaths As New List(Of String)()
            Dim cachedFilePath As String = Server.MapPath("~") & _
                "\cacheText.txt"
            filePaths.Add(cachedFilePath)
            policy.ChangeMonitors.Add(New  _
                HostFileChangeMonitor(filePaths))

            ' Fetch the file contents.
            fileContents = File.ReadAllText(cachedFilePath) & _
                vbCrLf & DateTime.Now.ToString()
            cache.Set("filecontents", fileContents, policy)
        End If
        Label1.Text = fileContents
    End Sub

End Class
'</Snippet1>