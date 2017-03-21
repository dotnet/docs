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