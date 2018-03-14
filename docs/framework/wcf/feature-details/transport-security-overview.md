---
title: "Transport Security Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 00959326-aa9d-44d0-af61-54933d4adc7f
caps.latest.revision: 23
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Transport Security Overview
Transport security mechanisms in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] depend on the binding and transport being used. For example, when using the <xref:System.ServiceModel.WSHttpBinding> class, the transport is HTTP, and the primary mechanism for securing the transport is Secure Sockets Layer (SSL) over HTTP, commonly called HTTPS. This topic discusses the major transport security mechanisms used in the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] system-provided bindings.  
  
> [!NOTE]
>  When SSL security is used with .NET Framework 3.5 and later an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client uses both the intermediate certificates in its certificate store and the intermediate certificates received during SSL negotiation to perform certificate chain validation on the service's certificate. .NET Framework 3.0 only uses the intermediate certificates installed in the local certificate store.  
  
> [!WARNING]
>  When transport security is used, the <!--zz <xref:System.Treading.Thread.CurrentPrincipal%2A> --> `CurrentPrincipal` property may be overwritten. To prevent this from happening set the <!--zz <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior.PrincipalPermission%2A> --> `PrincipalPermission` to None. <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior> is a service behavior that can be set on the service description.  
  
## BasicHttpBinding  
 By default, the <xref:System.ServiceModel.BasicHttpBinding> class does not provide security. This binding is designed for interoperability with Web service providers that do not implement security. However, you can switch on security by setting the <xref:System.ServiceModel.BasicHttpSecurity.Mode%2A> property to any value except <xref:System.ServiceModel.BasicHttpSecurityMode.None>. To enable transport security, set the property to <xref:System.ServiceModel.BasicHttpSecurityMode.Transport>.  
  
### Interoperation with IIS  
 The <xref:System.ServiceModel.BasicHttpBinding> class is primarily used to interoperate with existing Web services, and many of those services are hosted by Internet Information Services (IIS). Consequently, the transport security for this binding is designed for seamless interoperation with IIS sites. This is done by setting the security mode to <xref:System.ServiceModel.BasicHttpSecurityMode.Transport> and then setting the client credential type. The credential type values correspond to IIS directory security mechanisms. The following code shows the mode being set and the credential type set to Windows. You can use this configuration when both client and server are on the same Windows domain.  
  
 [!code-csharp[c_ProgrammingSecurity#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_programmingsecurity/cs/source.cs#10)] 
 [!code-vb[c_ProgrammingSecurity#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_programmingsecurity/vb/source.vb#10)]  
  
 Or, in configuration:  
  
```xml  
<bindings>  
  <basicHttpBinding>  
    <binding name="SecurityByTransport">  
      <security mode="Transport">  
        <transport clientCredentialType="Windows" />  
       </security>  
     </binding>  
  </basicHttpBinding>  
</bindings>  
```  
  
 The following sections discuss other client credential types.  
  
#### Basic  
 This corresponds to the Basic authentication method in IIS. When using this mode, the IIS server must be configured with Windows user accounts and appropriate NTFS file system permissions. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iis601](../../../../includes/iis601-md.md)], see [Enabling Basic Authentication and Configuring the Realm Name](http://go.microsoft.com/fwlink/?LinkId=88592). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iisver](../../../../includes/iisver-md.md)], see [IIS 7.0 Beta: Configure Basic Authentication](http://go.microsoft.com/fwlink/?LinkId=88593).  
  
#### Certificate  
 IIS has an option to require clients to log on with a certificate. The feature also enables IIS to map a client certificate to a Windows account. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iis601](../../../../includes/iis601-md.md)], see [Enabling Client Certificates in IIS 6.0](http://go.microsoft.com/fwlink/?LinkId=88594). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iisver](../../../../includes/iisver-md.md)], see [IIS 7.0 Beta: Configuring Server Certificates in IIS 7.0](http://go.microsoft.com/fwlink/?LinkId=88595).  
  
#### Digest  
 Digest authentication is similar to Basic authentication, but offers the advantage of sending the credentials as a hash, instead of in clear text. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iis601](../../../../includes/iis601-md.md)], see [Digest Authentication in IIS 6.0](http://go.microsoft.com/fwlink/?LinkID=88443). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iisver](../../../../includes/iisver-md.md)], see [IIS 7.0 Beta: Configure Digest Authentication](http://go.microsoft.com/fwlink/?LinkId=88596).  
  
#### Windows  
 This corresponds to integrated Windows authentication in IIS. When set to this value, the server is also expected to exist on a Windows domain that uses the Kerberos protocol as its domain controller. If the server is not on a Kerberos-backed domain, or if the Kerberos system fails, you can use the NT LAN Manager (NTLM) value described in the next section. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iis601](../../../../includes/iis601-md.md)], see [Integrated Windows Authentication in IIS 6.0](http://go.microsoft.com/fwlink/?LinkId=88597). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[iisver](../../../../includes/iisver-md.md)], see [IIS 7.0 Beta: Configuring Server Certificates in IIS 7.0](http://go.microsoft.com/fwlink/?LinkId=88595).  
  
#### NTLM  
 This enables the server to use NTLM for authentication if the Kerberos protocol fails. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] configuring IIS in [!INCLUDE[iis601](../../../../includes/iis601-md.md)], see [Forcing NTLM Authentication](http://go.microsoft.com/fwlink/?LinkId=88598). For [!INCLUDE[iisver](../../../../includes/iisver-md.md)], the Windows authentication includes NTLM authentication. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [IIS 7.0 Beta: Configuring Server Certificates in IIS 7.0](http://go.microsoft.com/fwlink/?LinkID=88595).  
  
## WsHttpBinding  
 The <xref:System.ServiceModel.WSHttpBinding> class is designed for interoperation with services that implement WS-* specifications. The transport security for this binding is Secure Sockets Layer (SSL) over HTTP, or HTTPS. To create an [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application that uses SSL, use IIS to host the application. Alternatively, if you are creating a self-hosted application, use the HttpCfg.exe tool to bind an X.509 certificate to a specific port on a computer. The port number is specified as part of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application as an endpoint address. When using transport mode, the endpoint address must include the HTTPS protocol or an exception will be thrown at run time. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [HTTP Transport Security](../../../../docs/framework/wcf/feature-details/http-transport-security.md).  
  
 For client authentication, set the <xref:System.ServiceModel.HttpTransportSecurity.ClientCredentialType%2A> property of the <xref:System.ServiceModel.HttpTransportSecurity> class to one of the <xref:System.ServiceModel.HttpClientCredentialType> enumeration values. The enumeration values are identical to the client credential types for <xref:System.ServiceModel.BasicHttpBinding> and are designed to be hosted with IIS services.  
  
 The following example shows the binding being used with a client credential type of Windows.  
  
 [!code-csharp[c_ProgrammingSecurity#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_programmingsecurity/cs/source.cs#11)]
 [!code-vb[c_ProgrammingSecurity#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_programmingsecurity/vb/source.vb#11)]  
  
## WSDualHttpBinding  
 This binding provides only message-level security, not transport-level security.  
  
## NetTcpBinding  
 The <xref:System.ServiceModel.NetTcpBinding> class uses TCP for message transport. Security for the transport mode is provided by implementing Transport Layer Security (TLS) over TCP. The TLS implementation is provided by the operating system.  
  
 You can also specify the client's credential type by setting the <xref:System.ServiceModel.TcpTransportSecurity.ClientCredentialType%2A> property of the <xref:System.ServiceModel.TcpTransportSecurity> class to one of the <xref:System.ServiceModel.TcpClientCredentialType> values, as shown in the following code.  
  
 [!code-csharp[c_ProgrammingSecurity#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_programmingsecurity/cs/source.cs#12)]
 [!code-vb[c_ProgrammingSecurity#12](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_programmingsecurity/vb/source.vb#12)]  
  
#### Client  
 On the client, you must specify a certificate using the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential> class.  
  
> [!NOTE]
>  If you are using Windows security, a certificate is not required.  
  
 The following code uses the thumbprint of the certificate, which uniquely identifies it. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] certificates, see [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md).  
  
 [!code-csharp[c_ProgrammingSecurity#13](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_programmingsecurity/cs/source.cs#13)]
 [!code-vb[c_ProgrammingSecurity#13](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_programmingsecurity/vb/source.vb#13)]  
  
 Alternatively, specify the certificate in the client's configuration using a [\<clientCredentials>](../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md) element in the behaviors section.  
  
```xml  
<behaviors>  
  <behavior>  
   <clientCredentials>  
     <clientCertificate findValue= "101010101010101010101010101010000000000"   
      storeLocation="LocalMachine" storeName="My"   
      X509FindType="FindByThumbPrint"/>  
     </clientCertificate>  
   </clientCredentials>  
 </behavior>  
</behaviors>    
```  
  
## NetNamedPipeBinding  
 The <xref:System.ServiceModel.NetNamedPipeBinding> class is designed for efficient intra-machine communication; that is, for processes running on the same computer, although named pipe channels can be created between two computers on the same network. This binding provides only transport-level security. When creating applications using this binding, the endpoint addresses must include "net.pipe" as the protocol of the endpoint address.  
  
## WSFederationHttpBinding  
 When using transport security, this binding uses SSL over HTTP, known as HTTPS with an issued token (<xref:System.ServiceModel.WSFederationHttpSecurityMode.TransportWithMessageCredential>). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] federation applications, see [Federation and Issued Tokens](../../../../docs/framework/wcf/feature-details/federation-and-issued-tokens.md).  
  
## NetPeerTcpBinding  
 The <xref:System.ServiceModel.NetPeerTcpBinding> class is a secure transport that is designed for efficient communication using the peer-to-peer networking feature. As indicated by the name of the class and binding, TCP is the protocol. When the security mode is set to Transport, the binding implements TLS over TCP. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the peer-to-peer feature, see [Peer-to-Peer Networking](../../../../docs/framework/wcf/feature-details/peer-to-peer-networking.md).  
  
## MsmqIntegrationBinding and NetMsmqBinding  
 For a complete discussion of transport security with Message Queuing (previously called MSMQ), see [Securing Messages Using Transport Security](../../../../docs/framework/wcf/feature-details/securing-messages-using-transport-security.md).  
  
## See Also  
 [Programming WCF Security](../../../../docs/framework/wcf/feature-details/programming-wcf-security.md)
