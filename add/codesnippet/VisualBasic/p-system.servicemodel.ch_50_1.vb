		Public Function ProcessMessage(ByVal request As Message) As Message Implements IUniversalContract.ProcessMessage
			Dim response As Message = Nothing

			'The HTTP Method (e.g. GET) from the incoming HTTP request
			'can be found on the HttpRequestMessageProperty. The MessageProperty
			'is added by the HTTP Transport when the message is received.
			Dim requestProperties As HttpRequestMessageProperty = CType(request.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)

			'Here we dispatch to different internal implementation methods
			'based on the incoming HTTP verb.
			If requestProperties IsNot Nothing Then
				If String.Equals("GET", requestProperties.Method, StringComparison.OrdinalIgnoreCase) Then
					response = GetCustomer(request)
				ElseIf String.Equals("POST", requestProperties.Method, StringComparison.OrdinalIgnoreCase) Then
					response = UpdateCustomer(request)
				ElseIf String.Equals("PUT", requestProperties.Method, StringComparison.OrdinalIgnoreCase) Then
					response = AddCustomer(request)
				ElseIf String.Equals("DELETE", requestProperties.Method, StringComparison.OrdinalIgnoreCase) Then
					response = DeleteCustomer(request)
				Else
					'This service doesn't implement handlers for other HTTP verbs (such as HEAD), so we
					'construct a response message and use the HttpResponseMessageProperty to
					'set the HTTP status code to 405 (Method Not Allowed) which indicates the client 
					'used an HTTP verb not supported by the server.
					response = Message.CreateMessage(MessageVersion.None, String.Empty, String.Empty)

					Dim responseProperty As New HttpResponseMessageProperty()
					responseProperty.StatusCode = HttpStatusCode.MethodNotAllowed

					response.Properties.Add(HttpResponseMessageProperty.Name, responseProperty)
				End If
			Else
				Throw New InvalidOperationException("This service requires the HTTP transport")
			End If

			Return response
		End Function