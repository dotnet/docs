
Imports System
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels


Namespace Service
    Module Module1
        Sub Main(ByVal args() As String)
            ' <Snippet0>
            ' <Snippet3>
            ' <Snippet1>
            Dim eab As New EndpointAddressBuilder()
            ' </Snippet1>
            eab.Uri = New Uri("http://localhost/Uri")
            eab.Headers.Add(AddressHeader.CreateAddressHeader("n", "ns", "val"))
            ' </Snippet3>

            ' <Snippet4>
            eab.Identity = EndpointIdentity.CreateUpnIdentity("foo")
            ' </Snippet4>

            ' <Snippet5>
            Dim xdrExtensions As XmlDictionaryReader = eab.GetReaderAtExtensions()
            ' </Snippet5>

            ' <Snippet6>
            Dim sr As New StringReader("<myExtension xmlns=""myExtNs"" />")
            eab.SetExtensionReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)))
            ' </Snippet6>

            ' <Snippet7>
            Dim ea As EndpointAddress = eab.ToEndpointAddress()
            ' </Snippet7>

            ' <Snippet8>
            sr = New StringReader("<myMetadata xmlns=""myMetaNs"" />")
            Dim xdrMetaData As XmlDictionaryReader = eab.GetReaderAtMetadata()
            ' </Snippet8>

            ' <Snippet9>
            eab.SetMetadataReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)))
            ' </Snippet9>
            ' </Snippet0>

            ' <Snippet2>
            Dim endpointAddress As New EndpointAddress("http://localhost/uri2")
            Dim eab2 As New EndpointAddressBuilder(endpointAddress)
            ' </Snippet2>
        End Sub
    End Module
End Namespace
