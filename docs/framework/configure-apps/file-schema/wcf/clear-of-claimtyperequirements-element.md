---
title: "<clear> of <claimTypeRequirements> element"
ms.date: "03/30/2017"
ms.assetid: ef42fde7-f292-4610-9111-9fea382c3b5f
---
# \<clear> of \<claimTypeRequirements> element
Specifies that all the claim types to be removed in the federated credential. This ensures that the collection starts empty.  
  
 \<system.ServiceModel>  
\<bindings>  
\<wsFederatedBinding>  
\<binding>  
\<security>  
\<message>  
\<claimTypeRequirements>  
  
## Syntax  
  
```xml  
<claimTypeRequirements>
  <clear />
</claimTypeRequirements>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<claimTypeRequirements>](claimtyperequirements-for-message.md)|Specifies a collection of required claim types. Each element is of type <xref:System.ServiceModel.Configuration.ClaimTypeElement>.<br /><br /> In a federated scenario, services state the requirements on incoming credentials. For example, the incoming credentials must possess a certain set of claim types. Each element in this collection specifies the types of required and optional claims expected to appear in a federated credential.|  
  
## See also

- <xref:System.ServiceModel.FederatedMessageSecurityOverHttp.ClaimTypeRequirements%2A>
- <xref:System.ServiceModel.Security.Tokens.ClaimTypeRequirement>
- <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement.ClaimTypeRequirements%2A>
- <xref:System.ServiceModel.Configuration.ClaimTypeElementCollection>
- <xref:System.ServiceModel.Configuration.ClaimTypeElement>
