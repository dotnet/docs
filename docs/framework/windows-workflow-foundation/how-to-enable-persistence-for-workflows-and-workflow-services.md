---
title: "How to: Enable Persistence for Workflows and Workflow Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2b1c8bf3-9866-45a4-b06d-ee562393e503
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Enable Persistence for Workflows and Workflow Services
This topic describes how to enable persistence for workflows and workflow services.  
  
## Enable Persistence for Workflows  
 You can associate an instance store with a **WorkflowApplication** by using the <xref:System.Activities.WorkflowApplication.InstanceStore%2A> property of the <xref:System.Activities.WorkflowApplication> class. The <xref:System.Activities.WorkflowApplication.Persist%2A> method saves or persists a workflow into the instance store associated with the application. The <xref:System.Activities.WorkflowApplication.Unload%2A> method persists a workflow into the instance store and then unloads the instance from the memory. The **Load** method loads a workflow into memory using the workflow data stored in the instance persistence store.  
  
 The **Persist** method performs the following steps:  
  
1.  Pauses the workflow scheduler and waits until the workflow enters the idle state.  
  
2.  Persists or saves the workflow into the persistence store.  
  
3.  Resumes the workflow scheduler.  
  
 The **Unload** method performs the following steps:  
  
1.  Pauses the workflow scheduler and waits until the workflow enters the idle state.  
  
2.  Persists or saves the workflow into the persistence store.  
  
3.  Disposes the workflow instance in the memory.  
  
 Both the **Persist** and **Unload** methods will block while a workflow is in a no-persist zone until the workflow exits the no-persist zone. The method continues with the persist or unload operation after the no-persist zone completes. If the no-persist zone does not complete before the time-out elapses, or if the persistence process takes too long, a TimeoutException will be thrown.  
  
## Enable Persistence for Workflow Services in Code  
 The **DurableInstancingOptions** member of the <xref:System.ServiceModel.WorkflowServiceHost> class has a property named **InstanceStore** that you can use to associate an instance store with the **WorkflowServiceHost**.  
  
```  
// wsh is an instance of WorkflowServiceHost class  
wsh.DurableInstancingOptions.InstanceStore = new SqlWorkflowInstanceStore();  
```  
  
 When the **WorkflowServiceHost** is opened, persistence is automatically enabled if the **DurableInstancingOptions.InstanceStore** is not null.  
  
 Typically, a service behavior provides the concrete instance store to be used with a workflow service host by using the **InstanceStore** property. For example, the SqlWorkflowInstanceStoreBehavior creates an instance of the **SqlWorkflowInstanceStore**, configures it, and assigns it to the **DurableInstancingOptions.InstanceStore**.  
  
## Enable Persistence for Workflow Services Using an Application Configuration File  
 Persistence can be enabled using an application configuration file by adding the following code to your app.config or web.config file:  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="myBehavior">  
          <SqlWorkflowInstanceStore connectionString="Data Source=myDatatbaseServer;Initial Catalog=myPersistenceDatabase">  
        </behavior>  
      </serviceBehaviors>  
    <behaviors>  
  </system.serviceModel>  
</configuration>  
```
