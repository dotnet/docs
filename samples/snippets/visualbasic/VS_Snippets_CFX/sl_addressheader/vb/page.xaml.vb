
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

'NSs added
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.ServiceModel.Syndication
Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO
Imports System.Json
Imports System.Text


Namespace SL_AddressHeader
	Partial Public Class Page
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		'This uses an event handler, not SL data binding
		Private Sub OnClick(ByVal sender As Object, ByVal args As EventArgs)

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

			'Bind text outputs

			'Name
			txtOutput1.Text = addressHeaderName

			'Namespace
			txtOutput2.Text = addressHeaderNS

			'Contains txtHeaders
			Dim addressHeaderCollection1 As AddressHeaderCollection = endpointAddressWithHeaders.Headers
			Dim txtHeaders As String = addressHeaderCollection1.Contains(addressHeader1).ToString()
			txtOutput3.Text = txtHeaders



			txtOutput4.Text = value.ToString()
			'txtOutput5.Text = txtOutput5;
			'txtOutput6.Text = txtOutput6;
			'txtOutput7.Text = txtOutput7;
		End Sub
	End Class
End Namespace