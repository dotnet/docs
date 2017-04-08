' <Internal>
' This program contains snippets for the following members:
' 1) System.Net.Sockets.MulticastOption;
' </Internal>
' <Snippet1>
' This sender example must be used in conjunction with the listener program.
' You must run this program as follows:
' Open a console window and run the listener from the command line. 
' In another console window run the sender. In both cases you must specify 
' the local IPAddress to use. To obtain this address, run the ipconfig command
' from the command line. 
'  
Imports System
Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic

Namespace Mssc.TransportProtocols.Utilities

  Module M_TestMulticastOption

    Class TestMulticastOption

      Private Shared mcastAddress As IPAddress
      Private Shared mcastPort As Integer
      Private Shared mcastSocket As Socket


      Shared Sub JoinMulticastGroup()
        Try
          ' Create a multicast socket.
          mcastSocket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

          ' Get the local IP address used by the listener and the sender to
          ' exchange multicast messages. 
          Console.Write(ControlChars.Lf + "Enter local IPAddress for sending multicast packets: ")
          Dim localIPAddr As IPAddress = IPAddress.Parse(Console.ReadLine())

          ' Create an IPEndPoint object. 
          Dim IPlocal As New IPEndPoint(localIPAddr, 0)

          ' Bind this endpoint to the multicast socket.
          mcastSocket.Bind(IPlocal)

          ' Define a MulticastOption object specifying the multicast group 
          ' address and the local IP address.
          ' The multicast group address is the same as the address used by the listener.
          Dim mcastOption As MulticastOption
          mcastOption = New MulticastOption(mcastAddress, localIPAddr)

          mcastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mcastOption)

        Catch e As Exception
          Console.WriteLine((ControlChars.Lf + e.ToString()))
        End Try
      End Sub 'JoinMulticast


      Shared Sub BroadcastMessage(ByVal message As String)
        Dim endPoint As IPEndPoint

        Try
          'Send multicast packets to the listener.
          endPoint = New IPEndPoint(mcastAddress, mcastPort)
          mcastSocket.SendTo(ASCIIEncoding.ASCII.GetBytes(message), endPoint)
          Console.WriteLine("Multicast data sent.....")
        Catch e As Exception
          Console.WriteLine((ControlChars.Lf + e.ToString()))
        End Try

        mcastSocket.Close()
      End Sub 'BrodcastMessage


      Public Shared Sub Main(ByVal args() As String)
        ' Initialize the multicast address group and multicast port.
        ' Both address and port are selected from the allowed sets as
        ' defined in the related RFC documents. These are the same as the 
        ' values used by the sender.
        mcastAddress = IPAddress.Parse("224.168.100.2")
        mcastPort = 11000

        ' Join the listener multicast group.
        JoinMulticastGroup()

        ' Broadcast the message to the listener.
        BroadcastMessage("Hello multicast listener.")
      End Sub 'Main
    End Class 'TestMulticastOption

  End Module

End Namespace
' </Snippet1>
