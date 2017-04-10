#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Security::Permissions;

public ref class Sample
{
protected:
   [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   void Method( Socket^ aSocket )
   {
      // <Snippet1>
      aSocket->Shutdown( SocketShutdown::Both );
      aSocket->Close();
      if ( aSocket->Connected )
      {
         Console::WriteLine( "Winsock error: {0}", Convert::ToString(
            System::Runtime::InteropServices::Marshal::GetLastWin32Error() ) );
      }
      // </Snippet1>
   }
};
