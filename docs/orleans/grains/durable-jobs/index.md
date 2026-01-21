---
title: Orleans Durable Jobs
description: Learn how to use Orleans Durable Jobs for reliable, scheduled task execution with at-least-once delivery guarantees.
ms.date: 01/20/2026
ms.topic: conceptual
zone_pivot_groups: orleans-version
---

# Orleans Durable Jobs

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0"

Orleans Durable Jobs is a feature that provides reliable, scheduled task execution with at-least-once delivery guarantees. Unlike traditional reminders, durable jobs support metadata, flexible retry policies, and are designed for scenarios where you need guaranteed execution of scheduled tasks.

[!INCLUDE [orleans-10-preview](../../includes/orleans-10-preview.md)]

## Features

Durable Jobs provides the following capabilities:

- **At-least-once execution**: Jobs are guaranteed to execute at least once, even in the face of silo failures.
- **Scheduled execution**: Schedule jobs to execute at a specific time in the future.
- **Metadata support**: Attach arbitrary key-value metadata to jobs for context during execution.
- **Retry policies**: Configure automatic retry behavior with exponential backoff.
- **Cancellation support**: Cancel scheduled jobs before they execute.
- **Execution context**: Access job details and retry count during execution.

## Comparison with Reminders

| Feature | Reminders | Durable Jobs |
|---------|-----------|--------------|
| Execution guarantee | At-least-once | At-least-once |
| Scheduling | Recurring on interval | One-time at specific time |
| Metadata | Not supported | Key-value dictionary |
| Retry policy | Fixed | Configurable with exponential backoff |
| Cancellation | Supported | Supported |
| Target | Grain instance | Any grain implementing `IDurableJobHandler` |
| Dequeue count | Not available | Available via `IDurableJobContext` |

## Installation

The Orleans Durable Jobs feature is distributed in the following NuGet packages:

| Package | Description |
|---------|-------------|
| [Microsoft.Orleans.DurableJobs](https://www.nuget.org/packages/Microsoft.Orleans.DurableJobs) | Core durable jobs functionality |

### Basic setup

To add Durable Jobs to your Orleans silo, call `AddDurableJobs()` on your silo builder:

```csharp
using Orleans.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    
    // Add durable jobs with in-memory storage (development only)
    siloBuilder.UseInMemoryDurableJobs();
});

var host = builder.Build();
await host.RunAsync();
```

> [!WARNING]
> The `UseInMemoryDurableJobs()` method uses non-persistent, in-memory storage and should only be used for development and testing. For production deployments, use a persistent storage provider.

## Implementing a job handler

To receive and process durable jobs, your grain must implement the `IDurableJobHandler` interface:

```csharp
using Orleans.DurableJobs;

public interface IOrderGrain : IGrainWithGuidKey, IDurableJobHandler
{
    Task ScheduleReminderAsync(DateTimeOffset dueTime);
}

public class OrderGrain : Grain, IOrderGrain
{
    private readonly ILocalDurableJobManager _durableJobManager;

    public OrderGrain(ILocalDurableJobManager durableJobManager)
    {
        _durableJobManager = durableJobManager;
    }

    public async Task ScheduleReminderAsync(DateTimeOffset dueTime)
    {
        // Schedule a job targeting this grain
        await _durableJobManager.ScheduleJobAsync(
            target: this.GetGrainId(),
            jobName: "process-order",
            dueTime: dueTime,
            metadata: new Dictionary<string, string>
            {
                ["priority"] = "high",
                ["source"] = "web-api"
            },
            cancellationToken: default);
    }

    public Task ExecuteJobAsync(IDurableJobContext context, CancellationToken cancellationToken)
    {
        var job = context.Job;
        
        Console.WriteLine($"Executing job: {job.Name}");
        Console.WriteLine($"Job ID: {job.Id}");
        Console.WriteLine($"Due time: {job.DueTime}");
        Console.WriteLine($"Attempt: {context.DequeueCount}");
        
        // Access metadata
        if (job.Metadata?.TryGetValue("priority", out var priority) == true)
        {
            Console.WriteLine($"Priority: {priority}");
        }
        
        // Perform your job logic here
        
        return Task.CompletedTask;
    }
}
```

## Scheduling jobs

Use the `ILocalDurableJobManager` service to schedule durable jobs:

```csharp
public class JobSchedulerGrain : Grain, IJobSchedulerGrain
{
    private readonly ILocalDurableJobManager _durableJobManager;
    private readonly IGrainFactory _grainFactory;

    public JobSchedulerGrain(
        ILocalDurableJobManager durableJobManager,
        IGrainFactory grainFactory)
    {
        _durableJobManager = durableJobManager;
        _grainFactory = grainFactory;
    }

    public async Task<DurableJob> ScheduleOrderProcessingAsync(
        Guid orderId, 
        DateTimeOffset processAt)
    {
        // Get the target grain's ID
        var orderGrain = _grainFactory.GetGrain<IOrderGrain>(orderId);
        var grainId = orderGrain.GetGrainId();

        // Schedule the job
        var job = await _durableJobManager.ScheduleJobAsync(
            target: grainId,
            jobName: "process-order",
            dueTime: processAt,
            metadata: new Dictionary<string, string>
            {
                ["orderId"] = orderId.ToString(),
                ["scheduledBy"] = "scheduler-service"
            },
            cancellationToken: default);

        return job;
    }
}
```

### The DurableJob model

When you schedule a job, you receive a `DurableJob` object containing:

| Property | Type | Description |
|----------|------|-------------|
| `Id` | `string` | Unique identifier for the job |
| `Name` | `string` | Name of the job for identification |
| `DueTime` | `DateTimeOffset` | When the job should execute |
| `TargetGrainId` | `GrainId` | The grain that will handle the job |
| `ShardId` | `string` | Internal shard identifier |
| `Metadata` | `IReadOnlyDictionary<string, string>?` | Optional key-value metadata |

## Canceling jobs

To cancel a scheduled job before it executes, use `TryCancelDurableJobAsync`:

```csharp
public async Task<bool> CancelJobAsync(DurableJob job)
{
    var canceled = await _durableJobManager.TryCancelDurableJobAsync(
        job, 
        cancellationToken: default);
    
    if (canceled)
    {
        Console.WriteLine($"Job {job.Id} was canceled successfully.");
    }
    else
    {
        Console.WriteLine($"Job {job.Id} could not be canceled (may have already executed).");
    }
    
    return canceled;
}
```

> [!NOTE]
> Cancellation may fail if the job has already started executing or has completed.

## Job execution context

The `IDurableJobContext` interface provides information about the current job execution:

| Property | Type | Description |
|----------|------|-------------|
| `Job` | `DurableJob` | The job being executed |
| `RunId` | `string` | Unique identifier for this execution attempt |
| `DequeueCount` | `int` | Number of times this job has been dequeued (1 for first attempt) |

Use `DequeueCount` to implement custom retry logic or logging:

```csharp
public Task ExecuteJobAsync(IDurableJobContext context, CancellationToken cancellationToken)
{
    if (context.DequeueCount > 1)
    {
        Console.WriteLine($"Retry attempt {context.DequeueCount} for job {context.Job.Id}");
    }
    
    // Process the job...
    
    return Task.CompletedTask;
}
```

## Configuration

Configure durable jobs behavior using `DurableJobsOptions`:

```csharp
builder.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    siloBuilder.AddDurableJobs();
    
    siloBuilder.Services.Configure<DurableJobsOptions>(options =>
    {
        // Duration of each job shard (default: 1 hour)
        options.ShardDuration = TimeSpan.FromMinutes(30);
        
        // How early to start processing a shard (default: 5 minutes)
        options.ShardActivationBufferPeriod = TimeSpan.FromMinutes(2);
        
        // Maximum concurrent jobs per silo (default: 10,000 * processor count)
        options.MaxConcurrentJobsPerSilo = 50_000;
        
        // Delay between overload checks (default: 5 seconds)
        options.OverloadBackoffDelay = TimeSpan.FromSeconds(10);
    });
});
```

### Configuration options

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `ShardDuration` | `TimeSpan` | 1 hour | Duration of each job shard. Smaller values reduce latency but increase overhead. Use values that evenly divide 60 minutes (1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, or 60 minutes). |
| `ShardActivationBufferPeriod` | `TimeSpan` | 5 minutes | How far in advance the shard begins processing before its start time. |
| `MaxConcurrentJobsPerSilo` | `int` | 10,000 * CPU count | Maximum number of jobs executing concurrently on a single silo. |
| `OverloadBackoffDelay` | `TimeSpan` | 5 seconds | Delay between overload checks when the host is overloaded. |
| `ShouldRetry` | `Func<IDurableJobContext, Exception, DateTimeOffset?>` | Exponential backoff (5 retries) | Function that determines if and when a failed job should be retried. |

### Custom retry policy

Configure a custom retry policy using the `ShouldRetry` option:

```csharp
siloBuilder.Services.Configure<DurableJobsOptions>(options =>
{
    options.ShouldRetry = (context, exception) =>
    {
        // Don't retry after 3 attempts
        if (context.DequeueCount >= 3)
        {
            return null;
        }
        
        // Don't retry for certain exception types
        if (exception is InvalidOperationException)
        {
            return null;
        }
        
        // Retry with linear backoff (30 seconds * attempt number)
        var delay = TimeSpan.FromSeconds(30 * context.DequeueCount);
        return DateTimeOffset.UtcNow.Add(delay);
    };
});
```

The default retry policy uses exponential backoff with up to 5 retries:
- Attempt 1: Retry after 2 seconds
- Attempt 2: Retry after 4 seconds
- Attempt 3: Retry after 8 seconds
- Attempt 4: Retry after 16 seconds
- Attempt 5: Retry after 32 seconds
- After 5 attempts: Job is not retried

## Storage providers

### In-memory storage (development only)

For development and testing, use the in-memory storage provider:

```csharp
siloBuilder.UseInMemoryDurableJobs();
```

> [!CAUTION]
> In-memory storage does not persist jobs across silo restarts. Use only for development.

### Azure Storage (production)

For production deployments, use a persistent storage provider such as Azure Blob Storage:

```csharp
siloBuilder.AddDurableJobs();
siloBuilder.AddAzureBlobDurableJobStorage(options =>
{
    options.ConfigureBlobServiceClient(new Uri("https://mystorageaccount.blob.core.windows.net"), 
        new DefaultAzureCredential());
});
```

## Error handling

When a job execution throws an exception:

1. The exception is caught by the durable jobs infrastructure.
2. The `ShouldRetry` function is called with the job context and exception.
3. If `ShouldRetry` returns a `DateTimeOffset`, the job is rescheduled for that time.
4. If `ShouldRetry` returns `null`, the job is not retried.

Implement robust error handling in your job handler:

```csharp
public async Task ExecuteJobAsync(IDurableJobContext context, CancellationToken cancellationToken)
{
    try
    {
        await ProcessOrderAsync(context.Job, cancellationToken);
    }
    catch (TransientException ex)
    {
        // Let the retry policy handle transient failures
        throw;
    }
    catch (PermanentException ex)
    {
        // Log and don't retry permanent failures
        _logger.LogError(ex, "Permanent failure processing job {JobId}", context.Job.Id);
        
        // Move to dead-letter queue or notify
        await HandlePermanentFailureAsync(context.Job, ex);
        
        // Don't throw - marks job as completed
    }
}
```

## See also

- <xref:Orleans.DurableJobs.IDurableJobHandler>
- <xref:Orleans.DurableJobs.ILocalDurableJobManager>
- <xref:Orleans.Hosting.DurableJobsOptions>
- [Timers and reminders](../timers-and-reminders.md)
- [NuGet packages](../../resources/nuget-packages.md)

:::zone-end

:::zone target="docs" pivot="orleans-9-0,orleans-8-0,orleans-7-0,orleans-3-x"

Orleans Durable Jobs is a feature introduced in Orleans 10.0 that provides reliable, scheduled task execution with at-least-once delivery guarantees. For earlier versions, consider using:

- **[Reminders](../timers-and-reminders.md)**: Built-in support for persistent, recurring timers with at-least-once delivery.
- **External job schedulers**: Integrate with Hangfire, Quartz.NET, or Azure Service Bus scheduled messages for advanced scheduling needs.

:::zone-end
<!-- markdownlint-enable MD044 -->
