		Private Shared Function BuildMessage() As Message
            Dim messageToSend As Message = Nothing
			Dim reqProps As New HttpRequestMessageProperty()
			reqProps.SuppressEntityBody = False
			reqProps.Headers.Add("CustomHeader", "Test Value")
			reqProps.Headers.Add(HttpRequestHeader.UserAgent, "my user agent")

			Try
				messageToSend = Message.CreateMessage(MessageVersion.Soap11, "http://tempuri.org/IUntypedService/ProcessMessage", "Hello WCF")
			Catch e As Exception
				Console.WriteLine("got exception when sending message: " & e.ToString())
			End Try

			messageToSend.Properties(HttpRequestMessageProperty.Name) = reqProps
			Return messageToSend
		End Function