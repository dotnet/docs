' File name: Program.vb
' Snippets  for Silverlight 2 RTM 
' Copyright (c) Microsoft Corporation.  All Rights Reserved.


' NSs automatically added to a SL App


Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
' using System.Windows.Controls;
' using System.Windows.Documents;
' using System.Windows.Input;
' using System.Windows.Media;
' using System.Windows.Media.Animation;
' using System.Windows.Shapes;

' Namespaces added
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization
' using System.Runtime.Serialization.Json;
' using System.ServiceModel.Syndication;
Imports System.Xml.Serialization
' using System.Json;
Imports System.Text

Namespace SL_AddressHeader
	Public Class Snippets
		Public Shared Sub Main()
			' <Snippet0>

			' <Snippet1>
			' Name property
			Dim addressHeaderWithName As AddressHeader = AddressHeader.CreateAddressHeader("MyServiceName", "http://localhost:8000/service",1)
			Dim addressHeaderName As String = addressHeaderWithName.Name
			' </Snippet1>

			' <Snippet2>
			'Put snippet here.
			' Namespace property
			Dim addressHeaderWithNS As AddressHeader = AddressHeader.CreateAddressHeader("MyServiceName", "http://localhost:8000/service",1)
			Dim addressHeaderNS As String = addressHeaderWithNS.Namespace
			' </Snippet2>

			' <Snippet3>
			' Obsolete
			' </Snippet3>

			' <Snippet4>
			' Obsolete
			' </Snippet4>

			' <Snippet5>
			' Create address headers for special services and add them to an array
			Dim addressHeader1 As AddressHeader = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1)
			Dim addressHeader2 As AddressHeader = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2)
			Dim addressHeaders() As AddressHeader = { addressHeader1, addressHeader2 }

			' Endpoint address constructor with URI and address headers
			Dim endpointAddressWithHeaders As New EndpointAddress(New Uri("http://localhost/silverlightsamples/service1"), addressHeaders)

			' Confirm adddressHeader1 is in endpointAddressWithHeaders - boolHeaders returns True.
			Dim addressHeaderCollection As AddressHeaderCollection = endpointAddressWithHeaders.Headers
			Dim boolHeaders As Boolean = addressHeaderCollection.Contains(addressHeader1)
			' </Snippet5>

			' <Snippet10>
			' <Snippet6>
			'Create address headers with XmlObjectSerializer specified
			Dim serializer As XmlObjectSerializer = New DataContractSerializer(GetType(Integer))
			Dim addressHeaderWithObjSer As AddressHeader = AddressHeader.CreateAddressHeader("MyServiceName", "http://localhost:8000/service", 1, serializer)
			Dim value As Integer = addressHeaderWithObjSer.GetValue(Of Integer)()
			' </Snippet6>
			' </Snippet10>

			' </Snippet0>


		End Sub
	End Class
End Namespace