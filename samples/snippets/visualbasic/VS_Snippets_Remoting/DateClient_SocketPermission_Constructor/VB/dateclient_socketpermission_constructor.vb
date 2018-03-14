 '
'  This program demonstrates the 'SocketPermission(PermissionState)', 
'  'SocketPermission(NetworkAccess, TransportType, string, int) constructors,
'  'FromXml', 'Intersect', 'AddPermission' methods and 'AllPorts' field
'  of 'SocketPermission' class.
'  
'  This program provides a class called 'DateClient' that functions as a client
'  for a 'DateServer'. A 'DateServer' is a server that provides the current date on
'  the server in response to a request from a client. The 'DateClient' class 
'  provides a method called 'GetDate' which returns the current date on the server.
'  The 'GetDate' is the method that shows the use of 'SocketPermission' class. An
'  instance of 'SocketPermission' is obtained using the 'FromXml' method. Another
'  instance of 'SocketPermission' is created with the 'SocketPermission(NetworkAccess,
'   TransportType, string, int)' constructor. A third 'SocketPermission' object is 
'  formed from the intersection of the above two 'SocketPermission' objects with the
'  use of the 'Intersect' method of 'SocketPermission' class. This 'SocketPermission'
'  object is used by the 'GetDate' method to verify the permissions of the calling
'  method. If the calling method has the requisite permissions the 'GetDate' method
'  connects to the 'DateServer' and returns the current date that the 'DateServer'
'  sends. If any exception occurs the 'GetDate' method returns an empty string.
'
'  Note: This program requires 'DateServer_SocketPermission' program executing. 
'

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Collections
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.VisualBasic


Public Class DateClient
    
    Private serverSocket As Socket
    Private asciiEncoding As Encoding
    Private serverAddress As IPAddress
    
    Private serverPort As Integer
    
    
    'The constructor takes the address and port of the remote server.
    Public Sub New(ipAddress As IPAddress, port As Integer)
        serverAddress = ipAddress
        serverPort = port
        serverSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        asciiEncoding = Encoding.ASCII
    End Sub 'New
    
    
    Public Function GetDate() As [String]
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>        

        Dim socketPermission1 As New SocketPermission(PermissionState.Unrestricted)
        
        'Create a 'SocketPermission' object for two ip addresses.
        Dim socketPermission2 As New SocketPermission(PermissionState.None)
        Dim securityElement1 As SecurityElement = socketPermission2.ToXml()
        ''SocketPermission' object for 'Connect' permission
        Dim securityElement2 As New SecurityElement("ConnectAccess")
        'Format to specify ip address are <ip-address>#<port>#<transport-type>
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All'
        ' ports for the ip-address.
        Dim securityElement3 As New SecurityElement("URI", "192.168.144.238#-1#3")
        'Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
        Dim securityElement4 As New SecurityElement("URI", "192.168.144.240#-1#3")
        securityElement2.AddChild(securityElement3)
        securityElement2.AddChild(securityElement4)
        securityElement1.AddChild(securityElement2)
        

        'Obtain a 'SocketPermission' object using 'FromXml' method.
        socketPermission2.FromXml(securityElement1)
        
        Console.WriteLine(ControlChars.Cr + "Displays the result of FromXml method : " + ControlChars.Cr)
        Console.WriteLine(socketPermission2.ToString())
        
        'Create another 'SocketPermission' object with two ip addresses.
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim socketPermission3 As New SocketPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.238", SocketPermission.AllPorts)
        
        'Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
        socketPermission3.AddPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.239", SocketPermission.AllPorts)
        
        Console.WriteLine("Displays the result of AddPermission method : " + ControlChars.Cr)
        Console.WriteLine(socketPermission3.ToString())
        
        'Find the intersection between two 'SocketPermission' objects.
        socketPermission1 = CType(socketPermission2.Intersect(socketPermission3), SocketPermission)
        
        Console.WriteLine("Displays the result of Intersect method :" + ControlChars.Cr + " ")
        Console.WriteLine(socketPermission1.ToString())
        'Demand that the calling method have the requsite socket permission.
        socketPermission1.Demand()
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>
	'Get the current date from the remote date server.
        Try
            Dim bytesReceived As Integer
            Dim getByte(100) As Byte
            serverSocket.Connect(New IPEndPoint(serverAddress, serverPort))
            bytesReceived = serverSocket.Receive(getByte, getByte.Length, 0)
            Return asciiEncoding.GetString(getByte, 0, bytesReceived)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception raised : {0}", e.Message)
            Return ""
        End Try
    End Function 'GetDate
End Class 'DateClient


'This class is used to demonstrate the caller of the 'GetDate' method for the 'DateClient' object.
Public Class UserDateClient
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    
    Overloads Public Shared Sub Main(args() As [String])
        If args.Length <> 3 Then
            PrintUsage()
            Return
        End If
        Try
            Dim myDateClient As New DateClient(IPAddress.Parse(args(1)), Int32.Parse(args(2)))
            Dim currentDate As [String] = myDateClient.GetDate()
            Console.WriteLine("The current date and time is : ")
            Console.WriteLine("{0}", currentDate)
        'This exception is thrown by the called method in the context of improper permissions.
        Catch e As SecurityException
            Console.WriteLine(ControlChars.Cr + "SecurityException raised : {0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception raised : {0}", e.Message)
        End Try
    End Sub 'Main
    
    
    Private Shared Sub PrintUsage()
        Console.WriteLine("Usage : DateClient_SocketPermission_Constructor")
        Console.WriteLine(ControlChars.Tab + "DateClient_SocketPermission_Constructor " + ChrW(60) + "ipaddress" + ChrW(62) + " " + ChrW(60) + "port" + ChrW(62))
        Console.WriteLine(ControlChars.Tab + "The ipaddress argument is the ip address of the Date server.")
        Console.WriteLine(ControlChars.Tab + "The port argument is the port of the Date server.")
    End Sub 'PrintUsage
End Class 'UserDateClient