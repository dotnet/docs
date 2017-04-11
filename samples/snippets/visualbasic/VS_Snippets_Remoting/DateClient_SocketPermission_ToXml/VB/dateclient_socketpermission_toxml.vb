 '
'  This program demonstrates the 'ToXml' and 'IsUnrestricted' method and 'ConnectList' property of 
'  'SocketPermission' class.
'  
'  This program provides a class called 'DateClient' that functions as a client
'  for a 'DateServer'. A 'DateServer' is a server that provides the current date on
'  the server in response to a request from a client. The 'DateClient' class 
'  provides a method called 'GetDate' which returns the current date on the server.
'  The 'GetDate' is the method that shows the use of 'SocketPermission' class. An
'  instance of 'SocketPermission' is obtained using the 'FromXml' method. Another
'  instance of 'SocketPermission' is created with the 'SocketPermission(NetworkAccess,
'   TransportType, string, int)' constructor. A third 'SocketPermission' object is 
'  formed from the union of the above two 'SocketPermission' objects with the use of the
'  'Union' method of 'SocketPermission' class . This 'SocketPermission' object is used by
'  the 'GetDate' method to verify the permissions of the calling method. If the calling 
'  method has the requisite permissions the 'GetDate' method connects to the 'DateServer'
'  and returns the current date that the 'DateServer' sends. If any exception occurs
'  the 'GetDate' method returns an empty string.
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
    Public Sub New(serverIpAddress As IPAddress, port As Integer)
        serverAddress = serverIpAddress
        serverPort = port
        serverSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        asciiEncoding = Encoding.ASCII
    End Sub 'New
    
    
    'Print a security element and all its children, in a depth-first manner.
    Private Sub PrintSecurityElement(securityElementObj As SecurityElement, depth As Integer)
        
        Console.WriteLine("Depth    : {0}", depth)
        Console.WriteLine("Tag      : {0}", securityElementObj.Tag)
        Console.WriteLine("Text     : {0}", securityElementObj.Text)
        If Not (securityElementObj.Children Is Nothing) Then
            Console.WriteLine("Children : {0}", securityElementObj.Children.Count)
        End If 
        If Not (securityElementObj.Attributes Is Nothing) Then
            Dim attributeEnumerator As IEnumerator = securityElementObj.Attributes.GetEnumerator()
            While attributeEnumerator.MoveNext()
                Console.WriteLine("Attribute - ""{0}"" , Value - ""{1}""", CType(attributeEnumerator, IDictionaryEnumerator).Key, CType(attributeEnumerator, IDictionaryEnumerator).Value)
            End While
        End If
        
        Console.WriteLine("")
        
        If Not (securityElementObj.Children Is Nothing) Then
            depth += 1
            Dim i As Integer
            For i = 0 To securityElementObj.Children.Count - 1
                PrintSecurityElement(CType(securityElementObj.Children(i), SecurityElement), depth)
            Next i
        End If
    End Sub 'PrintSecurityElement
     
    Public Function GetDate() As [String]
' <Snippet1>
' <Snippet2>
' <Snippet3>

	Dim socketPermission1 As New SocketPermission(PermissionState.Unrestricted)
	
        'Create a 'SocketPermission' object for two ip addresses.
        Dim socketPermission2 As New SocketPermission(PermissionState.None)
        Dim securityElement4 As SecurityElement = socketPermission2.ToXml()
        ''SocketPermission' object for 'Connect' permission
        Dim securityElement1 As New SecurityElement("ConnectAccess")
        'Format to specify ip address are <ip-address>#<port>#<transport-type>
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim securityElement2 As New SecurityElement("URI", "192.168.144.238#-1#3")
        'Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
        Dim securityElement3 As New SecurityElement("URI", "192.168.144.240#-1#3")
        securityElement1.AddChild(securityElement2)
        securityElement1.AddChild(securityElement3)
        securityElement4.AddChild(securityElement1)
        
        'Obtain a 'SocketPermission' object using 'FromXml' method.	
        socketPermission2.FromXml(securityElement4)
        
        'Create another 'SocketPermission' object with two ip addresses.
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim socketPermission3 As New SocketPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.238", SocketPermission.AllPorts)
        
        'Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
        socketPermission3.AddPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.239", SocketPermission.AllPorts)

        Console.WriteLine(ControlChars.Cr + "Checks the Socket permissions using IsUnrestricted method : ")
        If socketPermission1.IsUnrestricted() Then
            Console.WriteLine("Socket permission is unrestricted")
        Else
            Console.WriteLine("Socket permission is restricted")
        End If 
        Console.WriteLine()
        
        Console.WriteLine("Display result of ConnectList property : " + ControlChars.Cr)
        Dim enumerator As IEnumerator = socketPermission3.ConnectList
        While enumerator.MoveNext()
            Console.WriteLine("The hostname is       : {0}", CType(enumerator.Current, EndpointPermission).Hostname)
            Console.WriteLine("The port is           : {0}", CType(enumerator.Current, EndpointPermission).Port)
            Console.WriteLine("The Transport type is : {0}", CType(enumerator.Current, EndpointPermission).Transport)
        End While
        
        Console.WriteLine("")
        
        Console.WriteLine("Display Security Elements :" + ControlChars.Cr + " ")
        PrintSecurityElement(socketPermission2.ToXml(), 0)
        
        'Get a 'SocketPermission' object which is a union of two other 'SocketPermission' objects.
        socketPermission1 = CType(socketPermission3.Union(socketPermission2), SocketPermission)
        
        'Demand that the calling method have the socket permission.
        socketPermission1.Demand()
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
        Console.WriteLine("Usage : DateClient_SocketPermission_ToXml")
        Console.WriteLine(ControlChars.Tab + "DateClient_SocketPermission_ToXml " + ChrW(60) + "ipaddress" + ChrW(62) + " " + ChrW(60) + "port" + ChrW(62))
        Console.WriteLine(ControlChars.Tab + "The ipaddress argument is the ip address of the Date server.")
        Console.WriteLine(ControlChars.Tab + "The port argument is the port of the Date server.")
    End Sub 'PrintUsage
End Class 'UserDateClient