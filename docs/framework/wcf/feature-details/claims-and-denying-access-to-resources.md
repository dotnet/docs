---
title: "Claims and Denying Access to Resources"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "claims [WCF], denying access to resources"
ms.assetid: 145ebb41-680e-4256-b14c-1efb4af1e982
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Claims and Denying Access to Resources
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] supports a claims-based authorization mechanism. As well as allowing access to resources based on the presence of claims, systems often deny access to resources based on the presence of claims. Such systems should examine the <xref:System.IdentityModel.Policy.AuthorizationContext> for claims that result in access being denied before looking for claims that result in access being allowed.  
  
 For example, a system might deny access to a resource to anyone who has a claim with a type of `Age`, a right of <xref:System.IdentityModel.Claims.Rights.PossessProperty%2A>, and a resource value of `Under 21` only when that identity also has a claim of type `Name`, a right of <xref:System.IdentityModel.Claims.Rights.Identity%2A>, and a resource value of `Mallory`. Put another way, the system denies access to anyone who is under 21 years old and grants access when the name is Mallory. To correctly implement this semantic, it is important to look for the `Age` claim first and determine whether the age is under 21 years old. Otherwise, if Mallory is under 21, then the resource may be granted access solely on the basis of the `Name` claim.  
  
## See Also  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)  
 [Claims and Tokens](../../../../docs/framework/wcf/feature-details/claims-and-tokens.md)
