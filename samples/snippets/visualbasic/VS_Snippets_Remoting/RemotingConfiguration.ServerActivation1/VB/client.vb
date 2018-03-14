 ' <Snippet5>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels


Public Class ClientClass
   
   
   Public Shared Sub Main()
      
      ' </Snippet5>
      ' <Snippet6>
      ChannelServices.RegisterChannel(New TcpChannel())
      
      RemotingConfiguration.RegisterWellKnownClientType(GetType(HelloService), "tcp://localhost:8082/HelloServiceApplication/MyUri")
      
      Dim service As New HelloService()
      ' </Snippet6>
      ' <Snippet7>

      If service Is Nothing Then
         Console.WriteLine("Could not locate server.")
         Return
      End If
            
      ' Calls the remote method.
      Console.WriteLine()
      Console.WriteLine("Calling remote object")
      Console.WriteLine(service.HelloMethod("Caveman"))
      Console.WriteLine(service.HelloMethod("Spaceman"))
      Console.WriteLine(service.HelloMethod("Client Man"))
      Console.WriteLine("Finished remote object call")
      Console.WriteLine()

   End Sub 'Main

End Class 'ClientClass
' </Snippet7>