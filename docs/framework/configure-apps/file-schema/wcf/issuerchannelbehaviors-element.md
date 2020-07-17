---
title: "<issuerChannelBehaviors> Element"
ms.date: "03/30/2017"
ms.assetid: f7378673-8e9b-45b2-98d1-cf5dccdd8c40
no-loc: [<system.serviceModel>, <behaviors>, <endpointBehaviors>, <behavior>, <clientCredentials>, <issuedToken>, <issuerChannelBehaviors>, <dataContractSerializer>]
---

# \<issuerChannelBehaviors> Element

Contains a collection of Windows Communication Foundation (WCF) client endpoint behaviors (defined in the configuration) to be used when communicating with the specified Service Token Services. The defined behaviors cannot include any [\<clientCredentials>](clientcredentials.md) elements.

[\<configuration>](../configuration-element.md)\
&nbsp;&nbsp;[\<system.serviceModel>](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[\<behaviors>](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<endpointBehaviors>](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<behavior>](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<clientCredentials>](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[\<issuedToken>](issuedtoken.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\<issuerChannelBehaviors>

## Syntax

```xml
<issuerChannelBehaviors>
  <add behaviorConfiguration="string"
       issuerAddress="string" />
</issuerChannelBehaviors>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

None.

### Child elements

|Element|Description|
|-------------|-----------------|
|[\<add>](add-of-issuerchannelbehaviors.md)|Adds a behavior to the collection.|

### Parent elements

|Element|Description|
|-------------|-----------------|
|[\<issuedToken>](issuedtoken.md)|Specifies a custom token used to authenticate a client to a service.|

## Remarks

Use this element when any behaviors (other than behaviors that include `<clientCredentials>` elements) must be used to communicate with a service. For example, if a [\<dataContractSerializer>](datacontractserializer-element.md) behavior element must be included.

## See also

- <xref:System.ServiceModel.Configuration.IssuedTokenClientElement.IssuerChannelBehaviors%2A>
- <xref:System.ServiceModel.Configuration.IssuedTokenClientBehaviorsElement>
- <xref:System.ServiceModel.Configuration.IssuedTokenClientBehaviorsElementCollection>
- <xref:System.ServiceModel.Security.IssuedTokenClientCredential.IssuerChannelBehaviors%2A>
- [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md)
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Securing Clients](../../../wcf/securing-clients.md)
- [How to: Create a Federated Client](../../../wcf/feature-details/how-to-create-a-federated-client.md)
- [How to: Configure a Local Issuer](../../../wcf/feature-details/how-to-configure-a-local-issuer.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
