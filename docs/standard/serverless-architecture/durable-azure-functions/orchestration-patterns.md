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
# Orchestration Patterns

Durable Functions makes easier to create stateful workflows that are comprised of discrete, long running activities in a serverless environment. Since Durable Functions is able to track the progress of your your workflows and peridically checkpoints the execution history, let lends itself to implementing some interesting patterns.

## Function chaining
In a typical sequential process, activites need to execute one after the other in a particular order. Optionally, the upcoming activity my require some output from the previous. This dependency on order and out creates a function chain of execution.

The benefit of using Durable Functions to implement this workflow pattern comes from its ability to do checkpointing. In the event of a server crash, network timeout or some other issue, Durable functions is able to resume from the last known state and continue running your workflow event if it's on another server.

```csharp
[FunctionName("PlaceOrder")]
public static async Task<string> PlaceOrder([OrchestrationTrigger] DurableOrchestrationContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    await context.CallActivityAsync<bool>("CheckAndReserveInventory", orderData);
    await context.CallActivityAsync<bool>("ProcessPayment", orderData);

    string trackingNumber = await context.CallActivityAsync<string>("ScheduleShipping", orderData);
    await context.CallActivityAsync<string>("EmailCustomer", trackingNumber);

    return trackingNumber;
}
```

In the preceeding code sample, the `CallActivityAsync` function responsibile for running a given activity on a virtual machine in the data center. When the await returns and the underlying Task completes, the execution will be recorded to the history table. The code in the orchestrator function can make use of any of the familiar constructs of the Task Parallel Library and the async/await keywords.

Below is a simplified example of what the `ProcessPayment` method may look like.

```csharp
[FunctionName("ProcessPayment")]
public static bool ProcessPayment([ActivityTrigger] DurableActivityContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    ApplyCoupons(orderData);
    if(IssuePaymentRequest(orderData)) {
        return true;
    }

    return false;
}
```

## Asynchronous HTTP APIs
In some cases, workflows may contain activities that take a realtively long period of time to complete. Imagine a process that kicks off the backup of media files into blob storage. Depending on the size and quantity of the media files, this backup process may take hours to complete.

In a scenario like this, the `DurableOrchestrationClient`'s ability to check the status of a running workflow becomes quite useful. When using an `HttpTrigger` to intiate a workflow, the `CreateCheckStatusResponse` method can be used to return an instance of `HttpResponseMessage`. This response provides the client with a URI in the payload that can be used to check the status of the running process.

```csharp
[FunctionName("OrderWorkflow")]
public static async Task<HttpResponseMessage> Run(
    [HttpTrigger(AuthorizationLevel.Function, "POST")]HttpRequestMessage req,
    [OrchestrationClient ] DurableOrchestrationClient orchestrationClient)
{
    OrderRequestData data = await req.Content.ReadAsAsync<OrderRequestData>();

    string instanceId = await orchestrationClient.StartNewAsync("PlaceOrder", data);

    return orchestrationClient.CreateCheckStatusResponse(req, instanceId);
}
```

The sample result below shows the structure of the response payload.

```json
{
    "id": "instanceId",
    "statusQueryGetUri": "http://host/statusUri",
    "sendEventPostUri": "http://host/eventUri",
    "terminatePostUri": "http://host/terminateUri"
}
```
Using your preffered HTTP client, GET requests can be made to the URI in statusQueryGetUri to inspect the status of the running workflow. The returned status resonse should resemble the following.

```json
{
    "runtimeStatus": "Running",
    "input": {
        "$type": "DurableFunctionsDemos.OrderRequestData, DurableFunctionsDemos"
    },
    "output": null,
    "createdTime": "2018-01-01T00:22:05Z",
    "lastUpdatedTime": "2018-01-01T00:22:09Z"
}
```
As the process continues, the status response will change to either **Failed** or **Completed**. On successful completion, the **output** property in the payload will contained any returned data.

## Monitoring
For simple recurring tasks, Azure Functions provides the TimerTrigger that can be scheduled based on CRON expression. This works well for simple, short-lived tasks, but there might be scenarios where more flexible scheduled is needed. This is where the monitoring pattern and Durable Functions can help.

Durable Functions allows for flexible scheduling intervals, lifetime management, and the creation of multiple monitor processes from a single orchestration function. One use case for this might be to create watchers for stock price changes that complete once a certain threshold is met.

```csharp
[FunctionName("CheckStockPrice")]
public static async Task CheckStockPrice([OrchestrationTrigger] DurableOrchestrationContext context)
{
    StockWatcherInfo stockInfo = context.GetInput<StockWatcherInfo>();
    const int checkIntervalSeconds = 120;
    StockPrice initialStockPrice = null;

    DateTime fireAt;
    DateTime exitTime = context.CurrentUtcDateTime.Add(stockInfo.TimeLimit);

    while (context.CurrentUtcDateTime < exitTime)
    {
        StockPrice currentStockPrice = await context.CallActivityAsync<StockPrice>("GetStockPrice", stockInfo);

        if (initialStockPrice == null)
        {
            initialStockPrice = currentStockPrice;
            fireAt = context.CurrentUtcDateTime.AddSeconds(checkIntervalSeconds);
            await context.CreateTimer(fireAt, CancellationToken.None);
            continue;
        }

        decimal percentageChange = (initialStockPrice.Price - currentStockPrice.Price) /
                               ((initialStockPrice.Price + currentStockPrice.Price) / 2);

        if (Math.Abs(percentageChange) >= stockInfo.PercentageChange)
        {
            // Change threshold detected
            await context.CallActivityAsync("NotifyStockPercentageChange", currentStockPrice);
            break;
        }

        // Sleep til next polling interval
        fireAt = context.CurrentUtcDateTime.AddSeconds(checkIntervalSeconds);
        await context.CreateTimer(fireAt, CancellationToken.None);
    }
}
```

`DurableOrchestrationContext`'s `CreateTimer` method sets up the scheduled for the next invocation of the loop to check for stock price changes. DurableOrchestrationContext also has a `CurrentUtcDateTime` property to get the current DateTime value in UTC. It's better to use this property instead of DateTime.UtcNow because it is easily mocked for testing.


## Recommended Resources !TODO

* [Azure Event Grid](/azure/event-grid/overview)
* [Designing microservices: identifying microservice boundaries](/azure/architecture/microservices/microservice-boundaries)
* [Event Hubs](/azure/event-hubs/event-hubs-what-is-event-hubs)
* [IoT Hub](/azure/iot-hub)
* [Service Bus](/service-bus)

>[!div class="step-by-step"]
[Previous] (./index.md)
[Next] (./orchestration-patterns.md)