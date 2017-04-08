' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Principal
Imports System.Security.Permissions


Public Class ClientClass
   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      
      Dim ident As New GenericIdentity("Bob")
      Dim prpal As New GenericPrincipal(ident, New String() {"Level1"})
      Dim data As New LogicalCallContextData(prpal)
      
      'Enter data into the CallContext
      CallContext.SetData("test data", data)
      
      
      Console.WriteLine(data.numOfAccesses)
      
      ChannelServices.RegisterChannel(New TcpChannel())
      
      RemotingConfiguration.RegisterActivatedClientType(GetType(HelloServiceClass), "tcp://localhost:8082")
      
      Dim service As New HelloServiceClass()
      
      If service Is Nothing Then
         Console.WriteLine("Could not locate server.")
         Return
      End If
      
      
      ' call remote method
      Console.WriteLine()
      Console.WriteLine("Calling remote object")
      Console.WriteLine(service.HelloMethod("Caveman"))
      Console.WriteLine(service.HelloMethod("Spaceman"))
      Console.WriteLine(service.HelloMethod("Bob"))
      Console.WriteLine("Finished remote object call")
      Console.WriteLine()
      
      'Extract the returned data from the call context
      Dim returnedData As LogicalCallContextData = CType(CallContext.GetData("test data"), LogicalCallContextData)
      
      Console.WriteLine(data.numOfAccesses)
      Console.WriteLine(returnedData.numOfAccesses)

   End Sub 'Main

End Class 'ClientClass
' </Snippet1>