---
description: "Learn more about: Secure Sessions"
title: "Secure Sessions"
ms.date: "03/30/2017"
ms.assetid: 7b50602f-d7b5-42e9-8e92-1f0413df0d8b
---
# Secure Sessions

A feature of Windows Communication Foundation (WCF) is reliable sessions that guarantee messages are received in the order they were sent. The articles in this section discuss the security implications to consider when creating a reliable session. For more information about reliable sessions, see [Using Sessions](../using-sessions.md).  
  
> [!NOTE]
> When impersonation is required on Windows XP, use a secure session without a stateful security context token (SCT). When stateful SCTs are used with impersonation, an <xref:System.InvalidOperationException> is thrown. For more information, see [Unsupported Scenarios](unsupported-scenarios.md).  
  
## In This Section  
  
| Article | Description |  
|-|-|  
|[Secure Conversations and Secure Sessions](secure-conversations-and-secure-sessions.md)|Secure conversations and secure sessions are synonymous. This article explains the way a secure conversation works, and when and why to use the pattern.|  
|[How to: Create a Secure Session](how-to-create-a-secure-session.md)|Walks through of the basics of creating a secure session.|  
|[How to: Create a Security Context Token for a Secure Session](how-to-create-a-security-context-token-for-a-secure-session.md)|Walks through the steps of creating a Web farm that will maintain state and sessions with clients.|  
|[Security Considerations for Secure Sessions](security-considerations-for-secure-sessions.md)|Describes special considerations for secure sessions.|  
  
## Reference  

 <xref:System.ServiceModel>  
  
 <xref:System.ServiceModel.Channels>  
  
## Related Sections  

 [Sessions, Instancing, and Concurrency](sessions-instancing-and-concurrency.md)  
  
 [Designing and Implementing Services](../designing-and-implementing-services.md)  
  
## See also

- [How to: Enable Message Replay Detection](how-to-enable-message-replay-detection.md)
- [Replay Attacks](replay-attacks.md)
- [How to: Create a Service That Requires Sessions](how-to-create-a-service-that-requires-sessions.md)
