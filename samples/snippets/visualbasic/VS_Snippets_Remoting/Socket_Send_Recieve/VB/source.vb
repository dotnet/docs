
'<Snippet1>
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

 _

Public Class Sample
   
   
   Public Shared Function DoSocketGet(server As String) As String
      'Set up variables and String to write to the server.
    Dim ASCII As Encoding = Encoding.ASCII
    Dim [Get] As String = "GET / HTTP/1.1" + ControlChars.Lf + ControlChars.NewLine + "Host: " + server + ControlChars.Lf + ControlChars.NewLine + "Connection: Close" + ControlChars.Lf + ControlChars.NewLine + ControlChars.Lf + ControlChars.NewLine
    Dim ByteGet As [Byte]() = ASCII.GetBytes([Get])
    Dim RecvBytes(256) As [Byte]
    Dim strRetPage As [String] = Nothing


      
      ' IPAddress and IPEndPoint represent the endpoint that will
      '   receive the request.
      ' Get first IPAddress in list return by DNS.
      Try

 

         ' Define those variables to be evaluated in the next for loop and 
         ' then used to connect to the server. These variables are defined
         ' outside the for loop to make them accessible there after.
         Dim s As Socket = Nothing
         Dim hostEndPoint As IPEndPoint
         Dim hostAddress As IPAddress = Nothing
         Dim conPort As Integer = 80
         
         ' Get DNS host information.
         Dim hostInfo As IPHostEntry = Dns.Resolve(server)
         ' Get the DNS IP addresses associated with the host.
         Dim IPaddresses As IPAddress() = hostInfo.AddressList
         
         ' Evaluate the socket and receiving host IPAddress and IPEndPoint. 
      Dim index As Integer = 0
      For index = 0 To IPaddresses.Length - 1
        hostAddress = IPaddresses(index)
        hostEndPoint = New IPEndPoint(hostAddress, conPort)

'<Snippet3>

        ' Creates the Socket to send data over a TCP connection.
        s = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

'<Snippet2>

        ' Connect to the host using its IPEndPoint.
        s.Connect(hostEndPoint)

        If Not s.Connected Then
          ' Connection failed, try next IPaddress.
          strRetPage = "Unable to connect to host"
          s = Nothing
          GoTo ContinueFor1
        End If

'</Snippet2>

        ' Sent the GET request to the host.
        s.Send(ByteGet, ByteGet.Length, 0)

'</Snippet3>

ContinueFor1:
      Next index  ' End of the for loop.
      


 '<Snippet4>

      ' Receive the host home page content and loop until all the data is received.

      'Dim bytes As Int32 = s.Receive(RecvBytes, RecvBytes.Length, 0)
      Dim bytes As Int32 = s.Receive(RecvBytes, RecvBytes.Length, 0)

      strRetPage = "Default HTML page on " + server + ":\r\n"
      strRetPage = "Default HTML page on " + server + ":" + ControlChars.Lf + ControlChars.NewLine

      Dim i As Integer

      While bytes > 0

        bytes = s.Receive(RecvBytes, RecvBytes.Length, 0)

        strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes)

      End While

      '</Snippet4>

      ' End of the try block.
    Catch e As SocketException
         Console.WriteLine("SocketException caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      Catch e As ArgumentNullException
         Console.WriteLine("ArgumentNullException caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      Catch e As NullReferenceException
         Console.WriteLine("NullReferenceException caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      End Try
      
      Return strRetPage
   End Function 'DoSocketGet
    
   Public Shared Sub Main()
    Console.WriteLine(DoSocketGet("localhost"))
   End Sub 'Main
End Class 'Sample
 '</Snippet1>

