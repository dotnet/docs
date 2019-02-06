---
title: "<xmlElement>"
ms.date: "03/30/2017"
ms.assetid: 395205c2-d8c0-4a5e-90f3-7ce3c085fccd
---
# \<xmlElement>
Specifies an XML element that is sent in the message body to the Security Token Service when requesting a token.  
  
 \<system.ServiceModel>  
\<bindings>  
\<wsFederatedBinding>  
\<binding>  
\<security>  
\<message>  
\<tokenRequestParameters>  
  
## Syntax  
  
```xml  
<tokenRequestParameters>
  <xmlElement xmlElement="String" />
</tokenRequestParameters>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|xmlElement|A string specifying an XML element that is sent in the message body to the Security Token Service when requesting a token.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<tokenRequestParameters>](../../../../../docs/framework/configure-apps/file-schema/wcf/tokenrequestparameters.md)|A collection of token request parameters. Each parameter is an XML element.|  
  
## See also
- <xref:System.ServiceModel.FederatedMessageSecurityOverHttp.TokenRequestParameters%2A>
- <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement.TokenRequestParameters%2A>
- [Service Identity and Authentication](../../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)
- [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)
- [Security Capabilities with Custom Bindings](../../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md)
- [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)
- [Bindings](../../../../../docs/framework/wcf/bindings.md)
