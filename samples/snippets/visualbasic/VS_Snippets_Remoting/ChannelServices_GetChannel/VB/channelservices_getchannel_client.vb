' System.Runtime.Remoting.Channels.ChannelServices.GetChannel
' System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties

' This example demonstrates the usage of the properties 'GetChannel' and 
' 'GetChannelSinkProperties' of the 'ChannelServices' class. It displays
' the registered channel name, priority and channelsinkproperties
' for a given proxy and executes a remote method 'HelloMethod'.

Imports System
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Security.Permissions

Namespace RemotingSamples
   Public Class MyChannelServices_Client

      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         Dim myProperties As New ListDictionary()
         myProperties.Add("port", 8085)
         myProperties.Add("name", "MyHttpChannel")
' <Snippet1>
         Dim myClientChannel As New HttpChannel(myProperties, New SoapClientFormatterSinkProvider(), _
                                                            New SoapServerFormatterSinkProvider())
         ChannelServices.RegisterChannel(myClientChannel)
         ' Get the registered channel. 
         Console.WriteLine("Channel Name : " + ChannelServices.GetChannel _
                                                      (myClientChannel.ChannelName).ChannelName)
         Console.WriteLine("Channel Priorty : " + _
               ChannelServices.GetChannel(myClientChannel.ChannelName).ChannelPriority.ToString())
' </Snippet1>
         Dim myProxy As HelloServer = CType(Activator.GetObject(GetType(RemotingSamples.HelloServer), _
                                                   "http://localhost:8086/SayHello"), HelloServer)
' <Snippet2>
         ' Get an IDictionary of properties for a given proxy.
         Dim myDictionary As IDictionary = ChannelServices.GetChannelSinkProperties(myProxy)
         Dim myKeysCollection As ICollection = myDictionary.Keys
         Dim myKeysArray(myKeysCollection.Count-1) As Object
         Dim myValuesCollection As ICollection = myDictionary.Values
         Dim myValuesArray(myValuesCollection.Count-1) As Object
         myKeysCollection.CopyTo(myKeysArray, 0)
         myValuesCollection.CopyTo(myValuesArray, 0)
         Dim iIndex As Integer
         For iIndex = 0 To myKeysArray.Length - 1
            Console.Write("Property Name : " & myKeysArray(iIndex) & " value : ")
            Console.WriteLine(myValuesArray(iIndex))
         Next iIndex
' </Snippet2>
         If myProxy Is Nothing Then
            System.Console.WriteLine("Could not locate server")
         Else
            Console.WriteLine(myProxy.HelloMethod("Caveman"))
         End If
      End Sub 'Main
   End Class 'MyChannelServices_Client
End Namespace 'RemotingSamples