#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;

public ref class Sample
{
protected:
   void Method( Socket^ aSocket, EndPoint^ anEndPoint )
   {
      // <Snippet1>
      try
      {
         aSocket->Bind( anEndPoint );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Winsock error: {0}", e );
      }
      // </Snippet1>
   }
};
