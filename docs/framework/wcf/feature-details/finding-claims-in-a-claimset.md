---
description: "Learn more about: Finding Claims in a ClaimSet"
title: "Finding Claims in a ClaimSet"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "claims [WCF], finding in a claimset"
  - "claims [WCF]"
ms.assetid: a76ce107-aeb3-47d0-bfa9-134c53664e20
---
# Finding Claims in a ClaimSet

Examining the content of a <xref:System.IdentityModel.Claims.ClaimSet> for particular types of claims is a common task when using claim-based authorization. To examine a <xref:System.IdentityModel.Claims.ClaimSet> for the presence of particular claims, use the <xref:System.IdentityModel.Claims.ClaimSet.FindClaims%2A> method. This method provides better performance than iterating directly over the <xref:System.IdentityModel.Claims.ClaimSet>. The following example demonstrates this usage. Note that the `claimType` and `claimRight` parameters can be `null`. In that case, the parameters will match all claim types and claim rights.  
  
## Example  

 [!code-csharp[c_FindClaimsPerf#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_findclaimsperf/cs/c_findclaimsperf.cs#2)]
 [!code-vb[c_FindClaimsPerf#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_findclaimsperf/vb/c_findclaimsperf.vb#2)]  
  
## See also

- [Managing Claims and Authorization with the Identity Model](managing-claims-and-authorization-with-the-identity-model.md)
