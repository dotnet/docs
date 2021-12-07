---
title: BinaryFormatter event source
description: Learn how to use the BinaryFormatter event source to log when serialization or deserialization is occurring.
ms.date: 12/03/2020
ms.author: levib
author: GrabYourPitchforks
ms.topic: reference
---
# BinaryFormatter event source

Starting with .NET 5, <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> includes a built-in <xref:System.Diagnostics.Tracing.EventSource> that gives you visibility into when an object serialization or deserialization is occurring. Apps can use <xref:System.Diagnostics.Tracing.EventListener>-derived types to listen for these notifications and log them.

This functionality is not a substitute for a <xref:System.Runtime.Serialization.SerializationBinder> or an <xref:System.Runtime.Serialization.ISerializationSurrogate> and can't be used to modify the data being serialized or deserialized. Rather, this eventing system is intended to provide insight into the types being serialized or deserialized. It can also be used to detect unintended calls into the `BinaryFormatter` infrastructure, such as calls originating from third-party library code.

## Description of events

The `BinaryFormatter` event source has the well-known name `System.Runtime.Serialization.Formatters.Binary.BinaryFormatterEventSource`. Listeners may subscribe to 6 events.

### SerializationStart event (id = `10`)

Raised when <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize%2A?displayProperty=nameWithType> has been called and has started the serialization process. This event is paired with the `SerializationEnd` event. The `SerializationStart` event can be called recursively if an object calls `BinaryFormatter.Serialize` within its own serialization routine.

This event doesn't contain a payload.

### SerializationEnd event (id = `11`)

Raised when `BinaryFormatter.Serialize` has completed its work. Each occurrence of `SerializationEnd` denotes the completion of the last unpaired `SerializationStart` event.

This event doesn't contain a payload.

### SerializingObject event (id = `12`)

Raised when `BinaryFormatter.Serialize` is in the process of serializing a non-primitive type. The `BinaryFormatter` infrastructure special-cases certain types (such as `string` and `int`) and doesn't raise this event when these types are encountered. This event is raised for user-defined types and other types that `BinaryFormatter` doesn't natively understand.

This event may be raised zero or more times between `SerializationStart` and `SerializationEnd` events.

This event contains a payload with one argument:

* `typeName` (`string`): The assembly-qualified name (see <xref:System.Type.AssemblyQualifiedName?displayProperty=nameWithType>) of the type being serialized.

### DeserializationStart event (id = `20`)

Raised when <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=nameWithType> has been called and has started the deserialization process. This event is paired with the `DeserializationEnd` event. The `DeserializationStart` event can be called recursively if an object calls `BinaryFormatter.Deserialize` within its own deserialization routine.

This event doesn't contain a payload.

### DeserializationEnd event (id = `21`)

Raised when `BinaryFormatter.Deserialize` has completed its work. Each occurrence of `DeserializationEnd` denotes the completion of the last unpaired `DeserializationStart` event.

This event doesn't contain a payload.

### DeserializingObject event (id = `22`)

Raised when `BinaryFormatter.Deserialize` is in the process of deserializing a non-primitive type. The `BinaryFormatter` infrastructure special-cases certain types (such as `string` and `int`) and doesn't raise this event when these types are encountered. This event is raised for user-defined types and other types that `BinaryFormatter` doesn't natively understand.

This event may be raised zero or more times between `DeserializationStart` and `DeserializationEnd` events.

This event contains a payload with one argument.

* `typeName` (`string`): The assembly-qualified name (see <xref:System.Type.AssemblyQualifiedName?displayProperty=nameWithType>) of the type being deserialized.

### \[Advanced\] Subscribing to a subset of notifications

Listeners who wish to subscribe to only a subset of notifications can choose which keywords to enable.

* `Serialization` = `(EventKeywords)1`: Raises the `SerializationStart`, `SerializationEnd`, and `SerializingObject` events.
* `Deserialization` = `(EventKeywords)2`: Raises the `DeserializationStart`, `DeserializationEnd`, and `DeserializingObject` events.

If no keyword filters are provided during `EventListener` registration, all events are raised.

For more information, see <xref:System.Diagnostics.Tracing.EventKeywords?displayProperty=nameWithType>.

## Sample code

The following code:

- creates an `EventListener`-derived type that writes to `System.Console`,
- subscribes that listener to `BinaryFormatter`-produced notifications,
- serializes and deserializes a simple object graph using `BinaryFormatter`, and
- analyzes the events that have been raised.

:::code language="csharp" source="snippets/binaryformatter-event-source/csharp/Program.cs":::

The preceding code produces output similar to the following example:

```output
Event SerializationStart (id=10) received.
Event SerializingObject (id=12) received.
typeName = BinaryFormatterEventSample.Person, BinaryFormatterEventSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Event SerializingObject (id=12) received.
typeName = BinaryFormatterEventSample.Book, BinaryFormatterEventSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Event SerializationStop (id=11) received.
Event DeserializationStart (id=20) received.
Event DeserializingObject (id=22) received.
typeName = BinaryFormatterEventSample.Person, BinaryFormatterEventSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Event DeserializingObject (id=22) received.
typeName = BinaryFormatterEventSample.Book, BinaryFormatterEventSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Event DeserializationStop (id=21) received.
Rehydrated person Logan Edwards
Favorite book: A Tale of Two Cities by Charles Dickens, list price 10.25
```

In this sample, the console-based `EventListener` logs that serialization starts, instances of `Person` and `Book` are serialized, and then serialization completes. Similarly, once deserialization has started, instances of `Person` and `Book` are deserialized, and then deserialization completes.

The app then prints the values contained in the deserialized `Person` to demonstrate that the object did in fact serialize and deserialize properly.

## See also

For more information on using `EventListener` to receive `EventSource`-based notifications, see [the `EventListener` class](xref:System.Diagnostics.Tracing.EventListener).
