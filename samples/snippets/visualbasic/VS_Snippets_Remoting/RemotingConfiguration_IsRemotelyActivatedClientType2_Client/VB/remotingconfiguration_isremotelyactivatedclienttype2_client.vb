' System.Runtime.Remoting.RemotingConfiguration.IsRemotelyActivatedClientType(String,String)

' The following example demonstrates the 'IsRemotelyActivatedClientType(String,String)' method
' of 'RemotingConfiguration' class. 
' It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
' object as activated client type which can be activated at the server and displays it's 
' properties to the console.

Imports System
Imports System.Reflection
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Public Class ClientClass
   
   Shared Sub Main()
      Try
         ChannelServices.RegisterChannel(New TcpChannel())
         RemotingConfiguration.RegisterActivatedClientType(GetType(MyServerImpl), _
                 "tcp://localhost:8085")
         Dim myObject As New MyServerImpl()
         Dim i As Integer
         For i = 0 To 4
            Console.WriteLine(myObject.MyMethod("invoke the server method "))
         Next i ' Get the assembly for the 'MyServerImpl' object.
' <Snippet1>
         Dim myAssembly As [Assembly] = [Assembly].GetAssembly(GetType(MyServerImpl))
         Dim myName As AssemblyName = myAssembly.GetName()
         ' Check whether the 'MyServerImpl' type is registered as
         ' a remotely activated client type.
         Dim myActivatedClientEntry As ActivatedClientTypeEntry = _
                 RemotingConfiguration.IsRemotelyActivatedClientType(GetType(MyServerImpl).FullName, _
                 myName.Name)
         Console.WriteLine("The Object type : " + myActivatedClientEntry.ObjectType.ToString())
         Console.WriteLine("The Application Url : " + myActivatedClientEntry.ApplicationUrl)
         if myActivatedClientEntry is nothing then
	   Console.WriteLine("The object is not client activated")
	else
           Console.WriteLine("The object is client activated")
	end if
' </Snippet1>
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main
End Class 'ClientClass