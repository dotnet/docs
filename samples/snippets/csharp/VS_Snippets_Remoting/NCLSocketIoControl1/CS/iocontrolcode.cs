using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace Example
{
    public class Test
    {
        // <snippet1>
        static void DisplayPendingByteCount(Socket s)
        {
            byte[] outValue = BitConverter.GetBytes(0);

            // Check how many bytes have been received.
            s.IOControl(IOControlCode.DataToRead, null, outValue);

            uint bytesAvailable = BitConverter.ToUInt32(outValue, 0);
            Console.Write("server has {0} bytes pending. ", 
                bytesAvailable);
            Console.WriteLine("Available property says {1}.",
                             s.Available);

            return;
        }
        // </snippet1>
        public static void Main()
        {
            IPHostEntry localHost = Dns.Resolve(Dns.GetHostName());
            IPEndPoint endPoint = new IPEndPoint(
                localHost.AddressList[0], 11000);

            // For the purposes of this example, we will send and
            // receive on the same machine.
            //
            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            s.Bind(endPoint);

            s.Listen(1);
            Console.WriteLine(
                "Waiting to receive messages from client...");
            Socket client = s.Accept();

            // Creates a byte buffer to receive the message.
            byte[] buffer = new byte[256];
            string message;

            while (true)
            {
                Thread.Sleep(10000);
                DisplayPendingByteCount(client);
                client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer);
                // Displays the information received to the screen
                Console.WriteLine(
                    " Server received the following message : {0}", 
                    message);

                // Look for "<EOF>" to end session.
                if (message.IndexOf("<EOF>") != -1)
                    break;
            }
            client.Close();
            s.Close();

        }
    }
}