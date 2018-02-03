---
title: "WSTrustChannelFactory and WSTrustChannel"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 96cec467-e963-4132-b18b-7d0b3a2e979f
caps.latest.revision: 9
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# WSTrustChannelFactory and WSTrustChannel
If you are already familiar with Windows Communication Foundation (WCF), you know that a WCF client is already federation aware. By configuring a WCF client with a <xref:System.ServiceModel.WSFederationHttpBinding> or similar custom binding, you can enable federated authentication to a service.  
  
 WCF obtains the token that is issued by the security token service (STS) behind the scenes and uses this token to authenticate to the service. The main limitation to this approach is that there is no visibility into the client’s communications with the server. WCF automatically generates the request security token (RST) to the STS based on the issued token parameters on the binding. This means that the client cannot vary the RST parameters per request, inspect the request security token response (RSTR) to get information such as display claims, or cache the token for future use.  
  
 Currently, the WCF client is suitable for basic federation scenarios. However, one of the major scenarios that Windows Identity Foundation (WIF) supports requires control over the RST at a level that WCF does not easily allow. Therefore, WIF adds features that give you more control over communication with the STS.  
  
 WIF supports the following federation scenarios:  
  
-   Using a WCF client without any WIF dependencies to authenticate to a federated service  
  
-   Enabling WIF on a WCF client to insert an ActAs or OnBehalfOf element into the RST to the STS  
  
-   Using WIF alone to obtain a token from the STS and then enable a WCF client to authenticate with this token. For more information, see [ClaimsAwareWebService](http://go.microsoft.com/fwlink/?LinkID=248406) sample.  
  
 The first scenario is self-explanatory: Existing WCF clients will continue to work with WIF relying parties and STSs. This topic discusses the remaining two scenarios.  
  
## Enhancing an Existing WCF Client with ActAs / OnBehalfOf  
 In a typical identity delegation scenario, a client calls a middle-tier service, which then calls a back-end service. The middle-tier service acts as, or acts on behalf of, the client.  
  
> [!TIP]
>  What is the difference between ActAs and OnBehalfOf?  
>   
>  From the WS-Trust procotol standpoint:  
>   
>  1.  An ActAs RST element indicates that the requestor wants a token that contains claims about two distinct entities: the requestor, and an external entity represented by the token in the ActAs element.  
> 2.  An OnBehalfOf RST element indicates that the requestor wants a token that contains claims only about one entity: the external entity represented by the token in the OnBehalfOf element.  
>   
>  The ActAs feature is typically used in scenarios that require composite delegation, where the final recipient of the issued token can inspect the entire delegation chain and see not just the client, but all intermediaries. This lets it perform access control, auditing and other related activities based on the entire identity delegation chain. The ActAs feature is commonly used in multi-tiered systems to authenticate and pass information about identities between the tiers without having to pass this information at the application/business logic layer.  
>   
>  The OnBehalfOf feature is used in scenarios where only the identity of the original client is important and is effectively the same as the identity impersonation feature available in Windows. When OnBehalfOf is used, the final recipient of the issued token can only see claims about the original client, and the information about intermediaries is not preserved. One common pattern where the OnBehalfOf feature is used is the proxy pattern where the client cannot access the STS directly but instead communicates through a proxy gateway. The proxy gateway authenticates the caller and puts information about the caller into the OnBehalfOf element of the RST message that it then sends to the real STS for processing. The resulting token contains only claims related to the client of the proxy, making the proxy completely transparent to the receiver of the issued token.Note that WIF does not support \<wsse:SecurityTokenReference> or \<wsa:EndpointReferences> as a child of \<wst:OnBehalfOf>. The WS-Trust specification allows for three ways to identify the original requestor (on behalf of whom the proxy is acting). These are:  
>   
>  -   Security token reference. A reference to a token, either in the message, or possibly retrieved out of band).  
> -   Endpoint reference. Used as a key to look up data, again out of band.  
> -   Security token. Identifies the original requestor directly.  
>   
>  WIF supports only security tokens, either encrypted or unencrypted, as a direct child element of \<wst:OnBehalfOf>.  
  
 This information is conveyed to a WS-Trust issuer using the ActAs and OnBehalfOf token elements in the RST.  
  
 WCF exposes an extensibility point on the binding that allows arbitrary XML elements to be added to the RST. However, because the extensibility point is tied to the binding, scenarios that require the RST contents to vary per call must re-create the client for every call, which decreases performance. WIF uses extension methods on the `ChannelFactory` class to allow developers to attach any token that is obtained out of band to the RST. The following code example shows how to take a token that represents the client (such as an X.509, username, or Security Assertion Markup Language (SAML) token) and attach it to the RST that is sent to the issuer.  
  
```  
IHelloService serviceChannel = channelFactory.CreateChannelActingAs<IHelloService>( clientSamlToken );  
serviceChannel.Hello("Hi!");  
```  
  
 WIF provides the following benefits:  
  
-   The RST can be modified per channel; therefore, middle-tier services do not have to re-create the channel factory for each client, which improves performance.  
  
-   This works with existing WCF clients, which makes an easy upgrade path possible for existing WCF middle-tier services that want to enable identity delegation semantics.  
  
 However, there is still no visibility into the client’s communication with the STS. We’ll examine this in the third scenario.  
  
## Communicating Directly with an Issuer and Using the Issued Token to Authenticate  
 For some advanced scenarios, enhancing a WCF client is not enough. Developers who use only WCF typically use Message In / Message Out contracts and handle client-side parsing of the issuer response manually.  
  
 WIF introduces the <xref:System.ServiceModel.Security.WSTrustChannelFactory> and <xref:System.ServiceModel.Security.WSTrustChannel> classes to let the client communicate directly with a WS-Trust issuer. The <xref:System.ServiceModel.Security.WSTrustChannelFactory> and <xref:System.ServiceModel.Security.WSTrustChannel> classes enable strongly typed RST and RSTR objects to flow between the client and issuer, as shown in the following code example.  
  
```  
WSTrustChannelFactory trustChannelFactory = new WSTrustChannelFactory( stsBinding, stsAddress );  
WSTrustChannel channel = (WSTrustChannel) trustChannelFactory.CreateChannel();  
RequestSecurityToken rst = new RequestSecurityToken(RequestTypes.Issue);  
rst.AppliesTo = new EndpointAddress(serviceAddress);  
RequestSecurityTokenResponse rstr = null;  
SecurityToken token = channel.Issue(rst, out rstr);  
```  
  
 Note that the `out` parameter on the <xref:System.ServiceModel.Security.WSTrustChannel.Issue%2A> method allows access to the RSTR for client-side inspection.  
  
 So far, we’ve only seen how to obtain a token. The token that is returned from the <xref:System.ServiceModel.Security.WSTrustChannel> object is a `GenericXmlSecurityToken` that contains all of the information that is necessary for authentication to a relying party. The following code example shows how to use this token.  
  
```  
IHelloService serviceChannel = channelFactory.CreateChannelWithIssuedToken<IHelloService>( token ); serviceChannel.Hello("Hi!");  
```  
  
 The <xref:System.ServiceModel.ChannelFactory%601.CreateChannelWithIssuedToken%2A> extension method on the `ChannelFactory` object indicates to WIF that you have obtained a token out of band, and that it should stop the normal WCF call to the issuer and instead use the token that you obtained to authenticate to the relying party. This has the following benefits:  
  
-   It gives you complete control over the token issuance process.  
  
-   It supports ActAs / OnBehalfOf scenarios by directly setting these properties on the outgoing RST.  
  
-   It enables dynamic client-side trust decisions to be made based on the contents of the RSTR.  
  
-   It lets you cache and reuse the token that is returned from the <xref:System.ServiceModel.Security.WSTrustChannel.Issue%2A> method.  
  
-   <xref:System.ServiceModel.Security.WSTrustChannelFactory> and <xref:System.ServiceModel.Security.WSTrustChannel> allow for control of channel caching, fault, and recovery semantics according to WCF best practices.  
  
## See Also  
 [WIF Features](../../../docs/framework/security/wif-features.md)
