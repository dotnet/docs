		'  Sample call : DownloadStringInBackground2 ("http:' www.contoso.com/GameScores.html")
		Public Shared Sub DownloadStringInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadStringCallback2 method gets called
			'  when the download completes.
			AddHandler client.DownloadStringCompleted, AddressOf DownloadStringCallback2
                        Dim uri as Uri = New Uri(address)
			client.DownloadStringAsync(uri)
		End Sub
