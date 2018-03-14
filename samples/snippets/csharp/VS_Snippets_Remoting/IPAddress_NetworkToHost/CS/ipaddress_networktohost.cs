/*
   This program demonstrates 'NetworkToHostOrder(short)', 'NetworkToHostOrder(int)' and 
   'NetworkToHostOrder(long)' methods of 'IPAddress' class.
   It takes a string from commandline for each of above cases and convert it to the corresponding
   primitive type(i.e. short,int,long) value. Alternatively it uses default values for each cases.
   Then these values are converted from  network byte order to host byte order by  calling the 
   overloaded 'NetworkToHostOrder' methods of 'IPAddress' class. 
*/

using System;
using System.Net;

class NetworkToHostByteSample
{
   public static void Main()
   {      
     try
     {
       short networkByteShort = 4365;
       int networkByteInt = 286064640;
       long networkByteLong = 1228638273342013440;
       String networkByteString = "";

       NetworkToHostByteSample networkToHostByteSampleObj = new NetworkToHostByteSample();

       Console.Write("'Program converts Network byte order to Host byte order for short, int and long values'");
       Console.Write("\nEnter a short value for Convertion(press Enter for default, default is '4365') : ");
       networkByteString = Console.ReadLine();
       if(networkByteString.Length > 0)
         networkByteShort = Convert.ToInt16(networkByteString);
       networkToHostByteSampleObj.NetworkToHostOrder_Short(networkByteShort);

       networkByteString = "";
       Console.Write("\nEnter an Integer value for Convertion(press Enter for default, default is '286064640') : ");
       networkByteString = Console.ReadLine();
       if(networkByteString.Length > 0)
         networkByteInt = Convert.ToInt32(networkByteString);
       networkToHostByteSampleObj.NetworkToHostOrder_Integer(networkByteInt);
       
       networkByteString = "";
       Console.Write("\nEnter a long value for Convertion(press Enter for default, default is '1228638273342013440') : ");
       networkByteString = Console.ReadLine();
       if(networkByteString.Length > 0)
         networkByteLong = Convert.ToInt64(networkByteString);
       networkToHostByteSampleObj.NetworkToHostOrder_Long(networkByteLong);
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

// <Snippet1>
  public void NetworkToHostOrder_Short(short networkByte)
  {
    short hostByte;
    // Converts a short value from network byte order to host byte order.
    hostByte = IPAddress.NetworkToHostOrder(networkByte);
    Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte);
  }
// </Snippet1>

// <Snippet2>
  public void NetworkToHostOrder_Integer(int networkByte)
  {
    int hostByte;
    // Converts an integer value from network byte order to host byte order.
    hostByte = IPAddress.NetworkToHostOrder(networkByte);
    Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte);
  }
// </Snippet2>

// <Snippet3>
  public void NetworkToHostOrder_Long(long networkByte)
  {
    long hostByte;
    // Converts a long value from network byte order to host byte order.
    hostByte = IPAddress.NetworkToHostOrder(networkByte);
    Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte);
  }
// </Snippet3>
}
