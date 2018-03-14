' System.Runtime.Remoting.Channels.ChannelServices.GetUrlsForObject(MarshalByRefObject)

' The following example demonstrates the method 'GetUrlsForObject' 
' of the class 'ChannelServices'. The example is just a client, it 
' locates and connects to the server, retrieves a proxy for the remote 
' object, and calls the 'HelloMethod' on the remote object, passing the 
' string 'Caveman' as a parameter. The server returns the string
' 'Hi there Caveman'.  

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Security.Permissions

Namespace RemotingSamples
   Public Class MyChannelServices_Client
      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         Try
            Dim myTcpChannel As New TcpChannel(8084)
            ChannelServices.RegisterChannel(myTcpChannel)
            Dim myHelloServer As HelloServer = CType(Activator.GetObject(GetType _
                     (RemotingSamples.HelloServer), "tcp://localhost:8080/SayHello"), HelloServer)
            If myHelloServer Is Nothing Then
               System.Console.WriteLine("Could not locate server")
            Else
' <Snippet4>
               Dim myURLArray As String() = ChannelServices.GetUrlsForObject(myHelloServer)
               Console.WriteLine("Number of URLs for the specified Object: " + _
                                                            myURLArray.Length.ToString())
               Dim iIndex As Integer
               For iIndex = 0 To myURLArray.Length - 1
                  Console.WriteLine("URL: " + myURLArray(iIndex))
               Next iIndex 
' </Snippet4>
               Console.WriteLine(myHelloServer.HelloMethod("Caveman"))
            End If
         Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine("The source of exception: " + e.Source)
            Console.WriteLine("The Message of exception: " + e.Message)
         End Try
      End Sub 'Main
   End Class 'MyChannelServices_Client
End Namespace 'RemotingSamples