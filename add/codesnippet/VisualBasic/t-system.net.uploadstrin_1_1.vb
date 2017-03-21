		Public Shared Sub UploadStringInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim data As String = "Time = 12:00am temperature = 50"
			AddHandler client.UploadStringCompleted, AddressOf UploadStringCallback2
                        Dim uri as Uri = New Uri(address)
			client.UploadStringAsync(uri, data)
		End Sub
