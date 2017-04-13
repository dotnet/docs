Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports Microsoft.VisualBasic

Public Class Sync_Send_Receive


    Public Shared Sub SetSocketOptions()

        Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
        Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)

        Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

        '<Snippet1>
        'Send operations will time-out if confirmation is 
        ' not received within 1000 milliseconds.
        s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000)

        ' The socket will linger for 10 seconds after Socket.Close is called.
        Dim lingerOption As New LingerOption(True, 10)
        s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption)

        '</Snippet1>                  
        s.Connect(lep)
        Dim msg As Byte() = Encoding.ASCII.GetBytes("This is a test")

        '<Snippet2>
        Console.WriteLine(("This application will timeout if Send does not return within " + Encoding.ASCII.GetString(s.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 4))))
        ' blocks until send returns
        Dim i As Integer = s.Send(msg)

        ' blocks until read returns
        Dim bytes(1024) As Byte
        s.Receive(bytes)

        'Display to the screen
        Console.WriteLine(Encoding.ASCII.GetString(bytes))
        s.Shutdown(SocketShutdown.Both)

        Console.WriteLine(("If data remains to be sent, this application will stay open for " + CType(s.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger), LingerOption).LingerTime.ToString()))
        s.Close()
    End Sub 'SetSocketOptions
    '</Snippet2>

    Public Shared Sub CheckProperties()

        Dim lipa As IPHostEntry = Dns.Resolve("host.contoso.com")
        Dim lep As New IPEndPoint(lipa.AddressList(0), 11000)


        '<Snippet3>
        Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

        'Using the AddressFamily, SocketType, and ProtocolType properties.
        Console.WriteLine(("I just set the following properties of socket: " + "Address Family = " + s.AddressFamily.ToString() + ControlChars.Cr + "SocketType = " + s.SocketType.ToString() + ControlChars.Cr + "ProtocolType = " + s.ProtocolType.ToString()))

        '</Snippet3>
        '<Snippet4>
        s.Connect(lep)

        ' Using the RemoteEndPoint property.
        Console.WriteLine("I am connected to ")
        Console.WriteLine(IPAddress.Parse(CType(s.RemoteEndPoint, IPEndPoint).Address.ToString()))
        Console.WriteLine("on port number ")
        Console.WriteLine(CType(s.RemoteEndPoint, IPEndPoint).Port.ToString())

        ' Using the LocalEndPoint property.
        Console.WriteLine("My local IpAddress is :")
        Console.WriteLine(IPAddress.Parse(CType(s.LocalEndPoint, IPEndPoint).Address.ToString()))
        Console.WriteLine("I am connected on port number ")
        Console.WriteLine(CType(s.LocalEndPoint, IPEndPoint).Port.ToString())

        '</Snippet4>
        '<Snippet5>
        'Use low level method IOControl to set this socket to blocking mode.
        Dim code As Integer = Uri.FromHex("0x8004667E")
        '
        'ToDo: Error processing original source shown below
        '
        '
        'GenCode(token): unexpected token type

        Dim inBuf(4) As Byte
        inBuf(0) = 0
        Dim outBuf(4) As Byte
        s.IOControl(code, inBuf, outBuf)
        'Check to see that this worked.
        If s.Blocking Then
            Console.WriteLine("Socket was set to Blocking mode successfully")
        End If
    End Sub 'CheckProperties
    '</Snippet5>

    Public Shared Sub Main()
    End Sub 'Main
End Class 'Sync_Send_Receive 
