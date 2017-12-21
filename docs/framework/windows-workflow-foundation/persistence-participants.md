---
title: "Persistence Participants"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f84d2d5d-1c1b-4f19-be45-65b552d3e9e3
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Persistence Participants
A persistence participant can participate in a persistence operation (Save or Load) triggered by an application host. The [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] ships with two abstract classes, **PersistenceParticipant** and **PersistenceIOParticipant**, which you can use to create a persistence participant. A persistence participant derives from one of these classes, implements the methods of interest, and then adds an instance of the class to the <xref:System.ServiceModel.Activities.WorkflowServiceHost.WorkflowExtensions%2A> collection on the <xref:System.ServiceModel.Activities.WorkflowServiceHost> . The application host may look for such workflow extensions when persisting a workflow instance and invoke appropriate methods on the persistence participants at appropriate times.  
  
 The following list describes the tasks performed by the persistence subsystem in different stages of the Persist (Save) operation. The persistence participants are used in the third and fourth stages. If the participant is an IO participant (a persistence participant that also participates in IO operations), the participant is also used in the sixth stage.  
  
1.  Gathers built-in values, including workflow state, bookmarks, mapped variables, and timestamp.  
  
2.  Gathers all persistence participants that were added to the extension collection associated with the workflow instance.  
  
3.  Invokes the <xref:System.Activities.Persistence.PersistenceParticipant.CollectValues%2A> method implemented by all persistence participants.  
  
4.  Invokes the <xref:System.Activities.Persistence.PersistenceParticipant.MapValues%2A> method implemented by all persistence participants.  
  
5.  Persist or save the workflow into the persistence store.  
  
6.  Invokes the <xref:System.Activities.Persistence.PersistenceIOParticipant.BeginOnSave%2A> method on all of the persistence IO participants. If the participant is not an IO participant, this task is skipped. If the persistence episode is transactional, the transaction is provided in Transaction.Current property.  
  
7.  Waits for all persistence participants to complete. If all the participants succeed in persisting instance data, commits the transaction.  
  
 A persistence participant derives from the **PersistenceParticipant** class and may implement the **CollectValues** and **MapValues** methods. A persistence IO participant derives from the **PersistenceIOParticipant** class and may implement the **BeginOnSave** method in addition to implementing the **CollectValues** and **MapValues** methods.  
  
 Each stage is completed before the next stage begins. For example, values are collected from **all** persistence participants in the first stage. Then all the values collected in the first stage are provided to all persistence participants in the second stage for mapping. Then all the values collected and mapped in the first and second stages are provided to the persistence provider in the third stage, and so on.  
  
 The following list describes the tasks performed by the persistence subsystem in different stages of the Load operation. The persistence participants are used in the fourth stage. The persistence IO participants (persistence participants that also participate in IO operations) are also used in the third stage.  
  
1.  Gathers all persistence participants that were added to the extension collection associated with the workflow instance.  
  
2.  Loads the workflow from the persistence store.  
  
3.  Invokes the <xref:System.Activities.Persistence.PersistenceIOParticipant.BeginOnLoad%2A> on all persistence IO participants and waits for all the persistence participants to complete. If the persistence episode is transactional, the transaction is provided in Transaction.Current.  
  
4.  Loads the workflow instance in memory based on the data retrieved from the persistence store.  
  
5.  Invokes <xref:System.Activities.Persistence.PersistenceParticipant.PublishValues%2A> on each persistence participant.  
  
 A persistence participant derives from the **PersistenceParticipant** class and may implement the **PublishValues** method. A persistence IO participant derives from the **PersistenceIOParticipant** class and may implement the **BeginOnLoad** method in addition to implementing the **PublishValues** method.  
  
 When loading a workflow instance the persistence provider creates a lock on that instance. This prevents the instance from being loaded by more than one host in a multi-node scenario. If you attempt to load a workflow instance that has been locked you will see an exception like the following: The exception " System.ServiceModel.Persistence.InstanceLockException: The requested operation could not complete because the lock for instance '00000000-0000-0000-0000-000000000000' could not be acquired". This error is caused when one of the following occurs:  
  
-   In a multi-node scenario the instance is loaded by another host.  There are a few different ways to resolve these types of conflicts: forward the processing to the node which owns the lock and retry, or force the load which will cause the other host to be unable to save their work.  
  
-   In a single-node scenario and the host crashed.  When the host starts up again (a process recycle or creating a new persistence provider factory) the new host attempts to load an instance which is still locked by the old host because the lock hasn't expired yet.  
  
-   In a single-node scenario and the instance in question was aborted at some point and a new persistence provider instance is created which has a different host ID.  
  
 The lock timeout value has a default value of 5 minutes, you can specify a different timeout value when calling <xref:System.ServiceModel.Persistence.PersistenceProvider.Load%2A>.  
  
## In This Section  
  
-   [How to: Create a Custom Persistence Participant](../../../docs/framework/windows-workflow-foundation/how-to-create-a-custom-persistence-participant.md)  
  
## See Also  
 [Store Extensibility](../../../docs/framework/windows-workflow-foundation/store-extensibility.md)
