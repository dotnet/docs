---
title: "How to: Enable Persistence for Workflows and Services"
description: Learn how to configure SQL Workflow Instance Store to enable persistence for workflows and workflow services programmatically and by using a configuration file.
ms.date: "03/30/2017"
---
# How to: Enable persistence for workflows and workflow services

This article describes how to enable persistence for workflows and workflow services.

## Enable persistence for workflows

You can associate an instance store with a **WorkflowApplication** by using the <xref:System.Activities.WorkflowApplication.InstanceStore%2A> property of the <xref:System.Activities.WorkflowApplication> class. The <xref:System.Activities.WorkflowApplication.Persist%2A> method saves or persists a workflow into the instance store associated with the application. The <xref:System.Activities.WorkflowApplication.Unload%2A> method persists a workflow into the instance store and then unloads the instance from the memory. The **Load** method loads a workflow into memory using the workflow data stored in the instance persistence store.

The **Persist** method performs the following steps:

1. Pauses the workflow scheduler and waits until the workflow enters the idle state.
2. Persists or saves the workflow into the persistence store.
3. Resumes the workflow scheduler.

The **Unload** method performs the following steps:

1. Pauses the workflow scheduler and waits until the workflow enters the idle state.
2. Persists or saves the workflow into the persistence store.
3. Disposes the workflow instance in the memory.

Both the **Persist** and **Unload** methods will block while a workflow is in a no-persist zone until the workflow exits the no-persist zone. The method continues with the persist or unload operation after the no-persist zone completes. If the no-persist zone does not complete before the time-out elapses, or if the persistence process takes too long, a `TimeoutException` will be thrown.

## Enable persistence in code

The **DurableInstancingOptions** member of the <xref:System.ServiceModel.WorkflowServiceHost> class has a property named **InstanceStore** that you can use to associate an instance store with the **WorkflowServiceHost**.

```csharp
// wsh is an instance of WorkflowServiceHost class
wsh.DurableInstancingOptions.InstanceStore = new SqlWorkflowInstanceStore();
```

When the **WorkflowServiceHost** is opened, persistence is automatically enabled if the **DurableInstancingOptions.InstanceStore** is not null.

Typically, a service behavior provides the concrete instance store to be used with a workflow service host by using the **InstanceStore** property. For example, `SqlWorkflowInstanceStoreBehavior` creates an instance of the **SqlWorkflowInstanceStore**, configures it, and assigns it to the **DurableInstancingOptions.InstanceStore**.

## Enable persistence using an application configuration file

Persistence can be enabled using an application configuration file by adding the following code to your app.config or web.config file:

```xml
<configuration>
  <system.serviceModel>
    <behaviors>
      <serviceBehaviors>
        <behavior name="myBehavior">
          <sqlWorkflowInstanceStore connectionString="Data Source=myDatabaseServer;Initial Catalog=myPersistenceDatabase" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>
</configuration>
```

[!INCLUDE [managed-identities](../../includes/managed-identities.md)]
