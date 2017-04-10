Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization

Namespace Microsoft.ServiceModel.Samples
	<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single, AddressFilterMode := AddressFilterMode.Prefix)> _
	Friend Class MessageBasedCustomerService
		Implements IUniversalContract
		Private customerList As Dictionary(Of String, Customer)
		Private nextId As Integer

		Private Sub New()
			customerList = New Dictionary(Of String, Customer)()
			' Default customer
			Dim customer As New Customer()
			customer.Name = "Bob"
			customer.Address = "100 Main Street"
			customerList.Add("1", customer)

			nextId = 1
		End Sub

		#Region "IUniversalContract Members"
		' <snippet0>
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
		' </snippet0>

		#End Region

		Private Function GetCustomer(ByVal message As Message) As Message
			Dim response As Message = Nothing

			Dim requestProperties As HttpRequestMessageProperty = TryCast(message.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
			Dim responseProperties As New HttpResponseMessageProperty()

			Dim customer As Customer = Nothing
            Console.WriteLine("Received GET for ", message.Properties.Via)

			Dim endpointUri As Uri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri
			Dim id As String = CustomerIdFromRequestUri(message.Properties.Via, endpointUri)

			If id IsNot Nothing Then
				customerList.TryGetValue(id, customer)
			Else
				'No customer was specified, so return the contents of the collection as links
				Dim links As New List(Of Uri)()

                For Each customerId In Me.customerList.Keys
                    links.Add(New Uri(endpointUri.ToString() & "/" & customerId))
                Next customerId

				responseProperties.StatusCode = HttpStatusCode.OK
				response = Message.CreateMessage(message.Version, message.Headers.Action, links)
				response.Properties(HttpResponseMessageProperty.Name) = responseProperties
				Return response
			End If

			If customer Is Nothing Then
				responseProperties.StatusCode = HttpStatusCode.NotFound
				response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty)
			Else
				responseProperties.StatusCode = HttpStatusCode.OK
				response = Message.CreateMessage(message.Version, message.Headers.Action, customer)
			End If

			response.Properties(HttpResponseMessageProperty.Name) = responseProperties

			Return response
		End Function

		Private Function UpdateCustomer(ByVal message As Message) As Message
			Dim response As Message = Nothing

			Dim requestProperties As HttpRequestMessageProperty = TryCast(message.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
			Dim responseProperties As New HttpResponseMessageProperty()

			Dim endpointUri As Uri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri
			Dim id As String = CustomerIdFromRequestUri(message.Properties.Via, endpointUri)

			Console.WriteLine("Received " & requestProperties.Method & " for Customer.")
			Dim customer As Customer = message.GetBody(Of Customer)()
			Console.WriteLine(Constants.vbTab & "Customer Data - Name: " & customer.Name & " Address: " & customer.Address)

			If customer IsNot Nothing Then
				If (Not customerList.ContainsKey(id)) Then
					responseProperties.StatusCode = HttpStatusCode.NotFound
				Else
					customerList(id) = customer
					responseProperties.StatusCode = HttpStatusCode.OK
				End If
			Else
				responseProperties.StatusCode = HttpStatusCode.BadRequest
			End If

			responseProperties.SuppressEntityBody = True
			response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty)
			response.Properties(HttpResponseMessageProperty.Name) = responseProperties

			Return response
		End Function

		Private Function AddCustomer(ByVal message As Message) As Message
			Dim response As Message = Nothing
			Dim requestProperties As HttpRequestMessageProperty = TryCast(message.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)

			Dim responseProperties As New HttpResponseMessageProperty()

			Console.WriteLine("Received " & requestProperties.Method & " for Customer.")
			Dim customer As Customer = message.GetBody(Of Customer)()

			Console.WriteLine(Constants.vbTab & "Customer Data - Name: " & customer.Name & " Address: " & customer.Address)
			If customer IsNot Nothing Then
				Me.nextId += 1
				Me.customerList(nextId.ToString()) = customer

				Dim collectionUri As Uri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri
				responseProperties.StatusCode = HttpStatusCode.Created
				responseProperties.Headers(HttpResponseHeader.Location) = New Uri(collectionUri, Me.nextId.ToString()).ToString()
			Else
				responseProperties.StatusCode = HttpStatusCode.BadRequest
			End If

			responseProperties.SuppressEntityBody = True
			response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty)
			response.Properties(HttpResponseMessageProperty.Name) = responseProperties

			Return response

		End Function

		Private Function DeleteCustomer(ByVal message As Message) As Message
			Dim response As Message = Nothing
			Dim requestProperties As HttpRequestMessageProperty = TryCast(message.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)

			Dim responseProperties As New HttpResponseMessageProperty()

			Console.WriteLine("Received DELETE for Customer")

			Dim endpointUri As Uri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri
			Dim id As String = CustomerIdFromRequestUri(message.Properties.Via, endpointUri)

			If customerList.ContainsKey(id) Then
				customerList.Remove(id)
				responseProperties.StatusCode = HttpStatusCode.OK
				responseProperties.SuppressEntityBody = True
			Else
				responseProperties.StatusCode = HttpStatusCode.NotFound
				responseProperties.SuppressEntityBody = True
			End If

			responseProperties.SuppressEntityBody = True
			response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty)
			response.Properties(HttpResponseMessageProperty.Name) = responseProperties

			Return response
		End Function

		Private Function CustomerIdFromRequestUri(ByVal via As Uri, ByVal endpoint As Uri) As String
			Dim customerNameSegmentIndex As Integer = endpoint.Segments.Length
			Return If((customerNameSegmentIndex < via.Segments.Length), via.Segments(customerNameSegmentIndex), Nothing)
		End Function
	End Class
End Namespace
