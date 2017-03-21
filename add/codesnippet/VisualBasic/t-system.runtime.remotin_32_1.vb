Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Public Class MyServer
   
   Public Shared Sub Main()
      ' Create a 'HttpChannel' object and register it with the 
      ' channel services.
      ChannelServices.RegisterChannel(New HttpChannel(8086))
      ' Record the 'HelloServer' type as 'Singleton' well-known type.
      Dim myWellKnownServiceTypeEntry As New WellKnownServiceTypeEntry(GetType(HelloServer), _ 
                                                 "SayHello", WellKnownObjectMode.Singleton)
      ' Register the remote object as well-known type.
      RemotingConfiguration.RegisterWellKnownServiceType(myWellKnownServiceTypeEntry)
      ' Retrieve object types registered on the service end 
      ' as well-known types.
      Dim myWellKnownServiceTypeEntryCollection As WellKnownServiceTypeEntry() = _ 
                                      RemotingConfiguration.GetRegisteredWellKnownServiceTypes()
      Console.WriteLine("The 'WellKnownObjectMode' of the remote object : " + _
                                        myWellKnownServiceTypeEntryCollection(0).Mode.ToString())
      Console.WriteLine("The 'WellKnownServiceTypeEntry' object: " + _ 
                                             myWellKnownServiceTypeEntryCollection(0).ToString())
      Console.WriteLine("Started the Server, Hit <enter> to exit...")
      Console.ReadLine()
   End Sub 'Main
End Class 'MyServer