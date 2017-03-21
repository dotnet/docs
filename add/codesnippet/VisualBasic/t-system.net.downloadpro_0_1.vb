		'  Sample call : DownLoadFileInBackground2 ("http:' www.contoso.com/logs/January.txt")
		Public Shared Sub DownLoadFileInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadFileCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCallback2
			'  Specify a progress notification handler.
			AddHandler client.DownloadProgressChanged, AddressOf DownloadProgressCallback
                        Dim uri as Uri = New Uri(address)
			client.DownloadFileAsync(uri, "serverdata.txt")
		End Sub
