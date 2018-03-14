 ' The following sample is intended to demonstrate how to use a 
'NetworkStream for synchronous communcation with a remote host
'This class uses several NetworkStream members that would be useful
' in a synchronous communciation senario
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports Microsoft.VisualBasic

Public Class NetworkStream_Sync_Send_Receive
   
   
   Public Shared Sub MySample(networkStreamOwnsSocket As Boolean)
      
      '<Snippet1> 
      ' This should be the classwide example.
      ' Create a socket and connect with a remote host.
      Dim myIpHostEntry As IPHostEntry = Dns.GetHostEntry("www.contoso.com")
      Dim myIpEndPoint As New IPEndPoint(myIpHostEntry.AddressList(0), 1001)
      
      Dim mySocket As New Socket(myIpEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         mySocket.Connect(myIpEndPoint)
         
         '<Snippet2>  
         ' Examples for constructors that do not specify file permission.
         ' Create the NetworkStream for communicating with the remote host.
         Dim myNetworkStream As NetworkStream
         
         If networkStreamOwnsSocket Then
            myNetworkStream = New NetworkStream(mySocket, True)
         Else
            myNetworkStream = New NetworkStream(mySocket)
         End If
         '</Snippet2>           

         '<Snippet3>  
         ' Examples for CanWrite, and CanWrite  
         ' Check to see if this NetworkStream is writable.
         If myNetworkStream.CanWrite Then
            
            Dim myWriteBuffer As Byte() = Encoding.ASCII.GetBytes("Are you receiving this message?")
            myNetworkStream.Write(myWriteBuffer, 0, myWriteBuffer.Length)
         Else
            Console.WriteLine("Sorry.  You cannot write to this NetworkStream.")
         End If
         
         '</Snippet3>

         '<Snippet4>   
         ' Examples for CanRead, Read, and DataAvailable.
         ' Check to see if this NetworkStream is readable.
         If myNetworkStream.CanRead Then
            Dim myReadBuffer(1024) As Byte
                Dim myCompleteMessage As StringBuilder = New StringBuilder()
            Dim numberOfBytesRead As Integer = 0
            
            ' Incoming message may be larger than the buffer size.
            Do
               numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length)
                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
            Loop While myNetworkStream.DataAvailable
            
            ' Print out the received message to the console.
                Console.WriteLine(("You received the following message : " + myCompleteMessage.ToString()))
         Else
            Console.WriteLine("Sorry.  You cannot read from this NetworkStream.")
         End If
         
         '</Snippet4>

         '<Snippet5>  
         ' Example for closing the NetworkStream.
         ' Close the NetworkStream
         myNetworkStream.Close()
      
      '</Snippet5>
      Catch exception As Exception
         Console.WriteLine(("Exception Thrown: " + exception.ToString()))
      End Try
   End Sub 'MySample
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   
   '</Snippet1>
   Overloads Public Shared Sub Main(args() As [String])
      If args(0) = "yes" Then
         NetworkStream_Sync_Send_Receive.MySample(True)
      Else
         If args(0) = "no" Then
            NetworkStream_Sync_Send_Receive.MySample(False)
         Else
            Console.WriteLine(("Must use 'yes' to allow the NetworkStream to own the Socket or " + ControlChars.NewLine + " 'no' to prohibit NetworkStream from owning the Socket. "))
         End If
      End If
   End Sub 'Main 
End Class 'NetworkStream_Sync_Send_Receive


