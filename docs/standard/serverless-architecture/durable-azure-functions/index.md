---
title: Serverless apps. Architecture, patterns, and Azure implementation.
description: Serverless apps. Architecture, patterns, and Azure implementation. | Durable Azure functions
keywords: Serverless, Microservices, .NET, Azure, Azure Functions
author: cecilphillip
ms.author: cephilli
ms.date: 12/21/2017
ms.prod: .net
ms.technology: dotnet
ms.service: functions
ms.topic: article
---
# Durable Azure functions

When creating serverless applications with Azure Functions, your operations will typically be designed to run in a stateless manner. This is because as the platform scales your serverless application, it becomes difficult to know what servers the code is running on or even how many instances are active at any given point. However, there are classes of applications that require the current state of a process to be known. Take into consideration the process of submitting an order via an online store. The checkout operation might be a workflow that is comprised of multiple operations which need to know the state of product inventory, if the customer has any credits on their account, and also the results of processing the credit card. These mentioned operations could easily be their own internal workflows or even services from an third-party systems.

Various patterns exist today that assist with the coordiation of application state between internal and external systems. It is common to come across solutions that rely on centralized queing systems, distributed key-value stores or shared databases to manage that state. However, these are all additional resources that now need to be provisioned and managed. In a serverless environment, your code could become very cumbersome trying to coordinate with these resources manually. Azure Functions offers an alternative for creating stateful functions called Durable Functions.

Durable Functions is an extension to the Azure Functions runtime that enables the definition of stateful workflows in code. By breaking down workflows into activities, the Durable Functions extension is able to manage state, create progress checkpoints, and handle the distribution of function calls across servers. In the background, it makes use of an Azure Storage account to persist execution history, schedule activity functions and retrieve responses. Your serverless code should never interact with persisted information in that storage account, and is typically not something developers need to interact with.

## Triggering a stateful workflow
Stateful workflows in Durable Functions can be broken down into two intrinsic components; orchestration and activiy triggers. Triggers and bindings are core components used by Azure Functions to enable your serverless functions to notified when to start, receive intput and return results.

### Working with the Orchestration client
Orchestrations are very unique when compared to other styles of triggered operations in Azure Functions. Durable Functions enables the execution of functions that may take hours or even days to complete. That type of behavior comes with the need to able to check the status of a running orchestration, preemptively terminate, or send notifications of external events.

For these cases, the Durable Functions extension provides the DurableOrchestrationClient class that allows you to interact with orchestrated functions. You get access to the orchestration client by using the OrchestrationClientAttribute binding. Generally, you would include this attribute with another trigger type, such as a HttpTrigger or ServiceBusTrigger. Once the source function gets trigger, the orchestration client can be used to start an orchestrator function.

```csharp
[FunctionName("KickOff")]
public static async Task<HttpResponseMessage> Run(
    [HttpTrigger(AuthorizationLevel.Function, "POST")]HttpRequestMessage req,
    [OrchestrationClient ] DurableOrchestrationClient orchestrationClient)
{
    OrderRequestData data = await req.Content.ReadAsAsync<OrderRequestData>();

    string instanceId = await orchestrationClient.StartNewAsync("PlaceOrder", data);

    return orchestrationClient.CreateCheckStatusResponse(req, instanceId);
}
```

### The orchestrator function
Annotating a function with the OrchestrationTriggerAttribute in Azure Functions marks that function as an orchestrator function. It is responsible for managing the various activities that make up your stateful workflow.

Orchestrator functions are unable to make use of bindings other than the OrchestrationTriggerAttribute. This attribute can only be used with a parameter type of DurableOrchestrationContext. No other inputs can be used since deserialization of inputs in the function signature is not supported. To get inputs provided by the orchestration client, the GetInput<T> method must be used.

Also, the return types of orchestration functions must be either void, Task, or a JSON serializable value.

*Error handling code has been left out for brevity*
```csharp
[FunctionName("PlaceOrder")]
public static async Task<string> PlaceOrder([OrchestrationTrigger] DurableOrchestrationContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    await context.CallActivityAsync<bool>("CheckAndReserveInventory", orderData);
    await context.CallActivityAsync<string>("ProcessPayment", orderData);

    string trackingNumber = await context.CallActivityAsync<string>("ScheduleShipping", orderData);
    await context.CallActivityAsync<string>("EmailCustomer", trackingNumber);

    return trackingNumber;
}
```

Multiple instances of an orchestration can be started and running at the same time. Calling the StartNewAsync method on the DurableOrchestrationClient launches a new instance of the orchestration. The method returns a Task<string> that completes when the orchestration has started. An exception of type TimeoutException get thrown if the orchestration has not started within 30 seconds.

The completed Task<string> from StartNewAsync should contain the unique ID of the orchestration instance. This instance ID can used to invoke operations on that specific orchestration such as querying for the status or sending event notifications.

### The activity functions
Activity functions are the discrete operations that get composed together within an orchestration function to create the workflow. Here is where most of actual work would take place. They represent the business logic, long running processes, and the puzzle pieces to a larger solution.

The ActivityTriggerAttribute is used to annotate a function parameter of type DurableActivityContext, which let's the runtime know that the function is intended to be used as an activity function. Input values to activity functions have be retrived by using the GetInput<T> method of the DurableActivityContext parameter.

Similar to orchestration functions, the return types of activity functions must be either void, Task, or a JSON serializable value.

Any unhandled exceptions that get thrown within activity functions will get sent up to the calling orchestrator function and presentated as a TaskFailedException. At this point, the error can be caught and logged in the orchestrator, and the activity can be retried.

```csharp
[FunctionName("CheckAndReserveInventory")]
public static bool CheckAndReserveInventory([ActivityTrigger] DurableActivityContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    // Connect to inventory system and try to reserve items
    return true;
}
```


## Recommended Resources
* [Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings)
* [Bindings for Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings)
* [Manage instances in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-instance-management)

>[!div class="step-by-step"]
[Previous] (../azure-serverless-platform/event-grid.md)
[Next] (./orchestration-patterns.md)
