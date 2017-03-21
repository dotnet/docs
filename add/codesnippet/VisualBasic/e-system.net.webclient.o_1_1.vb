		Public Shared Sub OpenResourceForWriting2(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the OpenWriteCallback method gets called
			'  when the writeable stream is available.
			AddHandler client.OpenWriteCompleted, AddressOf OpenWriteCallback2
                        Dim uri as Uri = New Uri(address)
			client.OpenWriteAsync(uri, "POST")
			'  Applications can perform other tasks
			'  while waiting for the upload to complete.
		End Sub
