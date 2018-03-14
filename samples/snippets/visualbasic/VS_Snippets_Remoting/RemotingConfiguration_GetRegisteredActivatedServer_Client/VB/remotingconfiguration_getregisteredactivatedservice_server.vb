' System.Runtime.Remoting.RemotingConfiguration.IsActivationAllowed
' System.Runtime.Remoting.RemotingConfiguration.GetRegisteredActivatedServiceTypes
'
'
' The following example demonstrates the 'IsActivationAllowed' and
' 'GetRegisteredActivatedServiceTypes' methods of 'RemotingConfiguration' class. 
' It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
' object at the service end that can be activated on request from a client.By using the 
' 'GetRegisteredActivatedClientTypes' method it gets the registered activated service types
' and displays it's properties to the console.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class ServerClass
   
   Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel(8085))
      RemotingConfiguration.RegisterActivatedServiceType(GetType(MyServerImpl))
      
' <Snippet1>
' <Snippet2>
      ' Check whether the 'MyServerImpl' object is allowed for activation or not.
      If RemotingConfiguration.IsActivationAllowed(GetType(MyServerImpl)) Then
         ' Get the registered activated service types .
         Dim myActivatedServiceEntries As ActivatedServiceTypeEntry() = _ 
                             RemotingConfiguration.GetRegisteredActivatedServiceTypes()
         Console.WriteLine("The Length of the registered activated service type array is " + _ 
                                        myActivatedServiceEntries.Length.ToString())
         Console.WriteLine("The Object type is:" + _ 
                                 myActivatedServiceEntries(0).ObjectType.ToString())
      End If
' </Snippet2>
' </Snippet1>
      Console.WriteLine("Press enter to stop this process.")
      Console.ReadLine()
   End Sub 'Main
End Class 'ServerClass