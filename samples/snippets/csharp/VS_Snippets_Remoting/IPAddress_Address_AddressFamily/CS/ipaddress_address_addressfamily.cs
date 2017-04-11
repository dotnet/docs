/*
   This program demonstrates the 'AddressFamily' and 'Address' property of 'IPAddress' class.
   It takes an IP address string from commandline(or uses a default value) and creates an instance of 
   'IPAddress' class by calling 'Parse' method of 'IPAddress' class. Then it prints the value of 
   'AddressFamily' and 'Address' property (which is an integer value).
*/

using System;
using System.Net;

class IpAddressSample
{
   public static void Main()
   {
     try
     {
       String IpAddressString = "";
       Console.Write("Type an IP address (press Enter for default, default is '64.14.132.100') : ");
       IpAddressString = Console.ReadLine();
       if(IpAddressString.Length <= 0)
       IpAddressString = "64.14.132.100";
       IpAddressSample IpAddressSampleObj = new IpAddressSample();
       IpAddressSampleObj.PrintAddressFamily(IpAddressString);
       IpAddressSampleObj.PrintAddress(IpAddressString);		   
     }
     catch(Exception e)
     {
       Console.WriteLine("Exception caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }
   }

// <Snippet1>
  public void PrintAddressFamily(String IpAddressString)
  {
    // Creates an instance of the IPAddress for the specified IP string in 
    // dotted-quad notation. 
    IPAddress hostIPAddress = IPAddress.Parse(IpAddressString);
    Console.WriteLine("\nIP address family : " + hostIPAddress.AddressFamily);  
  }
// </Snippet1>

// <Snippet2>
  public void PrintAddress(String IpAddressString)
  {
    // Creates an instance of the IPAddress for the specified IP string in 
    // dotted-quad notation. 
    IPAddress hostIPAddress = IPAddress.Parse(IpAddressString);
    Console.WriteLine("\nThe IP address '" + IpAddressString + "' is {0}", hostIPAddress.ToString()); 
  }
// </Snippet2>
}