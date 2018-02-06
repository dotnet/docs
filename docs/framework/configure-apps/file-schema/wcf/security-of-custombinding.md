---
title: "&lt;security&gt; of &lt;customBinding&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 243a5148-bbd1-447f-a8a5-6e7792c0a3f1
caps.latest.revision: 24
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;security&gt; of &lt;customBinding&gt;
Specifies the security options for a custom binding.  
  
 \<system.serviceModel>  
\<bindings>  
\<customBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<security   
   allowSerializedSigningTokenOnReply="Boolean"  
   authenticationMode="AuthenticationMode"  
      defaultAlgorithmSuite="SecurityAlgorithmSuite"  
   includeTimestamp="Boolean"  
      requireDerivedKeys="Boolean"  
   keyEntropyMode="ClientEntropy/ServerEntropy/CombinedEntropy"   
messageProtectionOrder="SignBeforeEncrypt/SignBeforeEncryptAndEncryptSignature/EncryptBeforeSign"  
      messageSecurityVersion="WSSecurityJan2004/WSSecurityXXX2005"  
   requireDerivedKeys="Boolean"  
   requireSecurityContextCancellation="Boolean"  
   requireSignatureConfirmation="Boolean"  
      securityHeaderLayout=  
              "Strict/Lax/LaxTimestampFirst/LaxTimestampLast">  
   <issuedTokenParameters />  
   <localClientSettings />  
   <localServiceSettings />  
   <secureConversationBootstrap />  
</security>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|allowSerializedSigningTokenOnReply|Optional. A Boolean value that specifies if a serialized token can be used on reply. The default value is `false`. When using a dual binding, the setting defaults to `true` and any setting made will be ignored.|  
|authenticationMode|Optional. Specifies the authentication mode used between the initiator and the responder. See below for all values.<br /><br /> The default is `sspiNegotiated`.|  
|defaultAlgorithmSuite|Optional. Sets the message encryption and key-wrap algorithms. The algorithms and the key sizes are determined by the <xref:System.ServiceModel.Security.SecurityAlgorithmSuite> class. These algorithms map to those specified in the Security Policy Language (WS-SecurityPolicy) specification.<br /><br /> Possible values are shown below. The default value is `Basic256`.<br /><br /> This attribute is used when working with a different platform that opts for a set of algorithms different than the default. You should be aware of the strengths and weaknesses of the relevant algorithms when making modifications to this setting. This attribute is of type <xref:System.ServiceModel.Security.SecurityAlgorithmSuite>.|  
|includeTimestamp|A Boolean value that specifies whether time stamps are included in each message. The default is `true`.|  
|keyEntropyMode|Specifies the way that keys for securing messages are computed. Keys can be based on the client key material only, on the service key material only or a combination of both. Valid values are<br /><br /> -   `ClientEntropy`: The session key is based on key data provided by the client.<br />-   `ServerEntropy`: The session key is based on key data provided by the server.<br />-   `CombinedEntropy`: The session key is based on the key data provided by the client and service.<br /><br /> The default is `CombinedEntropy`.<br /><br /> This attribute is of type <xref:System.ServiceModel.Security.SecurityKeyEntropyMode>.|  
|messageProtectionOrder|Sets the order in which message level security algorithms are applied to the message. Valid values include the following:<br /><br /> -   `SignBeforeEncrypt`: Sign first, then encrypt.<br />-   `SignBeforeEncryptAndEncryptSignature`: Sign first, encrypt, then encrypt the signature.<br />-   `EncryptBeforeSign`: Encrypt first, then sign.<br /><br /> The default value depends upon the version of WS-Security being used. The default value is `SignBeforeEncryptAndEncryptSignature` when using WS-Security 1.1. The default value is `SignBeforeEncrypt` when using WS-Security 1.0.<br /><br /> This attribute is of type <xref:System.ServiceModel.Security.MessageProtectionOrder>.|  
|messageSecurityVersion|Optional. Sets the version of WS-Security that is used. Valid values include the following:<br /><br /> -   WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11<br />-   WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10<br />-   WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10<br /><br /> The default is WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11 and can be expressed in the XML as simply `Default`. This attribute is of type <xref:System.ServiceModel.MessageSecurityVersion>.|  
|requireDerivedKeys|A Boolean value that specifies if keys can be derived from the original proof keys. The default is `true`.|  
|requireSecurityContextCancellation|Optional. A Boolean value that specifies if security context should be cancelled and terminated when it is no longer needed. The default is `true`.|  
|requireSignatureConfirmation|Optional. A Boolean value that specifies whether WS-Security signature confirmation is enabled. When set to `true`, message signatures are confirmed by the responder.  When the custom binding is configured for mutual certificates or it is configured to use issued tokens (WSS 1.1 bindings) this attribute defaults to `true`. Otherwise, the default is `false`.<br /><br /> Signature confirmation is used to confirm that the service is responding in full awareness of a request.|  
|securityHeaderLayout|Optional. Specifies the ordering of the elements in security header. Valid values are<br /><br /> -   `Strict`: Items are added to the security header according to the general principle of "declare before use".<br />-   `Lax`: Items are added to the security header in any order that confirms to WSS: SOAP Message security.<br />-   `LaxWithTimestampFirst`: Items are added to the security header in any order that confirms to WSS: SOAP Message security except that the first element in the security header must be a wsse:Timestamp element.<br />-   `LaxWithTimestampLast`: Items are added to the security header in any order that confirms to WSS: SOAP Message security except that the last element in the security header must be a wsse:Timestamp element.<br /><br /> The default is `Strict`.<br /><br /> This element is of type <xref:System.ServiceModel.Channels.SecurityHeaderLayout>.|  
  
## authenticationMode Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|String|`AnonymousForCertificate`<br /><br /> `AnonymousForSslNegotiated`<br /><br /> `CertificateOverTransport`<br /><br /> `IssuedToken`<br /><br /> `IssuedTokenForCertificate`<br /><br /> `IssuedTokenForSslNegotiated`<br /><br /> `IssuedTokenOverTransport`<br /><br /> `Kerberos`<br /><br /> `KerberosOverTransport`<br /><br /> `MutualCertificate`<br /><br /> `MutualCertificateDuplex`<br /><br /> `MutualSslNegotiated`<br /><br /> `SecureConversation`<br /><br /> `SspiNegotiated`<br /><br /> `UserNameForCertificate`<br /><br /> `UserNameForSslNegotiated`<br /><br /> `UserNameOverTransport`<br /><br /> `SspiNegotiatedOverTransport`|  
  
## defaultAlgorithm Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|Basic128|Use Aes128 encryption, Sha1 for message digest, and Rsa-oaep-mgf1p for key wrap.|  
|Basic192|Use Aes192 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256|Use Aes256 encryption, Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
|Basic256Rsa15|Use Aes256 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|Basic192Rsa15|Use Aes192 for message encryption, Sha1 for message digest and Rsa15 for key wrap.|  
|TripleDes|Use TripleDes encryption,  Sha1 for message digest, Rsa-oaep-mgf1p for key wrap.|  
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
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuedTokenParameters>](../../../../../docs/framework/configure-apps/file-schema/wcf/issuedtokenparameters.md)|Specifies a current issued token. This element is of type <xref:System.ServiceModel.Configuration.IssuedTokenParametersElement>.|  
|[\<localClientSettings>](../../../../../docs/framework/configure-apps/file-schema/wcf/localclientsettings-element.md)|Specifies the security settings of a local client for this binding. This element is of type <xref:System.ServiceModel.Configuration.LocalClientSecuritySettingsElement>.|  
|[\<localServiceSettings>](../../../../../docs/framework/configure-apps/file-schema/wcf/localservicesettings-element.md)|Specifies the security settings of a local service for this binding. This element is of type <xref:System.ServiceModel.Configuration.LocalServiceSecuritySettingsElement>.|  
|[\<secureConversationBootstrap>](../../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md)|Specifies the default values used for initiating a secure conversation service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../../../docs/framework/misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] using this element, see [SecurityBindingElement Authentication Modes](../../../../../docs/framework/wcf/feature-details/securitybindingelement-authentication-modes.md) and [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md).  
  
## Example  
 The following example demonstrates how to configure security using a custom binding. It shows how to use a custom binding to enable message-level security together with a secure transport. This is useful when a secure transport is required to transmit the messages between client and service and simultaneously the messages must be secure on the message level. This configuration is not supported by system-provided bindings.  
  
 The service configuration defines a custom binding that supports TCP communication protected using TLS/SSL protocol, and Windows message security. The custom binding uses a service certificate to authenticate the service on the transport level and to protect the messages during the transmission between client and service. This is accomplished by the [\<sslStreamSecurity>](../../../../../docs/framework/configure-apps/file-schema/wcf/sslstreamsecurity.md) binding element. The service's certificate is configured using a service behavior.  
  
 Additionally, the custom binding uses message security with Windows credential type - this is the default credential type. This is accomplished by the [security](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md) binding element. Both client and service are authenticated using message-level security if Kerberos authentication mechanism is available. If the Kerberos authentication mechanism is not available, NTLM authentication is used. NTLM authenticates the client to the service but does not authenticate service to the client. The [security](../../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md) binding element is configured to use `SecureConversation` authenticationType, which results in the creation of a security session on both the client and the service. This is required to enable the service's duplex contract to work. For more information on running this example, see [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md).  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service   
          name="Microsoft.ServiceModel.Samples.CalculatorService"  
          behaviorConfiguration="CalculatorServiceBehavior">  
        <host>  
          <baseAddresses>  
            <!-- use following base address -->  
            <add baseAddress="net.tcp://localhost:8000/ServiceModelSamples/Service"/>  
          </baseAddresses>  
        </host>  
        <endpoint address=""  
                    binding="customBinding"  
                    bindingConfiguration="Binding1"   
                    contract="Microsoft.ServiceModel.Samples.ICalculatorDuplex" />  
        <!-- the mex endpoint is exposed at net.tcp://localhost:8000/ServiceModelSamples/service/mex -->  
        <endpoint address="mex"  
                  binding="mexTcpBinding"  
                  contract="IMetadataExchange" />  
      </service>  
    </services>  
  
    <bindings>  
      <!-- configure a custom binding -->  
      <customBinding>  
        <binding name="Binding1">  
          <security authenticationMode="SecureConversation"  
                     requireSecurityContextCancellation="true">  
          </security>  
          <textMessageEncoding messageVersion="Soap12WSAddressing10" writeEncoding="utf-8"/>  
          <sslStreamSecurity requireClientCertificate="false"/>  
          <tcpTransport/>  
        </binding>  
      </customBinding>  
    </bindings>  
  
    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="CalculatorServiceBehavior">  
          <serviceMetadata />  
          <serviceDebug includeExceptionDetailInFaults="False" />  
          <serviceCredentials>  
            <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName"/>  
          </serviceCredentials>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.SecurityElement>  
 <xref:System.ServiceModel.Channels.SecurityBindingElement>  
 <xref:System.ServiceModel.Channels.CustomBinding>  
 [Bindings](../../../../../docs/framework/wcf/bindings.md)  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)  
 [Custom Bindings](../../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [\<customBinding>](../../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [Custom Binding Security](../../../../../docs/framework/wcf/samples/custom-binding-security.md)
