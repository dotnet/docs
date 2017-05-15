' <Internal>
' This program contains snippets for the following members:
' 1) System.Net.Sockets.MulticastOption;
' 2) System.Net.Sockets.MulticastOption.MulticastOption(IPAddress, IPAddress);
' 3) System.Net.Sockets.MulticastOption.Group;
' 4) System.Net.Sockets.MulticastOption.LocalAddress;
' </Internal>

'<Snippet1>
' This is the listener example that shows how to use the MulticastOption class. 
' In particular, it shows how to use the MulticastOption(IPAddress, IPAddress) 
' constructor, which you need to use if you have a host with more than one 
' network card.
' The first parameter specifies the multicast group address, and the second 
' specifies the local address of the network card you want to use for the data
' exchange.
' You must run this program in conjunction with the sender program as 
' follows:
' Open a console window and run the listener from the command line. 
' In another console window run the sender. In both cases you must specify 
' the local IPAddress to use. To obtain this address run the ipconfig comand 
' from the command line. 


Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic


Namespace Mssc.TransportProtocols.Utilities

  Module M_TestMulticastOption

    Public Class TestMulticastOption

      Private Shared mcastAddress As IPAddress
      Private Shared mcastPort As Integer
      Private Shared mcastSocket As Socket
      Private Shared mcastOption As MulticastOption


      ' <Snippet3>
      Private Shared Sub MulticastOptionProperties()
        Console.WriteLine(("Current multicast group is: " + mcastOption.Group.ToString()))
        Console.WriteLine(("Current multicast local address is: " + mcastOption.LocalAddress.ToString()))
      End Sub 'MulticastOptionProperties


      ' </Snippet3>
      Private Shared Sub StartMulticast()

        Try
          mcastSocket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

          Console.Write("Enter the local IP address: ")

          Dim localIPAddr As IPAddress = IPAddress.Parse(Console.ReadLine())

          'IPAddress localIP = IPAddress.Any;
          Dim localEP As EndPoint = CType(New IPEndPoint(localIPAddr, mcastPort), EndPoint)

          mcastSocket.Bind(localEP)

          ' <Snippet2>
          ' Define a MulticastOption object specifying the multicast group 
          ' address and the local IPAddress.
          ' The multicast group address is the same as the address used by the server.
          mcastOption = New MulticastOption(mcastAddress, localIPAddr)

          mcastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mcastOption)
          ' </Snippet2>

        Catch e As Exception
          Console.WriteLine(e.ToString())
        End Try
      End Sub 'StartMulticast


      Private Shared Sub ReceiveBroadcastMessages()
        Dim done As Boolean = False
        Dim bytes() As Byte = New [Byte](99) {}
        Dim groupEP As New IPEndPoint(mcastAddress, mcastPort)
        Dim remoteEP As EndPoint = CType(New IPEndPoint(IPAddress.Any, 0), EndPoint)


        Try
          While Not done
            Console.WriteLine("Waiting for multicast packets.......")
            Console.WriteLine("Enter ^C to terminate.")

            mcastSocket.ReceiveFrom(bytes, remoteEP)

            Console.WriteLine("Received broadcast from {0} :" + ControlChars.Lf + " {1}" + ControlChars.Lf, groupEP.ToString(), Encoding.ASCII.GetString(bytes, 0, bytes.Length))
          End While



          mcastSocket.Close()

        Catch e As Exception
          Console.WriteLine(e.ToString())
        End Try
      End Sub 'ReceiveBrodcastMessages


      Public Shared Sub Main(ByVal args() As String)
        ' Initialize the multicast address group and multicast port.
        ' Both address and port are selected from the allowed sets as
        ' defined in the related RFC documents. These are the same
        ' as the values used by the sender.
        mcastAddress = IPAddress.Parse("224.168.100.2")
        mcastPort = 11000

        ' Start a multicast group.
        StartMulticast()

        ' Display MulticastOption properties.
        MulticastOptionProperties()

        ' Receive broadcast messages.
        ReceiveBroadcastMessages()
      End Sub 'Main
    End Class 'TestMulticastOption

  End Module

End Namespace
' </Snippet1>
