//<snippet0>
#using <System.dll>
using namespace System;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::Sockets;

int main()
{
    // Create the server side connection and
    // start listening for clients.
    TcpListener^ tcpListener = gcnew TcpListener(IPAddress::Any, 11000);
    tcpListener->Start();
    Console::WriteLine("Waiting for a connection....");

    // Accept the pending client connection.
    TcpClient^ tcpClient = tcpListener->AcceptTcpClient();
    Console::WriteLine("Connection accepted.");
    // Get the stream to write the message
    // that will be sent to the client.
    NetworkStream^ networkStream = tcpClient->GetStream();
    String^ responseString = "Hello.";
    // Set the write timeout to 10 millseconds.
    networkStream->WriteTimeout = 10;
    // Convert the message to a byte array and sent it to the client.
    array<Byte>^ sendBytes = Encoding::UTF8->GetBytes(responseString);
    networkStream->Write(sendBytes, 0, sendBytes->Length);
    Console::WriteLine("Message Sent.");
    // Close the connection to the client.
    tcpClient->Close();
    // Stop listening for incoming connections
    // and close the server.
    tcpListener->Stop();
}
//</snippet0>
