'<Snippet1>
Imports System.Runtime.Caching
Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cache As ObjectCache = MemoryCache.Default

        Dim fileContents As CacheItem = cache.GetCacheItem("filecontents")

        If fileContents Is Nothing Then
            Dim policy As New CacheItemPolicy()

            Dim filePaths As New List(Of String)()

            Dim CachedFilePaths As String = Server.MapPath("~") & "\cacheText.txt"

                filePaths.Add(CachedFilePaths)

            policy.ChangeMonitors.Add(New HostFileChangeMonitor(filePaths))

            ' Fetch the file contents 
            Dim fileData As String = File.ReadAllText(CachedFilePaths)

            fileContents = New CacheItem("filecontents", fileData)

            cache.Set(fileContents, policy)
        End If
        Label1.Text = TryCast(fileContents.Value, String)
    End Sub
End Class
'</Snippet1>