// <snippet1>
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Examples.Net.AddressChanges
{
    public class NetworkingExample
    {
        public static void Main()
        {
            NetworkChange.NetworkAddressChanged += new 
            NetworkAddressChangedEventHandler(AddressChangedCallback);
            Console.WriteLine("Listening for address changes. Press any key to exit.");
            Console.ReadLine();
        }
        static void AddressChangedCallback(object sender, EventArgs e)
        {
            
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface n in adapters)
            {
                Console.WriteLine("   {0} is {1}", n.Name, n.OperationalStatus);
            }
        }
    }
}
    // </snippet1>