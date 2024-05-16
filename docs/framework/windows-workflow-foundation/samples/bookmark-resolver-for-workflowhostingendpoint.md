---
description: "Learn more about: Bookmark Resolver for WorkflowHostingEndpoint"
title: "Bookmark Resolver for WorkflowHostingEndpoint"
ms.date: "03/30/2017"
ms.assetid: 97fd5816-935e-4625-ad04-e6f6befa07de
---
# Bookmark Resolver for WorkflowHostingEndpoint

The [CreationEndpoint sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Execution/CreationEndpoint/CS) demonstrates how the <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint> can be used with <xref:System.ServiceModel.Activities.WorkflowServiceHost> to create workflow instances.

## Demonstrates

 <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint>, <xref:System.ServiceModel.Activities.WorkflowServiceHost>

## Discussion

 This sample uses the <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint> to create workflow instances hosted using <xref:System.ServiceModel.Activities.WorkflowServiceHost>. <xref:System.ServiceModel.Activities.WorkflowHostingEndpoint> is an extensibility point for <xref:System.ServiceModel.Activities.WorkflowServiceHost> that can be used in the following scenarios:

- Creating new workflow instances.

- Resuming bookmarks on workflow instance hosted in a <xref:System.ServiceModel.Activities.WorkflowServiceHost>.

 The sample endpoint that is included exposes a contract that provides operations to create a workflow and returns the instance ID or creates an instance with a specific ID. The sample console application creates a <xref:System.ServiceModel.Activities.WorkflowServiceHost> instance with a workflow definition and adds a `CreationEndpoint` to the host. It then calls the `Create` operation on the endpoint to create a new workflow instance.

## Set up, build, and run the sample

1. Build the solution.

2. Run the application. The `CreationEndpoint` console shows a message that includes the instance ID when the workflow instance is created. The message "Hello World!" is printed by the workflow instance.
