   // Determine the Internet Protocol(IP) addresses for a host.
public:
   static void DoGetHostAddress(String^ hostname)
   {
      array<IPAddress^>^ ips;
      ips = Dns::GetHostAddresses(hostname);

      Console::WriteLine("GetHostAddresses({0}) returns:", hostname);
      for each ( IPAddress^ ip in ips )
      {
         Console::Write( "{0} ", ip );
      }
      Console::WriteLine( "" );
   }
  