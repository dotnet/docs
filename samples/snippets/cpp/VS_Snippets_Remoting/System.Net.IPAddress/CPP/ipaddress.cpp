

// <Internal>
// File name: ipaddress.cpp
// The snippets contained here apply to:
// 1) System.Net.IPAddress.AddressFamily, snippet3.
// 2) System.Net.IPAddess.ScopeId, snippet3.
// more
// </Internal>
// <Snippet1>
// This program shows how to use the IPAddress class to obtain a server 
// IP addressess and related information.
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text::RegularExpressions;

/**
* The IPAddresses method obtains the selected server IP address information.
* It then displays the type of address family supported by the server and its 
* IP address in standard and byte format.
**/
void IPAddresses( String^ server )
{
   try
   {
      System::Text::ASCIIEncoding^ ASCII = gcnew System::Text::ASCIIEncoding;
      
      // Get server related information.
      IPHostEntry^ heserver = Dns::GetHostEntry( server );
      
      // Loop on the AddressList
      System::Collections::IEnumerator^ myEnum = heserver->AddressList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IPAddress^ curAdd = safe_cast<IPAddress^>(myEnum->Current);
         
         //<Snippet3>
         // Display the type of address family supported by the server. If the
         // server is IPv6-enabled this value is: InterNetworkV6. If the server
         // is also IPv4-enabled there will be an additional value of InterNetwork.
         Console::WriteLine( "AddressFamily: {0}", curAdd->AddressFamily );
         
         // Display the ScopeId property in case of IPV6 addresses.
         if ( curAdd->AddressFamily.ToString() == ProtocolFamily::InterNetworkV6.ToString() )
                  Console::WriteLine( "Scope Id: {0}", curAdd->ScopeId );
         //</Snippet3>

         // Display the server IP address in the standard format. In 
         // IPv4 the format will be dotted-quad notation, in IPv6 it will be
         // in colon-hexadecimal notation.
         Console::WriteLine( "Address: {0}", curAdd );
         
         // Display the server IP address in byte format.
         Console::Write( "AddressBytes: " );
         
         //<Snippet2>
         array<Byte>^bytes = curAdd->GetAddressBytes();
         for ( int i = 0; i < bytes->Length; i++ )
         {
            Console::Write( bytes[ i ] );

         }
         // </Snippet2>

         Console::WriteLine( "\r\n" );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "[DoResolve] Exception: {0}", e );
   }

}


// This IPAddressAdditionalInfo displays additional server address information.
void IPAddressAdditionalInfo()
{
   try
   {
      // Display the flags that show if the server supports IPv4 or IPv6
      // address schemas.
      Console::WriteLine( "\r\nSupportsIPv4: {0}", Socket::SupportsIPv4 );
      Console::WriteLine( "SupportsIPv6: {0}", Socket::SupportsIPv6 );
      if ( Socket::SupportsIPv6 )
      {
         // Display the server Any address. This IP address indicates that the server 
         // should listen for client activity on all network interfaces. 
         Console::WriteLine( "\r\nIPv6Any: {0}", IPAddress::IPv6Any );

         // Display the server loopback address. 
         Console::WriteLine( "IPv6Loopback: {0}", IPAddress::IPv6Loopback );

         // Used during autoconfiguration first phase.
         Console::WriteLine( "IPv6None: {0}", IPAddress::IPv6None );
         Console::WriteLine( "IsLoopback(IPv6Loopback): {0}", IPAddress::IsLoopback( IPAddress::IPv6Loopback ) );
      }
      Console::WriteLine( "IsLoopback(Loopback): {0}", IPAddress::IsLoopback( IPAddress::Loopback ) );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "[IPAddresses] Exception: {0}", e );
   }

}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ server = nullptr;

   // Define a regular expression to parse user's input.
   // This is a security check. It allows only
   // alphanumeric input string between 2 to 40 character long.
   Regex^ rex = gcnew Regex( "^[a-zA-Z]\\w{1,39}$" );
   if ( args->Length < 2 )
   {
      // If no server name is passed as an argument to this program, use the current 
      // server name as default.
      server = Dns::GetHostName();
      Console::WriteLine( "Using current host: {0}", server );
   }
   else
   {
      server = args[ 1 ];
      if (  !(rex->Match(server))->Success )
      {
         Console::WriteLine( "Input string format not allowed." );
         return  -1;
      }
   }

   // Get the list of the addresses associated with the requested server.
   IPAddresses( server );

   // Get additional address information.
   IPAddressAdditionalInfo();
}
// </Snippet1>
