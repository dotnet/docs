---
title: "<transport> of <peerTransport>"
ms.date: "03/30/2017"
ms.assetid: d7116240-845c-4b6f-b203-262de6b597ef
---
# \<transport> of \<peerTransport>
Specifies the transport type for secured messages sent by peers configured with this binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<peerTransport>  
\<security>  
\<transport>  
  
## Syntax  
  
```xml  
<security>
  <transport credentialType="Certificate/Password" />
</security>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|credentialType|Optional. Specifies the type of credentials used to verify messages sent with the peer transport. This attribute is of type <xref:System.ServiceModel.PeerTransportCredentialType>.|  
  
## credentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Certificate|Authentication of the peer channel transport requires an X509 certificate.|  
|Password|Authentication of the peer channel transport requires a correct password.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-peertransport.md)|Defines the security settings for a peer transport.|  
  
## Remarks  
 This element is set only if the mode attribute of [\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-peertransport.md) is set to `Transport` or `TransportWithMessageCredential`.  
  
## See also

- <xref:System.ServiceModel.Configuration.PeerTransportSecurityElement>
- <xref:System.ServiceModel.PeerSecuritySettings.Transport%2A>
- <xref:System.ServiceModel.PeerTransportSecuritySettings>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transport Security](../../../../../docs/framework/wcf/feature-details/transport-security.md)
- [Transports](../../../../../docs/framework/wcf/feature-details/transports.md)
- [Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)
- [Bindings](../../../../../docs/framework/wcf/bindings.md)
- [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)
- [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
