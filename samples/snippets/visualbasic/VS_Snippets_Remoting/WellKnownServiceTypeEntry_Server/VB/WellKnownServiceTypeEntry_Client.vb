' This is the client program for the 'WellKnownServiceTypeEntry_Server.vb' program.
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Public Class MyClient
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New HttpChannel())
      Console.WriteLine(" Start calling from Client One.......")
      Dim myWellKnownClientTypeEntry As New WellKnownClientTypeEntry(GetType(HelloServer), _ 
                                                  "http://localhost:8086/SayHello")
      myWellKnownClientTypeEntry.ApplicationUrl = "http://localhost:8086/SayHello"
      RemotingConfiguration.RegisterWellKnownClientType(myWellKnownClientTypeEntry)
      Dim myHelloServerObject As New HelloServer()
      Dim i As Integer
      For i = 0 To 4
         Console.WriteLine(myHelloServerObject.HelloMethod(" Client One"))
      Next i
   End Sub 'Main
End Class 'MyClient