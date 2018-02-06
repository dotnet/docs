---
title: "Runnable Instances Detection Period"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4ea5c787-b638-47fd-bfc8-ede8c2898ce6
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runnable Instances Detection Period
The SQL Workflow Instance Store runs an internal task that periodically wakes up and detects runnable or activatable instances in the persistence database. The **Runnable Instances Detection Period** property of the SQL Workflow Instance Store specifies the time period after which the SQL Workflow Instance Store runs a detection task to detect any runnable or activatable workflow instances in the persistence database after the previous detection cycle.  
  
 Setting a shorter interval for this property reduces the time between the expiration of a timer associated with a workflow instance and the signaling of the event and subsequent loading of the instance. However, it also increases the processing load on a host and may not be desirable in scenarios where durable timers and/or host failures are rare. The type of the property is TimeSpan and the value of the property follows the format: hh:mm:ss. The minimum value for this property is 00:00:01. The default value for the property is 00:00:05.  
  
 For more information detecting and activating runnable and activatable workflow instances, see [Instance Activation](../../../docs/framework/windows-workflow-foundation/instance-activation.md).
