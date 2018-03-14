Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Security.Permissions

Public Class Client
   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Dim myChannel As New TcpChannel()
      ChannelServices.RegisterChannel(myChannel)
      Dim myObject As MyServerImpl = CType(Activator.GetObject(GetType(MyServerImpl), _ 
                                        "tcp://localhost:8085/SayHello"), MyServerImpl)
      Console.WriteLine(myObject.MyMethod("ClientString"))
   End Sub 'Main
End Class 'Client

