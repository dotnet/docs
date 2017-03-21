		'  Sample call: UploadFileInBackground("http:' www.contoso.com/fileUpload.aspx", "data.txt")
		Public Shared Sub UploadFileInBackground(ByVal address As String, ByVal fileName As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()
			Dim method As String = "POST"
                         Dim uri as Uri =  New Uri(address)

			'  Specify that that UploadFileCallback method gets called
			'  when the file upload completes.
			AddHandler client.UploadFileCompleted, AddressOf UploadFileCallback
			client.UploadFileAsync(uri, method, fileName, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the upload to complete.
			waiter.WaitOne()
			Console.WriteLine("File upload is complete.")
		End Sub
