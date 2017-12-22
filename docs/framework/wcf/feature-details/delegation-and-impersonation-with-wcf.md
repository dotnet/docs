---
title: "Delegation and Impersonation with WCF"
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
  - "impersonation [WCF]"
  - "delegation [WCF]"
ms.assetid: 110e60f7-5b03-4b69-b667-31721b8e3152
caps.latest.revision: 40
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Delegation and Impersonation with WCF
*Impersonation* is a common technique that services use to restrict client access to a service domain's resources. Service domain resources can either be machine resources, such as local files (impersonation), or a resource on another machine, such as a file share (delegation). For a sample application, see [Impersonating the Client](../../../../docs/framework/wcf/samples/impersonating-the-client.md). For an example of how to use impersonation, see [How to: Impersonate a Client on a Service](../../../../docs/framework/wcf/how-to-impersonate-a-client-on-a-service.md).  
  
> [!IMPORTANT]
>  Be aware that when impersonating a client on a service, the service runs with the client's credentials, which may have higher privileges than the server process.  
  
## Overview  
 Typically, clients call a service to have the service perform some action on the client’s behalf. Impersonation allows the service to act as the client while performing the action. Delegation allows a front-end service to forward the client’s request to a back-end service in such a way that the back-end service can also impersonate the client. Impersonation is most commonly used as a way of checking whether a client is authorized to perform a particular action, while delegation is a way of flowing impersonation capabilities, along with the client’s identity, to a back-end service. Delegation is a Windows domain feature that can be used when Kerberos-based authentication is performed. Delegation is distinct from identity flow and, because delegation transfers the ability to impersonate the client without possession of the client’s password, it is a much higher privileged operation than identity flow.  
  
 Both impersonation and delegation require that the client have a Windows identity. If a client does not possess a Windows identity, then the only option available is to flow the client’s identity to the second service.  
  
## Impersonation Basics  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] supports impersonation for a variety of client credentials. This topic describes service model support for impersonating the caller during the implementation of a service method. Also discussed are common deployment scenarios involving impersonation and SOAP security and [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] options in these scenarios.  
  
 This topic focuses on impersonation and delegation in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] when using SOAP security. You can also use impersonation and delegation with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] when using transport security, as described in [Using Impersonation with Transport Security](../../../../docs/framework/wcf/feature-details/using-impersonation-with-transport-security.md).  
  
## Two Methods  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] SOAP security has two distinct methods for performing impersonation. The method used depends on the binding. One is impersonation from a Windows token obtained from the Security Support Provider Interface (SSPI) or Kerberos authentication, which is then cached on the service. The second is impersonation from a Windows token obtained from the Kerberos extensions, collectively called *Service-for-User* (S4U).  
  
### Cached Token Impersonation  
 You can perform cached-token impersonation with the following:  
  
-   <xref:System.ServiceModel.WSHttpBinding>, <xref:System.ServiceModel.WSDualHttpBinding>, and <xref:System.ServiceModel.NetTcpBinding> with a Windows client credential.  
  
-   <xref:System.ServiceModel.BasicHttpBinding> with a <xref:System.ServiceModel.BasicHttpSecurityMode> set to the <xref:System.ServiceModel.BasicHttpSecurityMode.TransportWithMessageCredential> credential, or any other standard binding where the client presents a user name credential that the service can map to a valid Windows account.  
  
-   Any <xref:System.ServiceModel.Channels.CustomBinding> that uses a Windows client credential with the `requireCancellation` set to `true`. (The property is available on the following classes: <xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters>, <xref:System.ServiceModel.Security.Tokens.SslSecurityTokenParameters>, and <xref:System.ServiceModel.Security.Tokens.SspiSecurityTokenParameters>.) If a secure conversation is used on the binding, it must also have the `requireCancellation` property set to `true`.  
  
-   Any <xref:System.ServiceModel.Channels.CustomBinding> where the client presents a user name credential. If secure conversation is used on the binding, it must also have the `requireCancellation` property set to `true`.  
  
### S4U-Based Impersonation  
 You can perform S4U-based impersonation with the following:  
  
-   <xref:System.ServiceModel.WSHttpBinding>, <xref:System.ServiceModel.WSDualHttpBinding>, and <xref:System.ServiceModel.NetTcpBinding> with a certificate client credential that the service can map to a valid Windows account.  
  
-   Any <xref:System.ServiceModel.Channels.CustomBinding> that uses a Windows client credential with the `requireCancellation` property set to `false`.  
  
-   Any <xref:System.ServiceModel.Channels.CustomBinding> that uses a user name or Windows client credential and secure conversation with the `requireCancellation` property set to `false`.  
  
 The extent to which the service can impersonate the client depends on the privileges the service account holds when it attempts impersonation, the type of impersonation used, and possibly the extent of impersonation the client permits.  
  
> [!NOTE]
>  When the client and service are running on the same computer and the client is running under a system account (for example, `Local System` or `Network Service`), the client cannot be impersonated when a secure session is established with stateful Security Context tokens. A Windows Form or console application typically runs under the currently logged-in account, so that account can be impersonated by default. However, when the client is an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] page and that page is hosted in [!INCLUDE[iis601](../../../../includes/iis601-md.md)] or [!INCLUDE[iisver](../../../../includes/iisver-md.md)], then the client does run under the `Network Service` account by default. All of the system-provided bindings that support secure sessions use a stateless security context token (SCT) by default. However, if the client is an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] page, and secure sessions with stateful SCTs are used, the client cannot be impersonated. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] using stateful SCTs in a secure session, see [How to: Create a Security Context Token for a Secure Session](../../../../docs/framework/wcf/feature-details/how-to-create-a-security-context-token-for-a-secure-session.md).  
  
## Impersonation in a Service Method: Declarative Model  
 Most impersonation scenarios involve executing the service method in the caller context. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides an impersonation feature that makes this easy to do by allowing the user to specify the impersonation requirement in the <xref:System.ServiceModel.OperationBehaviorAttribute> attribute. For example, in the following code, the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure impersonates the caller before executing the `Hello` method. Any attempt to access native resources inside the `Hello` method succeed only if the access control list (ACL) of the resource allows the caller access privileges. To enable impersonation, set the <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A> property to one of the <xref:System.ServiceModel.ImpersonationOption> enumeration values, either <xref:System.ServiceModel.ImpersonationOption.Required?displayProperty=nameWithType> or <xref:System.ServiceModel.ImpersonationOption.Allowed?displayProperty=nameWithType>, as shown in the following example.  
  
> [!NOTE]
>  When a service has higher credentials than the remote client, the credentials of the service are used if the <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A> property is set to <xref:System.ServiceModel.ImpersonationOption.Allowed>. That is, if a low-privileged user provides its credentials, a higher-privileged service executes the method with the credentials of the service, and can use resources that the low-privileged user would otherwise not be able to use.  
  
 [!code-csharp[c_ImpersonationAndDelegation#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_impersonationanddelegation/cs/source.cs#1)]
 [!code-vb[c_ImpersonationAndDelegation#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_impersonationanddelegation/vb/source.vb#1)]  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure can impersonate the caller only if the caller is authenticated with credentials that can be mapped to a Windows user account. If the service is configured to authenticate using a credential that cannot be mapped to a Windows account, the service method is not executed.  
  
> [!NOTE]
>  On [!INCLUDE[wxp](../../../../includes/wxp-md.md)], impersonation fails if a stateful SCT is created, resulting in an <xref:System.InvalidOperationException>. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Unsupported Scenarios](../../../../docs/framework/wcf/feature-details/unsupported-scenarios.md).  
  
## Impersonation in a Service Method: Imperative Model  
 Sometimes a caller does not need to impersonate the entire service method to function, but for only a portion of it. In this case, obtain the Windows identity of the caller inside the service method and imperatively perform the impersonation. Do this by using the <xref:System.ServiceModel.ServiceSecurityContext.WindowsIdentity%2A> property of the <xref:System.ServiceModel.ServiceSecurityContext> to return an instance of the <xref:System.Security.Principal.WindowsIdentity> class and calling the <xref:System.Security.Principal.WindowsIdentity.Impersonate%2A> method before using the instance.  
  
> [!NOTE]
>  Be sure to use the [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)]`Using` statement or the C# `using` statement to automatically revert the impersonation action. If you do not use the statement, or if you use a programming language other than [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or C#, be sure to revert the impersonation level. Failure to do this can form the basis for denial of service and elevation of privilege attacks.  
  
 [!code-csharp[c_ImpersonationAndDelegation#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_impersonationanddelegation/cs/source.cs#2)]
 [!code-vb[c_ImpersonationAndDelegation#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_impersonationanddelegation/vb/source.vb#2)]  
  
## Impersonation for All Service Methods  
 In some cases, you must perform all the methods of a service in the caller’s context. Instead of explicitly enabling this feature on a per-method basis, use the <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior>. As shown in the following code, set the <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior.ImpersonateCallerForAllOperations%2A> property to `true`. The <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior> is retrieved from the collections of behaviors of the <xref:System.ServiceModel.ServiceHost> class. Also note that the `Impersonation` property of the <xref:System.ServiceModel.OperationBehaviorAttribute> applied to each method must also be set to either <xref:System.ServiceModel.ImpersonationOption.Allowed> or <xref:System.ServiceModel.ImpersonationOption.Required>.  
  
 [!code-csharp[c_ImpersonationAndDelegation#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_impersonationanddelegation/cs/source.cs#3)]
 [!code-vb[c_ImpersonationAndDelegation#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_impersonationanddelegation/vb/source.vb#3)]  
  
 The following table describes [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] behavior for all possible combinations of `ImpersonationOption` and `ImpersonateCallerForAllServiceOperations`.  
  
|`ImpersonationOption`|`ImpersonateCallerForAllServiceOperations`|Behavior|  
|---------------------------|------------------------------------------------|--------------|  
|Required|n/a|[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] impersonates the caller|  
|Allowed|false|[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not impersonate the caller|  
|Allowed|true|[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] impersonates the caller|  
|NotAllowed|false|[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not impersonate the caller|  
|NotAllowed|true|Disallowed. (An <xref:System.InvalidOperationException> is thrown.)|  
  
## Impersonation Level Obtained from Windows Credentials and Cached Token Impersonation  
 In some scenarios the client has partial control over the level of impersonation the service performs when a Windows client credential is used. One scenario occurs when the client specifies an Anonymous impersonation level. The other occurs when performing impersonation with a cached token. This is done by setting the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> property of the <xref:System.ServiceModel.Security.WindowsClientCredential> class, which is accessed as a property of the generic <xref:System.ServiceModel.ChannelFactory%601> class.  
  
> [!NOTE]
>  Specifying an impersonation level of Anonymous causes the client to log on to the service anonymously. The service must therefore allow anonymous logons, regardless of whether impersonation is performed.  
  
 The client can specify the impersonation level as <xref:System.Security.Principal.TokenImpersonationLevel.Anonymous>, <xref:System.Security.Principal.TokenImpersonationLevel.Identification>, <xref:System.Security.Principal.TokenImpersonationLevel.Impersonation>, or <xref:System.Security.Principal.TokenImpersonationLevel.Delegation>. Only a token at the specified level is produced, as shown in the following code.  
  
 [!code-csharp[c_ImpersonationAndDelegation#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_impersonationanddelegation/cs/source.cs#4)]
 [!code-vb[c_ImpersonationAndDelegation#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_impersonationanddelegation/vb/source.vb#4)]  
  
 The following table specifies the impersonation level the service obtains when impersonating from a cached token.  
  
|`AllowedImpersonationLevel` value|Service has `SeImpersonatePrivilege`|Service and client are capable of delegation|Cached token `ImpersonationLevel`|  
|---------------------------------------|------------------------------------------|--------------------------------------------------|---------------------------------------|  
|Anonymous|Yes|n/a|Impersonation|  
|Anonymous|No|n/a|Identification|  
|Identification|n/a|n/a|Identification|  
|Impersonation|Yes|n/a|Impersonation|  
|Impersonation|No|n/a|Identification|  
|Delegation|Yes|Yes|Delegation|  
|Delegation|Yes|No|Impersonation|  
|Delegation|No|n/a|Identification|  
  
## Impersonation Level Obtained from User Name Credentials and Cached Token Impersonation  
 By passing the service its user name and password, a client enables [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] to log on as that user, which is equivalent to setting the `AllowedImpersonationLevel` property to <xref:System.Security.Principal.TokenImpersonationLevel.Delegation>. (The `AllowedImpersonationLevel` is available on the <xref:System.ServiceModel.Security.WindowsClientCredential> and <xref:System.ServiceModel.Security.HttpDigestClientCredential> classes.) The following table provides the impersonation level obtained when the service receives user name credentials.  
  
|`AllowedImpersonationLevel`|Service has `SeImpersonatePrivilege`|Service and client are capable of delegation|Cached token `ImpersonationLevel`|  
|---------------------------------|------------------------------------------|--------------------------------------------------|---------------------------------------|  
|n/a|Yes|Yes|Delegation|  
|n/a|Yes|No|Impersonation|  
|n/a|No|n/a|Identification|  
  
## Impersonation Level Obtained from S4U-Based Impersonation  
  
|Service has `SeTcbPrivilege`|Service has `SeImpersonatePrivilege`|Service and client are capable of delegation|Cached token `ImpersonationLevel`|  
|----------------------------------|------------------------------------------|--------------------------------------------------|---------------------------------------|  
|Yes|Yes|n/a|Impersonation|  
|Yes|No|n/a|Identification|  
|No|n/a|n/a|Identification|  
  
## Mapping a Client Certificate to a Windows Account  
 It is possible for a client to authenticate itself to a service using a certificate, and to have the service map the client to an existing account through Active Directory. The following XML shows how to configure the service to map the certificate.  
  
```xml  
<behaviors>  
  <serviceBehaviors>  
    <behavior name="MapToWindowsAccount">  
      <serviceCredentials>  
        <clientCertificate>  
          <authentication mapClientCertificateToWindowsAccount="true" />  
        </clientCertificate>  
      </serviceCredentials>  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
 The following code shows how to configure the service.  
  
```  
// Create a binding that sets a certificate as the client credential type.  
WSHttpBinding b = new WSHttpBinding();  
b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;  
  
// Create a service host that maps the certificate to a Windows account.  
Uri httpUri = new Uri("http://localhost/Calculator");  
ServiceHost sh = new ServiceHost(typeof(HelloService), httpUri);  
sh.Credentials.ClientCertificate.Authentication.MapClientCertificateToWindowsAccount = true;  
```  
  
## Delegation  
 To delegate to a back-end service, a service must perform Kerberos multi-leg (SSPI without NTLM fallback) or Kerberos direct authentication to the back-end service using the client’s Windows identity. To delegate to a back-end service, create a <xref:System.ServiceModel.ChannelFactory%601> and a channel, and then communicate through the channel while impersonating the client. With this form of delegation, the distance at which the back-end service can be located from the front-end service depends on the impersonation level achieved by the front-end service. When the impersonation level is <xref:System.Security.Principal.TokenImpersonationLevel.Impersonation>, the front-end and back-end services must be running on the same machine. When the impersonation level is <xref:System.Security.Principal.TokenImpersonationLevel.Delegation>, the front-end and back-end services can be on separate machines or on the same machine. Enabling delegation-level impersonation requires that Windows domain policy be configured to permit delegation. For more information about configuring Active Directory for delegation support, see [Enabling Delegated Authentication](http://go.microsoft.com/fwlink/?LinkId=99690).  
  
> [!NOTE]
>  When a client authenticates to the front-end service using a user name and password that correspond to a Windows account on the back-end service, the front-end service can authenticate to the back-end service by reusing the client’s user name and password. This is a particularly powerful form of identity flow, because passing user name and password to the back-end service enables the back-end service to perform impersonation, but it does not constitute delegation because Kerberos is not used. Active Directory controls on delegation do not apply to user name and password authentication.  
  
### Delegation Ability as a Function of Impersonation Level  
  
|Impersonation level|Service can perform cross-process delegation|Service can perform cross-machine delegation|  
|-------------------------|---------------------------------------------------|---------------------------------------------------|  
|<xref:System.Security.Principal.TokenImpersonationLevel.Identification>|No|No|  
|<xref:System.Security.Principal.TokenImpersonationLevel.Impersonation>|Yes|No|  
|<xref:System.Security.Principal.TokenImpersonationLevel.Delegation>|Yes|Yes|  
  
 The following code example demonstrates how to use delegation.  
  
 [!code-csharp[c_delegation#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_delegation/cs/source.cs#1)]
 [!code-vb[c_delegation#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_delegation/vb/source.vb#1)]  
  
### How to Configure an Application to Use Constrained Delegation  
 Before you can use constrained delegation, the sender, receiver, and the domain controller must be configured to do so. The following procedure lists the steps that enable constrained delegation. For details about the differences between delegation and constrained delegation, see the portion of [Windows Server 2003 Kerberos Extensions](http://go.microsoft.com/fwlink/?LinkId=100194) that discusses constrained discussion.  
  
1.  On the domain controller, clear the **Account is sensitive and cannot be delegated** check box for the account under which the client application is running.  
  
2.  On the domain controller, select the **Account is trusted for delegation** check box for the account under which the client application is running.  
  
3.  On the domain controller, configure the middle tier computer so that it is trusted for delegation, by clicking the **Trust computer for delegation** option.  
  
4.  On the domain controller, configure the middle tier computer to use constrained delegation, by clicking the **Trust this computer for delegation to specified services only** option.  
  
 For more detailed instructions about configuring constrained delegation, see the following topics on MSDN:  
  
-   [Troubleshooting Kerberos Delegation](http://go.microsoft.com/fwlink/?LinkId=36724)  
  
-   [Kerberos Protocol Transition and Constrained Delegation](http://go.microsoft.com/fwlink/?LinkId=36725)  
  
## See Also  
 <xref:System.ServiceModel.OperationBehaviorAttribute>  
 <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A>  
 <xref:System.ServiceModel.ImpersonationOption>  
 <xref:System.ServiceModel.ServiceSecurityContext.WindowsIdentity%2A>  
 <xref:System.ServiceModel.ServiceSecurityContext>  
 <xref:System.Security.Principal.WindowsIdentity>  
 <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior>  
 <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior.ImpersonateCallerForAllOperations%2A>  
 <xref:System.ServiceModel.ServiceHost>  
 <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A>  
 <xref:System.ServiceModel.Security.WindowsClientCredential>  
 <xref:System.ServiceModel.ChannelFactory%601>  
 <xref:System.Security.Principal.TokenImpersonationLevel.Identification>  
 [Using Impersonation with Transport Security](../../../../docs/framework/wcf/feature-details/using-impersonation-with-transport-security.md)  
 [Impersonating the Client](../../../../docs/framework/wcf/samples/impersonating-the-client.md)  
 [How to: Impersonate a Client on a Service](../../../../docs/framework/wcf/how-to-impersonate-a-client-on-a-service.md)  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
