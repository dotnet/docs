// NclSslServerAsync
//<snippet0>
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Examples.Ssl
{
    // The following example demonstrates the server side of a 
    // client-server application that communicates using the
    // SslStream, TcpListener, and TcpClient classes.
    // After connecting to the server and authenticating, 
    // the server reads a message from the client,
    // sends a message to the client,
    // and then terminates. Messages sent to and from the client are terminated
    // with '<EOF>'.
    // The ClientState class holds information shared
    // by asynchronous calls.
    // <snippet1>
    internal class ClientState
    {
        internal SslStream stream;
        internal TcpClient client;
        internal StringBuilder readData;
        internal byte [] buffer = new byte[2048];
        internal ClientState(SslStream stream, TcpClient client)
        {
            this.stream = stream;
            this.client = client;
            readData = new StringBuilder();
        }
        internal void Close()
        {
            // Close the SslStream. This will also close the 
            // NetworkStream allocated to the TcpClient.
            stream.Close();
            // Close the TcpClient.
            client.Close();
            readData = null;
            buffer = null;
            Console.WriteLine("Client closed.");
        }
    }
    // </snippet1>
    public class SslTcpListener
    {
            // <snippet2>
        // The following method is invoked by the CertificateValidationDelegate.
        public static bool ValidateCertificate(
            object sender,
            X509Certificate certificate, 
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (certificate == null)
            {
                // Null certificate and no errors means that the client was not
                // required to provide a certificate.
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                } 
                else
                {
                    Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
                }
                    return false;
            }
            Console.WriteLine("Server is validating certificate.");
            Console.WriteLine("Certificate was issued to {0} and is valid from {1} until {2}.",
                certificate.Subject,
                certificate.GetEffectiveDateString(),
                certificate.GetExpirationDateString());
            return true;
        }
        // </snippet2>
        // <snippet3>
        void AuthenticateCallback(IAsyncResult ar)
        {
            ClientState state = (ClientState) ar.AsyncState;
            SslStream stream = state.stream;
            try 
            {
                stream.EndAuthenticateAsServer(ar);
                Console.WriteLine("Authentication succeeded.");
                Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, 
                    stream.CipherStrength);
                Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, 
                    stream.HashStrength);
                Console.WriteLine("Key exchange: {0} strength {1}", 
                    stream.KeyExchangeAlgorithm, 
                    stream.KeyExchangeStrength);
                Console.WriteLine("Protocol: {0}", stream.SslProtocol);
                // Asynchronously read a message from the client.
                stream.BeginRead(state.buffer, 0, state.buffer.Length, 
                    new AsyncCallback(ReadCallback),
                    state);
            }
            catch (Exception authenticationException)
            {
                Console.WriteLine("Authentication error: {0}", 
                    authenticationException.Message);
                if (authenticationException.InnerException != null)
                {
                    Console.WriteLine(" Inner exception: {0}", 
                    authenticationException.InnerException.Message);
                }
                state.Close();
                return;
            }
        }
    // </snippet3>
        // <snippet4>
        void WriteCallback(IAsyncResult ar)
        {
            ClientState state = (ClientState) ar.AsyncState;
            SslStream stream = state.stream;
            try 
            {
                Console.WriteLine("Writing data to the client.");
                stream.EndWrite(ar);
            }
            catch (Exception writeException)
            {
                Console.WriteLine("Write error: {0}", 
                    writeException.Message);
                state.Close();
                return;
            }
            Console.WriteLine("Finished with client.");
            state.Close();
        }
            // </snippet4>
            // <snippet5>
        void ReadCallback(IAsyncResult ar)
        {
            ClientState state = (ClientState) ar.AsyncState;
            SslStream stream = state.stream;
            // Read the  message sent by the client.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            int byteCount = -1;
            try 
            {
                Console.WriteLine("Reading data from the client.");
                byteCount = stream.EndRead(ar);
                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(state.buffer,0, byteCount)];
                decoder.GetChars(state.buffer, 0, byteCount, chars,0);
                state.readData.Append (chars);
                // Check for EOF or an empty message.
                if (state.readData.ToString().IndexOf("<EOF>") == -1 && byteCount != 0)
                {
                    // We are not finished reading.
                    // Asynchronously read more message data from  the client.
                    stream.BeginRead(state.buffer, 0, state.buffer.Length, 
                        new AsyncCallback(ReadCallback),
                        state);
                } 
                else
                {
                    Console.WriteLine("Message from the client: {0}", state.readData.ToString());
                }
                              
                // Encode a test message into a byte array.
                // Signal the end of the message using "<EOF>".
                byte[] message = Encoding.UTF8.GetBytes("Hello from the server.<EOF>");
                // Asynchronously send the message to the client.
                stream.BeginWrite(message, 0, message.Length, 
                    new AsyncCallback(WriteCallback),
                    state);
            }
            catch (Exception readException)
            {
                Console.WriteLine("Read error: {0}", readException.Message);
                state.Close();
                return;
            }
        }
            // </snippet5>
                // <snippet6>
        void ProcessClient (ClientState state, X509Certificate serverCertificate)
        {
            try 
            {
                state.stream.BeginAuthenticateAsServer (serverCertificate, 
                    true, SslProtocols.Tls, true, 
                    new AsyncCallback(AuthenticateCallback),
                    state);
            }
            catch (Exception authenticationException)
            {
                Console.WriteLine("Authentication error: {0}",
                    authenticationException.Message);
                state.Close();
                return;
            }
        }
            // </snippet6>
                // <snippet7>
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("You must specify the server certificate file.");
                return;
            }
            X509Certificate serverCertificate = X509Certificate.CreateFromCertFile(args[0]);
            // Create a TCP/IP (IPv4) socket and listen for incoming connections.
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);    
            listener.Start();
            Console.WriteLine("Listening for clients.");
            while (true) 
            {
                // Application blocks while waiting for an incoming connection.
                // Type CNTL-C to terminate the server.
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");
                SslStream stream = new SslStream(client.GetStream(),
                    false,
                    new RemoteCertificateValidationCallback(ValidateCertificate));
                ClientState state = new ClientState(stream, client);
                
                SslTcpListener listenerWorker = new SslTcpListener();
                listenerWorker.ProcessClient(state, serverCertificate);
            }
        } 
        // </snippet7>
    }
}
    
//</snippet0>
    
