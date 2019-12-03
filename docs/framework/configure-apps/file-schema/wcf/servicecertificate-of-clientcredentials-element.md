---
title: "<serviceCertificate> of <clientCredentials> Element"
ms.date: "03/30/2017"
ms.assetid: e50c0ac5-f0df-4c90-b54b-fc602c1f84ea
---
# \<serviceCertificate> of \<clientCredentials> Element
Specifies a certificate to use when authenticating a service to the client.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<clientCredentials>**](clientcredentials.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<serviceCertificate>**  
  
## Syntax  
  
```xml  
<serviceCertificate />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<defaultCertificate>](defaultcertificate-element.md)|Specifies an X.509 certificate to be used when a service or STS does not provide one via a negotiation protocol.|  
|[\<scopedCertificates>](scopedcertificates-element.md)|Represents a collection of X.509 certificates provided by specific services (scoped) for authentication. This collection is typically used to specify the service certificates for Security Token Services in a federated scenario.|  
|[\<authentication>](authentication-of-servicecertificate-element.md)|Specifies authentication behaviors for service certificates used by a client.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](clientcredentials.md)|Specifies the credentials used by the client to authenticate itself to a service.|  
  
## Remarks  
 This configuration element specifies the settings used by the client to validate the certificate presented by the service using SSL authentication. It also contains any certificate for the service that is explicitly configured on the client to use for encrypting messages to the service using message security.  
  
 The attributes of the `serviceCertificate` element are identical to the attributes of the [\<clientCertificate>](clientcertificate-of-clientcredentials-element.md).  
  
## See also

- <xref:System.ServiceModel.Configuration.ClientCredentialsElement>
- <xref:System.ServiceModel.Configuration.ClientCredentialsElement.ServiceCertificate%2A>
- <xref:System.ServiceModel.Description.ClientCredentials>
- <xref:System.ServiceModel.Description.ClientCredentials.ServiceCertificate%2A>
- <xref:System.ServiceModel.Configuration.X509RecipientCertificateClientElement>
- <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential>
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Securing Clients](../../../wcf/securing-clients.md)
- [Working with Certificates](../../../wcf/feature-details/working-with-certificates.md)
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
