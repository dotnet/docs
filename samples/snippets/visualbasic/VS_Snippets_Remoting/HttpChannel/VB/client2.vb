
Imports System
Imports System.Net.Sockets
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Lifetime
Imports SampleNamespace

' The following sample uses an HttpChannel constructor
' to create a new HttpChannel.  
' NOTE: manually instantiating HttpChannel() and registering it does not seem
' necessary.  This sample will work if the line of code is commented out.
' System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel()
' <Snippet3>
Public Class SampleClient
   Inherits MarshalByRefObject
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New HttpChannel())
      RemotingConfiguration.RegisterWellKnownClientType(GetType(SampleService), "http://localhost:9000/MySampleService/SampleService.soap")
      Dim service As New SampleService()
      service.SampleMethod()
   End Sub 'Main
End Class 'SampleClient
' </Snippet3>