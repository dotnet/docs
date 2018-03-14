/*
   This program converts a string containing an IP address, in dotted-quad notation for 
   IPv4 or in colon-hexadecimal for IPv6, into an instance of the IPAddress class.
   Then it uses the overloaded IPAddress ToString method to display the address in 
   its standard notation.
*/

// <Snippet1>

using System;
using System.Net;

class ParseAddress
{

  private static void Main(string[] args) 
  {
    string IPaddress;

    if (args.Length == 0)
    {
      Console.WriteLine("Please enter an IP address.");
      Console.WriteLine("Usage:   >cs_parse any IPv4 or IPv6 address.");
      Console.WriteLine("Example: >cs_parse 127.0.0.1");
      Console.WriteLine("Example: >cs_parse 0:0:0:0:0:0:0:1");
      return;
    }
    else
      IPaddress = args[0];

    // Get the list of the IPv6 addresses associated with the requested host.
    parse(IPaddress);
   
  }

  // This method calls the IPAddress.Parse method to check the ipAddress 
  // input string. If the ipAddress argument represents a syntatically correct IPv4 or
  // IPv6 address, the method displays the Parse output into quad-notation or
  // colon-hexadecimal notation, respectively. Otherwise, it displays an 
  // error message.
  private static void parse(string ipAddress)
  {
    try
    {
      // Create an instance of IPAddress for the specified address string (in 
      // dotted-quad, or colon-hexadecimal notation).
      IPAddress address = IPAddress.Parse(ipAddress);

      // Display the address in standard notation.
      Console.WriteLine("Parsing your input string: " + "\"" + ipAddress + "\"" + " produces this address (shown in its standard notation): "+ address.ToString());
    }

    catch(ArgumentNullException e)
    {
      Console.WriteLine("ArgumentNullException caught!!!");
      Console.WriteLine("Source : " + e.Source);
      Console.WriteLine("Message : " + e.Message);
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