---
title: "How to: Create a Custom Persistence Participant"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1d9cc47a-8966-4286-94d5-4221403d9c06
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Custom Persistence Participant
The following procedure has steps to create a persistence participant. See the [Participating in Persistence](http://go.microsoft.com/fwlink/?LinkID=177735) sample and [Store Extensibility](../../../docs/framework/windows-workflow-foundation/store-extensibility.md) topic for sample implementations of persistence participants.  
  
1.  Create a class deriving from the <xref:System.Activities.Persistence.PersistenceParticipant> or the <xref:System.Activities.Persistence.PersistenceIOParticipant> class. The PersistenceIOParticipant class offers the same extensibility points as the PersistenceParticipant class in addition to being able to participate in IO operations. Follow one or more of the following steps.  
  
2.  Implement the <xref:System.Activities.Persistence.PersistenceParticipant.CollectValues%2A> method. The **CollectValues** method has two dictionary parameters, one for storing read/write values and the other one for storing write-only values (used later in queries). In this method, you should populate these dictionaries with data that is specific to a persistence participant. Each dictionary contains the name of the value as the key and the value itself as an <xref:System.Runtime.DurableInstancing.InstanceValue> object.  
  
     The values in the readWriteValues dictionary are packaged as **InstanceValue** objects. The values in the write-only dictionary are packaged as **InstanceValue** objects with InstanceValueOptions.Optional and InstanceValueOption.WriteOnly set. Each **InstanceValue** provided by the **CollectValues** implementations across all persistence participants must have a unique name.  
  
    ```  
    protected virtual void CollectValues (out IDictionary<XName,Object> readWriteValues, out IDictionary<XName,Object> writeOnlyValues)  
    ```  
  
3.  Implement the <xref:System.Activities.Persistence.PersistenceParticipant.MapValues%2A> method. The **MapValues** method takes two parameters that are similar to the parameters that the **CollectValues** method receives. All the values collected in the **CollectValues** stage are passed through these dictionary parameters. The new values added by the **MapValues** stage are added to the write-only values.  The write-only dictionary is used to provide data to an external source not directly associated with the instance values. Each value provided by implementations of the **MapValues** method across all persistence participants must have a unique name.  
  
    ```  
    protected virtual IDictionary<XName,Object> MapValues (IDictionary<XName,Object> readWriteValues,IDictionary<XName,Object> writeOnlyValues)  
    ```  
  
     The <xref:System.Activities.Persistence.PersistenceParticipant.MapValues%2A> method provides functionality that <xref:System.Activities.Persistence.PersistenceParticipant.CollectValues%2A> does not, in that it allows for a dependency on another value provided by another persistence participant that hasn’t been processed by <xref:System.Activities.Persistence.PersistenceParticipant.CollectValues%2A> yet.  
  
4.  Implement the **PublishValues** method. The **PublishValues** method receives a dictionary containing all the values loaded from the persistence store.  
  
    ```  
    protected virtual void PublishValues (IDictionary<XName,Object> readWriteValues)  
    ```  
  
5.  Implement the **BeginOnSave** method if the participant is a persistence IO participant. This method is called during a Save operation. In this method, you should perform IO adjunct to the persisting (saving) workflow instances.  If the host is using a transaction for the corresponding persistence command, the same transaction is provided in Transaction.Current.  Additionally, PersistenceIOParticipants may advertise a transactional consistency requirement, in which case the host creates a transaction for the persistence episode if one would not otherwise be used.  
  
    ```  
    protected virtual IAsyncResult BeginOnSave (IDictionary<XName,Object> readWriteValues, IDictionary<XName,Object> writeOnlyValues, TimeSpan timeout, AsyncCallback callback, Object state)  
    ```  
  
6.  Implement the **BeginOnLoad** method if the participant is a persistence IO participant. This method is called during a Load operation. In this method, you should perform IO adjunct to the loading of workflow instances. If the host is using a transaction for the corresponding persistence command, the same transaction is provided in Transaction.Current. Additionally, Persistence IO participants may advertise a transactional consistency requirement, in which case the host creates a transaction for the persistence episode if one would not otherwise be used.  
  
    ```  
    protected virtual IAsyncResult BeginOnLoad (IDictionary<XName,Object> readWriteValues, TimeSpan timeout, AsyncCallback callback, Object state)  
    ```
