---
title: System.Diagnostics.Tracing.EventSource class
description: Learn about the System.Diagnostics.Tracing.EventSource class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Diagnostics.Tracing.EventSource class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Diagnostics.Tracing.EventSource> class is intended to be inherited by a user class that provides specific events to be used for event tracing. The <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A?displayProperty=nameWithType> methods are called to log the events.

The basic functionality of <xref:System.Diagnostics.Tracing.EventSource> is sufficient for most applications. If you want more control over the event metadata that's created, you can apply the <xref:System.Diagnostics.Tracing.EventAttribute> attribute to the methods. For advanced event source applications, it is possible to intercept the commands being sent to the derived event source and change the filtering, or to cause actions (such as dumping a data structure) to be performed by the inheritor. An event source can be activated in-process using <xref:System.Diagnostics.Tracing.EventListener> and out-of-process using EventPipe-based tools such as `dotnet-trace` or Event Tracing for Windows (ETW) based tools like `PerfView` or `Logman`. It is also possible to programmatically control and intercept the data dispatcher. The <xref:System.Diagnostics.Tracing.EventListener> class provides additional functionality.

## Conventions

<xref:System.Diagnostics.Tracing.EventSource>-derived classes should follow the following conventions:

- User-defined classes should implement a singleton pattern. The singleton instance is traditionally named `Log`. By extension, users should not call `IDisposable.Dispose` manually and allow the runtime to clean up the singleton instance at the end of managed code execution.
- A user-defined, derived class should be marked as `sealed` unless it implements the advanced "Utility EventSource" configuration discussed in the Advanced Usage section.
- Call <xref:System.Diagnostics.Tracing.EventSource.IsEnabled> before performing any resource intensive work related to firing an event.
- You can implicitly create <xref:System.Diagnostics.Tracing.EventTask> objects by declaring two event methods with subsequent event IDs that have the naming pattern `<EventName>Start` and `<EventName>Stop`. These events _must_ be declared next to each other in the class definition and the `<EventName>Start` method _must_ come first.
- Attempt to keep <xref:System.Diagnostics.Tracing.EventSource> objects backwards compatible and version them appropriately. The default version for an event is `0`. The version can be can be changed by setting <xref:System.Diagnostics.Tracing.EventAttribute.Version>. Change the version of an event whenever you change properties of the payload. Always add new payload properties to the end of the event declaration. If this is not possible, create a new event with a new ID to replace the old one.
- When declaring event methods, specify fixed-size payload properties before variably sized properties.
- <xref:System.Diagnostics.Tracing.EventKeywords> are used as a bit mask for specifying specific events when subscribing to a provider. You can specify keywords by defining a `public static class Keywords` member class that has `public const EventKeywords` members.
- Associate expensive events with an <xref:System.Diagnostics.Tracing.EventKeywords> using <xref:System.Diagnostics.Tracing.EventAttribute>. This pattern allows users of your <xref:System.Diagnostics.Tracing.EventSource> to opt out of these expensive operations.

## Self-describing (tracelogging) vs. manifest event formats

<xref:System.Diagnostics.Tracing.EventSource> can be configured into to two different modes based on the constructor used or what flags are set on <xref:System.Diagnostics.Tracing.EventSourceOptions>.

Historically, these two formats are derived from two formats that Event Tracing for Windows (ETW) used. While these two modes don't affect your ability to use Event Tracing for Windows (ETW) or EventPipe-based listeners, they do generate the metadata for events differently.

The default event format is <xref:System.Diagnostics.Tracing.EventSourceSettings.EtwManifestEventFormat>, which is set if not specified on <xref:System.Diagnostics.Tracing.EventSourceSettings>. Manifest-based <xref:System.Diagnostics.Tracing.EventSource> objects generate an XML document representing the events defined on the class upon initialization. This requires the <xref:System.Diagnostics.Tracing.EventSource> to reflect over itself to generate the provider and event metadata.

To use self-describing (tracelogging) event format, construct your <xref:System.Diagnostics.Tracing.EventSource> using the <xref:System.Diagnostics.Tracing.EventSource.%23ctor(System.String)> constructor, the <xref:System.Diagnostics.Tracing.EventSource.%23ctor(System.String,System.Diagnostics.Tracing.EventSourceSettings)> constructor, or by setting the `EtwSelfDescribingEventFormat` flag on <xref:System.Diagnostics.Tracing.EventSourceSettings>. Self-describing sources generate minimal provider metadata on initialization and only generate event metadata when <xref:System.Diagnostics.Tracing.EventSource.Write(System.String)> is called. Unlike the manifest-based format, it does not include additional metadata derived from attributes such as <xref:System.Diagnostics.Tracing.EventAttribute>. For example, properties like EventId, Level, Keywords, or Message specified in EventAttribute are not transmitted with the event.

In practice, these event format settings only affect usage with readers based on Event Tracing for Windows (ETW). They can, however, have a small effect on initialization time and per-event write times due to the time required for reflection and generating the metadata.

## Examples

The following example shows a simple implementation of the <xref:System.Diagnostics.Tracing.EventSource> class.

:::code language="csharp" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/csharp/program.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/vb/program.vb" id="Snippet1":::

The following example shows a more complex implementation of the <xref:System.Diagnostics.Tracing.EventSource> class.

:::code language="csharp" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/csharp/program1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/vb/program1.vb" id="Snippet1":::

## Advanced usage

Traditionally, user-defined <xref:System.Diagnostics.Tracing.EventSource> objects expect to inherit directly from <xref:System.Diagnostics.Tracing.EventSource>. For advanced scenarios, however, you can create `abstract` <xref:System.Diagnostics.Tracing.EventSource> objects, called _Utility Sources_, and implement interfaces. Using one or both of these techniques allows you to share code between different derived sources.

> [!IMPORTANT]
> Abstract <xref:System.Diagnostics.Tracing.EventSource> objects cannot define keywords, tasks, opcodes, channels, or events.

> [!IMPORTANT]
> To avoid name collisions at run time when generating event metadata, don't explicitly implement interface methods when using interfaces with <xref:System.Diagnostics.Tracing.EventSource>.

The following example shows an implementation of <xref:System.Diagnostics.Tracing.EventSource> that uses an interface.

:::code language="csharp" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/csharp/program2.cs" id="InterfaceSource":::

The following example shows an implementation of <xref:System.Diagnostics.Tracing.EventSource> that uses the Utility EventSource pattern.

:::code language="csharp" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/csharp/program2.cs" id="UtilitySource":::

The following example shows an implementation of <xref:System.Diagnostics.Tracing.EventSource> for tracing information about a component in a library.

:::code language="csharp" source="./snippets/System.Diagnostics.Tracing/EventSource/Overview/csharp/program2.cs" id="ComplexSource":::
