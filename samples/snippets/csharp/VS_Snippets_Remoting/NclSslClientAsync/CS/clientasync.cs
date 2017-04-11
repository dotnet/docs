// NclSslClientAsync
//<snippet0>
using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Examples.Ssl
{
    // The following example demonstrates the client side of a 
    // client-server application that communicates using the
    // SslStream and TcpClient classes.
    // After connecting to the server and authenticating, 
    // the client sends the server a message, recieves a message from the server,
    // and then terminates. Messages sent to and from the server are terminated
    // with '<EOF>'.
    public class SslTcpClient 
    {   
       // complete is used to terminate the application when all 
        // asynchronous calls have completed or any call has thrown an exception.
        // complete might be used by any of the callback methods.
        static bool complete = false;
        // e stores any exception thrown by an asynchronous method so that
        // the mail application thread can display the exception and terminate gracefully.
        // e might be used by any of the callback methods.
        static Exception e = null;
        // <snippet8>
        // readData and buffer holds the data read from the server.
        // They is used by the ReadCallback method.
        static StringBuilder readData = new StringBuilder();
        static byte [] buffer = new byte[2048];
        // </snippet8>
        //<snippet1>
       
        // The following method is invoked by the CertificateValidationDelegate.
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            Console.WriteLine("Validating the server certificate.");
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        //</snippet1>
        //<snippet2>
        public static X509Certificate SelectLocalCertificate(
            object sender,
            string targetHost, 
            X509CertificateCollection localCertificates, 
            X509Certificate remoteCertificate, 
            string[] acceptableIssuers)
        {	
            Console.WriteLine("Client is selecting a local certificate.");
            if (acceptableIssuers != null && 
                acceptableIssuers.Length > 0 &&
                localCertificates != null &&
                localCertificates.Count > 0)
            {
                // Use the first certificate that is from an acceptable issuer.
                foreach (X509Certificate certificate in localCertificates)
                {
                    string issuer = certificate.Issuer;
                    if (Array.IndexOf(acceptableIssuers, issuer) != -1)
                        return certificate;
                }
            }
            if (localCertificates != null &&
                localCertificates.Count > 0)
                return localCertificates[0];
                
            return null;
        }
        //</snippet2>
                //<snippet3>
        static void AuthenticateCallback(IAsyncResult ar)
        {
            SslStream stream = (SslStream) ar.AsyncState;
            try 
            {
                stream.EndAuthenticateAsClient(ar);
                Console.WriteLine("Authentication succeeded.");
                Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, 
                    stream.CipherStrength);
                Console.WriteLine("Hash: {0} strength {1}", 
                    stream.HashAlgorithm, stream.HashStrength);
                Console.WriteLine("Key exchange: {0} strength {1}", 
                    stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
                Console.WriteLine("Protocol: {0}", stream.SslProtocol);
                // Encode a test message into a byte array.
                // Signal the end of the message using the "<EOF>".
                byte[] message = Encoding.UTF8.GetBytes("Hello from the client.<EOF>");
                // Asynchronously send a message to the server.
                stream.BeginWrite(message, 0, message.Length, 
                    new AsyncCallback(WriteCallback),
                    stream);
            }
            catch (Exception authenticationException)
            {
                e = authenticationException;
                complete = true;
                return;
            }
        }
        //</snippet3>
        //<snippet4>
        static void WriteCallback(IAsyncResult ar)
        {
            SslStream stream = (SslStream) ar.AsyncState;
            try 
            {
                Console.WriteLine("Writing data to the server.");
                stream.EndWrite(ar);
                // Asynchronously read a message from the server.
                stream.BeginRead(buffer, 0, buffer.Length, 
                    new AsyncCallback(ReadCallback),
                    stream);
            }
            catch (Exception writeException)
            {
                e = writeException;
                complete = true;
                return;
            }
        }
        //</snippet4>
        //<snippet5>

        static void ReadCallback(IAsyncResult ar)
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            SslStream stream = (SslStream) ar.AsyncState;
            int byteCount = -1;
            try 
            {
                Console.WriteLine("Reading data from the server.");
                byteCount = stream.EndRead(ar);
                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer,0, byteCount)];
                decoder.GetChars(buffer, 0, byteCount, chars,0);
                readData.Append (chars);
                // Check for EOF or an empty message.
                if (readData.ToString().IndexOf("<EOF>") == -1 && byteCount != 0)
                {
                    // We are not finished reading.
                    // Asynchronously read more message data from  the server.
                    stream.BeginRead(buffer, 0, buffer.Length, 
                        new AsyncCallback(ReadCallback),
                        stream);
                } 
                else
                {
                    Console.WriteLine("Message from the server: {0}", readData.ToString());
                }
            }
            catch (Exception readException)
            {
                e = readException;
                complete = true;
                return;
            }
            complete = true;
        }
        //</snippet5>
 //<snippet7>
        public static int Main(string[] args)
        {
            string serverName = null;
            if (args == null ||args.Length <2 )
            {
                Console.WriteLine(
                    "To start the client specify the host name and" +
                    " one or more client certificate file names.");
                return 1;
            }
            //<snippet6>
            // Server name must match the host name and the name on the host's certificate. 
            serverName = args[0];
            // Create a TCP/IP client socket.
            TcpClient client = new TcpClient(serverName,80);
            Console.WriteLine("Client connected.");
            // Create an SSL stream that will close the client's stream.
            SslStream sslStream = new SslStream(
                client.GetStream(), 
                false, 
                new RemoteCertificateValidationCallback (ValidateServerCertificate), 
                new LocalCertificateSelectionCallback(SelectLocalCertificate)
                );
                   //</snippet6>
            // Create the certificate collection to hold the client's certificate.
            X509CertificateCollection clientCertificates = new X509CertificateCollection();
            for (int i = 1; i< args.Length; i++)
            {
                X509Certificate certificate = X509Certificate.CreateFromCertFile(args[i]);
                clientCertificates.Add(certificate);
            }
            // Begin authentication.
            // The server name must match the name on the server certificate.
           
            sslStream.BeginAuthenticateAsClient(
                serverName,
                clientCertificates,
                SslProtocols.Ssl3,
                true,
                new AsyncCallback(AuthenticateCallback),
                sslStream);
            // User can press a key to exit application, or let the 
            // asynchronous calls continue until they complete.
            Console.WriteLine("To quit, press the enter key.");
            do 
            {
                // Real world applications would do work here
                // while waiting for the asynchronous calls to complete.
                System.Threading.Thread.Sleep(100);
            } while (complete != true && Console.KeyAvailable == false);
            
            if (Console.KeyAvailable)
            {
                Console.ReadLine();
                Console.WriteLine("Quitting.");
                client.Close();
                sslStream.Close();
                return 1;
            }
            if (e != null )
            {
                Console.WriteLine("An exception was thrown: {0}", e.ToString());
            }
            sslStream.Close();
            client.Close();
            Console.WriteLine("Good bye.");
            return 0;
        }
         //</snippet7>
    }
}
    
//</snippet0>
    
