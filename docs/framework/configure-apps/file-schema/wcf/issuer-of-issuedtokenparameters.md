---
title: "<issuer> of <issuedTokenParameters>"
ms.date: "03/30/2017"
ms.assetid: d6a95f32-d58c-40fc-8658-dd92564d3c90
---
# \<issuer> of \<issuedTokenParameters>
Specifies the Security Token Service (STS) that issues security tokens.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
\<issuedTokenParameters>  
\<issuer>  
  
## Syntax  
  
```xml  
<issuer address="Uri" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|address|Required string. The URL of the STS.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<headers>](headers-element.md)|A collection of address headers for the endpoints that the builder can create.|  
|[\<identity>](identity.md)|When using an issued token, specifies settings that enable the client to authenticate the server.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuedTokenParameters>](issuedtokenparameters.md)|Specifies the current issued token.|  
  
## See also

- <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters.AdditionalRequestParameters%2A>
- <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement.AdditionalRequestParameters%2A>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Service Identity and Authentication](../../feature-details/service-identity-and-authentication.md)
- [Federation and Issued Tokens](../../feature-details/federation-and-issued-tokens.md)
- [Security Capabilities with Custom Bindings](../../feature-details/security-capabilities-with-custom-bindings.md)
- [Federation and Issued Tokens](../../feature-details/federation-and-issued-tokens.md)
- [Bindings](../../bindings.md)
- [Extending Bindings](../../extending/extending-bindings.md)
- [Custom Bindings](../../extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
- [How to: Create a Custom Binding Using the SecurityBindingElement](../../feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)
- [Custom Binding Security](../../samples/custom-binding-security.md)
