---
title: "&lt;message&gt; of &lt;wsHttpBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 621abbde-590b-454d-90ac-68dc3c69c720
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;message&gt; of &lt;wsHttpBinding&gt;
Defines settings for message-level security of the [\<wsHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md).  
  
 \<system.ServiceModel>  
\<bindings>  
\<wsHttpBinding>  
\<binding>  
\<security>  
\<message>  
  
## Syntax  
  
```xml  
<message   
   algorithmSuite="Basic128/Basic192/Basic256/Basic128Rsa15/Basic256Rsa15/TripleDes/TripleDesRsa15/Basic128Sha256/Basic192Sha256/TripleDesSha256/Basic128Sha256Rsa15/Basic192Sha256Rsa15/Basic256Sha256Rsa15/TripleDesSha256Rsa15"  
   clientCredentialType="Certificate/IssuedToken/None/UserName/Windows"  
   establishSecurityContext="Boolean"  
   negotiateServiceCredential="Boolean" />  
```  
  
## Type  
 <xref:System.ServiceModel.NonDualMessageSecurityOverHttp>  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|algorithmSuite|Sets the message encryption and key-wrap algorithms. The algorithms and the key sizes are determined by the <xref:System.ServiceModel.Security.SecurityAlgorithmSuite> class. These algorithms map to those specified in the Security Policy Language (WS-SecurityPolicy) specification.<br /><br /> The default value is `Basic256`.|  
|clientCredentialType|Optional. Specifies the type of credential to be used when performing client authentication using the security mode is `Message` or `TransportWithMessageCredentials`. See the enumeration values below. The default is `Windows`.<br /><br /> This attribute is of type <xref:System.ServiceModel.MessageCredentialType>.|  
|establishSecurityContext|A Boolean value that determines whether the security channel establishes a secure session. A secure session establishes a Security Context Token (SCT) before exchanging the application messages. When the SCT is established, the security channel offers a <xref:System.ServiceModel.Channels.ISession> interface to the upper channels. For more information about using secure sessions, see [How to: Create a Secure Session](../../../../../docs/framework/wcf/feature-details/how-to-create-a-secure-session.md).<br /><br /> The default value is `true`.|  
|negotiateServiceCredential|Optional. A Boolean value that specifies whether the service credential is provisioned at the client out of band, or is obtained from the service to the client through a process of negotiation. Such a negotiation is a precursor to the usual message exchange.<br /><br /> If the `clientCredentialType` attribute equals to None, Username, or Certificate, setting this attribute to `false` implies that the service certificate is available at the client out of band and that the client needs to specify the service certificate (using the [\<serviceCertificate>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-servicecredentials.md)) in the [\<serviceCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecredentials.md) service behavior. This mode is interoperable with SOAP stacks which implement WS-Trust and WS-SecureConversation.<br /><br /> If the `ClientCredentialType` attribute is set to `Windows`, setting this attribute to `false` specifies Kerberos based authentication. This means that the client and service must be part of the same Kerberos domain. This mode is interoperable with SOAP stacks which implement the Kerberos token profile (as defined at OASIS WSS TC) as well as WS-Trust and WS-SecureConversation.<br /><br /> When this attribute is `true`, it causes a .NET SOAP negotiation that tunnels SPNego exchange over SOAP messages.<br /><br /> The default is `true`.|  
  
## algorithmSuite Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Basic128|Use Basic128 encryption, Sha1 for message digest, and Rsa-oaep-mgf1p for key wrap.|  
|Basic192|Use Basic192 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256|Use Basic256 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256Rsa15|Use Basic256 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic192Rsa15|Use Basic192 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDes|Use TripleDes encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic128Rsa15|Use Basic128 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDesRsa15|Use TripleDes encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic128Sha256|Use Basic256 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic192Sha256|Use Basic192 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic256Sha256|Use Basic256 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|TripleDesSha256|Use TripleDes for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic128Sha256Rsa15|Use Basic128 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|Basic192Sha256Rsa15|Use Basic192 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|Basic256Sha256Rsa15|Use Basic256 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|TripleDesSha256Rsa15|Use TripleDes for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
  
## clientCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|This allows the service to interact with anonymous clients. On the service side, this indicates that the service does not require any client credential. On the client, this indicates that the client does not provide any client credential.|  
|Certificate|Allows the service to require that the client be authenticated using a certificate. If message security mode is used and the `negotiateServiceCredential` attribute is set to `false`, the client needs to be provisioned with the service certificate.|  
|IssuedToken|Specifies a custom token, usually issued by a Security Token Service.|  
|UserName|Allows the service to require that the client be authenticated using a UserName credential. [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] does not support sending a password digest or deriving keys using password and using such keys for message security. As such, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] enforces that the transport is secured when using UserName credentials. This credential mode results in either an interoperable exchange or a non-interoperable negotiation based on the `negotiateServiceCredential` attribute.|  
|Windows|Allows the SOAP exchanges to be under the authenticated context of a Windows credential. If the `negotiateServiceCredential` attribute is set to `true`, this either performs an SSPI Negotiation or Kerberos (an interoperable standard).|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-wshttpbinding.md)|Defines the security settings for a [\<wsHttpBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md).|  
  
## See Also  
 <xref:System.ServiceModel.NonDualMessageSecurityOverHttp>  
 <xref:System.ServiceModel.Configuration.WSHttpSecurityElement.Message%2A>  
 <xref:System.ServiceModel.WSHttpSecurity.Message%2A>  
 <xref:System.ServiceModel.Configuration.NonDualMessageSecurityOverHttpElement>  
 [Securing Services and Clients](../../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Configuring System-Provided Bindings](../../../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Using Bindings to Configure Windows Communication Foundation Services and Clients](http://msdn.microsoft.com/library/bd8b277b-932f-472f-a42a-b02bb5257dfb)  
 [\<binding>](../../../../../docs/framework/misc/binding.md)
