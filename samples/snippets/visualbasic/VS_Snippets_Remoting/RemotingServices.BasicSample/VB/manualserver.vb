
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Security.Permissions
Imports SampleNamespace

' Note: this snippet is based on v-ralphs' Dynamic Remoting sample.
Public Class ManualServer

   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      ' System.Runtime.Remoting.RemotingServices.Marshal(MarshalByRefObject, string)
      ' System.Runtime.Remoting.RemotingServices.Disconnect() -- ManualClient.cs has a snippet for Disconnect, too.
      ' <Snippet2>
      Dim channel As New TcpChannel(9000)
      ChannelServices.RegisterChannel(channel)
      
      Dim objectWellKnown As New SampleWellKnown()
      ' After the channel is registered, the object needs to be registered
      ' with the remoting infrastructure.  So, Marshal is called.
      Dim objrefWellKnown As ObjRef = RemotingServices.Marshal(objectWellKnown, "objectWellKnownUri")
      Console.WriteLine("An instance of SampleWellKnown type is published at {0}.", objrefWellKnown.URI)
      
      Console.WriteLine("Press enter to unregister SampleWellKnown, so that it is no longer available on this channel.")
      Console.ReadLine()
      RemotingServices.Disconnect(objectWellKnown)
      Console.WriteLine("Press enter to end the server process.")
      Console.ReadLine()
      ' </Snippet2>
   End Sub 'Main 
End Class 'ManualServer
