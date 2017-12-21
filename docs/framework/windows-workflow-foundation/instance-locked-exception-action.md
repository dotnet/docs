---
title: "Instance Locked Exception Action"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 164a5419-315c-4987-ad72-54cbdb88d402
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Instance Locked Exception Action
The <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.InstanceLockedExceptionAction%2A> property of the SQL Workflow Instance Store lets you specify what action the SQL persistence provider should take when it receives an <xref:System.Runtime.DurableInstancing.InstanceLockedException>. The persistence provider receives this exception when it tries to lock a workflow service instance that is currently locked by another service host. The values for this property are <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.NoRetry>, <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.BasicRetry>, and <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.AggressiveRetry>. The default value is <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.NoRetry>. The following list describes the three options:  
  
-   <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.NoRetry>. The service host does not attempt to lock the workflow service instance and passes the <xref:System.Runtime.DurableInstancing.InstanceLockedException> to the caller.  If your workflow stays in memory for a period exceeding 60 seconds, use <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.NoRetry> as the retry. The default value is <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.NoRetry>.  
  
-   <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.BasicRetry>. The service host reattempts to lock the workflow service instance with a linear interval between retry attempts and passes the <xref:System.Runtime.DurableInstancing.InstanceLockedException> to the caller at the end of the sequence. If you workflow stays in memory approximately between 5-60 seconds, and messages arrive in batches where it is more likely for messages being sent to the same instance on the same host to process all messages before unloading the workflow, use <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.BasicRetry> to achieve the best latency without wasting resources.  
  
-   <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.AggressiveRetry>. The service host reattempts to lock the workflow service instance with an exponential backoff interval between retry attempts, and passes the exception to the caller at the end of the sequence. If your workflow stays in memory for a very short time (less than 5 seconds), or a Web farm is large and the chance of another message being delivered to the same host is not very high, use <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.AggressiveRetry> to achieve the best latency.  
  
 The Instance Locked Exception Action feature supports the following scenarios. In all scenarios, if the instanceLockedExceptionAction property of the SqlWorkflowInstanceStore is set to <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.BasicRetry> or <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction.AggressiveRetry>, the host transparently retries to acquire the lock on instances periodically.  
  
1.  **Enabling graceful shutdown and overlapped recycling of application domains.** Suppose an **AppDomain** with a service host running workflow service instances is being recycled and a new **AppDomain** is brought up to handle new requests in parallel while the old **AppDomain** is brought down gracefully. The shutdown waits until workflow service instances are idle, and then persists and unloads the instances. Any attempts by hosts in the new **AppDomain** to lock an instance will cause an <xref:System.Runtime.DurableInstancing.InstanceLockedException>.  
  
2.  **Horizontally scaling durable workflows across a homogeneous farm of servers.** Suppose a node of a server farm on which a workflow instance is running crashes and the workflow host cannot remove locks on the instance it is running. When a service host running on another node of the farm receives a message for that workflow instance, it tries to acquire locks on these instances it will receive the <xref:System.Runtime.DurableInstancing.InstanceLockedException>. The locks will expire after some time because the host that was supposed to renew the lock no longer exists.  
  
     **Horizontally scaling durable workflows across a homogeneous farm of servers.**  Suppose you want to horizontally scale a durable workflow using multiple hosts behind a NLB (Network Load Balancer), the workflow host running on one node of the farm loads a workflow instance and is processing a message, and the next message to the instance is routed to the host that is running on another node because the NLB does not have routing algorithm to deliver messages to the host that is already running the instance. Upon receiving the message, the second host attempts to load the workflow instance and receives the <xref:System.Runtime.DurableInstancing.InstanceLockedException> because the first host has a lock on the instance. The first host unlocks the instance when it is finished with processing the first message and the second host acquires the lock when it retries the next time, loads the instance, and processes the second message.
