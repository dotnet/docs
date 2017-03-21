		Public Sub ProcessMessage(ByVal input As Message) Implements IUntypedService.ProcessMessage
			Try
				Console.WriteLine("ProcessMessage: Message received: " & input.GetBody(Of String)())
                Dim reqProp = CType(input.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
                Dim customString = reqProp.Headers.Get("CustomHeader")
                Dim userAgent = reqProp.Headers(HttpRequestHeader.UserAgent)
				Console.WriteLine()
				Console.WriteLine("ProcessMessage: Got custom header: {0}, User-Agent: {1}", customString, userAgent)
			Catch e As Exception
				Console.WriteLine("ProcessMessage: got exception: " & e.ToString())
			End Try
		End Sub