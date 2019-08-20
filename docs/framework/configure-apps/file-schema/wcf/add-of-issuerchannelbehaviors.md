---
title: "<add> of <issuerChannelBehaviors>"
ms.date: "03/30/2017"
ms.assetid: 50710506-e28f-45dd-ab7e-bff6f44173db
---

# \<add> of \<issuerChannelBehaviors>

Adds an endpoint behavior to be used when communicating with an STS.

> [!NOTE]
> If any endpoint behavior contains a [\<clientCredentials>](clientcredentials.md) element, an exception will be thrown.

\<system.ServiceModel>\
\<behaviors>\
endpointBehaviors section
\<behavior>\
\<clientCredentials>\
\<issuedToken>\
\<issuerChannelBehaviors> Element\
\<add>

## Syntax

```xml
<add issuerAddress="string"
     behaviorConfiguration="string" />
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
|[\<issuerChannelBehaviors>](issuerchannelbehaviors-element.md)|Contains a collection of Windows Communication Foundation (WCF) client endpoint behaviors to be used when communicating with the specified Service Token Services.|

## Remarks

`issuerAddress` contains the URI of the Security Token Service that the client wants to communicate with. `behaviorConfiguration` points to an endpoint behavior that the application uses in the channels created by Windows Communication Foundation (WCF) to get the issued tokens from the Security Token Services.

## See also

- <xref:System.ServiceModel.Configuration.IssuedTokenClientElement.IssuerChannelBehaviors%2A>
- <xref:System.ServiceModel.Configuration.IssuedTokenClientBehaviorsElement>
- <xref:System.ServiceModel.Configuration.IssuedTokenClientBehaviorsElementCollection>
- <xref:System.ServiceModel.Security.IssuedTokenClientCredential.IssuerChannelBehaviors%2A>
- [Service Identity and Authentication](../../feature-details/service-identity-and-authentication.md)
- [Security Behaviors](../../feature-details/security-behaviors-in-wcf.md)
- [Federation and Issued Tokens](../../feature-details/federation-and-issued-tokens.md)
- [Securing Services and Clients](../../feature-details/securing-services-and-clients.md)
- [Securing Clients](../../securing-clients.md)
- [How to: Create a Federated Client](../../feature-details/how-to-create-a-federated-client.md)
- [How to: Configure a Local Issuer](../../feature-details/how-to-configure-a-local-issuer.md)
- [Federation and Issued Tokens](../../feature-details/federation-and-issued-tokens.md)
- [\<issuerChannelBehaviors>](issuerchannelbehaviors-element.md)
