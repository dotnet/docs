/*
   This program checks whether the specified address is a loopback address.  
   It invokes the IPAddress Parse method to translate the address 
   input string into the correct internal format.
   The IP address string must be in dotted-quad notation for IPv4 or in 
   colon-hexadecimal notation for IPv6. 
*/

// <Snippet1>

using System;
using System.Net;
using System.Net.Sockets;

class IsLoopbackTest
{

  private static void Main(string[] args) 
  {
    
    if (args.Length == 0)
    {
      // No parameters entered. Display program usage.
      Console.WriteLine("Please enter an IP address.");
      Console.WriteLine("Usage:   >ipaddress_isloopback any IPv4 or IPv6 address.");
      Console.WriteLine("Example: >ipaddress_isloopback 127.0.0.1");
      Console.WriteLine("Example: >ipaddress_isloopback 0:0:0:0:0:0:0:1");
      return;
    }
    else
      // Parse the address string entered by the user.
      parse(args[0]);
   
  }

  // This method calls the IPAddress.Parse method to check if the 
  // passed ipAddress parameter is in the correct format.
  // Then it checks whether it represents a loopback address.
  // Finally, it displays the results.
  private static void parse(string ipAddress)
  {
    string loopBack=" is not a loopback address.";

    try
    {
      // Perform syntax check by parsing the address string entered by the user.
      IPAddress address = IPAddress.Parse(ipAddress);

      // Perform semantic check by verifying that the address is a valid IPv4 
      // or IPv6 loopback address. 
      if(IPAddress.IsLoopback(address)&& address.AddressFamily == AddressFamily.InterNetworkV6)
        loopBack =  " is an IPv6 loopback address " +
                    "whose internal format is: " + address.ToString() + ".";
      else
        if(IPAddress.IsLoopback(address) && address.AddressFamily == AddressFamily.InterNetwork)
          loopBack = " is an IPv4 loopback address " +
                     "whose internal format is: " + address.ToString() + ".";

      // Display the results.
      Console.WriteLine("Your input address: " + "\"" + ipAddress + "\"" + loopBack);
    }

    catch(FormatException e)
    {
      Console.WriteLine("FormatException caught!!!");
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
}
// </Snippet1>