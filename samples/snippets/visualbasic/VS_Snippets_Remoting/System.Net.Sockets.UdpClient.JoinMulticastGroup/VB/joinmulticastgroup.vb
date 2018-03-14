 ' File name:multicastOperations.cs
' This example shows how to join a multicast group and perform a muticast 
' data exchange. The OriginatorClient object starts the conversation while 
' the TargetClient responds. The two helper objects Receive and Send 
' perform the actual data exchange. 
' Note. This program cannot be build with the current VS build version.
' Build it via command line. Rubuild it in VS when a suitable version is 
' available.
' <Snippet1>
Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic





' The following Receive class is used by both the ClientOriginator and 
' the ClientTarget class to receive data from one another..

Public Class Receive
   
   ' The following static method performs the actual data
   ' exchange. In particular, it performs the following tasks:
   ' 1)Establishes a communication endpoint.
   ' 2)Receive data through this end point on behalf of the
   ' caller.
   ' 3) Returns the received data in ASCII format.
   Public Shared Function ReceiveUntilStop(c As UdpClient) As String
      Dim strData As [String] = ""
      Dim Ret As [String] = ""
      Dim ASCII As New ASCIIEncoding()
      
      ' Establish the communication endpoint.
      Dim endpoint As New IPEndPoint(IPAddress.IPv6Any, 50)
      
      While Not strData.Equals("Over")
         Dim data As [Byte]() = c.Receive(endpoint)
         strData = ASCII.GetString(data)
         Ret += strData + ControlChars.Lf
      End While
      Return Ret
   End Function 'ReceiveUntilStop
End Class 'Receive

' The following Send class is used by both the ClientOriginator and 
' ClientTarget classes to send data to one another.

Public Class Send
   Private Shared greetings As Char() =  {"H"c, "e"c, "l"c, "l"c, "o"c, " "c, "T"c, "a"c, "r"c, "g"c, "e"c, "t"c, "."c}
   Private Shared nice As Char() =  {"H"c, "a"c, "v"c, "e"c, " "c, "a"c, " "c, "n"c, "i"c, "c"c, "e"c, " "c, "d"c, "a"c, "y"c, "."c}
   Private Shared eom As Char() =  {"O"c, "v"c, "e"c, "r"c}
   
   Private Shared tGreetings As Char() =  {"H"c, "e"c, "l"c, "l"c, "o"c, " "c, "O"c, "r"c, "i"c, "g"c, "i"c, "n"c, "a"c, "t"c, "o"c, "r"c, "!"c}
   Private Shared tNice As Char() =  {"Y"c, "o"c, "u"c, " "c, "t"c, "o"c, "o"c, "."c}
   
   
   ' The following static method sends data to the ClientTarget on 
   ' behalf of the ClientOriginator.
   Public Shared Sub OriginatorSendData(c As UdpClient, ep As IPEndPoint)
      Console.WriteLine(New String(greetings))
      c.Send(GetByteArray(greetings), greetings.Length, ep)
      Thread.Sleep(1000)
      
      Console.WriteLine(New [String](nice))
      c.Send(GetByteArray(nice), nice.Length, ep)
      
      Thread.Sleep(1000)
      Console.WriteLine(New [String](eom))
      c.Send(GetByteArray(eom), eom.Length, ep)
   End Sub 'OriginatorSendData
   
   
   ' The following static method sends data to the ClientOriginator on 
   ' behalf of the ClientTarget.
   Public Shared Sub TargetSendData(c As UdpClient, ep As IPEndPoint)
      Console.WriteLine(New String(tGreetings))
      c.Send(GetByteArray(tGreetings), tGreetings.Length, ep)
      Thread.Sleep(1000)
      
      Console.WriteLine(New [String](tNice))
      c.Send(GetByteArray(tNice), tNice.Length, ep)
      
      Thread.Sleep(1000)
      Console.WriteLine(New [String](eom))
      c.Send(GetByteArray(eom), eom.Length, ep)
   End Sub 'TargetSendData
   
   ' Internal utility 
   Public Shared Function GetByteArray(ChArray() As [Char]) As [Byte]()
      Dim Ret(ChArray.Length) As [Byte]
      
      Dim i As Integer
      For i = 0 To ChArray.Length - 1
         Ret(i) = AscW(ChArray(i))
      Next i 
      Return Ret
   End Function 'GetByteArray

End Class 'Send


' The ClientTarget class is the receiver of the ClientOriginator 
' messages. The StartMulticastConversation method contains the 
' logic for exchanging data between the ClientTarget and its 
' counterpart ClientOriginator in a multicast operation.

Public Class ClientTarget
   Private Shared m_ClientTarget As UdpClient
   Private Shared m_GrpAddr As IPAddress
   
   
   ' The following StartMulticastConversation method connects the UDP 
   ' ClientTarget with the ClientOriginator. 
   ' It performs the following main tasks:
   ' 1)Creates a UDP client to receive data on a specific port and using 
   ' IPv6 addresses. The port is the same one used by the ClientOriginator 
   ' to define its communication endpoint.
   ' 2)Joins or creates a multicast group at the specified address.  
   ' 3)Defines the endpoint port to send data to the ClientOriginator.
   ' 4)Receives data from the ClientOriginator until the end of the 
   ' communication.
   ' 5)Sends data to the ClientOriginator.
   ' Note this method is the counterpart of the 
   ' ClientOriginator.ConnectOriginatorAndTarget().
   Public Shared Sub StartMulticastConversation()
      Dim Ret As String
      
      ' Bind and listen on port 1000. Specify the IPv6 address family type.
      m_ClientTarget = New UdpClient(1000, AddressFamily.InterNetworkV6)
      
      ' Join or create a multicast group
      m_GrpAddr = IPAddress.Parse("FF01::1")
      
      ' Use the overloaded JoinMulticastGroup method.  
      ' Refer to the ClientOriginator method to see how to use the other 
      ' methods.
      m_ClientTarget.JoinMulticastGroup(m_GrpAddr)
      
      ' Define the endpoint data port. Note that this port number
      ' must match the ClientOriginator UDP port number which is the
      ' port on which the ClientOriginator is receiving data.
      Dim ClientOriginatordest As New IPEndPoint(m_GrpAddr, 2000)
      
      ' Receive data from the ClientOriginator.
      Ret = Receive.ReceiveUntilStop(m_ClientTarget)
      Console.WriteLine((ControlChars.Lf + "The ClientTarget received: " + ControlChars.Lf + ControlChars.Lf + Ret + ControlChars.Lf))
      
      ' Done receiving, now respond to the ClientOriginator.
      ' Wait to make sure the ClientOriginator is ready to receive.
      Thread.Sleep(2000)
      
      Console.WriteLine(ControlChars.Lf + "The ClientTarget sent:" + ControlChars.Lf)
      
      Send.TargetSendData(m_ClientTarget, ClientOriginatordest)
      
      ' Exit the multicast conversation. 
      m_ClientTarget.DropMulticastGroup(m_GrpAddr)
   End Sub 'StartMulticastConversation
End Class 'ClientTarget


' The following ClientOriginator class starts the multicast conversation
' with the ClientTarget class.. 
' It performs the following main tasks:
' 1)Creates a socket and binds it to the port on which to communicate.
' 2)Specifies that the connection must use an IPv6 address.
' 3)Joins or create a multicast group. 
'   Note that the multicast address ranges to use are specified 
'   in the RFC#2375. 
' 4)Defines the endpoint to send the data to and starts the 
' client target (ClientTarget) thread.

Public Class ClientOriginator
   Private Shared clientOriginator As UdpClient
   Private Shared m_GrpAddr As IPAddress
   Private Shared m_ClientTargetdest As IPEndPoint
   Private Shared m_t As Thread
   
   
   ' The ConnectOriginatorAndTarget method connects the 
   ' ClientOriginator with the ClientTarget.
   ' It performs the following main tasks:
   ' 1)Creates a UDP client to receive data on a specific port 
   '   using IPv6 addresses. 
   ' 2)Joins or create a multicast group at the specified address.  
   ' 3)Defines the endpoint port to send data to on the ClientTarget.
   ' 4)Starts the ClientTarget thread that also creates the ClientTarget object.
   ' Note this method is the counterpart of the 
   ' ClientTarget.StartMulticastConversation().
   Public Shared Function ConnectOriginatorAndTarget() As Boolean
      Try
         ' <Snippet3>
         ' Bind and listen on port 2000. This constructor creates a socket 
         ' and binds it to the port on which to receive data. The family 
         ' parameter specifies that this connection uses an IPv6 address.
         clientOriginator = New UdpClient(2000, AddressFamily.InterNetworkV6)
         
         ' Join or create a multicast group. The multicast address ranges 
         ' to use are specified in RFC#2375. You are free to use 
         ' different addresses.
         ' Transform the string address into the internal format.
         m_GrpAddr = IPAddress.Parse("FF01::1")
         
         ' Display the multicast address used.
         Console.WriteLine(("Multicast Address: [" + m_GrpAddr.ToString() + "]"))
         
         ' <Snippet4>
         ' Exercise the use of the IPv6MulticastOption.
         Console.WriteLine("Instantiate IPv6MulticastOption(IPAddress)")
         
         ' Instantiate IPv6MulticastOption using one of the 
         ' overloaded constructors.
         Dim ipv6MulticastOption As New IPv6MulticastOption(m_GrpAddr)
         
         ' Store the IPAdress multicast options.
         Dim group As IPAddress = ipv6MulticastOption.Group
         Dim interfaceIndex As Long = ipv6MulticastOption.InterfaceIndex
         
         ' Display IPv6MulticastOption properties.
         Console.WriteLine(("IPv6MulticastOption.Group: [" + group.ToString() + "]"))
         Console.WriteLine(("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex.ToString() + "]"))
         
         ' </Snippet4>
         ' <Snippet5>
         ' Instantiate IPv6MulticastOption using another 
         ' overloaded constructor.
         Dim ipv6MulticastOption2 As New IPv6MulticastOption(group, interfaceIndex)
         
         ' Store the IPAdress multicast options.
         group = ipv6MulticastOption2.Group
         interfaceIndex = ipv6MulticastOption2.InterfaceIndex
         
         ' Display the IPv6MulticastOption2 properties.
         Console.WriteLine(("IPv6MulticastOption.Group: [" + group.ToString() + "]"))
         Console.WriteLine(("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex.ToString() + "]"))
         
         ' Join the specified multicast group using one of the 
         ' JoinMulticastGroup overloaded methods.
         clientOriginator.JoinMulticastGroup(Fix(interfaceIndex), group)
         
         ' </Snippet5>
         ' Define the endpoint data port. Note that this port number
         ' must match the ClientTarget UDP port number which is the
         ' port on which the ClientTarget is receiving data.
         m_ClientTargetdest = New IPEndPoint(m_GrpAddr, 1000)
         
         ' </Snippet3>
         ' Start the ClientTarget thread so it is ready to receive.
         m_t = New Thread(New ThreadStart(AddressOf ClientTarget.StartMulticastConversation))
         m_t.Start()
         
         ' Make sure that the thread has started.
         Thread.Sleep(2000)
         
         Return True
      Catch e As Exception
         Console.WriteLine(("[ClientOriginator.ConnectClients] Exception: " + e.ToString()))
         Return False
      End Try
   End Function 'ConnectOriginatorAndTarget
   
   
   ' The SendAndReceive performs the data exchange  
   ' between the ClientOriginator and the ClientTarget classes.
   Public Shared Function SendAndReceive() As String
      Dim Ret As String = ""
      
      ' <Snippet2>
      ' Send data to ClientTarget.
      Console.WriteLine(ControlChars.Lf + "The ClientOriginator sent:" + ControlChars.Lf)
      Send.OriginatorSendData(clientOriginator, m_ClientTargetdest)
      
      ' Receive data from ClientTarget
      Ret = Receive.ReceiveUntilStop(clientOriginator)
      
      ' Stop the ClientTarget thread
      m_t.Abort()
      
      ' Abandon the multicast group.
      clientOriginator.DropMulticastGroup(m_GrpAddr)
      
      ' </Snippet2>
      Return Ret
   End Function 'SendAndReceive
   
   
   'This is the console application entry point.
   Public Shared Sub Main()
      ' Join the multicast group.
      If ConnectOriginatorAndTarget() Then
         ' Perform a multicast conversation with the ClientTarget.
         Dim Ret As String = SendAndReceive()
         Console.WriteLine((ControlChars.Lf + "The ClientOriginator received: " + ControlChars.Lf + ControlChars.Lf + Ret))
      Else
         Console.WriteLine("Unable to Join the multicast group")
      End If
   End Sub 'Main
End Class 'ClientOriginator
' </Snippet1>