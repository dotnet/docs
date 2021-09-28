---
description: "Learn more about: PNRP in Application Development"
title: "PNRP in Application Development"
ms.date: "03/30/2017"
ms.assetid: 265615d6-4423-4b5d-8626-752e456f4f4e
---
# PNRP in Application Development

In Windows Vista, networking applications can access name publication and resolution functions through a simplified PNRP application programming interface (API).  
  
## Implementing the Peer Name Resolution Protocol  

 With the simplified PNRP API, clouds are not explicitly specified to register the name and addresses; the PNRP component automatically determines the appropriate clouds to join and the addresses to publish within the clouds.  
  
 For highly simplified PNRP name resolution in Windows Vista, PNRP names are now integrated into the getaddrinfo() Windows Sockets function. To use PNRP to resolve a name to an IPv6 address, applications can use the getaddrinfo() function to resolve the Fully Qualified Domain Name (FQDN) name.prnp.net, in which name is peer name being resolved. The pnrp.net domain is a reserved domain in Windows Vista for PNRP name resolution.  
  
 Message passing between PeerToPeer applications is still handled by underlying architectures such as PeerChannel and WCF [Large Data and Streaming](../wcf/feature-details/large-data-and-streaming.md).  
  
## See also

- <xref:System.Net.PeerToPeer>
