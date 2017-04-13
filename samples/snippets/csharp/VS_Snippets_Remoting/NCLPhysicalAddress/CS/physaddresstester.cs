using System;
using System.Net.NetworkInformation;

namespace Examples.System.Net.Networking
{

    public class PhysicalAddressExample
    {
// <snippet1>
        static void DisplayAddressNone()
        {
            PhysicalAddress none = PhysicalAddress.None;
            
            Console.WriteLine("None: {0}", none.ToString());
            byte[] bytes = none.GetAddressBytes();
            foreach (byte b in bytes)
            {
                Console.Write("{0} ", b.ToString());
            }
            Console.WriteLine();
        }
// </snippet1>

// <snippet2>
        public static void ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}.{1}     ",
                    computerProperties.HostName, computerProperties.DomainName);
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return;
            }
                             
            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                Console.WriteLine();
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length,'='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.Write("  Physical address ........................ : ");
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for(int i = 0; i< bytes.Length; i++)
                {
                    // Display the physical address in hexadecimal.
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    // Insert a hyphen after each byte, unless we are at the end of the 
                    // address.
                    if (i != bytes.Length -1)
                    {
                         Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }
// </snippet2>
// <snippet3>
        public static void ParseTest()
        {
            PhysicalAddress address = PhysicalAddress.Parse("AC1EBA22");
            Console.WriteLine("Address parsed as {0}", address.ToString());
            PhysicalAddress address2 = PhysicalAddress.Parse("ac1eba22");
            Console.WriteLine("Address2 parsed as {0}", address2.ToString());
            bool test = address.Equals(address2);
            Console.WriteLine("Equal? {0}", test);
        }
// </snippet3>
// <snippet4>
            public static PhysicalAddress[] StoreNetworkInterfaceAddresses()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return null;
            }
                             
            PhysicalAddress[] addresses = new PhysicalAddress[nics.Length];
            int i = 0;
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                PhysicalAddress newAddress =  new PhysicalAddress(bytes);
                addresses[i++]=newAddress;
             }
            return addresses;
        }
// </snippet4>
//<snippet5>
        public static PhysicalAddress StrictParseAddress(string address)
        {
            PhysicalAddress newAddress = PhysicalAddress.Parse(address);
            if (PhysicalAddress.None.Equals(newAddress))
                return null;

            return newAddress;
        }
//</snippet5>

        public static void Main()
        {
           DisplayAddressNone();
           ShowNetworkInterfaces();
           ParseTest();
           PhysicalAddress[] addresses = StoreNetworkInterfaceAddresses();
           foreach (PhysicalAddress address in addresses)
           {
              Console.WriteLine(address.ToString());
           } 
         
          PhysicalAddress a =   StrictParseAddress(null);
          Console.WriteLine(a== null? "null" : a.ToString());
        }
    }
}


