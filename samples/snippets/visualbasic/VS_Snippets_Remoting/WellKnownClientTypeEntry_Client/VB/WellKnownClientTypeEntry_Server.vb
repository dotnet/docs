' This is the server program for the 'WellKnownClientTypeEntry_Client.vb' program.
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Public Class MyServer
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New HttpChannel(8086))
      ' Record the 'HelloServer' type as 'Singleton' well-known type.
      Dim myWellKnownServiceTypeEntry As New WellKnownServiceTypeEntry(GetType(HelloServer), _ 
                                                     "SayHello", WellKnownObjectMode.Singleton)
      RemotingConfiguration.RegisterWellKnownServiceType(myWellKnownServiceTypeEntry)
      Console.WriteLine("Started the Server, Hit <enter> to exit...")
      Console.ReadLine()
   End Sub 'Main
End Class 'MyServer
