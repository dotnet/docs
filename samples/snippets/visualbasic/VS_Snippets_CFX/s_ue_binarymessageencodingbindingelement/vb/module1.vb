
Imports System
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Collections.Generic
Imports System.Text

Namespace Module1
    Module Module1
        Sub Main(ByVal args() As String)
            ' <Snippet0>
            ' <Snippet1>
            Dim be As New BinaryMessageEncodingBindingElement()
            ' </Snippet1>
            ' <Snippet2>
            be.MaxReadPoolSize = 16
            ' </Snippet2>
            ' <Snippet3>
            be.MaxSessionSize = 2048
            ' </Snippet3>
            ' <Snippet4>
            be.MaxWritePoolSize = 16
            ' </Snippet4>
            ' <Snippet5>
            be.MessageVersion = MessageVersion.Default
            ' </Snippet5>
            ' <Snippet6>
            Dim quotas As XmlDictionaryReaderQuotas = be.ReaderQuotas
            ' </Snippet6>

            ' <Snippet7>
            Dim binding As New CustomBinding()
            Dim bpCol As New BindingParameterCollection()
            Dim context As New BindingContext(binding, bpCol)
            be.BuildChannelFactory(Of IDuplexChannel)(context)
            ' </Snippet7>

            ' <Snippet8>
            Dim binding2 As New CustomBinding()
            Dim bpCol2 As New BindingParameterCollection()
            Dim context2 As New BindingContext(binding2, bpCol2)
            be.BuildChannelListener(Of IDuplexChannel)(context2)
            ' </Snippet8>

            ' <Snippet9>
            be.CanBuildChannelListener(Of IDuplexChannel)(context2)
            ' </Snippet9>
            ' <Snippet10>
            Dim bindingElement As BindingElement = be.Clone()
            ' </Snippet10>
            ' <Snippet11>
            Dim mef As MessageEncoderFactory = be.CreateMessageEncoderFactory()
            ' </Snippet11>
            ' <Snippet12>
            Dim mv As MessageVersion = be.GetProperty(Of MessageVersion)(context)
            ' </Snippet12>
            ' </Snippet0>
        End Sub
    End Module
End Namespace
