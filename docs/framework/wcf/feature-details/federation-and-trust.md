---
description: "Learn more about: Federation and Trust"
title: "Federation and Trust"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "federation [WCF], and trust"
ms.assetid: 4bdec4f2-f8a2-4512-bdcf-14ef54b5877a
---
# Federation and Trust

This topic covers various aspects related to federated applications, trust boundaries and configuration, and use of issued tokens in Windows Communication Foundation (WCF).  
  
## Services, Security Token Services, and Trust  

 Services that expose federated endpoints typically expect clients to authenticate using a token provided by a specific issuer. It is important that the service is configured with the correct credentials for the issuer; otherwise, it will not be able to verify signatures over the issued tokens, and the client will be unable to communicate with the service. For more information about configuring issuer credentials on the service, see [How to: Configure Credentials on a Federation Service](how-to-configure-credentials-on-a-federation-service.md).  
  
 Similarly, when using symmetric keys, the keys are encrypted for the target service, so you must configure the security token service with the correct credentials for the target service; otherwise, it will be unable to encrypt the key for the target service, and again, the client will be unable to communicate with the service.  
  
 WCF services use the value of the <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings.MaxClockSkew%2A> property on the [SecurityBindingElement](../diagnostics/wmi/securitybindingelement.md) to allow for clock skew between the client and service. In federation, the `MaxClockSkew` setting applies to clock skews between both the client and the security token service from where the client obtained the issued token. Therefore, security token services need not make clock-skew allowances when setting the issued token's effective and expiration times.  
  
> [!NOTE]
> The importance of clock skew increases as the lifetime of the issued token shortens. In most cases, clock skew is not a significant issue if the token lifetime is 30 minutes or more. Scenarios with shorter lifetimes or where the exact validity time of the token is important should be designed to take clock skew into account.  
  
## Federated Endpoints and Time-Outs  

 When a client communicates with a federated endpoint, it must first acquire an appropriate token from a security token service. If the security token service exposes a federated endpoint, the client must first obtain a token from the issuer for that endpoint. Each token acquisition takes time, and that time is subject to the overall time-out for sending the actual message to the final endpoint.  
  
 For example, the time-out on the client-side channel is set to 30 seconds. Two token issuers need to be called to retrieve tokens before sending the message to the final endpoint, and each takes 15 seconds to issue a token. In this case, the attempt will fail and a <xref:System.TimeoutException> is thrown. Thus, you need to set the <xref:System.ServiceModel.IContextChannel.OperationTimeout%2A> value on the client channel to a value large enough to include the time taken to retrieve all issued tokens. In the case where a value is not specified for the <xref:System.ServiceModel.IContextChannel.OperationTimeout%2A> property, the <xref:System.ServiceModel.Channels.Binding.OpenTimeout%2A> property or the <xref:System.ServiceModel.Channels.Binding.SendTimeout%2A> property (or both) need to be set to a value large enough to include the time taken to retrieve all issued tokens.  
  
## Token Lifetime and Renewal  

 WCF clients do not check the issued token when making an initial request to a service.  Rather, WCF trusts the security token service to issue a token with appropriate effective and expiration times. If the token is cached by the client and reused, the token lifetime is checked on subsequent requests and the client automatically renews the token if necessary. For more information about token caching, see [How to: Create a Federated Client](how-to-create-a-federated-client.md).  
  
 Specifying short lifetimes, on the order of 30 seconds or less for issued tokens or security context tokens, may result in negotiation time-outs or other exceptions being thrown by WCF clients when requesting issued tokens or when negotiating or renewing security context tokens.  
  
## Issued Tokens and InclusionMode  

 Whether an issued token is serialized in a message sent from a client to a federated endpoint or not is controlled by setting the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters.InclusionMode%2A> property of the <xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters> class. This property can be set to one of the <xref:System.ServiceModel.Security.Tokens.SecurityTokenInclusionMode> enumeration values, but it is not useful in most federated scenarios. The `SecurityTokenInclusionMode.Never` and `SecurityTokenInclusionMode.AlwaysToInitiator` values cause the client to send a reference to the token issued by the security token service to the relying party. Unless the relying party possesses a copy of the issued token, authentication will fail because the token reference is not resolvable. WCF treats `SecurityTokenInclusionMode.Once` as equivalent to `SecurityTokenInclusionMode.AlwaysToRecipient`.  
  
## See also

- <xref:System.ServiceModel.Security.Tokens.SecurityTokenInclusionMode>
- [How to: Create a Federated Client](how-to-create-a-federated-client.md)
- [How to: Configure Credentials on a Federation Service](how-to-configure-credentials-on-a-federation-service.md)
- [How to: Create a WSFederationHttpBinding](how-to-create-a-wsfederationhttpbinding.md)
