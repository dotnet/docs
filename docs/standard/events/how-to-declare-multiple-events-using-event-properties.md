---
title: "Declare multiple events using event properties"
description: Learn how to declare many events by using event properties. Define delegate collections, event keys, and event properties. Implement add and remove accessor methods.
ms.date: 03/25/2026
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "event properties [.NET]"
  - "multiple events [.NET]"
  - "event handling [.NET], with multiple events"
  - "events [.NET], multiple"
ai-usage: ai-assisted
---

# Declare multiple events using event properties

When a class defines many events using field-like event declarations, the compiler generates a backing field for each one. Every instance of that class allocates memory for all of those fields—even for events that are never subscribed. With many events, this per-instance overhead wastes memory.

To avoid this memory overhead, use event properties backed by a delegate collection. The collection must provide methods that set, access, and retrieve delegates by event key. <xref:System.ComponentModel.EventHandlerList> is designed for this purpose, but you can also use a <xref:System.Collections.Hashtable> or a class derived from <xref:System.Collections.DictionaryBase>. Keep the collection's implementation details private.

Each event property defines an add accessor and a remove accessor. The add accessor adds the input delegate to the delegate collection, and the remove accessor removes it. Both accessors use a predefined key to add and remove instances from the collection.

## Prerequisites

Familiarize yourself with the concepts in the [Events](index.md) article.

## Define multiple events using event properties

These steps create a `Sensor` class that exposes 10 event properties, all backed by a single `EventHandlerList`.

1. Define an event data class that inherits from <xref:System.EventArgs>.

   Add properties for each piece of data you want to pass to the handler:

   :::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Sensor.cs" id="SensorEventArgs":::
   :::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Sensor.vb" id="SensorEventArgs":::

1. Declare an <xref:System.ComponentModel.EventHandlerList> field to store the delegates:

   :::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Sensor.cs" id="EventHandlerListField":::
   :::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Sensor.vb" id="EventHandlerListField":::

1. Declare a unique key for each event.

   `EventHandlerList` stores delegates by key. Use a `static readonly` object (`Shared ReadOnly` in Visual Basic) for each key—object identity ensures each key is truly unique:

   :::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Sensor.cs" id="EventKeys":::
   :::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Sensor.vb" id="EventKeys":::

1. Define each event as an event property with custom add and remove accessors.

   Each accessor calls `AddHandler` or `RemoveHandler` on the list using that event's key. In C#, also add a `protected virtual` raise method that retrieves the delegate from the list by key and invokes it. In Visual Basic, the `Custom Event` declaration already includes a `RaiseEvent` block that does this:

   :::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Sensor.cs" id="SingleEventProperty":::
   :::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Sensor.vb" id="SingleEventProperty":::

   Repeat this pattern for each event, using its corresponding key.

1. Subscribe to the event using the `+=` operator (in Visual Basic, `AddHandler`):

   :::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Program.cs" id="SubscribeEvent":::
   :::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Program.vb" id="SubscribeEvent":::

1. Define the event handler.

   The signature must match the <xref:System.EventHandler`1> delegate—an `object` sender and your event data class as the second parameter:

   :::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Program.cs" id="HandleEvent":::
   :::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Program.vb" id="HandleEvent":::

The following example shows the complete `Sensor` class implementation:

:::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/Sensor.cs" id="EventProperties":::
:::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/Sensor.vb" id="EventProperties":::

## Related content

- <xref:System.ComponentModel.EventHandlerList?displayProperty=nameWithType>
- [Events](index.md)
