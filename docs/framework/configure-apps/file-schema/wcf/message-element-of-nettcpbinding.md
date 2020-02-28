---
title: "<message> element of <netTcpBinding>"
ms.date: "03/30/2017"
ms.assetid: 1d71edd9-c085-4c2e-b6d3-980c313366f9
---
# \<message> element of \<netTcpBinding>
Defines the type of message-level security requirements for an endpoint configured with the [\<netTcpBinding>](nettcpbinding.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netTcpBinding>**](nettcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<security>**](security-of-nettcpbinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<message>**  
  
## Syntax  
  
```xml  
<message algorithmSuite="System.Servicemodel.Security.SecurityAlgorithmsuite"
         clientCredentialType="None/Windows/UserName/Certificate/IssuedToken" />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`algorithmSuite`|Sets the message encryption and key-wrap algorithms. The algorithms and the key sizes are determined by the <xref:System.ServiceModel.Security.SecurityAlgorithmSuite> class. These algorithms map to those specified in the Security Policy Language (WS-SecurityPolicy) specification.<br /><br /> Possible values are shown in the following table. The default value is `Basic256`.<br /><br /> If the service binding specifies an `algorithmSuite` value that is not equal to the default, and you generate the configuration file using Svcutil.exe, then it is not generated correctly, and you must manually edit the configuration file to set this attribute to the desired value.|  
|`clientCredentialType`|Specifies the type of credential to be used when performing client authentication using Message-based security. Possible values are shown in the following table. The default value is `UserName`. This attribute is of type <xref:System.ServiceModel.MessageCredentialType>.|  
  
## algorithmSuite Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Basic128|Use Aes128 encryption, Sha1 for message digest, and Rsa-oaep-mgf1p for key wrap.|  
|Basic192|Use Aes192 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256|Use Aes256 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256Rsa15|Use Aes256 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic192Rsa15|Use Aes192 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDes|Use TripleDes encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic128Rsa15|Use Aes128 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDesRsa15|Use TripleDes encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic128Sha256|Use Aes256 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic192Sha256|Use Aes192 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic256Sha256|Use Aes256 for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|TripleDesSha256|Use TripleDes for message encryption, Sha256 for message digest and Rsa-oaep-mgf1p for key wrap.|  
|Basic128Sha256Rsa15|Use Aes128 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|Basic192Sha256Rsa15|Use Aes192 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|Basic256Sha256Rsa15|Use Aes256 for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
|TripleDesSha256Rsa15|Use TripleDes for message encryption, Sha256 for message digest and Rsa15 for key wrap.|  
  
## clientCredentialType Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|None|This allows the service to interact with anonymous clients. On the service, this indicates that the service does not require any client credential. On the client, this indicates that the client does not provide any client credential.|  
|Windows|Allows the SOAP exchanges to be under the authenticated context of a Windows credential.|  
|UserName|Allows the service to require that the client be authenticated using a UserName credential. WCF does not support sending a password digest or deriving keys using password and using such keys for message security. As such, WCF enforces that the transport is secured when using UserName credentials. This credential mode results in either an interoperable exchange or a non-interoperable negotiation based on the `negotiateServiceCredential` attribute.|  
|Certificate|Allows the service to require that the client be authenticated using a certificate. If message security mode is used and the `negotiateServiceCredential` attribute is set to `false`, the client must be provisioned with the service certificate.|  
|IssuedToken|Specifies a custom token, usually issued by a Security Token Service (STS).|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-nettcpbinding.md)|Defines the security capabilities for the <xref:System.ServiceModel.Configuration.NetTcpBindingElement>.|  
  
## Remarks  
 Message uses message-level security for the integrity and confidentiality of the SOAP message, and for mutual authentication of the communication peers. If this security mode is selected on a binding, the channel stack is configured with message security binding elements and the SOAP messages are secured in compliance with WS-Security* standards.  
  
## See also

- <xref:System.ServiceModel.MessageSecurityOverTcp>
- <xref:System.ServiceModel.Configuration.NetTcpSecurityElement.Message%2A>
- <xref:System.ServiceModel.NetTcpSecurity.Message%2A>
- <xref:System.ServiceModel.Configuration.NetTcpSecurityElement>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](bindings.md)
