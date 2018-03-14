---
title: "How to: Impersonate a Client on a Service"
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
  - "WCF, impersonation"
  - "impersonation"
  - "WCF, security"
ms.assetid: 431db851-a75b-4009-9fe2-247243d810d3
caps.latest.revision: 33
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Impersonate a Client on a Service
Impersonating a client on a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service enables the service to perform actions on behalf of the client. For actions subject to access control list (ACL) checks, such as access to directories and files on a machine or access to a SQL Server database, the ACL check is against the client user account. This topic shows the basic steps required to enable a client in a Windows domain to set a client impersonation level. For a working example of this, see [Impersonating the Client](../../../docs/framework/wcf/samples/impersonating-the-client.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] client impersonation, see [Delegation and Impersonation](../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md).  
  
> [!NOTE]
>  When the client and service are running on the same computer and the client is running under a system account (that is, `Local System` or `Network Service`), the client cannot be impersonated when a secure session is established with stateful Security Context tokens. A WinForms or console application typically is run under the currently logged in account, so that account can be impersonated by default. However, when the client is an [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] page and that page is hosted in [!INCLUDE[iis601](../../../includes/iis601-md.md)] or IIS 7.0, then the client does run under the `Network Service` account by default. All of the system-provided bindings that support secure sessions use a stateless Security Context token by default. However, if the client is an [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] page and secure sessions with stateful Security Context tokens are used, the client cannot be impersonated. [!INCLUDE[crabout](../../../includes/crabout-md.md)] using stateful Security Context tokens in a secure session, see [How to: Create a Security Context Token for a Secure Session](../../../docs/framework/wcf/feature-details/how-to-create-a-security-context-token-for-a-secure-session.md).  
  
### To enable impersonation of a client from a cached Windows token on a service  
  
1.  Create the service. For a tutorial of this basic procedure, see [Getting Started Tutorial](../../../docs/framework/wcf/getting-started-tutorial.md).  
  
2.  Use a binding that uses Windows authentication and creates a session, such as <xref:System.ServiceModel.NetTcpBinding> or <xref:System.ServiceModel.WSHttpBinding>.  
  
3.  When creating the implementation of the service's interface, apply the <xref:System.ServiceModel.OperationBehaviorAttribute> class to the method that requires client impersonation. Set the <xref:System.ServiceModel.OperationBehaviorAttribute.Impersonation%2A> property to <xref:System.ServiceModel.ImpersonationOption.Required>.  
  
     [!code-csharp[c_SimpleImpersonation#2](../../../samples/snippets/csharp/VS_Snippets_CFX/c_simpleimpersonation/cs/source.cs#2)]
     [!code-vb[c_SimpleImpersonation#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_simpleimpersonation/vb/source.vb#2)]  
  
### To set the allowed impersonation level on the client  
  
1.  Create service client code by using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Accessing Services Using a WCF Client](../../../docs/framework/wcf/accessing-services-using-a-wcf-client.md).  
  
2.  After creating the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client, set the <xref:System.ServiceModel.Security.WindowsClientCredential.AllowedImpersonationLevel%2A> property of the <xref:System.ServiceModel.Security.WindowsClientCredential> class to one of the <xref:System.Security.Principal.TokenImpersonationLevel> enumeration values.  
  
    > [!NOTE]
    >  To use <xref:System.Security.Principal.TokenImpersonationLevel.Delegation>, negotiated Kerberos authentication (sometimes called *multi-leg* or *multi-step* Kerberos) must be used. For a description of how to implement this, see [Best Practices for Security](../../../docs/framework/wcf/feature-details/best-practices-for-security-in-wcf.md).  
  
     [!code-csharp[c_SimpleImpersonation#1](../../../samples/snippets/csharp/VS_Snippets_CFX/c_simpleimpersonation/cs/source.cs#1)]
     [!code-vb[c_SimpleImpersonation#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_simpleimpersonation/vb/source.vb#1)]  
  
## See Also  
 <xref:System.ServiceModel.OperationBehaviorAttribute>  
 <xref:System.Security.Principal.TokenImpersonationLevel>  
 [Impersonating the Client](../../../docs/framework/wcf/samples/impersonating-the-client.md)  
 [Delegation and Impersonation](../../../docs/framework/wcf/feature-details/delegation-and-impersonation-with-wcf.md)
