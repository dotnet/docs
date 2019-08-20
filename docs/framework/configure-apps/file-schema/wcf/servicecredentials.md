---
title: "<serviceCredentials>"
ms.date: "03/30/2017"
ms.assetid: 96db336c-4f7a-4193-81a5-910b8ffd804f
---
# \<serviceCredentials>
Specifies the credential to be used in authenticating the service and the client credential validation-related settings.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceCredentials>  
  
## Syntax  
  
```xml  
<serviceCredentials type="String">
  <clientCertificate>
  </clientCertificate>
  <issuedTokenAuthentication>
  </issuedTokenAuthentication>
  <peer>
  </peer>
  <secureConversationAuthentication>
  </secureConversationAuthentication>
  <serviceCertificate>
  </serviceCertificate>
  <userNameAuthentication>
  </userNameAuthentication>
  <windowsAuthentication>
  </windowsAuthentication>
</serviceCredentials>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`type`|A string that specifies the type of this configuration element.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCertificate>](clientcertificate-of-servicecredentials.md)|Specifies the certificate to be used when the client certificate is available out-of-band. This element also specifies client certificate validation settings. This element is of type <xref:System.ServiceModel.Configuration.X509InitiatorCertificateServiceElement>.|  
|[\<issuedTokenAuthentication>](issuedtokenauthentication-of-servicecredentials.md)|Specifies the current issued token for this service. This element is of type <xref:System.ServiceModel.Configuration.IssuedTokenServiceElement>.|  
|[\<peer>](peer-of-servicecredentials.md)|Specifies the current credentials for a peer node. This element is of type <xref:System.ServiceModel.Configuration.PeerCredentialElement>.|  
|[\<secureConversationAuthentication>](secureconversationauthentication-of-servicecredential.md)|Specifies the current credentials for a secure conversation. This element is of type <xref:System.ServiceModel.Configuration.SecureConversationServiceElement>.|  
|[\<serviceCertificate>](servicecertificate-of-servicecredentials.md)|Specifies a certificate used by a service to identify itself. This element is of type <xref:System.ServiceModel.Configuration.X509RecipientCertificateServiceElement>.|  
|[\<userNameAuthentication>](usernameauthentication.md)|Specifies the settings for username password validation. This element is of type <xref:System.ServiceModel.Configuration.UserNameServiceElement>.|  
|[\<windowsAuthentication>](windowsauthentication-of-servicecredentials.md)|Specifies the settings for Windows credential validation. This element is of type <xref:System.ServiceModel.Configuration.WindowsServiceElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## See also

- <xref:System.ServiceModel.Configuration.ServiceCredentialsElement>
- <xref:System.ServiceModel.Description.ServiceCredentials>
- [Security Behaviors](../../feature-details/security-behaviors-in-wcf.md)
