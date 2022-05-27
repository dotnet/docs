---
title: EventSource Activity IDs
description: Understand how to use EventSource Activity IDs
ms.date: 03/24/2022
---

# EventSource Activity IDs

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

This guide explains Activity IDs, an optional identifier that can be logged with each event generated using
<xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType>. For an introduction, see
[Getting Started with EventSource](./eventsource-getting-started.md).

## The challenge of logging concurrent work

Long ago, a typical application may have been simple and single-threaded, which makes logging straightforward. You
could write each step to a log file in order and then read the log back exactly in the order it was written to
understand what happened. If the app handled requests then only one request was handled at a time. All log
messages for request A would be printed in order, then all the messages for B, and so on.
When apps become multi-threaded that strategy no longer works because multiple
requests are being handled at the same time. However if each request is assigned to a single thread that processes
it entirely, you can solve the problem by recording a thread ID for each log message. For example, a multi-threaded app
might log:

```txt
Thread Id      Message
---------      -------
12             BeginRequest A
12             Doing some work
190            BeginRequest B
12             uh-oh error happened
190            Doing some work
```

By reading the thread IDs you know that thread 12 was processing request A and thread 190 was processing request B,
therefore the 'uh-oh error happened' message related to request A. However application concurrency has continued to
grow ever more sophisticated. It's now common to use `async` and `await` so that a single request could
be handled partially on many different threads before the work is complete. Thread IDs are no longer sufficient to
correlate together all the messages produced for one request. Activity IDs solve this problem. They provide a finer
grain identifier that can track individual requests, or portions of requests, regardless of if the work
is spread across different threads.

> [!NOTE]
> The Activity ID concept referred to here is not the same as the System.Diagnostics.Tracing.Activity, despite the
> similar naming.

## Tracking work using an Activity ID

You can run the code below to see Activity tracking in action.

```C#
using System.Diagnostics.Tracing;

public static class Program
{
    public static async Task Main(string[] args)
    {
        ConsoleWriterEventListener listener = new ConsoleWriterEventListener();

        Task a = ProcessWorkItem("A");
        Task b = ProcessWorkItem("B");
        await Task.WhenAll(a, b);
    }

    private static async Task ProcessWorkItem(string requestName)
    {
        DemoEventSource.Log.WorkStart(requestName);
        await HelperA();
        await HelperB();
        DemoEventSource.Log.WorkStop();
    }

    private static async Task HelperA()
    {
        DemoEventSource.Log.DebugMessage("HelperA");
        await Task.Delay(100); // pretend to do some work
    }

    private static async Task HelperB()
    {
        DemoEventSource.Log.DebugMessage("HelperB");
        await Task.Delay(100); // pretend to do some work
    }
}

[EventSource(Name ="Demo")]
class DemoEventSource : EventSource
{
    public static DemoEventSource Log = new DemoEventSource();

    [Event(1)]
    public void WorkStart(string requestName) => WriteEvent(1, requestName);
    [Event(2)]
    public void WorkStop() => WriteEvent(2);

    [Event(3)]
    public void DebugMessage(string message) => WriteEvent(3, message);
}

class ConsoleWriterEventListener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if(eventSource.Name == "Demo")
        {
            Console.WriteLine("{0,-5} {1,-40} {2,-15} {3}", "TID", "Activity ID", "Event", "Arguments");
            EnableEvents(eventSource, EventLevel.Verbose);
        }
        else if(eventSource.Name == "System.Threading.Tasks.TplEventSource")
        {
            // Activity IDs aren't enabled by default.
            // Enabling Keyword 0x80 on the TplEventSource turns them on
            EnableEvents(eventSource, EventLevel.LogAlways, (EventKeywords)0x80);
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        lock (this)
        {
            Console.Write("{0,-5} {1,-40} {2,-15} ", eventData.OSThreadId, eventData.ActivityId, eventData.EventName);
            if (eventData.Payload.Count == 1)
            {
                Console.WriteLine(eventData.Payload[0]);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
```

When run, this code prints output:

```
TID   Activity ID                              Event           Arguments
21256 00000011-0000-0000-0000-00006ab99d59     WorkStart       A
21256 00000011-0000-0000-0000-00006ab99d59     DebugMessage    HelperA
21256 00000012-0000-0000-0000-00006bb99d59     WorkStart       B
21256 00000012-0000-0000-0000-00006bb99d59     DebugMessage    HelperA
14728 00000011-0000-0000-0000-00006ab99d59     DebugMessage    HelperB
11348 00000012-0000-0000-0000-00006bb99d59     DebugMessage    HelperB
11348 00000012-0000-0000-0000-00006bb99d59     WorkStop
14728 00000011-0000-0000-0000-00006ab99d59     WorkStop
```

> [!NOTE]
> There is a known issue where Visual Studio debugger may cause invalid Activity IDs to be generated. Either don't run this sample under the debugger
> or set a breakpoint at the beginning of Main and evaluate the expression 'System.Threading.Tasks.TplEventSource.Log.TasksSetActivityIds = false' in
> the immediate window before continuing to work around the issue.

Using the Activity IDs you can see that all of the messages for work item A have ID `00000011-...` and all the messages for
work item B have ID `00000012-...`. Both work items first did some work on thread 21256, but then each of them continued their work
on separate threadpool threads 11348 and 14728 so trying to track the request only with thread IDs wouldn't have worked.

EventSource has an automatic heuristic where defining an event named _Something_Start followed immediately by another event named
_Something_Stop is considered the start and stop of a unit of work. Logging the start event for a new unit of work creates a new
Activity ID and begins logging all events on the same thread with that Activity ID until the stop event is logged. The ID also
automatically follows async control flow when using `async` and `await`. Although we recommend that you use the Start/Stop naming suffixes,
you may name the events anything you like by explicitly annotating them using the
<xref:System.Diagnostics.Tracing.EventAttribute.Opcode?displayProperty=nameWithType> property. Set the first event to
`EventOpcode.Start` and the second to `EventOpcode.Stop`.

## Log requests that do parallel work

Sometimes a single request might do different parts of its work in parallel, and you want to group all the log events
and the subparts. The example below simulates a request that does two database queries in parallel and then does some
processing on the result of each query. You want to isolate the work for each query, but also understand which queries belong
to the same request when many concurrent requests could be running. This is modeled as a tree where each top-level request is a root and
then subportions of work are branches. Each node in the tree gets its own Activity ID, and the first event logged with the new child
Activity ID logs an extra field called Related Activity ID to describe its parent.

Run the following code:

```C#
using System.Diagnostics.Tracing;

public static class Program
{
    public static async Task Main(string[] args)
    {
        ConsoleWriterEventListener listener = new ConsoleWriterEventListener();

        await ProcessWorkItem("A");
    }

    private static async Task ProcessWorkItem(string requestName)
    {
        DemoEventSource.Log.WorkStart(requestName);
        Task query1 = Query("SELECT bowls");
        Task query2 = Query("SELECT spoons");
        await Task.WhenAll(query1, query2);
        DemoEventSource.Log.WorkStop();
    }

    private static async Task Query(string query)
    {
        DemoEventSource.Log.QueryStart(query);
        await Task.Delay(100); // pretend to send a query
        DemoEventSource.Log.DebugMessage("processing query");
        await Task.Delay(100); // pretend to do some work
        DemoEventSource.Log.QueryStop();
    }
}

[EventSource(Name = "Demo")]
class DemoEventSource : EventSource
{
    public static DemoEventSource Log = new DemoEventSource();

    [Event(1)]
    public void WorkStart(string requestName) => WriteEvent(1, requestName);
    [Event(2)]
    public void WorkStop() => WriteEvent(2);
    [Event(3)]
    public void DebugMessage(string message) => WriteEvent(3, message);
    [Event(4)]
    public void QueryStart(string query) => WriteEvent(4, query);
    [Event(5)]
    public void QueryStop() => WriteEvent(5);
}

class ConsoleWriterEventListener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name == "Demo")
        {
            Console.WriteLine("{0,-5} {1,-40} {2,-40} {3,-15} {4}", "TID", "Activity ID", "Related Activity ID", "Event", "Arguments");
            EnableEvents(eventSource, EventLevel.Verbose);
        }
        else if (eventSource.Name == "System.Threading.Tasks.TplEventSource")
        {
            // Activity IDs aren't enabled by default.
            // Enabling Keyword 0x80 on the TplEventSource turns them on
            EnableEvents(eventSource, EventLevel.LogAlways, (EventKeywords)0x80);
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        lock (this)
        {
            Console.Write("{0,-5} {1,-40} {2, -40} {3,-15} ", eventData.OSThreadId, eventData.ActivityId, eventData.RelatedActivityId, eventData.EventName);
            if (eventData.Payload.Count == 1)
            {
                Console.WriteLine(eventData.Payload[0]);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
```

This example prints output such as:

```txt
TID   Activity ID                              Related Activity ID                      Event           Arguments
34276 00000011-0000-0000-0000-000086af9d59     00000000-0000-0000-0000-000000000000     WorkStart       A
34276 00001011-0000-0000-0000-0000869f9d59     00000011-0000-0000-0000-000086af9d59     QueryStart      SELECT bowls
34276 00002011-0000-0000-0000-0000868f9d59     00000011-0000-0000-0000-000086af9d59     QueryStart      SELECT spoons
32684 00002011-0000-0000-0000-0000868f9d59     00000000-0000-0000-0000-000000000000     DebugMessage    processing query
18624 00001011-0000-0000-0000-0000869f9d59     00000000-0000-0000-0000-000000000000     DebugMessage    processing query
18624 00002011-0000-0000-0000-0000868f9d59     00000000-0000-0000-0000-000000000000     QueryStop
32684 00001011-0000-0000-0000-0000869f9d59     00000000-0000-0000-0000-000000000000     QueryStop
32684 00000011-0000-0000-0000-000086af9d59     00000000-0000-0000-0000-000000000000     WorkStop
```

This example only ran one top-level request, which was assigned Activity ID `00000011-...`. Then each `QueryStart` event began
a new branch of the request with Activity IDs `00001011-...` and `00002011-...` respectively. You can identify these IDs are
children of the original request because both of the start events logged their parent `00000011-...` in the Related Activity ID field.

> [!NOTE]
> You may have noticed the numerical values of the IDs have some clear patterns between parent and child and aren't random. Although it
> can assist in spotting the relationship visually in simple cases, it's best for tools not to rely on this and treat the IDs as opaque identifiers.
> As the nesting level grows deeper, the byte pattern will change. Using the Related Activity ID field is the best way to ensure tools
> work reliably regardless of nesting level.

Because requests with complex trees of subwork items will generate many different Activity IDs, these IDs are usually
best parsed by tools rather than trying to reconstruct the tree by hand. [PerfView](https://github.com/Microsoft/perfview) is one tool
that knows how to correlate events annotated with these IDs.
