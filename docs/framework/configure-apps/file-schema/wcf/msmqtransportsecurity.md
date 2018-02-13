---
title: "&lt;msmqTransportSecurity&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 092e911b-ab1b-4069-a26e-6134c3299e06
caps.latest.revision: 10
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;msmqTransportSecurity&gt;
Specifies MSMQ transport security settings for a custom binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<msmqIntegration>  
\<msmqTransportSecurity>  
  
## Syntax  
  
```xml  
<msmqTransportSecurity>  
   msmqAuthenticationMode="None/Windows/Certificate"  
   msmqEncryptionAlgorithm="RC4Stream/AES"  
   msmqProtectionLevel="None/Sign/EncryptAndSign"  
   msmqSecureHashAlgorithm="MD5/SHA1/SHA256/SHA512" />  
</msmqTransportSecurity>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`msmqAuthenticationMode`|Specifies how the message must be authenticated by the MSMQ transport. If this is set to `None`, the value of the `msmqProtectionLevel` attribute must also be set to `None`.<br /><br /> Valid values include the following:<br /><br /> -   None: No authentication.<br />-   Windows: The authentication mechanism uses Active Directory to get the X.509 certificate for the SID associated with the message. This is then used to check the ACL of the queue to ensure the user has permission to write to the queue.<br />-   Certificate: The channel gets the certificate from the certificate store.<br /><br /> The default value is Windows. This attribute is of type <xref:System.ServiceModel.MsmqAuthenticationMode>.|  
|`msmqEncryptionAlgorithm`|Specifies the algorithm to be used for message encryption on the wire when transferring messages between message queue managers. Valid values include the following:<br /><br /> -   RC4Stream<br />-   AES<br /><br /> The default value is RC4Stream. This attribute is of type <xref:System.ServiceModel.MsmqEncryptionAlgorithm>.|  
|`msmqProtectionLevel`|Specifies how the message is secured at the level of the MSMQ transport. Encryption ensures message integrity while EncryptAndSign ensures both message integrity and non-repudiation; that is, the message indeed comes from the sender and the sender is who he says he is. Valid values include the following:<br /><br /> -   None: No protection.<br />-   Sign: Messages are signed.<br />-   EncryptAndSign: Messages are encrypted and signed.<br /><br /> The default value is Sign. This attribute is of type <xref:System.Net.Security.ProtectionLevel>.|  
|`msmqSecureHashAlgorithm`|Specifies the algorithm to be used in computing the digest as part of signatures. Valid values include the following:<br /><br /> -   MD5<br />-   SHA1<br />-   SHA256<br />-   SHA512<br /><br /> The default value is SHA1. This attribute is of type <xref:System.ServiceModel.MsmqSecureHashAlgorithm>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<msmqIntegration>](../../../../../docs/framework/configure-apps/file-schema/wcf/msmqintegration.md)|Specifies settings required for interaction with a Message Queuing (MSMQ) sender or receiver.|  
|[\<msmqTransport>](../../../../../docs/framework/configure-apps/file-schema/wcf/msmqtransport.md)|Specifies the queuing communication properties for a Windows Communication Foundation (WCF) service that uses the native MSMQ protocol.|  
  
## Remarks  
 For more information on transport security, see [Transport Security](../../../../../docs/framework/wcf/feature-details/transport-security.md).  
  
## See Also  
 <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationSecurity>  
 <xref:System.ServiceModel.Configuration.MsmqTransportSecurityElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Queues in WCF](../../../../../docs/framework/wcf/feature-details/queues-in-wcf.md)  
 [Transports](../../../../../docs/framework/wcf/feature-details/transports.md)  
 [Choosing a Transport](../../../../../docs/framework/wcf/feature-details/choosing-a-transport.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [Transport Security](../../../../../docs/framework/wcf/feature-details/transport-security.md)
