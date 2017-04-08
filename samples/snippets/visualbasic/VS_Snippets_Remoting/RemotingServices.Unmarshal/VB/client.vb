' System.Runtime.Remoting.RemotingServices.GetLifetimeService
' This sample is of a remote client for a group coffee timer.
' Since the client must stay connected to a stateful server object
' for minutes without calling it, it needs to register as a sponsor
' of the lease to prevent the server from being collected.
' Multiple clients can connect to the same timer object, and receive
' notification when the timer expires.
Imports System
Imports System.Net.Sockets
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
Imports SampleNamespace

Public Class SampleClient
   Inherits MarshalByRefObject

   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      ' System.Runtime.Remoting.RemotingServices.Unmarshal
      ' <Snippet2>
      ChannelServices.RegisterChannel(New HttpChannel())

      Dim objectSample As SampleService = CType(Activator.GetObject(GetType(SampleService), _ 
            "http://localhost:9000/MySampleService/SampleService.soap"), SampleService)

      ' The GetManuallyMarshaledObject() method uses RemotingServices.Marshal()
      ' to create an ObjRef object for a SampleTwo object.
      Dim objRefSampleTwo As ObjRef = objectSample.GetManuallyMarshaledObject()

      Dim objectSampleTwo As SampleTwo = CType(RemotingServices.Unmarshal(objRefSampleTwo), SampleTwo)

      objectSampleTwo.PrintMessage("I successfully unmarshaled your ObjRef.  Thanks.")
      ' </Snippet2>
   End Sub 'Main 
End Class 'SampleClient
