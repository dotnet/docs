using System;
using System.Collections;
using System.Collections.Generic;

using System.Net;
using System.Net.Sockets;

using System.IO;
using System.Text;
using System.Threading;

namespace send_generics_csharp
{
	class Class1
	{
        public static int syncSendAndReceive(string host, int port)
        {
            //<Snippet1>
            byte[] RecvBytes = new Byte[256];
            Encoding ASCII = Encoding.ASCII;

            // Create the TCP Socket.
            IPHostEntry hostEntry = Dns.Resolve(host);
            IPEndPoint EPhost = new IPEndPoint(
                hostEntry.AddressList[0], port);

            Socket mySocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp );
            
            mySocket.Connect(EPhost);

            // Build the buffers to be sent.
            List<ArraySegment<byte>> buffers = 
                                     new List<ArraySegment<byte>>(2);

            buffers.Add(new ArraySegment<byte>(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                "<buffer 1>")));

            buffers.Add(new ArraySegment<byte>(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                "<buffer 2>")));        

            // Send the data.
            mySocket.Send(buffers);
            //</Snippet1>

            //<Snippet2>

            // Build the buffers for the receive.
            List<ArraySegment<byte>> recvBuffers = 
                                     new List<ArraySegment<byte>>(2);

            byte[] bigBuffer = new byte[1024];

            // Specify the first buffer segment (2 bytes, starting 
            // at the 4th element of bigBuffer)
            recvBuffers.Add(new ArraySegment<byte>
                                    (bigBuffer, 4, 2));

            // Specify the second buffer segment (500 bytes, starting
            // at the 20th element of bigBuffer)
            recvBuffers.Add(new ArraySegment<byte>
                                    (bigBuffer, 20, 500));

            int bytesReceived = mySocket.Receive(recvBuffers);

            Console.WriteLine("{0}", ASCII.GetString(bigBuffer));
            //</Snippet2>

            return 1;
        }

        public static ManualResetEvent allDone = 
                                new ManualResetEvent(false);

        public static void SendCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socket s = (Socket) ar.AsyncState;
            s.EndSend(ar);
        }
 
        public static void ReceiveCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socket s = (Socket) ar.AsyncState;
            s.EndReceive(ar);
        }
         
        public static int asyncSendAndReceive(string host, int port)
        {
            //<Snippet3>
            byte[] RecvBytes = new byte[256];
            Encoding ASCII = Encoding.ASCII;

            // Create the TCP Socket.
            IPHostEntry hostEntry = Dns.Resolve(host);
            IPEndPoint EPhost = new IPEndPoint(
                hostEntry.AddressList[0], port);

            Socket mySocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp );
            
            mySocket.Connect(EPhost);

            // Build the buffers to be sent.
            List<ArraySegment<byte>> buffers = 
                                     new List<ArraySegment<byte>>(2);

            buffers.Add(new ArraySegment<byte>(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                "<buffer 1>")));

            buffers.Add(new ArraySegment<byte>(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                "<buffer 2>")));        

            // Send the data.
            allDone.Reset();
            mySocket.BeginSend(buffers, SocketFlags.None, 
                               SendCallback, (object)mySocket);
            allDone.WaitOne();

            // done
            Console.WriteLine("Data sent");
            //</Snippet3>

            //<Snippet4>

            // Build the buffers for the receive.
            List<ArraySegment<byte>> recvBuffers = 
                                     new List<ArraySegment<byte>>(2);

            byte[] bigBuffer = new byte[1024];

            // Specify the first buffer segment (2 bytes, starting 
            // at the 6th element of bigBuffer)
            recvBuffers.Add(new ArraySegment<byte>
                                    (bigBuffer, 6, 2));

            // Specify the second buffer segment (500 bytes, starting
            // at the 10th element of bigBuffer)
            recvBuffers.Add(new ArraySegment<byte>
                                    (bigBuffer, 10, 500));

            // Receive the data.
            allDone.Reset();
            mySocket.BeginReceive(recvBuffers, SocketFlags.None, 
                                  SendCallback, (object)mySocket);
            allDone.WaitOne();

            Console.WriteLine("Data received:");
            Console.WriteLine("{0}", ASCII.GetString(bigBuffer));
            //</Snippet4>


        return 1;
        }
            
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("starting synchronous test");
            syncSendAndReceive("localhost", 80);
            Console.WriteLine("starting asynchronous test");
            asyncSendAndReceive("localhost", 80);
            Console.WriteLine("ending tests");
        }
    }

}
