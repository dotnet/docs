' This program acts as a client and calls the remote method 'HelloMethod'.

Imports System
Imports System.Net
Imports System.Collections.Specialized
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Security.Permissions

Namespace RemotingSamples
   Public Class MyIChannelReceiverChannelDataClientClass
      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         Dim myChannelURL As String = "tcp://" + Dns.Resolve(Dns.GetHostName()).AddressList(0).ToString() + _
                                       ":8085/SayHello"
         Dim myListDictionary As New ListDictionary()
         myListDictionary.Add("port", 8086)
         Dim myCustomChannel As New TcpChannel(myListDictionary, New SoapClientFormatterSinkProvider(), _
                                                            New SoapServerFormatterSinkProvider())
         ChannelServices.RegisterChannel(myCustomChannel)
         Try
            Dim myHelloServer As HelloServer = CType(Activator.GetObject(GetType _
                              (RemotingSamples.HelloServer), myChannelURL), HelloServer)
            If myHelloServer Is Nothing Then
               Console.WriteLine("Could not locate server.")
            Else
               Console.WriteLine(myHelloServer.HelloMethod("Caveman"))
            End If
         Catch e As Exception
            Console.WriteLine("Message : " + e.Message)
         End Try
      End Sub 'Main
   End Class 'MyIChannelReceiverChannelDataClientClass
End Namespace 'RemotingSamples