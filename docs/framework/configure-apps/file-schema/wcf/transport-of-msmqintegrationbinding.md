---
description: "Learn more about: <transport> of <msmqIntegrationBinding>"
title: "<transport> of <msmqIntegrationBinding>"
ms.date: "03/30/2017"
ms.assetid: 054579e3-7fdd-47df-99ca-952706ba5c8e
---
# \<transport> of \<msmqIntegrationBinding>

Defines the security settings for the Message Queuing integration transport.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<msmqIntegrationBinding>**](msmqintegrationbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<security>**](security-of-msmqintegrationbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<transport>**  
  
## Syntax  
  
```xml  
<security>
  <transport msmqAuthenticationMode="None/WindowsDomain/Certificate"
             msmqEncryptionAlgorithm="RC4Stream/AES"
             msmqProtectionLevel="None/Sign/EncryptAndSign"
             msmqSecureHashAlgorithm="MD5/SHA1/SHA256/SHA512" />
</security>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`msmqAuthenticationMode`|Specifies how the message must be authenticated by the MSMQ transport. If this is set to `None`, the value of the `msmqProtectionLevel` attribute must also be set to `None`.<br /><br /> Valid values include the following:<br /><br /> -   None: No authentication.<br />-   WindowsDomain: The authentication mechanism uses Active Directory to get the X.509 certificate for the SID associated with the message. This is then used to check the ACL of the queue to ensure the user has permission to write to the queue.<br />-   Certificate: The channel gets the certificate from the certificate store.<br /><br /> The default value is WindowsDomain. This attribute is of type <xref:System.ServiceModel.MsmqAuthenticationMode>.|  
|`msmqEncryptionAlgorithm`|Specifies the algorithm to be used for message encryption on the wire when transferring messages between message queue managers. Valid values include the following:<br /><br /> -   RC4Stream<br />-   AES<br /><br /> The default value is RC4Stream. This attribute is of type <xref:System.ServiceModel.MsmqEncryptionAlgorithm>.|  
|`msmqProtectionLevel`|Specifies how the message is secured at the level of the MSMQ transport. Encryption ensures message integrity while EncryptAndSign ensures both message integrity and non-repudiation; that is, the message indeed comes from the sender and the sender is who they say they are.<br /><br /> -   Valid values include the following:<br />-   None: No protection.<br />-   Sign: Messages are signed.<br />-   EncryptAndSign: Messages are encrypted and signed.<br /><br /> The default value is Sign. This attribute is of type ProtectionLevel.|  
|`msmqSecureHashAlgorithm`|-   Specifies the algorithm to be used in computing the digest as part of signatures. Valid values include the following:<br />-   MD5<br />-   SHA1<br />-   SHA256<br />-   SHA512<br /><br /> The default value is SHA1. This attribute is of type <xref:System.ServiceModel.MsmqSecureHashAlgorithm>.<br>Due to collision problems with MD5 and SHA1, Microsoft recommends SHA256 or better.|  
  
### Child Elements  

 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-basichttpbinding.md)|Defines the security settings for a MSMQ binding.|  
  
## Remarks  

 This element encapsulates the security settings for the Message Queuing integration transport. The settings are the same for both the Message Queuing integration and queued transports. It enables you to set the Authentication Mode, Encryption Algorithm, Secure Hash Algorithm, and Protection Level.  
  
## See also

- <xref:System.ServiceModel.Configuration.MsmqTransportSecurityElement>
- <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationSecurity.Transport%2A>
- <xref:System.ServiceModel.Configuration.MsmqIntegrationSecurityElement.Transport%2A>
- <xref:System.ServiceModel.MsmqTransportSecurity>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
