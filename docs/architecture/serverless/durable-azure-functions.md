---
title: Durable Azure Functions - Serverless apps
description: Durable Azure Functions extend the Azure Functions runtime to enable stateful workflows in code.
author: cecilphillip
ms.date: 06/26/2018
---
# Durable Azure Functions

When creating serverless applications with Azure Functions, your operations will typically be designed to run in a stateless manner. The reason for this design choice is because as the platform scales, it becomes difficult to know what servers the code is running on. It also becomes difficult to know how many instances are active at any given point. However, there are classes of applications that require the current state of a process to be known. Consider the process of submitting an order to an online store. The checkout operation might be a workflow that is composed of multiple operations that need to know the state of the process. Such information may include the product inventory, if the customer has any credits on their account, and also the results of processing the credit card. These operations could easily be their own internal workflows or even services from third-party systems.

Various patterns exist today that assist with the coordination of application state between internal and external systems. It's common to come across solutions that rely on centralized queuing systems, distributed key-value stores, or shared databases to manage that state. However, these are all additional resources that now need to be provisioned and managed. In a serverless environment, your code could become cumbersome trying to coordinate with these resources manually. Azure Functions offers an alternative for creating stateful functions called Durable Functions.

Durable Functions is an extension to the Azure Functions runtime that enables the definition of stateful workflows in code. By breaking down workflows into activities, the Durable Functions extension can manage state, create progress checkpoints, and handle the distribution of function calls across servers. In the background, it makes use of an Azure Storage account to persist execution history, schedule activity functions and retrieve responses. Your serverless code should never interact with persisted information in that storage account, and is typically not something with which developers need to interact.

## Triggering a stateful workflow

Stateful workflows in Durable Functions can be broken down into two intrinsic components; orchestration and activity triggers. Triggers and bindings are core components used by Azure Functions to enable your serverless functions to be notified when to start, receive input, and return results.

### Working with the Orchestration client

Orchestrations are unique when compared to other styles of triggered operations in Azure Functions. Durable Functions enables the execution of functions that may take hours or even days to complete. That type of behavior comes with the need to able to check the status of a running orchestration, preemptively terminate, or send notifications of external events.

For such cases, the Durable Functions extension provides the `DurableOrchestrationClient` class that allows you to interact with orchestrated functions. You get access to the orchestration client by using the `OrchestrationClientAttribute` binding. Generally, you would include this attribute with another trigger type, such as an `HttpTrigger` or `ServiceBusTrigger`. Once the source function has been triggered, the orchestration client can be used to start an orchestrator function.

```csharp
[FunctionName("KickOff")]
public static async Task<HttpResponseMessage> Run(
    [HttpTrigger(AuthorizationLevel.Function, "POST")]HttpRequestMessage req,
    [OrchestrationClient ] DurableOrchestrationClient<orchestrationClient>)
{
    OrderRequestData data = await req.Content.ReadAsAsync<OrderRequestData>();

    string instanceId = await orchestrationClient.StartNewAsync("PlaceOrder", data);

    return orchestrationClient.CreateCheckStatusResponse(req, instanceId);
}
```

### The orchestrator function

Annotating a function with the OrchestrationTriggerAttribute in Azure Functions marks that function as an orchestrator function. It's responsible for managing the various activities that make up your stateful workflow.

Orchestrator functions are unable to make use of bindings other than the OrchestrationTriggerAttribute. This attribute can only be used with a parameter type of DurableOrchestrationContext. No other inputs can be used since deserialization of inputs in the function signature isn't supported. To get inputs provided by the orchestration client, the GetInput\<T\> method must be used.

Also, the return types of orchestration functions must be either void, Task, or a JSON serializable value.

> *Error handling code has been left out for brevity*

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

Multiple instances of an orchestration can be started and running at the same time. Calling the `StartNewAsync` method on the `DurableOrchestrationClient` launches a new instance of the orchestration. The method returns a `Task<string>` that completes when the orchestration has started. An exception of type `TimeoutException` gets thrown if the orchestration hasn't started within 30 seconds.

The completed `Task<string>` from `StartNewAsync` should contain the unique ID of the orchestration instance. This instance ID can be used to invoke operations on that specific orchestration. The orchestration can be queried for the status or sent event notifications.

### The activity functions

Activity functions are the discrete operations that get composed together within an orchestration function to create the workflow. Here is where most of actual work would take place. They represent the business logic, long running processes, and the puzzle pieces to a larger solution.

The `ActivityTriggerAttribute` is used to annotate a function parameter of type `DurableActivityContext`. Using the annotation informs the runtime that the function is intended to be used as an activity function. Input values to activity functions are retrieved using the `GetInput<T>` method of the `DurableActivityContext` parameter.

Similar to orchestration functions, the return types of activity functions must be either void, Task, or a JSON serializable value.

Any unhandled exceptions that get thrown within activity functions will get sent up to the calling orchestrator function and presented as a `TaskFailedException`. At this point, the error can be caught and logged in the orchestrator, and the activity can be retried.

```csharp
[FunctionName("CheckAndReserveInventory")]
public static bool CheckAndReserveInventory([ActivityTrigger] DurableActivityContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    // Connect to inventory system and try to reserve items
    return true;
}
```

## Recommended resources

- [Durable Functions](/azure/azure-functions/durable-functions-overview)
- [Bindings for Durable Functions](/azure/azure-functions/durable-functions-bindings)
- [Manage instances in Durable Functions](/azure/azure-functions/durable-functions-instance-management)

>[!div class="step-by-step"]
>[Previous](event-grid.md)
>[Next](orchestration-patterns.md)
