---
title: "&lt;security&gt; of &lt;netMsmqBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 001d11a9-7439-498c-b09d-fca20eaf8cd3
caps.latest.revision: 15
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;security&gt; of &lt;netMsmqBinding&gt;
Defines the security settings for a MSMQ binding. It specifies whether transport or SOAP security is enabled and, if so, what authentication mode and protection levels are in use.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netMsmqBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<security mode="None/Transport/Message/Both">  
   <transport msmqAuthenticationMode="None/WindowsDomain/Certificate"  
      msmqEncryptionAlgorithm="RC4Stream/AES"  
      msmqProtectionLevel="None/Sign/EncryptAndSign"  
      msmqSecureHashAlgorithm="MD5/SHA1/SHA256/SHA512" />  
      <message  
      algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
      clientCredentialType="None/Windows/UserName/Certificate/CardSpace"/>  
</security>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|Specifies the type of security that controls integrity, confidentiality and authentication. Valid values include the following:<br /><br /> -   None: This disables security.<br />-   Transport: Protection and authentication are offered by the transport. This applies to the message security between the two queue managers. There is no security offered between the application and queue manager. Existing Msmq applications are functionally equivalent with this type of security mode.<br />-   Message: Specifies end-end application security. There is no security offered at the transport layer. This is similar to the security offered by other standard bindings.<br />-   Both: Offers security at both the transport and SOAP messaging layer. The same credential is required at both the levels.<br /><br /> The default value is Transport. This attribute is of type <xref:System.ServiceModel.NetMsmqSecurityMode>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<message>](../../../../../docs/framework/configure-apps/file-schema/wcf/message-of-netmsmqbinding.md)|Defines the SOAP message security settings. This element is of type <xref:System.ServiceModel.Configuration.MessageSecurityOverMsmqElement>.|  
|[\<transport>](../../../../../docs/framework/configure-apps/file-schema/wcf/transport-of-netmsmqbinding.md)|Defines the security settings for the MSMQ transport. This element is of type <xref:System.ServiceModel.Configuration.MsmqTransportSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|binding|The binding element of the [\<netMsmqBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/netmsmqbinding.md)|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.NetMsmqSecurityElement>  
 <xref:System.ServiceModel.NetMsmqBinding.Security%2A>  
 <xref:System.ServiceModel.Configuration.NetMsmqBindingElement.Security%2A>  
 <xref:System.ServiceModel.NetMsmqSecurity>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)  
 [Queues in WCF](../../../../../docs/framework/wcf/feature-details/queues-in-wcf.md)
