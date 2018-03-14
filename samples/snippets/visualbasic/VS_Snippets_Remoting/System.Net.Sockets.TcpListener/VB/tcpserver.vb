' <Snippet1>
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic


Class MyTcpListener

    Public Shared Sub Main()

	Dim server As TcpListener
	server=nothing
        Try
            ' Set the TcpListener on port 13000.
         Dim port As Int32 = 13000
         Dim localAddr As IPAddress = IPAddress.Parse("127.0.0.1")

         server = New TcpListener(localAddr, port)
         
         ' Start listening for client requests.
         server.Start()
         
         ' Buffer for reading data
            Dim bytes(1024) As Byte
            Dim data As String = Nothing
         
         ' Enter the listening loop.
         While True
            Console.Write("Waiting for a connection... ")
            
            ' Perform a blocking call to accept requests.
            ' You could also user server.AcceptSocket() here.
            Dim client As TcpClient = server.AcceptTcpClient()
            Console.WriteLine("Connected!")
            
            data = Nothing
            
            ' Get a stream object for reading and writing
            Dim stream As NetworkStream = client.GetStream()
            
            Dim i As Int32
            
            ' Loop to receive all the data sent by the client.
            i = stream.Read(bytes, 0, bytes.Length)
            While (i <> 0) 
               ' Translate data bytes to a ASCII string.
               data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                    Console.WriteLine("Received: {0}", data)
               
               ' Process the data sent by the client.
               data = data.ToUpper()
                    Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
               
               ' Send back a response.
               stream.Write(msg, 0, msg.Length)
                    Console.WriteLine("Sent: {0}", data)
              
               i = stream.Read(bytes, 0, bytes.Length)

            End While
            
            ' Shutdown and end connection
            client.Close()
         End While
      Catch e As SocketException
         Console.WriteLine("SocketException: {0}", e)
      Finally
         server.Stop()
      End Try
      
      Console.WriteLine(ControlChars.Cr + "Hit enter to continue....")
      Console.Read()
   End Sub 'Main

End Class 'MyTcpListener 
' </Snippet1>