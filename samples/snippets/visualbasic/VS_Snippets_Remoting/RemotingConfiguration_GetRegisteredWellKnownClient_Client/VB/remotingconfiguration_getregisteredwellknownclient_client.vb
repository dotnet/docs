' System.Runtime.Remoting.RemotingConfiguration.GetRegisteredWellKnownClientTypes
'
' The following example demonstrates the 'GetRegisteredWellKnownClientTypes' method
' of 'RemotingConfiguration' class. 
' It registers a 'TcpChannel' object with the channel services. Then registers the 
' 'MyServerImpl' object as well-known type at the client end. By using the 
' 'GetRegisteredWellKnownClientTypes' method it gets well-known types registered
' at the client side and displays it's properties to the console.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class Client
   
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New TcpChannel())
      ' Register the specified object as well-known type at client end.
      RemotingConfiguration.RegisterWellKnownClientType(GetType(MyServerImpl), _ 
                                                       "tcp://localhost:8085/SayHello")
      Dim myObject As New MyServerImpl()
      Console.WriteLine(myObject.MyMethod("ClientString"))
      
' <Snippet1>
      ' Get the well-known types registered at the client.
      Dim myEntries As WellKnownClientTypeEntry() = _ 
                              RemotingConfiguration.GetRegisteredWellKnownClientTypes()
      Console.WriteLine("The number of WellKnownClientTypeEntries are:" +  _ 
                                                        myEntries.Length.ToString())
      Console.WriteLine("The Object type is:" + myEntries(0).ObjectType.ToString())
      Console.WriteLine("The Object Url is:" + myEntries(0).ObjectUrl.ToString())
' </Snippet1>
   End Sub 'Main 
End Class 'Client

