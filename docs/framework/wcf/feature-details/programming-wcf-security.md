---
title: "Programming WCF Security"
description: Learn how to create a secure WCF application, including authentication, confidentiality, and integrity. 
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "message security [WCF], programming overview"
ms.assetid: 739ec222-4eda-4cc9-a470-67e64a7a3f10
---
# Programming WCF Security

This topic describes the fundamental programming tasks used to create a secure Windows Communication Foundation (WCF) application. This topic covers only authentication, confidentiality, and integrity, collectively known as *transfer security*. This topic does not cover authorization (the control of access to resources or services); for information on authorization, see [Authorization](authorization-in-wcf.md).  
  
> [!NOTE]
> For a valuable introduction to security concepts, especially in regard to WCF, see the set of patterns and practices tutorials on MSDN at [Scenarios, Patterns, and Implementation Guidance for Web Services Enhancements (WSE) 3.0](/previous-versions/msp-n-p/ff648183(v=pandp.10)).  
  
 Programming WCF security is based on three steps setting the following: the security mode, a client credential type, and the credential values. You can perform these steps either through code or configuration.  
  
## Setting the Security Mode  

 The following explains the general steps for programming with the security mode in WCF:  
  
1. Select one of the predefined bindings appropriate to your application requirements. For a list of the binding choices, see [System-Provided Bindings](../system-provided-bindings.md). By default, nearly every binding has security enabled. The one exception is the <xref:System.ServiceModel.BasicHttpBinding> class (using configuration, the [\<basicHttpBinding>](../../configure-apps/file-schema/wcf/basichttpbinding.md)).  
  
     The binding you select determines the transport. For example, <xref:System.ServiceModel.WSHttpBinding> uses HTTP as the transport; <xref:System.ServiceModel.NetTcpBinding> uses TCP.  
  
2. Select one of the security modes for the binding. Note that the binding you select determines the available mode choices. For example, the <xref:System.ServiceModel.WSDualHttpBinding> does not allow transport security (it is not an option). Similarly, neither the <xref:System.ServiceModel.MsmqIntegration.MsmqIntegrationBinding> nor the <xref:System.ServiceModel.NetNamedPipeBinding> allows message security.  
  
     You have three choices:  
  
    1. `Transport`  
  
         Transport security depends on the mechanism that the binding you have selected uses. For example, if you are using `WSHttpBinding` then the security mechanism is Secure Sockets Layer (SSL) (also the mechanism for the HTTPS protocol). Generally speaking, the main advantage of transport security is that it delivers good throughput no matter which transport you are using. However, it does have two limitations: The first is that the transport mechanism dictates the credential type used to authenticate a user. This is a drawback only if a service needs to interoperate with other services that demand different types of credentials. The second is that, because the security is not applied at the message level, security is implemented in a hop-by-hop manner rather than end-to-end. This latter limitation is an issue only if the message path between client and service includes intermediaries. For more information about which transport to use, see [Choosing a Transport](choosing-a-transport.md). For more information about using transport security, see [Transport Security Overview](transport-security-overview.md).  
  
    2. `Message`  
  
         Message security means that every message includes the necessary headers and data to keep the message secure. Because the composition of the headers varies, you can include any number of credentials. This becomes a factor if you are interoperating with other services that demand a specific credential type that a transport mechanism can't supply, or if the message must be used with more than one service, where each service demands a different credential type.  
  
         For more information, see [Message Security](message-security-in-wcf.md).  
  
    3. `TransportWithMessageCredential`  
  
         This choice uses the transport layer to secure the message transfer, while every message includes the rich credentials other services need. This combines the performance advantage of transport security with the rich credentials advantage of message security. This is available with the following bindings: <xref:System.ServiceModel.BasicHttpBinding>, <xref:System.ServiceModel.WSFederationHttpBinding>, <xref:System.ServiceModel.NetPeerTcpBinding>, and <xref:System.ServiceModel.WSHttpBinding>.  
  
3. If you decide to use transport security for HTTP (in other words, HTTPS), you must also configure the host with an SSL certificate and enable SSL on a port. For more information, see [HTTP Transport Security](http-transport-security.md).  
  
4. If you are using the <xref:System.ServiceModel.WSHttpBinding> and do not need to establish a secure session, set the <xref:System.ServiceModel.NonDualMessageSecurityOverHttp.EstablishSecurityContext%2A> property to `false`.  
  
     A secure session occurs when a client and service create a channel using a symmetric key (both client and server use the same key for the length of a conversation, until the dialog is closed).  
  
## Setting the Client Credential Type  

 Select a client credential type as appropriate. For more information, see [Selecting a Credential Type](selecting-a-credential-type.md). The following client credential types are available:  
  
- `Windows`  
  
- `Certificate`  
  
- `Digest`  
  
- `Basic`  
  
- `UserName`  
  
- `NTLM`  
  
- `IssuedToken`  
  
 Depending on how you set the mode, you must set the credential type. For example, if you have selected the `wsHttpBinding`, and have set the mode to "Message," then you can also set the `clientCredentialType` attribute of the Message element to one of the following values: `None`, `Windows`, `UserName`, `Certificate`, and `IssuedToken`, as shown in the following configuration example.  
  
```xml  
<system.serviceModel>  
<bindings>  
  <wsHttpBinding>  
    <binding name="myBinding">  
      <security mode="Message"/>  
      <message clientCredentialType="Windows"/>  
    </binding>
  </wsHttpBinding>
</bindings>  
</system.serviceModel>  
```  
  
 Or in code:  
  
 [!code-csharp[c_WsHttpService#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_wshttpservice/cs/source.cs#1)]
 [!code-vb[c_WsHttpService#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_wshttpservice/vb/source.vb#1)]  
  
## Setting Service Credential Values  

 Once you select a client credential type, you must set the actual credentials for the service and client to use. On the service, credentials are set using the <xref:System.ServiceModel.Description.ServiceCredentials> class and returned by the <xref:System.ServiceModel.ServiceHostBase.Credentials%2A> property of the <xref:System.ServiceModel.ServiceHostBase> class. The binding in use implies the service credential type, the security mode chosen, and the type of the client credential. The following code sets a certificate for a service credential.  
  
 [!code-csharp[c_tcpService#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_tcpservice/cs/source.cs#3)]
 [!code-vb[c_tcpService#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_tcpservice/vb/source.vb#3)]  
  
## Setting Client Credential Values  

 On the client, set client credential values using the <xref:System.ServiceModel.Description.ClientCredentials> class and returned by the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property of the <xref:System.ServiceModel.ClientBase%601> class. The following code sets a certificate as a credential on a client using the TCP protocol.  
  
 [!code-csharp[c_TcpClient#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_tcpclient/cs/source.cs#1)]
 [!code-vb[c_TcpClient#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_tcpclient/vb/source.vb#1)]  
  
## See also

- [Basic WCF Programming](../basic-wcf-programming.md)
- [Common Security Scenarios](common-security-scenarios.md)
