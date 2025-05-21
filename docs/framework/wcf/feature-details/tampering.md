---
description: "Learn more about: Tampering"
title: "Tampering"
ms.date: "03/30/2017"
ms.assetid: 3bad93be-60bb-4f89-96ab-a1c3dc7c0fad
ms.topic: concept-article
---
# Tampering

*Tampering* is the act of altering a message, or the delivery of a message, and using the altered message for a purpose other than what it was intended for.  
  
## Do Not Disable WS-Addressing  

 The WS-Addressing specification provides address headers on each message, allowing a message recipient to verify the sender of the message. You can disable this feature by setting the <xref:System.ServiceModel.Channels.MessageVersion.Addressing%2A> property to <xref:System.ServiceModel.Channels.AddressingVersion.None%2A>.  
  
 When the security mode is set to Message, and if WS-Addressing is disabled, an attacker could take a request from a client and send it to another service, and the second service has no way of detecting that the message came from the original client. In effect, the first service can pretend that it is a client when talking to the second service.  
  
 To mitigate this, never set the <xref:System.ServiceModel.Channels.MessageVersion.Addressing%2A> property to <xref:System.ServiceModel.Channels.AddressingVersion.None%2A>, and avoid the use of <xref:System.ServiceModel.Channels.MessageVersion>, such as the static <xref:System.ServiceModel.Channels.MessageVersion.Soap12%2A> property, which sets the <xref:System.ServiceModel.Channels.MessageVersion.Addressing%2A> property to <xref:System.ServiceModel.Channels.AddressingVersion.None%2A>.  
  
## See also

- [Security Considerations](security-considerations-in-wcf.md)
- [Information Disclosure](information-disclosure.md)
- [Elevation of Privilege](elevation-of-privilege.md)
- [Denial of Service](denial-of-service.md)
- [Unsupported Scenarios](unsupported-scenarios.md)
- [Replay Attacks](replay-attacks.md)
