' This program registers the remote object.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Collections.Specialized

Namespace RemotingSamples
   Public Class MyChannelServices_Server
      
      Public Shared Sub Main()
         Dim properties As New ListDictionary()
         properties.Add("port", 8086)
         Dim myServerChannel As New HttpChannel(properties, New SoapClientFormatterSinkProvider(), _
                                                      New SoapServerFormatterSinkProvider())
         ChannelServices.RegisterChannel(myServerChannel)
         RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("RemotingSamples.HelloServer," + _
                     " ChannelServices_GetChannel_Share"), "SayHello", WellKnownObjectMode.Singleton)
         Console.WriteLine("Hit <enter> to exit...")
         Console.ReadLine()
      End Sub 'Main
   End Class 'MyChannelServices_Server
End Namespace 'RemotingSamples
