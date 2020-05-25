

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;

public ref class Sample
{
protected:
   void Method( Socket^ mySocket )
   {
      // <Snippet1>
      LingerOption^ myOpts = gcnew LingerOption( true,1 );
      mySocket->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Linger, myOpts );
      // </Snippet1>
   }
};
