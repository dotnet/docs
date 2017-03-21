		Public Shared Sub UploadDataInBackground3(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim text As String = "Time = 12:00am temperature = 50"
			Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
			AddHandler client.UploadDataCompleted, AddressOf UploadDataCallback3
                        Dim uri as Uri = New Uri(address)
			client.UploadDataAsync(uri, data)
		End Sub
