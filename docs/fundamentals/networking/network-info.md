---
title: Network availability
description: Learn how to detect changes in network availability and ping a host with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/24/2022
ms.topic: article
---

# Network availability

The <xref:System.Net.NetworkInformation> namespace enables you to gather information about network events, changes, statistics, and properties. In this article, you'll learn how to use the <xref:System.Net.NetworkInformation.NetworkChange?displayProperty=nameWithType> class to determine whether the network address or availability has changed. Additionally, you'll see about the network statistics and properties on an interface or protocol basis. Finally, you'll use the <xref:System.Net.NetworkInformation.Ping?displayProperty=nameWithType> class to determine whether a remote host is reachable.

## Network change events

The <xref:System.Net.NetworkInformation.NetworkChange?displayProperty=nameWithType> class enables you to determine whether the network address or availability has changed. To use this class, create an event handler to process the change, and associate it with a <xref:System.Net.NetworkInformation.NetworkAddressChangedEventHandler> or a <xref:System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler>.

:::code language="csharp" source="snippets/misc/Program.NetworkChange.cs" id="networkavailabilitychanged":::

The preceding C# code:

- Registers an event handler for the <xref:System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged?displayProperty=nameWithType> event.
- The event handler simply writes the availability status to the console.
- A message is written to the console letting the user know that the code is listening for changes in network availability and waits for a key press to exit.
- Unregisters the event handler.

:::code language="csharp" source="snippets/misc/Program.NetworkChange.cs" id="networkaddresschanged":::

The preceding C# code:

- Registers an event handler for the <xref:System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged?displayProperty=nameWithType> event.
- The event handler iterates over <xref:System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces?displayProperty=nameWithType>, writing their name and operational status to the console.
- A message is written to the console letting the user know that the code is listening for changes in network availability and waits for a key press to exit.
- Unregisters the event handler.

## Network statistics and properties

You can gather network statistics and properties on an interface or protocol basis. The <xref:System.Net.NetworkInformation.NetworkInterface>, <xref:System.Net.NetworkInformation.NetworkInterfaceType>, and <xref:System.Net.NetworkInformation.PhysicalAddress> classes give information about a particular network interface, while the <xref:System.Net.NetworkInformation.IPInterfaceProperties>, <xref:System.Net.NetworkInformation.IPGlobalProperties>, <xref:System.Net.NetworkInformation.IPGlobalStatistics>, <xref:System.Net.NetworkInformation.TcpStatistics>, and <xref:System.Net.NetworkInformation.UdpStatistics> classes give information about layer 3 and layer 4 packets.

:::code language="csharp" source="snippets/misc/Program.IPGlobalProperties.cs" id="ipglobalprops":::

The preceding C# code:

- Calls a custom `ShowStatistics` method to display the statistics for each protocol.
- The `ShowStatistics` method calls <xref:System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties?displayProperty=nameWithType>, and depending on the given <xref:System.Net.NetworkInformation.NetworkInterfaceComponent> will either call <xref:System.Net.NetworkInformation.IPGlobalProperties.GetIPv4GlobalStatistics?displayProperty=nameWithType> or <xref:System.Net.NetworkInformation.IPGlobalProperties.GetIPv6GlobalStatistics?displayProperty=nameWithType>.
- The <xref:System.Net.NetworkInformation.TcpStatistics> are written to the console.

## Determine if a remote host is reachable

You can use the <xref:System.Net.NetworkInformation.Ping> class to determine whether a remote host is up, on the network, and reachable.

:::code language="csharp" source="snippets/misc/Program.Ping.cs" id="ping":::

The preceding C# code:

- Instantiate a <xref:System.Net.NetworkInformation.Ping> object.
- Calls <xref:System.Net.NetworkInformation.Ping.SendPingAsync(System.String)?displayProperty=nameWithType> with the `"stackoverflow.com"` hostname parameter.
- The status of the ping is written to the console.

## See also

- [Network programming in .NET](overview.md)
- <xref:System.Net.NetworkInformation.NetworkInterface>
