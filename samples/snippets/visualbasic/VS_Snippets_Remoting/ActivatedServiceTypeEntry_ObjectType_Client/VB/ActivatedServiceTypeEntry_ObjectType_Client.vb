Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class MyClient
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel())
      Dim myActivatedClientTypeEntry As New ActivatedClientTypeEntry(GetType(HelloServer), _
                                                "tcp://localhost:8082")
      ' Register 'HelloServer' Type on the client end so that it can be
      ' activated on the server.
      RemotingConfiguration.RegisterActivatedClientType(myActivatedClientTypeEntry)
      ' Obtain a proxy object for the remote object.
      Dim myHelloServer As New HelloServer("ParameterString")
      If myHelloServer Is Nothing Then
         System.Console.WriteLine("Could not locate server")
      Else
         Console.WriteLine("Calling remote object")
         Console.WriteLine(myHelloServer.HelloMethod("Bill"))
      End If
   End Sub 'Main
End Class 'MyClient