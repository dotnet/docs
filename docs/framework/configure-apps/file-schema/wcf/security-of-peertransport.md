---
title: "&lt;security&gt; of &lt;peerTransport&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f73634ed-f896-4968-bf74-5e5ac52d3b6b
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;security&gt; of &lt;peerTransport&gt;
Contains the security settings associated with a peer channel, including the type of authentication used and the security used for the message transport.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<peerTransport>  
\<security>  
  
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
|[\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-peertransport.md)|Defines a peer transport for a custom binding. This element has a `clientCredentialType` attribute that specifies the credentials to be used when interacting with a service. This attribute is of type <xref:System.ServiceModel.PeerTransportCredentialType>.<br /><br /> This element is of type <xref:System.ServiceModel.Configuration.PeerTransportSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<peerTransport>](../../../../../docs/framework/configure-apps/file-schema/wcf/peertransport.md)|Defines a peer transport for a custom binding.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.PeerSecurityElement>  
 <xref:System.ServiceModel.PeerSecuritySettings>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Transport Security](../../../../../docs/framework/wcf/feature-details/transport-security.md)  
 [Transports](../../../../../docs/framework/wcf/feature-details/transports.md)  
 [Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
