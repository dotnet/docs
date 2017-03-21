		'  Sample call: UploadFileInBackground2("http:' www.contoso.com/fileUpload.aspx", "data.txt")
		Public Shared Sub UploadFileInBackground2(ByVal address As String, ByVal fileName As String)

			Dim client As WebClient = New WebClient()
                        Dim uri as Uri =  New Uri(address)
			AddHandler client.UploadFileCompleted, AddressOf UploadFileCallback2

			'  Specify a progress notification handler.
			AddHandler client.UploadProgressChanged, AddressOf UploadProgressCallback
			client.UploadFileAsync(uri, "POST", fileName)
			Console.WriteLine("File upload started.")
		End Sub
