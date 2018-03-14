---
title: "Support for Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 093c22f5-3294-4642-857a-5252233d6796
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Support for Queries
The SQL Workflow Instance Store records a set of well-known properties in the store. Users can query for instances based on these properties. The following list contains some of these well-known properties:  
  
-   **Site Name.** Name of the Web site that contains the service.  
  
-   **Relative Application Path.** Path of the application relative to the Web site.  
  
-   **Relative Service Path.** Path of the service relative to the application.  
  
-   **Service Name.** Name of the service.  
  
-   **Service Namespace.** Name of the namespace that the service uses.  
  
-   **Current Machine.**  
  
-   **Last Machine**. The computer on which the workflow service instance ran the last time.  
  
> [!NOTE]
>  For self-hosted scenarios using Workflow Service Host, only the last four properties are populated. For Workflow Application scenarios, only the last property is populated.  
  
 The workflow runtime supplies values for the first three properties. The workflow service host supplies the value for the **Suspend Reason** property. The SQL Workflow Instance Store itself supplies values for the **Last Updated Machine** property.  
  
 The SQL Workflow Instance Store feature also lets you specify the custom properties for which you want to store the values in the persistence database and that you want to use in queries. For more information about custom promotions, see [Store Extensibility](../../../docs/framework/windows-workflow-foundation/store-extensibility.md).  
  
## Views  
 The instance store contains the following views. See [Persistence Database Schema](../../../docs/framework/windows-workflow-foundation/persistence-database-schema.md) for further details.  
  
### The Instances View  
 The Instances view contains the following fields:  
  
1.  **Id**  
  
2.  **PendingTimer**  
  
3.  **CreationTime**  
  
4.  **LastUpdatedTime**  
  
5.  **ServiceDeploymentId**  
  
6.  **SuspensionExceptionName**  
  
7.  **SuspensionReason**  
  
8.  **ActiveBookmarks**  
  
9. **CurrentMachine**  
  
10. **LastMachine**  
  
11. **ExecutionStatus**  
  
12. **IsInitialized**  
  
13. **IsSuspended**  
  
14. **IsCompleted**  
  
15. **EncodingOption**  
  
16. **ReadWritePrimitiveDataProperties**  
  
17. **WriteOnlyPrimitiveDataProperties**  
  
18. **ReadWriteComplexDataProperties**  
  
19. **WriteOnlyComplexDataProperties**  
  
### The ServiceDeployments view  
 The ServiceDeployments view contains the following fields:  
  
1.  **SiteName**  
  
2.  **RelativeServicePath**  
  
3.  **RelativeApplicationPath**  
  
4.  **ServiceName**  
  
5.  **ServiceNamespace**  
  
### The InstancePromotedProperties view  
 The InstancePromotedProperties view contains the following fields. For details on promoted properties, see the [Store Extensibility](../../../docs/framework/windows-workflow-foundation/store-extensibility.md) topic.  
  
1.  **InstanceId**  
  
2.  **EncodingOption**  
  
3.  **PromotionName**  
  
4.  **Value#** (a range of fields from **Value1** to **Value64**).
