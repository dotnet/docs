Imports System
Imports System.Collections
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Public Class SinkProviderSampleClass
    <PermissionSet(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
        ' <Snippet1>
        Dim prop = New Hashtable()
        prop("port") = 9000

        Dim clientChain = New BinaryClientFormatterSinkProvider()

        Dim serverChain = New SoapServerFormatterSinkProvider()
        serverChain.Next = New BinaryServerFormatterSinkProvider()

        ChannelServices.RegisterChannel(New HttpChannel(prop, clientChain, serverChain))
        ' </Snippet1>
    End Sub 'Main 

End Class 'SinkProviderSampleClass