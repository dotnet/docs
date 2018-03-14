/*
This program demonstrates the 'AddressFamily' and 'Address' property of 'IPAddress' class.
It takes an IP address String* from commandline(or uses a default value) and creates an instance of
'IPAddress' class by calling 'Parse' method of 'IPAddress' class. Then it prints the value of
'AddressFamily' and 'Address' property (which is an integer value).
*/

#using <System.dll>

using namespace System;
using namespace System::Net;

// <Snippet1>
void PrintAddressFamily( String^ IpAddressString )
{
   // Creates an instance of the IPAddress for the specified IP String* in
   // dotted-quad notation.
   IPAddress^ hostIPAddress = IPAddress::Parse( IpAddressString );
   Console::WriteLine( "\nIP address family : {0}", hostIPAddress->AddressFamily );
}
// </Snippet1>

// <Snippet2>
void PrintAddress( String^ IpAddressString )
{
   // Creates an instance of the IPAddress for the specified IP String* in
   // dotted-quad notation.
   IPAddress^ hostIPAddress = IPAddress::Parse( IpAddressString );
   Console::WriteLine( "\nInteger value of IP address {0} is {1}", IpAddressString, hostIPAddress->Address );
}
// </Snippet2>

int main()
{
   try
   {
      String^ IpAddressString = "";
      Console::Write( "Type an IP address (press Enter for default, default is '64.14.132.100') : " );
      IpAddressString = Console::ReadLine();
      if ( IpAddressString->Length <= 0 )
      {
         IpAddressString = "64.14.132.100";
      }
      PrintAddressFamily( IpAddressString );
      PrintAddress( IpAddressString );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception caught!!!" );
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
}
