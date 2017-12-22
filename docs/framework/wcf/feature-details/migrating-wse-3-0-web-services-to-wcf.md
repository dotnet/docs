---
title: "Migrating WSE 3.0 Web Services to WCF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7bc5fff7-a2b2-4dbc-86cc-ecf73653dcdc
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Migrating WSE 3.0 Web Services to WCF
The benefits of migrating WSE 3.0 Web services to [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] include improved performance and the support of additional transports, additional security scenarios, and WS-* specifications. A Web service that is migrated from WSE 3.0 to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] can experience up to a 200% to 400% performance improvement. For more information about the transports supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see [Choosing a Transport](../../../../docs/framework/wcf/feature-details/choosing-a-transport.md). For a list of the scenarios supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see [Common Security Scenarios](../../../../docs/framework/wcf/feature-details/common-security-scenarios.md). For a list of the specifications that are supported by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see [Web Services Protocols Interoperability Guide](../../../../docs/framework/wcf/feature-details/web-services-protocols-interoperability-guide.md).  
  
 The following sections provide guidance on how to migrate a specific feature of a WSE 3.0 Web service to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## General  
 WSE 3.0 and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications include wire-level interoperability and a common set of terminology. WSE 3.0 and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications are wire-level interoperable based on the set of WS-* specifications that they both support. When a WSE 3.0 or [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application is developed there is a common set of terminology, such as the names of the turnkey security assertions in WSE and the authentication modes.  
  
 Although there are many similar aspects between the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] and ASP.NET or WSE 3.0 programming models, they are different. For details about the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] programming model, see [Basic Programming Lifecycle](../../../../docs/framework/wcf/basic-programming-lifecycle.md).  
  
> [!NOTE]
>  To migrate a WSE Web service to WCF the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) tool can be used to generate a client. That client however contains interfaces and classes that can be used as a starting point for a WCF service too. The interfaces that are generated have the <xref:System.ServiceModel.OperationContractAttribute> attribute applied to the members of the contract with the <xref:System.ServiceModel.OperationContractAttribute.ReplyAction%2A> property set to `*`. When a WSE client calls a Web service with this setting, the following exception is thrown: **Web.Services3.ResponseProcessingException: WSE910: An error happened during the processing of a response message, and you can find the error in the inner exception**. To mitigate this, set the <xref:System.ServiceModel.OperationContractAttribute.ReplyAction%2A> property of the <xref:System.ServiceModel.OperationContractAttribute> attribute to a non-`null` value, such as `http://Microsoft.WCF.Documentation/ResponseToOCAMethod`.  
  
## Security  
  
### WSE 3.0 Web services that are secured using a policy file  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services can use a configuration file to secure a service and that mechanism is similar to a WSE 3.0 policy file. In WSE 3.0 when securing a Web service using a policy file, you use either a turnkey security assertion or a custom policy assertion. The turnkey security assertions map closely to the authentication mode of a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security binding element. Not only are the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] authentication modes and WSE 3.0 turnkey security assertions named the same or similarly, they secure the messages using the same credential types. For instance, the `usernameForCertificate` turnkey security assertion in WSE 3.0 maps to the `UsernameForCertificate` authentication mode in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. The following code examples demonstrate how a minimal policy that uses the `usernameForCertificate` turnkey security assertion in WSE 3.0 maps to a `UsernameForCertificate` authentication mode in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] in a custom binding.  
  
 **WSE 3.0**  
  
```xml  
<policies>  
  <policy name="MyPolicy">  
    <usernameForCertificate messageProtectionOrder="SignBeforeEncrypt"  
                            requireDeriveKeys="true"/>  
  </policy>  
</policies>  
```  
  
 **WCF**  
  
```xml  
<customBinding>  
  <binding name="MyBinding">  
    <security authenticationMode="UserNameForCertificate"   
              messageProtectionOrder="SignBeforeEncrypt"  
              requireDerivedKeys="true"/>  
  </binding>  
</customBinding>  
```  
  
 To migrate the security settings of a WSE 3.0 Web service that are specified in a policy file to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], a custom binding must be created in a configuration file and the turnkey security assertion must be set to its equivalent authentication mode. Additionally, the custom binding must be configured to use the August 2004 WS-Addressing specification when WSE 3.0 clients communicate with the service. When the migrated [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service does not require communication with WSE 3.0 clients and must only maintain security parity, consider using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] system-defined bindings with appropriate security settings instead of creating a custom binding.  
  
 The following table lists the mapping between a WSE 3.0 policy file and the equivalent custom binding in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
|WSE 3.0 Turnkey Security Assertion|WCF custom binding configuration|  
|----------------------------------------|--------------------------------------|  
|\<usernameOverTransportSecurity />|`<customBinding>   <binding name="MyBinding">     <security authenticationMode="UserNameOverTransport" />     <textMessageEncoding messageVersion="Soap12WSAddressingAugust2004" />   </binding> </customBinding>`|  
|\<mutualCertificate10Security />|`<customBinding>   <binding name="MyBinding">     <security messageSecurityVersion="WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10" authenticationMode="MutualCertificate" />     <textMessageEncoding messageVersion="Soap12WSAddressingAugust2004" />   </binding> </customBinding>`|  
|\<usernameForCertificateSecurity />|`<customBinding>   <binding name="MyBinding">     <security authenticationMode="UsernameForCertificate"/>     <textMessageEncoding messageVersion="Soap12WSAddressingAugust2004" />   </binding> </customBinding>`|  
|\<anonymousForCertificateSecurity />|`<customBinding>   <binding name="MyBinding">     <security authenticationMode="AnonymousForCertificate"/>     <textMessageEncoding messageVersion="Soap12WSAddressingAugust2004" />   </binding> </customBinding>`|  
|\<kerberosSecurity />|`<customBinding>   <binding name="MyBinding">     <security authenticationMode="Kerberos"/>     <textMessageEncoding messageVersion="Soap12WSAddressingAugust2004" />   </binding> </customBinding>`|  
|\<mutualCertificate11Security />|`<customBinding>   <binding name="MyBinding">     <security authenticationMode="MutualCertificate"/>     <textMessageEncoding messageVersion="Soap12WSAddressingAugust2004" />   </binding> </customBinding>`|  
  
 For more information about creating custom bindings in WCF, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
### WSE 3.0 Web services that are secured using application code  
 Whether WSE 3.0 or [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is used, the security requirements can be specified in application code instead of in configuration. In WSE 3.0, this is accomplished by creating a class that derives from the `Policy` class and then by adding the requirements by calling the `Add` method. For more details about specifying the security requirements in code, see [How to: Secure a Web Service Without Using a Policy File](http://go.microsoft.com/fwlink/?LinkId=73747). In [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], to specify security requirements in code, create an instance of the <xref:System.ServiceModel.Channels.BindingElementCollection> class and add an instance of a <xref:System.ServiceModel.Channels.SecurityBindingElement> to the <xref:System.ServiceModel.Channels.BindingElementCollection>. The security assertion requirements are set using the static authentication mode helper methods of the <xref:System.ServiceModel.Channels.SecurityBindingElement> class. For more details about specifying security requirements in code using [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md) and [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md).  
  
### WSE 3.0 Custom Policy Assertion  
 In WSE 3.0 there are two types of custom policy assertions: those that secure a SOAP message and those that do not secure a SOAP message. Policy assertions that secure SOAP messages derive from WSE 3.0 `SecurityPolicyAssertion` class and the conceptual equivalent in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is the <xref:System.ServiceModel.Channels.SecurityBindingElement> class.  
  
 An important point to note is that the WSE 3.0 turnkey security assertions are a subset of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] authentication modes. If you have created a custom policy assertion in WSE 3.0, there may be an equivalent [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] authentication mode. For example, WSE 3.0 does not provide a CertificateOverTransport security assertion that is the equivalent to `UsernameOverTransport` turnkey security assertion, but uses an X.509 certificate for client authentication purposes. If you have defined your own custom policy assertion for this scenario, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] makes the migration straightforward. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] defines an authentication mode for this scenario, so you can take advantage of the static authentication mode helper methods to configure a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]<xref:System.ServiceModel.Channels.SecurityBindingElement>.  
  
 When there is not a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] authentication mode that is equivalent to a custom policy assertion that secures SOAP messages, derive a class from <xref:System.ServiceModel.Channels.TransportSecurityBindingElement>, <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement> or <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] classes and specify the equivalent binding element. For more details, see [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md).  
  
 To convert a custom policy assertion that does not secure a SOAP message, see [Filtering](../../../../docs/framework/wcf/feature-details/filtering.md) and the sample [Custom Message Interceptor](../../../../docs/framework/wcf/samples/custom-message-interceptor.md).  
  
### WSE 3.0 Custom Security Token  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] programming model for creating a custom token is different than WSE 3.0. For details about creating a custom token in WSE, see [Creating Custom Security Tokens](http://go.microsoft.com/fwlink/?LinkID=73750). For details about creating a custom token in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md).  
  
### WSE 3.0 Custom Token Manager  
 The programming model for creating a custom token manager is different in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] than WSE 3.0. For details about how to create a custom token manager and the other components that are required for a custom security token, see [How to: Create a Custom Token](../../../../docs/framework/wcf/extending/how-to-create-a-custom-token.md).  
  
> [!NOTE]
>  If you have created a custom `UsernameToken` security token manager, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides an easier mechanism to specify the authentication logic than creating a custom security token manager. For more details, see [How to: Use a Custom User Name and Password Validator](../../../../docs/framework/wcf/feature-details/how-to-use-a-custom-user-name-and-password-validator.md).  
  
### WSE 3.0 Web services that use MTOM encoded SOAP messages  
 Like a WSE 3 application, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application can specify the MTOM message encoding in configuration. To migrate this setting, add the [\<mtomMessageEncoding>](../../../../docs/framework/configure-apps/file-schema/wcf/mtommessageencoding.md) to the binding for the service. The following code example demonstrates how MTOM encoding is specified in WSE 3.0 for a service that is equivalent in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
 **WSE 3.0**  
  
```xml  
<messaging>  
    <mtom clientMode="On"/>  
</messaging>  
```  
  
 **WCF**  
  
```xml  
<customBinding>  
  <binding name="MyBinding">  
    <mtomMessageEncoding/>  
  </binding>  
</customBinding>  
```  
  
## Messaging  
  
### WSE 3.0 Applications that use the WSE Messaging API  
 When the WSE Messaging API is used to gain direct access to the XML that is communicated between the client and Web service, the application can be converted to use "Plain Old XML" (POX). For more details about POX, see [Interoperability with POX Applications](../../../../docs/framework/wcf/feature-details/interoperability-with-pox-applications.md). For more details about the WSE Messaging API, see [Sending and Receiving SOAP Messages Using WSE Messaging API](http://go.microsoft.com/fwlink/?LinkID=73755).  
  
## Transports  
  
### TCP  
 By default, WSE 3.0 clients and Web services that send SOAP messages using the TCP transport do not interoperate with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients and Web services. This incompatibility is due to differences in the framing used in the TCP protocol and for performance reasons. However, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sample details how to implement a custom TCP session that interoperates with WSE 3.0. For details about this sample, see [Transport: WSE 3.0 TCP Interoperability](../../../../docs/framework/wcf/samples/transport-wse-3-0-tcp-interoperability.md).  
  
 To specify that a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application uses the TCP transport, use the [\<netTcpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md).  
  
### Custom Transport  
 The equivalent of a WSE 3.0 custom transport in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] is a channel extension. For details about creating a channel extension, see [Extending the Channel Layer](../../../../docs/framework/wcf/extending/extending-the-channel-layer.md).  
  
## See Also  
 [Basic Programming Lifecycle](../../../../docs/framework/wcf/basic-programming-lifecycle.md)  
 [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md)  
 [How to: Create a Custom Binding Using the SecurityBindingElement](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-binding-using-the-securitybindingelement.md)  
 [How to: Create a SecurityBindingElement for a Specified Authentication Mode](../../../../docs/framework/wcf/feature-details/how-to-create-a-securitybindingelement-for-a-specified-authentication-mode.md)
