---
description: "Learn more about: <claimTypeRequirements> for <message>"
title: "<claimTypeRequirements> for <message>"
ms.date: "03/30/2017"
ms.assetid: f95c5ecd-abb6-4b77-a6d7-a38727f4a142
---
# \<claimTypeRequirements> for \<message>

Specifies a collection of required claim types.  
  
 The collection is used by the service to specify any required and optional claims which must be in the issued token the client uses to access the service. The service exposes the required claim types in metadata if WSDL publishing is enabled but WCF does not require the issued token contain the specified claim types. Services wishing to enforce required claim types are present should do using authorization policy.  
  
 On federated clients, this collection contains the list of required and optional claims which is sent to the security token service in the client’s request for an issued token.  
  
## See also

- <xref:System.ServiceModel.FederatedMessageSecurityOverHttp.ClaimTypeRequirements%2A>
- <xref:System.ServiceModel.Security.Tokens.ClaimTypeRequirement>
- <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement.ClaimTypeRequirements%2A>
- <xref:System.ServiceModel.Configuration.ClaimTypeElementCollection>
- <xref:System.ServiceModel.Configuration.ClaimTypeElement>
