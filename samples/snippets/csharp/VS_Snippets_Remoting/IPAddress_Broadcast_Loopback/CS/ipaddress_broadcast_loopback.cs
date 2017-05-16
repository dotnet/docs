/*
   This program demonstrates the  'Loopback' and 'Broadcast' field of 'IPAddress' class.
   It prints the loopback IP address 127.0.0.1 and Broadcast IP address 255.255.255.255
*/


using System;
using System.Net;

class LoopbackBroadcastSample
{
   public static void Main()
   {
     LoopbackBroadcastSample loopbackBroadcastSampleObj = new LoopbackBroadcastSample();
     loopbackBroadcastSampleObj.PrintLoopbackAddress();
     loopbackBroadcastSampleObj.PrintBroadcastAddress();
   }

// <Snippet1>
  public void PrintLoopbackAddress()
  {
    // Gets the IP loopback address and converts it to a string.
    String IpAddressString = IPAddress.Loopback.ToString();
    Console.WriteLine("Loopback IP address : " + IpAddressString);
  }
// </Snippet1>

// <Snippet2>
  public void PrintBroadcastAddress()
  {
    // Get the IP Broadcast address and convert it to string.
    string ipAddressString = IPAddress.Broadcast.ToString();
    Console.WriteLine("Broadcast IP address: {0}", ipAddressString);
  }
// </Snippet2>
}