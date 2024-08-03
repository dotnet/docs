---
title: Immediate and delayed confirmation
description: Learn the differences between immediate and delayed confirmation in .NET Orleans.
ms.date: 07/03/2024
---

# Immediate and delayed confirmations

In this article, you'll learn the differences between immediate and delayed confirmations.

## Immediate confirmation

For many applications, we want to ensure that events are confirmed immediately, so that the persisted version does not lag behind the current version in memory, and we do not risk losing the latest state if the grain should fail. We can guarantee this by following these rules:

1. Confirm all <xref:Orleans.EventSourcing.JournaledGrain%602.RaiseEvent%2A> calls using <xref:Orleans.EventSourcing.JournaledGrain%602.ConfirmEvents%2A> before the grain method returns.
1. Make sure tasks returned by <xref:Orleans.EventSourcing.JournaledGrain%602.RaiseConditionalEvent%2A> complete before the grain method returns.
1. Avoid <xref:Orleans.Concurrency.ReentrantAttribute> or <xref:Orleans.Concurrency.AlwaysInterleaveAttribute> attributes, so only one grain call can be processed at a time.

If we follow these rules, it means that after an event is raised, no other grain code can execute until the event has been written to storage. Therefore, it is impossible to observe inconsistencies between the version in memory and the version in storage. While this is often exactly what we want, it also has some potential disadvantages.

### Potential disadvantages

* If the connection to a remote cluster or storage is temporarily interrupted, then the grain becomes unavailable: effectively, the grain cannot execute any code while it is stuck waiting to confirm the events, which can take an indefinite amount of time (the log-consistency protocol keeps retrying until storage connectivity is restored).

* When handling a lot of updates to a single grain instance, confirming them one at a time can become very inefficient, for example, causing poor throughput.

## Delayed confirmation

To improve availability and throughput in the situations mentioned above, grains can choose to do one or both of the following:

* Allow grain methods to raise events without waiting for confirmation.
* Allow reentrancy, so the grain can keep processing new calls even if previous calls get stuck waiting for confirmation.

This means grain code can execute while some events are still in the process of being confirmed. The <xref:Orleans.EventSourcing.JournaledGrain%602> API has some specific provisions to give developers precise control over how to deal with unconfirmed events that are currently _in flight_.

The following property can be examined to find out what events are currently unconfirmed:

```csharp
IEnumerable<EventType> UnconfirmedEvents { get; }
```

Also, since the state returned by the <xref:Orleans.EventSourcing.JournaledGrain%602.State%2A?displayProperty=nameWithType> property does not include the effect of unconfirmed events, there is an alternative property

```csharp
StateType TentativeState { get; }
```

Which returns a "tentative" state, obtained from "State" by applying all the unconfirmed events. The tentative state is essentially a "best guess" at what will likely become the next confirmed state after all unconfirmed events are confirmed. However, there is no guarantee that it actually will, because the grain may fail, or because the events may race against other events and lose, causing them to be canceled (if they are conditional) or appear at a later position in the sequence than anticipated (if they are unconditional).

## Concurrency guarantees

Note that Orleans turn-based scheduling (cooperative concurrency) guarantees always apply, even when using reentrancy or delayed confirmation. This means that even though several methods may be in progress, only one can be actively executing&mdash;all others are stuck at an await, so there are never any true races caused by parallel threads.

In particular, note that:

* The properties <xref:Orleans.EventSourcing.JournaledGrain%602.State%2A>, <xref:Orleans.EventSourcing.JournaledGrain%602.TentativeState>, <xref:Orleans.EventSourcing.JournaledGrain%602.Version%2A>, and <xref:Orleans.EventSourcing.JournaledGrain%602.UnconfirmedEvents%2A> can change during the execution of a method.
* But such changes can only happen while stuck at an await.

These guarantees assume that the user code stays within the [recommended practice](../external-tasks-and-grains.md) concerning tasks and async/await (in particular, does not use thread pool tasks, or only uses them for code that does not call grain functionality and that are properly awaited).
