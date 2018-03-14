' <Snippet5>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class Client
   
   Public Shared Sub Main()
      
      ' open channel and get handle to object
      ChannelServices.RegisterChannel(New TcpChannel())
      
      'Registering the well known object on the client side for use by the operator new.
      RemotingConfiguration.RegisterWellKnownClientType(GetType(HelloServer), _
                                                        "tcp://localhost:8084/SayHello")

      Dim obj As HelloServer  = New HelloServer()
      
      ' call remote method
      Console.WriteLine()
      Console.WriteLine("Before Call")
      Console.WriteLine(obj.HelloMethod("Caveman"))
      Console.WriteLine(obj.HelloMethod("Spaceman"))
      Console.WriteLine(obj.HelloMethod("Client Man"))
      Console.WriteLine("After Call")
      Console.WriteLine()

   End Sub 'Main 

End Class 'Client
' </Snippet5>