' This file is a support file for demonstrating IClientChannelSinkProvider 
' and ServerProcessing.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels
Imports System.Security.Permissions
Imports MyLogging

Public Class MyServerProcessingClient
   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Dim mySoapClientFormatterProvider = New SoapClientFormatterSinkProvider()
      Dim myClientProvider = New MyServerProcessingLogClientChannelSinkProviderData()
   
      mySoapClientFormatterProvider.Next = myClientProvider
      
         Dim channel As New TcpChannel(Nothing, mySoapClientFormatterProvider, Nothing)
   
      ChannelServices.RegisterChannel(channel)
      
       RemotingConfiguration.RegisterWellKnownClientType(GetType(MyHelloService), _
                 "tcp://localhost:8082/HelloServiceApplication/MyUri")
      
      Dim myService As New MyHelloService()

      If myService Is Nothing Then
         Console.WriteLine("Could not locate server.")
         Return
      End If
      
      ' Call remote method.
      Console.WriteLine()
      Console.WriteLine("Calling remote object")
      Console.WriteLine(myService.HelloMethod("Caveman"))
      Console.WriteLine(myService.HelloMethod("Spaceman"))
      Console.WriteLine(myService.HelloMethod("Client Man"))
      Console.WriteLine("Finished remote object call")
      Console.WriteLine()
   End Sub 'Main
End Class 'MyServerProcessingClient