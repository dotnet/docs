---
title: "Internet Protocol Version 6"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "IPv6, improvements"
  - "IPv4"
  - "IPv6"
  - "Internet Protocol version 6, improvements"
  - "Internet Protocol version 6"
ms.assetid: e6fa8ebd-010a-4c48-a5ec-a5102c53c06f
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Internet Protocol Version 6
The Internet Protocol version 6 (IPv6) is a new suite of standard protocols for the network layer of the Internet. IPv6 is designed to solve many of the problems of the current version of the Internet Protocol suite (known as IPv4) with regard to address depletion, security, auto-configuration, extensibility, and so on. IPv6 expands the capabilities of the Internet to enable new kinds of applications, including peer-to-peer and mobile applications. The following are the main issues of the current IPv4 protocol:  
  
-   Rapid depletion of the address space.  
  
     This has led to the use of Network Address Translators (NATs) that map multiple private addresses to a single public IP address. The main problems created by this mechanism are processing overhead and lack of end-to-end connectivity.  
  
-   Lack of hierarchy support.  
  
     Because of its inherent predefined class organization, IPv4 lacks true hierarchical support. It is impossible to structure the IP addresses in a way that truly maps the network topology. This crucial design flaw creates the need for large routing tables to deliver IPv4 packets to any location on the Internet.  
  
-   Complex network configuration.  
  
     With IPv4, addresses must be assigned statically or using a configuration protocol such as DHCP. In an ideal situation, hosts would not have to rely on the administration of a DHCP infrastructure. Instead, they would be able to configure themselves based on the network segment in which they are located.  
  
-   Lack of built-in authentication and confidentiality.  
  
     IPv4 does not require the support for any mechanism that provides authentication or encryption of the exchanged data. This changes with IPv6. Internet Protocol security (IPSec) is an IPv6 support requirement.  
  
 A new protocol suite must satisfy the following basic requirements:  
  
-   Large-scale routing and addressing with low overhead.  
  
-   Auto-configuration for various connecting situations.  
  
-   Built-in authentication and confidentiality.  
  
 For more information, see [IPv6 Addressing](../../../docs/framework/network-programming/ipv6-addressing.md), [IPv6 Routing](../../../docs/framework/network-programming/ipv6-routing.md), [IPv6 Auto-Configuration](../../../docs/framework/network-programming/ipv6-auto-configuration.md), [Enabling and Disabling IPv6](../../../docs/framework/network-programming/enabling-and-disabling-ipv6.md), and [How to: Modify the Computer Configuration File to Enable IPv6 Support](../../../docs/framework/network-programming/how-to-modify-the-computer-configuration-file-to-enable-ipv6-support.md).  
  
## References  
 The following are selected RFC documents that you can find at the Internet Engineering Task Force site ([http://www.ietf.org](http://www.ietf.org/)):  
  
-   RFC 1287, Towards the Future Internet Architecture.  
  
-   RFC 1454, Comparison of Proposals for Next Version of IP.  
  
-   RFC 2373, IP Version 6 Addressing Architecture.  
  
-   RFC 2374, An IPv6 Aggregatable Global Unicast Address Format.  
  
 You can also find IPv6-related information on the [IPv6 area on Technet](http://go.microsoft.com/fwlink/?LinkID=179658).  
  
## See Also  
 [IPv6 Sockets Sample](http://go.microsoft.com/fwlink/?LinkID=179568)  
 [Network Programming Samples](../../../docs/framework/network-programming/network-programming-samples.md)  
 [Sockets](../../../docs/framework/network-programming/sockets.md)
