/*
   This program demostrates 'AddressList' property of 'IPHostEntry' class.
   It takes a URL from commandline(or uses default value) and obtains a
   'IPHostEntry' object by calling 'GetHostByName' method of 'Dns' class and
   prints the host name and IP addresses associated with the specified URL.      
*/

using System;
using System.Net;
using System.Net.Sockets;

class HostInfoSample
{
   public static void Main() 
   {
      String hostString = " ";
      // Create an instance of HostInfoSample class.
      HostInfoSample hostInfoSampleObj = new HostInfoSample();
      Console.Write("Type a URL(or press Enter for default, default is 'www.microsoft.net') : ");
      hostString = Console.ReadLine();
      if(hostString.Length > 0)
         hostInfoSampleObj.GetIpAddressList(hostString);
      else
         hostInfoSampleObj.GetIpAddressList("www.microsoft.net");
   }
// <Snippet1>
   
   public void GetIpAddressList(String hostString)
   {
	   try 
	   {
		   // Get 'IPHostEntry' object containing information like host name, IP addresses, aliases for a host.
		   IPHostEntry hostInfo = Dns.GetHostByName(hostString);
		   Console.WriteLine("Host name : " + hostInfo.HostName);
		   Console.WriteLine("IP address List : ");
		   for(int index=0; index < hostInfo.AddressList.Length; index++)
		   {
			   Console.WriteLine(hostInfo.AddressList[index]);
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
	   catch(Exception e)
	   {
		   Console.WriteLine("Exception caught!!!");
		   Console.WriteLine("Source : " + e.Source);
		   Console.WriteLine("Message : " + e.Message);
	   }
   }
// </Snippet1>
}