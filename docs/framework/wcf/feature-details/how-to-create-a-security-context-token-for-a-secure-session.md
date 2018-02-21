---
title: "How to: Create a Security Context Token for a Secure Session"
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
ms.assetid: 640676b6-c75a-4ff7-aea4-b1a1524d71b2
caps.latest.revision: 14
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Create a Security Context Token for a Secure Session
By using a stateful security context token (SCT) in a secure session, the session can withstand the service being recycled. For instance, when a stateless SCT is used in a secure session and Internet Information Services (IIS) is reset, then the session data that is associated with the service is lost. This session data includes an SCT token cache. So, the next time a client sends the service a stateless SCT, an error is returned, because the key that is associated with the SCT cannot be retrieved. If, however, a stateful SCT is used, then the key that is associated with the SCT is contained within the SCT. Because the key is contained within the SCT and thus contained within the message, the secure session is not affected by the service being recycled. By default, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] uses stateless SCTs in a secure session. This topic details how to use stateful SCTs in a secure session.  
  
> [!NOTE]
>  Stateful SCTs cannot be used in a secure session that involves a contract that derives from <xref:System.ServiceModel.Channels.IDuplexChannel>.  
  
> [!NOTE]
>  For applications that use stateful SCTs in a secure session, the thread identity for the service must be a user account that has an associated user profile. When the service is run under an account that does not have a user profile, such as `Local Service`, an exception may be thrown.  
  
> [!NOTE]
>  When impersonation is required on Windows XP, use a secure session without a stateful SCT. When stateful SCTs are used with impersonation, an <xref:System.InvalidOperationException> is thrown. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Unsupported Scenarios](../../../../docs/framework/wcf/feature-details/unsupported-scenarios.md).  
  
### To use stateful SCTs in a secure session  
  
-   Create a custom binding that specifies that SOAP messages are protected by a secure session that uses a stateful SCT.  
  
    1.  Define a custom binding, by adding a [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md) to the configuration file for the service.  
  
        ```xml  
        <customBinding>  
        ```  
  
    2.  Add a [\<binding>](../../../../docs/framework/misc/binding.md) child element to the [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md).  
  
         Specify a binding name by setting the `name` attribute to a unique name within the configuration file.  
  
        ```xml  
        <binding name="StatefulSCTSecureSession">  
        ```  
  
    3.  Specify the authentication mode for messages sent to and from this service by adding a [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md) child element to the [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md).  
  
         Specify that a secure session is used by setting the `authenticationMode` attribute to `SecureConversation`. Specify that stateful SCTs are used by setting the `requireSecurityContextCancellation` attribute to `false`.  
  
        ```xml  
        <security authenticationMode="SecureConversation"  
                  requireSecurityContextCancellation="false">  
        ```  
  
    4.  Specify how the client is authenticated while the secure session is established by adding a [\<secureConversationBootstrap>](../../../../docs/framework/configure-apps/file-schema/wcf/secureconversationbootstrap.md) child element to the [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md).  
  
         Specify how the client is authenticated by setting the `authenticationMode` attribute.  
  
        ```xml  
        <secureConversationBootstrap authenticationMode="UserNameForCertificate" />  
        ```  
  
    5.  Specify the message encoding by adding an encoding element, such as [\<textMessageEncoding>](../../../../docs/framework/configure-apps/file-schema/wcf/textmessageencoding.md).  
  
        ```xml  
        <textMessageEncoding />  
        ```  
  
    6.  Specify the transport by adding a transport element, such as the [\<httpTransport>](../../../../docs/framework/configure-apps/file-schema/wcf/httptransport.md).  
  
        ```xml  
        <httpTransport />  
        ```  
  
     The following code example uses configuration to specify a custom binding that messages can use with stateful SCTs in a secure session.  
  
    ```xml  
    <customBinding>  
      <binding name="StatefulSCTSecureSession">  
        <security authenticationMode="SecureConversation"  
                  requireSecurityContextCancellation="false">  
          <secureConversationBootstrap authenticationMode="UserNameForCertificate" />  
        </security>  
        <textMessageEncoding />  
        <httpTransport />  
      </binding>  
    </customBinding>  
    ```  
  
## Example  
 The following code example creates a custom binding that uses the <xref:System.ServiceModel.Configuration.AuthenticationMode.MutualCertificate> authentication mode to bootstrap a secure session.  
  
 [!code-csharp[c_CreateStatefulSCT#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_createstatefulsct/cs/secureservice.cs#2)]
 [!code-vb[c_CreateStatefulSCT#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_createstatefulsct/vb/secureservice.vb#2)]  
  
 When Windows authentication is used in combination with a stateful SCT, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not populate the <xref:System.ServiceModel.ServiceSecurityContext.WindowsIdentity%2A> property with the actual caller's identity but instead sets the property to anonymous. Because [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security must re-create the content of the service security context for every request from the incoming SCT, the server does not keep track of the security session in the memory. Because it is impossible to serialize the <xref:System.Security.Principal.WindowsIdentity> instance into the SCT, the <xref:System.ServiceModel.ServiceSecurityContext.WindowsIdentity%2A> property returns an anonymous identity.  
  
 The following configuration exhibits this behavior.  
  
```xml  
<customBinding>  
  <binding name="Cancellation">  
       <textMessageEncoding />  
        <security   
            requireSecurityContextCancellation="false">  
              <secureConversationBootstrap />  
      </security>  
    <httpTransport />  
  </binding>  
</customBinding>  
```  
  
## See Also  
 [\<customBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/custombinding.md)
