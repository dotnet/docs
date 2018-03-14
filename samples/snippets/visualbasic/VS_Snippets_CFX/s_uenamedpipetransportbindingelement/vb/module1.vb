' Snippet for S_UENamedPipeTransportBindingElement.

Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Globalization
Imports System.Net
Imports System.Net.Security
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Security
Imports System.Text
Imports System.Xml

Namespace Snippets
    Module Module1

        Sub Main()
            ' <Snippet3>
            ' <Snippet2>
            ' <Snippet0>
            ' <Snippet1>
            Dim bElement As New NamedPipeTransportBindingElement()
            ' </Snippet1>

            Dim connectionPoolSettings As NamedPipeConnectionPoolSettings = bElement.ConnectionPoolSettings
            ' </Snippet0>
            ' </Snippet2>
            ' </Snippet3>

            ' <Snippet4>
            Dim scheme As String = bElement.Scheme
            ' </Snippet4>

            ' <Snippet5>
            Dim bElementCopy As BindingElement = bElement.Clone()
            ' </Snippet5>

            ' <Snippet8>
            Dim binding As New BasicHttpBinding()
            Dim b As ISecurityCapabilities = binding.GetProperty(Of ISecurityCapabilities)(New BindingParameterCollection())

            Dim SupportsServerAuthentication As Boolean = b.SupportsServerAuthentication
            ' </Snippet8>

        End Sub

        Private Sub RunClient()
            Dim binding As New CustomBinding()
            binding.Elements.Add(New NamedPipeTransportBindingElement())
            Dim customBinding As New CustomBinding()
            Dim bpCollection As New BindingParameterCollection()

            ' <Snippet6>
            Dim bContext As New BindingContext(customBinding, bpCollection)
            Dim factory As IChannelFactory(Of IOutputChannel) = binding.BuildChannelFactory(Of IOutputChannel)(bContext)
            ' </Snippet6>

            ' <Snippet7>
            Dim listener As IChannelListener(Of IOutputChannel) = binding.BuildChannelListener(Of IOutputChannel)(bContext)
            ' </Snippet7>

        End Sub

    End Module

End Namespace
