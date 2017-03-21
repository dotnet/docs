		'  Sample call : DownLoadDataInBackground ("http:' www.contoso.com/GameScores.html")
		Public Shared Sub DownloadDataInBackground(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadDataCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadDataCompleted, AddressOf DownloadDataCallback
                        Dim uri as Uri = New Uri(address)
			client.DownloadDataAsync(uri, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the download to complete.
			waiter.WaitOne()
		End Sub
