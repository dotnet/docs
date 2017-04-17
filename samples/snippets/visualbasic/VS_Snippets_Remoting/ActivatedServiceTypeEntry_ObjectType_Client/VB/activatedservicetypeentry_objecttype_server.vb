' System.Runtime.Remoting.ActivatedServiceTypeEntry
' System.Runtime.Remoting.ActivatedServiceTypeEntry.ObjectType
' System.Runtime.Remoting.ActivatedServiceTypeEntry.ToString

' The following example demonstrates the 'ActivatedServiceTypeEntry' class and 
' the 'ObjectType' property ,'ToString' method of 'ActivatedServiceTypeEntry' class.
' It registers a 'TcpChannel' object with the channel services. Then registers the 'HelloServer'
' object at the service end that can be activated on request from a client.By using the 
' 'GetRegisteredActivatedServiceTypes' method it gets the registered activated service types
' and displays it's information to the console.

' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class MyClient
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel(8082))
      ' Create an instance of 'ActivatedServiceTypeEntry' class
      ' which holds the values for 'HelloServer' type.
      Dim myActivatedServiceTypeEntry As New ActivatedServiceTypeEntry(GetType(HelloServer))
      ' Register an object Type on the service end so that 
      ' it can be activated on request from a client.
      RemotingConfiguration.RegisterActivatedServiceType(myActivatedServiceTypeEntry)
' <Snippet2>
' <Snippet3>
      ' Get the registered activated service types .
      Dim myActivatedServiceEntries As ActivatedServiceTypeEntry() = RemotingConfiguration. _
                                                         GetRegisteredActivatedServiceTypes()
      Console.WriteLine("Information of first registered activated " + " service type :")
      Console.WriteLine("Object type: " + myActivatedServiceEntries(0).ObjectType.ToString())
      Console.WriteLine("Description: " + myActivatedServiceEntries(0).ToString())
' </Snippet3>
' </Snippet2>
      Console.WriteLine("Press enter to stop this process")
      Console.ReadLine()
   End Sub 'Main
End Class 'MyClient
' </Snippet1>