Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class MyUdpClientExample
   
   
   Public Shared Sub Main()
      
      '<Snippet1>
      ' This constructor arbitrarily assigns the local port number.
      Dim udpClient As New UdpClient(11000)
      Try
         udpClient.Connect("www.contoso.com", 11000)
         
         ' Sends a message to the host to which you have connected.
         Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there?")
         
         udpClient.Send(sendBytes, sendBytes.Length)
         
         ' Sends message to a different host using optional hostname and port parameters.
         Dim udpClientB As New UdpClient()
         udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 11000)
         
         ' IPEndPoint object will allow us to read datagrams sent from any source.
         Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
         
         ' UdpClient.Receive blocks until a message is received from a remote host.
         Dim receiveBytes As [Byte]() = udpClient.Receive(RemoteIpEndPoint)
         Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
         
         ' Which one of these two hosts responded?
         Console.WriteLine(("This is the message you received " + _
                                       returnData.ToString()))
          Console.WriteLine(("This message was sent from " + _
                                       RemoteIpEndPoint.Address.ToString() + _ 
                                       " on their port number " + _
                                       RemoteIpEndPoint.Port.ToString()))
         udpClient.Close()
         udpClientB.Close()
 
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 
   '</Snippet1>
End Class 'MyUdpClientExample
