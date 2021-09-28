---
description: "Learn more about: <issuedToken>"
title: "<issuedToken>"
ms.date: "03/30/2017"
ms.assetid: b6eae4b7-a6cd-4e1a-b0f6-f407022550b0
---
# \<issuedToken>

Specifies a custom token used to authenticate a client to a service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<issuedToken>**  
  
## Syntax  
  
```xml  
<issuedToken cacheIssuedTokens="Boolean"
             defaultKeyEntropyMode="ClientEntropy/ServerEntropy/CombinedEntropy"
             issuedTokenRenewalThresholdPercentage = "0 to 100"
             issuerChannelBehaviors="String"
             localIssuerChannelBehaviors="String"
             maxIssuedTokenCachingTime="TimeSpan">
</issuedToken>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`cacheIssuedTokens`|Optional Boolean attribute that specifies whether tokens are cached. The default is `true`.|  
|`defaultKeyEntropyMode`|Optional string attribute that specifies which random values (entropies) are used for handshake operations. Values include `ClientEntropy`, `ServerEntropy`, and `CombinedEntropy`, The default is `CombinedEntropy`. This attribute is of type <xref:System.ServiceModel.Security.SecurityKeyEntropyMode>.|  
|`issuedTokenRenewalThresholdPercentage`|Optional integer attribute that specifies the percentage of a valid time frame (supplied by the token issuer) that can pass before a token is renewed. Values are from 0 to 100. The default is 60, which specifies 60% of the time passes before a renewal is attempted.|  
|`issuerChannelBehaviors`|Optional attribute that specifies the channel behaviors to use when communicating with the issuer.|  
|`localIssuerChannelBehaviors`|Optional attribute that specifies the channel behaviors to use when communicating with the local issuer.|  
|`maxIssuedTokenCachingTime`|Optional Timespan attribute that specifies the duration that issued tokens are cached when the token issuer (an STS) does not specify a time. The default is "10675199.02:48:05.4775807."|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<localIssuer>](localissuer.md)|Specifies the address of the local issuer of the token and the binding used to communicate with the endpoint.|  
|[\<issuerChannelBehaviors>](issuerchannelbehaviors-element.md)|Specifies the endpoint behaviors to use when contacting a local issuer.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](clientcredentials.md)|Specifies the credentials used to authenticate a client to a service.|  
  
## Remarks  

 An issued token is a custom credential type used, for example, when authenticating with a Secure Token Service (STS) in a federated scenario. By default, the token is a SAML token. For more information, see [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md), and [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md).  
  
 This section contains the elements used to configure a local issuer of tokens, or behaviors used with an security token service. For instructions on configuring a client to use a local issuer, see [How to: Configure a Local Issuer](../../../wcf/feature-details/how-to-configure-a-local-issuer.md).  
  
## See also

- <xref:System.ServiceModel.Configuration.IssuedTokenClientElement>
- <xref:System.ServiceModel.Configuration.ClientCredentialsElement>
- <xref:System.ServiceModel.Description.ClientCredentials>
- <xref:System.ServiceModel.Configuration.ClientCredentialsElement.IssuedToken%2A>
- <xref:System.ServiceModel.Description.ClientCredentials.IssuedToken%2A>
- <xref:System.ServiceModel.Security.IssuedTokenClientCredential>
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
- [Securing Clients](../../../wcf/securing-clients.md)
- [How to: Create a Federated Client](../../../wcf/feature-details/how-to-create-a-federated-client.md)
- [How to: Configure a Local Issuer](../../../wcf/feature-details/how-to-configure-a-local-issuer.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
