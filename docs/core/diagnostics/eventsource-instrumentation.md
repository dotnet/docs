---
title: Instrument Code to Create EventSource Events
description: A tutorial for instrumenting code with EventSource
ms.date: 03/03/2022
---

# Instrument Code to Create EventSource Events

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

The [Getting Started guide](./eventsource-getting-started.md) showed you how to create a minimal EventSource and collect events in a trace file.
This tutorial goes into more detail about creating events using <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType>.

## A minimal EventSource

```C#
[EventSource(Name = "Demo")]
class DemoEventSource : EventSource
{
    public static DemoEventSource Log { get; } = new DemoEventSource();

    [Event(1)]
    public void AppStarted(string message, int favoriteNumber) => WriteEvent(1, message, favoriteNumber);
}
```

The basic structure of a derived EventSource is always the same. In particular:

- The class inherits from <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType>
- For each different type of event you wish to generate, a method needs to be defined.
  This method should be named using the name of the event being created. If the event has additional data these should be
  passed using arguments. These event arguments need to be serialized so only [certain types](#supported-parameter-types) are allowed.
- Each method has a body that calls WriteEvent passing it an ID (a numeric value that represents the event) and the
  arguments of the event method. The ID needs to be unique within the EventSource. The ID is explicitly assigned
  using the <xref:System.Diagnostics.Tracing.EventAttribute?displayProperty=nameWithType>
- EventSources are intended to be singleton instances. Thus it's convenient to define a static variable, by convention
  called `Log`, that represents this singleton.

## Rules for defining event methods

1. Any instance, non-virtual, void returning method defined in an EventSource class is by default an event logging method.
2. Virtual or non-void-returning methods are included only if they're marked with the
<xref:System.Diagnostics.Tracing.EventAttribute?displayProperty=nameWithType>
3. To mark a qualifying method as non-logging you must decorate it with the
<xref:System.Diagnostics.Tracing.NonEventAttribute?displayProperty=nameWithType>
4. Event logging methods have event IDs associated with them. This can be done either explicitly by decorating the method
with a <xref:System.Diagnostics.Tracing.EventAttribute?displayProperty=nameWithType> or implicitly by the ordinal number of
the method in the class. For example using implicit numbering the first method in the class has ID 1, the second has ID 2, and
so on.
5. Event logging methods must call a <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A>,
<xref:System.Diagnostics.Tracing.EventSource.WriteEventCore%2A>,
<xref:System.Diagnostics.Tracing.EventSource.WriteEventWithRelatedActivityId%2A> or
<xref:System.Diagnostics.Tracing.EventSource.WriteEventWithRelatedActivityIdCore%2A> overload.
6. The event ID, whether implied or explicit, must match the first argument passed to the WriteEvent\* API it calls.
7. The number, types and order of arguments passed to the EventSource method must align with how they're passed
to the WriteEvent\* APIs. For WriteEvent the arguments follow the Event ID, for WriteEventWithRelatedActivityId the arguments
follow the relatedActivityId. For the WriteEvent\*Core methods, the arguments must be serialized manually into the
`data` parameter.
8. Event names cannot contain `<` or `>` characters. While user-defined methods also cannot contain these characters, `async` methods
will be rewritten by the compiler to contain them. To be sure these generated methods don't become events, mark all non-event methods on an <xref:System.Diagnostics.Tracing.EventSource>
with the <xref:System.Diagnostics.Tracing.NonEventAttribute>.

## Best practices

1. Types that derive from EventSource usually don't have intermediate types in the hierarchy or implement interfaces. See
[Advanced customizations](#advanced-customizations) below for some exceptions where this may be useful.
2. Generally the name of the EventSource class is a bad public name for the EventSource. Public names, the names that will
show up in logging configurations and log viewers, should be globally unique. Thus it's good practice to give your EventSource
a public name using the <xref:System.Diagnostics.Tracing.EventSourceAttribute?displayProperty=nameWithType>. The name "Demo"
used above is short and unlikely to be unique so not a good choice for production use. A common convention is to use a
hierarchical name with `.` or `-` as a separator, such as "MyCompany-Samples-Demo", or the name of the Assembly or namespace for
which the EventSource provides events. It's not recommended to include "EventSource" as part of the public name.
3. Assign Event IDs explicitly, this way seemingly benign changes to the code in the source class such as rearranging it or
adding a method in the middle won't change the event ID associated with each method.
4. When authoring events that represent the start and end of a unit of work, by convention these methods are named with
suffixes 'Start' and 'Stop'. For example, 'RequestStart' and 'RequestStop'.
5. Do not specify an explicit value for EventSourceAttribute’s Guid property, unless you need it for backwards compatibility reasons.
The default Guid value is derived from the source’s name, which allows tools to accept the more human-readable name and derive
the same Guid.
6. Call <xref:System.Diagnostics.Tracing.EventSource.IsEnabled> before performing any resource intensive work related to
firing an event, such as computing an expensive event argument that won't be needed if the event is disabled.
7. Attempt to keep EventSource object back compatible and version them appropriately. The default version for an event is 0.
The version can be changed by setting <xref:System.Diagnostics.Tracing.EventAttribute.Version%2A?displayProperty=nameWithType>.
Change the version of an event whenever you change the data that is serialized with it. Always add new serialized data to the
end of the event declaration, that is, at the end of the list of method parameters. If this isn't possible, create a new event with a
new ID to replace the old one.
8. When declaring events methods, specify fixed-size payload data before variably sized data.
9. Do not use strings containing null characters. When generating the manifest for ETW EventSource will declare all strings as null terminated, even though it is possible to have a null character in a C# String. If a string contains a null character the entire string will be written to the event payload, but any parser will treat the first null character as the end of the string. If there are payload arguments after the string, the remainder of the string will be parsed instead of the intended value.

## Typical event customizations

### Setting event verbosity levels

Each event has a verbosity level and event subscribers often enable all events on an EventSource up to a certain verbosity level.
Events declare their verbosity level using the <xref:System.Diagnostics.Tracing.EventAttribute.Level> property. For example in
this EventSource below a subscriber that requests events of level Informational and lower won't log the Verbose DebugMessage
event.

```C#
[EventSource(Name = "MyCompany-Samples-Demo")]
class DemoEventSource : EventSource
{
    public static DemoEventSource Log { get; } = new DemoEventSource();

    [Event(1, Level = EventLevel.Informational)]
    public void AppStarted(string message, int favoriteNumber) => WriteEvent(1, message, favoriteNumber);
    [Event(2, Level = EventLevel.Verbose)]
    public void DebugMessage(string message) => WriteEvent(2, message);
}
```

If the verbosity level of an event is not specified in the EventAttribute, then it defaults to Informational.

#### Best practice

Use levels less than Informational for relatively rare warnings or errors. When in doubt, stick with the default of Informational and
use Verbose for events that occur more frequently than 1000 events/sec.

### Setting event keywords

Some event tracing systems support keywords as an additional filtering mechanism. Unlike verbosity that categorizes events by level
of detail, keywords are intended to categorize events based on other criteria such as areas of code functionality or which would be useful
for diagnosing certain problems. Keywords are named bit flags and each event can have any combination of keywords applied to it. For
example the EventSource below defines some events that relate to request processing and other events that relate to startup. If a developer wanted to analyze the performance of startup, they might only enable logging the events marked with the startup keyword.

```C#
[EventSource(Name = "Demo")]
class DemoEventSource : EventSource
{
    public static DemoEventSource Log { get; } = new DemoEventSource();

    [Event(1, Keywords = Keywords.Startup)]
    public void AppStarted(string message, int favoriteNumber) => WriteEvent(1, message, favoriteNumber);
    [Event(2, Keywords = Keywords.Requests)]
    public void RequestStart(int requestId) => WriteEvent(2, requestId);
    [Event(3, Keywords = Keywords.Requests)]
    public void RequestStop(int requestId) => WriteEvent(3, requestId);

    public class Keywords   // This is a bitvector
    {
        public const EventKeywords Startup = (EventKeywords)0x0001;
        public const EventKeywords Requests = (EventKeywords)0x0002;
    }
}
```

Keywords must be defined by using a nested class called `Keywords` and each individual keyword is defined by a member typed
`public const EventKeywords`.

#### Best practice

Keywords are more important when distinguishing between high volume events. This allows an event consumer to raise the
verbosity to a high level but manage the performance overhead and log size by only enabling narrow subsets of the events.
Events that are triggered more than 1,000/sec are good candidates for a unique keyword.

## Supported parameter types

EventSource requires that all event parameters can be serialized so it only accepts a limited set of types. These are:

- Primitives: bool, byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, IntPtr, and UIntPtr, Guid
  decimal, string,  DateTime, DateTimeOffset, TimeSpan
- Enums
- Structures attributed with <xref:System.Diagnostics.Tracing.EventDataAttribute?displayProperty=nameWithType>. Only
  the public instance properties with serializable types will be serialized.
- Anonymous types where all public properties are serializable types
- Arrays of serializable types
- Nullable\<T\> where T is a serializable type
- KeyValuePair\<T, U\> where T and U are both serializable types
- Types that implement IEnumerable\<T\> for exactly one type T and where T is a serializable type

## Troubleshooting

The EventSource class was designed so that it would never throw an Exception by default. This is a useful property, as
logging is often treated as optional, and you usually don't want an error writing a log message to cause your application
to fail. However, this makes finding any mistake in your EventSource difficult. Here are several techniques that can help
troubleshoot:

1. The EventSource constructor has overloads that take <xref:System.Diagnostics.Tracing.EventSourceSettings>. Try
enabling the ThrowOnEventWriteErrors flag temporarily.
2. The <xref:System.Diagnostics.Tracing.EventSource.ConstructionException?displayProperty=nameWithType> property
stores any Exception that was generated when validating the event logging methods. This can reveal various
authoring errors.
3. EventSource logs errors using event ID 0, and this error event has a string describing the error.
4. When debugging, that same error string will also be logged using Debug.WriteLine() and show up in the debug
output window.
5. EventSource internally throws and then catches exceptions when errors occur. To observe when these exceptions are occurring, enable first chance exceptions
in a debugger, or use event tracing with the .NET runtime's [Exception events](../../fundamentals/diagnostics/runtime-exception-events.md) enabled.

## Advanced customizations

### Setting OpCodes and Tasks

ETW has concepts of [Tasks and OpCodes](/windows/win32/wes/defining-tasks-and-opcodes),
which are further mechanisms for tagging and filtering events. You can associate events with specific tasks and opcodes
using the <xref:System.Diagnostics.Tracing.EventAttribute.Task%2A> and
<xref:System.Diagnostics.Tracing.EventAttribute.Opcode%2A> properties. Here's an example:

```C#
[EventSource(Name = "Samples-EventSourceDemos-Customized")]
public sealed class CustomizedEventSource : EventSource
{
    static public CustomizedEventSource Log { get; } = new CustomizedEventSource();

    [Event(1, Task = Tasks.Request, Opcode=EventOpcode.Start)]
    public void RequestStart(int RequestID, string Url)
    {
        WriteEvent(1, RequestID, Url);
    }

    [Event(2, Task = Tasks.Request, Opcode=EventOpcode.Info)]
    public void RequestPhase(int RequestID, string PhaseName)
    {
        WriteEvent(2, RequestID, PhaseName);
    }

    [Event(3, Keywords = Keywords.Requests,
           Task = Tasks.Request, Opcode=EventOpcode.Stop)]
    public void RequestStop(int RequestID)
    {
        WriteEvent(3, RequestID);
    }

    public class Tasks
    {
        public const EventTask Request = (EventTask)0x1;
    }
}
```

You can implicitly create EventTask objects by declaring two event methods with subsequent event IDs that have the naming
pattern \<EventName\>Start and \<EventName\>Stop. These events must be declared next to each other in the class definition and
the \<EventName\>Start method must come first.

### Self-describing (tracelogging) vs. manifest event formats

This concept only matters when subscribing to EventSource from ETW. ETW has two different ways that it can log events,
manifest format and self-describing (sometimes called tracelogging) format. Manifest-based EventSource objects generate
and log an XML document representing the events defined on the class upon initialization. This requires the EventSource
to reflect over itself to generate the provider and event metadata. In the Self-describing format metadata for each event is
transmitted inline with the event data rather than up-front. The self-describing approach supports the more flexible
<xref:System.Diagnostics.Tracing.EventSource.Write%2A> methods that can send arbitrary events without having created
a pre-defined event logging method. It's also slightly faster at startup because it avoids eager reflection. However the
extra metadata that's emitted with each event adds a small performance overhead, which may not be desirable when sending
a high volume of events.

To use self-describing event format, construct your EventSource using the EventSource(String) constructor, the
EventSource(String, EventSourceSettings) constructor, or by setting the EtwSelfDescribingEventFormat flag on EventSourceSettings.

### EventSource types implementing interfaces

An EventSource type may implement an interface in order to integrate seamlessly in various advanced logging
systems that use interfaces to define a common logging target. Here's an example of a possible use:

```C#
public interface IMyLogging
{
    void Error(int errorCode, string msg);
    void Warning(string msg);
}

[EventSource(Name = "Samples-EventSourceDemos-MyComponentLogging")]
public sealed class MyLoggingEventSource : EventSource, IMyLogging
{
    public static MyLoggingEventSource Log { get; } = new MyLoggingEventSource();

    [Event(1)]
    public void Error(int errorCode, string msg)
    { WriteEvent(1, errorCode, msg); }

    [Event(2)]
    public void Warning(string msg)
    { WriteEvent(2, msg); }
}
```

You must specify the EventAttribute on the interface methods, otherwise (for compatibility reasons) the method won't
be treated as a logging method. Explicit interface method implementation is disallowed in order to prevent naming collisions.

### EventSource class hierarchies

In most cases, you'll be able to write types that directly derive from the EventSource class. Sometimes however it's useful to define functionality that will be shared by multiple derived EventSource types, such as customized WriteEvent
overloads (see [optimizing performance for high volume events](#optimizing-performance-for-high-volume-events) below).

Abstract base classes can be used as long as they don't define any keywords, tasks, opcodes, channels, or events. Here's
an example where the UtilBaseEventSource class defines an optimized WriteEvent overload this is needed by multiple derived
EventSources in the same component. One of these derived types is illustrated below as OptimizedEventSource.

```C#
public abstract class UtilBaseEventSource : EventSource
{
    protected UtilBaseEventSource()
        : base()
    { }
    protected UtilBaseEventSource(bool throwOnEventWriteErrors)
        : base(throwOnEventWriteErrors)
    { }

    protected unsafe void WriteEvent(int eventId, int arg1, short arg2, long arg3)
    {
        if (IsEnabled())
        {
            EventSource.EventData* descrs = stackalloc EventSource.EventData[2];
            descrs[0].DataPointer = (IntPtr)(&arg1);
            descrs[0].Size = 4;
            descrs[1].DataPointer = (IntPtr)(&arg2);
            descrs[1].Size = 2;
            descrs[2].DataPointer = (IntPtr)(&arg3);
            descrs[2].Size = 8;
            WriteEventCore(eventId, 3, descrs);
        }
    }
}

[EventSource(Name = "OptimizedEventSource")]
public sealed class OptimizedEventSource : UtilBaseEventSource
{
    public static OptimizedEventSource Log { get; } = new OptimizedEventSource();

    [Event(1, Keywords = Keywords.Kwd1, Level = EventLevel.Informational,
           Message = "LogElements called {0}/{1}/{2}.")]
    public void LogElements(int n, short sh, long l)
    {
        WriteEvent(1, n, sh, l); // Calls UtilBaseEventSource.WriteEvent
    }

    #region Keywords / Tasks /Opcodes / Channels
    public static class Keywords
    {
        public const EventKeywords Kwd1 = (EventKeywords)1;
    }
    #endregion
}
```

## Optimizing performance for high volume events

The EventSource class has a number of overloads for WriteEvent, including one for variable number of arguments. When none of the other
overloads match, the params method is called. Unfortunately, the params overload is relatively expensive. In particular it:

1. Allocates an array to hold the variable arguments.
2. Casts each parameter to an object, which causes allocations for value types.
3. Assigns these objects to the array.
4. Calls the function.
5. Figures out the type of each array element to determine how to serialize it.

This is probably 10 to 20 times as expensive as specialized types. This doesn't matter much for low volume cases, but for high
volume events it can be important. There are two important cases for insuring that the params overload isn't used:

1. Ensure that enumerated types are cast to 'int' so that they match one of the fast overloads.
2. Create new fast WriteEvent overloads for high volume payloads.

Here's an example for adding a WriteEvent overload that takes four integer arguments

```C#
[NonEvent]
public unsafe void WriteEvent(int eventId, int arg1, int arg2,
                              int arg3, int arg4)
{
    EventData* descrs = stackalloc EventProvider.EventData[4];

    descrs[0].DataPointer = (IntPtr)(&arg1);
    descrs[0].Size = 4;
    descrs[1].DataPointer = (IntPtr)(&arg2);
    descrs[1].Size = 4;
    descrs[2].DataPointer = (IntPtr)(&arg3);
    descrs[2].Size = 4;
    descrs[3].DataPointer = (IntPtr)(&arg4);
    descrs[3].Size = 4;

    WriteEventCore(eventId, 4, (IntPtr)descrs);
}
```
