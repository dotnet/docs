

/*
This program checks whether the specified address is a loopback address.
It invokes the IPAddress Parse method to translate the address
input String* into the correct internal format.
The IP address String* must be in dotted-quad notation for IPv4 or in
colon-hexadecimal notation for IPv6.
*/
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

// This method calls the IPAddress::Parse method to check if the
// passed ipAddress parameter is in the correct format.
// Then it checks whether it represents a loopback address.
// Finally, it displays the results.
void parse( String^ ipAddress )
{
   String^ loopBack = " is not a loopback address.";
   try
   {
      
      // Perform syntax check by parsing the address string entered by the user.
      IPAddress^ address = IPAddress::Parse( ipAddress );
      
      // Perform semantic check by verifying that the address is a valid IPv4
      // or IPv6 loopback address.
      if ( IPAddress::IsLoopback( address ) && address->AddressFamily == AddressFamily::InterNetworkV6 )
            loopBack = String::Concat( " is an IPv6 loopback address whose internal format is: ", address, "." );
      else
      if ( IPAddress::IsLoopback( address ) && address->AddressFamily == AddressFamily::InterNetwork )
            loopBack = String::Concat( " is an IPv4 loopback address whose internal format is: ", address, "." );
      
      // Display the results.
      Console::WriteLine( "Your input address: \" {0} \" {1}", ipAddress, loopBack );
   }
   catch ( FormatException^ e ) 
   {
      Console::WriteLine( "FormatException caught!!!" );
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

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length == 1 )
   {
      
      // No parameters entered. Display program usage.
      Console::WriteLine( "Please enter an IP address." );
      Console::WriteLine( "Usage:   >ipaddress_isloopback any IPv4 or IPv6 address." );
      Console::WriteLine( "Example: >ipaddress_isloopback 127.0.0.1" );
      Console::WriteLine( "Example: >ipaddress_isloopback 0:0:0:0:0:0:0:1" );
   }
   else
      parse( args[ 1 ] );

   
   // Parse the address string entered by the user.
}

// </Snippet1>
