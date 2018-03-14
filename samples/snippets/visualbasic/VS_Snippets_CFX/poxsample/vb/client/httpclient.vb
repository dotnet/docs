
Imports System
Imports System.Collections.Generic
Imports System.Net
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Text

Namespace Microsoft.ServiceModel.Samples
	Public Class HttpClient
		Inherits ClientBase(Of IRequestChannel)
		Public Sub New(ByVal baseUri As Uri, ByVal keepAliveEnabled As Boolean)
			Me.New(baseUri.ToString(), keepAliveEnabled)
		End Sub

		Public Sub New(ByVal baseUri As String, ByVal keepAliveEnabled As Boolean)
			MyBase.New(HttpClient.CreatePoxBinding(keepAliveEnabled), New EndpointAddress(baseUri))
		End Sub

		Public Function Request(ByVal requestUri As Uri, ByVal httpMethod As String) As Message
            Dim request_Renamed As Message = Message.CreateMessage(MessageVersion.None, String.Empty)
            request_Renamed.Headers.To = requestUri

            Dim [property] As New HttpRequestMessageProperty()
            [property].Method = httpMethod
            [property].SuppressEntityBody = True
            request_Renamed.Properties.Add(HttpRequestMessageProperty.Name, [property])
            Return Me.Channel.Request(request_Renamed)
        End Function

		Public Function Request(ByVal requestUri As Uri, ByVal httpMethod As String, ByVal entityBody As Object) As Message
            Dim request_Renamed As Message = Message.CreateMessage(MessageVersion.None, String.Empty, entityBody)
			request_Renamed.Headers.To = requestUri

			Dim [property] As New HttpRequestMessageProperty()
			[property].Method = httpMethod

			request_Renamed.Properties.Add(HttpRequestMessageProperty.Name, [property])
			Return Me.Channel.Request(request_Renamed)
		End Function

		Public Function [Get](ByVal requestUri As Uri) As Message
			Return Request(requestUri, "GET")
		End Function

		Public Function Post(ByVal requestUri As Uri, ByVal body As Object) As Message
			Return Request(requestUri, "POST", body)
		End Function

		Public Function Put(ByVal requestUri As Uri, ByVal body As Object) As Message
			Dim response As Message = Request(requestUri, "PUT", body)
			Return response
		End Function

		Public Function Delete(ByVal requestUri As Uri) As Message
			Return Request(requestUri, "DELETE")
		End Function

		Public Function GetStatusCode(ByVal response As Message) As HttpStatusCode
			Dim [property] As HttpResponseMessageProperty = TryCast(response.Properties(HttpResponseMessageProperty.Name), HttpResponseMessageProperty)
			Return [property].StatusCode
		End Function

		Public Function GetStatusDescription(ByVal response As Message) As String
			Dim [property] As HttpResponseMessageProperty = TryCast(response.Properties(HttpResponseMessageProperty.Name), HttpResponseMessageProperty)
			Return [property].StatusDescription
		End Function

		Public Function GetLocation(ByVal response As Message) As Uri
			Dim [property] As HttpResponseMessageProperty = TryCast(response.Properties(HttpResponseMessageProperty.Name), HttpResponseMessageProperty)

			Dim location As String = [property].Headers(HttpResponseHeader.Location)

			If location Is Nothing Then
				Throw New ProtocolException("Missing Location header")
			End If

			Dim locationUri As Uri = Nothing

			Uri.TryCreate(location, UriKind.Absolute, locationUri)

			If locationUri Is Nothing Then
				Uri.TryCreate(Me.Channel.Via, locationUri, locationUri)
			End If

			If locationUri Is Nothing Then
				Throw New ProtocolException("Invalid Location: header: " & location)
			End If

			Return locationUri
		End Function

		Private Shared Function CreatePoxBinding(ByVal keepAliveEnabled As Boolean) As Binding
			Dim encoder As New TextMessageEncodingBindingElement(MessageVersion.None, Encoding.UTF8)

			Dim transport As New HttpTransportBindingElement()
			transport.ManualAddressing = True
			transport.KeepAliveEnabled = keepAliveEnabled

			Return New CustomBinding(New BindingElement() { encoder, transport })
		End Function
	End Class
End Namespace
