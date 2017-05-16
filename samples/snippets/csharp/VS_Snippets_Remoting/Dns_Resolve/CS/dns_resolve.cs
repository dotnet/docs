/*
   This program demonstrates 'Resolve' method of 'Dns' class.
   It takes a URL or IP address string from commandline or uses default value and obtains the 'IPHostEntry' 
   object by calling 'Resolve' method of 'Dns' class. Then prints host name, IP address list and aliases.
*/

using System;
using System.Net;
using System.Net.Sockets;

class DnsResolve
{
   public static void Main()
   {
      String hostString = "";
      DnsResolve myDnsResolve = new DnsResolve();
      Console.Write("Type a URL or IP address (press Enter for default, default is '207.46.131.199') : ");
      hostString = Console.ReadLine();
      if(hostString.Length > 0)      
         myDnsResolve.DisplayHostAddress(hostString);
      else
         myDnsResolve.DisplayHostAddress("207.46.131.199");
   }

   public void DisplayHostAddress(String hostString)
   {
      // Call the Resolve method passing a DNS style host name or an IP address in dotted-quad notation 
      // (for example, "www.contoso.com" or "207.46.131.199") to obtain an IPHostEntry instance that contains 
      // address information for the specified host.
// <Snippet1>   
     try {
         IPHostEntry hostInfo = Dns.Resolve(hostString);
         // Get the IP address list that resolves to the host names contained in the 
         // Alias property.
         IPAddress[] address = hostInfo.AddressList;
         // Get the alias names of the addresses in the IP address list.
         String[] alias = hostInfo.Aliases;

         Console.WriteLine("Host name : " + hostInfo.HostName);
         Console.WriteLine("\nAliases : ");
         for(int index=0; index < alias.Length; index++) {
           Console.WriteLine(alias[index]);
         } 
         Console.WriteLine("\nIP Address list :");
         for(int index=0; index < address.Length; index++) {
            Console.WriteLine(address[index]);
         }
      }
      catch(SocketException e) 
      {
         Console.WriteLine("SocketException caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
      catch(ArgumentNullException e)
      {
	 Console.WriteLine("ArgumentNullException caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
	  catch(NullReferenceException e)
	  {
		  Console.WriteLine("NullReferenceException caught!!!");
		  Console.WriteLine("Source : " + e.Source);
		  Console.WriteLine("Message : " + e.Message);
	  }
	  catch(Exception e)
	  {
		  Console.WriteLine("Exception caught!!!");
		  Console.WriteLine("Source : " + e.Source);
		  Console.WriteLine("Message : " + e.Message);
	  }
// </Snippet1>   
   }
}