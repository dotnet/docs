---
description: "Learn more about: Suspended Instance Management"
title: "Suspended Instance Management"
ms.date: "03/30/2017"
ms.assetid: f5ca3faa-ba1f-4857-b92c-d927e4b29598
---
# Suspended Instance Management

The [SuspendedInstanceManagement sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/application/SuspendedInstanceManagement/CS) demonstrates how to manage workflow instances that have been suspended.  The default action for <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> is `AbandonAndSuspend`. This means that by default, unhandled exceptions thrown from a workflow instance hosted in the <xref:System.ServiceModel.WorkflowServiceHost> will cause the instance to be disposed from memory (abandoned) and the durable/persisted version of the instance to be marked as suspended. A suspended workflow instance will not be able to run until it has been unsuspended.

 The sample shows how a command-line utility can be implemented to query for suspended instances, and how to give the user the option to resume or terminate the instance. In this sample, a workflow service intentionally throws an exception, causing it to become suspended. The command-line utility can then be used to query for the instance and subsequently resume or terminate the instance.

## Demonstrates

 <xref:System.ServiceModel.WorkflowServiceHost> with <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> and <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> in Windows Workflow Foundation (WF).

## Discussion

 The command-line utility implemented in this sample is specific to the SQL instance store implementation that ships in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)]. If you have a custom implementation of the instance store, then you can adapt this utility by replacing the `WorkflowInstanceCommand` implementations in the sample with implementations that are specific to your instance store.

 The provided implementation runs SQL commands against the SQL instance store directly to list suspended instances, and it relies on a <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> added to the <xref:System.ServiceModel.WorkflowServiceHost> in order to resume or terminate the instances.

## To set up, build, and run the sample

1. This sample requires that the following Windows components are enabled:

    1. Microsoft Message Queues (MSMQ) Server

    2. SQL Server Express

2. Set up the SQL Server database.

    1. From a Visual Studio command prompt, run "setup.cmd" from the SuspendedInstanceManagement sample directory, which does the following:

        1. Creates a persistence database using SQL Server Express. If the persistence database already exists, then it is dropped and re-created

        2. Sets up the database for persistence.

        3. Adds IIS APPPOOL\DefaultAppPool and NT AUTHORITY\Network Service to the InstanceStoreUsers role that was defined when setting up the database for persistence.

3. Set up the service queue.

    1. In Visual Studio, right-click the **SampleWorkflowApp** project and click **Set as Startup Project**.

    2. Compile and run the SampleWorkflowApp by pressing **F5**. This will create the required queue.

    3. Press **Enter** to stop the SampleWorkflowApp.

    4. Open the Computer Management console by running Compmgmt.msc from a command prompt.

    5. Expand **Service and Applications**, **Message Queuing**, **Private Queues**.

    6. Right click the **ReceiveTx** queue and select **Properties**.

    7. Select the **Security** tab and allow **Everyone** to have permissions to **Receive Message**, **Peek Message**, and **Send Message**.

4. Now, run the sample.

    1. In Visual Studio, run the SampleWorkflowApp project again without debugging by pressing **Ctrl+F5**. Two endpoint addresses will be printed in the console window: one for the application endpoint and then other from the <xref:System.ServiceModel.Activities.WorkflowControlEndpoint>. A workflow instance is then created, and tracking records for that instance will appear in the console window. The workflow instance will throw an exception causing the instance to be suspended and aborted.

    2. The command-line utility can then be used to take further action on any of these instances. The syntax for command line arguments is as follows::

         `SuspendedInstanceManagement -Command:[CommandName] -Server:[ServerName] -Database:[DatabaseName] -InstanceId:[InstanceId]`

         The supported commands are: `Query`, `Resume`, and `Terminate`.  The InstanceId switch is only required for `Resume` and `Terminate` operations.

## To cleanup (Optional)

1. Open the Computer Management console by running Compmgmt.msc.

2. Expand **Service and Applications**, **Message Queuing**, **Private Queues**.

3. Delete the **ReceiveTx** queue.

4. To remove the persistence database, run cleanup.cmd.
