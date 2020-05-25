/*
This program demostrates 'AddressList' property of 'IPHostEntry' class.
It takes a URL from commandline(or uses default value) and obtains a
'IPHostEntry' Object* by calling 'GetHostByName' method of 'Dns' class and
prints the host name and IP addresses associated with the specified URL.
*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

// <Snippet1>
void GetIpAddressList( String^ hostString )
{
   try
   {
      // Get 'IPHostEntry' object containing information
      // like host name, IP addresses, aliases for a host.
      IPHostEntry^ hostInfo = Dns::GetHostByName( hostString );
      Console::WriteLine( "Host name : {0}", hostInfo->HostName );
      Console::WriteLine( "IP address List : " );
      for ( int index = 0; index < hostInfo->AddressList->Length; index++ )
         Console::WriteLine( hostInfo->AddressList[ index ] );
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
}
// </Snippet1>

int main()
{
   String^ hostString = " ";
   
   // Create an instance of HostInfoSample class.
   Console::Write( "Type a URL(or press Enter for default, default is 'www.microsoft.net') : " );
   hostString = Console::ReadLine();
   if ( hostString->Length > 0 )
      GetIpAddressList( hostString );
   else
      GetIpAddressList( "www.microsoft.net" );
}
