 ' File name:ipendpoint.cs.
' <Internal>
' This program contains snippets applicable to the following:
' System.Net.IPEndPoint (Snippet1);  
' System.Net.IPEndPoint.IPEndPoint(IPAddress, int) (Snippet2);
' System.Net.IPEndPoint.Address (Snippet3);
' System.Net.IPEndPoint.AddressFamily (Snippet3);
' System.Net.IPEndPoint.Port (Snippet3);
' System.Net.IPEndPoint.Serialize (Snippet4);
' System.Net.IPEndPoint.Create (Snippet5);
' </Internal>

'<Snippet1>
' This example uses the IPEndPoint class and its members to display the home page 
' of the server selected by the user.

Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text.RegularExpressions

Namespace Mssc.Services.ConnectionManagement
  Module M_TestIPEndPoint


    Public Class TestIPEndPoint

	'The getPage method gets the server's home page content by 
    	'recreating the server's endpoint from the original serialized endpoint.
    	'Then it creates a new socket and connects it to the endpoint.
      Private Shared Function getPage(ByVal server As String, ByVal socketAddress As SocketAddress) As String
        'Set up variables and String to write to the server.
        Dim ASCII As Encoding = Encoding.ASCII
        Dim [Get] As String = "GET / HTTP/1.1" + ControlChars.Cr + ControlChars.Lf + "Host: " + server + ControlChars.Cr + ControlChars.Lf + "Connection: Close" + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf
        Dim ByteGet As [Byte]() = ASCII.GetBytes([Get])
        Dim RecvBytes(255) As [Byte]
        Dim strRetPage As [String] = Nothing

        Dim socket As Socket = Nothing

        '<Snippet5>
        ' Recreate the connection endpoint from the serialized information.
        Dim endpoint As New IPEndPoint(0, 0)
        Dim clonedIPEndPoint As IPEndPoint = CType(endpoint.Create(socketAddress), IPEndPoint)
        Console.WriteLine(("clonedIPEndPoint: " + clonedIPEndPoint.ToString()))
        '</Snippet5>
        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()

        Try
          ' Create a socket object to establish a connection with the server.
          socket = New Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

          ' Connect to the cloned end point.
          socket.Connect(clonedIPEndPoint)
        Catch e As SocketException
          Console.WriteLine(("Source : " + e.Source))
          Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
          Console.WriteLine(("Source : " + e.Source))
          Console.WriteLine(("Message : " + e.Message))
        End Try

        If socket Is Nothing Then
          Return "Connection to cloned endpoint failed"
        End If
        ' Send request to the server.
        socket.Send(ByteGet, ByteGet.Length, 0)

        ' Receive the server  home page content.
        Dim bytes As Int32 = socket.Receive(RecvBytes, RecvBytes.Length, 0)

        ' Read the first 256 bytes.
        strRetPage = "Default HTML page on " + server + ":" + ControlChars.Cr + ControlChars.Lf
        strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes)

        While bytes > 0
          bytes = socket.Receive(RecvBytes, RecvBytes.Length, 0)
          strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes)
        End While

        socket.Close()

        Return strRetPage
      End Function 'getPage


      '<Snippet4>
      ' The serializeEndpoint method serializes the endpoint and returns the 
      ' SocketAddress containing the serialized endpoint data.
      Private Shared Function serializeEndpoint(ByVal endpoint As IPEndPoint) As SocketAddress

        ' Serialize IPEndPoint details to a SocketAddress instance.
        Dim socketAddress As SocketAddress = endpoint.Serialize()

        ' Display the serialized endpoint information.
        Console.WriteLine("Endpoint Serialize() : " + socketAddress.ToString())

        Console.WriteLine("Socket Family : " + socketAddress.Family.ToString())
        Console.WriteLine("Socket Size : " + socketAddress.ToString())

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()

        Return socketAddress
      End Function 'serializeEndpoint

      '</Snippet4>
      '<Snippet3>
      Private Shared Sub displayEndpointInfo(ByVal endpoint As IPEndPoint)
        Console.WriteLine("Endpoint Address : " + endpoint.Address.ToString())
        Console.WriteLine("Endpoint AddressFamily : " + endpoint.AddressFamily.ToString())
        Console.WriteLine("Endpoint Port : " + endpoint.Port.ToString())
        Console.WriteLine("Endpoint ToString() : " + endpoint.ToString())

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()
      End Sub 'displayEndpointInfo

      '</Snippet3>
      ' The following method determines the server endpoint and then 
      ' serializes it to obtain the related SocketAddress object.
      ' Note that in the for loop a temporary socket is created to ensure that 
      ' the current IP address format matches the AddressFamily type.
      ' In fact, in the case of servers supporting both IPv4 and IPv6, an exception 
      ' may arise if an IP address format does not match the address family type.
      Private Shared Function getSocketAddress(ByVal server As String, ByVal port As Integer) As SocketAddress
        Dim tempSocket As Socket = Nothing
        Dim host As IPHostEntry = Nothing
        Dim serializedSocketAddress As SocketAddress = Nothing

        Try
          ' Get the object containing Internet host information.
          host = Dns.Resolve(server)

          ' <Snippet2>
          ' Obtain the IP address from the list of IP addresses associated with the server.
          Dim address As IPAddress
          For Each address In host.AddressList
            Dim endpoint As New IPEndPoint(address, port)


            tempSocket = New Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

            tempSocket.Connect(endpoint)

            If tempSocket.Connected Then
              ' Display the endpoint information.
              displayEndpointInfo(endpoint)
              ' Serialize the endpoint to obtain a SocketAddress object.
              serializedSocketAddress = serializeEndpoint(endpoint)
              Exit For

            End If

          Next address

          ' </Snippet2>

          'Close the temporary socket.
          tempSocket.Close()

        Catch e As SocketException
          Console.WriteLine(("Source : " + e.Source))
          Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
          Console.WriteLine(("Source : " + e.Source))
          Console.WriteLine(("Message : " + e.Message))
        End Try

        Return serializedSocketAddress

      End Function 'getSocketAddress



      ' The requestServerHomePage obtains the server's home page and returns
      ' its content.
      Private Shared Function requestServerHomePage(ByVal server As String, ByVal port As Integer) As String
        Dim strRetPage As [String] = Nothing

        ' Get a socket address using the specified server and port.
        Dim socketAddress As SocketAddress = getSocketAddress(server, port)

        If socketAddress Is Nothing Then
          strRetPage = "Connection failed"
          ' Obtain the server's home page content.
        Else
          strRetPage = getPage(server, socketAddress)
        End If
        Return strRetPage
      End Function 'requestServerHomePage


      ' Show to the user how to use this program when wrong input parameters are entered.
      Private Shared Sub showusage()
        Console.WriteLine("Enter the server name as follows:")
        Console.WriteLine(ControlChars.Tab + "vb_ipendpoint servername")
      End Sub 'showusage

      ' This is the program entry point. It allows the user to enter 
      ' a server name that is used to locate its current homepage.
      Public Shared Sub Main(ByVal args() As String)
        Dim host As String = Nothing
        Dim port As Integer = 80

        'Define a regular expression to parse user's input.
        'This is a security check. It allows only
        'alphanumeric input string between 2 to 40 character long.
        Dim rex As New Regex("^[a-zA-Z]\w{1,39}$")

        If args.Length = 0 Then
          ' Show how to use this program.
          showusage()
        Else
          host = args(0)
          If ((rex.Match(host)).Success) Then
            ' Get the specified server home_page and display its content.
            Dim result As String = requestServerHomePage(host, port)
            Console.WriteLine(result)
          Else
            Console.WriteLine("Input string format not allowed.")
          End If
        End If
      End Sub 'Main

    End Class 'TestIPEndPoint
  End Module
End Namespace
'</Snippet1>

