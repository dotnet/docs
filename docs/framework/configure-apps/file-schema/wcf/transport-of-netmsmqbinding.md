---
title: "<transport> of <netMsmqBinding>"
ms.date: "03/30/2017"
ms.assetid: 72e1b338-39f0-4af1-a5d9-7a2fb79f6a0b
---
# \<transport> of \<netMsmqBinding>
Defines the transport security settings.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netMsmqBinding>  
\<binding>  
\<security>  
\<transport>  
  
## Syntax  
  
```xml  
<netMsmqBinding>
  <binding>
    <security>
      <transport msmqAuthenticationMode="None/WindowsDomain/Certificate"
                 msmqEncryptionAlgorithm="RC4Stream/AES"
                 msmqProtectionLevel="None/Sign/EncryptAndSign"
                 msmqSecureHashAlgorithm="MD5/SHA1/SHA256/SHA512" />
    </security>
  </binding>
</netMsmqBinding>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|msmqAuthenticationMode|Specifies how the message must be authenticated by the MSMQ transport. Valid values include the following:<br /><br /> -   None: No authentication.<br />-   WindowsDomain: The authentication mechanism uses Active Directory to retrieve the X.509 certificate for the security identifier associated with the message. This is then used to check the ACL of the queue to ensure the user has write permission for the queue.<br />-   Certificate: The channel retrieves the certificate from the certificate store.<br /><br /> The default is `WindowsDomain`.<br /><br /> If this attribute is set to `None`, the `msmqProtectionLevel` attribute must also be set to `None`. This attribute is of type <xref:System.ServiceModel.MsmqAuthenticationMode>|  
|msmqEncryptionAlgorithm|Specifies the algorithm to be used for message encryption on the wire when transferring messages between message queue managers. Valid values include the following:<br /><br /> -   RC4Stream<br />-   AES<br />-   The default value is `RC4Stream`. This attribute is of type <xref:System.ServiceModel.MsmqEncryptionAlgorithm>.|  
|msmqProtectionLevel|Specifies the way messages are secured at the level of the MSMQ transport. Encryption ensures message integrity, while sign and encrypt ensures both message integrity and non-repudiation. That is, the message indeed came from the sender and the sender is who he says he is. Valid values include the following:<br /><br /> -   None: No protection.<br />-   Sign: Messages are signed.<br />-   EncryptAndSign: Messages are encrypted and signed.<br />-   The default is `Sign`.|  
|msmqSecureHashAlgorithm|Specifies the hash algorithm to be used for computing the message digest. Valid values include the following:<br /><br /> -   MD5<br />-   SHA1<br />-   SHA256<br />-   SHA512<br /><br /> The default is `SHA1`. This attribute is of type <xref:System.ServiceModel.MsmqSecureHashAlgorithm>.<br>Due to collision problems with MD5 and SHA1, Microsoft recommends SHA256 or better.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-netmsmqbinding.md)|Defines the transport security settings for queued transports.|  
  
## See also

- <xref:System.ServiceModel.Configuration.MsmqTransportSecurityElement>
- <xref:System.ServiceModel.Configuration.NetMsmqSecurityElement.Transport%2A>
- <xref:System.ServiceModel.NetMsmqSecurity.Transport%2A>
- <xref:System.ServiceModel.MsmqTransportSecurity>
- [Queues in WCF](../../feature-details/queues-in-wcf.md)
- [Securing Services and Clients](../../feature-details/securing-services-and-clients.md)
- [Bindings](../../bindings.md)
- [Configuring System-Provided Bindings](../../feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../using-bindings-to-configure-services-and-clients.md)
- [\<binding>](../../../misc/binding.md)
