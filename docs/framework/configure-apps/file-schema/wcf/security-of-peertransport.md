---
title: "<security> of <peerTransport>"
ms.date: "03/30/2017"
ms.assetid: f73634ed-f896-4968-bf74-5e5ac52d3b6b
---
# \<security> of \<peerTransport>
Contains the security settings associated with a peer channel, including the type of authentication used and the security used for the message transport.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<peerTransport>**](peertransport.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  
  
## Syntax  
  
```xml  
<security mode="None/Transport/Message/TransportWithMessageCredential">
  <transport clientCredentialType="None/Windows/UserName/Certificate/CardSpace" />
</security
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`mode`|Specifies the type of security to be applied. The default value is Message. This attribute is of type <xref:System.ServiceModel.SecurityMode>.|  
  
## mode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`None`|Security is disabled.|  
|`Transport`|Security is provided using HTTPS.|  
|`Message`|SOAP security provides authentication, integrity and confidentiality.|  
|`TransportWithMessageCredential`|HTTPS provides authentication and confidentiality. SOAP messages provide rich credential types.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<transport>](transport-of-peertransport.md)|Defines a peer transport for a custom binding. This element has a `clientCredentialType` attribute that specifies the credentials to be used when interacting with a service. This attribute is of type <xref:System.ServiceModel.PeerTransportCredentialType>.<br /><br /> This element is of type <xref:System.ServiceModel.Configuration.PeerTransportSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peerTransport>](peertransport.md)|Defines a peer transport for a custom binding.|  
  
## See also

- <xref:System.ServiceModel.Configuration.PeerSecurityElement>
- <xref:System.ServiceModel.PeerSecuritySettings>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Transport Security](../../../wcf/feature-details/transport-security.md)
- [Transports](../../../wcf/feature-details/transports.md)
- [Choosing a Transport](../../../wcf/feature-details/choosing-a-transport.md)
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
