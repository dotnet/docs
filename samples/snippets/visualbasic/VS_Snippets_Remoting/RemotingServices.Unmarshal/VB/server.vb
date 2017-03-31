
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime


Namespace SampleNamespace
   Public Class SampleServer
      Public Shared Sub Main()
         ' System.Runtime.Remoting.RemotingServices.SetObjectUriForMarshal
         ' <Snippet1>
         RemotingConfiguration.ApplicationName = "MySampleService"
         Dim channel As New HttpChannel(9000)
         ChannelServices.RegisterChannel(channel)
         Dim objectService As New SampleService()
         RemotingServices.SetObjectUriForMarshal(objectService, "SampleService.soap")
         Dim objRefService As ObjRef = RemotingServices.Marshal(objectService)
         
         Console.WriteLine("Press enter to end the server process.")
         Console.ReadLine()
         ' </Snippet1>
      End Sub 'Main 
   End Class 'SampleServer
End Namespace 'SampleNamespace
