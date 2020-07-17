#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;

public ref class Sample
{
   // <Snippet1>
protected:
   void AcceptMethod( Socket^ listeningSocket )
   {
      Socket^ mySocket = listeningSocket->Accept();
   }
   // </Snippet1>
};
