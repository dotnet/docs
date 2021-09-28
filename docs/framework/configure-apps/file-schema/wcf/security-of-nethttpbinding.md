---
description: "Learn more about: <security> of <netHttpBinding>"
title: "<security> of <netHttpBinding>"
ms.date: "03/30/2017"
ms.assetid: dc41f6f7-cabc-4a64-9fa0-ceabf861b348
---
# \<security> of \<netHttpBinding>

Defines the security capabilities of the [\<netHttpBinding>](nethttpbinding.md).

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netHttpBinding>**](nethttpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<security>**  

## Syntax

```xml
<security mode="Message/None/Transport/TransportWithCredential">
  <transport clientCredentialType="Basic/Certificate/Digest/None/Ntlm/Windows"
             proxyCredentialType="Basic/Digest/None/Ntlm/Windows"
             realm="string" />
  <message algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"
           clientCredentialType="Certificate/IssuedToken/None/UserName/Windows" />
</security>
```

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|mode|Optional. Specifies the type of security that is used. The default is `None`. This attribute is of type <xref:System.ServiceModel.BasicHttpSecurityMode>.|

## mode attribute

|Value|Description|
|-----------|-----------------|
|None|-   Messages are not secured during transfer.|
|Transport|Security is provided using HTTPS transport. The SOAP messages are secured using HTTPS. The service is authenticated to the client using the service's X.509 certificate. The client is authenticated using the ClientCredentialType supplied.|
|Message|Security is provided using SOAP message security. By default, the body is encrypted and signed. For this binding, the system requires that the server certificate be provided to the client out of band. The only valid `ClientCredentialType` for this binding is `Certificate`.|
|TransportWithMessageCredential|Integrity, confidentiality and server authentication are provided by transport security. Client authentication is provided by means of SOAP message security. This mode is relevant when the user is authenticating using username/password and there is an existing HTTP deployment for securing message transfer.|
|TransportCredentialOnly|This mode does not provide message integrity and confidentiality. It provides http-based client authentication. This mode should be used with caution. It should be used in environments where the transport security is being provided by other means (such as IPSec) and only client authentication is provided by the WCF infrastructure.|

### Child elements

|Element|Description|
|-------------|-----------------|
|[\<transport>](transport-of-nethttpbinding.md)|Defines the transport security settings for a basic HTTP service. This element corresponds to <xref:System.ServiceModel.HttpTransportSecurity>.|
|[\<message>](message-of-nethttpbinding.md)|Defines the message security settings for a basic HTTP service. This element corresponds to <xref:System.ServiceModel.BasicHttpMessageSecurity>.|

### Parent elements

|Element|Description|
|-------------|-----------------|
|binding|The binding element of the [\<basicHttpBinding>](basichttpbinding.md).|

## Remarks

 By default, the SOAP message is not secured and the client is not authenticated. This element enables you to configure additional security settings for the `netHttpBinding` element.

## See also

- <xref:System.ServiceModel.NetHttpBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.NetHttpBindingElement.Security%2A>  
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Selecting a Credential Type](../../../wcf/feature-details/selecting-a-credential-type.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
