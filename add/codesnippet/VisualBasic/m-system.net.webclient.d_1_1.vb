		Public Shared Sub DownloadString(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim reply As String = client.DownloadString(address)

			Console.WriteLine(reply)
		End Sub

