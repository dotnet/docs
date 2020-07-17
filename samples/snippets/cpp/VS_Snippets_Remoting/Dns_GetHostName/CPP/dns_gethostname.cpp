/*
This program demonstrates the 'GetHostName' method of 'Dns' class.
It creates a 'DnsHostName' instance and calls 'GetHostName' method to get the local host
computer name. Then prints the computer name on the console.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

public ref class DnsHostName
{
   // <Snippet1>
public:
   void DisplayLocalHostName()
   {
      try
      {
         // Get the local computer host name.
         String^ hostName = Dns::GetHostName();
         Console::WriteLine( "Computer name : {0}", hostName );
      }
      catch ( SocketException^ e ) 
      {
         Console::WriteLine( "SocketException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
   }
   // </Snippet1>
};

int main()
{
   DnsHostName^ dnsHostNameObj = gcnew DnsHostName;
   dnsHostNameObj->DisplayLocalHostName();
}
