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

Public Class NetworkStream_ASync_Send_Receive
   
   Public Shared allDone As New ManualResetEvent(False)
   
   
   Public Shared Sub MySample(networkStreamOwnsSocket As Boolean)
      
      
      ' Create a socket and connect with a remote host.
      Dim myIpHostEntry As IPHostEntry = Dns.GetHostEntry("www.contoso.com")
      Dim myIpEndPoint As New IPEndPoint(myIpHostEntry.AddressList(0), 1001)
      
      Dim mySocket As New Socket(myIpEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
      Try
         
         '<Snippet1>
         ' Example for creating a NetworkStreams
         mySocket.Connect(myIpEndPoint)
         
         ' Create the NetworkStream for communicating with the remote host.
         Dim myNetworkStream As NetworkStream
         
         If networkStreamOwnsSocket Then
            myNetworkStream = New NetworkStream(mySocket, FileAccess.ReadWrite, True)
         Else
            myNetworkStream = New NetworkStream(mySocket, FileAccess.ReadWrite)
         End If
         
         '</Snippet1>

         '<Snippet2>
         ' Example of CanWrite, and BeginWrite.
         ' Check to see if this NetworkStream is writable.
         If myNetworkStream.CanWrite Then
            
            Dim myWriteBuffer As Byte() = Encoding.ASCII.GetBytes("Are you receiving this message?")
            myNetworkStream.BeginWrite(myWriteBuffer, 0, myWriteBuffer.Length, New AsyncCallback(AddressOf NetworkStream_ASync_Send_Receive.myWriteCallBack), myNetworkStream)
            allDone.WaitOne()
         Else
            Console.WriteLine("Sorry.  You cannot write to this NetworkStream.")
         End If
         
         '</Snippet2>

         '<Snippet3>
         ' Example of CanRead, and BeginRead.
         ' Check to see if this NetworkStream is readable.
         If myNetworkStream.CanRead Then
            
            Dim myReadBuffer(1024) As Byte
            myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, New AsyncCallback(AddressOf NetworkStream_ASync_Send_Receive.myReadCallBack), myNetworkStream)
            
            allDone.WaitOne()
         Else
            Console.WriteLine("Sorry.  You cannot read from this NetworkStream.")
         End If
         
         '</Snippet3>

         ' Close the NetworkStream
         myNetworkStream.Close()
      
      Catch exception As Exception
         Console.WriteLine(("Exception Thrown: " + exception.ToString()))
      End Try
   End Sub 'MySample
   
   
   '<Snippet4>
   ' Example of EndWrite
   Public Shared Sub myWriteCallBack(ar As IAsyncResult)
      
      Dim myNetworkStream As NetworkStream = CType(ar.AsyncState, NetworkStream)
      myNetworkStream.EndWrite(ar)
   End Sub 'myWriteCallBack
   
   
   '</Snippet4>

   '<Snippet5>
   ' Example of EndRead, DataAvailable and BeginRead.
   Public Shared Sub myReadCallBack(ar As IAsyncResult)
      
      Dim myNetworkStream As NetworkStream = CType(ar.AsyncState, NetworkStream)
      Dim myReadBuffer(1024) As Byte
      Dim myCompleteMessage As [String] = ""
      Dim numberOfBytesRead As Integer
      
      numberOfBytesRead = myNetworkStream.EndRead(ar)
      myCompleteMessage = [String].Concat(myCompleteMessage, Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
      
      ' message received may be larger than buffer size so loop through until you have it all.
      While myNetworkStream.DataAvailable
         
         myNetworkStream.BeginRead(myReadBuffer, 0, myReadBuffer.Length, New AsyncCallback(AddressOf NetworkStream_ASync_Send_Receive.myReadCallBack), myNetworkStream)
      End While
      
      
      ' Print out the received message to the console.
      Console.WriteLine(("You received the following message : " + myCompleteMessage))
   End Sub 'myReadCallBack
   
   '</Snippet5>

   'Entry point which delegates to C-style main Private Function
'   Public Overloads Shared Sub Main()
'      Main(System.Environment.GetCommandLineArgs())
'   End Sub
   
   
   Public Shared Sub Main(args() As [String])
      If args(0) = "yes" Then
         NetworkStream_ASync_Send_Receive.MySample(True)
      Else
         If args(0) = "no" Then
            NetworkStream_ASync_Send_Receive.MySample(False)
         Else
            Console.WriteLine(("Must use 'yes' to allow the NetworkStream to own the Socket or " + ControlChars.NewLine + " 'no' to prohibit NetworkStream from owning the Socket. "))
         End If
      End If
   End Sub 'Main 
End Class 'NetworkStream_ASync_Send_Receive


