---
title: Orchestration patterns - Serverless apps
description: Learn about using Durable Functions to implement workflow patterns.
author: cecilphillip
ms.date: 06/26/2018
---
# Orchestration patterns

Durable Functions makes it easier to create stateful workflows that are composed of discrete, long running activities in a serverless environment. Since Durable Functions can track the progress of your workflows and periodically checkpoints the execution history, it lends itself to implementing some interesting patterns.

## Function chaining

In a typical sequential process, activities need to execute one after the other in a particular order. Optionally, the upcoming activity may require some output from the previous function. This dependency on the ordering of activities creates a function chain of execution.

The benefit of using Durable Functions to implement this workflow pattern comes from its ability to do checkpointing. If the server crashes, the network times out or some other issue occurs, Durable functions can resume from the last known state and continue running your workflow even if it's on another server.

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

In the preceding code sample, the `CallActivityAsync` function is responsible for running a given activity on a virtual machine in the data center. When the await returns and the underlying Task completes, the execution will be recorded to the history table. The code in the orchestrator function can make use of any of the familiar constructs of the Task Parallel Library and the async/await keywords.

The following code is a simplified example of what the `ProcessPayment` method may look like:

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

In some cases, workflows may contain activities that take a relatively long period of time to complete. Imagine a process that kicks off the backup of media files into blob storage. Depending on the size and quantity of the media files, this backup process may take hours to complete.

In this scenario, the `DurableOrchestrationClient`'s ability to check the status of a running workflow becomes useful. When using an `HttpTrigger` to start a workflow, the `CreateCheckStatusResponse` method can be used to return an instance of `HttpResponseMessage`. This response provides the client with a URI in the payload that can be used to check the status of the running process.

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

Using your preferred HTTP client, GET requests can be made to the URI in statusQueryGetUri to inspect the status of the running workflow. The returned status response should resemble the following code.

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

As the process continues, the status response will change to either **Failed** or **Completed**. On successful completion, the **output** property in the payload will contain any returned data.

## Monitoring

For simple recurring tasks, Azure Functions provides the `TimerTrigger` that can be scheduled based on a CRON expression. The timer works well for simple, short-lived tasks, but there might be scenarios where more flexible scheduling is needed. This scenario is when the monitoring pattern and Durable Functions can help.

Durable Functions allows for flexible scheduling intervals, lifetime management, and the creation of multiple monitor processes from a single orchestration function. One use case for this functionality might be to create watchers for stock price changes that complete once a certain threshold is met.

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

`DurableOrchestrationContext`'s `CreateTimer` method sets up the schedule for the next invocation of the loop to check for stock price changes. `DurableOrchestrationContext` also has a `CurrentUtcDateTime` property to get the current DateTime value in UTC. It's better to use this property instead of `DateTime.UtcNow` because it's easily mocked for testing.

## Recommended resources

- [Azure Durable Functions](/azure/azure-functions/durable-functions-overview)
- [Unit Testing in .NET Core and .NET Standard](../../core/testing/index.md)

>[!div class="step-by-step"]
>[Previous](durable-azure-functions.md)
>[Next](serverless-business-scenarios.md)
