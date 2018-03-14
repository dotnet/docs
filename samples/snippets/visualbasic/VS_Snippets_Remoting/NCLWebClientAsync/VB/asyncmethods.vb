imports System
imports System.Net
imports System.IO
imports System.Text
imports System.ComponentModel
'  NCLWebClientAsync
Namespace Examples.WebClientSnippets

	Public Class Test

		' <Snippet1>
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

		' </Snippet1>
		' <Snippet2>
		Public Shared Sub PostString(ByVal address As String)

			Dim data As String = "Time = 12:00am temperature = 50"
			Dim method As String = "POST"
			Dim client As WebClient = New WebClient()
			Dim reply As String = client.UploadString(address, method, data)

			Console.WriteLine(reply)
		End Sub

		' </Snippet2>
		' <Snippet3>
		'  Sample call: UploadFileInBackground3("http:' www.contoso.com/fileUpload.aspx", "data.txt")
		Public Shared Sub UploadFileInBackground3(ByVal address As String, ByVal fileName As String)

			' <Snippet43>
			Dim client As WebClient = New WebClient()
                        Dim uri as Uri =  New Uri(address)
			client.UseDefaultCredentials = True
			' </Snippet43>
			AddHandler client.UploadFileCompleted, AddressOf UploadFileCallback2
			client.UploadFileAsync(uri, fileName)
			Console.WriteLine("File upload started.")
		End Sub

		' </Snippet3>
		' <Snippet4>
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

		' </Snippet4>
		' <Snippet5>
        Private Shared Sub UploadFileCallback2(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs)

            Dim reply As String = System.Text.Encoding.UTF8.GetString(e.Result)
            Console.WriteLine(reply)
        End Sub

		' </Snippet5>
		' <Snippet6>
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

		' </Snippet6>
		' <Snippet7>
        Private Shared Sub UploadFileCallback(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)
            Try

                Dim reply As String = System.Text.Encoding.UTF8.GetString(e.Result)
                Console.WriteLine(reply)
            Finally
                '  If this thread throws an exception, make sure that
                '  you let the main application thread resume.
                waiter.Set()
            End Try
        End Sub

		' </Snippet7>
		' <Snippet8>
		Public Shared Sub UploadStringInBackground(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()
			Dim data As String = "Time = 12:00am temperature = 50"
			Dim method As String = "POST"
                         Dim uri as Uri =  New Uri(address)
			AddHandler client.UploadStringCompleted, AddressOf UploadStringCallback
			client.UploadStringAsync(uri, method, data, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the upload to complete.
			waiter.WaitOne()
			Console.WriteLine("String upload is complete.")
		End Sub

		' </Snippet8>
		' <Snippet9>
        Private Shared Sub UploadStringCallback(ByVal sender As Object, ByVal e As UploadStringCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)

            Try

                Dim reply As String = CStr(e.Result)

                Console.WriteLine(reply)

            Finally

                '  If this thread throws an exception, make sure that
                '  you let the main application thread resume.
                waiter.Set()
            End Try
        End Sub

		' </Snippet9>
		' <Snippet10>
		Public Shared Sub OpenResourceForReading(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()
                        Dim uri as Uri = New Uri(address)
			AddHandler client.OpenReadCompleted, AddressOf OpenReadCallback
			client.OpenReadAsync(uri, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the upload to complete.
			waiter.WaitOne()
		End Sub

		' </Snippet10>
		' <Snippet11>
        Private Shared Sub OpenReadCallback(ByVal sender As Object, ByVal e As OpenReadCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)
            Dim reply As Stream = Nothing
            Dim s As StreamReader = Nothing

            Try
                reply = CType(e.Result, System.IO.Stream)
                s = New StreamReader(reply)
                Console.WriteLine(s.ReadToEnd())
            Finally
                If Not s Is Nothing Then
                    s.Close()
                End If

                If Not reply Is Nothing Then
                    reply.Close()
                End If

                '  If this thread throws an exception, make sure that
                '  you let the main application thread resume.
                waiter.Set()
            End Try
        End Sub

		' </Snippet11>
		' <Snippet12>
		Public Shared Sub OpenResourceForWriting(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()

			'  Specify that the OpenWriteCallback method gets called
			'  when the writeable stream is available.
			AddHandler client.OpenWriteCompleted, AddressOf OpenWriteCallback
                        Dim uri as Uri = New Uri(address)
			client.OpenWriteAsync(uri, "POST", waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the upload to complete.
			waiter.WaitOne()
		End Sub

		' </Snippet12>
		' <Snippet13>
        Private Shared Sub OpenWriteCallback(ByVal sender As Object, ByVal e As OpenWriteCompletedEventArgs)
            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)
            Dim body As Stream = Nothing
            Dim s As StreamWriter = Nothing

            Try

                body = CType(e.Result, System.IO.Stream)
                s = New StreamWriter(body)
                s.AutoFlush = True
                s.Write("This is content data to be sent to the server.")
            Finally

                If Not s Is Nothing Then

                    s.Close()
                End If

                If Not body Is Nothing Then

                    body.Close()
                End If

                '  If this thread throws an exception, make sure that
                '  you let the main application thread resume.
                waiter.Set()
            End Try
        End Sub

		' </Snippet13>
		' <Snippet14>
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

		' </Snippet14>
		' <Snippet15>
        Private Shared Sub OpenWriteCallback2(ByVal sender As Object, ByVal e As OpenWriteCompletedEventArgs)

            Dim body As Stream = Nothing
            Dim s As StreamWriter = Nothing

            Try

                body = CType(e.Result, Stream)
                s = New StreamWriter(body)
                s.AutoFlush = True
                s.Write("This is content data to be sent to the server.")
            Finally

                If Not s Is Nothing Then

                    s.Close()
                End If

                If Not body Is Nothing Then

                    body.Close()
                End If
            End Try
        End Sub

		' </Snippet15>
		' <Snippet16>
		Public Shared Sub OpenResourceForPosting(ByVal address As String)

			Dim client As WebClient = New WebClient()
			'  Specify that the OpenWriteCallback method gets called
			'  when the writeable stream is available.
			AddHandler client.OpenWriteCompleted, AddressOf OpenWriteCallback2
                        Dim uri as Uri = New Uri(address)
			client.OpenWriteAsync(uri)
			'  Applications can perform other tasks
			'  while waiting for the upload to complete.
		End Sub

		' </Snippet16>
		' <Snippet17>
		'  Sample call : DownLoadFileInBackground ("http:' www.contoso.com/logs/January.txt")
		Public Shared Sub DownLoadFileInBackground(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()
			'  Specify that the DownloadFileCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCallback
                        Dim uri as Uri = New Uri(address)
			client.DownloadFileAsync(uri, "serverdata.txt", waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the download to complete.
			waiter.WaitOne()
		End Sub

		' </Snippet17>
		' <Snippet18>
        Private Shared Sub DownloadFileCallback(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

            If e.Cancelled = True Then

                Console.WriteLine("File download cancelled.")
            End If

            If Not e.Error Is Nothing Then

                Console.WriteLine(e.Error.ToString())
            End If

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)

            '  Let the main application thread resume.
            waiter.Set()
        End Sub

		' </Snippet18>
		' <Snippet19>
		'  Sample call : DownLoadFileInBackground2 ("http:' www.contoso.com/logs/January.txt")
		Public Shared Sub DownLoadFileInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadFileCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCallback2
			'  Specify a progress notification handler.
			AddHandler client.DownloadProgressChanged, AddressOf DownloadProgressCallback
                        Dim uri as Uri = New Uri(address)
			client.DownloadFileAsync(uri, "serverdata.txt")
		End Sub

		' </Snippet19>
		' <Snippet20>
        Private Shared Sub DownloadFileCallback2(ByVal sender As Object, _
   ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
            If e.Cancelled = True Then
                Console.WriteLine("File download cancelled.")
            End If

            If Not e.Error Is Nothing Then
                Console.WriteLine(e.Error.ToString())
            End If
        End Sub

		' </Snippet20>
		' <Snippet21>
		'  Sample call : DownLoadDataInBackground ("http:' www.contoso.com/GameScores.html")
		Public Shared Sub DownloadDataInBackground(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadDataCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadDataCompleted, AddressOf DownloadDataCallback
                        Dim uri as Uri = New Uri(address)
			client.DownloadDataAsync(uri, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the download to complete.
			waiter.WaitOne()
		End Sub

		' </Snippet21>
		' <Snippet22>
        Private Shared Sub DownloadDataCallback(ByVal sender As Object, ByVal e As DownloadDataCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)

            Try

                '  If the request was not canceled and did not throw
                '  an exception, display the resource.
                If e.Cancelled = False AndAlso e.Error Is Nothing Then

                    Dim data() As Byte = CType(e.Result, Byte())
                    Dim textData As String = System.Text.Encoding.UTF8.GetString(data)

                    Console.WriteLine(textData)
                End If
            Finally

                '  Let the main application thread resume.
                waiter.Set()
            End Try
        End Sub

		' </Snippet22>
		' <Snippet23>
		'  Sample call : DownloadDataInBackground2 ("http:' www.contoso.com/GameScores.html")
		Public Shared Sub DownloadDataInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadDataCallback2 method gets called
			'  when the download completes.
			AddHandler client.DownloadDataCompleted, AddressOf DownloadDataCallback2
                        Dim uri as Uri = New Uri(address)
			client.DownloadDataAsync(uri)
		End Sub

		' </Snippet23>
		' <Snippet24>
        Private Shared Sub DownloadDataCallback2(ByVal sender As Object, ByVal e As DownloadDataCompletedEventArgs)

            '  If the request was not canceled and did not throw
            '  an exception, display the resource.
            If e.Cancelled = False AndAlso e.Error Is Nothing Then
                Dim data() As Byte = CType(e.Result, Byte())
                Dim textData As String = System.Text.Encoding.UTF8.GetString(data)
                Console.WriteLine(textData)
            End If
        End Sub

		' </Snippet24>
		' <Snippet25>
		Public Shared Sub DownloadString(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim reply As String = client.DownloadString(address)

			Console.WriteLine(reply)
		End Sub


		'  </Snippet25>
		' <Snippet26>
		'  Sample call : DownLoadStringInBackground ("http:' www.contoso.com/GameScores.html")
		Public Shared Sub DownloadStringInBackground(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadStringCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadStringCompleted, AddressOf DownloadStringCallback
                        Dim uri as Uri = New Uri(address)
			client.DownloadStringAsync(uri, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the download to complete.
			waiter.WaitOne()
		End Sub

		' </Snippet26>
		' <Snippet27>
        Private Shared Sub DownloadStringCallback(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)

            Try

                '  If the request was not canceled and did not throw
                '  an exception, display the resource.
                If e.Cancelled = False AndAlso e.Error Is Nothing Then

                    Dim textString As String = CStr(e.Result)
                    Console.WriteLine(textString)
                End If

            Finally

                '  Let the main application thread resume.
                waiter.Set()
            End Try
        End Sub

		' </Snippet27>
		' <Snippet28>
		'  Sample call : DownloadStringInBackground2 ("http:' www.contoso.com/GameScores.html")
		Public Shared Sub DownloadStringInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadStringCallback2 method gets called
			'  when the download completes.
			AddHandler client.DownloadStringCompleted, AddressOf DownloadStringCallback2
                        Dim uri as Uri = New Uri(address)
			client.DownloadStringAsync(uri)
		End Sub

		' </Snippet28>
		' <Snippet29>
        Private Shared Sub DownloadStringCallback2(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)

            '  If the request was not canceled and did not throw
            '  an exception, display the resource.
            If e.Cancelled = False AndAlso e.Error Is Nothing Then

                Dim textString As String = CStr(e.Result)
                Console.WriteLine(textString)
            End If
        End Sub

		' </Snippet29>
		' <Snippet30>
		Public Shared Sub OpenResourceForReading2(ByVal address As String)

			Dim client As WebClient = New WebClient()
			AddHandler client.OpenReadCompleted, AddressOf OpenReadCallback2
                        Dim uri as Uri = New Uri(address)
			client.OpenReadAsync(uri)                        
		End Sub

		' </Snippet30>
		' <Snippet31>
        Private Shared Sub OpenReadCallback2(ByVal sender As Object, ByVal e As OpenReadCompletedEventArgs)

            Dim reply As Stream = Nothing
            Dim s As StreamReader = Nothing

            Try

                reply = CType(e.Result, Stream)
                s = New StreamReader(reply)
                Console.WriteLine(s.ReadToEnd())
            Finally

                If Not s Is Nothing Then

                    s.Close()
                End If

                If Not reply Is Nothing Then

                    reply.Close()
                End If
            End Try
        End Sub

		' </Snippet31>
		' <Snippet32>
		Public Shared Sub UploadDataInBackground(ByVal address As String)

			Dim waiter As System.Threading.AutoResetEvent = New System.Threading.AutoResetEvent(False)
			Dim client As WebClient = New WebClient()
			Dim text As String = "Time = 12:00am temperature = 50"
			Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
			Dim method As String = "POST"

			AddHandler client.UploadDataCompleted, AddressOf UploadDataCallback
                        Dim uri as Uri = New Uri(address)
			client.UploadDataAsync(uri, method, data, waiter)

			'  Block the main application thread. Real applications
			'  can perform other tasks while waiting for the upload to complete.
			waiter.WaitOne()
			Console.WriteLine("Data upload is complete.")
		End Sub

		' </Snippet32>
		' <Snippet33>
        Private Shared Sub UploadDataCallback(ByVal sender As Object, ByVal e As UploadDataCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)
            Try
                Dim data() As Byte = CType(e.Result, Byte())
                Dim reply As String = System.Text.Encoding.UTF8.GetString(data)

                Console.WriteLine(reply)
            Finally

                '  If this thread throws an exception, make sure that
                '  you let the main application thread resume.
                waiter.Set()

            End Try
        End Sub

		' </Snippet33>
		' <Snippet34>
		Public Shared Sub UploadDataInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim text As String = "Time = 12:00am temperature = 50"
			Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
			Dim method As String = "POST"

			AddHandler client.UploadDataCompleted, AddressOf UploadDataCallback2
			Dim uri as Uri = New Uri(address)
                        client.UploadDataAsync(uri, method, data)
		End Sub

		' </Snippet34>
		' <Snippet35>
        Private Shared Sub UploadDataCallback2(ByVal sender As Object, ByVal e As UploadDataCompletedEventArgs)

            Dim data() As Byte = CType(e.Result, Byte())
            Dim reply As String = System.Text.Encoding.UTF8.GetString(data)

            Console.WriteLine(reply)
        End Sub

		' </Snippet35>
		' <Snippet36>
		Public Shared Sub UploadDataInBackground3(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim text As String = "Time = 12:00am temperature = 50"
			Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
			AddHandler client.UploadDataCompleted, AddressOf UploadDataCallback3
                        Dim uri as Uri = New Uri(address)
			client.UploadDataAsync(uri, data)
		End Sub

		' </Snippet36>
		' <Snippet37>
        Private Shared Sub UploadDataCallback3(ByVal sender As Object, ByVal e As UploadDataCompletedEventArgs)
            Dim data() As Byte = CType(e.Result, Byte())
            Dim reply As String = System.Text.Encoding.UTF8.GetString(data)
            Console.WriteLine(reply)
        End Sub

		' </Snippet37>

		' <Snippet38>
		Public Shared Sub UploadStringInBackground2(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim data As String = "Time = 12:00am temperature = 50"
			AddHandler client.UploadStringCompleted, AddressOf UploadStringCallback2
                        Dim uri as Uri = New Uri(address)
			client.UploadStringAsync(uri, data)
		End Sub

		' </Snippet38>
		' <Snippet39>
        Private Shared Sub UploadStringCallback2(ByVal sender As Object, ByVal e As UploadStringCompletedEventArgs)
            Dim reply As String = CStr(e.Result)
            Console.WriteLine(reply)
        End Sub
		' </Snippet39>

		' <Snippet40>
		Public Shared Sub UploadStringInBackground3(ByVal address As String)

			Dim client As WebClient = New WebClient()
			Dim data As String = "Time = 12:00am temperature = 50"
			Dim method As String = "POST"
			AddHandler client.UploadStringCompleted, AddressOf UploadStringCallback2
                        Dim uri as Uri = New Uri(address)										
			client.UploadStringAsync(uri, method, data)
		End Sub
		' </Snippet40>
		' <Snippet41>

		'  Sample call : DownLoadFileWithProgressNotify ("http:' www.contoso.com/logs/January.txt")
		Public Shared Sub DownLoadFileWithProgressNotify(ByVal address As String)

			Dim client As WebClient = New WebClient()

			'  Specify that the DownloadFileCallback method gets called
			'  when the download completes.
			AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCallback2
			'  Specify a progress notification handler.
			AddHandler client.DownloadProgressChanged, AddressOf DownloadProgressCallback

			'  The user token, shown here as ID 1234, is used to uniquely
			'  identify notification events raised for this data transfer operation.
                        Dim uri as Uri = New Uri(address)
			client.DownloadFileAsync(uri, "serverdata.txt", "ID 1234")
		End Sub
		' </Snippet41>
		' <Snippet42>
        Private Shared Sub UploadProgressCallback(ByVal sender As Object, ByVal e As UploadProgressChangedEventArgs)

            '  Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", _
             CStr(e.UserState), e.BytesSent, e.TotalBytesToSend, e.ProgressPercentage)
        End Sub
        Private Shared Sub DownloadProgressCallback(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

            '  Displays the operation identifier, and the transfer progress.
            Console.WriteLine("0}    downloaded 1} of 2} bytes. 3} % complete...", _
             CStr(e.UserState), e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage)
        End Sub
		' </Snippet42>
		'  nothing below this line appears in the docs.
		' [System.Security.Permissions.FileIOPermissionAttribute(System.Security.Permissions.SecurityAction.Deny, Write=@"c:\whidbeycode\ncl.xml")]

		Public Shared Sub Main(ByVal args() As String)

			'  OpenResourceForReading ("http:' google.com")
			' OpenResourceForReading2("http:' google.com")
			'   System.Threading.Thread.Sleep (10000)

			UploadDataInBackground2("http:// sharriso1/test/postaccepter.aspx")

			'  DownloadString ("http:' google.com")

			'		UploadDataInBackground("http:' sharriso1/test/postaccepter.aspx")

			'	System.Threading.Thread.Sleep(1000)
			'	UploadDataInBackground3("http:' sharriso1/test/postaccepter.aspx")
			'	System.Threading.Thread.Sleep(1000)

			'	UploadStringInBackground("http:' sharriso1/test/postaccepter.aspx")
			'	UploadStringInBackground2("http:' sharriso1/test/postaccepter.aspx")
			'	System.Threading.Thread.Sleep(1000)
			'	UploadStringInBackground3("http:' sharriso1/test/postaccepter.aspx")
			'	System.Threading.Thread.Sleep(1000)

			'  OpenResourceForWriting2("http:' sharriso1/test/postaccepter.aspx")
			'  DownloadDataInBackground ("http:' google.com")
			' System.Threading.Thread.Sleep (10000)
			'  DownloadString ("http:' google.com")
			'   DownloadStringInBackground ("http:' google.com")
			'   DownloadStringInBackground2 ("http:' google.com")
			'   System.Threading.Thread.Sleep (1000) 
			'   DownLoadFileInBackground2 ("http:' sharriso1/test/uploadedFiles/onesandtwos.txt")
			DownLoadFileWithProgressNotify("http:// sharriso1/test/uploadedFiles/onesandtwos.txt")
			' System.Threading.Thread.Sleep (10000)
			'  UploadString ()
			'    UploadStringInBackground ("http:' sharriso1/test/fileUploadercs.aspx")
			'    UploadFileInBackground2 ("http:' sharriso1/test/fileUploadercs.aspx", "onesandtwos.txt")

			'   UploadFileInBackground3 ("http:' sharriso1/test/fileUploadercs.aspx", "onesandtwos.txt")
			System.Threading.Thread.Sleep(1000)

		End Sub
	End Class
End Namespace
