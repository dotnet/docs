---
title: "How to: Set the Security Mode"
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
  - "Mode property"
  - "WCF, security mode"
  - "WCF, security"
ms.assetid: 6e01dd9f-b5dd-4474-b24c-06e124de4ff7
caps.latest.revision: 22
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Set the Security Mode
[!INCLUDE[indigo1](../../../includes/indigo1-md.md)] security has three common security modes that are found on most predefined bindings: transport, message, and "transport with message credential." Two additional modes are specific to two bindings: the "transport-credential only" mode found on the <xref:System.ServiceModel.BasicHttpBinding>, and the "Both" mode, found on the <xref:System.ServiceModel.NetMsmqBinding>. However, this topic concentrates on the three common security modes: <xref:System.ServiceModel.SecurityMode.Transport>, <xref:System.ServiceModel.SecurityMode.Message>, and <xref:System.ServiceModel.SecurityMode.TransportWithMessageCredential>.  
  
 Note that not every predefined binding supports all of these modes. This topic sets the mode with the <xref:System.ServiceModel.WSHttpBinding> and <xref:System.ServiceModel.NetTcpBinding> classes and demonstrates how to set the mode both programmatically and through configuration.  
  
 [!INCLUDE[crabout](../../../includes/crdefault-md.md)] [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] security, see [Security Overview](../../../docs/framework/wcf/feature-details/security-overview.md), [Securing Services](../../../docs/framework/wcf/securing-services.md), and [Securing Services and Clients](../../../docs/framework/wcf/feature-details/securing-services-and-clients.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] transport mode and message, see [Transport Security](../../../docs/framework/wcf/feature-details/transport-security.md) and [Message Security](../../../docs/framework/wcf/feature-details/message-security-in-wcf.md).  
  
### To set the security mode in code  
  
1.  Create an instance of the binding class that you are using. For a list of predefined bindings, see [System-Provided Bindings](../../../docs/framework/wcf/system-provided-bindings.md). This example creates an instance of the <xref:System.ServiceModel.WSHttpBinding> class.  
  
2.  Set the `Mode` property of the object returned by the `Security` property.  
  
     [!code-csharp[c_SettingSecurityMode#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#1)]
     [!code-vb[c_SettingSecurityMode#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#1)]  
  
     Alternatively, set the mode to message, as shown in the following code.  
  
     [!code-csharp[c_SettingSecurityMode#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#2)]
     [!code-vb[c_SettingSecurityMode#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#2)]  
  
     Or set the mode to transport with message credentials, as shown in the following code.  
  
     [!code-csharp[c_SettingSecurityMode#3](../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#3)]
     [!code-vb[c_SettingSecurityMode#3](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#3)]  
  
3.  You can also set the mode in the constructor of the binding, as shown in the following code.  
  
     [!code-csharp[c_SettingSecurityMode#4](../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#4)]
     [!code-vb[c_SettingSecurityMode#4](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#4)]  
  
## Setting the ClientCredentialType Property  
 Setting the mode to one of the three values determines how you set the `ClientCredentialType` property. For example, using the <xref:System.ServiceModel.WSHttpBinding> class, setting the mode to `Transport` means you must set the <xref:System.ServiceModel.HttpTransportSecurity.ClientCredentialType%2A> property of the <xref:System.ServiceModel.HttpTransportSecurity> class to an appropriate value.  
  
#### To set the ClientCredentialType property for Transport mode  
  
1.  Create an instance of the binding.  
  
2.  Set the `Mode` property to `Transport`.  
  
3.  Set the `ClientCredential` property to an appropriate value. The following code sets the property to `Windows`.  
  
     [!code-csharp[c_SettingSecurityMode#5](../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#5)]
     [!code-vb[c_SettingSecurityMode#5](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#5)]  
  
#### To set the ClientCredentialType property for Message mode  
  
1.  Create an instance of the binding.  
  
2.  Set the `Mode` property to `Message`.  
  
3.  Set the `ClientCredential` property to an appropriate value. The following code sets the property to `Certificate`.  
  
     [!code-csharp[c_SettingSecurityMode#6](../../../samples/snippets/csharp/VS_Snippets_CFX/c_settingsecuritymode/cs/source.cs#6)]
     [!code-vb[c_SettingSecurityMode#6](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_settingsecuritymode/vb/source.vb#6)]  
  
#### To set the Mode and ClientCredentialType property in configuration  
  
1.  Add an appropriate binding element to the [\<bindings>](../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) element of the configuration file. The following example adds a [\<wsHttpBinding>](../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) element.  
  
2.  Add a `<binding>` element and set its `name` attribute to an appropriate value.  
  
3.  Add a `<security>` element and set the `mode` attribute to `Message`, `Transport`, or `TransportWithMessageCredential`.  
  
4.  If the mode is set to `Transport`, add a `<transport>` element and set the `clientCredential` attribute to an appropriate value.  
  
     The following example sets the mode to "`Transport"`, and then sets the `clientCredentialType` attribute of the `<transport>` element to "`Windows"`.  
  
    ```xml  
    <wsHttpBinding>  
    <binding name="TransportSecurity">  
        <security mode="Transport" />  
           <transport clientCredentialType = "Windows" />  
        </security>  
    </binding>  
    </wsHttpBinding >  
    ```  
  
     Alternatively, set the `security mode` to "`Message"`, followed by a `<"message">` element. This example sets the `clientCredentialType` to "`Certificate"`.  
  
    ```xml  
    <wsHttpBinding>  
    <binding name="MessageSecurity">  
        <security mode="Message" />  
           <message clientCredentialType = "Certificate" />  
        </security>  
    </binding>  
    </wsHttpBinding >  
    ```  
  
     Using the <xref:System.ServiceModel.BasicHttpSecurityMode.TransportWithMessageCredential> value is a special case, and is explained below.  
  
### Using TransportWithMessageCredential  
 When setting the security mode to `TransportWithMessageCredential`, the transport determines the actual mechanism that provides the transport-level security. For example, the HTTP protocol uses Secure Sockets Layer (SSL) over HTTP (HTTPS). Therefore, setting the `ClientCredentialType` property of any transport security object (such as <xref:System.ServiceModel.HttpTransportSecurity>) is ignored.  In other words, you can only set the `ClientCredentialType` of the message security object (for the `WSHttpBinding` binding, the <xref:System.ServiceModel.NonDualMessageSecurityOverHttp> object).  
  
 [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [How to: Use Transport Security and Message Credentials](../../../docs/framework/wcf/feature-details/how-to-use-transport-security-and-message-credentials.md).  
  
## See Also  
 [How to: Configure a Port with an SSL Certificate](../../../docs/framework/wcf/feature-details/how-to-configure-a-port-with-an-ssl-certificate.md)  
 [How to: Use Transport Security and Message Credentials](../../../docs/framework/wcf/feature-details/how-to-use-transport-security-and-message-credentials.md)  
 [Transport Security](../../../docs/framework/wcf/feature-details/transport-security.md)  
 [Message Security](../../../docs/framework/wcf/feature-details/message-security-in-wcf.md)  
 [Security Overview](../../../docs/framework/wcf/feature-details/security-overview.md)  
 [System-Provided Bindings](../../../docs/framework/wcf/system-provided-bindings.md)  
 [\<security>](../../../docs/framework/configure-apps/file-schema/wcf/security-of-wshttpbinding.md)  
 [\<security>](../../../docs/framework/configure-apps/file-schema/wcf/security-of-basichttpbinding.md)  
 [\<security>](../../../docs/framework/configure-apps/file-schema/wcf/security-of-nettcpbinding.md)
