---
title: "<clientCredentials>"
ms.date: "03/30/2017"
ms.assetid: 1e6eef0d-a34e-4d74-b0f7-f65d2181858d
---
# \<clientCredentials>
Specifies the credentials used to authenticate the client to a service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<clientCredentials>**  
  
## Syntax  
  
```xml  
<clientCredentials type="String"
                   supportInteractive="Boolean" >
  <clientCertificate>
  </clientCertificate>
  <digest>
  </digest>
  <isuedToken>
  </isuedToken>
  <peer>
  </peer>
  <serviceCertificate>
  </serviceCertificate>
  <windowsAuthentication>
  </windowsAuthentication>
</clientCredentials>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`supportInteractive`|A Boolean value that specifies whether an interactive user can be involved in selecting a client credential at runtime. The default value is `true`.|  
|`type`|A string that specifies the type of this configuration element.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCertificate>](clientcertificate-of-clientcredentials-element.md)|Specifies the certificate used to authenticate the client to the service. This element is of type <xref:System.ServiceModel.Configuration.X509InitiatorCertificateClientElement>.|  
|[\<httpDigest>](httpdigest-element.md)|Specifies a digest used to authenticate the client to the service. This element is of type <xref:System.ServiceModel.Configuration.HttpDigestClientElement>.|  
|[\<issuedToken>](issuedtoken.md)|Specifies a custom token type used to authenticate the client to a Secure Token Service (STS). This element is of type <xref:System.ServiceModel.Configuration.IssuedTokenClientElement>.|  
|[\<peer>](peer-of-clientcredentials-element.md)|Specifies a current peer credential. This element is of type <xref:System.ServiceModel.Configuration.PeerCredentialElement>.|  
|[\<serviceCertificate>](servicecertificate-of-clientcredentials-element.md)|Specifies the certificate used to authenticate the service to the client and provides a structure for setting certificate options. This certificate must be supplied out-of-band from the service to the client. This element is of type <xref:System.ServiceModel.Configuration.X509RecipientCertificateClientElement>.|  
|[\<windows>](windows-of-clientcredentials-element.md)|Specifies a Windows credential. The default is the credential of the current thread. This element is of type <xref:System.ServiceModel.Configuration.WindowsClientElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## Remarks  
 Client credentials are used to authenticate the client to services in cases where mutual authentication is required. This configuration section can also be used to specify service certificates for scenarios where the client must secure messages to a service with the service's certificate.  
  
## See also

- <xref:System.ServiceModel.Configuration.ClientCredentialsElement>
- <xref:System.ServiceModel.Description.ClientCredentials>
- [Security Behaviors](../../../wcf/feature-details/security-behaviors-in-wcf.md)
- [Securing Clients](../../../wcf/securing-clients.md)
