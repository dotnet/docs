---
title: "Workflow Security"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "programming [WF], workflow security"
ms.assetid: d712a566-f435-44c0-b8c0-49298e84b114
---
# Workflow Security
Windows Workflow Foundation (WF) is integrated with several different technologies, such as Microsoft SQL Server and Windows Communication Foundation (WCF). Interacting with these technologies may introduce security issues into your workflow if done improperly.

## Persistence Security Concerns

1.  Workflows that use a <xref:System.Activities.Statements.Delay> activity and persistence need to be reactivated by a service. Windows AppFabric uses the Workflow Management Service (WMS) to reactivate workflows with expired timers. WMS creates a <xref:System.ServiceModel.WorkflowServiceHost> to host the reactivated workflow. If the WMS service is stopped, persisted workflows will not be reactivated when their timers expire.

2.  Access to durable instancing should be protected against malicious entities external to the application domain. In addition, developers should ensure that malicious code can't be executed in the same application domain as the durable instancing code.

3.  Durable instancing should not be run with elevated (Administrator) permissions.

4.  Data being processed outside the application domain should be protected.

5.  Applications that require security isolation should not share the same instance of the schema abstraction. Such applications should use different store providers, or store providers configured to use different store instantiations.

## SQL Server Security Concerns

-   When large numbers of child activities, locations, bookmarks, host extensions, or scopes are used, or when bookmarks with very large payloads are used, memory can be exhausted, or undue amounts of database space can be allocated during persistence. This can be mitigated by using object-level and database-level security.

-   When using <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>, the instance store must be secured. For more information, see [SQL Server Best Practices](https://go.microsoft.com/fwlink/?LinkId=164972).

-   Sensitive data in the instance store should be encrypted. For more information, see [SQL Security Encryption](https://go.microsoft.com/fwlink/?LinkId=164976).

-   Since the database connection string is often included in a configuration file, windows-level security (ACL) should be used to ensure that the configuration file (Web.Config usually) is secure, and that login and password information are not included in the connection string. Windows authentication should be used between the database and the web server instead.

## Considerations for WorkflowServiceHost

-   Windows Communication Foundation (WCF) endpoints used in workflows should be secured. For more information, see [WCF Security Overview](https://go.microsoft.com/fwlink/?LinkID=164975).

-   Host-level authorization can be implemented by using <xref:System.ServiceModel.ServiceAuthorizationManager>. See [How To: Create a Custom Authorization Manager for a Service](https://go.microsoft.com/fwlink/?LinkId=192228) for details.

-   The ServiceSecurityContext for the incoming message is also available from within workflow by accessing OperationContext.

## WF Security Pack CTP
 The Microsoft WF Security Pack CTP 1 is the first community technology preview (CTP) release of a set of activities and their implementation based on [Windows Workflow Foundation](https://msdn.microsoft.com/netframework/aa663328.aspx)in [.NET Framework 4](https://msdn.microsoft.com/netframework/default.aspx) (WF 4) and the [Windows Identity Foundation (WIF)](https://msdn.microsoft.com/security/aa570351.aspx).  The Microsoft WF Security Pack CTP 1 contains both activities and their designers which illustrate how to easily enable various security-related scenarios using workflow, including:

1.  Impersonating a client identity in the workflow

2.  In-workflow authorization, such as PrincipalPermission and validation of Claims

3.  Authenticated messaging using ClientCredentials specified in the workflow, such as username/password or a token retrieved from a Security Token Service (STS)

4.  Flowing a client security token to a back-end service (claims-based delegation) using WS-Trust ActAs

For more information and to download the WF Security Pack CTP, see: [WF Security Pack CTP](https://wf.codeplex.com/releases/view/48114)