---
title: "&lt;add&gt; of &lt;issuerChannelBehaviors&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 50710506-e28f-45dd-ab7e-bff6f44173db
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;issuerChannelBehaviors&gt;
Adds an endpoint behavior to be used when communicating with an STS.  
  
> [!NOTE]
>  If any endpoint behavior contains a [\<clientCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md) element, an exception will be thrown.  
  
 \<system.ServiceModel>  
\<behaviors>  
endpointBehaviors section  
\<behavior>  
\<clientCredentials>  
\<issuedToken>  
\<issuerChannelBehaviors> Element  
\<add>  
  
## Syntax  
  
```xml  
<add issuerAddress="string"  
     behaviorConfiguraton="string" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|issuerAddress|The URI of the security token issuer to communicate with.|  
|behaviorConfiguration|The name of an endpoint behavior defined in the same configuration file.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuerChannelBehaviors>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuerchannelbehaviors-element.md)|Contains a collection of [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] client endpoint behaviors to be used when communicating with the specified Service Token Services.|  
  
## Remarks  
 `issuerAddress` contains the URI of the Security Token Service that the client wants to communicate with. `behaviorConfiguration` points to an endpoint behavior that the application uses in the channels created by [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] to get the issued tokens from the Security Token Services.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.IssuedTokenClientElement.IssuerChannelBehaviors%2A>  
 <xref:System.ServiceModel.Configuration.IssuedTokenClientBehaviorsElement>  
 <xref:System.ServiceModel.Configuration.IssuedTokenClientBehaviorsElementCollection>  
 <xref:System.ServiceModel.Security.IssuedTokenClientCredential.IssuerChannelBehaviors%2A>  
 [Service Identity and Authentication](../../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md)  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Securing Clients](../../../../../docs/framework/wcf/securing-clients.md)  
 [How to: Create a Federated Client](../../../../../docs/framework/wcf/feature-details/how-to-create-a-federated-client.md)  
 [How to: Configure a Local Issuer](../../../../../docs/framework/wcf/feature-details/how-to-configure-a-local-issuer.md)  
 [Federation and Issued Tokens](../../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md)  
 [\<issuerChannelBehaviors>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuerchannelbehaviors-element.md)
