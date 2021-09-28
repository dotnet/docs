---
description: "Learn more about: NetworkInformation"
title: "NetworkInformation"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Network"
ms.assetid: 31b44dd3-b903-4a48-8419-40419a3e4038
---
# NetworkInformation

The <xref:System.Net.NetworkInformation> namespace enables you to gather information about network events, changes, statistics, and properties. You can also determine whether a remote host is reachable by using the <xref:System.Net.NetworkInformation.Ping?displayProperty=nameWithType> class.  
  
## Network Availability and Events  

 The <xref:System.Net.NetworkInformation.NetworkChange?displayProperty=nameWithType> class enables you to determine whether the network address or availability has changed. To use this class, create an event handler to process the change, and associate it with a <xref:System.Net.NetworkInformation.NetworkAddressChangedEventHandler> or a <xref:System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler>. For more information, see [How to: Detect Network Availability and Address Changes](how-to-detect-network-availability-and-address-changes.md).  
  
## Network Statistics and Properties  

 You can gather network statistics and properties on an interface or protocol basis. The <xref:System.Net.NetworkInformation.NetworkInterface>, <xref:System.Net.NetworkInformation.NetworkInterfaceType>, and <xref:System.Net.NetworkInformation.PhysicalAddress> classes give information about a particular network interface, while the <xref:System.Net.NetworkInformation.IPInterfaceProperties>, <xref:System.Net.NetworkInformation.IPGlobalProperties>, <xref:System.Net.NetworkInformation.IPGlobalStatistics>, <xref:System.Net.NetworkInformation.TcpStatistics>, and <xref:System.Net.NetworkInformation.UdpStatistics> classes give information about layer 3 and layer 4 packets. For more information, see [How to: Get Interface and Protocol Information](how-to-get-interface-and-protocol-information.md).  
  
## Determine if a Remote Host is Reachable  

 You can use the <xref:System.Net.NetworkInformation.Ping> class to determine whether a Remote Host is up, on the network, and reachable. For more information, see [How to: Ping a Host](how-to-ping-a-host.md).  
  
## See also

- [Network Programming Samples](network-programming-samples.md)

<!-- to-do: review sample links
- [Network Information Technology Sample](https://archive.msdn.microsoft.com/nclsamples/Wiki/View.aspx?title=Network%20Information)
- [NetStat Tool Technology Sample](https://archive.msdn.microsoft.com/nclsamples/Wiki/View.aspx?title=NetStat%20Tool)
- [Ping Client Technology Sample](https://archive.msdn.microsoft.com/nclsamples/Wiki/View.aspx?title=Ping%20Client)
-->
