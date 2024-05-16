---
description: "Learn more about: Accessing OperationContext"
title: "Accessing OperationContext"
ms.date: "03/30/2017"
ms.assetid: 4e92efe8-7e79-41f3-b50e-bdc38b9f41f8
---
# Accessing OperationContext

The [AccessingOperationContext sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/Services/AccessingOperationContext/CS) demonstrates how the messaging activities (<xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.Send>) can be used with a custom scope activity to access <xref:System.ServiceModel.OperationContext.Current%2A> and attach or retrieve a custom message header within an outgoing or incoming message.

## Demonstrates

 Messaging Activities, <xref:System.ServiceModel.Activities.ISendMessageCallback>, <xref:System.ServiceModel.Activities.IReceiveMessageCallback>.

## Discussion

 This sample shows how to use extensibility points (<xref:System.ServiceModel.Activities.ISendMessageCallback>) <xref:System.ServiceModel.Activities.IReceiveMessageCallback>) in the messaging activities to access <xref:System.ServiceModel.OperationContext.Current%2A>. The callbacks are registered within the workflow runtime as an implementation of <xref:System.Activities.IExecutionProperty> that is picked up by the messaging activities upon execution. Any messaging activity in the same scope as that <xref:System.Activities.IExecutionProperty> implementation is affected. In particular, this sample uses a custom scope activity to enforce the callback behavior. The <xref:System.ServiceModel.Activities.ISendMessageCallback> is used in the client workflow to include the workflow's <xref:System.Activities.WorkflowApplication.Id%2A> as an outgoing <xref:System.ServiceModel.Channels.MessageHeader>. This header is then picked up in the service using the <xref:System.ServiceModel.Activities.IReceiveMessageCallback> and the value of the header is printed out to the console.

## Set up, build, and run the sample

1. This sample exposes a workflow service using HTTP endpoints. To run this sample, proper URL ACLs must be added (see [Configuring HTTP and HTTPS](../../wcf/feature-details/configuring-http-and-https.md) for details), either by running Visual Studio as Administrator or by executing the following command at an elevated prompt to add the appropriate ACLs. Ensure that your Domain and Username are substituted.

    ```console
    netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%
    ```

2. Once the URL ACLs are added, use the following steps.

    1. Build the solution.

    2. Set multiple start-up projects by right-clicking the solution and selecting **Set Startup Projects**.

    3. Add **Service** and **Client** (in that order) as multiple start-up projects.

    4. Run the application. The client console shows a workflow running twice and the Service window shows the instance ID of those workflows.
