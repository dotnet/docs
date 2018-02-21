---
title: "NAT Traversal using IPv6 and Teredo"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 568cd245-3300-49ef-a995-d81bf845d961
caps.latest.revision: 6
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# NAT Traversal using IPv6 and Teredo
Enhancements were made that provide support for Network Address Translation (NAT) traversal. These changes are designed for use with IPv6 and Teredo, but they are also applicable to other IP tunneling technologies. These enhancements affect classes in the <xref:System.Net> and related namespaces.  
  
 These changes can affect client and server applications that plan to use IP tunneling technologies.  
  
 The changes to support NAT traversal are available only for applications using .NET Framework version 4. These features are not available on earlier versions of the .NET Framework.  
  
## Overview  
 The Internet Protocol version 4 (IPv4) defined an IPv4 address as 32 bits long. As a result, IPv4 supports approximately 4 billion unique IP addresses (2^32). As the number of computers and network devices on the Internet expanded in the 1990s, the limits of the IPv4 address space became apparent.  
  
 One of several techniques used to extend the lifetime of IPv4 has been to deploy NAT to allow a single unique public IP address to represent a large number of private IP addresses (private Intranet). The private IP addresses behind the NAT device share the single public IPv4 address. The NAT device may be a dedicated hardware device (an inexpensive Wireless Access Point and router, for example) or a computer running a service to provide NAT. A device or service for this public IP address translates IP network packets between the public Internet and the private Intranet.  
  
 This scheme works well for client applications running on the private Intranet that send requests to other IP addresses (usually servers) on the Internet. The NAT device or server can keep a mapping of client requests so when a response is returned it knows where to send the response. But this scheme poses problems for applications running in the private Intranet behind the NAT device that want to provide services, listen for packets, and respond. This is particularly the case for peer-to-peer applications.  
  
 The IPv6 protocol defined an IPv4 address as 128 bits long. As a result, IPv6 supports very a large IP address space of 3.2 x 10^38 unique addresses (2^128). With an address space of this size, it is possible for every device connected to the Internet to be given a unique address. But there are problems. Much of the world is still using only IPv4. In particular, many of the existing routers and wireless access points used by small companies, organizations, and households do not support IPv6. Also some Internet service providers that serve these customers either do not support or have not configured support for IPv6.  
  
 Several IPv6 transition technologies have been developed to tunnel IPv6 addresses in an IPv4 packet. These technologies include 6to4, ISATAP, and Teredo tunnels that provide address assignment and host-to-host automatic tunneling for unicast IPv6 traffic when IPv6 hosts must traverse IP4 networks to reach other IPv6 networks. IPv6 packets are sent tunneled as IPv4 packets. Several tunneling techniques are being used that allow NAT traversal for IPv6 addresses through a NAT device.  
  
 Teredo is one of the IPv6 transition technologies which brings IPv6 connectivity to IPv4 networks. Teredo is documented in RFC 4380 published by the Internet Engineering Task Force (IETF). Windows XP SP2 and later provide support for a virtual Teredo adapter which can provide a public IPv6 address in the range 2001:0::/32. This IPv6 address can be used to listen for incoming connections from the Internet and can be provided to IPv6 enabled clients that wish to connect to the listening service. This frees an application from worrying about how to address a computer behind a NAT device, since the application can just connect to it using its IPv6 Teredo address.  
  
## Enhancements to Support NAT Traversal and Teredo  
 Enhancements are added to the <xref:System.Net>, <xref:System.Net.NetworkInformation>, and <xref:System.Net.Sockets> namespaces for supporting NAT traversal using IPv6 and Teredo.  
  
 Several methods are added to the <xref:System.Net.NetworkInformation.IPGlobalProperties?displayProperty=nameWithType> class to get the list of unicast IP addresses on the host. The <xref:System.Net.NetworkInformation.IPGlobalProperties.BeginGetUnicastAddresses%2A> method begins an asynchronous request to retrieve the stable unicast IP address table on the local computer. The <xref:System.Net.NetworkInformation.IPGlobalProperties.EndGetUnicastAddresses%2A> method ends a pending asynchronous request to retrieve the stable unicast IP address table on the local computer. The <xref:System.Net.NetworkInformation.IPGlobalProperties.GetUnicastAddresses%2A> method is a synchronous request to retrieve the stable unicast IP address table on the local computer, waiting until the address table stabilizes if necessary.  
  
 The <xref:System.Net.IPAddress.IsIPv6Teredo%2A?displayProperty=nameWithType> property can be used to determine if an <xref:System.Net.IPAddress> is an IPv6 Teredo address.  
  
 Using these new <xref:System.Net.NetworkInformation.IPGlobalProperties> class methods in combination with the <xref:System.Net.IPAddress.IsIPv6Teredo%2A> property allows an application to easily find the Teredo address. An application normally only needs to know the local Teredo address if it is communicating this information to remote applications. For example, a peer-to-peer application might send all of its IPv6 addresses to a matchmaking server which can then forward them to others peers to enable direct communication.  
  
 An application should normally set its listening service to listen on <xref:System.Net.IPAddress.IPv6Any?displayProperty=nameWithType> rather than on the local Teredo address. So if a remote client or peer has a direct IPv6 route to the host of the listening service, the client or peer can connect directly using IPv6 and not have to use Teredo to tunnel packets.  
  
 For TCP applications, the <xref:System.Net.Sockets.TcpListener?displayProperty=nameWithType> class has an <xref:System.Net.Sockets.TcpListener.AllowNatTraversal%2A> method to enable NAT traversal. For UDP applications, the <xref:System.Net.Sockets.UdpClient?displayProperty=nameWithType> class has an <xref:System.Net.Sockets.UdpClient.AllowNatTraversal%2A> method to enable NAT traversal.  
  
 For applications that use the <xref:System.Net.Sockets.Socket?displayProperty=nameWithType> and related classes, the <xref:System.Net.Sockets.Socket.GetSocketOption%2A> and <xref:System.Net.Sockets.Socket.SetSocketOption%2A> methods can be used with the <xref:System.Net.Sockets.SocketOptionName.IPProtectionLevel?displayProperty=nameWithType> socket option to query, enable, or disable NAT traversal.  
  
## See Also  
 <xref:System.Net.IPAddress.IsIPv6Teredo%2A?displayProperty=nameWithType>  
 <xref:System.Net.NetworkInformation.IPGlobalProperties.BeginGetUnicastAddresses%2A?displayProperty=nameWithType>  
 <xref:System.Net.NetworkInformation.IPGlobalProperties.EndGetUnicastAddresses%2A?displayProperty=nameWithType>  
 <xref:System.Net.NetworkInformation.IPGlobalProperties.GetUnicastAddresses%2A?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.IPProtectionLevel?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.Socket.SetIPProtectionLevel%2A?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.TcpListener.AllowNatTraversal%2A?displayProperty=nameWithType>  
 <xref:System.Net.Sockets.UdpClient.AllowNatTraversal%2A?displayProperty=nameWithType>
