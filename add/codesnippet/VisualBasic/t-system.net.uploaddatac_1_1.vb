		Public Shared Sub UploadDataInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim text As String = "Time = 12:00am temperature = 50"
			Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
			Dim method As String = "POST"

			AddHandler client.UploadDataCompleted, AddressOf UploadDataCallback2
			Dim uri as Uri = New Uri(address)
                        client.UploadDataAsync(uri, method, data)
		End Sub
