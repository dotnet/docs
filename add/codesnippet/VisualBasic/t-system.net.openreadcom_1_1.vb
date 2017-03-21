		Public Shared Sub OpenResourceForReading2(ByVal address As String)

			Dim client As WebClient = New WebClient()
			AddHandler client.OpenReadCompleted, AddressOf OpenReadCallback2
                        Dim uri as Uri = New Uri(address)
			client.OpenReadAsync(uri)                        
		End Sub
