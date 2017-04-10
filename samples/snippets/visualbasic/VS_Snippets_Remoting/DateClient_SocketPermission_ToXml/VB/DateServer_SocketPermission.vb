 '
'  This program demonstrates the 'AcceptList' property  of 'SocketPermission' class.
'
'  This program provides a class called 'DateServer' that functions as a server 
'  for a 'DateClient'. A 'DateServer' is a server that provides the current date on
'  the server in response to a request from a client. The 'DateServer' class 
'  provides a method called 'Create' which waits for client connections and sends
'  the current date on that socket connection. Within the 'Create' method of
'  'DateServer' class an instance of 'SocketPermission' is created with the 
'  'SocketPermission(NetworkAccess, TransportType, string, int)' constructor.
'  If the calling method has the requisite permissions the 'Create' method waits 
'  for client connections and sends the current date on the socket connection.
'
'

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Security
Imports System.Collections
Imports Microsoft.VisualBasic


Public Class DateServer
    
    'Client connecting to the date server.
    Private clientSocket As Socket
    Private serverSocket As Socket
    Private asciiEncoding As Encoding
    
    Public serverBacklog As Integer
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    
    Overloads Public Shared Sub Main(args() As [String])
        If args.Length <> 2 Then
            PrintUsage()
            Return
        End If
        Dim server As New DateServer()
        Try
            server.Create(args(1))
        Catch securityException As SecurityException
            Console.WriteLine("SecurityException caught !!!")
            Console.WriteLine(("Message : " + securityException.Message))
        Catch exception As Exception
            Console.WriteLine("Exception caught !!!")
            Console.WriteLine(("Message " + exception.Message))
        End Try
    End Sub 'Main
    
    
    Public Sub New()
        asciiEncoding = Encoding.ASCII
        serverSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        serverBacklog = 10
    End Sub 'New
    
    
    'Return the current date on the client connection.
    Public Function Create(portString As [String]) As Boolean       
        'Create another 'SocketPermission' object with two ip addresses.
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim socketPermission As New SocketPermission(NetworkAccess.Accept, TransportType.All, "192.168.144.238", SocketPermission.AllPorts)
        
        
        'Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
        socketPermission.AddPermission(NetworkAccess.Accept, TransportType.All, "192.168.144.239", SocketPermission.AllPorts)
        
        Console.WriteLine("Display result of AcceptList property : ")
        Dim enumerator As IEnumerator = socketPermission.AcceptList
        While enumerator.MoveNext()
            Console.WriteLine("The hostname is       : {0}", CType(enumerator.Current, EndpointPermission).Hostname)
            Console.WriteLine("The port is           : {0}", CType(enumerator.Current, EndpointPermission).Port)
            Console.WriteLine("The Transport type is : {0}", CType(enumerator.Current, EndpointPermission).Transport)
        End While
        
        'Demand for the calling method for requisite socket permissions.
        socketPermission.Demand() 
        serverSocket.Bind(New IPEndPoint(Dns.Resolve(Dns.GetHostName()).AddressList(0), Int16.Parse(portString)))
        serverSocket.Listen(serverBacklog)
        While True
            Try
                clientSocket = serverSocket.Accept()
                Dim sendByte As Byte() = asciiEncoding.GetBytes(DateTime.Now.ToString())
                clientSocket.Send(sendByte, sendByte.Length, 0)
                clientSocket.Close()
            Catch e As Exception
                Console.WriteLine(ControlChars.Cr + "Exception raised : {0}", e.Message)
                Return False
            End Try
        End While
    End Function 'Create
    
    
    Public Shared Sub PrintUsage()
        Console.WriteLine("Usage : DateServer_SocketPermission")
        Console.WriteLine(ControlChars.Tab + "DateServer_SocketPermission " + ChrW(60) + "port" + ChrW(62))
        Console.WriteLine(ControlChars.Tab + "port is the port on which the DateServer is listening")
    End Sub 'PrintUsage
End Class 'DateServer