---
title: "How to: Use Transport Security and Message Credentials"
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
helpviewer_keywords: 
  - "TransportWithMessageCredentials"
ms.assetid: 6cc35346-c37a-4859-b82b-946c0ba6e68f
caps.latest.revision: 11
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Use Transport Security and Message Credentials
Securing a service with both transport and message credentials uses the best of both Transport and Message security modes in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]. In sum, transport-layer security provides integrity and confidentiality, while message-layer security provides a variety of credentials that are not possible with strict transport security mechanisms. This topic shows the basic steps for implementing transport with message credentials using the <xref:System.ServiceModel.WSHttpBinding> and <xref:System.ServiceModel.NetTcpBinding> bindings. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] setting the security mode, see [How to: Set the Security Mode](../../../../docs/framework/wcf/how-to-set-the-security-mode.md).  
  
 When setting the security mode to `TransportWithMessageCredential`, the transport determines the actual mechanism that provides the transport-level security. For HTTP, the mechanism is Secure Sockets Layer (SSL) over HTTP (HTTPS); for TCP, it is SSL over TCP or Windows.  
  
 If the transport is HTTP (using the <xref:System.ServiceModel.WSHttpBinding>), SSL over HTTP provides the transport-level security. In that case, you must configure the computer hosting the service with an SSL certificate bound to a port, as shown later in this topic.  
  
 If the transport is TCP (using the <xref:System.ServiceModel.NetTcpBinding>), by default the transport-level security provided is Windows security, or SSL over TCP. When using SSL over TCP, you must specify the certificate using the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A> method, as shown later in this topic.  
  
### To use the WSHttpBinding with a certificate for transport security (in code)  
  
1.  Use the HttpCfg.exe tool to bind an SSL certificate to a port on the machine. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Configure a Port with an SSL Certificate](../../../../docs/framework/wcf/feature-details/how-to-configure-a-port-with-an-ssl-certificate.md).  
  
2.  Create an instance of the <xref:System.ServiceModel.WSHttpBinding> class and set the <xref:System.ServiceModel.WSHttpSecurity.Mode%2A> property to <xref:System.ServiceModel.SecurityMode.TransportWithMessageCredential>.  
  
3.  Set the <xref:System.ServiceModel.HttpTransportSecurity.ClientCredentialType%2A> property to an appropriate value. ([!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Selecting a Credential Type](../../../../docs/framework/wcf/feature-details/selecting-a-credential-type.md).) The following code uses the <xref:System.ServiceModel.MessageCredentialType.Certificate> value.  
  
4.  Create an instance of the <xref:System.Uri> class with an appropriate base address. Note that the address must use the "HTTPS" scheme and must contain the actual name of the machine and the port number that the SSL certificate is bound to. (Alternatively, you can set the base address in configuration.)  
  
5.  Add a service endpoint using the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> method.  
  
6.  Create the instance of the <xref:System.ServiceModel.ServiceHost> and call the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method, as shown in the following code.  
  
     [!code-csharp[c_SettingSecurityMode#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#7)]
     [!code-vb[c_SettingSecurityMode#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#7)]  
  
### To use the NetTcpBinding with a certificate for transport security (in code)  
  
1.  Create an instance of the <xref:System.ServiceModel.NetTcpBinding> class and set the <xref:System.ServiceModel.NetTcpSecurity.Mode%2A> property to <xref:System.ServiceModel.SecurityMode.TransportWithMessageCredential>.  
  
2.  Set the <xref:System.ServiceModel.MessageSecurityOverTcp.ClientCredentialType%2A> to an appropriate value. The following code uses the <xref:System.ServiceModel.MessageCredentialType.Certificate> value.  
  
3.  Create an instance of the <xref:System.Uri> class with an appropriate base address. Note that the address must use the "net.tcp" scheme. (Alternatively, you can set the base address in configuration.)  
  
4.  Create the instance of the <xref:System.ServiceModel.ServiceHost> class.  
  
5.  Use the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential> class to explicitly set the X.509 certificate for the service.  
  
6.  Add a service endpoint using the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> method.  
  
7.  Call the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method, as shown in the following code.  
  
     [!code-csharp[c_SettingSecurityMode#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#8)]
     [!code-vb[c_SettingSecurityMode#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#8)]  
  
### To use the NetTcpBinding with Windows for transport security (in code)  
  
1.  Create an instance of the <xref:System.ServiceModel.NetTcpBinding> class and set the <xref:System.ServiceModel.NetTcpSecurity.Mode%2A> property to <xref:System.ServiceModel.SecurityMode.TransportWithMessageCredential>.  
  
2.  Set the transport security to use Windows by setting the <xref:System.ServiceModel.TcpTransportSecurity.ClientCredentialType%2A> to <xref:System.ServiceModel.TcpClientCredentialType.Windows>. (Note that this is the default.)  
  
3.  Set the <xref:System.ServiceModel.MessageSecurityOverTcp.ClientCredentialType%2A> to an appropriate value. The following code uses the <xref:System.ServiceModel.MessageCredentialType.Certificate> value.  
  
4.  Create an instance of the <xref:System.Uri> class with an appropriate base address. Note that the address must use the "net.tcp" scheme. (Alternatively, you can set the base address in configuration.)  
  
5.  Create the instance of the <xref:System.ServiceModel.ServiceHost> class.  
  
6.  Use the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential.SetCertificate%2A> method of the <xref:System.ServiceModel.Security.X509CertificateRecipientServiceCredential> class to explicitly set the X.509 certificate for the service.  
  
7.  Add a service endpoint using the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> method.  
  
8.  Call the <xref:System.ServiceModel.ICommunicationObject.Open%2A> method, as shown in the following code.  
  
     [!code-csharp[c_SettingSecurityMode#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#9)]
     [!code-vb[c_SettingSecurityMode#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#9)]  
  
## Using Configuration  
  
#### To use the WSHttpBinding  
  
1.  Configure the computer with an SSL certificate bound to a port. ([!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Configure a Port with an SSL Certificate](../../../../docs/framework/wcf/feature-details/how-to-configure-a-port-with-an-ssl-certificate.md)). You do not need to set a <`transport`> element value with this configuration.  
  
2.  Specify the client credential type for the message-level security. The following example sets the `clientCredentialType` attribute of the <`message`> element to `UserName`.  
  
    ```xml  
    <wsHttpBinding>  
    <binding name="WsHttpBinding_ICalculator">  
            <security mode="TransportWithMessageCredential" >  
               <message clientCredentialType="UserName" />  
            </security>  
    </binding>  
    </wsHttpBinding>  
    ```  
  
#### To use the NetTcpBinding with a certificate for transport security  
  
1.  For SSL over TCP, you must explicitly specify the certificate in the `<behaviors>` element. The following example specifies a certificate by its issuer in the default store location (local machine and personal stores).  
  
    ```xml  
    <behaviors>  
     <serviceBehaviors>  
       <behavior name="mySvcBehavior">  
           <serviceCredentials>  
             <serviceCertificate findValue="contoso.com"  
                                 x509FindType="FindByIssuerName" />  
           </serviceCredentials>  
       </behavior>  
     </serviceBehaviors>  
    </behaviors>  
    ```  
  
2.  Add a [\<netTcpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md) to the bindings section  
  
3.  Add a binding element, and set the `name` attribute to an appropriate value.  
  
4.  Add a <`security`> element, and set the `mode` attribute to `TransportWithMessageCredential`.  
  
5.  Add a <`message>` element, and set the `clientCredentialType` attribute to an appropriate value.  
  
    ```xml  
    <bindings>  
    <netTcpBinding>  
      <binding name="myTcpBinding">  
        <security mode="TransportWithMessageCredential" >  
           <message clientCredentialType="Windows" />  
        </security>  
      </binding>  
    </netTcpBinding>  
    </bindings>  
    ```  
  
#### To use the NetTcpBinding with Windows for transport security  
  
1.  Add a [\<netTcpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/nettcpbinding.md) to the bindings section,  
  
2.  Add a <`binding`> element and set the `name` attribute to an appropriate value.  
  
3.  Add a <`security`> element, and set the `mode` attribute to `TransportWithMessageCredential`.  
  
4.  Add a <`transport`> element and set the `clientCredentialType` attribute to `Windows`.  
  
5.  Add a <`message`> element and set the `clientCredentialType` attribute to an appropriate value. The following code sets the value to a certificate.  
  
    ```xml  
    <bindings>  
    <netTcpBinding>  
      <binding name="myTcpBinding">  
        <security mode="TransportWithMessageCredential" >  
           <transport clientCredentialType="Windows" />  
           <message clientCredentialType="Certificate" />  
        </security>  
      </binding>  
    </netTcpBinding>  
    </bindings>  
    ```  
  
## See Also  
 [How to: Set the Security Mode](../../../../docs/framework/wcf/how-to-set-the-security-mode.md)  
 [Securing Services](../../../../docs/framework/wcf/securing-services.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
