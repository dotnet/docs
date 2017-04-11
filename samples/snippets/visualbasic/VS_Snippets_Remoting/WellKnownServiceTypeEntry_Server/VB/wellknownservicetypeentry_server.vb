' System.Runtime.Remoting.WellKnownServiceTypeEntry

' The following example demonstrates the 'WellKnownServiceTypeEntry' class. 
' It registers a 'HttpChannel' object with the channel services. Then registers the 'HelloServer'
' type as well known type with the Remoting Infrastructure at the service end . It displays the 
' properties of the 'WellKnownServiceTypeEntry' object holding the values for the above well-known
' type .

' <Snippet1>
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
' </Snippet1>