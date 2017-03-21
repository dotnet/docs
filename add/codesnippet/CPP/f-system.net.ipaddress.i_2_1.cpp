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