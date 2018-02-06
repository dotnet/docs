---
title: "Workflow Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "programming [WF], workflow security"
ms.assetid: d712a566-f435-44c0-b8c0-49298e84b114
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Security
[!INCLUDE[wf](../../../includes/wf-md.md)] is integrated with several different technologies, such as Microsoft SQL Server and [!INCLUDE[indigo1](../../../includes/indigo1-md.md)]. Interacting with these technologies may introduce security issues into your workflow if done improperly.  
  
## Persistence Security Concerns  
  
1.  Workflows that use a <xref:System.Activities.Statements.Delay> activity and persistence need to be reactivated by a service. Windows AppFabric uses the Workflow Management Service (WMS) to reactivate workflows with expired timers. WMS creates a <xref:System.ServiceModel.WorkflowServiceHost> to host the reactivated workflow. If the WMS service is stopped, persisted workflows will not be reactivated when their timers expire.  
  
2.  Access to durable instancing should be protected against malicious entities external to the application domain. In addition, developers should ensure that malicious code can't be executed in the same application domain as the durable instancing code.  
  
3.  Durable instancing should not be run with elevated (Administrator) permissions.  
  
4.  Data being processed outside the application domain should be protected.  
  
5.  Applications that require security isolation should not share the same instance of the schema abstraction. Such applications should use different store providers, or store providers configured to use different store instantiations.  
  
## SQL Server Security Concerns  
  
-   When large numbers of child activities, locations, bookmarks, host extensions, or scopes are used, or when bookmarks with very large payloads are used, memory can be exhausted, or undue amounts of database space can be allocated during persistence. This can be mitigated by using object-level and database-level security.  
  
-   When using <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>, the instance store must be secured. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [SQL Server Best Practices](http://go.microsoft.com/fwlink/?LinkId=164972).  
  
-   Sensitive data in the instance store should be encrypted. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [SQL Security Encryption](http://go.microsoft.com/fwlink/?LinkId=164976).  
  
-   Since the database connection string is often included in a configuration file, windows-level security (ACL) should be used to ensure that the configuration file (Web.Config usually) is secure, and that login and password information are not included in the connection string. Windows authentication should be used between the database and the web server instead.  
  
## Considerations for WorkflowServiceHost  
  
-   [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] endpoints used in workflows should be secured. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [WCF Security Overview](http://go.microsoft.com/fwlink/?LinkID=164975).  
  
-   Host-level authorization can be implemented by using <xref:System.ServiceModel.ServiceAuthorizationManager>. See [How To: Create a Custom Authorization Manager for a Service](http://go.microsoft.com/fwlink/?LinkId=192228) for details. This is also demonstrated in the following sample: [Securing Workflow Services](../../../docs/framework/windows-workflow-foundation/samples/securing-workflow-services.md).  
  
-   The ServiceSecurityContext for the incoming message is also available from within workflow by accessing OperationContext.  See [Accessing OperationContext from a Workflow Service](../../../docs/framework/wcf/feature-details/accessing-operationcontext-from-a-workflow-service.md) for details.  
  
## WF Security Pack CTP  
 The Microsoft WF Security Pack CTP 1 is the first community technology preview (CTP) release of a set of activities and their implementation based on [Windows Workflow Foundation](http://msdn.microsoft.com/netframework/aa663328.aspx)in [.NET Framework 4](http://msdn.microsoft.com/netframework/default.aspx) (WF 4) and the [Windows Identity Foundation (WIF)](http://msdn.microsoft.com/security/aa570351.aspx).  The Microsoft WF Security Pack CTP 1 contains both activities and their designers which illustrate how to easily enable various security-related scenarios using workflow, including:  
  
1.  Impersonating a client identity in the workflow  
  
2.  In-workflow authorization, such as PrincipalPermission and validation of Claims  
  
3.  Authenticated messaging using ClientCredentials specified in the workflow, such as username/password or a token retrieved from a Security Token Service (STS)  
  
4.  Flowing a client security token to a back-end service (claims-based delegation) using WS-Trust ActAs  
  
For more information and to download the WF Security Pack CTP, see: [WF Security Pack CTP](http://wf.codeplex.com/releases/view/48114)