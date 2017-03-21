		Public Shared Sub PostString(ByVal address As String)

			Dim data As String = "Time = 12:00am temperature = 50"
			Dim method As String = "POST"
			Dim client As WebClient = New WebClient()
			Dim reply As String = client.UploadString(address, method, data)

			Console.WriteLine(reply)
		End Sub
