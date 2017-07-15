---
title: "&lt;peer&gt; of &lt;serviceCredentials&gt; | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b134e21d-e5b5-458e-9309-626dbf8db4ed
caps.latest.revision: 7
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# &lt;peer&gt; of &lt;serviceCredentials&gt;
Specifies the current credentials for a peer node.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
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
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<certificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/certificate-of-peer.md)|Specifies an X.509 certificate to use for signing and encrypting messages for peer-to-peer services. .|  
|[\<messageSenderAuthentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/messagesenderauthentication.md)|Specifies authentication options for message senders.|  
|[\<peerAuthentication>](../../../../../docs/framework/configure-apps/file-schema/wcf/peerauthentication.md)|Specifies authentication options for peer services.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecredentials.md)|Specifies the credential to be used in authenticating the service, and the client credential validation-related settings.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.PeerCredentialElement>   
 <xref:System.ServiceModel.Configuration.ServiceCredentialsElement.Peer%2A>   
 <xref:System.ServiceModel.Description.ServiceCredentials.Peer%2A>   
 <xref:System.ServiceModel.Security.PeerCredential>   
 [Peer-to-Peer Networking](../../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md)   
 [Peer Channel Message Authentication](https://msdn.microsoft.com/library/aa967730(v=vs.90).aspx)   
 [Peer Channel Custom Authentication](https://msdn.microsoft.com/library/ms751447(v=vs.90).aspx)   
 [Securing Peer Channel Applications](../../../../../docs/framework/wcf/feature-details/securing-peer-channel-applications.md)   
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
