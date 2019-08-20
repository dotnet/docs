---
title: "<issuerMetadata> of <issuedTokenParameters>"
ms.date: "03/30/2017"
ms.assetid: 1a85ca37-496d-4fa3-8d44-d6c9383d735c
---
# \<issuerMetadata> of \<issuedTokenParameters>
\<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
\<issuedTokenParameters>  
\<issuerMetadata>  
  
## Syntax  
  
```xml  
<issuerMetaData address="String" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|address|Required. A string that specifies the address of the endpoint. The address must be an absolute URI. The default value is an empty string.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<headers>](headers-element.md)|A collection of address headers.|  
|[\<identity>](identity.md)|An identity that enables the authentication of an endpoint by other endpoints exchanging messages with it.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuedTokenParameters>](issuedtokenparameters.md)|Specifies the parameters for an security token issued in a Federated security scenario.|  
  
## See also

- <xref:System.ServiceModel.Security.Tokens.IssuedSecurityTokenParameters>
- <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement>
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
