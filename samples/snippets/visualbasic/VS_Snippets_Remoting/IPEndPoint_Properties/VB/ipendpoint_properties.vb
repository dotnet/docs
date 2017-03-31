' System.Net.IPEndPoint.MaxPort; System.Net.IPEndPoint.MinPort;
' System.Net.IPEndPoint.AddressFamily; System.Net.IPEndPoint.IPEndPoint(long,int)
' System.Net.IPEndPoint.Address; System.Net.IPEndPoint.Port;

'This program demonstrates the properties 'MaxPort', 'MinPort','Address','Port'
'  and 'AddressFamily' and a constructor 'IPEndPoint(long,int)' of class 'IPEndPoint'.
'  
'  A procedure DoSocketGet is created which internally uses a socket to transmit http "Get" requests to a Web resource.
'  The program accepts a resource Url, Resolves it to obtain 'IPAddress',Constructs 'IPEndPoint' instance using this 
'  'IPAddress' and port 80.Invokes DoSocketGet procedure to obtain a response and displays the response to a console.
'   
'  It then accepts another Url, Resolves it to obtain 'IPAddress'. Assigns this IPAddress and port to the 'IPEndPoint'
'  and again invokes DoSocketGet to obtain a response and display.
' 

Imports System
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic


Class IPEndPointSnippet
    
    Public Shared Sub Main()
        Try
            Console.Write(ControlChars.Cr + "Please enter an INTRANET Url as shown: [e.g. www.microsoft.com]: ")
            Dim hostString1 As String = Console.ReadLine()
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
            Dim hostIPAddress1 As IPAddress = Dns.Resolve(hostString1).AddressList(0)
            Dim hostIPEndPoint As New IPEndPoint(hostIPAddress1, 80)
            Console.WriteLine((ControlChars.Cr + "IPEndPoint information:" + hostIPEndPoint.ToString()))
            Console.WriteLine((ControlChars.Cr + ControlChars.Tab + "Maximum allowed Port Address :" + IPEndPoint.MaxPort.ToString()))
            Console.WriteLine((ControlChars.Cr + ControlChars.Tab + "Minimum allowed Port Address :" + IPEndPoint.MinPort.ToString()))
            Console.WriteLine((ControlChars.Cr + ControlChars.Tab + "Address Family :" + hostIPEndPoint.AddressFamily.ToString()))
' </Snippet4>
	         Console.Write(ControlChars.Cr + "Press Enter to continue")
            Console.ReadLine()
            Dim getString As String = "GET / HTTP/1.0" + ControlChars.Lf + ControlChars.Cr + "Host: " + hostString1 + ControlChars.Lf + ControlChars.Cr + "Connection: Close" + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr
            Dim pageContent As String = DoSocketGet(hostIPEndPoint, getString)
            If Not (pageContent Is Nothing) Then
                Console.WriteLine(("Default HTML page on " + hostString1 + " is:" + ControlChars.Lf + ControlChars.Cr + pageContent))
            End If
' </Snippet3>
' </Snippet2>
' </Snippet1>
	         Console.Write(ControlChars.Cr + ControlChars.Cr + ControlChars.Cr + "Please enter another INTRANET Url as shown[e.g. www.microsoft.com]: ")
            Dim hostString2 As String = Console.ReadLine()
' <Snippet5>
' <Snippet6>			
            Dim hostIPAddress2 As IPAddress = Dns.Resolve(hostString2).AddressList(0)
            hostIPEndPoint.Address = hostIPAddress2
            hostIPEndPoint.Port = 80
            getString = "GET / HTTP/1.0" + ControlChars.Lf + ControlChars.Cr + "Host: " + hostString2 + ControlChars.Lf + ControlChars.Cr + "Connection: Close" + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr
            pageContent = DoSocketGet(hostIPEndPoint, getString)
            If Not (pageContent Is Nothing) Then
                Console.WriteLine(("Default HTML page on " + hostString2 + " is:" + ControlChars.Lf + ControlChars.Cr + pageContent))
            End If
' </Snippet6>
' </Snippet5>	
	Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'Main
     
    
    Public Shared Function DoSocketGet(hostIPEndPoint As IPEndPoint, getString As String) As String
        Try
            ' Set up variables and String to write to the server.
            Dim ASCII As Encoding = Encoding.ASCII
            
            Dim byteGet As [Byte]() = ASCII.GetBytes(getString)
            Dim recvBytes(256) As [Byte]
            Dim strRetPage As [String] = Nothing
            ' Create the Socket for sending data over TCP.
            Dim mySocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            ' Connect to host using IPEndPoint.
            mySocket.Connect(hostIPEndPoint)
            ' Send the GET text to the host.
            mySocket.Send(byteGet, byteGet.Length, 0)
            ' Receive the page, loop until all bytes are received.
            Dim byteCount As Int32 = mySocket.Receive(recvBytes, recvBytes.Length, 0)
            strRetPage = strRetPage + ASCII.GetString(recvBytes, 0, byteCount)
            While byteCount > 0
                byteCount = mySocket.Receive(recvBytes, recvBytes.Length, 0)
                strRetPage = strRetPage + ASCII.GetString(recvBytes, 0, byteCount)
            End While
            Return strRetPage
        
        Catch e As Exception
            Console.WriteLine("Exception : {0}", e.Message)
            Console.WriteLine(("WinSock Error : " + Convert.ToString(Marshal.GetLastWin32Error())))
            Return Nothing
        End Try
    End Function 'DoSocketGet
End Class 'IPEndPointSnippet