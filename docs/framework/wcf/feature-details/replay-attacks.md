---
description: "Learn more about: Replay Attacks"
title: "Replay Attacks"
ms.date: "03/30/2017"
ms.assetid: 7a17e040-93cd-4432-81b9-9f62fec78c8f
---
# Replay Attacks

A *replay attack* occurs when an attacker copies a stream of messages between two parties and replays the stream to one or more of the parties. Unless mitigated, the computers subject to the attack process the stream as legitimate messages, resulting in a range of bad consequences, such as redundant orders of an item.  
  
## Bindings May Be Subject to Reflection Attacks  

 *Reflection attacks* are replays of messages back to a sender as if they came from the receiver as the reply. The standard *replay detection* in the Windows Communication Foundation (WCF) mechanism does not automatically handle this.  
  
 Reflection attacks are mitigated by default because the WCF service model adds a signed message ID to request messages and expects a signed `relates-to` header on response messages. Consequently, the request message cannot be replayed as a response. In secure reliable message (RM) scenarios, reflection attacks are mitigated because:  
  
- The create sequence and create sequence response message schemas are different.  
  
- For simplex sequences, sequence messages the client sends cannot be replayed back to it because the client cannot understand such messages.  
  
- For duplex sequences, the two sequence IDs must be unique. Thus, an outgoing sequence message cannot be replayed back as an incoming sequence message (all sequence headers and bodies are signed, too).  
  
 The only bindings that are susceptible to reflection attacks are those without WS-Addressing: custom bindings that have WS-Addressing disabled and use the symmetric key-based security. The <xref:System.ServiceModel.BasicHttpBinding> does not use WS-Addressing by default, but it does not use symmetric key-based security in a way that allows it to be vulnerable to this attack.  
  
 The mitigation for custom bindings is to not establish security context or to require WS-Addressing headers.  
  
## Web Farm: Attacker Replays Request to Multiple Nodes  

 A client uses a service that is implemented on a Web farm. An attacker replays a request that was sent to one node in the farm to another node in the farm. In addition, if a service is restarted, the replay cache is flushed, allowing an attacker to replay the request. (The cache contains used, previously seen message signature values and prevents replays so those signatures can be used only once. Replay caches are not shared across a Web farm.)  
  
 Mitigations include:  
  
- Use message mode security with stateful security context tokens (with or without secure conversation enabled). For more information, see [How to: Create a Security Context Token for a Secure Session](how-to-create-a-security-context-token-for-a-secure-session.md).  
  
- Configure the service to use transport-level security.  
  
## See also

- [Security Considerations](security-considerations-in-wcf.md)
- [Information Disclosure](information-disclosure.md)
- [Elevation of Privilege](elevation-of-privilege.md)
- [Denial of Service](denial-of-service.md)
- [Tampering](tampering.md)
- [Unsupported Scenarios](unsupported-scenarios.md)
