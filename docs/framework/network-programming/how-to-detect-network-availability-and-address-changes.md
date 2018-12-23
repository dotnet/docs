---
title: "How to: Detect Network Availability and Address Changes"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Network"
ms.assetid: d4377115-4a76-4848-ab23-4898d65c771c
---
# How to: Detect Network Availability and Address Changes
This sample shows how to detect changes in the network address of an interface.  
  
## Example  
  
```  
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
```  
  
## Compiling the Code  
 This example requires:  
  
-   References to the **System.Net** namespace.
