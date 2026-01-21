---
title: Orleans Journaling
description: Learn how to use Orleans Journaling for durable state machines with automatic persistence and recovery using the DurableGrain base class and durable collections.
ms.date: 01/20/2026
ms.topic: conceptual
zone_pivot_groups: orleans-version
---

# Orleans Journaling

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0"

Orleans Journaling provides durable state machines with automatic persistence, recovery, and efficient journal-based storage. Unlike traditional grain persistence that stores complete state snapshots, journaling records state changes as a sequence of log entries, enabling efficient incremental updates and point-in-time recovery.

[!INCLUDE [orleans-10-preview](../../includes/orleans-10-preview.md)]

## Features

Orleans Journaling provides the following capabilities:

- **Durable state machines**: State changes are recorded as journal entries and automatically replayed during grain activation.
- **Automatic recovery**: On grain activation, the journal is replayed to restore the exact state.
- **Efficient updates**: Only state changes are persisted, not the entire state snapshot.
- **Type-safe collections**: Pre-built durable collections for common data structures.
- **Snapshot optimization**: Automatic snapshot creation to optimize recovery time.
- **Transaction support**: Multiple state machines can be updated atomically.

## Comparison with JournaledGrain

Orleans has offered event sourcing through `JournaledGrain<TState, TEvent>` since Orleans 3.x. The new `DurableGrain` base class in Orleans 10.0 provides a simpler, more flexible approach:

| Feature | JournaledGrain (7.0) | DurableGrain (10.0) |
|---------|---------------------|---------------------|
| State model | Single state object with events | Multiple durable collections |
| Event handling | Explicit event classes and Apply methods | Implicit through collection operations |
| Complexity | Higher (requires event design) | Lower (use familiar collection APIs) |
| Flexibility | Custom event semantics | Pre-built collection behaviors |
| Recovery | Event replay | Journal replay with snapshots |
| Multiple state machines | Not supported | Supported |

## Installation

The Orleans Journaling feature is distributed in the following NuGet package:

| Package | Description |
|---------|-------------|
| [Microsoft.Orleans.Journaling](https://www.nuget.org/packages/Microsoft.Orleans.Journaling) | Core journaling functionality with durable collections |

### Basic setup

To enable journaling in your Orleans silo, call `AddStateMachineStorage()` on your silo builder:

```csharp
using Orleans.Journaling;

var builder = Host.CreateApplicationBuilder(args);

builder.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    
    // Add state machine storage for journaling
    siloBuilder.AddStateMachineStorage();
    
    // Configure a storage provider for the journal
    // (Required for production - use Azure Blob, SQL, etc.)
});

var host = builder.Build();
await host.RunAsync();
```

## The DurableGrain base class

To create a grain with durable state, inherit from `DurableGrain` instead of `Grain`:

```csharp
using Orleans.Journaling;

public interface ICounterGrain : IGrainWithGuidKey
{
    Task<int> GetValueAsync();
    Task IncrementAsync();
    Task DecrementAsync();
}

public class CounterGrain : DurableGrain, ICounterGrain
{
    private readonly IDurableValue<int> _counter;

    public CounterGrain(
        [FromKeyedServices("counter")] IDurableValue<int> counter)
    {
        _counter = counter;
    }

    public Task<int> GetValueAsync() => Task.FromResult(_counter.Value);

    public async Task IncrementAsync()
    {
        _counter.Value++;
        await WriteStateAsync();
    }

    public async Task DecrementAsync()
    {
        _counter.Value--;
        await WriteStateAsync();
    }
}
```

### Key concepts

- **`DurableGrain`**: Base class that manages state machine lifecycle and persistence.
- **`WriteStateAsync()`**: Persists all pending changes to the journal.
- **Keyed services**: Durable collections are injected using `[FromKeyedServices("name")]` to identify them in the journal.

## Durable collections

Orleans Journaling provides several pre-built durable collections that automatically track and persist changes:

### IDurableValue&lt;T&gt;

A simple wrapper for storing a single value:

```csharp
public class SettingsGrain : DurableGrain, ISettingsGrain
{
    private readonly IDurableValue<UserSettings> _settings;

    public SettingsGrain(
        [FromKeyedServices("settings")] IDurableValue<UserSettings> settings)
    {
        _settings = settings;
    }

    public Task<UserSettings?> GetSettingsAsync() => Task.FromResult(_settings.Value);

    public async Task UpdateSettingsAsync(UserSettings settings)
    {
        _settings.Value = settings;
        await WriteStateAsync();
    }
}
```

### IDurableDictionary&lt;TKey, TValue&gt;

A dictionary that persists add, update, and remove operations:

```csharp
public class ShoppingCartGrain : DurableGrain, IShoppingCartGrain
{
    private readonly IDurableDictionary<string, CartItem> _items;

    public ShoppingCartGrain(
        [FromKeyedServices("items")] IDurableDictionary<string, CartItem> items)
    {
        _items = items;
    }

    public Task<IReadOnlyDictionary<string, CartItem>> GetItemsAsync() 
        => Task.FromResult<IReadOnlyDictionary<string, CartItem>>(_items);

    public async Task AddItemAsync(string productId, int quantity)
    {
        if (_items.TryGetValue(productId, out var existing))
        {
            _items[productId] = existing with { Quantity = existing.Quantity + quantity };
        }
        else
        {
            _items[productId] = new CartItem(productId, quantity);
        }
        await WriteStateAsync();
    }

    public async Task RemoveItemAsync(string productId)
    {
        _items.Remove(productId);
        await WriteStateAsync();
    }

    public async Task ClearAsync()
    {
        _items.Clear();
        await WriteStateAsync();
    }
}
```

### IDurableList&lt;T&gt;

An ordered list that persists add, insert, update, and remove operations:

```csharp
public class TodoListGrain : DurableGrain, ITodoListGrain
{
    private readonly IDurableList<TodoItem> _todos;

    public TodoListGrain(
        [FromKeyedServices("todos")] IDurableList<TodoItem> todos)
    {
        _todos = todos;
    }

    public Task<IReadOnlyList<TodoItem>> GetAllAsync() 
        => Task.FromResult(_todos.AsReadOnly() as IReadOnlyList<TodoItem>);

    public async Task AddAsync(TodoItem item)
    {
        _todos.Add(item);
        await WriteStateAsync();
    }

    public async Task InsertAtAsync(int index, TodoItem item)
    {
        _todos.Insert(index, item);
        await WriteStateAsync();
    }

    public async Task RemoveAtAsync(int index)
    {
        _todos.RemoveAt(index);
        await WriteStateAsync();
    }
}
```

### IDurableQueue&lt;T&gt;

A first-in-first-out queue:

```csharp
public class WorkQueueGrain : DurableGrain, IWorkQueueGrain
{
    private readonly IDurableQueue<WorkItem> _queue;

    public WorkQueueGrain(
        [FromKeyedServices("queue")] IDurableQueue<WorkItem> queue)
    {
        _queue = queue;
    }

    public Task<int> GetPendingCountAsync() => Task.FromResult(_queue.Count);

    public async Task EnqueueAsync(WorkItem item)
    {
        _queue.Enqueue(item);
        await WriteStateAsync();
    }

    public async Task<WorkItem?> TryDequeueAsync()
    {
        if (_queue.TryDequeue(out var item))
        {
            await WriteStateAsync();
            return item;
        }
        return null;
    }
}
```

### IDurableSet&lt;T&gt;

A set that prevents duplicate values:

```csharp
public class TagsGrain : DurableGrain, ITagsGrain
{
    private readonly IDurableSet<string> _tags;

    public TagsGrain(
        [FromKeyedServices("tags")] IDurableSet<string> tags)
    {
        _tags = tags;
    }

    public Task<IReadOnlyCollection<string>> GetTagsAsync() 
        => Task.FromResult<IReadOnlyCollection<string>>(_tags);

    public async Task<bool> AddTagAsync(string tag)
    {
        var added = _tags.Add(tag);
        if (added)
        {
            await WriteStateAsync();
        }
        return added;
    }

    public async Task<bool> RemoveTagAsync(string tag)
    {
        var removed = _tags.Remove(tag);
        if (removed)
        {
            await WriteStateAsync();
        }
        return removed;
    }
}
```

### IDurableTaskCompletionSource&lt;T&gt;

A durable task completion source for long-running operations:

```csharp
public class ApprovalGrain : DurableGrain, IApprovalGrain
{
    private readonly IDurableTaskCompletionSource<ApprovalResult> _approval;

    public ApprovalGrain(
        [FromKeyedServices("approval")] IDurableTaskCompletionSource<ApprovalResult> approval)
    {
        _approval = approval;
    }

    public Task<ApprovalResult> WaitForApprovalAsync() => _approval.Task;

    public async Task ApproveAsync(string approver)
    {
        _approval.TrySetResult(new ApprovalResult(true, approver));
        await WriteStateAsync();
    }

    public async Task RejectAsync(string reason)
    {
        _approval.TrySetResult(new ApprovalResult(false, reason));
        await WriteStateAsync();
    }
}
```

## Durable collections reference

| Interface | Description | Key Operations |
|-----------|-------------|----------------|
| `IDurableValue<T>` | Single value wrapper | `Value` (get/set) |
| `IDurableDictionary<K, V>` | Key-value dictionary | `Add`, `Remove`, `Clear`, indexer |
| `IDurableList<T>` | Ordered list | `Add`, `Insert`, `RemoveAt`, `AddRange` |
| `IDurableQueue<T>` | FIFO queue | `Enqueue`, `Dequeue`, `TryDequeue`, `Peek` |
| `IDurableSet<T>` | Unique value set | `Add`, `Remove`, `Clear`, set operations |
| `IDurableTaskCompletionSource<T>` | Async result holder | `TrySetResult`, `TrySetException`, `TrySetCanceled` |
| `IDurableNothing` | Placeholder for retired types | (no operations) |

## Multiple state machines

A single grain can use multiple durable collections, each identified by a unique key:

```csharp
public class OrderGrain : DurableGrain, IOrderGrain
{
    private readonly IDurableValue<OrderStatus> _status;
    private readonly IDurableDictionary<string, OrderItem> _items;
    private readonly IDurableList<OrderEvent> _history;

    public OrderGrain(
        [FromKeyedServices("status")] IDurableValue<OrderStatus> status,
        [FromKeyedServices("items")] IDurableDictionary<string, OrderItem> items,
        [FromKeyedServices("history")] IDurableList<OrderEvent> history)
    {
        _status = status;
        _items = items;
        _history = history;
    }

    public async Task PlaceOrderAsync()
    {
        _status.Value = OrderStatus.Placed;
        _history.Add(new OrderEvent("Order placed", DateTime.UtcNow));
        await WriteStateAsync();
    }
}
```

All state machines are persisted atomically when `WriteStateAsync()` is called.

## Custom state machines

For advanced scenarios, you can create custom state machines by implementing `IDurableStateMachine` and using `GetOrCreateStateMachine`:

```csharp
public class CustomGrain : DurableGrain, ICustomGrain
{
    private MyCustomStateMachine? _stateMachine;

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        _stateMachine = GetOrCreateStateMachine<MyCustomStateMachine>("custom");
        return base.OnActivateAsync(cancellationToken);
    }
}
```

## State machine manager

The `IStateMachineManager` interface provides low-level control over state persistence:

| Method | Description |
|--------|-------------|
| `InitializeAsync` | Initializes the state machine manager (called automatically) |
| `RegisterStateMachine` | Registers a state machine with a stable name |
| `TryGetStateMachine` | Retrieves a registered state machine by name |
| `WriteStateAsync` | Persists all pending changes to storage |
| `DeleteStateAsync` | Removes all persistent state |

## Retiring durable types

When you need to remove a durable collection from a grain without breaking existing persisted data, use `IDurableNothing`:

```csharp
// Old grain with deprecated state
public class MyGrain : DurableGrain, IMyGrain
{
    // This collection is no longer used but must be retained for compatibility
    public MyGrain(
        [FromKeyedServices("deprecated")] IDurableNothing deprecated,
        [FromKeyedServices("current")] IDurableValue<int> current)
    {
        // deprecated collection will be ignored during recovery
    }
}
```

## Storage providers

Journaling requires a storage provider that implements `IStateMachineStorageProvider`. Configure your provider based on your deployment environment:

### Azure Blob Storage (production)

```csharp
siloBuilder.AddStateMachineStorage();
siloBuilder.AddAzureBlobStateMachineStorage(options =>
{
    options.ConfigureBlobServiceClient(
        new Uri("https://mystorageaccount.blob.core.windows.net"), 
        new DefaultAzureCredential());
});
```

### Development

For development and testing, you can use in-memory or local file storage. Check the Orleans samples for development configurations.

## Best practices

1. **Call `WriteStateAsync()` after modifications**: Changes are buffered until you explicitly persist them.

2. **Batch related changes**: Group related modifications before calling `WriteStateAsync()` to reduce I/O:

   ```csharp
   public async Task ProcessBatchAsync(IEnumerable<Item> items)
   {
       foreach (var item in items)
       {
           _collection.Add(item);
       }
       await WriteStateAsync(); // Single persist for all items
   }
   ```

3. **Use unique keys for each collection**: The key string identifies the state machine in the journal. Reusing keys with different types will cause errors.

4. **Consider snapshot frequency**: For state machines with many small changes, periodic snapshots improve recovery time.

5. **Handle concurrent access**: Like all grains, durable grains process one request at a time. State is consistent within each grain activation.

## See also

- <xref:Orleans.Journaling.DurableGrain>
- <xref:Orleans.Journaling.IStateMachineManager>
- [Event sourcing](../event-sourcing/index.md)
- [Grain persistence](../grain-persistence/index.md)
- [NuGet packages](../../resources/nuget-packages.md)

:::zone-end

:::zone target="docs" pivot="orleans-9-0,orleans-8-0,orleans-7-0,orleans-3-x"

Orleans Journaling with `DurableGrain` is a feature introduced in Orleans 10.0. For earlier versions, consider using:

- **[JournaledGrain](../event-sourcing/index.md)**: Event sourcing with `JournaledGrain<TState, TEvent>` for explicit event-based state management.
- **[Grain persistence](../grain-persistence/index.md)**: Traditional state persistence with snapshot-based storage.

:::zone-end
<!-- markdownlint-enable MD044 -->
