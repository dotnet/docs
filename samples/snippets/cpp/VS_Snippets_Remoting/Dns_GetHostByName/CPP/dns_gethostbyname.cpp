/*
This program demonstrates 'GetHostByName' method of 'Dns' class.
It takes a URL String* from commandline or uses default value, and obtains
the 'IPHostEntry' Object* by calling 'GetHostByName' method of 'Dns' class.Then
prints host name, IP address list and aliases.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

public ref class DnsHostByName
{
public:
   void DisplayHostName( String^ hostName )
   {
      // Call the GetHostByName method passing a DNS style host name(for example,
      // S"www.contoso.com") as an argument.
      // Obtain the IPHostEntry instance, that contains information of the specified host.
      // <Snippet1>
      try
      {
         IPHostEntry^ hostInfo = Dns::GetHostByName( hostName );
         
         // Get the IP address list that resolves to the host names contained in the
         // Alias property.
         array<IPAddress^>^address = hostInfo->AddressList;
         
         // Get the alias names of the addresses in the IP address list.
         array<String^>^alias = hostInfo->Aliases;
         Console::WriteLine( "Host name : {0}", hostInfo->HostName );
         Console::WriteLine( "\nAliases : " );
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
   String^ hostName = "";
   DnsHostByName^ myDnsHostByName = gcnew DnsHostByName;
   Console::Write( "Type a URL (press Enter for default, default is 'www.microsoft.net') : " );
   hostName = Console::ReadLine();
   if ( hostName->Length > 0 )
      myDnsHostByName->DisplayHostName( hostName );
   else
      myDnsHostByName->DisplayHostName( "www.microsoft.net" );
}
