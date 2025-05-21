---
title: "Internet Protocol version 6 (IPv6) overview"
description: Learn about the IPv6 protocol and how it differs from IPv4.
author: IEvangelist
ms.author: dapine
ms.date: 08/24/2022
helpviewer_keywords: 
- "Internet Protocol version 6"
- "Internet Protocol version 6, addresses in"
- "Internet Protocol version 6, anycast addresses"
- "Internet Protocol version 6, auto-configuring"
- "Internet Protocol version 6, disabling"
- "Internet Protocol version 6, enabling"
- "Internet Protocol version 6, improvements"
- "Internet Protocol version 6, mobility and"
- "Internet Protocol version 6, multicast addresses"
- "Internet Protocol version 6, Neighbor Discovery"
- "Internet Protocol version 6, RFC documents"
- "Internet Protocol version 6, routing"
- "Internet Protocol version 6, unicast addresses"
- "IPv4"
- "IPv6"
- "IPv6, addresses in"
- "IPv6, anycast addresses"
- "IPv6, auto-configuring"
- "IPv6, disabling"
- "IPv6, enabling"
- "IPv6, improvements"
- "IPv6, mobility and"
- "IPv6, multicast addresses"
- "IPv6, Neighbor Discovery"
- "IPv6, RFC documents"
- "IPv6, routing"
- "IPv6, unicast addresses"
- "Neighbor Discovery"
ms.topic: concept-article
---

# Internet Protocol version 6 (IPv6) overview

The Internet Protocol version 6 (IPv6) is a suite of standard protocols for the network layer of the Internet. IPv6 is designed to solve many of the problems of the current version of the Internet Protocol suite (known as IPv4) about address depletion, security, auto-configuration, extensibility, and so on. IPv6 expands the capabilities of the Internet to enable new kinds of applications, including peer-to-peer and mobile applications. The following are the main issues of the current IPv4 protocol:

- Rapid depletion of the address space.

  This has led to the use of Network Address Translators (NATs) that map multiple private addresses to a single public IP address. The main problems created by this mechanism are processing overhead and lack of end-to-end connectivity.

- Lack of hierarchy support.

  Because of its inherent predefined class organization, IPv4 lacks true hierarchical support. It is impossible to structure the IP addresses in a way that truly maps the network topology. This crucial design flaw creates the need for large routing tables to deliver IPv4 packets to any location on the Internet.

- Complex network configuration.

  With IPv4, addresses must be assigned statically or using a configuration protocol such as DHCP. In an ideal situation, hosts would not have to rely on the administration of a DHCP infrastructure. Instead, they would be able to configure themselves based on the network segment in which they are located.

- Lack of built-in authentication and confidentiality.

  IPv4 does not require support for any mechanism that provides authentication or encryption of the exchanged data. This changes with IPv6. Internet Protocol security (IPSec) is an IPv6 support requirement.

 A new protocol suite must satisfy the following basic requirements:

- Large-scale routing and addressing with low overhead.
- Auto-configuration for various connecting situations.
- Built-in authentication and confidentiality.

## IPv6 addressing

With IPv6, addresses are 128 bits long. One reason for such a large address space is to subdivide the available addresses into a hierarchy of routing domains that reflect the Internet's topology. Another reason is to map the addresses of network adapters (or interfaces) that connect devices to the network. IPv6 features an inherent capability to resolve addresses at their lowest level, which is at the network interface level, and also has auto-configuration capabilities.

### Text representation

The following are the three conventional forms used to represent the IPv6 addresses as text strings:

- **Colon-hexadecimal form:**

  This is the preferred form `n:n:n:n:n:n:n:n`. Each `n` represents the hexadecimal value of one of the eight 16-bit elements of the address. For example: `3FFE:FFFF:7654:FEDA:1245:BA98:3210:4562`.

- **Compressed form:**

  Due to the address length, it is common to have addresses containing a long string of zeros. To simplify writing these addresses, use the compressed form, in which a single contiguous sequence of 0 blocks is represented by a double-colon symbol (`::`). This symbol can appear only once in an address. For example, the multicast address `FFED:0:0:0:0:BA98:3210:4562` in compressed form is `FFED::BA98:3210:4562`. The unicast address `3FFE:FFFF:0:0:8:800:20C4:0` in compressed form is `3FFE:FFFF::8:800:20C4:0`. The loopback address `0:0:0:0:0:0:0:1` in compressed form is `::1`. The unspecified address `0:0:0:0:0:0:0:0` in compressed form is `::`.

- **Mixed form:**

  This form combines IPv4 and IPv6 addresses. In this case, the address format is `n:n:n:n:n:n:d.d.d.d`, where each n represents the hexadecimal values of the six IPv6 high-order 16-bit address elements, and each d represents the decimal value of an IPv4 address.

### Address types

The leading bits in the address define the specific IPv6 address type. The variable-length field containing these leading bits is called a Format Prefix (FP).

An IPv6 unicast address is divided into two parts. The first part contains the address prefix, and the second part contains the interface identifier. A concise way to express an IPv6 address/prefix combination is as follows: ipv6-address/prefix-length.

The following is an example of an address with a 64-bit prefix.

`3FFE:FFFF:0:CD30:0:0:0:0/64`.

The prefix in this example is `3FFE:FFFF:0:CD30`. The address can also be written in a compressed form, as `3FFE:FFFF:0:CD30::/64`.

IPv6 defines the following address types:

- **Unicast address:**

  An identifier for a single interface. A packet sent to this address is delivered to the identified interface. The unicast addresses are distinguished from the multicast addresses by the value of the high-order octet. The multicast addresses' high-order octet has the hexadecimal value of FF. Any other value for this octet identifies a unicast address. The following are different types of unicast addresses:

  - **Link-local addresses:**

    These addresses are used on a single link and have the following format: `FE80::*InterfaceID*`. Link-local addresses are used between nodes on a link for auto-address configuration, neighbor discovery, or when no routers are present. A link-local address is used primarily at startup and when the system has not yet acquired addresses of larger scope.

  - **Site-local addresses:**

  These addresses are used on a single site and have the following format: `FEC0::*SubnetID*:*InterfaceID*`. The site-local addresses are used for addressing inside a site without the need for a global prefix.

  - **Global IPv6 unicast addresses:**

  These addresses can be used across the Internet and have the following format: `*GlobalRoutingPrefix*::*SubnetID*:*InterfaceID*`.

- **Multicast address:**

  An identifier for a set of interfaces (typically belonging to different nodes). A packet sent to this address is delivered to all the interfaces identified by the address. The multicast address types supersede the IPv4 broadcast addresses.

- **Anycast address:**

  An identifier for a set of interfaces (typically belonging to different nodes). A packet sent to this address is delivered to only one interface identified by the address. This is the nearest interface as identified by routing metrics. Anycast addresses are taken from the unicast address space and are not syntactically distinguishable. The addressed interface performs the distinction between unicast and anycast addresses as a function of its configuration.

In general, a node always has a link-local address. It might have a site-local address and one or more global addresses.

## IPv6 routing

A flexible routing mechanism is a benefit of IPv6. Due to how IPv4 network IDs were and are allocated, large routing tables need to be maintained by the routers that are on the Internet backbones. These routers must know all the routes to forward packets that are potentially directed to any node on the Internet. With its ability to aggregate addresses, IPv6 allows flexible addressing and drastically reduces the size of routing tables. In this new addressing architecture, intermediate routers must keep track only of the local portion of their network to forward the messages appropriately.

### Neighbor discovery

Some of the features provided by _neighbor discovery_ are:

- **Router discovery:** This allows hosts to identify local routers.
- **Address resolution:** This allows nodes to resolve a link-layer address for a corresponding next-hop address (a replacement for Address Resolution Protocol [ARP]).
- **Address auto-configuration:** This allows hosts to automatically configure site-local and global addresses.

Neighbor discovery uses Internet Control Message Protocol for IPv6 (ICMPv6) messages that include:

- **Router advertisement:** Sent by a router on a pseudo-periodic basis or in response to a router solicitation. IPv6 routers use router advertisements to advertise their availability, address prefixes, and other parameters.
- **Router solicitation:** Sent by a host to request that routers on the link send a router advertisement immediately.
- **Neighbor solicitation:** Sent by nodes for address resolution, duplicate address detection, or to verify that a neighbor is still reachable.
- **Neighbor advertisement:** Sent by nodes to respond to a neighbor solicitation or to notify neighbors of a change in link-layer address.
- **Redirect:** Sent by routers to indicate a better next-hop address to a particular destination for a sending node.

## IPv6 auto-configuration

One important goal for IPv6 is to support node Plug and Play. That is, it should be possible to plug a node into an IPv6 network and have it automatically configured without any human intervention.

### Auto-configuration types

IPv6 supports the following types of auto-configuration:

- **Stateful auto-configuration:**

  This type of configuration requires a certain level of human intervention because it needs a Dynamic Host Configuration Protocol for IPv6 (DHCPv6) server for the installation and administration of the nodes. The DHCPv6 server keeps a list of nodes to which it supplies configuration information. It also maintains state information so the server knows how long each address is in use, and when it might be available for reassignment.

- **Stateless auto-configuration:**

  This type of configuration is suitable for small organizations and individuals. In this case, each host determines its addresses from the contents of received router advertisements. Using the IEEE EUI-64 standard to define the network ID portion of the address, it is reasonable to assume the uniqueness of the host address on the link.

Regardless of how the address is determined, the node must verify that its potential address is unique to the local link. This is done by sending a neighbor solicitation message to the potential address. If the node receives any response, it knows that the address is already in use and must determine another address.

### IPv6 mobility

 The proliferation of mobile devices has introduced a new requirement: A device must be able to arbitrarily change locations on the IPv6 Internet and still maintain existing connections. To provide this functionality, a mobile node is assigned a home address at which it can always be reached. When the mobile node is at home, it connects to the home link and uses its home address. When the mobile node is away from home, a home agent, which is usually a router, relays messages between the mobile node and the nodes with which it is communicating.

## Disable or enable IPv6

To use the IPv6 protocol, ensure that you are running a version of the operating system that supports IPv6 and ensure that the operating system and the networking classes are configured properly.

### Configuration Steps

 The following table lists various configurations

| OS IPv6 enabled? | Code IPv6 enabled? | Description                                                                                            |
|------------------|--------------------|--------------------------------------------------------------------------------------------------------|
| ❌ No            | ❌ No               | Can parse IPv6 addresses.                                                                              |
| ❌ No            | ✔️ Yes             | Can parse IPv6 addresses.                                                                              |
| ✔️ Yes          | ❌ No               | Can parse IPv6 addresses and resolve IPv6 addresses using name resolution methods not marked obsolete. |
| ✔️ Yes          | ✔️ Yes             | Can parse and resolve IPv6 addresses using all methods including those marked obsolete.                |

IPv6 is enabled by default. To configure this switch in an environment variable, use the `DOTNET_SYSTEM_NET_DISABLEIPV6` environment variable. For more information, see [.NET environment variables: DOTNET_SYSTEM_NET_DISABLEIPV6](../../core/tools/dotnet-environment-variables.md#dotnet_system_net_disableipv6).

## See also

- [Networking in .NET](overview.md)
- [Sockets in .NET](./sockets/sockets-overview.md)
- <xref:System.AppContext?displayProperty=fullName>
