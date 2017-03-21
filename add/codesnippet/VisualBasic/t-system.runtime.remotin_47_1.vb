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
      ' Get the registered activated service types .
      Dim myActivatedServiceEntries As ActivatedServiceTypeEntry() = RemotingConfiguration. _
                                                         GetRegisteredActivatedServiceTypes()
      Console.WriteLine("Information of first registered activated " + " service type :")
      Console.WriteLine("Object type: " + myActivatedServiceEntries(0).ObjectType.ToString())
      Console.WriteLine("Description: " + myActivatedServiceEntries(0).ToString())
      Console.WriteLine("Press enter to stop this process")
      Console.ReadLine()
   End Sub 'Main
End Class 'MyClient