---
title: "<peer> of <serviceCredentials>"
ms.date: "03/30/2017"
ms.assetid: b134e21d-e5b5-458e-9309-626dbf8db4ed
---
# \<peer> of \<serviceCredentials>
Specifies the current credentials for a peer node.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceCredentials>**](servicecredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<peer>**  
  
## Syntax  
  
```xml  
<peer>
  <certificate />
  <peerAuthentication />
  <messageSenderAuthentication />
</peer>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<certificate>](certificate-of-peer.md)|Specifies an X.509 certificate to use for signing and encrypting messages for peer-to-peer services. .|  
|[\<messageSenderAuthentication>](messagesenderauthentication.md)|Specifies authentication options for message senders.|  
|[\<peerAuthentication>](peerauthentication.md)|Specifies authentication options for peer services.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceCredentials>](servicecredentials.md)|Specifies the credential to be used in authenticating the service, and the client credential validation-related settings.|  
  
## See also

- <xref:System.ServiceModel.Configuration.PeerCredentialElement>
- <xref:System.ServiceModel.Configuration.ServiceCredentialsElement.Peer%2A>
- <xref:System.ServiceModel.Description.ServiceCredentials.Peer%2A>
- <xref:System.ServiceModel.Security.PeerCredential>
- [Peer-to-Peer Networking](../../../wcf/feature-details/peer-to-peer-networking.md)
- [Peer Channel Message Authentication](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/aa967730(v=vs.90))
- [Peer Channel Custom Authentication](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms751447(v=vs.90))
- [Securing Peer Channel Applications](../../../wcf/feature-details/securing-peer-channel-applications.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
