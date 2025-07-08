---
description: "Learn more about configuring the SQL Workflow Instance Store feature to enable persistence for workflows hosted in WorkflowServiceHost."
title: "How to: Configure Persistence with WorkflowServiceHost"
ms.date: "03/30/2017"
---
# How to: Configure Persistence with WorkflowServiceHost

This article describes how to configure the SQL Workflow Instance Store feature to enable persistence for workflows hosted in <xref:System.ServiceModel.Activities.WorkflowServiceHost> by using a configuration file. Before using the SQL Workflow Instance Store feature, you must create a SQL database that's used to persist workflow instances. For more information, see [How to: Enable SQL Persistence for Workflows and Workflow Services](../../windows-workflow-foundation/how-to-enable-sql-persistence-for-workflows-and-workflow-services.md).

## To Configure the SQL Workflow Instance Store in Configuration

1. The properties of the SQL workflow instance store can be configured through the <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior>, a service behavior that allows you to change the settings through XML configuration. The following configuration example shows how to configure the SQL workflow instance store by using the `<sqlWorkflowInstanceStore>` behavior element in a configuration file.

    ```xml
    <serviceBehaviors>
        <behavior name="">
            <sqlWorkflowInstanceStore
                 connectionString="...;Async=true"
                 instanceEncodingOption="GZip | None"
                 instanceCompletionAction="DeleteAll | DeleteNothing"
                 instanceLockedExceptionAction="NoRetry | SimpleRetry | AggressiveRetry"
                 hostLockRenewalPeriod="00:00:30"
                 runnableInstancesDetectionPeriod="00:00:05">
            </sqlWorkflowInstanceStore>
        </behavior>
    </serviceBehaviors>
    ```

     For more information about how to configure the SQL workflow instance store, see [How to: Enable SQL Persistence for Workflows and Workflow Services](../../windows-workflow-foundation/how-to-enable-sql-persistence-for-workflows-and-workflow-services.md). For more information about the individual settings for the `<sqlWorkflowInstanceStore>` behavior element, see [SQL Workflow Instance Store](../../windows-workflow-foundation/sql-workflow-instance-store.md).

    > [!NOTE]
    > The preceding configuration example uses simplified configuration. For more information, see [Simplified Configuration](../simplified-configuration.md).

## To Configure the SQL Workflow Instance Store in Code

1. The properties of the SQL workflow instance store can be configured through the <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior>, a service behavior that allows you to change the settings through code. The following example shows how to configure the SQL workflow instance store by using the <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior> behavior element in code.

    ```csharp
    host.Description.Behaviors.Add(new SqlWorkflowInstanceStoreBehavior
    {
       ConnectionString = "...;Async=true",
       InstanceEncodingOption = "GZip | None",
       InstanceCompletionAction = "DeleteAll | DeleteNothing",
       InstanceLockedExceptionAction = "NoRetry | SimpleRetry | AggressiveRetry",
       HostLockRenewalPeriod = new TimeSpan(00, 00, 30),
       RunnableInstancesDetectionPeriod = new TimeSpan(00, 00, 05)
    });
    ```

     For more information about how to configure the SQL workflow instance store, see [How to: Enable SQL Persistence for Workflows and Workflow Services](../../windows-workflow-foundation/how-to-enable-sql-persistence-for-workflows-and-workflow-services.md). For more information about the individual settings for the <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior> behavior element, see [SQL Workflow Instance Store](../../windows-workflow-foundation/sql-workflow-instance-store.md).

    > [!NOTE]
    > The preceding configuration example uses simplified configuration. For more information, see [Simplified Configuration](../simplified-configuration.md).

     For an example of how to configure persistence programmatically see [How to: Enable Persistence for Workflows and Workflow Services](../../windows-workflow-foundation/how-to-enable-persistence-for-workflows-and-workflow-services.md).

## See also

- [Workflow Services](workflow-services.md)
- [Workflow Persistence](../../windows-workflow-foundation/workflow-persistence.md)
- [Windows Server App Fabric Persistence](/previous-versions/appfabric/ee677272(v=azure.10))
