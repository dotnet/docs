
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime
Imports SampleNamespace

' This assembly contains a remote service and its server host wrapped together.
Public Class SampleServer
   
   Public Shared Sub Main()
      ' The following sample uses an HttpChannel constructor
      ' to create a new HttpChannel that will listen on port 9000.
      ' System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel(int)
      ' System.Runtime.Remoting.Channels.Http.HttpChannel
      ' <Snippet1>
      Dim channel As New HttpChannel(9000)
      ChannelServices.RegisterChannel(channel)
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(SampleService), "MySampleService/SampleService.soap", WellKnownObjectMode.Singleton)
      
      Console.WriteLine("** Press enter to end the server process. **")
      Console.ReadLine()
      ' </Snippet1>
   End Sub 'Main ' 
End Class 'SampleServer
