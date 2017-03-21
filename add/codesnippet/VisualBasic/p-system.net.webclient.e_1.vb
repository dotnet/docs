		Public Shared Sub UploadString(ByVal address As String)

			Dim data As String = "Time = 12:00am temperature = 50"
			Dim client As WebClient = New WebClient()
			'  Optionally specify an encoding for uploading and downloading strings.
			client.Encoding = System.Text.Encoding.UTF8
			'  Upload the data.
			Dim reply As String = client.UploadString(address, data)
			'  Disply the server's response.
			Console.WriteLine(reply)
		End Sub
