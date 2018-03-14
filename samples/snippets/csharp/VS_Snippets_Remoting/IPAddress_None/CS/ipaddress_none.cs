/*
   This program demonstrates the 'None' field of 'IPAddress' class.
   Provides an IP address indicating that no network interface should be used.
*/

using System;
using System.Net;

class NoneFieldAddress
{
// <Snippet1>
   public static void Main()
   {
      // Gets the IP address indicating that no network interface should be used 
      // and converts it to a string.
      string address = IPAddress.None.ToString();
      Console.WriteLine("IP address : " + address);
   }
// </Snippet1>

}