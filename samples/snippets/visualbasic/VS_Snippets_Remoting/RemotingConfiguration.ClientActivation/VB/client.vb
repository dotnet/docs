 ' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp


Public Class ClientClass
   
   Public Shared Sub Main()
      
      ChannelServices.RegisterChannel(New TcpChannel())
      
      RemotingConfiguration.RegisterActivatedClientType(GetType(HelloServiceClass), "tcp://localhost:8082")
      
      Try
          Dim service As New HelloServiceClass()
      
       
          ' Calls the remote method.
          Console.WriteLine()
          Console.WriteLine("Calling remote object")
          Console.WriteLine(service.HelloMethod("Caveman"))
          Console.WriteLine(service.HelloMethod("Spaceman"))
          Console.WriteLine(service.HelloMethod("Client Man"))
          Console.WriteLine("Finished remote object call")
      Catch ex as Exception
          Console.WriteLine("An exception occurred: " + ex.Message)
      End Try

      Console.WriteLine()

   End Sub 'Main

End Class 'ClientClass
' </Snippet1>