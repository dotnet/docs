---
title: "<sslStreamSecurity>"
ms.date: "03/30/2017"
ms.assetid: 430a378b-a742-4858-8a12-9f9b235fd627
---
# \<sslStreamSecurity>
Represents a custom binding element that supports channel security using an SSL stream.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<sslStreamSecurity>  
  
## Syntax  
  
```xml  
<sslStreamSecurity requireClientCertificate="Boolean"
                   sslProtocols="Ssl3|Tls|Tls11|Tls12" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|requireClientCertificate|A Boolean value that specifies if a client certificate is required for this binding. The default is `false`.|  
|sslProtocols|A SslProtocols enum flag value that specifies which SslProtocols are supported. The default is Ssl3&#124;Tls&#124;Tls11&#124;Tls12.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## See also

- <xref:System.ServiceModel.Configuration.SslStreamSecurityElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- <xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement>
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
