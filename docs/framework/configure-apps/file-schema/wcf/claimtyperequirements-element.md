---
description: "Learn more about: <claimTypeRequirements> element"
title: "<claimTypeRequirements> element"
ms.date: "03/30/2017"
ms.assetid: a26efe73-4bad-4731-8cad-27f00d54354b
---
# \<claimTypeRequirements> element

Specifies a collection of required claim types.  
  
 In a federated scenario, services state the requirements on incoming credentials. For example, the incoming credentials must possess a certain set of claim types. Each child element in this collection specifies the types of required and optional claims expected to appear in a federated credential.  
  
 A claim type requirement consists of the URI of the claim type requested in the issued token along with a Boolean parameter that indicates whether that claim type is required in the issued token, or is optional.  
  
## See also

- <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters.ClaimTypeRequirements%2A>
- <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement.ClaimTypeRequirements%2A>
- <xref:System.ServiceModel.Configuration.ClaimTypeElementCollection>
- <xref:System.ServiceModel.Configuration.ClaimTypeElement>
- <xref:System.ServiceModel.Configuration.SecurityElementBase.IssuedTokenParameters%2A>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
- [Security Capabilities with Custom Bindings](../../../wcf/feature-details/security-capabilities-with-custom-bindings.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
- [\<add>](add-of-claimtyperequirements.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
- [How to: Create a Custom Binding Using the SecurityBindingElement](../../../wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)
- [Custom Binding Security](../../../wcf/samples/custom-binding-security.md)
