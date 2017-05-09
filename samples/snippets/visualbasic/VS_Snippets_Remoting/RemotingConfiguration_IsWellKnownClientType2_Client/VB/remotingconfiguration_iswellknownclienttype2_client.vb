' System.Runtime.Remoting.RemotingConfiguration.IsWellKnownClientType(String,String)

' The following example demonstrates the 'IsWellKnownClientType(String,String)' method
' of 'RemotingConfiguration' class. It registers a 'TcpChannel' object with the channel
' services. Then registers the 'MyServerImpl' object as well-known type at the client end.
' and displays it's properties to the console.

Imports System
Imports System.Reflection
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
' <Snippet1>
      Dim myObject As New MyServerImpl()
      ' Get the assembly for the 'MyServerImpl' object.
      Dim myAssembly As [Assembly] = [Assembly].GetAssembly(GetType(MyServerImpl))
      Dim myName As AssemblyName = myAssembly.GetName()
      ' Check whether the specified object type is registered as
      ' well-known client type.
      Dim myWellKnownClientType As WellKnownClientTypeEntry = _
           RemotingConfiguration.IsWellKnownClientType(GetType(MyServerImpl).FullName, myName.Name)
      Console.WriteLine("The Object type :" + myWellKnownClientType.ObjectType.ToString())
      Console.WriteLine("The Object Uri :" + myWellKnownClientType.ObjectUrl)
' </Snippet1>
      Console.WriteLine(myObject.MyMethod("Remote method is called."))
   End Sub 'Main
End Class 'Client

