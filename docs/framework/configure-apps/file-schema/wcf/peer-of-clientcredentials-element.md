---
title: "&lt;peer&gt; of &lt;clientCredentials&gt; Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 505bd987-0042-4622-b68e-94f439729d53
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;peer&gt; of &lt;clientCredentials&gt; Element
Specifies credentials used when authenticating peer-to-peer clients.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<clientCredentials>  
\<peer>  
  
## Syntax  
  
```xml  
<peer>  
  <certificate/>  
  <peerAuthentication/>  
  <messageSenderAuthentication/>  
</peer>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<certificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/certificate-element.md)|Specifies an X.509 certificate to use for signing and encrypting messages for peer-to-peer clients. .|  
|[\<peerAuthentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/peerauthentication-element.md)|Specifies authentication options for peer clients.|  
|[\<messageSenderAuthentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/messagesenderauthentication-element.md)|Specifies authentication options for message senders.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md)|Specifies the credentials used to authenticate a client to a service.|  
  
## Remarks  
 This configuration element specifies the credentials that a peer node uses to authenticate itself to other nodes in the mesh, as well as authentication settings that a peer node uses to authenticate other peer nodes. For more information, see [Peer Channel Message Authentication](http://msdn.microsoft.com/library/80e73386-514e-4c30-9e4a-b9ca8c173a95) and [Securing Peer Channel Applications](../../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md).  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Configuration.PeerCredentialElement>  
 <xref:System.ServiceModel.Configuration.ClientCredentialsElement.Peer%2A>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Description.ClientCredentials.Peer%2A>  
 <xref:System.ServiceModel.Security.PeerCredential>  
 [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)  
 [Peer Channel Message Authentication](http://msdn.microsoft.com/library/80e73386-514e-4c30-9e4a-b9ca8c173a95)  
 [Peer Channel Custom Authentication](http://msdn.microsoft.com/library/4aa8a82e-41a8-48e2-8621-7e1cbabdca7c)  
 [Securing Peer Channel Applications](../../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
