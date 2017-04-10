' System.Runtime.Remoting.RemotingConfiguration.IsWellKnownClientType(Type)
'
' The following example demonstrates the 'IsWellKnownClientType(Type)' method
' of 'RemotingConfiguration' class. It registers a 'TcpChannel' object with the channel
' services. Then registers the 'MyServerImpl' object as well-known type. By using the above 
' method it gets the well-known type registered at the client side and displays it's 
' properties to the console.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class Client
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel())
      ' Register the 'MyServerImpl' object as well known type 
      ' at client end.
      RemotingConfiguration.RegisterWellKnownClientType(GetType(MyServerImpl), _ 
                                          "tcp://localhost:8085/SayHello")
      Dim myObject As New MyServerImpl()
      
      Console.WriteLine(myObject.MyMethod("ClientString"))
' <Snippet1>
      ' Check whether the specified object type is registered as 
      ' well known client type or not.
      Dim myWellKnownClientType As WellKnownClientTypeEntry = _ 
                         RemotingConfiguration.IsWellKnownClientType(GetType(MyServerImpl))
      Console.WriteLine("The Object type is " + myWellKnownClientType.ObjectType.ToString())
      Console.WriteLine("The Object Url is " + myWellKnownClientType.ObjectUrl)
' </Snippet1>
   End Sub 'Main
End Class 'Client 

