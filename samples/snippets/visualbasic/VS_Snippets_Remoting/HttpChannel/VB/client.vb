
Imports System
Imports System.Net.Sockets
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
Imports SampleNamespace


' The following sample uses an HttpChannel constructor
' to create a new HttpChannel, allowing this client to
' hook up to an event on a server object.
' System.Runtime.Remoting.Channels.Http.HttpChannel.HttpChannel(int)
' <Snippet2>
Public Class SampleClient
   Inherits MarshalByRefObject
   
   Public Shared Sub Main()
      Dim client As New SampleClient()
   End Sub 'Main

   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Sub New()
      ChannelServices.RegisterChannel(New HttpChannel(0))
      Dim service As SampleService = CType(Activator.GetObject(GetType(SampleService), "http://localhost:9000/MySampleService/SampleService.soap"), SampleService)
      ' Subscribe to event so that the client can receive notification from ther server.
      Dim eventHandler As SomethingHappenedEventHandler = AddressOf OnSomethingHappened
      AddHandler service.SomethingHappened, eventHandler
      ' The server will fire the SomethingHappened event in SampleMethod()
      service.SampleMethod()
      RemoveHandler service.SomethingHappened, eventHandler
   End Sub 'New
   
   
   Private Sub OnSomethingHappened(source As Object, e As SampleServiceEventArgs)
      Console.WriteLine("SomethingHappened event fired: {0}", e.Message)
   End Sub 'OnSomethingHappened
End Class 'SampleClient 
' </Snippet2>