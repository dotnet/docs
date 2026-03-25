---
title: "Handle multiple events using event properties"
description: Learn how to handle many events by using event properties. Define delegate collections, event keys, and event properties. Implement add and remove accessor methods.
ms.date: "03/30/2017"
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

# Handle multiple events using event properties

When a class raises many events, field-like events generate a backing-field reference type for each event. As the number of events grows, these allocations become wasteful. Instead, use event properties backed by an <xref:System.ComponentModel.EventHandlerList>, which stores events by key.

To store the delegates for each event, use an <xref:System.ComponentModel.EventHandlerList> or implement your own collection. The collection must provide methods for setting, accessing, and retrieving the event handler delegate based on the event key. For example, use a <xref:System.Collections.Hashtable> or a custom class derived from <xref:System.Collections.DictionaryBase>. The delegate collection's implementation details don't need to be exposed outside your class.

Each event property defines an add accessor and a remove accessor. The add accessor adds the input delegate to the delegate collection, and the remove accessor removes it. Both accessors use a predefined key to add and remove instances from the collection.

## Handle multiple events using event properties

1. Define a delegate collection within the class that raises the events.
1. Define a key for each event.
1. Define the event properties in the class that raises the events.
1. Use the delegate collection to implement the add and remove accessor methods for the event properties.
1. Use the public event properties to add and remove event handler delegates in the classes that handle the events.

The following example implements the `MouseDown` and `MouseUp` event properties using an <xref:System.ComponentModel.EventHandlerList> to store each event's delegate.

:::code language="csharp" source="./snippets/how-to-handle-multiple-events-using-event-properties/csharp/DrawingCanvas.cs" id="EventProperties":::
:::code language="vb" source="./snippets/how-to-handle-multiple-events-using-event-properties/vb/DrawingCanvas.vb" id="EventProperties":::

## Related content

- <xref:System.ComponentModel.EventHandlerList?displayProperty=nameWithType>
- [Events](index.md)
- [How to declare custom events to conserve memory](../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-conserve-memory.md)
