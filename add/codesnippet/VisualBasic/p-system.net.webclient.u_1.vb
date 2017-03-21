		'  Sample call: UploadFileInBackground3("http:' www.contoso.com/fileUpload.aspx", "data.txt")
		Public Shared Sub UploadFileInBackground3(ByVal address As String, ByVal fileName As String)

			Dim client As WebClient = New WebClient()
                        Dim uri as Uri =  New Uri(address)
			client.UseDefaultCredentials = True
			AddHandler client.UploadFileCompleted, AddressOf UploadFileCallback2
			client.UploadFileAsync(uri, fileName)
			Console.WriteLine("File upload started.")
		End Sub
