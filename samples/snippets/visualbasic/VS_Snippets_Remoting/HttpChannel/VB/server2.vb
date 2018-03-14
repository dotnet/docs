
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime
Imports System.Collections.Specialized
Imports SampleNamespace

' This assembly contains a remote service and its server host wrapped together.
Public Class SampleServer
   
   Public Shared Sub Main()
      ' The following sample uses an HttpChannel constructor
      ' to create a new HttpChannel that will listen on port 9000.
      ' System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel(IDictionary, IClientChannelSinkProvider, IServerChannelSinkProvider);
      ' <Snippet4>
      Dim channelProperties As New ListDictionary()
      channelProperties.Add("port", 9000)
      
      Dim channel As New HttpChannel(channelProperties, New SoapClientFormatterSinkProvider(), New SoapServerFormatterSinkProvider())
      ChannelServices.RegisterChannel(channel)
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(SampleService), "MySampleService/SampleService.soap", WellKnownObjectMode.Singleton)
      
      Console.WriteLine("** Press enter to end the server process. **")
      Console.ReadLine()
      ' </Snippet4>
   End Sub 'Main 
End Class 'SampleServer
