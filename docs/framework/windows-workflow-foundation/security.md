---
title: "Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 737ec121-bfc5-4b75-a504-2d53c2c8af39
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Security
The SQL Workflow Instance Store uses the following database security roles to secure access to instance state information in the persistence database.  
  
-   **System.Activities.DurableInstancing.InstanceStoreUsers**. This role has read and write access to public views and execution rights to stored procedures that are involved in creating, loading and saving instances.  
  
-   **System.Activities.DurableInstancing.InstanceStoreObservers**. This role has read-only access to public views.  
  
-   **System.Activities.DurableInstancing.WorkflowActivationUsers**. This role has execution rights to stored procedures that are involved in the instance activation process. For more information about instance activation, see [Instance Activation](../../../docs/framework/windows-workflow-foundation/instance-activation.md). The user account under which a generic host (such as the Workflow Management Service of [!INCLUDE[dublin](../../../includes/dublin-md.md)]) runs should be added to this database role.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] security for persistence stores with Windows Server App Fabric, see [Security Configuration for Persistence Stores in App Fabric](http://go.microsoft.com/fwlink/?LinkId=201208)  
  
> [!CAUTION]
>  A client that has access to its own instance data in the instance store has access to all other instances in the same instance store. The instance store does not support specifying security permissions at the instance level. You should create separate instance stores and map different groups/users to have access to different stores.
