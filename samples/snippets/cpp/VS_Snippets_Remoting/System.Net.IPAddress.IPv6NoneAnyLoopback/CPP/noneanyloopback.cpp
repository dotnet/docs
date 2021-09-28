/**
* File name: ipaddress_none_any_loopback.cs
* Exercise the IPAddress IPv6None, IPv6Any, and IPv6Loopback properties.
* Usage: cs_nal.exe.
**/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;

// <Snippet1>
// This method displays the value of the current host loopback address in
// standard compressed format.
void displayIPv6LoopBackAddress()
{
   try
   {
      // Get the loopback address.
      IPAddress^ loopBack = IPAddress::IPv6Loopback;
      
      // Transform the loop-back address to a string using the overladed
      // ToString() method. Note that the resulting string is in the compact
      // form: "::1".
      String^ ipv6LoopBack = loopBack->ToString();
      Console::WriteLine( "The IPv6 Loopback address is: {0}", ipv6LoopBack );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "->Item[displayIPv6LoopBackAddress] Exception: {0}", e );
   }
}
// </Snippet1>

// <Snippet2>
// This method displays the value of the current host's Any address in
// standard compressed format. The Any address is used by the host to enable
// listening to client activities on all the interfaces for a given port.
void displayIPv6AnyAddress()
{
   try
   {
      // Get the Any address.
      IPAddress^ any = IPAddress::IPv6Any;
      
      // Transform the Any address to a string using the overloaded
      // ToString() method. Note that the resulting string is in the compact
      // form: "::".
      String^ ipv6Any = any->ToString();
      
      // Display the Any address.
      Console::WriteLine( "The IPv6 Any address is: {0}", ipv6Any );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "->Item[displayIPv6AnyAddress] Exception: {0}", e );
   }
}
// </Snippet2>

// <Snippet3>
// This method displays the value of the current host's None address in
// standard compressed format. The None address is used by the host to disable
// listening to client activities on all the interfaces.
void displayIPv6NoneAddress()
{
   try
   {
      // Get the None address.
      IPAddress^ none = IPAddress::IPv6None;
      
      // Transform the None address to a string using the overloaded
      // ToString() method. Note that the resulting string is in the compact
      // form: "::".
      String^ ipv6None = none->ToString();

      Console::WriteLine( "The IPv6 None address is: {0}", ipv6None );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "->Item[displayIPv6NoneAddress] Exception: {0}", e );
   }
}
// </Snippet3>

// <Snippet4>
// This function checks whether the passed string represents a loop-back address.
void checkIPv6LoopBackAddress( String^ ipAddress )
{
   try
   {
      // Parse the passed String* to obtain the internal address
      // representation.
      IPAddress^ loopBack = IPAddress::Parse( ipAddress );
      
      // Verify that the address is a loopback address.
      bool isLoopBack = IPAddress::IsLoopback( loopBack );
      
      // Build the message.
      String^ msg;
      if ( isLoopBack )
      {
         msg = " is a loop back address.";
      }
      else
      {
         msg = " is not a loop back address.";
      }
      
      // Display the results.
      Console::WriteLine( String::Concat( ipAddress, msg ) );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "->Item[displayIPv6LoopBackAddress] Exception: {0}", e );
   }
}
// </Snippet4>

int main()
{
   // Verify that the current host supports IPv6 and also call WSAStartup.
   // If you do not use any IPv6 methods that call WSAStartup, you will get a
   // SocketException when using IPv6Loopback, IPv6Any or IPv6None.

   bool ipv6Supported = Socket::SupportsIPv6;
   
   // Display current host Loopback address.
   displayIPv6LoopBackAddress();
   
   // Display the current host's Any address.
   displayIPv6AnyAddress();
   
   // Display the current host's None address.
   displayIPv6NoneAddress();
   
   // Check that this is a loopback address.
   checkIPv6LoopBackAddress( "0::1" );
}
