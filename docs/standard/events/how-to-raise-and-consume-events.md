---
title: "Raise and consume events"
description: Raise and consume events in .NET. See examples that use the EventHandler delegate, the EventHandler<TEventArgs> delegate, and a custom delegate.
ms.date: 03/24/2026
ms.topic: how-to
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "events [.NET], raising"
  - "raising events"
  - "events [.NET], samples"
---

# Raise and consume events

This article shows how to work with events in .NET using the <xref:System.EventHandler> delegate, the <xref:System.EventHandler`1> delegate, and a custom delegate, with examples for events with and without data.

## Prerequisites

Familiarize yourself with the concepts in the [Events](index.md) article.

## Raise an event without data

These steps create a `Counter` class that fires a `ThresholdReached` event when a running total reaches or exceeds a threshold.

1. Declare the event using the <xref:System.EventHandler> delegate.

   Use `EventHandler` when your event doesn't pass data to the handler:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventNoData.cs" id="DeclareEvent":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventNoData.vb" id="DeclareEvent":::

1. Add a `protected virtual` method (`Protected Overridable` in Visual Basic) to raise the event.

   This pattern lets derived classes override the event-raising behavior without directly invoking the delegate. In C#, use the null-conditional operator (`?.`) to guard against no subscribers (in Visual Basic, `RaiseEvent` handles this automatically):

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventNoData.cs" id="RaiseEventMethod":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventNoData.vb" id="RaiseEventMethod":::

1. Call the raise method when the condition is met.

   Pass <xref:System.EventArgs.Empty> because this event carries no data:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventNoData.cs" id="RaiseEvent":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventNoData.vb" id="RaiseEvent":::

1. Subscribe to the event using the `+=` operator (in Visual Basic, `AddHandler`):

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventNoData.cs" id="SubscribeEvent":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventNoData.vb" id="SubscribeEvent":::

1. Define the event handler method.

   Its signature must match the <xref:System.EventHandler> delegate—the first parameter is the event source and the second is <xref:System.EventArgs>:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventNoData.cs" id="HandleEvent":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventNoData.vb" id="HandleEvent":::

The following example shows the complete implementation:

:::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventNoData.cs" id="ThresholdReachedNoData":::
:::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventNoData.vb" id="ThresholdReachedNoData":::

## Raise an event with data

These steps extend the previous `Counter` example to raise an event that includes data—the threshold value and the time it was reached.

1. Define an event data class that inherits from <xref:System.EventArgs>.

   Add properties for each piece of data you want to pass to the handler:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="EventDataClass2":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="EventDataClass2":::

1. Declare the event using the <xref:System.EventHandler`1> delegate, passing your event data class as the type argument:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="DeclareEvent2":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="DeclareEvent2":::

1. Add a `protected virtual` method (`Protected Overridable` in Visual Basic) to raise the event.

   This pattern lets derived classes override the event-raising behavior without directly invoking the delegate. In C#, use the null-conditional operator (`?.`) to guard against no subscribers (in Visual Basic, `RaiseEvent` handles this automatically):

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="RaiseEventMethod2":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="RaiseEventMethod2":::

1. Populate the event data object and call the raise method when the condition is met:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="RaiseEvent2":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="RaiseEvent2":::

1. Subscribe to the event using the `+=` operator (in Visual Basic, `AddHandler`):

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="SubscribeEvent2":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="SubscribeEvent2":::

1. Define the event handler.

   The second parameter type is `ThresholdReachedEventArgs` instead of <xref:System.EventArgs>, which lets the handler read the event data:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="HandleEvent2":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="HandleEvent2":::

The following example shows the complete implementation:

:::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithData.cs" id="ThresholdReachedWithData":::
:::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithData.vb" id="ThresholdReachedWithData":::

## Declare a custom delegate for an event

Declare a custom delegate only in rare scenarios, such as making your class available to legacy code that can't use generics. For most cases, use <xref:System.EventHandler`1> as shown in the previous section.

1. Declare the custom delegate type.

   The delegate signature must match the event handler signature—two parameters: the event source (`object`; in Visual Basic, `Object`) and the event data class:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="DeclareDelegateType":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="DeclareDelegateType":::

1. Declare the event using your custom delegate type instead of <xref:System.EventHandler`1>:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="DeclareEventWithDelegate":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="DeclareEventWithDelegate":::

1. Add a `protected virtual` method (`Protected Overridable` in Visual Basic) to raise the event.

   In C#, use the null-conditional operator (`?.`) to guard against no subscribers (in Visual Basic, `RaiseEvent` handles this automatically):

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="RaiseEventMethodDelegate":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="RaiseEventMethodDelegate":::

1. Populate the event data object and call the raise method when the condition is met:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="RaiseEventDelegate":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="RaiseEventDelegate":::

1. Subscribe to the event using the `+=` operator (in Visual Basic, `AddHandler`):

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="SubscribeEventDelegate":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="SubscribeEventDelegate":::

1. Define the event handler.

   The handler signature must match the custom delegate—`object` for the sender and your event data class for the second parameter:

   :::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="HandleEventDelegate":::
   :::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="HandleEventDelegate":::

The following example shows the complete implementation:

:::code language="csharp" source="./snippets/how-to-raise-and-consume-events/csharp/EventWithDelegate.cs" id="ThresholdReachedWithDelegate":::
:::code language="vb" source="./snippets/how-to-raise-and-consume-events/vb/EventWithDelegate.vb" id="ThresholdReachedWithDelegate":::

## Related content

- [Events](index.md)
