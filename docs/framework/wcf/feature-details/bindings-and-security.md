---
title: "Bindings and Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "bindings [WCF], security"
  - "WCF security"
  - "Windows Communication Foundation, security"
  - "bindings [WCF]"
ms.assetid: 4de03dd3-968a-4e65-af43-516e903d7f95
caps.latest.revision: 42
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Bindings and Security
The system-provided bindings included with [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] offer a quick way to program [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] applications. With one exception, all the bindings have a default security scheme enabled. This topic helps you select the right binding for your security needs.  
  
 For an overview of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security, see [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] programming [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] using bindings, see [Programming WCF Security](../../../../docs/framework/wcf/feature-details/programming-wcf-security.md).  
  
 If you have already selected a binding, you can find out more about the run-time behaviors that are associated with security in [Security Behaviors](../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md).  
  
 Some security functions are not programmable using the system-provided bindings. For more control using a custom binding, see [Security Capabilities with Custom Bindings](../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md).  
  
## Security Functions of Bindings  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] includes a number of system-provided bindings that meet most needs. If a particular binding does not suffice, you can also create a custom binding. For a list of system-provided bindings, see [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] custom bindings, see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md).  
  
 Every binding in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] has two forms: as an API and as an XML element used in a configuration file. For example, the `WSHttpBinding` (API) has a counterpart in the [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md).  
  
 The following section lists both forms for each binding and summarizes the security features.  
  
### BasicHttp  
 In code, use the <xref:System.ServiceModel.BasicHttpBinding> class; in configuration, use the [\<basicHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md).  
  
 This binding is designed for use with a range of existing technologies, including the following:  
  
-   ASP.NET Web services (ASMX), version 1.  
  
-   Web Service Enhancements (WSE) applications.  
  
-   Basic Profile as defined in the Web Services Interoperability (WS-I) specification ([http://go.microsoft.com/fwlink/?LinkId=38955](http://go.microsoft.com/fwlink/?LinkId=38955)).  
  
-   Basic security profile as defined in WS-I.  
  
 By default, this binding is not secure. It is designed to interoperate with ASMX services. When security is enabled, the binding is designed for seamless interoperation with Internet Information Services (IIS) security mechanisms, such as basic authentication, digest, and integrated Windows security. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Transport Security Overview](../../../../docs/framework/wcf/feature-details/transport-security-overview.md). This binding supports the following:  
  
-   HTTPS transport security.  
  
-   HTTP basic authentication.  
  
-   WS-Security.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.BasicHttpSecurity>, <xref:System.ServiceModel.BasicHttpMessageSecurity>, <xref:System.ServiceModel.BasicHttpMessageCredentialType>, and <xref:System.ServiceModel.BasicHttpSecurityMode>.  
  
### WSHttpBinding  
 In code, use the <xref:System.ServiceModel.WSHttpBinding> class; in configuration, use the [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md).  
  
 By default, this binding implements the WS-Security specification and provides interoperability with services that implement the WS-* specifications. It supports the following:  
  
-   HTTPS transport security.  
  
-   WS-Security.  
  
-   HTTPS transport protection with SOAP message credential security for authenticating the caller.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.WSHttpSecurity>, <xref:System.ServiceModel.MessageSecurityOverHttp>, <xref:System.ServiceModel.MessageCredentialType>, <xref:System.ServiceModel.SecurityMode>, <xref:System.ServiceModel.HttpTransportSecurity>, <xref:System.ServiceModel.HttpClientCredentialType>, and <xref:System.ServiceModel.HttpProxyCredentialType>.  
  
### WSDualHttpBinding  
 In code, use the <xref:System.ServiceModel.WSDualHttpBinding> class; in configuration, use the [\<wsDualHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wsdualhttpbinding.md).  
  
 This binding is designed to enable duplex service applications. This binding implements the WS-Security specification for message-based transfer security. Transport security is not available. By default, it provides the following features:  
  
-   Implements WS-Reliable Messaging for reliability.  
  
-   Implements WS-Security for transfer security and authentication.  
  
-   Uses HTTP for message delivery.  
  
-   Uses text/XML message encoding.  
  
 Using WS-Security (message-layer security), the binding allows you to configure the following parameters:  
  
-   The security algorithm suite to determine the cryptographic algorithm.  
  
-   Binding options for the following:  
  
    -   Providing service credentials available out-of-band at the client.  
  
    -   Providing service credentials negotiated from the service as part of channel setup.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.WSDualHttpSecurity> and <xref:System.ServiceModel.WSDualHttpSecurityMode>.  
  
### NetTcpBinding  
 In code, use the <xref:System.ServiceModel.NetTcpBinding> class; in configuration, use the [\<netTcpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md).  
  
 This binding is optimized for cross-machine communication. By default, it has the following characteristics:  
  
-   Implements transport-layer security.  
  
-   Leverages Windows security for transfer security and authentication.  
  
-   Uses TCP for transport.  
  
-   Implements binary message encoding.  
  
-   Implements WS-Reliable Messaging.  
  
 Options include the following:  
  
-   Message-layer security (using WS-Security).  
  
-   Transport security with message credential—confidentiality and integrity provided by Transport Layer Security (TLS) over TCP, and credentials for authorization provided by WS-Security.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.NetTcpSecurity>, <xref:System.ServiceModel.TcpTransportSecurity>, <xref:System.ServiceModel.TcpClientCredentialType>, <xref:System.ServiceModel.MessageSecurityOverTcp>, and <xref:System.ServiceModel.MessageCredentialType>.  
  
### NetNamedPipeBinding  
 In code, use the <xref:System.ServiceModel.NetNamedPipeBinding> class; in configuration, use the [\<netNamedPipeBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/netnamedpipebinding.md).  
  
 This binding is optimized for cross-process communication (usually on the same machine). By default, this binding has the following characteristics:  
  
-   Uses transport security for message transfer and authentication.  
  
-   Uses named pipes for message delivery.  
  
-   Implements binary message encoding.  
  
-   Encryption and message signing.  
  
 Options include the following:  
  
-   Authentication using Windows security.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.NetNamedPipeSecurity>, <xref:System.ServiceModel.NetNamedPipeSecurityMode>, and <xref:System.ServiceModel.NamedPipeTransportSecurity>.  
  
### MsmqIntegrationBinding  
 In code, use the <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> class; in configuration, use the [\<msmqIntegrationBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/msmqintegrationbinding.md).  
  
 This binding is optimized for creating [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] clients and services that interoperate with non-[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] Microsoft Message Queuing (MSMQ) endpoints.  
  
 By default, this binding uses transport security and provides the following security characteristics:  
  
-   Security can be disabled (None).  
  
-   MSMQ transport security (Transport).  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.NetMsmqSecurity> and <xref:System.ServiceModel.NetMsmqSecurityMode>.  
  
### NetMsmqBinding  
 In code, use the <xref:System.ServiceModel.NetMsmqBinding> class; in configuration, use the [\<netMsmqBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/netmsmqbinding.md).  
  
 This binding is intended for use when creating [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services that require MSMQ queued message support.  
  
 By default, this binding uses transport security and provides the following security characteristics:  
  
-   Security can be disabled (None).  
  
-   MSMQ transport security (Transport).  
  
-   SOAP-based message security (Message).  
  
-   Simultaneous Transport and Message security (Both).  
  
-   Client Credential Types supported: None, Windows, UserName, Certificate, IssuedToken.  
  
 The <xref:System.ServiceModel.MessageCredentialType.Certificate> credential is supported only when the security mode is set to either <xref:System.ServiceModel.NetMsmqSecurityMode.Both> or <xref:System.ServiceModel.NetMsmqSecurityMode.Message>.  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] <xref:System.ServiceModel.MessageSecurityOverMsmq> and <xref:System.ServiceModel.MsmqTransportSecurity>.  
  
### WSFederationHttpBinding  
 In code, use the <xref:System.ServiceModel.WSFederationHttpBinding> class; in configuration, use the [\<wsFederationHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wsfederationhttpbinding.md).  
  
 By default, this binding uses WS-Security (message-layer security).  
  
 [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Federation](../../../../docs/framework/wcf/feature-details/federation.md), <xref:System.ServiceModel.WSFederationHttpSecurity>, and <xref:System.ServiceModel.WSFederationHttpSecurityMode>.  
  
## Custom Bindings  
 If none of the system-provided bindings meets you requirements, you can create a custom binding with a custom security binding element. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Security Capabilities with Custom Bindings](../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md).  
  
## Binding Choices  
 The following table summarizes the features offered in the security mode setting, that is, it lists the features available when the security mode is set to `Transport`, `Message`, or `TransportWithMessageCredential`. Use this table to help you find the security features your application requires.  
  
|Setting|Features|  
|-------------|--------------|  
|Transport|Server authentication<br /><br /> Client authentication<br /><br /> Point-to-point security<br /><br /> Interoperability<br /><br /> Hardware acceleration<br /><br /> High throughput<br /><br /> Secure firewall<br /><br /> High-latency applications<br /><br /> Re-encryption across multiple hops|  
|Message|Server authentication<br /><br /> Client authentication<br /><br /> End-to-end security<br /><br /> Interoperability<br /><br /> Rich claims<br /><br /> Federation<br /><br /> Multifactor authentication<br /><br /> Custom tokens<br /><br /> Notary/timestamp service<br /><br /> High-latency applications<br /><br /> Persistence of message signatures|  
|TransportWithMessageCredential|Server authentication<br /><br /> Client authentication<br /><br /> Point-to-point security<br /><br /> Interoperability<br /><br /> Hardware acceleration<br /><br /> High throughput<br /><br /> Rich client claims<br /><br /> Federation<br /><br /> Multifactor authentication<br /><br /> Custom tokens<br /><br /> Secure firewall<br /><br /> High-latency applications<br /><br /> Re-encryption across multiple hops|  
  
 The following table lists the bindings that support the various mode settings. Select a binding from the table to use to create your service endpoint.  
  
|Binding|Transport mode support|Message mode support|TransportWithMessageCredential support|  
|-------------|----------------------------|--------------------------|--------------------------------------------|  
|`BasicHttpBinding`|Yes|Yes|Yes|  
|`WSHttpBinding`|Yes|Yes|Yes|  
|`WSDualHttpBinding`|No|Yes|No|  
|`NetTcpBinding`|Yes|Yes|Yes|  
|`NetNamedPipeBinding`|Yes|No|No|  
|`NetMsmqBinding`|Yes|Yes|No|  
|`MsmqIntegrationBinding`|Yes|No|No|  
|`wsFederationHttpBinding`|No|Yes|Yes|  
  
## Transport Credentials in Bindings  
 The following table lists the client credential types available when using either `BasicHttpBinding` or `WSHttpBinding` in transport security mode.  
  
|Type|Description|  
|----------|-----------------|  
|None|Specifies that the client does not need to present any credential. This translates to an anonymous client.|  
|Basic|Basic authentication. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] RFC 2617 – HTTP Authentication: Basic and Digest Authentication, available at [http://go.microsoft.com/fwlink/?LinkId=84023](http://go.microsoft.com/fwlink/?LinkId=84023).|  
|Digest|Digest authentication. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] RFC 2617 – HTTP Authentication: Basic and Digest Authentication, available at [http://go.microsoft.com/fwlink/?LinkId=84023](http://go.microsoft.com/fwlink/?LinkId=84023).|  
|NTLM|NT LAN Manager (NTLM) authentication.|  
|Windows|Windows authentication.|  
|Certificate|Authentication performed using a certificate.|  
|IssuedToken|Allows the service to require that the client be authenticated using a token issued by a security token service or by [!INCLUDE[infocard](../../../../includes/infocard-md.md)]. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).|  
  
### Message Client Credentials in Bindings  
 The following table lists the client credential types available when using a binding in Message security mode.  
  
|Type|Description|  
|----------|-----------------|  
|None|Allows the service to interact with anonymous clients.|  
|Windows|Allows SOAP message exchanges to be made under the authenticated context of a Windows credential.|  
|UserName|Allows the service to require that the client be authenticated using a user name credential. Note that when the security mode is set to `TransportWithMessageCredential`, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support sending a password digest or deriving keys using password and using such keys for Message mode security. As such, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] enforces that the transport is secured when using user name credentials.|  
|Certificate|Allows the service to require that the client be authenticated using a certificate.|  
|IssuedToken|Allows the service to use a security token service to supply a custom token.|  
  
## See Also  
 [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)  
 [Selecting a Credential Type](../../../../docs/framework/wcf/feature-details/selecting-a-credential-type.md)  
 [Security Capabilities with Custom Bindings](../../../../docs/framework/wcf/feature-details/security-capabilities-with-custom-bindings.md)  
 [Security Behaviors](../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Security Model for Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkID=201279&clcid=0x409)
