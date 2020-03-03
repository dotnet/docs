#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::Sockets;

void MySerializeIPEndPointClassMethod()
{
   //<Snippet1>
   //Creates an IpEndPoint.
   IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
   IPEndPoint^ ipLocalEndPoint = gcnew IPEndPoint( ipAddress,11000 );
   
   //Serializes the IPEndPoint.
   SocketAddress^ socketAddress = ipLocalEndPoint->Serialize();
   
   //Verifies that ipLocalEndPoint is now serialized by printing its contents.
   Console::WriteLine( "Contents of the socketAddress are: {0}", socketAddress );
   //Checks the Family property.
   Console::WriteLine( "The address family of the socketAddress is: {0}", socketAddress->Family );
   //Checks the underlying buffer size.
   Console::WriteLine( "The size of the underlying buffer is: {0}", socketAddress->Size );
   //</Snippet1>
}

int main()
{
   MySerializeIPEndPointClassMethod();
}
