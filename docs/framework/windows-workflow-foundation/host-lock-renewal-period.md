---
title: "Host Lock Renewal Period"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f8ba94fc-27e0-4d8e-8f85-50a6d2a3cd43
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Host Lock Renewal Period
The **Host Lock Renewal Period** property of the SQL Workflow Instance Store lets you specify the time period within which the host renews its lock on a workflow instance. The lock remains valid for Host Lock Renewal Period + 30 seconds. If the host fails to renew the lock (in other words, extend the lease) within this time period, the lock expires and the persistence provider unlocks the instance. The value for this property is of type TimeSpan of the form "hh:mm:ss". The minimum permitted value is "00:00:01" (1 second). The default value of this property is "00:00:30" (30 seconds).  
  
 This property is significant in scenarios where a workflow service host fails before it can unlock a workflow service instance that it owns. In this scenario, the lock on the workflow service instance in the persistence database is removed by the persistence provider after the lock expires so that another workflow service host running on the same computer or another computer in a server farm can acquire the lock and load the workflow service instance into memory to resume its execution from its last persisted state.  
  
 Setting a higher value for this property causes the workflow service instances to be locked in the persistence database for a longer time and therefore delays the recovery of the instance from the last persistence point. Setting a short interval for this property causes the new instance of the workflow service host to pick up the failed workflow service instance quickly, but causes an increase in workload for the workflow service host and the SQL Server database.  
  
 The SQL Workflow Instance Store runs an internal task that periodically wakes up and detects instances with expired locks on them. When it finds instances with expired locks, it places the instances in the RunnableInstances table so that a workflow host can pick up and run these instances.
