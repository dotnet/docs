' Supporting file for the ITransportHeaders_3_Server.vb
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Security.Permissions

Public Class MyITransportHeadersClient
   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Try
         Dim myTcpChannel1 As New TcpChannel()
         ChannelServices.RegisterChannel(myTcpChannel1)
         Dim myHelloServerObj As MyHelloServer = CType(Activator.GetObject(GetType(MyHelloServer), _
                                              "tcp://localhost:8085/SayHello"), MyHelloServer)
         If myHelloServerObj Is Nothing Then
            System.Console.WriteLine("Could not locate server")
         Else
            Console.WriteLine(myHelloServerObj.MyHelloMethod("World"))
         End If
      Catch e As Exception
         Console.WriteLine("The following exception is raised on the client side: " + e.Message)
      End Try
   End Sub 'Main
End Class 'MyITransportHeadersClient