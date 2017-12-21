---
title: "SQL Workflow Instance Store"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8cd2f8a5-4bf8-46ea-8909-c7fdb314fabc
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SQL Workflow Instance Store
The [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] ships with the SQL Workflow Instance Store, which allows workflows to persist state information about workflow instances in a SQL Server 2005 or SQL Server 2008 database. This feature is primarily implemented in the form of the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> class, which derives from the abstract <xref:System.Runtime.DurableInstancing.InstanceStore> class of the persistence framework. The SQL Workflow Instance Store feature constitutes a SQL persistence provider, which is a concrete implementation of the persistence API that a host uses to send persistence commands to the store.  
  
 The SQL Workflow Instance Store supports both self-hosted workflows or workflow services that use <xref:System.Activities.WorkflowApplication> or <xref:System.ServiceModel.WorkflowServiceHost> as well as services hosted in WAS using <xref:System.ServiceModel.WorkflowServiceHost>. You can configure the SQL Workflow Instance Store feature for self-hosted services programmatically by using the object model exposed by the feature. You can configure this feature for services hosted by <xref:System.ServiceModel.WorkflowServiceHost> both programmatically by using the object model and also by using an XML configuration file.  
  
 The SQL Workflow Instance Store feature (**SqlWorkflowInstanceStore** class) does not implement <xref:System.ServiceModel.Persistence.PersistenceProviderFactory> and hence does not offer persistence support for durable non-workflow WCF services. It also does not implement <xref:System.Workflow.Runtime.Hosting.WorkflowPersistenceService> and hence does not offer persistence support for 3.x workflows. The feature supports persistence for only WF 4.0 (and later) workflows and workflow services. The feature also does not support any databases other than SQL Server 2005 and SQL Server 2008.  
  
 The topics in this section describe properties and features of the SQL Workflow Instance Store and provide you with details on configuring the store.  
  
 Windows Server App Fabric provides its own instance store and tooling to simplify the configuration and use of the instance store. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] see [Windows Server App Fabric Instance Store](http://go.microsoft.com/fwlink/?LinkId=201201). [!INCLUDE[crabout](../../../includes/crabout-md.md)] the App Fabric SQL Server Persistence Database see [App Fabric SQL Server Persistence Database](http://go.microsoft.com/fwlink/?LinkId=201202)  
  
## In This Section  
  
-   [Properties of SQL Workflow Instance Store](../../../docs/framework/windows-workflow-foundation/properties-of-sql-workflow-instance-store.md)  
  
-   [How to: Enable SQL Persistence for Workflows and Workflow Services](../../../docs/framework/windows-workflow-foundation/how-to-enable-sql-persistence-for-workflows-and-workflow-services.md)  
  
-   [Instance Activation](../../../docs/framework/windows-workflow-foundation/instance-activation.md)  
  
-   [Support for Queries](../../../docs/framework/windows-workflow-foundation/support-for-queries.md)  
  
-   [Store Extensibility](../../../docs/framework/windows-workflow-foundation/store-extensibility.md)  
  
-   [Security](../../../docs/framework/windows-workflow-foundation/security.md)  
  
-   [SQL Server Persistence Database](../../../docs/framework/windows-workflow-foundation/sql-server-persistence-database.md)  
  
## See Also  
 [Persistence Samples](http://go.microsoft.com/fwlink/?LinkID=177735)
