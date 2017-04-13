/*
This program demonstrates 'GetHostByAddress(IPAddress)' method of 'Dns' class.
It takes an IP address String* from commandline or uses default value and creates
an instance of IPAddress for the specified IP address String*. Obtains the IPHostEntry
Object* by calling 'GetHostByAddress' method of 'Dns' class and prints host name,
IP address list and aliases.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

class DnsHostByAddress
{
public:
   void DisplayHostAddress( String^ IpAddressString )
   {
      // Call 'GetHostByAddress(IPAddress)' method giving an 'IPAddress' Object* as argument.
      // Obtain an 'IPHostEntry' instance, containing address information of the specified host.
      // <Snippet1>
      try
      {
         IPAddress^ hostIPAddress = IPAddress::Parse( IpAddressString );
         IPHostEntry^ hostInfo = Dns::GetHostByAddress( hostIPAddress );
         
         // Get the IP address list that resolves to the host names contained in
         // the Alias property.
         array<IPAddress^>^address = hostInfo->AddressList;
         
         // Get the alias names of the addresses in the IP address list.
         array<String^>^alias = hostInfo->Aliases;
         Console::WriteLine( "Host name : {0}", hostInfo->HostName );
         Console::WriteLine( "\nAliases :" );
         for ( int index = 0; index < alias->Length; index++ )
            Console::WriteLine( alias[ index ] );
         Console::WriteLine( "\nIP address list : " );
         for ( int index = 0; index < address->Length; index++ )
            Console::WriteLine( address[ index ] );
      }
      catch ( SocketException^ e ) 
      {
         Console::WriteLine( "SocketException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( FormatException^ e ) 
      {
         Console::WriteLine( "FormatException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( ArgumentNullException^ e ) 
      {
         Console::WriteLine( "ArgumentNullException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      // </Snippet1>
   }
};

int main()
{
   String^ IpAddressString = "";
   DnsHostByAddress * myDnsHostByAddress = new DnsHostByAddress;
   Console::Write( "Type an IP address (press Enter for default, default is '207.46.131.199'): " );
   IpAddressString = Console::ReadLine();
   if ( IpAddressString->Length > 0 )
      myDnsHostByAddress->DisplayHostAddress( IpAddressString );
   else
      myDnsHostByAddress->DisplayHostAddress( "207.46.131.199" );
}
