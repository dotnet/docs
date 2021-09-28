---
description: "Learn more about: <localIssuer>"
title: "<localIssuer>"
ms.date: "03/30/2017"
ms.assetid: 26bdd0df-0e7d-4b9e-bbeb-f28c53769385
---
# \<localIssuer>

Specifies the address and binding of the local issuer to be used to obtain a security token.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<issuedToken>**](issuedtoken.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<localIssuer>**  
  
## Syntax  
  
```xml  
<localIssuer address="String"
             binding="String"
             bindingConfiguration="String" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|address|Required string. Specifies the URI of the local issuer.|  
|binding|Optional string. One of the system-provided bindings. For a list, see [System-Provided Bindings](../../../wcf/system-provided-bindings.md).|  
|bindingConfiguration|Optional string. Specifies a binding configuration found in the configuration file.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<identity>](identity.md)|Specifies identity information for the local issuer.|  
|[\<headers>](headers-element.md)|A collection of address headers that are required in order to correctly address the local issuer. You can use the `add` keyword to add a header to this collection.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuedToken>](issuedtoken.md)|Specifies a custom token used to authenticate a client to a service.|  
  
## Remarks  

 When obtaining an issued token from a Security Token Service (STS), the client application must be configured with the address and binding to use to communicate with the STS. When the <xref:System.ServiceModel.WSFederationHttpBinding> does not supply a URL for the security token service, or when the issuer address of a federated binding is `http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous` or `null`, the client's Windows Communication Foundation (WCF) channel uses the values specified by `address` and `binding` to communicate with the STS to obtain the issued token. For more information on configuring a local issuer, see [How to: Configure a Local Issuer](../../../wcf/feature-details/how-to-configure-a-local-issuer.md).  
  
## Example  

 The following example sets the `address`, `binding`, and `bindingConfiguration` attributes of a `localIssuer` element.  
  
```xml  
<system.serviceModel>
  <behaviors>
    <endpointBehaviors>
      <behavior name="MyEndpointBehavior">
        <clientCredentials>
          <issuedToken cacheIssuedTokens="false"
                       defaultKeyEntropyMode="ClientEntropy">
            <localIssuer address="net.tcp://cohowinery/tokens"
                         binding="netTcpBinding"
                         bindingConfiguration="myTcpBindingConfig" />
          </issuedToken>
        </clientCredentials>
      </behavior>
    </endpointBehaviors>
  </behaviors>
</system.serviceModel>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.IssuedTokenClientElement.LocalIssuer%2A>
- <xref:System.ServiceModel.Configuration.IssuedTokenParametersEndpointAddressElement>
- <xref:System.ServiceModel.Security.IssuedTokenClientCredential>
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [How to: Configure a Local Issuer](../../../wcf/feature-details/how-to-configure-a-local-issuer.md)
- [Service Identity and Authentication](../../../wcf/feature-details/service-identity-and-authentication.md)
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Securing Clients](../../../wcf/securing-clients.md)
- [How to: Create a Federated Client](../../../wcf/feature-details/how-to-create-a-federated-client.md)
- [Federation and Issued Tokens](../../../wcf/feature-details/federation-and-issued-tokens.md)
