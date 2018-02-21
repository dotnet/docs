---
title: "Replacing a Principal Object"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "principal objects, replacing"
  - "security [.NET Framework], replacing principal objects"
  - "security [.NET Framework], principals"
ms.assetid: c323687e-b196-487b-beba-f38f9b3f961b
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Replacing a Principal Object
Applications that provide authentication services must be able to replace the **Principal** object (<xref:System.Security.Principal.IPrincipal>) for a given thread. Furthermore, the security system must help protect the ability to replace **Principal** objects because a maliciously attached, incorrect **Principal** compromises the security of your application by claiming an untrue identity or role. Therefore, applications that require the ability to replace **Principal** objects must be granted the <xref:System.Security.Permissions.SecurityPermission?displayProperty=nameWithType> object for principal control. (Note that this permission is not required for performing role-based security checks or for creating **Principal** objects.)  
  
 The current **Principal** object can be replaced by performing the following tasks:  
  
1.  Create the replacement **Principal** object and associated **Identity** object.  
  
2.  Attach the new **Principal** object to the call context.  
  
## Example  
 The following example shows how to create a generic principal object and use it to set the principal of a thread.  
  
 [!code-csharp[SetCurrentPrincipal#1](../../../samples/snippets/csharp/VS_Snippets_CLR/SetCurrentPrincipal/CS/program.cs#1)]
 [!code-vb[SetCurrentPrincipal#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/SetCurrentPrincipal/VB/program.vb#1)]  
  
## See Also  
 <xref:System.Security.Permissions.SecurityPermission?displayProperty=nameWithType>  
 [Principal and Identity Objects](../../../docs/standard/security/principal-and-identity-objects.md)
