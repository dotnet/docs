Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class MyUdpClientExample
   
   
   '  MyUdpClientConstructor is just used to illustrate the different constructors available in in the UdpClient class.
   Public Shared Sub MyUdpClientConstructor(myConstructorType As String)
      
      If myConstructorType = "PortNumberExample" Then
         ' <Snippet1>
         'Creates an instance of the UdpClient class to listen on 
         'the default interface using a particular port.
         Try
            Dim udpClient As New UdpClient(11000)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try
      ' </Snippet1> 
      Else
         If myConstructorType = "LocalEndPointExample" Then
            ' <Snippet2>
            'Creates an instance of the UdpClient class using a local endpoint.
            Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
            Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 11000)
            
            Try
               Dim udpClient As New UdpClient(ipLocalEndPoint)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
         ' </Snippet2>
         Else
            If myConstructorType = "HostNameAndPortNumExample" Then
               ' <Snippet3>
               'Creates an instance of the UdpClient class with a remote host name and a port number.
               Try
                  Dim udpClient As New UdpClient("www.contoso.com", 11000)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try
            ' </Snippet3>
            Else
               If myConstructorType = "DefaultExample" Then
                  ' <Snippet4>
                  'Creates an instance of the UdpClient class using the default constructor.
                  Dim udpClient As New UdpClient()
               ' </Snippet4>  
               Else
               End If ' Do nothing.
            End If
         End If
      End If 
   End Sub 'MyUdpClientConstructor
    ' MyUdpClientConnection method is just used to illustrate the different connection methods of UdpClient class.
   Public Shared Sub MyUdpClientConnection(myConnectionType As String)
      
      If myConnectionType = "HostnameAndPortNumExample" Then
         ' <Snippet5>
         'Uses a host name and port number to establish a socket connection.
         Dim udpClient As New UdpClient()
         Try
            udpClient.Connect("www.contoso.com", 11002)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try
      ' </Snippet5>
      
      Else
         If myConnectionType = "IPAddressAndPortNumExample" Then
            ' <Snippet6>
            'Uses the IP address and port number to establish a socket connection.
            Dim udpClient As New UdpClient()
            Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
            Try
               udpClient.Connect(ipAddress, 11003)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
         ' </Snippet6>
         Else
            If myConnectionType = "RemoteEndPointExample" Then
               ' <Snippet7>
               'Uses a remote endpoint to establish a socket connection.
               Dim udpClient As New UdpClient()
               Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
               Dim ipEndPoint As New IPEndPoint(ipAddress, 11004)
               Try
                  udpClient.Connect(ipEndPoint)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try
            ' </Snippet7>
            Else
            End If ' Do nothing.
         End If
      End If
   End Sub 'MyUdpClientConnection
    
   ' This class demonstrates sending and receiving using a Udp socket.
   Public Shared Sub MyUdpClientCommunicator(mySendType As String)
      
      
      If mySendType = "EndPointExample" Then
         
         ' <Snippet8>
         Dim udpClient As New UdpClient()
         Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
         Dim ipEndPoint As New IPEndPoint(ipAddress, 11004)
         
         Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there?")
         Try
            udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try
      '</Snippet8>
      Else
         If mySendType = "HostNameAndPortNumberExample" Then
            
            '<Snippet9>
            Dim udpClient As New UdpClient()
            
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there")
            Try
               udpClient.Send(sendBytes, sendBytes.Length, "www.contoso.com", 11000)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
         '</Snippet9>
         Else
            If mySendType = "StraightSendExample" Then
               '<Snippet10>
               Dim udpClient As New UdpClient("www.contoso.com", 11000)
               Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there")
               Try
                  udpClient.Send(sendBytes, sendBytes.Length)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try
            '</Snippet10>
            
            Else
            End If ' Do nothing.
         End If
      End If 
      '<Snippet11>
      'Creates a UdpClient for reading incoming data.
      Dim receivingUdpClient As New UdpClient(11000)
      
      'Creates an IPEndPoint to record the IP address and port number of the sender. 
      ' The IPEndPoint will allow you to read datagrams sent from any source.
      Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
      Try
         
         ' Blocks until a message returns on this socket from a remote host.
         Dim receiveBytes As [Byte]() = receivingUdpClient.Receive(RemoteIpEndPoint)
         
         Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
         
         Console.WriteLine(("This is the message you received " + returnData.ToString()))
         Console.WriteLine(("This message was sent from " + RemoteIpEndPoint.Address.ToString() + " on their port number " + RemoteIpEndPoint.Port.ToString()))
      Catch e As Exception
         Console.WriteLine(e.ToString())
      End Try
   End Sub 'MyUdpClientCommunicator
    
   '</Snippet11>
   
   ' This example class demonstrates methods used to join and drop multicast groups.
   Public Shared Sub MyUdpClientMulticastConfiguration(myAction As String)
      
      If myAction = "JoinMultiCastExample" Then
         '<Snippet12>
         Dim udpClient As New UdpClient()
         Dim multicastIpAddress As IPAddress = Dns.Resolve("MulticastGroupName").AddressList(0)
         Try
            udpClient.JoinMulticastGroup(multicastIpAddress)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try
      '</Snippet12>
      Else
         If myAction = "JoinMultiCastWithTimeToLiveExample" Then
            
            '<Snippet13>
            Dim udpClient As New UdpClient()
            ' Creates an IP address to use to join and drop the multicast group.
            Dim multicastIpAddress As IPAddress = IPAddress.Parse("239.255.255.255")
            
            Try
               ' The packet dies after 50 router hops.
               udpClient.JoinMulticastGroup(multicastIpAddress, 50)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
            '</Snippet13>
            '<Snippet14>
            ' Informs the server that you want to remove yourself from the multicast client list.
            Try
               udpClient.DropMulticastGroup(multicastIpAddress)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
            '</Snippet14>
            '<Snippet15>
            ' Closes the UDP client by calling the public method Close().
            udpClient.Close()
         '</Snippet15>
         Else
         End If ' Do nothing.
      End If
   End Sub 'MyUdpClientMulticastConfiguration
   
   
   Public Shared Sub Main()
      
      ' For our example, we will use the default constructor.
      MyUdpClientConstructor("defaultExample")
      MyUdpClientConnection("HostNameAndPortNumExample")
      MyUdpClientCommunicator("EndPointExample")
      MyUdpClientMulticastConfiguration("JoinMultiCastExample")
   End Sub 'Main 
End Class 'MyUdpClientExample

'end class


