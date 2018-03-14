---
title: "IPv6 Addressing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Internet Protocol version 6, addresses in"
  - "Neighbor Discovery"
  - "IPv6, enabling"
  - "IPv6, mobility and"
  - "Internet Protocol version 6, anycast addresses"
  - "IPv6, Neighbor Discovery"
  - "Internet Protocol version 6, auto-configuring"
  - "Internet Protocol version 6, enabling"
  - "IPv6, unicast addresses"
  - "IPv6, auto-configuring"
  - "Internet Protocol version 6, routing"
  - "IPv6, RFC documents"
  - "IPv6, routing"
  - "Internet Protocol version 6, disabling"
  - "Internet Protocol version 6, unicast addresses"
  - "IPv6, multicast addresses"
  - "Internet Protocol version 6, mobility and"
  - "Internet Protocol version 6, RFC documents"
  - "Internet Protocol version 6, Neighbor Discovery"
  - "IPv6, anycast addresses"
  - "Internet Protocol version 6, multicast addresses"
  - "IPv6, addresses in"
  - "IPv6, disabling"
ms.assetid: 20a104ae-1649-4649-a005-531a5cf74c93
caps.latest.revision: 10
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# IPv6 Addressing
In the Internet Protocol version 6 (IPv6), addresses are 128 bits long. One reason for such a large address space is to subdivide the available addresses into a hierarchy of routing domains that reflect the Internet's topology. Another reason is to map the addresses of network adapters (or interfaces) that connect devices to the network. IPv6 features an inherent capability to resolve addresses at their lowest level, which is at the network interface level, and also has auto-configuration capabilities.  
  
## Text Representation  
 The following are the three conventional forms used to represent the IPv6 addresses as text strings:  
  
-   **Colon-hexadecimal form**. This is the preferred form n:n:n:n:n:n:n:n. Each n represents the hexadecimal value of one of the eight 16-bit elements of the address. For example: `3FFE:FFFF:7654:FEDA:1245:BA98:3210:4562`.  
  
-   **Compressed form**. Due to the address length, it is common to have addresses containing a long string of zeros. To simplify writing these addresses, use the compressed form, in which a single contiguous sequence of 0 blocks are represented by a double-colon symbol (::). This symbol can appear only once in an address. For example, the multicast address `FFED:0:0:0:0:BA98:3210:4562` in compressed form is `FFED::BA98:3210:4562`. The unicast address `3FFE:FFFF:0:0:8:800:20C4:0` in compressed form is `3FFE:FFFF::8:800:20C4:0`. The loopback address `0:0:0:0:0:0:0:1` in compressed form is `::`1. The unspecified address `0:0:0:0:0:0:0:0` in compressed form is `::`.  
  
-   **Mixed form**. This form combines IPv4 and IPv6 addresses. In this case, the address format is n:n:n:n:n:n:d.d.d.d, where each n represents the hexadecimal values of the six IPv6 high-order 16-bit address elements, and each d represents the decimal value of an IPv4 address.  
  
## Address Types  
 The leading bits in the address define the specific IPv6 address type. The variable-length field containing these leading bits is called a Format Prefix (FP).  
  
 An IPv6 unicast address is divided into two parts. The first part contains the address prefix, and the second part contains the interface identifier. A concise way to express an IPv6 address/prefix combination is as follows: ipv6-address/prefix-length.  
  
 The following is an example of an address with a 64-bit prefix.  
  
 `3FFE:FFFF:0:CD30:0:0:0:0/64`.  
  
 The prefix in this example is `3FFE:FFFF:0:CD30`. The address can also be written in a compressed form, as `3FFE:FFFF:0:CD30::/64`.  
  
 IPv6 defines the following address types:  
  
-   **Unicast address**. An identifier for a single interface. A packet sent to this address is delivered to the identified interface. The unicast addresses are distinguished from the multicast addresses by the value of the high-order octet. The multicast addresses' high-order octet has the hexadecimal value of FF. Any other value for this octet identifies a unicast address. The following are different types of unicast addresses:  
  
    -   **Link-local addresses**. These addresses are used on a single link and have the following format: FE80::*InterfaceID*. Link-local addresses are used between nodes on a link for auto-address configuration, neighbor discovery, or when no routers are present. A link-local address is used primarily at startup and when the system has not yet acquired addresses of larger scope.  
  
    -   **Site-local addresses**. These addresses are used on a single site and have the following format: FEC0::*SubnetID*:*InterfaceID*. The site-local addresses are used for addressing inside a site without the need for a global prefix.  
  
    -   **Global IPv6 unicast addresses**. These addresses can be used across the Internet and have the following format: 010(FP, 3 bits) TLA ID (13 bits) Reserved (8 bits) NLA ID (24 bits) SLA ID (16 bits) *InterfaceID* (64 bits).  
  
-   **Multicast address**. An identifier for a set of interfaces (typically belonging to different nodes). A packet sent to this address is delivered to all the interfaces identified by the address. The multicast address types supersede the IPv4 broadcast addresses.  
  
-   **Anycast address**. An identifier for a set of interfaces (typically belonging to different nodes). A packet sent to this address is delivered to only one interface identified by the address. This is the nearest interface as identified by routing metrics. Anycast addresses are taken from the unicast address space and are not syntactically distinguishable. The addressed interface performs the distinction between unicast and anycast addresses as a function of its configuration.  
  
 In general, a node always has a link-local address. It might have a site-local address and one or more global addresses.  
  
## See Also  
 [Internet Protocol Version 6](../../../docs/framework/network-programming/internet-protocol-version-6.md)  
 [Sockets](../../../docs/framework/network-programming/sockets.md)
