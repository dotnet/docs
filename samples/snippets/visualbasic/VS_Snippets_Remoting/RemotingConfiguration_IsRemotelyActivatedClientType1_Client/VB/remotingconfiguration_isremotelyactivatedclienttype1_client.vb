' System.Runtime.Remoting.RemotingConfiguration.IsRemotelyActivatedClientType(Type)
'
' The following example demonstrates the 'IsRemotelyActivatedClientType(Type)' method
' of 'RemotingConfiguration' class. 
' It registers a 'TcpChannel' object with the channel services. Then registers the 'MyServerImpl'
' object as activated client type which can be activated at the server. By using the above 
' method it gets the activated client type registered at the client side and displays it's 
' properties to the console.

Imports System
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
            Console.WriteLine(myObject.MyMethod("invoke the server method " + _ 
                                                         (i + 1).ToString() + " time."))
         Next i
         
' <Snippet1>
         ' Check whether the 'MyServerImpl' type is registered as a remotely activated client type.
         Dim myActivatedClientEntry As ActivatedClientTypeEntry = _ 
                        RemotingConfiguration.IsRemotelyActivatedClientType(GetType(MyServerImpl))
         Console.WriteLine("The Object type is " + myActivatedClientEntry.ObjectType.ToString())
         Console.WriteLine("The Application Url is " + _ 
                                          myActivatedClientEntry.ApplicationUrl.ToString())
' </Snippet1>
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main
End Class 'ClientClass