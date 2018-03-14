/*
   This program demonstrates the 'GetHostName' method of 'Dns' class.
   It creates a 'DnsHostName' instance and calls 'GetHostName' method to get the local host 
   computer name. Then prints the computer name on the console.
*/

using System;
using System.Net;
using System.Net.Sockets;

class DnsHostName
{
   public static void Main()
   {
      DnsHostName dnsHostNameObj = new DnsHostName();
      dnsHostNameObj.DisplayLocalHostName();
   }
   
// <Snippet1>   
   public void DisplayLocalHostName()
   {
      try {
         // Get the local computer host name.
         String hostName = Dns.GetHostName();
         Console.WriteLine("Computer name :" + hostName);
      }
      catch(SocketException e) {
         Console.WriteLine("SocketException caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
	  catch(Exception e)
	  {
		  Console.WriteLine("Exception caught!!!");
		  Console.WriteLine("Source : " + e.Source);
		  Console.WriteLine("Message : " + e.Message);
	  }
   }
// </Snippet1>   
}