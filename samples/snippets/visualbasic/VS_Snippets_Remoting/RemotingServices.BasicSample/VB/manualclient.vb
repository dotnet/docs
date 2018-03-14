
Imports System
Imports System.Net.Sockets
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports SampleNamespace

' Note: this snippet is based on v-ralphs' Dynamic Remoting sample.
Public Class ManualClient
   
   Public Shared Sub Main()
      ' System.Runtime.Remoting.RemotingServices.Disconnect() -- ManualServer.cs has a snippet for Disconnect, too.
      ' <Snippet3>
      Dim remoteType As New WellKnownClientTypeEntry(GetType(SampleWellKnown), "tcp://localhost:9000/objectWellKnownUri")
      RemotingConfiguration.RegisterWellKnownClientType(remoteType)
      
      Dim objectWellKnown As New SampleWellKnown()
      
      Try
         objectWellKnown.Add(2, 3)
         Console.WriteLine("The add method on SampleWellKnown was successfully called.")
      Catch e As SocketException
         Console.WriteLine("The server is not available.  Is it still running?")
      Catch e As RemotingException
         Console.WriteLine("SampleWellKnown is currently not available.  The server probably called Disconnect().")
      End Try
      ' </Snippet3>
   End Sub 'Main
   
End Class 'ManualClient 
